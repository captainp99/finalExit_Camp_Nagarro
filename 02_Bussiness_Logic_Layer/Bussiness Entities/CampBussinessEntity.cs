using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Bussiness_Logic_Layer.Bussiness_Entities
{
    public class CampBussinessEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int Rating { get; set; }
  }
}
