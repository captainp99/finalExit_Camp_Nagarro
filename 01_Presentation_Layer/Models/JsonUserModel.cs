using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_Presentation_Layer.Models
{
    public class JsonUserModel
    {
        public string JWTToken { get; set; }
        public string RefreshToken { get; set; }
    }
}