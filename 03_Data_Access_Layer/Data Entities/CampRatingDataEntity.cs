using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Data_Entities
{
    public class CampRatingDataEntity
    {
        public int Id { get; set; }

        public int CampId { get; set; }

        public double Rating { get; set; }

        public virtual CampDataEntity Camp { get; set; }
    }
}
