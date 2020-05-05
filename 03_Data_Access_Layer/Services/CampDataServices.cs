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
  public class CampDataServices : ICampDataAccess
  {
    private CampBookingDbContext db = new CampBookingDbContext();

    public int CreateCamp(CampDataEntity campDataObject)
    {

      db.Camps.Add(campDataObject);
      int numberOfRowsAffected = db.SaveChanges();
      CampRatingDataEntity ratingWhileCreateCamp = new CampRatingDataEntity();
      ratingWhileCreateCamp.CampId = campDataObject.Id;
      ratingWhileCreateCamp.Rating = 3;
      db.CampRatings.Add(ratingWhileCreateCamp);
      db.SaveChanges();
      return numberOfRowsAffected;
    }

    public IList<CampRatingModel> RequestAllCampsFromDb()
    {

      List<CampDataEntity> allCamps = (from camps in db.Camps
                                       select camps).ToList();
      int rate;
      int count;
      List<CampRatingModel> RatedCampData = new List<CampRatingModel>();
        var campsForRate = db.Camps.Include(x => x.Ratings);
      foreach(CampDataEntity camp in campsForRate)
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
        foreach(CampRatingDataEntity rating in camp.Ratings)
        {
          rate = rate + Convert.ToInt32(rating.Rating);
          count = count + 1;

        }
        campRatingObject.Rating = Convert.ToInt32(rate / count);
        RatedCampData.Add(campRatingObject);
      }
      

      return RatedCampData;


    }


   

    public CampDataEntity GetCampByIDFromDb(int id)
    {
      CampDataEntity specifiedCampFromDb = db.Camps.FirstOrDefault(x => x.Id == id);

      return specifiedCampFromDb;
    }

    public int UpdateCamp(CampDataEntity campDataEntityObject, int id)
    {
      CampDataEntity campToEdit = db.Camps.FirstOrDefault(x => x.Id == id);
      if (campDataEntityObject.ImageURL == null) { campDataEntityObject.ImageURL = campToEdit.ImageURL; }
      campDataEntityObject.Id = campToEdit.Id;
      db.Entry(campToEdit).CurrentValues.SetValues(campDataEntityObject);

      db.Entry(campToEdit).State = EntityState.Modified;

      int numberOfRowsAffected = db.SaveChanges();
      return numberOfRowsAffected;
    }


    public string DeleteCamp(int id)
    {
      CampDataEntity modelToDelete = db.Camps.SingleOrDefault(x => x.Id == id);
      db.Camps.Remove(modelToDelete);
      int result = db.SaveChanges();
      if (result != 0)
      {
        return modelToDelete.ImageURL;
      }
      else
      {
        return null;
      }



    }
  }
}
