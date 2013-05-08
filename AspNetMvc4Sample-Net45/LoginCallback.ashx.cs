using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AspNetMvc4Sample_Net45
{
    public class LoginCallback : IHttpHandler
    {
        private readonly Auth0.Client client = new Auth0.Client(
                                ConfigurationManager.AppSettings["auth0:ClientId"],
                                ConfigurationManager.AppSettings["auth0:ClientSecret"],
                                ConfigurationManager.AppSettings["auth0:Domain"]);

        public void ProcessRequest(HttpContext context)
        {
            var token = client.ExchangeAuthorizationCodePerAccessToken(context.Request.QueryString["code"], ConfigurationManager.AppSettings["auth0:CallbackUrl"]);
            var profile = client.GetUserInfo(token.AccessToken);

            var user = new Dictionary<string, string>
            {
                { "name", profile.Name },
                { "email", profile.Email },
                { "family_name", profile.FamilyName },
                { "gender", profile.Gender },
                { "given_name", profile.GivenName },
                { "nickname", profile.Nickname },
                { "picture", profile.Picture },
                { "user_id", profile.UserId },
                { "id_token", token.IdToken },
                { "connection", profile.Identities.First().Connection },
                { "provider", profile.Identities.First().Provider }
            };

            // NOTE: this will set a cookie with all the user claims that will be converted 
            //       to a ClaimsPrincipal for each request using the ClaimsCookie HttpModule . 
            //       You can choose your own mechanism to keep the user authenticated (FormsAuthentication, Session, etc.)
            ClaimsCookie.ClaimsCookieModule.Instance.CreateSessionSecurityToken(user);

            context.Response.Redirect("/");
        }

        public bool IsReusable { get { return false; } }
    }
}