using FakexiechengAPI.Database;
using FakexiechengAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FakexiechengAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();//注册MVC Controller
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();//依赖注入，每次请求都会注册一个新的数据仓库
            //services.AddSingleton //只在初次请求创建一次数据仓库，之后每一次使用相同的，内存占用少，效率高，但是可能会造成数据污染，
            //services.AddScoped //引入了事务的概念，暂时不做了解

            services.AddDbContext<AppDbContext>(option =>//IOC注入数据库上下文对象后需要option 配置连接数据库字符串 
            {
                //option.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Fakexiecheng;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);//使用UseSqlServer拓展方法需要nuget安装entityFramework sql server
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//IApplicationBuilder创建HTTP请求通道,MiddleWare中间件具体处理，IWebHostEnvironment配置是否是生产环境
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
