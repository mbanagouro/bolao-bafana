using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoBafana.Web.Code
{
    public static class UserHelper
    {
        public static bool IsAutenticado
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public static int Id
        {
            get { return Convert.ToInt32(GetValue()[0]); }
        }

        public static string Nome
        {
            get { return GetValue()[1]; }
        }

        public static string Email
        {
            get { return GetValue()[2]; }
        }

        private static string[] GetValue()
        {
            return HttpContext.Current.User.Identity.Name.Split(';');
        }
    }
}