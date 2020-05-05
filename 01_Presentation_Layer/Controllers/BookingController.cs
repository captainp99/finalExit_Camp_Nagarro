using _01_Presentation_Layer.Models;
using _01_Presentation_Layer.MyMapper;
using _02_Bussiness_Logic_Layer.Bussiness_Entities;
using _02_Bussiness_Logic_Layer.Class_Blueprints;
using _02_Bussiness_Logic_Layer.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace _01_Presentation_Layer.Controllers
{
  [RoutePrefix("api/booking")]
  public class BookingController : ApiController
  {
    IBookingBussiness CampBookingServiceforBL = new BoookingBussinessService();

    [HttpPost]
    [Route("addbooking/{id}")]
    public IHttpActionResult AddCampBooking(BookingPresentationModel campBookingPresentationObject, int id)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        campBookingPresentationObject.CampId = id;

        // Mapping From CampPresentationModel to CampBussinessEntityModel
        
        BookingBussinessEntity campBussinessObject = MapperFromPresenationtoBL.Mapping<BookingPresentationModel, BookingBussinessEntity>(campBookingPresentationObject);

        string result = CampBookingServiceforBL.CampBooking(campBussinessObject);

        if (result != null)
        {
          return Ok(result);
        }
        else
        {
          throw new Exception();
        }
      }
      catch (Exception e)
      {
        return Ok(e.ToString());
      }
    }

    [HttpGet]
    public BookingPresentationModel GetBookingDetailsByReferenceID(string referenceid)
    {
      BookingBussinessEntity campBussinessObject = CampBookingServiceforBL.GetBookingDetailsByReferenceID(referenceid);

      
      BookingPresentationModel campofPL = MapperFromPresenationtoBL.Mapping<BookingBussinessEntity, BookingPresentationModel>(campBussinessObject);

      return campofPL;
    }


    [HttpDelete]
    public IHttpActionResult CancelBooking(string referenceid)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        bool result = CampBookingServiceforBL.CancelBooking(referenceid);

        if (result)
        {
          return Ok("Success");
        }
        else
        {
          throw new Exception();
        }
      }
      catch (Exception e)
      {
        return Ok(e.ToString());
      }

    }
    [HttpGet]
    [Route("filtercamp")]
    public IList<CampPresentationModel> GetFilterCamps(DateTime startdate, DateTime enddate, int capacity = 1)
    {
      IList<CampBussinessEntity> allCampofBL = CampBookingServiceforBL.GetFilterCamps(startdate, enddate, capacity);
      IList<CampPresentationModel> allCampsOfPL = new List<CampPresentationModel>();

      foreach (var currentCamp in allCampofBL)
      {
        
        CampPresentationModel campPresentationObject = MapperFromPresenationtoBL.Mapping<CampBussinessEntity, CampPresentationModel>(currentCamp);
        allCampsOfPL.Add(campPresentationObject);
        if (!string.IsNullOrEmpty(campPresentationObject.ImageURL))
        {
          var filepath = HttpContext.Current.Server.MapPath("~/Image/") + campPresentationObject.ImageURL;
          if (File.Exists(filepath))
          {
            Image image = Image.FromFile(filepath);
            campPresentationObject.ImageArray = ImgToByteArray(image);
          }
        }
      }

      return allCampsOfPL;
    }
    private byte[] ImgToByteArray(Image img)
    {
      using (MemoryStream mStream = new MemoryStream())
      {
        img.Save(mStream, img.RawFormat);
        return mStream.ToArray();
      }
    }

    [HttpPost]
    [Route("camprating")]
    public IHttpActionResult RateCamp(RatingPresentationModel ratingPresentationObject)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        

        // Mapping From CampPresentationModel to CampBussinessEntityModel
        
        RatingBussinessEntity rateBussinessObject = MapperFromPresenationtoBL.Mapping<RatingPresentationModel, RatingBussinessEntity>(ratingPresentationObject);

        bool result = CampBookingServiceforBL.CampRating(rateBussinessObject);

        if (result == true)
        {
          return Ok(result);
        }
        else
        {
          throw new Exception();
        }
      }
      catch (Exception e)
      {
        return Ok(e.ToString());
      }

    }

  }
}
