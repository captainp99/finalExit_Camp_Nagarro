using _03_Data_Access_Layer.Data_Entities;
using _03_Data_Access_Layer.ExtraModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Class_Blueprints
{
    public interface ICampDataAccess
    {
        int CreateCamp(CampDataEntity campDataEntityObject);

        IList<CampRatingModel> RequestAllCampsFromDb();

        CampDataEntity GetCampByIDFromDb(int id);

        int UpdateCamp(CampDataEntity campDataEntityObject, int id);

        string DeleteCamp(int id);
    }
}
