using System;
using System.Reflection;
using System.Web;
using System.Web.Security;
using Microsoft.VisualBasic;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using System.Web.UI.WebControls;

namespace PSC.Web.UI
{
    public partial class Login : PFSBasePage
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Focus();

                if (!IsPostBack)
                {
                    viewLogin.SetActiveView(vLogin);
                }

                if (!PFSConfiguration.ActiveDirectory.IsUsingAd)
                {
                    trActiveDirectory.Style.Add("display", "none");
                    tblLogin.Style.Remove("margin-top");
                    trDomian.Style.Add("display", "none");
                    tblLogin.Style.Add("margin-top", "70px");
                }
                else
                {
                    tblLogin.Style.Remove("margin-top");
                    trActiveDirectory.Style.Remove("display");
                    trDomian.Style.Remove("display");
                    tblLogin.Style.Add("margin-top", "50px");

                    string[] sAdDomain = PFSConfiguration.ActiveDirectory.AdDomain.Split(new string[] { "|" }, StringSplitOptions.None);

                    for (int i = 0; i < sAdDomain.Length; i++)
                    {
                        RadioButton rbDomain = new RadioButton();

                        rbDomain.ID = "rbDomain" + i;
                        rbDomain.Text = sAdDomain[i];
                        rbDomain.GroupName = "AdDomain";

                        if (i == 0)
                            rbDomain.Checked = true;

                        phDomainName.Controls.Add(rbDomain);
                    }
                }                
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNo = PFSCommon.GenerateRefNumber();
                ExceptionLog.LogError(
                    sRefNo,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNo));
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User oUser = new User();
            oUser.DecryptedPassword = txtPassword.Text;

            UserLoginAttempt oUserLoginAttempt = new UserLoginAttempt();
            string sMessageLog = "";
            string sRefNumber = PFSCommon.GenerateRefNumber();
            bool bIsError = false;
            bool bIsSuccessLogin = false;

            try
            {
                bool bIsUsingAD = PFSConfiguration.ActiveDirectory.IsUsingAd;
                string ip = string.Empty;

                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    Alert("User must Be filled");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    Alert("Password must Be filled");
                    return;
                }

                oUser.UserName = txtUserName.Text.Trim();
                if (oUser.DAL_LoadByUserName(txtUserName.Text.Trim(), null))
                {
                    // Reset login attempts
                    if (oUser.LastFailedLoginDate.Date != DateTime.Today)
                    {
                        oUser.TodayFailedLoginAttempts = 0;
                    }

                    if (oUser.IsBlocked)
                    {
                        sMessageLog = PFSCommon.GetSysParam("BLOCKED_ACCOUNT_MESSAGE");
                        Alert(sMessageLog);
                        return;
                    }
                    else
                    {
                        if (bIsUsingAD)
                        {
                            #region Using AD

                            string[] sAdDomain = PFSConfiguration.ActiveDirectory.AdDomain.Split(new string[] { "|" }, StringSplitOptions.None);
                            string[] sAdPath = PFSConfiguration.ActiveDirectory.AdPath.Split(new string[] { "|" }, StringSplitOptions.None);

                            int iIndex = 0;
                            for (int i = 0; i < sAdDomain.Length; i++)
                            {
                                RadioButton rbDomain = phDomainName.FindControl("rbDomain" + i) as RadioButton;

                                if (rbDomain.Checked)
                                {
                                    iIndex = i;
                                    break;
                                }
                            }

                            PFSAD oPFSAD = new PFSAD(txtUserName.Text, txtPassword.Text, sAdPath[iIndex]);                            

                            if (oPFSAD.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim()) != PFSAD.LoginResult.LOGIN_OK)
                            {
                                #region Add in System Log
                                SystemLog oSystemLog = new SystemLog();
                                oSystemLog.LogDate = DateTime.Now;
                                oSystemLog.ReferenceNumber = sRefNumber;
                                oSystemLog.Description = oPFSAD.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim()).ToString();
                                oSystemLog.DAL_Add();
                                #endregion
                                sMessageLog = PFSCommon.GetSysParam("INVALID_USER_PASSWORD_MESSAGE");
                                Alert(sMessageLog);
                                return;
                            }
                            oPFSAD = null;

                            #endregion
                        }

                        // Check password
                        if (!bIsUsingAD
                            && oUser.Password != Security.Encrypt(txtPassword.Text.Trim()))
                        {
                            // Check Login attempt
                            if (oUser.TodayFailedLoginAttempts >= (int.Parse(PFSCommon.GetSysParam("MAXIMAL_FAILED_LOGIN_ATTEMPT")) - 1))
                            {
                                oUser.IsBlocked = true;
                                oUser.LastFailedLoginDate = DateTime.Now;
                                oUser.TodayFailedLoginAttempts += 1;
                                oUser.DAL_Update();

                                sMessageLog = PFSCommon.GetSysParam("BLOCKED_ACCOUNT_MESSAGE");
                                Alert(sMessageLog);
                                return;
                            }
                            else
                            {
                                oUser.TodayFailedLoginAttempts += 1;
                                oUser.LastFailedLoginDate = DateTime.Now;
                                oUser.DAL_Update();

                                sMessageLog = PFSCommon.GetSysParam("INVALID_USER_PASSWORD_MESSAGE");
                                Alert(sMessageLog);
                                return;
                            }
                        }
                        // Check login status
                        else if (oUser.IsLogin)
                        {
                            int iTimer = Convert.ToInt32(PFSConfiguration.Role.FormExpires);
                            DateTime iDateTime = DateAndTime.DateAdd(DateInterval.Minute, iTimer, oUser.LastAccess);
                            long iInterval = DateAndTime.DateDiff(DateInterval.Minute, DateTime.Now, iDateTime);
                            if (iInterval <= 0)
                            {
                                bIsSuccessLogin = true;
                            }
                            else
                            {
                                UserLog oUserLog = new UserLog();
                                oUserLog.DAL_LoadLastLogByUserID(oUser.UserID);

                                // Compare IP Address
                                if (oUserLog.IpAddress == Request.UserHostAddress)
                                {
                                    bIsSuccessLogin = true;
                                }
                                else
                                {
                                    sMessageLog = string.Format(PFSCommon.GetSysParam("USER_ALREADY_LOGIN_MESSAGE"),
                                        oUser.UserName,
                                        oUser.LastAccess,
                                        iInterval);
                                    Alert(sMessageLog);
                                    return;
                                }

                                oUserLog = null;
                            }
                        }
                        else if (!oUser.IsActive)
                        {
                            sMessageLog = PFSCommon.GetSysParam("INACTIVE_ACCOUNT_MESSAGE");
                            Alert(sMessageLog);
                            return;
                        }
                        // Success Login
                        else
                        {
                            #region Is password expired

                            UserPasswordHistoryCollection oPasswordHistoryCollection = new UserPasswordHistoryCollection();
                            bool bIsPasswordExpired = false;
                            oPasswordHistoryCollection.DAL_LoadByUserID(oUser.UserID);
                            oPasswordHistoryCollection.Sort(UserPasswordHistoryCollection.UserPasswordHistoryFields.CreateDate, false);

                            if (oPasswordHistoryCollection.Count != 0)
                            {
                                TimeSpan tsDateDiff = DateTime.Now - oPasswordHistoryCollection[0].CreateDate;
                                if (tsDateDiff.Days > int.Parse(PFSCommon.GetSysParam("PASSWORD_EXPIRED_TIME")))
                                {
                                    viewLogin.SetActiveView(vChangePassword);
                                    bIsPasswordExpired = true;
                                }
                            }

                            if (!bIsUsingAD)
                            {
                                // If user never change its password, force user to change its password
                                if (oUser.LastAccess == Convert.ToDateTime("1/1/1900"))
                                {
                                    viewLogin.SetActiveView(vChangePassword);
                                    bIsPasswordExpired = true;
                                }

                                oPasswordHistoryCollection.Clear();
                                oPasswordHistoryCollection = null;
                            }


                            #endregion

                            #region Check Last Login Periode

                            if (!bIsPasswordExpired
                                && oUser.LastAccess.Date != PFSCommon.DefaultDate()
                                && oUser.LastAccess.Date <= DateTime.Now.AddDays(int.Parse(PFSCommon.GetSysParam("LAST_LOGIN_TIME_PERIODE")) * -1))
                            {
                                oUser.IsBlocked = true;
                                oUser.LastFailedLoginDate = DateTime.Now;
                                oUser.TodayFailedLoginAttempts += 1;
                                oUser.DAL_Update();

                                sMessageLog = PFSCommon.GetSysParam("LAST_LOGIN_TIME_BLOCKED_MESSSAGE");
                                Alert(sMessageLog);
                                return;
                            }

                            #endregion

                            // Login Success
                            if (!bIsPasswordExpired)
                            {
                                bIsSuccessLogin = true;
                            }
                        }
                    }
                }
                // Failed load data from Db
                else
                {
                    sMessageLog = PFSCommon.GetSysParam("INVALID_USER_PASSWORD_MESSAGE");
                    Alert(sMessageLog);
                    return;
                }

                if (bIsSuccessLogin)
                {
                    if (oUser.IsAllowedToLogin(Holiday.TodayHolidayCheck()))
                    {
                        sMessageLog = "LOGIN SUCCESS";
                        LoginMethod(oUser);
                    }
                    else
                    {
                        bIsSuccessLogin = false;
                        sMessageLog = PFSCommon.GetSysParam("HOLIDAY_LOGIN_MESSAGE");
                        Alert(sMessageLog);
                        return;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                bIsError = true;
                string sRefNo = PFSCommon.GenerateRefNumber();
                ExceptionLog.LogError(
                    sRefNo,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNo));
            }
            finally
            {
                #region Login Attempt

                try
                {
                    if (!bIsError)
                    {
                        oUserLoginAttempt.UserName = txtUserName.Text.Trim();
                        if (bIsSuccessLogin)
                        {
                            oUserLoginAttempt.LastFailedDescription = sMessageLog;
                            oUserLoginAttempt.UpdateFailLoginAttempt();
                        }
                        else
                        {
                            oUserLoginAttempt.UpdateSuccessLoginAttempt();
                        }
                    }

                    oUserLoginAttempt = null;
                }
                catch (Exception Ex)
                {
                    string sRefNo = PFSCommon.GenerateRefNumber();
                    ExceptionLog.LogError(
                        sRefNo,
                        GetType().FullName,
                        MethodInfo.GetCurrentMethod().Name,
                        Ex);
                    Alert(string.Format("{0} ({1})", GeneralError(), sRefNo));
                }

                #endregion

                //oUser.Password = "**********";
                //oUser.DecryptedPassword = "**********";

                Security.LogLoginActivity(
                    txtUserName.Text.Trim(),
                    Request.UserHostAddress,
                    sRefNumber,
                    sMessageLog,
                    oUser,
                    bIsSuccessLogin == true ? (Int16)1 : (Int16)0,
                    (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_LOGIN);

                // Relase resource
                oUser = null;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            bool bIsSuccess = false;
            string sRefNo = PFSCommon.GenerateRefNumber();
            string sMessageLog = string.Empty;
            User oUser = new User();

            try
            {
                oUser.DAL_LoadByUserName(txtUserName.Text, null);

                if (txtNewPassword.Text.Equals(txtCfrmNewPassword.Text))
                {
                    int iUpperCase = 0, iLowerCase = 0, iNumeric = 0;

                    //Check if password contain upper, lower or numeric
                    foreach (char cPwd in txtNewPassword.Text)
                    {
                        if (Char.IsNumber(cPwd)) iNumeric += 1;
                        else if (Char.IsUpper(cPwd)) iUpperCase += 1;
                        else if (Char.IsLower(cPwd)) iLowerCase += 1;
                    }

                    if (iNumeric >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_NUMERIC_CHAR"))
                        && iUpperCase >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_UPPER_CASE_CHAR"))
                        && iLowerCase >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_LOWER_CASE_CHAR"))
                        && txtNewPassword.Text.Length >= Convert.ToInt32(PFSCommon.GetSysParam("PASSWORD_LENGTH")))
                    {
                        //Check new password whether new password identical with n latest password
                        UserPasswordHistoryCollection oPasswordHistoryCollection = new UserPasswordHistoryCollection();
                        oPasswordHistoryCollection.DAL_LoadByUserID(oUser.UserID);
                        oPasswordHistoryCollection.Sort(
                            UserPasswordHistoryCollection.UserPasswordHistoryFields.CreateDate, false);

                        int batas = oPasswordHistoryCollection.Count >=
                                    Convert.ToInt32(PFSCommon.GetSysParam("LAST_UNIQUE_PASSWORD"))
                            ? Convert.ToInt32(PFSCommon.GetSysParam("LAST_UNIQUE_PASSWORD"))
                            : oPasswordHistoryCollection.Count;

                        for (int i = 0; i < batas; i++)
                        {
                            if (oPasswordHistoryCollection[i].Password == Security.Encrypt(txtNewPassword.Text))
                            {
                                sMessageLog = "Password cannot be same with "
                                              + PFSCommon.GetSysParam("LAST_UNIQUE_PASSWORD")
                                              + " latest passwords";
                                Alert(sMessageLog);
                                return;
                            }
                        }
                    }
                    else
                    {
                        sMessageLog = "Passwords must contain at least " + PFSCommon.GetSysParam("PASSWORD_LENGTH") +
                                      " characters \\n";
                        sMessageLog = sMessageLog + "Contain minimal " +
                                      PFSCommon.GetSysParam("PASSWORD_UPPER_CASE_CHAR") +
                                      " upper case alphabetical character\\n";
                        sMessageLog = sMessageLog + "Contain minimal " +
                                      PFSCommon.GetSysParam("PASSWORD_LOWER_CASE_CHAR") +
                                      " lower case alphabetical character\\n";
                        sMessageLog = sMessageLog + "Contain minimal " +
                                      PFSCommon.GetSysParam("PASSWORD_NUMERIC_CHAR") + " numeric character";

                        Alert(sMessageLog);
                        return;
                    }

                    oUser.Password = Security.Encrypt(txtNewPassword.Text);

                    UserPasswordHistory oPassHistory = new UserPasswordHistory();
                    oPassHistory.CreateDate = DateTime.Now;
                    oPassHistory.Password = Security.Encrypt(txtNewPassword.Text);
                    oPassHistory.UserID = oUser.UserID;
                    oPassHistory.UserName = oUser.UserName;
                    bIsSuccess = oPassHistory.DAL_Add();

                    if (bIsSuccess)
                    {
                        Alert("Change password successfull");
                        LoginMethod(oUser);
                    }
                    else
                    {
                        Alert(sMessageLog);
                    }
                }
                else
                {
                    sMessageLog = "Password not match";
                    Alert(sMessageLog);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(
                    sRefNo,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNo));
            }
            finally
            {
                Security.LogLoginActivity(
                    txtUserName.Text.Trim(),
                    Request.UserHostAddress,
                    sRefNo,
                    sMessageLog,
                    oUser,
                    bIsSuccess == true ? (Int16)1 : (Int16)0,
                    (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_CHANGE_PASSWORD);
            }
        }

        #endregion

        #region Method

        private void LoginMethod(User p_User)
        {
            // Create the authetication ticket
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                txtUserName.Text,
                DateTime.Now,
                DateTime.Now.AddMinutes(Convert.ToInt32(PFSConfiguration.Role.FormExpires)),
                false,
                "");

            // Now encrypt the ticket.
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            // Create a cookie and add the encrypted ticket to the cookie as data.
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Add the cookie to the outgoing cookies collection.
            Response.Cookies.Add(authCookie);

            if (Response.IsClientConnected)
            {
                p_User.TodayFailedLoginAttempts = 0;
                p_User.IsLogin = true;
                p_User.LastAccess = DateTime.Now;
                p_User.DAL_Update();

                Session["sessCurrentUser"] = p_User;
                Response.Redirect("~/Index.htm", true);
            }
            else
            {
                Response.End();
            }

        }
        #endregion
    }
}