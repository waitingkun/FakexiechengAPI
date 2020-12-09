using FakexiechengAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakexiechengAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _itouristRouteRepository;//私有变量以_开头命名
        /// <summary>
        /// 通过构造函数将controller和数据仓库绑定
        /// </summary>
        /// <param name="touristRouteRepository"></param>
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            _itouristRouteRepository = touristRouteRepository;
        }
        public IActionResult GetTouristRoutes()
        {
            var routes = _itouristRouteRepository.GetTouristRoutes();
            return Ok(routes);//http请求状态码200 ok
        }
    }
}
