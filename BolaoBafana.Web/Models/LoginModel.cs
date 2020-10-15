using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Web.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ReturnUrl { get; set; }
    }
}