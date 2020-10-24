using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HaruhiSuzumiya.Logic.Entity
{
    /// <summary>
    ///视频资源
    /// </summary>
    public class VideoSource
    {
        [Key]
        public long VideoSourceId { get; set; }
        public long VideoSourceProviderId{get;set;}
        public long  SerialNumber{get;set;}
        public  VideoSourceProvider VideoSourceProvider{get;set;}
        public SourceTypeEnum SourceType { get; set; }
        public string SourceURL{get;set;}
    }
}
