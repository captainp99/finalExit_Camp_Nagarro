using _01_Presentation_Layer.CustomFilters;
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
  [RoutePrefix("api/camp")]
  public class CampController : ApiController
  {
    ICampBussiness campBussinessServiceObject = new CampBussinessService();

    [HttpGet]
    [Route("getallcamps")]
    public IList<CampPresentationModel> GetAllCamp()
    {
      IList<CampBussinessEntity> allCampsBussinessEntities = campBussinessServiceObject.RequestAllCamps();

      IList<CampPresentationModel> allCampsPresentationModels = new List<CampPresentationModel>();


      foreach (var currentCamp in allCampsBussinessEntities)
      {
        
        CampPresentationModel campPresentationObject = MapperFromPresenationtoBL.Mapping<CampBussinessEntity, CampPresentationModel>(currentCamp);
        allCampsPresentationModels.Add(campPresentationObject);
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

      return allCampsPresentationModels;
    }
    private byte[] ImgToByteArray(Image img)
    {
      using (MemoryStream mStream = new MemoryStream())
      {
        img.Save(mStream, img.RawFormat);
        return mStream.ToArray();
      }
    }

    [HttpGet]
    [Route("getcamp/{id}")]
    public CampPresentationModel GetCampByID(int id)
    {
      if (id == 0) return null;
      CampBussinessEntity campBussinessEntityObject = campBussinessServiceObject.RequestCampById(id);
     
      CampPresentationModel campPresentationObject = MapperFromPresenationtoBL.Mapping<CampBussinessEntity, CampPresentationModel>(campBussinessEntityObject);
      if (!string.IsNullOrEmpty(campPresentationObject.ImageURL))
      {
        var filepath = HttpContext.Current.Server.MapPath("~/Image/") + campPresentationObject.ImageURL;
        if (File.Exists(filepath))
        {
          Image image = Image.FromFile(filepath);
          campPresentationObject.ImageArray = ImgToByteArray(image);
        }
      }

      return campPresentationObject;
    }



    [HttpPost]
    [Route("createcamp")]
    [CustomAuthenticationFilter]
    public IHttpActionResult AddCamp()
    {
      try
      {

        string imageName = null;
        var httpRequest = HttpContext.Current.Request;
        ////Upload Image
        var postedFile = httpRequest.Files["Image"];
        //var postedFile = campPresentationObject.ImageURL;
        //Create custom filename
        imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
        imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

        var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);


        postedFile.SaveAs(filePath);




        CampPresentationModel campPresentationObject = new CampPresentationModel();



        campPresentationObject.Name = httpRequest["Name"];
        campPresentationObject.Description = httpRequest["Description"];
        campPresentationObject.Capacity = Convert.ToInt32(httpRequest["Capacity"]);
        campPresentationObject.Price = Convert.ToSingle(httpRequest["Price"]);
        campPresentationObject.ImageURL = imageName;



        // Mapping From CampPresentationModel to CampBussinessEntityModel
       
        CampBussinessEntity campBussinessEntityObject = MapperFromPresenationtoBL.Mapping<CampPresentationModel, CampBussinessEntity>(campPresentationObject);

        bool result = campBussinessServiceObject.CreateCampRequest(campBussinessEntityObject);



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


    [HttpPatch]
    [Route("updatecamp/{id}")]
    [CustomAuthenticationFilter]
    public IHttpActionResult UpdateCamp(int id)
    {
      try
      {
        string imageName = null;
        var httpRequest = HttpContext.Current.Request;
        if (httpRequest.Files["Image"] != null)
        {
          var postedFile = httpRequest.Files["Image"];

          imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
          imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);

          var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);


          postedFile.SaveAs(filePath);



        }


        CampPresentationModel campPresentationObject = new CampPresentationModel();



        campPresentationObject.Name = httpRequest["Name"];
        campPresentationObject.Description = httpRequest["Description"];
        campPresentationObject.Capacity = Convert.ToInt32(httpRequest["Capacity"]);
        campPresentationObject.Price = Convert.ToSingle(httpRequest["Price"]);
        campPresentationObject.ImageURL = imageName;



        
        CampBussinessEntity campBussinessEntityObject = MapperFromPresenationtoBL.Mapping<CampPresentationModel, CampBussinessEntity>(campPresentationObject);

        bool result = campBussinessServiceObject.UpdateCampRequest(campBussinessEntityObject, id);





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

    [HttpDelete]
    [Route("deletecamp/{id}")]
    public IHttpActionResult DeleteCamp(int id)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        string result = campBussinessServiceObject.RequestCampToDelete(id);


        if (result != null)
        {


          var filepath = HttpContext.Current.Server.MapPath("~/Image/") + result;
          if (File.Exists(filepath))
          {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(filepath);
          }

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
  }
}
