using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakexiechengAPI.Models
{
    public class TouristRoute
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }
        [Range(0.0, 1.0)]
        public double? DiscountPresent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeparttureTime { get; set; }
        [MaxLength]
        public string Features { get; set; }
        [MaxLength]
        public string Fees { get; set; }//费用说明
        [MaxLength]
        public string Notes { get; set; }
        public ICollection<TouristRoutePicture> touristRoutePictures { get; set; } = new List<TouristRoutePicture>(); //new对象是为了程序更健壮//链接路线照片 属性 一条旅游线路对应多张照片用数组形式
    }
}
