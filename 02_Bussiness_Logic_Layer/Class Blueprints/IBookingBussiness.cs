using _02_Bussiness_Logic_Layer.Bussiness_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bussiness_Logic_Layer.Class_Blueprints
{
  public interface IBookingBussiness
  {
        string CampBooking(BookingBussinessEntity bookingBussinessObject);
        BookingBussinessEntity GetBookingDetailsByReferenceID(string referenceid);
        IList<CampBussinessEntity> GetFilterCamps(DateTime stratdate, DateTime enddate, int capacity);
        bool CancelBooking(string referenceid);

    bool CampRating(RatingBussinessEntity ratingBussinessObject);
  }
}
