using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakexiechengAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace FakexiechengAPI.Database
{
    /// <summary>
    /// 数据库上下文连接对象，连接数据库和本地代码
    /// </summary>
    public class AppDbContext:DbContext //需要注入Dbcontextpotion的实例 （原因暂时不了解）
    {
        /// <summary>
        /// 构造函数将Dbcontextoption的实例传递进来
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// 映射Model到数据库table 旅游路线表  
        /// </summary>
        public DbSet<TouristRoute> touristRoutes { get; set; }
        /// <summary>
        /// 映射Model到数据库table 旅游路线照片  
        /// </summary>
        public DbSet<TouristRoutePicture> touristRoutePictures { get; set; }
        /// <summary>
        /// DbContext类中的OnModelCreating方法 控制数据库和entity的映射 这里重写
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)//modelBuilder：1 初始化数据库 2 创建数据库时补充个说明，可以添加主键等
        {
            //modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute() { //HasData函数提供模型数据支持
            //    Id = Guid.NewGuid(),
            //    Title = "xiechengTitle",
            //    Description = "shuoming",
            //    OriginalPrice = 0,
            //    CreateTime = DateTime.UtcNow
            //});
               
            //读取虚拟json数据反序列化为Model list对象然后将数据转换为sql insert into语句插入数据库表
            var touristRoutejsondata = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/touristRoutesMockData.json");
            IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRoutejsondata);
            modelBuilder.Entity<TouristRoute>().HasData(touristRoutes);

            var touristRoutePicturejsondata = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/touristRoutePicturesMockData.json");
            IList<TouristRoutePicture> touristRoutePicture = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRoutePicturejsondata);
            modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutePicture);
            base.OnModelCreating(modelBuilder);
        }
         
    }
}
