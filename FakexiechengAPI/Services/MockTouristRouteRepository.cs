using FakexiechengAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakexiechengAPI.Services
{

    /// <summary>
    /// 模拟假数据服务
    /// </summary>
    public class MockTouristRouteRepository : ITouristRouteRepository
    {
        private List<TouristRoute> _routes;//定义旅游线路list，保存模拟数据
        public  MockTouristRouteRepository()//构造函数初始化_routes
        {
            if(_routes == null)
            {
                InitializeTouristRoutes();
            }
        }
        /// <summary>
        /// 初始化数据仓库，定义模拟数据
        /// </summary>
        private void InitializeTouristRoutes()
        {
            _routes = new List<TouristRoute>
            {
                new TouristRoute
                {
                    Id = Guid.NewGuid(),
                    Title = "黄山",
                    Description = "黄山真好玩",
                    OriginalPrice = 1299,
                    Features = "<p>娱购</p>",
                    Fees = "<p>交通费自理</p>",
                    Notes ="<p>请注意安全</p>"

                },
                 new TouristRoute
                {
                    Id = Guid.NewGuid(),
                    Title = "华山",
                    Description = "华山真好玩",
                    OriginalPrice = 1299,
                    Features = "<p>娱购</p>",
                    Fees = "<p>交通费自理</p>",
                    Notes ="<p>请注意安全</p>"

                },
            };
        }

        public TouristRoute GetTouristRoute(Guid TouristRouteId)
        {
            return _routes.FirstOrDefault(n => n.Id == TouristRouteId);//lamda表达式 n代表_routes列表的每一个元素，如果找不到FirstOrDefault将会返回空
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _routes;
        }
    }
}
