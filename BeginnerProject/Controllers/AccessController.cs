using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BeginnerProject.Models.WebService;

namespace BeginnerProject.Controllers
{
    public class AccessController : ApiController
    {
        [HttpGet]
        public Reply HelloWord(){
            Reply reply = new Reply();
            reply.Message = "First Project";

            reply.Result = 1;
            return reply;
        }
    }
}
