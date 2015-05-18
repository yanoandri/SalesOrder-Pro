using System;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using Telerik.Web.UI;
using SO.BusinessLogicLayer;
using System.Drawing;
using System.Threading;
using SO.BusinessLogicLayer.Enumeration;
using System.Reflection;
using System.Web;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace SO
{
    public partial class UserDetail : PFSBasePage
    {
        #region Session

        private User sessUser
        {
            get { return Session["sessUser"] == null ? new User() : (User)Session["sessUser"]; }
            set { Session["sessUser"] = value; }
        }
        #endregion

        #region QueryString

        private int qs_iUserID
        {
            get { return Request.QueryString["UserID"] == null ? -1 : Convert.ToInt32(Request.QueryString["UserID"]); }
        }
        #endregion

        #region Properties

        string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
        #endregion

        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (
                        !Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_USR_READ.ToString()) &&
                        qs_iUserID > 0)
                        NoPermission();

                    GetUser();
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string sRefNumber = RefNumber;
            try
            {
                BackToUserList();
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        #endregion

        #region Grid Eevnts
        protected void rgridAuthGroup_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string sRefNumber = RefNumber;
            try
            {
                rgridAuthGroup.DataSource = sessUser.UserGroupList;
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Back to User list page if this form was called from -> UserList.aspx
        /// </summary>
        /// <param name="PromptMessage">Message to prompt</param>
        private void BackToUserList(string PromptMessage = null)
        {
            try
            {
                if (PromptMessage != null)
                    Response.Write("<script>alert('" + PromptMessage + "'); location.href='UserList.aspx'</script>");
                else
                    Response.Redirect("UserList.aspx");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// A Function to get User Data, commonly used in Update or Approval mode
        /// </summary>
        private void GetUser()
        {
            try
            {
                if (qs_iUserID > 0)
                {
                    User oUser = new User();
                    oUser.DAL_LoadWithChild(qs_iUserID);
                    IEnumerable<Branch> oBranch = null;
                    if (oUser.UserDetails.Count > 0)
                    {
                        BranchCollection oBranchCollection = new BranchCollection();
                        oBranchCollection.DAL_Load();

                        oBranch = from Branch oBranchs in oBranchCollection
                                                      where oBranchs.BranchCode == oUser.UserDetails[0].BranchCode
                                                      select oBranchs;                
                    }

                    lblActiveStatus.Text = oUser.IsActive ? "Active" : "Not Active";
                    lblBlockedStatus.Text = oUser.IsBlocked ? "Blocked" : "Not Blocked";
                    lblFullName.Text = oUser.FullName;
                    lblBranchCode.Text = oUser.UserDetails.Count > 0 ? oUser.UserDetails[0].BranchCode + " - " + oBranch.ElementAt(0).BranchName : "-";
                    lblTitle.Text = oUser.Title;
                    lblEmail.Text = oUser.Email;
                    lblUsername.Text = oUser.UserName;
                    lblStartLoginTime.Text = oUser.StartLoginTime;
                    lblEndLoginTime.Text = oUser.EndLoginTime;
                    lblHolidayLogin.Text = oUser.AllowHolidayLogin ? "Allowed" : "Not Allowed";
                    lblLastAccess.Text = string.Format("{0:dd MMMM yyyy, hh:mm:ss tt}", oUser.LastAccess);
                    if (oUser.LastAccess.Year == 1900) lblLastAccess.Text = "-";

                    sessUser = oUser;
                }
                else
                {
                    sessUser = new User();
                }

                rgridAuthGroup.Rebind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}