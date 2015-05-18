using System.Reflection;
using PFSHelper.BusinessLogicLayer;
using System.Web.SessionState;
using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using SO;

namespace SO
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_End(object sender, EventArgs e)
        {
            string sRefNumber = PFSHelper.Lib.PFSCommon.GenerateRefNumber();
            bool bIsSuccess = false;
            User oUser = (User)Session["sessCurrentUser"];

            if (Session["sessCurrentUser"] != null)
            {
                oUser.IsLogin = false;
                bIsSuccess = oUser.UpdateLoginStatus(false);

                Security.WriteUserLog(
                    sRefNumber,
                    "Automatic Logout",
                    oUser,
                    Convert.ToInt16(bIsSuccess),
                    (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_USR_LOGOUT);

                FormsAuthentication.SignOut();
                Response.Cookies.Clear();
                Session["sessCurrentUser"] = null;

            }
        }

        void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            string sRefNumber = PFSHelper.Lib.PFSCommon.GenerateRefNumber();
            try
            {
                if (Request.IsAuthenticated)
                {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    string[] Roles = id.Ticket.UserData.Split(new char[] { '|' });

                    User oUser = new User();
                    oUser.LoadByUserNameWithoutGroup(HttpContext.Current.User.Identity.Name);
                    Context.User = new CustomPrincipal(User.Identity, Request.UserHostAddress, oUser);
                    oUser = null;
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            }
        }


    }
}
