namespace CheLiangGuanLi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarRecord")]
    public partial class CarRecord
    {
        [Key]
        public int CarId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="车主姓名")]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "车主电话")]
        public string Mobile { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "车辆名称")]
        public string CarName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "车牌号")]
        public string CarNo { get; set; }

        [Required]
        [StringLength(20)] 
        [Display(Name = "车型")]
        public string CarType { get; set; }

        public DateTime DriveTime { get; set; }
        [Display(Name = "进出状态")]
        public int? State { get; set; }
        [Display(Name = "停车类型")]
        public int? Type { get; set; }

        [Display(Name = "出入小区")]
        public int? CId { get; set; }

        public virtual CommunityInfo CommunityInfo { get; set; }
    }
}
