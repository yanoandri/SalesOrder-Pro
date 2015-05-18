using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;

public partial class UserControls_uc_Menu : System.Web.UI.UserControl
{
    public ModuleObjectMemberCollection oModuleObjectMemberCollection
    {
        get { return (ViewState["oModuleObjectMemberCollection"] == null) ? new ModuleObjectMemberCollection() : (ModuleObjectMemberCollection)ViewState["oModuleObjectMemberCollection"]; }
        set { ViewState["oModuleObjectMemberCollection"] = value; }
    }

    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
        }
    }
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        string sRefNumber = PFSHelper.Lib.PFSCommon.GenerateRefNumber();
        bool bIsSuccess = false;

        User oUser = (User)Session["sessCurrentUser"];
        if (oUser != null)
        {
            oUser.IsLogin = false;
            bIsSuccess = oUser.UpdateLoginStatus(false);
            Session["sessCurrentUser"] = null;

            Security.WriteUserLog(sRefNumber, "Logout", oUser, Convert.ToInt16(bIsSuccess), (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_USR_LOGOUT);
        }

        FormsAuthentication.SignOut();
        Response.Cookies.Clear();
    }
    #endregion    
}
