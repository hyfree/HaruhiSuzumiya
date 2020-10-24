using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HaruhiSuzumiya.Logic.Entity
{   
   /// <summary>
   /// 动漫
   /// </summary>
    public  class Anime
    {
        [Key]
        public long AnimeId { get; set; }
        public long  AnimeSeriesId{get;set;}
        public string Name { get; set; }
        public int count{get;set;}
        public int Year { get; set; }
        public int Month { get; set; }
        public string CoverImageUrl{get;set;}
        public string Details{get;set;}
        public List<string> Tags{get;set;}
        public List<VideoSourceProvider> VideoSourceProvider{get;set;}

        public override string ToString()
        {
            return Name;
        }
    }
}
