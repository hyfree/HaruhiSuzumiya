using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HaruhiSuzumiya.Logic.Entity
{
    public class AnimeListPage
    {
        [Key]
        public long AnimeListPageId{get;set;}
        public VideoSourceProvider VideoSourceProvider{get;set;}
        public string SourceURL{get;set;}
        public SourceTypeEnum SourceType{get;set;}

      
    }
}
