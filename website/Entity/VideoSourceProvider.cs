using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HaruhiSuzumiya.Logic.Entity
{
    /// <summary>
    /// 视频提供者
    /// </summary>
    public class VideoSourceProvider
    {  
        [Key]
        public long VideoSourceProviderId{get;set;}
        public  string ProvideName{get;set; }
        public  string UrlTemplate{get;set; }
        public  string Type{get;set; }
        


    }
}
