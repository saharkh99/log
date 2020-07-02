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
        Database1Entities6 us = new Database1Entities6();
        
      // private static CodeGenerator cg1 = new CodeGenerator();
         
         
        public String Login(user login)
        {
            using (Database1Entities6 us = new Database1Entities6())
            {
               
                var lusername = us.users.Where(a => a.username == login.username).FirstOrDefault();
                var lpassword = us.users.Where(a => a.passwords == login.passwords).FirstOrDefault();
                if (lusername != null && lpassword != null)
                {

                    return JwtManager.GenerateToken(lusername.name,lusername.username, lusername.roles);
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



         public JsonResult Get(string token)
         {
             using (Database1Entities6 us = new Database1Entities6())
             {
                 List<servicess> list;
                 if (JwtManager.ValidateToken(token).Equals("developer"))
                 {


                     list = us.servicesses.Where(a => (a.parent.Equals("itpart") && a.accesslevel.Equals("1")) || (a.parent.Equals("general")) || (a.parent.Equals("entpart"))).ToList();
                    var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                    return jsondata;
                     
                 }
                 else if (JwtManager.ValidateToken(token).Equals("manager"))
                 {


                     list = us.servicesses.Where(a => (a.parent.Equals("itpart") && a.accesslevel.Equals("3")) || (a.parent.Equals("general")) || (a.parent.Equals("entpart"))).ToList();
                     var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                     return jsondata;
                    

                 }
                 else if (JwtManager.ValidateToken(token).Equals("seniDev"))
                 {


                     list = us.servicesses.Where(a => (a.parent.Equals("itpart") && a.accesslevel.Equals("2")) || (a.parent.Equals("general")) || (a.parent.Equals("entpart"))).ToList();
                     var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                     return jsondata;

                 }
                 else if (JwtManager.ValidateToken(token).Equals("trainer"))
                 {


                     list = us.servicesses.Where(a => (a.parent.Equals("trainingpart") && a.accesslevel.Equals("1")) || (a.parent.Equals("general")) || (a.parent.Equals("entpart"))).ToList();
                     var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                     return jsondata;

                 }
                 else if (JwtManager.ValidateToken(token).Equals("seniDev"))
                 {


                     list = us.servicesses.Where(a => (a.parent.Equals("itpart") && a.accesslevel.Equals("1")) || (a.parent.Equals("general")) || (a.parent.Equals("entpart"))).ToList();
                     var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                     return jsondata;

                 }
                 else if (JwtManager.ValidateToken(token).Equals("receptionist"))
                 {


                     list = us.servicesses.Where(a => (a.parent.Equals("receppart") && a.accesslevel.Equals("1")) || (a.parent.Equals("general")) || (a.parent.Equals("entpart"))).ToList();
                     var jsondata = Json(list, JsonRequestBehavior.AllowGet);
                     return jsondata;

                 }
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

