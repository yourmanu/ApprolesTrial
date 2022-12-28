using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Security.Claims;

namespace ApprolesTrial.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UserclaimsController : ControllerBase
    {
        private System.Security.Claims.ClaimsPrincipal user;
        private string result=" ";
        private bool response = false;
        [HttpGet]
        public async Task<string> Get()
        {
            User.Claims.ToList().ForEach(c => result = result + c.Type + " : " + c.Value + "\n");
            return result;
        }
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("isinrole")]
        public bool GetBoolean([FromQuery] string rolename)
        {
            user = User;
            response= user.IsInRole(rolename);
            return response;
        }
        
        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("getroles")]
        public async Task<List<string>> GetList()
        {
            List<string> claims = new List<string>();
            User.Claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").ToList().ForEach(c => claims.Add(c.Value));
            return claims;
        }
    }
}