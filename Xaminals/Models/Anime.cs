using System;
using System.Collections.Generic;
using System.Text;

namespace HaruhiSuzumiya.APP.Models
{
    public  class Anime
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
