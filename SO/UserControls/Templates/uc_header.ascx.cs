using System;
using System.Web;
using PFSHelper.BusinessLogicLayer;
using PSC.BusinessLogicLayer;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class Admin_UserControl_uc_header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Type oType = HttpContext.Current.User.GetType();
        //if (oType.FullName == "PFSHelper.BusinessLogicLayer.CustomPrincipal")
        //{
        //    Uc_menu1.Visible = true;
        //}
        //else
        //{
        //    Uc_menu1.Visible = false;
        //}

        //lblCurrentDate.Text = DateTime.Now.DayOfWeek.ToString();
        //lblCurrentDate.Text = string.Format("{0}, {1:dd MMM yyyy}", lblCurrentDate.Text, DateTime.Now);

        //if (!HttpContext.Current.User.Identity.Name.Equals(string.Empty))
        //{
        //    ShowUserInfo();
        //}
        //else
        //{
        //    divUserInfo.Visible = false;
        //}
    }
    //private void ShowUserInfo()
    //{
    //    User oUser = ((CustomPrincipal)HttpContext.Current.User).User;
    //    lblUserFullName.Text = oUser.FullName;
    //    lblEmail.Text = oUser.Email;

    //    UserLoginAttempt oUserLoginAttempt = new UserLoginAttempt();
    //    if (oUserLoginAttempt.DAL_LoadByUsername(oUser.UserName))
    //    {
    //        if (oUserLoginAttempt.LastFailedLoginDate == new DateTime(1900, 1, 1))
    //            lblLastFailedLoginDate.Text = "-";
    //        else
    //            lblLastFailedLoginDate.Text = string.Format("{0:dd MMM yyyy}", oUserLoginAttempt.LastFailedLoginDate);

    //        lblLastLoginDate.Text = string.Format("{0:dd MMM yyyy}", oUserLoginAttempt.LastSuccessfullLoginDate);
    //    }
    //}

    //protected void OnLogout(object sender, LoginCancelEventArgs e)
    //{
    //    string sRefNumber = PFSHelper.Lib.PFSCommon.GenerateRefNumber();
    //    bool bIsSuccess = false;

    //    User oUser = (User)Session["sessCurrentUser"];
    //    if (oUser != null)
    //    {
    //        oUser.IsLogin = false;
    //        bIsSuccess = oUser.DAL_Update();
    //        Session["sessCurrentUser"] = null;

    //        Security.WriteUserLog(sRefNumber, "Logout", oUser, Convert.ToInt16(bIsSuccess), (int)PSC.BusinessLogicLayer.Enumeration.OTSCEnumeration.PFSModuleObjectMember.SCR_USR_LOGOUT);
    //    }

    //    FormsAuthentication.SignOut();
    //    Response.Cookies.Clear();
    //}
}

