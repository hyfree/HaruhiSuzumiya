using System;
using System.Collections.Generic;
using System.Text;
using HaruhiSuzumiya.APP.Models;

namespace HaruhiSuzumiya.APP.Data
{
    public class VolumeData
    {
        public static IList<Volume> Volumes { get; private set; }

        static VolumeData()
        {
            Volumes = new List<Volume>();

            Volumes.Add(new Volume() { Name="热血",ImageUrl= "rexue" });
            Volumes.Add(new Volume() { Name="青春",ImageUrl= "qingchun" });
            Volumes.Add(new Volume() { Name="萝莉",ImageUrl= "luoli"});
            Volumes.Add(new Volume() { Name="激战",ImageUrl= "jizhan"});
            Volumes.Add(new Volume() { Name="恐怖",ImageUrl= "kongbu"});
            Volumes.Add(new Volume() { Name="奇幻",ImageUrl= "qihuan"});
            Volumes.Add(new Volume() { Name="装逼",ImageUrl= "zhuangbi"});
            Volumes.Add(new Volume() { Name="后宫",ImageUrl= "hougong"});
            Volumes.Add(new Volume() { Name="冒险",ImageUrl= "maoxian"});
            Volumes.Add(new Volume() { Name="轻小说",ImageUrl= "qingxiaoshuo"});
            Volumes.Add(new Volume() { Name="肉番",ImageUrl= "roufan"});
            Volumes.Add(new Volume() { Name="搞笑",ImageUrl= "gaoxiao"});
  
            Volumes.Add(new Volume() { Name="推理",ImageUrl= "tuili"});
            Volumes.Add(new Volume() { Name="科幻",ImageUrl= "kehuan"});
            Volumes.Add(new Volume() { Name="耽美",ImageUrl= "danmei"});
            Volumes.Add(new Volume() { Name="运动",ImageUrl= "yundong"});
            Volumes.Add(new Volume() { Name="游戏",ImageUrl= "youxi"});
            Volumes.Add(new Volume() { Name="真人",ImageUrl= "zhenren"});
            Volumes.Add(new Volume() { Name="治愈系",ImageUrl= "zhiyuxi"});
            Volumes.Add(new Volume() { Name="励志",ImageUrl= "lizhi"});
            Volumes.Add(new Volume() { Name="百合",ImageUrl= "baihe"});
            Volumes.Add(new Volume() { Name="泡面番",ImageUrl= "paomianfan"});
            Volumes.Add(new Volume() { Name="乙女",ImageUrl= "yinv"});
            Volumes.Add(new Volume() { Name="剧场版",ImageUrl= "juchangban"});
      

          
        }

    }
}
