using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc2.Models;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace Mvc2.Controllers
{
    
    public class HomeController : Controller
    {

        Database1Entities us = new Database1Entities();
      // private static CodeGenerator cg1 = new CodeGenerator();
        public String Login(user login)
        {
            using (Database1Entities us = new Database1Entities())
            {

                var lusername = us.users.Where(a => a.username == login.username).FirstOrDefault();
                var lpassword = us.users.Where(a => a.passwords == login.passwords).FirstOrDefault();
                if (lusername != null && lpassword != null)
                {

                    var jsonData = Json(login.username, JsonRequestBehavior.AllowGet);
                    return "true";
                }
                else
                {
                    var jsonData = Json(login.username, JsonRequestBehavior.AllowGet);
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

