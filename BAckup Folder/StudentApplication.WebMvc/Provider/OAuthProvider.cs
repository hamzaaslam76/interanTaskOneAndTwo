//using Microsoft.Owin.Security.OAuth;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;

//namespace StudentApplication.WebMvc.Provider
//{
//    public class OAuthProvider : OAuthAuthorizationServerProvider
//    {
//        public override Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
//        {
//            return base.AuthorizationEndpointResponse(context);
//        }

//        public override Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
//        {
//            return base.AuthorizeEndpoint(context);
//        }

//        public override bool Equals(object obj)
//        {
//            return base.Equals(obj);
//        }

//        public override int GetHashCode()
//        {
//            return base.GetHashCode();
//        }

//        public override Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
//        {
//            return base.GrantAuthorizationCode(context);
//        }

//        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
//        {
//            return base.GrantClientCredentials(context);
//        }

//        public override Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
//        {
//            return base.GrantCustomExtension(context);
//        }

//        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
//        {
//            return base.GrantRefreshToken(context);
//        }

//        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
//        {
//            return base.GrantResourceOwnerCredentials(context);
//        }

//        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
//        {
//            return base.MatchEndpoint(context);
//        }

//        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
//        {
//            return base.TokenEndpoint(context);
//        }

//        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
//        {
//            return base.TokenEndpointResponse(context);
//        }

//        public override string ToString()
//        {
//            return base.ToString();
//        }

//        public override Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
//        {
//            return base.ValidateAuthorizeRequest(context);
//        }

//        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
//        {
//            return base.ValidateClientAuthentication(context);
//        }

//        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
//        {
//            return base.ValidateClientRedirectUri(context);
//        }

//        public override Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
//        {
//            return base.ValidateTokenRequest(context);
//        }
//    }
//}