using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_Layer.Data_Entities
{
    public class BookingDataEntity
    {
          public int Id { get; set; }
          public int CampId { get; set; }

          [Column(TypeName = "VARCHAR")]
          [StringLength(8)]
          [Index(IsUnique = true)]
          [Required]
          public string ReferenceId { get; set; }

          [DataType(DataType.Date)]
          [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
          [Required(ErrorMessage = "Please enter StartDate")]
          public DateTime StartDate { get; set; }

          [DataType(DataType.Date)]
          [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
          [Required(ErrorMessage = "Please enter EndDate")]
          public DateTime EndDate { get; set; }

          [Required(ErrorMessage = "Please enter BillingAddress")]
          public string BillingAddress { get; set; }

          [Required(ErrorMessage = "Please enter ZipCode")]
          public int ZipCode { get; set; }

          [Required(ErrorMessage = "Please enter Country")]
          public string Country { get; set; }

          [Required(ErrorMessage = "Please enter State")]
          public string State { get; set; }

          [Required(ErrorMessage = "Please enter CellPhone")]
          public long CellPhone { get; set; }


          [Required(ErrorMessage = "Please enter TotalAmount")]
          public double TotalAmount { get; set; }


          public virtual CampDataEntity Camp { get; set; }
  }
}


