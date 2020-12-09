using FakexiechengAPI.Database;
using FakexiechengAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakexiechengAPI.Services
{
    /// <summary>
    /// 获取旅游路线数据仓库
    /// </summary>
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext _context;

        public TouristRouteRepository(AppDbContext context)//注入的数据库上下文对象
        {
            _context = context;
        }
        /// <summary>
        /// 返回指定路线
        /// </summary>
        /// <param name="TouristRouteId"></param>
        /// <returns></returns>
        public TouristRoute GetTouristRoute(Guid TouristRouteId)
        {
            return _context.touristRoutes.FirstOrDefault(n => n.Id == TouristRouteId);
        }
        /// <summary>
        /// 返回所有路线
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _context.touristRoutes;
        }
    }
}
