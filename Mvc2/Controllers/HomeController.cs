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

namespace WebApi.Jwt.Controllers
{

    public class HomeController : Controller
    {
        private const string Secret = "eyJhbGciOiJIUzI1NiJ9.e30.H4c7AhHbO2rWmVVG7LFtXNcfFMrRbWEcV36u3tMU6d4";
        Database1Entities1 us = new Database1Entities1();
      // private static CodeGenerator cg1 = new CodeGenerator();
         
         
        public String Login(user login)
        {
            using (Database1Entities1 us = new Database1Entities1())
            {
                
                var lusername = us.users.Where(a => a.username == login.username).FirstOrDefault();
                var lpassword = us.users.Where(a => a.passwords == login.passwords).FirstOrDefault();
                if (lusername != null && lpassword != null)
                {  
                    
                    return JwtManager.GenerateToken(lusername.username,lusername.roles);
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



         public string Get(string token)
         {
             if (JwtManager.ValidateToken(token).Equals("admin"))
             {
                 return "hello";
             }
             return null;
         }  



     //   public String getCode(CodeGenerator cg)
     //   {
         
     //       if (cg.code == cg1.code)
     //           return "true";
       //     else
       //         return "false";
            
     //   }

    }
}

