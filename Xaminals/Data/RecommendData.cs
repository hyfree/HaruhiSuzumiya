using HaruhiSuzumiya.Common.Entity;
using System.Collections.Generic;

namespace HaruhiSuzumiya.APP.Data
{
    public class RecommendData
    {
        public static IList<Anime> RecommendImages { get; private set; }

        static RecommendData()
        {
            RecommendImages = new List<Anime>
            {
                new Anime() { Name = "overlord", CoverImageUrl = "photo.png", Details = "这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介" },
                new Anime() { Name = "女神异闻录", CoverImageUrl = "photo.png", Details = "这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介" },
                new Anime() { Name = "我的英雄", CoverImageUrl = "photo.png", Details = "这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介" },
                new Anime() { Name = "异世界魔王", CoverImageUrl = "photo.png", Details = "这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介这是动漫简介" }
            };
        }
    }
}