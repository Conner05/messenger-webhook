using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messenger_webhook.Models;
using messenger_webhook.Options;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace messenger_webhook.Controllers
{
    [Route("api/[controller]")]
    public class WebhookController : Controller
    {
        private TokenConfig _tokenAccessor;

        public WebhookController(IOptions<TokenConfig> tokenAccessor)
        {
            _tokenAccessor = tokenAccessor.Value;
        }
        // GET api/webhook
        [HttpGet]
        public IActionResult Get(
            [FromQuery(Name = "hub.mode")]string mode,
            [FromQuery(Name = "hub.challenge")]string challenge,
            [FromQuery(Name = "hub.verify_token")]string verifyToken
        )
        {
            var VERIFY_TOKEN = _tokenAccessor.VerifyToken;
            if (mode != "subscribe" || verifyToken != VERIFY_TOKEN)
            {
                return Forbid();
            }

            return Ok(challenge);
        }

        // POST api/webhook
        [HttpPost]
        public IActionResult Post()
        {
            var req = HttpContext.Request;
            var bodyStr = "";
            req.EnableRewind();
            using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = reader.ReadToEnd();
            }

            req.Body.Position = 0;
            var request = JsonConvert.DeserializeObject<Request>(bodyStr);
            if (request.Object == "page")
            {
                request.Entry.ForEach(entry =>
                {
                    var webhookEvent = entry.Messaging.FirstOrDefault().Message;
                });

                return Ok("EVENT_RECEIVED");
            }
            return NotFound();
        }
    }
}
