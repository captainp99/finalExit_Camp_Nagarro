using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_Presentation_Layer.Models
{
  public class BookingPresentationModel
  {
            public int Id { get; set; }

            public int CampId { get; set; }


            public string ReferenceId { get; set; }


            public DateTime StartDate { get; set; }


            public DateTime EndDate { get; set; }

            public string BillingAddress { get; set; }

            public int ZipCode { get; set; }

            public string Country { get; set; }

            public string State { get; set; }

            public long CellPhone { get; set; }

            public double TotalAmount { get; set; }

  }
}
