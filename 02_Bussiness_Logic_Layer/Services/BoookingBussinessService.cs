using _02_Bussiness_Logic_Layer.Bussiness_Entities;
using _02_Bussiness_Logic_Layer.Class_Blueprints;
using _02_Bussiness_Logic_Layer.MyMapper;
using _03_Data_Access_Layer.Class_Blueprints;
using _03_Data_Access_Layer.Data_Entities;
using _03_Data_Access_Layer.ExtraModel;
using _03_Data_Access_Layer.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bussiness_Logic_Layer.Services
{
  public class BoookingBussinessService : IBookingBussiness
  {
      IBookingDataAccess GetBookingCampDataServices = new BookingDataService();

      public string CampBooking(BookingBussinessEntity bookingBussinessObject)
      {
            Guid obj = Guid.NewGuid();
            string var = obj.ToString();
            string str = var.Substring(0, 8);
             bookingBussinessObject.ReferenceId = str;



       
      BookingDataEntity bookingDAL = MapperFromBLtoDA.Mapping<BookingBussinessEntity, BookingDataEntity>(bookingBussinessObject);

        int NumberOfRowsAffected = GetBookingCampDataServices.CreateBooking(bookingDAL);

        //bool result = false;

        if (NumberOfRowsAffected == 0)
        {
           throw new Exception("Something Went Wrong");
        }
        return bookingBussinessObject.ReferenceId;
      }

      public BookingBussinessEntity GetBookingDetailsByReferenceID(string referenceid)
      {
      BookingDataEntity bookingDataAccessObject = GetBookingCampDataServices.GetBookingDetailsByReferenceID(referenceid);

       

      BookingBussinessEntity bookingBussinessObject = MapperFromBLtoDA.Mapping<BookingDataEntity, BookingBussinessEntity>(bookingDataAccessObject);

        return bookingBussinessObject;
      }

      public IList<CampBussinessEntity> GetFilterCamps(DateTime startdate, DateTime enddate, int capacity)
      {
        IList<CampRatingModel> listOFCampDataAccess = GetBookingCampDataServices.GetFilterCamps(startdate, enddate, capacity);
        IList<CampBussinessEntity> listOfCampBussiness = new List<CampBussinessEntity>();

        foreach (var currentCamp in listOFCampDataAccess)
        {
         
        CampBussinessEntity campBussinessEntityObject = MapperFromBLtoDA.Mapping<CampRatingModel, CampBussinessEntity>(currentCamp);
        listOfCampBussiness.Add(campBussinessEntityObject);
        }

        return listOfCampBussiness;
      }

      public bool CancelBooking(string referenceid)
      {
        int rows = GetBookingCampDataServices.CancelBooking(referenceid);

        bool result = false;

        if (rows != 0)
        {
          result = true;
        }

        return result;

      }

    public bool CampRating(RatingBussinessEntity ratingBussinessObject)
    {
      
      CampRatingDataEntity ratingDataObject = MapperFromBLtoDA.Mapping<RatingBussinessEntity, CampRatingDataEntity>(ratingBussinessObject);

      bool done = GetBookingCampDataServices.CreateCampRating(ratingDataObject,ratingBussinessObject.ReferenceId);

      //bool result = false;

      if (done == false)
      {
        throw new Exception("Something Went Wrong");
      }
      return done;
    }
  }
}
