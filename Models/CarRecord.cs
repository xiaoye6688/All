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
        [Display(Name ="��������")]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "�����绰")]
        public string Mobile { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "��������")]
        public string CarName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "���ƺ�")]
        public string CarNo { get; set; }

        [Required]
        [StringLength(20)] 
        [Display(Name = "����")]
        public string CarType { get; set; }

        public DateTime DriveTime { get; set; }
        [Display(Name = "����״̬")]
        public int? State { get; set; }
        [Display(Name = "ͣ������")]
        public int? Type { get; set; }

        [Display(Name = "����С��")]
        public int? CId { get; set; }

        public virtual CommunityInfo CommunityInfo { get; set; }
    }
}
