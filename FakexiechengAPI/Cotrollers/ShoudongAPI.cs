using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakexiechengAPI.Controllers
{
    [Route("api/shoudongapi")]//路由
    public class ShoudongAPIController: Controller//标准定义Controller 名称以Controller结尾 继承Controller父类，查看官方文档点击Controller按F1
    {
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new int[] {1,2};
        }
    }
}
