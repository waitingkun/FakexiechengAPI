using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakexiechengAPI.Models
{
    public class TouristRoutePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//定义自增
        public int Id { get; set;  }
        [MaxLength(100)]    
        public string Url { get; set; }
        [ForeignKey("TouristRouteId")]//这里的外键关系TouristRouteId是外键关系model（TouristRoute）名字 + TouristRoute主键（Id）
        public Guid TouristRouteId { get; set; }//外键关系 与旅游线路关联
        public TouristRoute touristRoute { get; set; }//连接旅游线路属性
    }
}
