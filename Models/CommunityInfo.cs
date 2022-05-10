namespace CheLiangGuanLi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommunityInfo")]
    public partial class CommunityInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommunityInfo()
        {
            CarRecord = new HashSet<CarRecord>();
        }

        [Key]
        public int CId { get; set; }

        [Required]
        [StringLength(50)]
        public string CommunityName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarRecord> CarRecord { get; set; }
    }
}
