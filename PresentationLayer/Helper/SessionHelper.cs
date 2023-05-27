using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Helper
{
    public class SessionHelper {

        public static int UserId
        {
            get
            {
                if (HttpContext.Current.Session["UserId"] == null)
                    return 0;
                return (int)HttpContext.Current.Session["UserId"];
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
        public static string Fullname
        {
            get
            {
                if (HttpContext.Current.Session["Fullname"] == null)
                    return string.Empty;
                return HttpContext.Current.Session["Fullname"].ToString();
            }
            set
            {
                HttpContext.Current.Session["Fullname"] = value;
            }
        }
        public static bool IsUser
        {
            get
            {
                if (HttpContext.Current.Session["isUser"] == null)
                    return false;
                return (bool)HttpContext.Current.Session["isUser"];
            }
            set
            {
                HttpContext.Current.Session["isUser"] = value;
            }
        }
        public static bool IsAdmin
        {
            get
            {
                if (HttpContext.Current.Session["isAdmin"] == null)
                    return false;
                return (bool)HttpContext.Current.Session["isAdmin"];
            }
            set
            {
                HttpContext.Current.Session["isAdmin"] = value;
            }
        }
          
    }
}