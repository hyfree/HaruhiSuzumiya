using System;
using System.ComponentModel;
using System.IO;
using Android.Content;
using Android.Widget;
using ARelativeLayout = Android.Widget.RelativeLayout;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FormsVideoLibrary;
using Android.App;
using Android.Views;

[assembly: ExportRenderer(typeof(FormsVideoLibrary.VideoPlayer),
                          typeof(FormsVideoLibrary.Droid.VideoPlayerRenderer))]

namespace FormsVideoLibrary.Droid
{
    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, ARelativeLayout>
    {
       
        VideoView videoView;
        Android.Widget.ProgressBar progressBar;
        ImageView imageView;

    
        static Activity _context;
        double playerHeight;
        bool hasScrollView = false;
        const string FullScreenImageSource = "landscape_mode.png";
        const string ExitFullScreenImageSource = "portrait_mode.png";
        static double deviceWidth;
        static double deviceHeight;
        bool isFullScreen = false;

        MediaController mediaController;    // Used to display transport controls
        bool isPrepared;
        public event EventHandler<bool> FullScreenStatusChanged;
   
        public static void Init(Activity context)
        {
            _context = context;
            deviceWidth = (int)(context.Resources.DisplayMetrics.WidthPixels / context.Resources.DisplayMetrics.Density);
            deviceHeight = (int)(context.Resources.DisplayMetrics.HeightPixels / context.Resources.DisplayMetrics.Density);
           
        }
        public VideoPlayerRenderer(Context context) : base(context)
        {
            Init(context as Activity);
        }
        private void InitProgressBar()
        {
            progressBar = new Android.Widget.ProgressBar(Context);
            progressBar.Indeterminate = false;
            progressBar.Visibility = Android.Views.ViewStates.Invisible;
            var lparams = new Android.Widget.RelativeLayout.LayoutParams(100, 100);
            lparams.AddRule(LayoutRules.CenterInParent);
            Control.AddView(progressBar, lparams);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    // Save the VideoView for future reference
                    videoView = new VideoView(Context);

                    // Put the VideoView in a RelativeLayout
                    ARelativeLayout relativeLayout = new ARelativeLayout(Context);
                    relativeLayout.AddView(videoView);

                    // Center the VideoView in the RelativeLayout
                    ARelativeLayout.LayoutParams layoutParams =
                        new ARelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    layoutParams.AddRule(LayoutRules.CenterInParent);
                    videoView.LayoutParameters = layoutParams;

                    // Handle a VideoView event
                    videoView.Prepared += OnVideoViewPrepared;

                    SetNativeControl(relativeLayout);
                }

                SetAreTransportControlsEnabled();
                InitProgressBar();
                SetSource();

                args.NewElement.UpdateStatus += OnUpdateStatus;
                args.NewElement.PlayRequested += OnPlayRequested;
                args.NewElement.PauseRequested += OnPauseRequested;
                args.NewElement.StopRequested += OnStopRequested;
             
            }

            if (args.OldElement != null)
            {
                args.OldElement.UpdateStatus -= OnUpdateStatus;
                args.OldElement.PlayRequested -= OnPlayRequested;
                args.OldElement.PauseRequested -= OnPauseRequested;
                args.OldElement.StopRequested -= OnStopRequested;
            }

