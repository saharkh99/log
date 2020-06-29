using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Jwt.Controllers
{
    public class ValueController : Controller
    {
        [Authorize(Roles = "sahar")]
        public string Get(string token)
        {
            return "hello";
        }  
    }
  
}
