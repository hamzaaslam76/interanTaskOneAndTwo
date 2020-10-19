﻿using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApi.App_Start;

namespace WebApi.Providers
{
    public class Provider : OAuthAuthorizationServerProvider
    {

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var userRepository = new UserRepository();
                var user = userRepository.ValidateUser(username, password);   // UserDTO user = UserDAL.ValidateUser(username, password);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Sid,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email)
                    };
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                      {"Name",user.Name},
                      {"Email",user.Email },
                      {"UserId",user.UserId.ToString()},
                    });
                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, props));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}