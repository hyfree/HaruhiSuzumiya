using System;
using System.Collections.Generic;
using System.Text;
using Xaminals.Models;

namespace Xaminals.Data
{
    public class CarouselData
    {
        public static IList<Anime> CarouselImages { get; private set; }

        static CarouselData()
        {
            CarouselImages = new List<Anime>
            {
                new Anime() { Name = "overlord", ImageUrl = "overlord.jpg", Details = "" },
                new Anime() { Name = "女神异闻录", ImageUrl = "nsywl.jpg", Details = "" },
                new Anime() { Name = "我的英雄", ImageUrl = "wdyx.jpg", Details = "" },
                new Anime() { Name = "异世界魔王", ImageUrl = "ysjmw.jpg", Details = "" }
            };





        }

    }
}
