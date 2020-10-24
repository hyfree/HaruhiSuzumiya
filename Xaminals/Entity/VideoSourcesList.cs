using System;
using System.Collections.Generic;
using System.Text;

namespace HaruhiSuzumiya.Common.Entity
{
    /// <summary>
    /// 视频来源表
    /// </summary>
    public class VideoSourcesList
    {
        public long SourceId { get; set; }
        public string SourceName { get; set; }
        public VideoSourceProvider sourceProvider{get;set;}
        public  SourceType SourceType{get;set;}
        public List<VideoSource> Videos{get;set;}
    }
}
