using _03_Data_Access_Layer.Class_Blueprints;
using _03_Data_Access_Layer.DAL;
using _03_Data_Access_Layer.Data_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Services
{
    public class UserDataServices : IUserDataAccess
    {
        private CampBookingDbContext db = new CampBookingDbContext();

        public bool ValidateAuthentication(UserDataEntity userDataEntityObject)
        {
            bool result = false;
            var user = db.Users.FirstOrDefault(x => x.Username == userDataEntityObject.Username && x.Password == userDataEntityObject.Password);

            if(user != null)
            {
                result = user.IsAdmin;
            }

            return result;
        }
    }
}
