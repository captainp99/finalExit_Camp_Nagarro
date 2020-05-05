using _01_Presentation_Layer.Models;
using _01_Presentation_Layer.MyMapper;
using _01_Presentation_Layer.Services;
using _02_Bussiness_Logic_Layer.Bussiness_Entities;
using _02_Bussiness_Logic_Layer.Class_Blueprints;
using _02_Bussiness_Logic_Layer.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Results;

namespace _01_Presentation_Layer.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        IUserBussiness userBussinessServiceObject = new UserBussinessService();
        string[] refreshTokens = new string[256];

        [HttpPost]
        [Route("logout")]
        public IHttpActionResult LogoutUser([FromBody]JsonUserModel jsonUserModelObject)
        {
            jsonUserModelObject.RefreshToken = null;
            refreshTokens = null;
            return Ok("success");
        }


        [HttpPost]
        [Route("login")]
        public JsonResult<JsonUserModel> AuthenticateUser([FromBody]UserPresentationModel userPresentationModelObject)
        {
            
            UserBussinessEntity userBussinessEntityObject = MapperFromPresenationtoBL.Mapping<UserPresentationModel, UserBussinessEntity>(userPresentationModelObject);

            bool isAuthenticated = userBussinessServiceObject.RequestAuthentication(userBussinessEntityObject);



            if (isAuthenticated)
            {
                IAuthContainerModel model = GetJWTContainerModel(userPresentationModelObject.Username, "admin");
                IAuthService authService = new JWTService(model.SecretKey);

                string token = authService.GenerateToken(model);
                int refreshToken = RandomNumber(0,256);
                if (!authService.IsTokenValid(token))
                    throw new UnauthorizedAccessException();
                else
                {
                     ClaimsPrincipal claims = authService.GetTokenClaims(token);
                    refreshTokens[refreshToken] = userPresentationModelObject.Username;
                 }

                JsonUserModel jsonUserModelObject = new JsonUserModel();
                jsonUserModelObject.RefreshToken = userPresentationModelObject.Username;
                jsonUserModelObject.JWTToken = token;

                return Json(jsonUserModelObject);
            }

            return null;
        }

        




        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #region Private Methods
        private static JWTContainerModel GetJWTContainerModel(string name, string email)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                }
            };
        }
        #endregion
    }
}


