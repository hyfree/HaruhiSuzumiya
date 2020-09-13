using System;
using System.Collections.Generic;
using System.Text;
using HaruhiSuzumiya.APP.Models;
using HaruhiSuzumiya.Common.Entity;

namespace HaruhiSuzumiya.APP.Data
{
    /// <summary>
    /// 动漫数据 数据
    /// </summary>
    public class AnimeData
    {
        public static IList<Anime> AnimeImages { get; private set; }

        static AnimeData()
        {
            AnimeImages = new List<Anime>
            {
                new Anime() { Name = "overlord", CoverImageUrl = "overlord.jpg", Details = "" },
                new Anime() { Name = "女神异闻录", CoverImageUrl = "nsywl.jpg", Details = "" },
                new Anime() { Name = "我的英雄", CoverImageUrl = "wdyx.jpg", Details = "" },
                new Anime() { Name = "异世界魔王", CoverImageUrl = "ysjmw.jpg", Details = "" }
            };





        }

    }
}
