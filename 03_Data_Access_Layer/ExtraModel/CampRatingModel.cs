using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.ExtraModel
{
  public class CampRatingModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    
    public double Price { get; set; }

   
    public int Capacity { get; set; }

   
    public string Description { get; set; }

    public string ImageURL { get; set; }

    public  int Rating { get; set; }


  }
}
