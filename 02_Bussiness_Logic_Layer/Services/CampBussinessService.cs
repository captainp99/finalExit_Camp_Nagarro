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
    public class CampBussinessService : ICampBussiness
    {
        ICampDataAccess campDataServicesObject = new CampDataServices();

        public bool CreateCampRequest(CampBussinessEntity campBussinessEntityObject)
        {
            
            CampDataEntity campDataEntityObject = MapperFromBLtoDA.Mapping<CampBussinessEntity, CampDataEntity>(campBussinessEntityObject);

            int NumberOfRowsAffected = campDataServicesObject.CreateCamp(campDataEntityObject);

            bool result = false;

            if (NumberOfRowsAffected != 0)
            {
                result = true;
            }

            return result;
        }


        public IList<CampBussinessEntity> RequestAllCamps()
        {
            IList<CampRatingModel> allCampsOfCampDataEntity = campDataServicesObject.RequestAllCampsFromDb();

            IList<CampBussinessEntity> allCampsOfCampBussinessEntity = new List<CampBussinessEntity>();

            foreach (var currentCamp in allCampsOfCampDataEntity)
            {
                
                CampBussinessEntity campBussinessEntityObject = MapperFromBLtoDA.Mapping<CampRatingModel, CampBussinessEntity>(currentCamp);
                allCampsOfCampBussinessEntity.Add(campBussinessEntityObject);
            }

            return allCampsOfCampBussinessEntity;
        }

        public CampBussinessEntity RequestCampById(int id)
        {
            CampDataEntity campDataEntityObject = campDataServicesObject.GetCampByIDFromDb(id);

           

            CampBussinessEntity campBussinessEntityObject = MapperFromBLtoDA.Mapping<CampDataEntity, CampBussinessEntity>(campDataEntityObject);
            return campBussinessEntityObject;
        }

        public bool UpdateCampRequest(CampBussinessEntity campBussinessEntityObject,int id)
        {
           
            CampDataEntity campDataEntityObject = MapperFromBLtoDA.Mapping<CampBussinessEntity, CampDataEntity>(campBussinessEntityObject);

            int NumberOfRowsAffected = campDataServicesObject.UpdateCamp(campDataEntityObject,id);

            bool result = false;

            if (NumberOfRowsAffected != 0)
            {
                result = true;
            }

            return result;
        }


        public string RequestCampToDelete(int id)
        {
            
            string imageURL = campDataServicesObject.DeleteCamp(id);



             return imageURL;
        }
    }
}
