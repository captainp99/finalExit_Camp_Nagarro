using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Data_Entities
{
    public class CampDataEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Capacity is Required")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        public string  ImageURL { get; set; }

        public virtual ICollection<BookingDataEntity> Bookings { get; set; }

        public virtual ICollection<CampRatingDataEntity> Ratings { get; set; }

    }
}
