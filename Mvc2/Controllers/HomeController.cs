using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc2.Models;
using System.Web.Mvc;

namespace Mvc2.Controllers
{
    public class HomeController : Controller
    {
        UserEntities us = new UserEntities();
       private static CodeGenerator cg1 = new CodeGenerator();

       public void insert(user user) {


           us.users.Add(user);
           us.SaveChanges();
                   
       }

        public String Login(user login)
        {
            using (UserEntities us = new UserEntities())
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

