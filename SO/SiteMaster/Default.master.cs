using System;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using SO.BusinessLogicLayer;
using SO.BusinessLogicLayer.Enumeration;

public partial class MasterPages_Default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sRefNumber = PFSHelper.Lib.PFSCommon.GenerateRefNumber();
        try
        {
            Response.Cache.SetNoStore();
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
            {
                ShowUserInfo();
            }

            if (!IsPostBack)
            {
                #region Access Right

                #region Security
                mnuGroup.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_GRP_READ.ToString());
                mnuAuditTrails.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_AUD_READ.ToString());

                if (mnuGroup.Visible
                    || mnuAuditTrails.Visible)
                    mnuSecurity.Visible = true;
                else
                    mnuSecurity.Visible = false;

                #endregion

                #region Sales Order

                mnuSoList.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SALES_SO_READ.ToString());
                mnuSoInput.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SALES_SOINPUT_ADDITEM.ToString());

                if (mnuSoList.Visible
                    || mnuSoInput.Visible)
                    mnuSalesOrder.Visible = true;
                else
                    mnuSalesOrder.Visible = false;
                #endregion

                #endregion
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
        }
    }

    private void ShowUserInfo()
    {
        User oUser = ((CustomPrincipal)HttpContext.Current.User).User;
        lblUserFullName.Text = oUser.FullName;
        lblLastLogin.Text = oUser.LastAccess.ToString("dd-MMM-yyyy hh:mm:ss");
    }

    protected void OnLogout(object sender, LoginCancelEventArgs e)
    {
        string sRefNumber = PFSHelper.Lib.PFSCommon.GenerateRefNumber();
        bool bIsSuccess = false;

        User oUser = (User)Session["sessCurrentUser"];
        if (oUser != null)
        {
            oUser.IsLogin = false;
            bIsSuccess = oUser.UpdateLoginStatus(false);
            Session["sessCurrentUser"] = null;

            Security.WriteUserLog(sRefNumber, "Logout", oUser, Convert.ToInt16(bIsSuccess), 1);
        }

        FormsAuthentication.SignOut();
        Response.Cookies.Clear();
        Response.Redirect("../SalesOrder/SOList.aspx");
    }
}
