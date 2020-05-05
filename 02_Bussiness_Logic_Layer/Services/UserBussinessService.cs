using _02_Bussiness_Logic_Layer.Bussiness_Entities;
using _02_Bussiness_Logic_Layer.Class_Blueprints;
using _02_Bussiness_Logic_Layer.MyMapper;
using _03_Data_Access_Layer.Class_Blueprints;
using _03_Data_Access_Layer.Data_Entities;
using _03_Data_Access_Layer.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bussiness_Logic_Layer.Services
{
    public class UserBussinessService : IUserBussiness
    {
        IUserDataAccess userDataServiceObject = new UserDataServices();

        public bool RequestAuthentication(UserBussinessEntity userBussinessEntityObject)
        {
            //bool result = false;


           
            UserDataEntity userDataEntityObject = MapperFromBLtoDA.Mapping<UserBussinessEntity, UserDataEntity>(userBussinessEntityObject);

            bool result = userDataServiceObject.ValidateAuthentication(userDataEntityObject);

            return result;
        }
    }
}
