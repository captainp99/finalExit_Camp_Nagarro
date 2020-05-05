using _03_Data_Access_Layer.Data_Entities;
using _03_Data_Access_Layer.ExtraModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Class_Blueprints
{
  public interface IBookingDataAccess
  {
    int CreateBooking(BookingDataEntity bookingDataObject);
    BookingDataEntity GetBookingDetailsByReferenceID(string referenceid);
    IList<CampRatingModel> GetFilterCamps(DateTime stratdate, DateTime enddate, int capacity);
    int CancelBooking(string referenceid);

    bool CreateCampRating(CampRatingDataEntity ratingDataObject,string ReferenceId);
  }
}
