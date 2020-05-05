using _03_Data_Access_Layer.Data_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Class_Blueprints
{
    public interface IUserDataAccess
    {
        bool ValidateAuthentication(UserDataEntity userDataEntityObject);
    }
}
