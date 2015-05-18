using System;
using PFSHelper.BusinessLogicLayer;
using System.Web;
using PFSHelper.Lib;
using System.Reflection;

namespace SO.MasterPages
{
    public partial class Dashbord : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                if (!IsPostBack)
                {
                    ShowUserInfo();
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            }
        }
        #region Region:Methods

        private void ShowUserInfo()
        {
            User oUser = ((CustomPrincipal)HttpContext.Current.User).User;
            lblUserFullName.Text = oUser.FullName;
            lblLastLogin.Text = oUser.LastAccess.ToString("dd-MMM-yyyy hh:mm:ss");
        }
        #endregion
    }
}