using Microsoft.AspNetCore.Mvc;

namespace Hostitan.API.Controllers
{
    [ApiController]
    [Route("/customers/{id}/subscriptions")]
    public class SubscriptionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSUbscriptions()
        {
            return Ok();
        }        

        [HttpGet]
        [Route("{subs_id}")]
        public IActionResult GetSubsciptions(Guid subId)
        {
            return Ok();
        }
    }
}