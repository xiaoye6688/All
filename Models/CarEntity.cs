using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CheLiangGuanLi.Models
{
    public partial class CarEntity : DbContext
    {
        public CarEntity()
            : base("name=CarEntity")
        {
        }

        public virtual DbSet<CarRecord> CarRecord { get; set; }
        public virtual DbSet<CommunityInfo> CommunityInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
