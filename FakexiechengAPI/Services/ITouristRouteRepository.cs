using FakexiechengAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakexiechengAPI.Services
{
    public interface ITouristRouteRepository
    {
        /// <summary>
        /// 定义获取所有旅游线路接口
        /// </summary>
        /// <returns></returns>
        IEnumerable<TouristRoute> GetTouristRoutes();
        /// <summary>
        /// 定义获取单条旅游线路接口
        /// </summary>
        /// <param name="TouristRouteId"></param>
        /// <returns></returns>
        TouristRoute GetTouristRoute(Guid TouristRouteId);
    }
}
