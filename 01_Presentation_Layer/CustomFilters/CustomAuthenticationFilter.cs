using _01_Presentation_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace _01_Presentation_Layer.CustomFilters
{
  public class CustomAuthenticationFilter : AuthorizeAttribute, IAuthenticationFilter
  {

    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    {
      string authParameter = string.Empty;
      HttpRequestMessage r = context.Request;
      AuthenticationHeaderValue authorization = r.Headers.Authorization;
      if (authorization == null)
      {
        return;
      }
      if (authorization == null && authorization.Scheme != "Bearer")
      {
        return;
      }
      if (string.IsNullOrEmpty(authorization.Parameter))
      {
        return;
      }


      JWTService jwtService = new JWTService("TW9zaGVFcmV6UHJpdmF0ZUtleQ ==");

      context.Principal = jwtService.GetTokenClaims(authorization.Parameter);
       
    }



    public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    {
      return Task.FromResult(0);
    }





  }
}
