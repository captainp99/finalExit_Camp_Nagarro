using _03_Data_Access_Layer.Class_Blueprints;
using _03_Data_Access_Layer.DAL;
using _03_Data_Access_Layer.Data_Entities;
using _03_Data_Access_Layer.ExtraModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Services
{
  public class BookingDataService : IBookingDataAccess
  {
    private CampBookingDbContext db = new CampBookingDbContext();

    public int CreateBooking(BookingDataEntity bookingDataObject)
    {
      int days = (bookingDataObject.EndDate.Date - bookingDataObject.StartDate.Date).Days;
      int normalDays = 0;
      int weekend = 0;
      var price = (from camp in db.Camps
                   where camp.Id == bookingDataObject.CampId
                   select camp.Price).FirstOrDefault();
      DateTime startdate = bookingDataObject.StartDate;
      while (startdate < bookingDataObject.EndDate)
      {
        if(startdate.DayOfWeek == DayOfWeek.Saturday
          || startdate.DayOfWeek == DayOfWeek.Sunday
          || startdate.DayOfWeek == DayOfWeek.Friday)
        {
          weekend = weekend + 1;
        }
        else
        {
          normalDays = normalDays + 1;
        }
        startdate = startdate.AddDays(1);

      }
      bookingDataObject.TotalAmount = normalDays * price  + weekend * (price + 200);
      db.Bookings.Add(bookingDataObject);
      int numberOfRowsAffected = db.SaveChanges();
      return numberOfRowsAffected;
    }

    public BookingDataEntity GetBookingDetailsByReferenceID(string referenceid)
    {
      BookingDataEntity bookingcamp = db.Bookings.FirstOrDefault(x => String.Equals(x.ReferenceId, referenceid));
      return bookingcamp;
    }

    public IList<CampRatingModel> GetFilterCamps(DateTime startdate, DateTime enddate, int capacity = 1)
    {
      var notavilabecampID = (from booking in db.Bookings
                              where ((booking.StartDate <= startdate) && (booking.EndDate >= startdate)) ||
                                     ((booking.StartDate <= enddate) && (booking.EndDate >= enddate)) ||
                                     ((booking.StartDate >= startdate) && (booking.EndDate <= enddate))
                              select booking.CampId).ToList();

      var camps = (from camp in db.Camps
                                    where !(notavilabecampID).Contains(camp.Id) && camp.Capacity >= capacity
                                    select camp).Include(x => x.Ratings);

      int rate;
      int count;
      List<CampRatingModel> RatedCampData = new List<CampRatingModel>();
      
      foreach (CampDataEntity camp in camps)
      {
        CampRatingModel campRatingObject = new CampRatingModel();
        rate = 0;
        count = 0;
        campRatingObject.Name = camp.Name;
        campRatingObject.Description = camp.Description;
        campRatingObject.Capacity = camp.Capacity;
        campRatingObject.ImageURL = camp.ImageURL;
        campRatingObject.Price = camp.Price;
        campRatingObject.Id = camp.Id;
        foreach (CampRatingDataEntity rating in camp.Ratings)
        {
          rate = rate + Convert.ToInt32(rating.Rating);
          count = count + 1;

        }
        campRatingObject.Rating = Convert.ToInt32(rate / count);
        RatedCampData.Add(campRatingObject);
      }


      return RatedCampData;


     


    }

    public int CancelBooking(string referenceid)
    {
      BookingDataEntity booking = db.Bookings.FirstOrDefault(x => x.ReferenceId == referenceid);
      db.Bookings.Remove(booking);
      int affectedRows = db.SaveChanges();
      return affectedRows;
    }

    public bool CreateCampRating(CampRatingDataEntity ratingDataObject,string referenceId)
    {
      db.CampRatings.Add(ratingDataObject);
      int rowAffected = db.SaveChanges();
      if(rowAffected != 0)
      {
        BookingDataEntity booking = db.Bookings.FirstOrDefault(x => x.ReferenceId == referenceId);
        db.Bookings.Remove(booking);
        db.SaveChanges();
        return true;
      }
      else
      {
        return false;
      }
      

    }
  }
}
