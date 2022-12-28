using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ApprolesTrial.Server.Controllers
{
    [Authorize(Roles = "siva.read")]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class SivaController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Good morning Siva!";
        }
    }
}