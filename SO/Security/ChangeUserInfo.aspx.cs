using System;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using System.Reflection;

namespace PSC.Web.UI
{
    public partial class ChangeUserInfo : PFSBasePage
    {
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
                    GetUser();
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }

        protected void cbChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                trPassword.Visible = cbChangePassword.Checked;
                trPasswordConfirm.Visible = cbChangePassword.Checked;
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sRefNumber = RefNumber;
            string sRemark = string.Empty;
            string sDescription = string.Empty;
            short iStatus = 0;
            User oUser = new User();

            try
            {
                if (rgridAuthGroup.Items.Count <= 0)
                {
                    Alert("Please assign at least 1 group access to this user");
                    return;
                }
                else
                {
                    oUser.DAL_Load(qs_iUserID);

                    oUser.UserID = qs_iUserID;
                    oUser.FullName = txtFullName.Text;
                    oUser.Title = txtTitle.Text;
                    oUser.Email = txtEmail.Text;
                    if (cbChangePassword.Checked)
                    {
                        oUser.Password = PFSCommon.HashString(txtPassword.Text.Trim());
                    }
                    oUser.UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                    oUser.UpdateDate = DateTime.Now;

                    #region Validate Complex Password

                    if (txtPassword.Text.Trim().Length > 0)
                    {
                        if (!ValidateComplexPassword(
                                txtPassword.Text.Trim(),
                                qs_iUserID,
                                true,
                                out sRemark))
                        {
                            Alert(sRemark);
                            return;
                        }
                    }
                    #endregion

                    if (qs_iUserID > 0)
                    {
                        sDescription = "Update User";
                        if (oUser.DAL_Update())
                        {
                            if (cbChangePassword.Checked)
                            {
                                UserPasswordHistory oPassHistory = new UserPasswordHistory();
                                oPassHistory.CreateDate = DateTime.Now;
                                oPassHistory.Password = Security.Encrypt(txtPassword.Text);
                                oPassHistory.UserID = oUser.UserID;
                                oPassHistory.UserName = oUser.UserName;
                                oPassHistory.DAL_Add();
                                oPassHistory = null;
                            }

                            iStatus = 1;
                        }
                    }
                }

                if (iStatus == 0)
                {
                    sDescription += " not successful CODE:" + sRefNumber;
                    Alert(sDescription);
                }
                else
                {
                    sDescription += " successful";
                    BackToUserList(sDescription);
                }
            }
            catch (Exception Ex)
            {
                if (Ex.Message.Contains("Logon failure: unknown user name or bad password"))
                {
                    Alert("Your dont have right to verify user on this system");
                }
                else
                {
                    ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                    Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
                }
            }
            finally
            {
                //*** Dispose Any Objects ***//
                sRefNumber = null;
                sDescription = null;
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
                    Response.Write("<script>alert('" + PromptMessage + "'); location.href='../Home/Home.aspx'</script>");
                else
                    Response.Redirect("~/Home/Home.aspx");
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

                    if (oUser.IsActive)
                        lblActiveStatus.Text = "Active";
                    else
                        lblActiveStatus.Text = "Not Active";

                    if (oUser.IsBlocked)
                        lblBlockedStatus.Text = "Blocked";
                    else
                        lblBlockedStatus.Text = "Not Blocked";

                    txtFullName.Text = oUser.FullName;
                    txtTitle.Text = oUser.Title;
                    txtEmail.Text = oUser.Email;

                    lblActiveStatus.Text = oUser.IsActive ? "Active" : "Not Active";
                    lblBlockedStatus.Text = oUser.IsBlocked ? "Blocked" : "Not Blocked";
                    lblUsername.Text = oUser.UserName;
                    lblStartLoginTime.Text = oUser.StartLoginTime;
                    lblEndLoginTime.Text = oUser.EndLoginTime;
                    lblHolidayLogin.Text = oUser.AllowHolidayLogin ? "Allowed" : "Not Allowed";
                    lblLastAccess.Text = string.Format("{0:dd MMMM yyyy, hh:mm:ss}", oUser.LastAccess);
                    if (oUser.LastAccess.Year == 1900) lblLastAccess.Text = "-";

                    rgridAuthGroup.DataSource = oUser.UserGroupList;
                    rgridAuthGroup.DataBind();

                    trPassword.Visible = false;
                    trPasswordConfirm.Visible = false;
                }

                rgridAuthGroup.Rebind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateComplexPassword(
            string p_sPassword,
            int p_iUserID,
            bool p_bIsChangePassword,
            out string p_sRemark)
        {
            bool bIsSuccess = true;
            p_sRemark = string.Empty;
            int iUpperCase = 0, iLowerCase = 0, iNumeric = 0;

            //Check if password contain upper, lower or numeric
            foreach (char cPwd in p_sPassword)
            {
                if (Char.IsNumber(cPwd)) iNumeric += 1;
                else if (Char.IsUpper(cPwd)) iUpperCase += 1;
                else if (Char.IsLower(cPwd)) iLowerCase += 1;
            }

            if (iNumeric >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_NUMERIC_CHAR"))
                && iUpperCase >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_UPPER_CASE_CHAR"))
                && iLowerCase >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_LOWER_CASE_CHAR"))
                && p_sPassword.Length >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_LENGTH")))
            {
                if (p_bIsChangePassword)
                {
                    //Check new password whether new password identical with n latest password
                    UserPasswordHistoryCollection oPasswordHistoryCollection = new UserPasswordHistoryCollection();
                    oPasswordHistoryCollection.DAL_LoadByUserID(p_iUserID);
                    oPasswordHistoryCollection.Sort(
                        UserPasswordHistoryCollection.UserPasswordHistoryFields.CreateDate, false);

                    int batas = oPasswordHistoryCollection.Count >=
                                Convert.ToInt32(PFSCommon.GetSysParam("LAST_UNIQUE_PASSWORD"))
                        ? Convert.ToInt32(PFSCommon.GetSysParam("LAST_UNIQUE_PASSWORD"))
                        : oPasswordHistoryCollection.Count;

                    for (int i = 0; i < batas; i++)
                    {
                        if (oPasswordHistoryCollection[i].Password == Security.Encrypt(p_sPassword))
                        {
                            bIsSuccess = false;
                            p_sRemark = "Password cannot be same with " + PFSCommon.GetSysParam("LAST_UNIQUE_PASSWORD") + " latest passwords";
                            break;
                        }
                    }
                }
            }
            else
            {
                bIsSuccess = false;

                p_sRemark = "Passwords must contain at least " + PFSCommon.GetSysParam("PASSWORD_LENGTH") + " characters \\n";
                p_sRemark = p_sRemark + "Contain minimal " + PFSCommon.GetSysParam("PASSWORD_UPPER_CASE_CHAR") + " upper case alphabetical character\\n";
                p_sRemark = p_sRemark + "Contain minimal " + PFSCommon.GetSysParam("PASSWORD_LOWER_CASE_CHAR") + " lower case alphabetical character\\n";
                p_sRemark = p_sRemark + "Contain minimal " + PFSCommon.GetSysParam("PASSWORD_NUMERIC_CHAR") + " numeric character";
            }

            return bIsSuccess;
        }
        #endregion
    }
}