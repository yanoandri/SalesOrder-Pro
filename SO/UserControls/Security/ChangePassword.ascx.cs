using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using System.Reflection;

public partial class UserControls_Security_ChangePassword : PFSBaseUserControl
{
    private string RefNumber = PFSCommon.GenerateRefNumber();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            User oUser = new User();
            if (oUser.DAL_Load(((CustomPrincipal)HttpContext.Current.User).User.UserID))
            {
                if (PFSCommon.HashString(txtOldPassword.Text) == oUser.Password)
                {
                    oUser.Password = PFSCommon.HashString(txtNewPassword.Text);
                    if (oUser.DAL_Update())
                    {
                        ramChangePassword.Alert("Update successful");

                        Response.Redirect("~/Account/Login.aspx");
                    }
                }
                else
                {
                    ramChangePassword.Alert("Incorrect old password");
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
            // ssaputra Temp
            //ram.Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
}