            InitializeFullScreenCapability();

        }

        private void InitializeFullScreenCapability()
        {
            Xamarin.Forms.Element view = Element;
            while (view.Parent != null)
            {
                view = view.Parent;
                if (view is Xamarin.Forms.ScrollView)
                {
                    //(view as Xamarin.Forms.ScrollView).Scrolled += delegate { DisplaySeekbar(false); };
                    hasScrollView = true;
                    break;
                }
            }
            imageView = new ImageView(_context) { };
            imageView.SetImageResource(HaruhiSuzumiya.Droid.Resource.Drawable.portrait_mode);
            var lv = new Android.Widget.RelativeLayout.LayoutParams(60, 60);
            lv.SetMargins(0, 30, 30, 0);
            lv.AddRule(LayoutRules.AlignParentRight);
            imageView.LayoutParameters = lv;
            Control.AddView(imageView);

            imageView.Click += delegate
            {
                if (IsFullScreen)
                    ExitFullScreen();
                else
                    FullScreen(hasScrollView);
            };
        }
        private bool IsFullScreen
        {
            get
            {
                return isFullScreen;
            }
        }

        private void FullScreen(bool resizeLayout = false)
        {
            if (isFullScreen)
                return;

            _context.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
            var window = (_context as Activity).Window;
            window.AddFlags(WindowManagerFlags.Fullscreen);
         
            imageView.SetImageResource(HaruhiSuzumiya.Droid.Resource.Drawable.landscape_mode);
            isFullScreen = true;
            if (resizeLayout)
            {
                if (Element.HeightRequest == -1)
                    playerHeight = (Control.Width / _context.Resources.DisplayMetrics.Density);
                else
                    playerHeight = Element.HeightRequest;
                Element.HeightRequest = deviceWidth;
            }
            else
            {
                playerHeight = 0;
            }
            FullScreenStatusChanged?.Invoke(this, true);
        }

        private void ExitFullScreen()
        {
            if (!isFullScreen)
                return;

            imageView.SetImageResource(HaruhiSuzumiya.Droid.Resource.Drawable.portrait_mode);
            _context.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            var window = (_context as Activity).Window;
            window.ClearFlags(WindowManagerFlags.Fullscreen);
            isFullScreen = false;
            if (playerHeight > 0)
            {
                Element.HeightRequest = playerHeight;
            }
            FullScreenStatusChanged?.Invoke(this, false);
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null && videoView != null)
            {
                videoView.Prepared -= OnVideoViewPrepared;
            }
            if (Element != null)
            {
                Element.UpdateStatus -= OnUpdateStatus;
            }

            base.Dispose(disposing);
        }

        void OnVideoViewPrepared(object sender, EventArgs args)
        {
            progressBar.Visibility = Android.Views.ViewStates.Invisible;
            isPrepared = true;
            ((IVideoPlayerController)Element).Duration = TimeSpan.FromMilliseconds(videoView.Duration);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.AreTransportControlsEnabledProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
            else if (args.PropertyName == VideoPlayer.PositionProperty.PropertyName)
            {
                if (Math.Abs(videoView.CurrentPosition - Element.Position.TotalMilliseconds) > 1000)
                {
                    videoView.SeekTo((int)Element.Position.TotalMilliseconds);
                }
            }
        }

        void SetAreTransportControlsEnabled()
        {
            if (Element.AreTransportControlsEnabled)
            {
                mediaController = new MediaController(Context);
                mediaController.SetMediaPlayer(videoView);
                videoView.SetMediaController(mediaController);
            }
            else
            {
                videoView.SetMediaController(null);

                if (mediaController != null)
                {
                    mediaController.SetMediaPlayer(null);
                    mediaController = null;
                }
            }
        }

        void SetSource()
        {
            isPrepared = false;
            bool hasSetSource = false;
            progressBar.Visibility = Android.Views.ViewStates.Visible;
            if (Element.Source is UriVideoSource)
            {
                string uri = (Element.Source as UriVideoSource).Uri;

                if (!String.IsNullOrWhiteSpace(uri))
                {
                    videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
                    hasSetSource = true;
                }
            }
            else if (Element.Source is FileVideoSource)
            {
                string filename = (Element.Source as FileVideoSource).File;

                if (!String.IsNullOrWhiteSpace(filename))
                {
                    videoView.SetVideoPath(filename);
                    hasSetSource = true;
                }
            }
            else if (Element.Source is ResourceVideoSource)
            {
                string package = Context.PackageName;
                string path = (Element.Source as ResourceVideoSource).Path;

                if (!String.IsNullOrWhiteSpace(path))
                {
                    string filename = Path.GetFileNameWithoutExtension(path).ToLowerInvariant();
                    string uri = "android.resource://" + package + "/raw/" + filename;
                    videoView.SetVideoURI(Android.Net.Uri.Parse(uri));
                    hasSetSource = true;
                }
            }

            if (hasSetSource && Element.AutoPlay)
            {
                videoView.Start();
            }
        }

        // Event handler to update status
        void OnUpdateStatus(object sender, EventArgs args)
        {
            VideoStatus status = VideoStatus.NotReady;

            if (isPrepared)
            {
                status = videoView.IsPlaying ? VideoStatus.Playing : VideoStatus.Paused;
            }

            ((IVideoPlayerController)Element).Status = status;

            // Set Position property
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(videoView.CurrentPosition);
            ((IElementController)Element).SetValueFromRenderer(VideoPlayer.PositionProperty, timeSpan);
        }

        // Event handlers to implement methods
        void OnPlayRequested(object sender, EventArgs args)
        {
            videoView.Start();
        }

        void OnPauseRequested(object sender, EventArgs args)
        {
            videoView.Pause();
        }

        void OnStopRequested(object sender, EventArgs args)
        {
            videoView.StopPlayback();
           
        }


    }
}