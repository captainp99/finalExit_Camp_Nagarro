using _03_Data_Access_Layer.Data_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.DAL
{
  public class CampBookingWebAppInitializer : System.Data.Entity.CreateDatabaseIfNotExists<CampBookingDbContext>
  {
    protected override void Seed(CampBookingDbContext context) 
    {
      var camps = new List<CampDataEntity>
            {
                new CampDataEntity{Name = "Blue Camp" , Capacity = 2 , Description = "blue camps with lightning all around" , Price = 1500 , ImageURL = "camp3.jpg"},



                new CampDataEntity{Name = "Hut Camp" , Capacity = 8 , Description = "Colorful Big Camps aith greenry all around" , Price = 2000 , ImageURL = "camp1.jpg"},




                new CampDataEntity{Name = "Hill Side Camp" , Capacity = 4 , Description = "Colorfull Hill side camps with a great vie at hill peek" , Price = 2500 , ImageURL = "camp10.jpg"},




                new CampDataEntity{Name = "Kid Camps" , Capacity = 2 , Description = "Funny small kids camp with toys and lot of funny things" , Price = 2000 , ImageURL = "camp5.png"},




                new CampDataEntity{Name = "Big Yellow Camp" , Capacity = 4 , Description = "Spacious camp specially for couples at the place where nobody comes " , Price = 3000 , ImageURL = "camp8.jpg"}



            };
       camps.ForEach(s => context.Camps.Add(s));
      context.SaveChanges();

      var bookings = new List<BookingDataEntity>
      {
        new BookingDataEntity{CampId = 1, BillingAddress = "Yamuna Vihar" , State = "Delhi" , Country = "India", ZipCode = 110053, CellPhone = 8585910889, ReferenceId = "abcd1234", StartDate = DateTime.Parse("04-05-2020 00:00:00"), EndDate = DateTime.Parse("06-05-2020 00:00:00"), TotalAmount = 3000 },
        new BookingDataEntity{CampId = 1, BillingAddress = "Shankar Nagar" , State = "Delhi" , Country = "India", ZipCode = 110051, CellPhone = 8585910889, ReferenceId = "efgh5678", StartDate = DateTime.Parse("01-05-2020 00:00:00"), EndDate = DateTime.Parse("03-05-2020 00:00:00"), TotalAmount = 3400 },
        new BookingDataEntity{CampId = 2, BillingAddress = "Muzzafarnagar" , State = "Uttar Pradesh" , Country = "India", ZipCode = 210101, CellPhone = 8585910889, ReferenceId = "wxyz9100", StartDate = DateTime.Parse("15-05-2020 00:00:00"), EndDate = DateTime.Parse("18-05-2020 00:00:00"), TotalAmount = 3600 }
      };
      bookings.ForEach(s => context.Bookings.Add(s));
      context.SaveChanges();

      var rating = new List<CampRatingDataEntity>
      {
        new CampRatingDataEntity{CampId = 1, Rating = 3 },
        new CampRatingDataEntity{CampId = 2, Rating = 3 },
        new CampRatingDataEntity{CampId = 3, Rating = 3 },
        new CampRatingDataEntity{CampId = 4, Rating = 3 },
        new CampRatingDataEntity{CampId = 5, Rating = 3 }
      };
      rating.ForEach(s => context.CampRatings.Add(s));
      context.SaveChanges();

      var users = new UserDataEntity
      {
        Username = "admin",
        Password = "admin",
        IsAdmin = true
      };

      context.Users.Add(users);
      context.SaveChanges();
    }
  }
}
