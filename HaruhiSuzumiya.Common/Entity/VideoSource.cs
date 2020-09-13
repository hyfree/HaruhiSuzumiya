using System;
using System.Collections.Generic;
using System.Text;

namespace HaruhiSuzumiya.Common.Entity
{
    /// <summary>
    ///视频来源
    /// </summary>
    public class VideoSource
    {
        public long VideoId { get; set; }
        public SourceType SourceType { get; set; }
        public string SourceURL{get;set;}


    }
}
