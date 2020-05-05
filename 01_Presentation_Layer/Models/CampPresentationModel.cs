using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_Presentation_Layer.Models
{
    public class CampPresentationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public byte[] ImageArray { get; set; }

        public int Rating { get; set; }
  }
}
