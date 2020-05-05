using _03_Data_Access_Layer.Data_Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.DAL
{
    public class CampBookingDbContext : DbContext
    {
        public CampBookingDbContext() : base("CampBookingDbContext")
        {
          Database.SetInitializer(new CampBookingWebAppInitializer());
        }

        public DbSet<CampDataEntity> Camps { get; set; }
        public DbSet<BookingDataEntity> Bookings { get; set; }
        public DbSet<CampRatingDataEntity> CampRatings { get; set; }
        public DbSet<UserDataEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
