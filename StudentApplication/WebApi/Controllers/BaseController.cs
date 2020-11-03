using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BaseController : ApiController
    {
        public int USER_ID
        {
            get { return GetUserId(); }
            set { }
        }
        private int GetUserId()
        {
            try
            {
                // Get UserId in Claim
                var identity = (ClaimsIdentity)User.Identity;
                return Convert.ToInt32 ( identity.Claims.Where(c => c.Type == ClaimTypes.Sid).FirstOrDefault().Value);
                
            }
            catch (Exception ex)
            {
                return -1;
            }  
        }
    }
}
