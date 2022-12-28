using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace ApprolesTrial.Server.Controllers
{
    [Authorize(Roles = "vaidotas.read")]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class VaidotasController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Good morning Vaidotas!";
        }
    }
}