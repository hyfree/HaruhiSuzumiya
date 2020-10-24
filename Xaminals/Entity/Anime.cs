using System;
using System.Collections.Generic;
using System.Text;

namespace HaruhiSuzumiya.Common.Entity
{   
   /// <summary>
   /// 动漫
   /// </summary>
    public  class Anime
    {
        public long AnimeEpisodeId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string CoverImageUrl{get;set;}
        public string Details{get;set;}
        public string Tags{get;set;}
        public List<VideoSourcesList> VideoSourcesLists { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
