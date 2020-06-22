using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc2.Models
{
    public class CodeGenerator
    {
        public string code{set;get;}
        
        public string generator() {
            const string Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, 4)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return result;

        }
        public void set(string result) {
            code = result;
        }
        public string get() {
            
            return code;
        
        }

    }
}