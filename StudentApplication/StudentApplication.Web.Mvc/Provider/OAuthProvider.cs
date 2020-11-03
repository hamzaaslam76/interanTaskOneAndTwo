using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Repository.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace StudentApplication.Web.Mvc.Provider
{
    public class OAuthProvider:OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var userEmail = context.UserName;
                var password = context.Password;
                UserRepository userRepository = new UserRepository();
                var user = userRepository.ValidateUser(userEmail, password);
                if(user!=null)
                {
                    var claims = new List<Claim>()
                    { 
                        new Claim(ClaimTypes.Sid,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Email,user.Email)
                    };
                    foreach(var role in user.roleDto)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Title));
                    }
                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    var data = new Dictionary<string, string>()
                    {
                        {"Name",user.Name },
                        {"Email",user.Email },
                        {"UserId",user.UserId.ToString() },
                        {"roles",string.Join("",user.roleDto.Select(r=>r.Title)) }
                    };
                    var properties = new AuthenticationProperties(data);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);

                }
                else
                {
                    context.SetError("The user name or password is incorrect");
                }

            });
        }
    }
}