using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc2.Models;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Http;

namespace WebApi.Jwt.Controllers
{

    public class HomeController : Controller
    {
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
        Database1Entities us = new Database1Entities();
      // private static CodeGenerator cg1 = new CodeGenerator();
         [AllowAnonymous]
        public String Login(user login)
        {
            using (Database1Entities us = new Database1Entities())
            {

                var lusername = us.users.Where(a => a.username == login.username).FirstOrDefault();
                var lpassword = us.users.Where(a => a.passwords == login.passwords).FirstOrDefault();
                if (lusername != null && lpassword != null)
                {
                   
                    return JwtManager.GenerateToken(lusername.username);
                }
                else
                {
                    return "false";
                }

            }
        
        }
        
       // public string insert() {

         //   user u = new user();
           // return u.InsertRegDetails();
        
        //}
   //     public String setCode() {
         
    //        cg1.code = cg1.generator();
     //       return cg1.code;
    //    }
       
 





     //   public String getCode(CodeGenerator cg)
     //   {
         
     //       if (cg.code == cg1.code)
     //           return "true";
       //     else
       //         return "false";
            
     //   }

    }
}

