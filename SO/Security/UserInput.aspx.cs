using System;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using Telerik.Web.UI;
using PSC.BusinessLogicLayer;
using System.Drawing;
using System.Threading;
using PSC.BusinessLogicLayer.Enumeration;
using System.Reflection;
using System.Web;
using System.Data;

namespace PSC.Web.UI
{
    public partial class Security_UserInput : PFSBasePage
    {
        #region Session

        private User sessUser
        {
            get { return Session["sessUser"] == null ? new User() : (User)Session["sessUser"]; }
            set { Session["sessUser"] = value; }
        }
        private User sessNewUser
        {
            get { return Session["sessNewUser"] == null ? new User() : (User)Session["sessNewUser"]; }
            set { Session["sessNewUser"] = value; }
        }
        private bool sessIsApprovalMode
        {
            get { return Session["IsApprovalMode"] == null ? false : Convert.ToBoolean(Session["IsApprovalMode"]); }
            set { Session["IsApprovalMode"] = value; }
        }
        #endregion

        #region QueryString

        private int qs_iUserID
        {
            get { return Request.QueryString["UserID"] == null ? -1 : Convert.ToInt32(Request.QueryString["UserID"]); }
        }
        private int? qs_iApprovalID
        {
            get { return Convert.ToInt32(Request.QueryString["ID"]); }
        }
        private int qs_iViewDetail
        {
            get { return Request.QueryString["View"] == null ? 0 : Convert.ToInt32(Request.QueryString["View"]); }
        }

        private string qs_sViewType
        {
            get { return Request.QueryString["ViewType"] == null ? "NONE" : Request.QueryString["ViewType"]; }
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
                if (qs_sViewType == "ChangeUserData")
                {
                    #region Change User Info

                    calStartLoginTime.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    calEndLoginTime.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);

                    GetUser();

                    trApprovalInformation.Visible = false;
                    tdNewUserData.Visible = false;
                    trRemarks.Visible = false;

                    rbIsActive.Enabled = false;
                    rbIsBlocked.Enabled = false;
                    txtUserName.Enabled = false;
                    btnVerifyAD.Visible = false;
                    calStartLoginTime.Enabled = false;
                    calEndLoginTime.Enabled = false;
                    chkHolidayLogin.Enabled = false;

                    trAddAuthGroup.Visible = false;
                    tdNewUserGroupData.Visible = false;
                    rgridAuthGroup.MasterTableView.Columns[3].Visible = false;

                    #endregion
                }
                else
                {
                    SwitchToApprovalMode(qs_iApprovalID > 0);
                    //SetTitle();

                    if (qs_iApprovalID > 0)
                    {
                        if ((!Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.SCR_USR_APPROVE.ToString())) &&
                            (!Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.SCR_USR_REJECT.ToString())))
                            NoPermission();

                        btnApprove.Visible =
                            Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.SCR_USR_APPROVE.ToString()) &&
                            qs_iViewDetail <= 0;
                        btnReject.Visible =
                            Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.SCR_USR_REJECT.ToString()) &&
                            qs_iViewDetail <= 0;

                        GetDataApprovalInformation();
                    }
                    else //(qs_iUserID != null)
                    {
                        if (cbChangePassword.Visible && cbChangePassword.Checked)
                        {
                            trPassword.Visible = true;
                            trPasswordConfirm.Visible = true;
                        }
                        else
                        {
                            if (qs_iUserID > 0)
                            {
                                trPassword.Visible = false;
                                trPasswordConfirm.Visible = false;
                            }
                            else
                            {
                                cbChangePassword.Visible = false;
                                trPassword.Visible = true;
                                trPasswordConfirm.Visible = true;
                            }
                        }
                        if (!IsPostBack)
                        {
                            if (
                                !Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.SCR_USR_CREATE.ToString()) &&
                                qs_iUserID <= 0)
                                NoPermission();

                            if (
                                !Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE.ToString()) &&
                                qs_iUserID > 0)
                                NoPermission();

                            calStartLoginTime.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                DateTime.Now.Day, 8, 0, 0);
                            calEndLoginTime.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                DateTime.Now.Day, 17, 0, 0);

                            BindBranchCode();
                            BindAdDomain();
                            GetUser();
                            BindCmbAuthGroup(cmbAuthGroup);
                        }
                    }
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
                if (sender == cbChangePassword)
                {
                    trPassword.Visible = cbChangePassword.Checked;
                    trPasswordConfirm.Visible = cbChangePassword.Checked;
                }
                else if (sender == cbNewChangePassword)
                {
                    trNewPassword.Visible = cbNewChangePassword.Checked;
                    trNewPasswordConfirm.Visible = cbNewChangePassword.Checked;
                }
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
            string sPreviousDetail = string.Empty;
            short iStatus = 0;
            ApprovalLog oApprovalLog = new ApprovalLog();
            ApprovalLog oCheckExistingContent = new ApprovalLog();
            User oCheckUser = new User();
            object iUserID = null;

            if (qs_iUserID > 0)
                iUserID = qs_iUserID;

            try
            {
                bool bIsUserActive = Convert.ToBoolean(rbIsActive.SelectedValue);
                bool bIsUserBlocked = Convert.ToBoolean(rbIsBlocked.SelectedValue);
                if (rgridAuthGroup.Items.Count <= 0)
                {
                    Alert("Please assign at least 1 group access to this user");
                    return;
                }
                else if (oCheckUser.DAL_LoadByUserName(txtUserName.Text, iUserID))
                {
                    //*** Duplicate username detected ***//
                    Alert("Duplicate username in Database. Please change the username");
                    return;
                }
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("User", "UserName", txtUserName.Text, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_CREATE, null))
                {
                    //*** Duplicate username detected in ApprovalLog***//
                    Alert("Duplicate username in Approval Log. Please change the username");
                    return;
                }
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("User", "UserName", txtUserName.Text, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE, null))
                {
                    //*** Duplicate username detected in ApprovalLog***//
                    Alert("Duplicate username in Approval Log. Please change the username");
                    return;
                }
                else
                //else if (!bIsUserActive || (bIsUserActive && IsUserVerified()))
                //else if (IsUserVerified())
                {

                    bool bVerified = false;
                    if (bIsUserActive) bVerified = IsUserVerified();

                    if ((!bIsUserActive) || (bVerified && bIsUserActive))
                    {
                        sessUser.UserID = qs_iUserID;
                        sessUser.IsActive = bIsUserActive;//Convert.ToBoolean(rbIsActive.SelectedValue);
                        sessUser.IsBlocked = bIsUserBlocked;
                        sessUser.FullName = txtFullName.Text;
                        sessUser.Email = txtEmail.Text;
                        sessUser.UserName = txtUserName.Text;

                        if (!bIsUserBlocked)
                        {
                            sessUser.TodayFailedLoginAttempts = 0;
                            sessUser.LastAccess = DateTime.Now;
                        }

                        sessUser.StartLoginTime = calStartLoginTime.SelectedDate.Value.TimeOfDay.ToString().Substring(0, 5);
                        sessUser.EndLoginTime = calEndLoginTime.SelectedDate.Value.TimeOfDay.ToString().Substring(0, 5);
                        sessUser.AllowWeekendLogin = sessUser.AllowHolidayLogin = chkHolidayLogin.Checked;

                        sessUser.UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessUser.UpdateDate = DateTime.Now;

                        #region Validate Complex Password

                        if (txtPassword.Text.Trim().Length > 0)
                        {
                            if (!ValidateComplexPassword(
                                    txtPassword.Text.Trim(),
                                    qs_iUserID,
                                    cbChangePassword.Checked ? true : false,
                                    out sRemark))
                            {
                                Alert(sRemark);
                                return;
                            }
                        }

                        #endregion

                        #region User Detail
                        PFSHelper.BusinessLogicLayer.UserDetail oUserDetail = new PFSHelper.BusinessLogicLayer.UserDetail();
                        oUserDetail.BranchCode = ddlBranchCode.SelectedValue;
                        oUserDetail.UserID = sessUser.UserID;
                        sessUser.UserDetails.Add(oUserDetail);
                        #endregion

                        //*** UPDATE USER ***//
                        if (qs_iUserID > 0)
                        {
                            #region Update User

                            sDescription = "Update User";
                            User oUser = new User();
                            oUser.DAL_LoadWithChild(qs_iUserID);

                            if (lblLastAccess.Text == "-")
                            {
                                sessUser.LastAccess = Convert.ToDateTime("1/1/1900");
                            }
                            else
                            {
                                if (bIsUserBlocked)
                                {
                                    sessUser.LastAccess = oUser.LastAccess;
                                }
                            }

                            if (cbChangePassword.Checked)
                            {
                                sessUser.Password = PFSCommon.HashString(txtPassword.Text.Trim());
                            }
                            else
                            {
                                sessUser.Password = oUser.Password;
                            }

                            oApprovalLog.RefID = Convert.ToInt32(sessUser.UserID);
                            oApprovalLog.ModuleObjectMemberID = (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE;
                            oApprovalLog.ApprovalStatusID = (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.PENDING;
                            oApprovalLog.Detail = PFSXMLTools.SerializeObjectUsingUnicode<User>(sessUser);
                            oApprovalLog.PreviousDetail = sPreviousDetail = PFSXMLTools.SerializeObjectUsingUnicode<User>(oUser);

                            if (qs_sViewType == "ChangeUserData")
                            {
                                if (sessUser.DAL_Update())
                                {
                                    iStatus = 1;
                                }
                            }
                            else
                            {
                                iStatus =
                                    Convert.ToInt16(Approval.UpdateApprovalLog(sessUser, oApprovalLog,
                                        PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.PENDING,
                                        ref sRemark));
                            }

                            #endregion
                        }
                        //*** CREATE USER ***//
                        else
                        {
                            #region Create User

                            sDescription = "Create User";

                            sessUser.LastAccess = Convert.ToDateTime("1/1/1900");
                            sessUser.Password = PFSCommon.HashString(txtPassword.Text.Trim());
                            sessUser.IsNeedApproval = true;

                            sessUser.CreateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                            sessUser.CreateDate = DateTime.Now;

                            oApprovalLog.RefID = Convert.ToInt32(-1);
                            oApprovalLog.ModuleObjectMemberID = (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_CREATE;
                            oApprovalLog.ApprovalStatusID = (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.PENDING;
                            oApprovalLog.Detail = PFSXMLTools.SerializeObjectUsingUnicode<User>(sessUser);
                            oApprovalLog.PreviousDetail = sPreviousDetail = PFSXMLTools.SerializeObjectUsingUnicode<User>(sessUser);

                            iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(sessUser, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.PENDING, ref sRemark));

                            #endregion
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
                    PFSCommon.ClearAccessRight();

                    sDescription += " successful";
                    if (qs_sViewType == "ChangeUserData")
                    {
                        BackToUserList(sDescription);
                    }
                    else
                    {
                        BackToUserList(sDescription + " and ready for approval process");
                    }
                }

            }
            catch (Exception Ex)
            {
                if (Ex.Message.Contains("Logon failure: unknown user name or bad password"))
                {
                    Alert("You don't have any rights to verify user on this system");
                }
                else
                {
                    ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                    Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
                }
            }
            finally
            {
                Security.WriteUserLog(
                    sRefNumber,
                    sDescription,
                    sessUser,
                    iStatus,
                    oApprovalLog.ModuleObjectMemberID,
                    sPreviousDetail);

                //*** Dispose Any Objects ***//
                if (iStatus == 1) sessUser = null;
                sRefNumber = null;
                sDescription = null;
                oApprovalLog = null;
            }
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string sRefNumber = RefNumber;
            string sRemark = string.Empty;
            string sDescription = "Approve User Request";
            short iStatus = 0;
            ApprovalLog oApprovalLog = new ApprovalLog(Convert.ToInt32(qs_iApprovalID));
            User oUser = new User();

            try
            {
                oApprovalLog.DAL_LoadWithWithModuleObject();
                oApprovalLog.Remark = txtRemarks.Text;
                oUser = (User)PFSXMLTools.DeserializeObjectUsingUnicode<User>(oApprovalLog.Detail);
                ApprovalLog oCheckExistingContent = new ApprovalLog();

                object iUserID = null;

                if (oUser.UserID > 0)
                    iUserID = oUser.UserID;

                if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_CREATE)
                {
                    sDescription = "Approve Create User";

                    //*** Check duplication ***//
                    User oCheckUser = new User();

                    if (oCheckUser.DAL_LoadByUserName(oUser.UserName, iUserID))
                        //*** Duplicate username detected ***//
                        sDescription = "Duplicate username in Database. Please change the username";
                    else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("User", "UserName", oUser.UserName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_CREATE, oApprovalLog.ApprovalLogID))
                    {
                        //*** Duplicate username detected in ApprovalLog***//
                        sDescription = "Duplicate username in Approval Log. Please change the username";
                    }
                    else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("User", "UserName", oUser.UserName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE, oApprovalLog.ApprovalLogID))
                    {
                        //*** Duplicate username detected in ApprovalLog***//
                        sDescription = "Duplicate username in Approval Log. Please change the username";
                    }
                    else
                        if ((iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oUser, oApprovalLog, PSCEnumeration.ApprovalStatus.APPROVE, ref sRemark))) == 1)
                        {
                            sDescription += " successful";
                        }
                        else
                            sDescription += " not successful";

                }
                else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE)
                {
                    sDescription = "Approve Update User";

                    //*** Check duplicate user name ***//
                    bool bIsFound = false;
                    User oCheckUser = new User();

                    bIsFound = oCheckUser.DAL_LoadByUserName(oUser.UserName, iUserID);

                    //*** Check Duplication ***//
                    if (bIsFound && oCheckUser.UserID != oUser.UserID)
                        //*** Duplicate name detected ***//
                        sDescription = "Duplicate username in Database. Please change the username";
                    else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("User", "UserName", oUser.UserName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_CREATE, oApprovalLog.ApprovalLogID))
                    {
                        //*** Duplicate username detected in ApprovalLog***//
                        sDescription = "Duplicate username in Approval Log. Please change the username";
                    }
                    else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("User", "UserName", oUser.UserName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE, oApprovalLog.ApprovalLogID))
                    {
                        //*** Duplicate username detected in ApprovalLog***//
                        sDescription = "Duplicate username in Approval Log. Please change the username";
                    }
                    //*** Approve and Update if no duplication ***//
                    else
                        //*** Set Description Status ***//
                        if ((iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oUser, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.APPROVE, ref sRemark))) == 1)
                        {
                            sDescription += " successful";
                            if (trChangePasswordNotification.Visible)
                            {
                                UserPasswordHistory oUserPasswordHistory = new UserPasswordHistory();
                                oUserPasswordHistory.CreateDate = DateTime.Now;
                                oUserPasswordHistory.UserID = oUser.UserID;
                                oUserPasswordHistory.Password = oUser.Password;
                                if (oUserPasswordHistory.DAL_Add())
                                {
                                    sDescription += " successful";
                                }
                                else
                                {
                                    sDescription += " not successful";
                                }
                            }
                        }
                        else
                            sDescription += " not successful";

                }
                else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_DELETE)
                {
                    sDescription = "Approve Delete User";

                    if (PFSHelper.BusinessLogicLayer.User.IsHaveRelation(oUser.UserID))
                    {
                        sDescription += " failed, this user having some relation to another data, you have to reject this request.";
                        Alert(sDescription);
                        return;
                    }

                    iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oUser, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.APPROVE, ref sRemark));

                    //*** Set Description Status ***//
                    if (iStatus == 1) sDescription += " successful";
                    else sDescription += " not successful CODE:" + sRefNumber;
                }

                if (iStatus == 0) Alert(sDescription);
                else
                {
                    PFSCommon.ClearAccessRight();

                    BackToApprovalList(sDescription);
                }

            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
            finally
            {
                Security.WriteUserLog(sRefNumber, sDescription, oUser, iStatus, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_APPROVE);

                //*** Dispose Any Object ***?//
                sRefNumber = null;
                sDescription = null;
                sessUser = null;
                sessNewUser = null;
                oApprovalLog = null;
                oUser = null;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string sRefNumber = RefNumber;
            try
            {
                if (sessIsApprovalMode)
                    BackToApprovalList();
                else
                    BackToUserList();

            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            string sRefNumber = RefNumber;
            string sRemark = string.Empty;
            string sDescription = "Reject Approval Request";
            short iStatus = 0;
            ApprovalLog oApprovalLog = new ApprovalLog(Convert.ToInt32(qs_iApprovalID));
            User oUser = new User();

            try
            {
                oApprovalLog.DAL_LoadWithWithModuleObject();
                oApprovalLog.Remark = txtRemarks.Text;
                oUser = (User)PFSXMLTools.DeserializeObjectUsingUnicode<User>(oApprovalLog.Detail);

                iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oUser, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.REJECT, ref sRemark));
                if (iStatus == 0)
                {
                    sDescription += " not successful CODE:" + sRefNumber;
                    Alert(sDescription);
                }
                else
                {
                    sDescription += " successful";
                    BackToApprovalList(sDescription);
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
            finally
            {
                Security.WriteUserLog(sRefNumber, sDescription, oUser, iStatus, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_REJECT);

                //*** Dispose Any Objects ***//
                sRefNumber = null;
                sessUser = null;
                sessNewUser = null;
                oApprovalLog = null;
                oUser = null;
            }
        }
        protected void btnVerifyAD_Click(object sender, EventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();

            try
            {
                if (txtUserName.Text.Length > 0)
                    IsUserVerified();
                else
                    Alert("Please input username...");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Logon failure: unknown user name or bad password"))
                {
                    Alert("Your dont have right to verify user on this system");
                }
                else
                {
                    ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                    Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
                }
            }
            finally
            {

            }
        }
        protected void btnAddAuthGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCurrentUserGroup())
                {
                    Alert("Group already exists");
                }
                else
                {
                    if (cmbAuthGroup.SelectedValue != "-1")
                    {
                        UserGroup oNewUserGroup = new UserGroup();
                        oNewUserGroup.GroupID = Convert.ToInt32(cmbAuthGroup.SelectedValue);
                        oNewUserGroup.UserID = qs_iUserID;
                        oNewUserGroup.GroupName = Convert.ToString(cmbAuthGroup.SelectedItem);

                        sessUser.UserGroupList.Add(oNewUserGroup);
                        rgridAuthGroup.Rebind();
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        #endregion

        #region Grid Eevnts

        protected void rgridAuthGroup_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string sRefNumber = RefNumber;
            try
            {
                if (e.CommandName == RadGrid.DeleteCommandName)
                {
                    Label lblGroupID = (Label)e.Item.FindControl("lblGroupID");
                    for (int i = 0; i < sessUser.UserGroupList.Count; i++)
                    {
                        if (sessUser.UserGroupList[i].GroupID == Convert.ToInt32(lblGroupID.Text))
                        {
                            sessUser.UserGroupList.RemoveAt(i);
                        }
                    }
                    rgridAuthGroup.Rebind();
                }
            }
            catch (Exception Ex)
            {
                if (Ex is ThreadAbortException)
                {
                    //** Do Nothing, Just Bypass this exception **//
                }
                else
                {
                    ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                    Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
                }
            }
        }
        protected void rgridNewAuthGroup_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                if (e.CommandName == RadGrid.DeleteCommandName)
                {
                    int iUserGroupID = Convert.ToInt32(rgridNewAuthGroup.MasterTableView.DataKeyValues[e.Item.ItemIndex]["UserGroupID"]);
                    foreach (UserGroup oUserGroup in sessUser.UserGroupList)
                    {
                        if (oUserGroup.UserGroupID == iUserGroupID)
                        {
                            sessUser.UserGroupList.RemoveByID(iUserGroupID);
                        }
                    }
                    //RemoveChildByID(sessUser.UserGroupList, iUserGroupID);
                    rgridNewAuthGroup.Rebind();
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
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
        protected void rgridNewAuthGroup_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgridNewAuthGroup.DataSource = sessNewUser.UserGroupList;
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
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
        /// Back to Approval List page if this form was called from -> ApprovalList.aspx
        /// </summary>
        /// <param name="PromptMessage">Message to prompt</param>
        private void BackToApprovalList(string PromptMessage = null)
        {
            try
            {
                if (PromptMessage != null)
                    Response.Write("<script>alert('" + PromptMessage + "'); location.href='../ApprovalLog/ApprovalLogList.aspx'</script>");
                else
                    Response.Redirect("../ApprovalLog/ApprovalLogList.aspx");
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Function to bind group data to combo box/Dropdown List
        /// </summary>
        /// <param name="cmbMyCombo">Control Name</param>
        private void BindCmbAuthGroup(DropDownList cmbMyCombo)
        {
            try
            {
                cmbMyCombo.DataSource = null;

                GroupCollection oGroupCollection = new GroupCollection();
                oGroupCollection.DAL_Load(null, true, null, null, null, null, null, null, null);
                oGroupCollection.Sort(GroupCollection.GroupFields.GroupName, true);

                cmbMyCombo.DataSource = oGroupCollection;
                cmbMyCombo.DataTextField = "GroupName";
                cmbMyCombo.DataValueField = "GroupID";
                cmbMyCombo.DataBind();

                ListItem li = new ListItem(STRING_SELECT_ONE, "-1");
                cmbMyCombo.Items.Insert(0, li);
                cmbMyCombo.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindBranchCode()
        {
            BranchCollection oBranchCollection = new BranchCollection();
            oBranchCollection.DAL_Load();

            ddlBranchCode.Items.Clear();
            ddlBranchCode.Items.Add(new ListItem(STRING_SELECT_ONE, string.Empty));
            foreach (Branch oBranch in oBranchCollection)
            {
                ddlBranchCode.Items.Add(new ListItem(oBranch.BranchCode + " - " + oBranch.BranchName, oBranch.BranchCode));
            }

        }

        private void BindAdDomain()
        {
            if (PFSConfiguration.ActiveDirectory.IsUsingAd)
            {
                trAdDomain.Visible = true;
                string[] sAdDomain = PFSConfiguration.ActiveDirectory.AdDomain.Split(new string[] { "|" }, StringSplitOptions.None);
                string[] sAdPath = PFSConfiguration.ActiveDirectory.AdPath.Split(new string[] { "|" }, StringSplitOptions.None);

                for (int i = 0; i < sAdDomain.Length; i++)
                {
                    rblAdDomain.Items.Add(new ListItem(sAdDomain[i].ToString(), sAdPath[i].ToString()));
                }
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

                    rbIsActive.SelectedValue = oUser.IsActive.ToString().ToLower();//oUser.IsActive.ToString();//Convert.ToInt32(oUser.IsActive);// Convert.ToInt32(oUser.IsActive).ToString();
                    rbIsBlocked.SelectedValue = oUser.IsBlocked.ToString().ToLower();
                    txtFullName.Text = oUser.FullName;
                    txtEmail.Text = oUser.Email;
                    txtUserName.Text = oUser.UserName;
                    if (oUser.UserDetails.Count > 0)
                        ddlBranchCode.SelectedValue = oUser.UserDetails[0].BranchCode;

                    calStartLoginTime.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(oUser.StartLoginTime.Substring(0, 2)), Int32.Parse(oUser.StartLoginTime.Substring(3, 2)), 0);
                    calEndLoginTime.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(oUser.EndLoginTime.Substring(0, 2)), Int32.Parse(oUser.EndLoginTime.Substring(3, 2)), 0);
                    chkHolidayLogin.Checked = oUser.AllowHolidayLogin;

                    lblLastAccess.Text = string.Format("{0:dd MMMM yyyy, hh:mm:ss}", oUser.LastAccess);
                    if (oUser.LastAccess.Year == 1900) lblLastAccess.Text = "-";

                    sessUser = oUser;

                    trPassword.Visible = false;
                    trPasswordConfirm.Visible = false;
                }
                else
                {
                    trChangePassword.Visible = false;
                    sessUser = new User();
                }

                rgridAuthGroup.Rebind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Function to check Member of Group on current user login
        /// </summary>
        /// <returns>True if exist and False if not exist</returns>
        private bool CheckCurrentUserGroup()
        {
            try
            {
                bool bAlreadyExist = false;
                foreach (UserGroup oCheckUserGroup in sessUser.UserGroupList)
                {
                    if (oCheckUserGroup.GroupID == Convert.ToInt32(cmbAuthGroup.SelectedValue))
                    {
                        bAlreadyExist = true;
                        break;
                    }
                }
                return bAlreadyExist;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Function to make this form in approval input form for this module object
        /// </summary>
        /// <param name="p_ApprovalMode">IsApprovalMode</param>
        private void SwitchToApprovalMode(bool p_ApprovalMode)
        {
            try
            {
                sessIsApprovalMode = p_ApprovalMode;

                //*** INVISIBLE ***//
                trRequiredFieldsLabel.Visible =
                trAddAuthGroup.Visible =
                trNewAddAuthGroup.Visible =
                btnAddAuthGroup.Visible =
                btnSave.Visible =
                btnCancel.Visible =
                rbIsActive.Visible =
                rbIsBlocked.Visible =
                txtFullName.Visible =
                ddlBranchCode.Visible =
                txtEmail.Visible =
                txtUserName.Visible =
                btnVerifyAD.Visible =
                calStartLoginTime.Visible =
                calEndLoginTime.Visible =
                chkHolidayLogin.Visible =
                    trChangePassword.Visible =
                    trPassword.Visible =
                    trPasswordConfirm.Visible =

                trLastAccess.Visible =
                rgridNewAuthGroup.MasterTableView.Columns[3].Visible =
                rgridAuthGroup.MasterTableView.Columns[3].Visible =
                    trNewChangePassword.Visible =
                    trNewPassword.Visible =
                    trNewPasswordConfirm.Visible =
                trNewLastAccess.Visible =
                trChangePasswordNotification.Visible =

                !(//*** VISIBLE ***//
                    trApprovalInformation.Visible =
                    lblActiveStatus.Visible =
                    lblBlockedStatus.Visible =
                    lblFullName.Visible =
                    lblEmail.Visible =
                    lblUsername.Visible =
                    lblNewActiveStatus.Visible =
                    lblNewBlockedStatus.Visible =
                    lblNewFullName.Visible =
                    lblNewEmail.Visible =
                    lblNewUsername.Visible =
                    tdNewUserGroupData.Visible =
                    tdNewUserData.Visible =
                    trRemarks.Visible =
                    btnBack.Visible =
                    p_ApprovalMode
                );

                if (qs_iViewDetail == 1)
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;
                }
                else
                {
                    tdUserData.ColSpan = 2;
                    tdUserGroupData.ColSpan = 2;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Function to get data on Detail Approval
        /// </summary>
        private void GetDataApprovalInformation()
        {
            ApprovalLog oApprovalLog = new ApprovalLog(Convert.ToInt32(qs_iApprovalID));
            User oUser = new User();
            User oNewUser = new User();

            try
            {
                oApprovalLog.DAL_LoadWithWithModuleObject();

                lblRequestBy.Text = string.Format("{0} / {1}", oApprovalLog.CreateByUserName, oApprovalLog.CreateByFullUserName);
                lblRequestDate.Text = string.Format("{0:dd-MMM-yyyy HH:mm:ss}", oApprovalLog.CreateDate);
                lblRequestType.Text = oApprovalLog.MemberName;

                if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_CREATE)
                {
                    tdUserData.Visible = false;
                    tdUserGroupData.Visible = false;

                    oNewUser = (User)PFSXMLTools.DeserializeObjectUsingUnicode<User>(oApprovalLog.Detail);
                    lblNewActiveStatus.Text = oNewUser.IsActive ? "Active" : "Not Active";
                    lblNewBlockedStatus.Text = oNewUser.IsBlocked ? "Blocked" : "Not Blocked";
                    lblNewFullName.Text = oNewUser.FullName;
                    lblNewEmail.Text = oNewUser.Email;
                    lblNewUsername.Text = oNewUser.UserName;
                    if (oNewUser.UserDetails.Count > 0)
                        lblNewBranchCode.Text = oNewUser.UserDetails[0].BranchCode;

                    lblNewStartLoginTime.Text = oNewUser.StartLoginTime;
                    lblNewEndLoginTime.Text = oNewUser.EndLoginTime;
                    lblNewHolidayLogin.Text = oNewUser.AllowHolidayLogin ? "Allowed" : "Not Allowed";

                    lblNewLastAccess.Text = string.Format("{0:dd MMMM yyyy, hh:mm:ss}", oNewUser.LastAccess);
                    if (oNewUser.LastAccess.Year == 1900) lblNewLastAccess.Text = "-";

                    sessNewUser = oNewUser;
                    rgridNewAuthGroup.Rebind();

                }
                else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE)
                {
                    //oUser.DAL_LoadWithChild(oApprovalLog.RefID);
                    oUser = (User)PFSXMLTools.DeserializeObjectUsingUnicode<User>(oApprovalLog.PreviousDetail);
                    lblActiveStatus.Text = oUser.IsActive ? "Active" : "Not Active";
                    lblBlockedStatus.Text = oUser.IsBlocked ? "Blocked" : "Not Blocked";
                    lblFullName.Text = oUser.FullName;
                    if (oUser.UserDetails.Count > 0)
                        lblBranchCode.Text = oUser.UserDetails[0].BranchCode;
                    lblEmail.Text = oUser.Email;
                    lblUsername.Text = oUser.UserName;
                    lblStartLoginTime.Text = oUser.StartLoginTime;
                    lblEndLoginTime.Text = oUser.EndLoginTime;
                    lblHolidayLogin.Text = oUser.AllowHolidayLogin ? "Allowed" : "Not Allowed";
                    lblPassword.Text = oUser.Password;
                    lblLastAccess.Text = string.Format("{0:dd MMMM yyyy, hh:mm:ss}", oUser.LastAccess);
                    if (oUser.LastAccess.Year == 1900) lblLastAccess.Text = "-";

                    sessUser = oUser;
                    rgridAuthGroup.Rebind();

                    oNewUser = (User)PFSXMLTools.DeserializeObjectUsingUnicode<User>(oApprovalLog.Detail);
                    lblNewActiveStatus.Text = oNewUser.IsActive ? "Active" : "Not Active";
                    lblNewBlockedStatus.Text = oNewUser.IsBlocked ? "Blocked" : "Not Blocked";
                    lblNewFullName.Text = oNewUser.FullName;
                    if (oNewUser.UserDetails.Count > 0)
                        lblNewBranchCode.Text = oNewUser.UserDetails[0].BranchCode;
                    lblNewEmail.Text = oNewUser.Email;
                    lblNewUsername.Text = oNewUser.UserName;
                    lblNewStartLoginTime.Text = oNewUser.StartLoginTime;
                    lblNewEndLoginTime.Text = oNewUser.EndLoginTime;
                    lblNewHolidayLogin.Text = oNewUser.AllowHolidayLogin ? "Allowed" : "Not Allowed";
                    lblNewPassword.Text = oNewUser.Password;
                    lblNewLastAccess.Text = string.Format("{0:dd MMMM yyyy, hh:mm:ss}", oNewUser.LastAccess);
                    if (oNewUser.LastAccess.Year == 1900) lblNewLastAccess.Text = "-";

                    sessNewUser = oNewUser;
                    rgridNewAuthGroup.Rebind();

                    CompareAndHighlight();

                }
                else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_USR_DELETE)
                {
                    oUser = (User)PFSXMLTools.DeserializeObjectUsingUnicode<User>(oApprovalLog.Detail);
                    lblActiveStatus.Text = oUser.IsActive ? "Active" : "Not Active";
                    lblBlockedStatus.Text = oUser.IsBlocked ? "Blocked" : "Not Blocked";
                    lblFullName.Text = oUser.FullName;
                    if (oUser.UserDetails.Count > 0)
                        lblBranchCode.Text = oUser.UserDetails[0].BranchCode;
                    lblEmail.Text = oUser.Email;
                    lblStartLoginTime.Text = oUser.StartLoginTime;
                    lblEndLoginTime.Text = oUser.EndLoginTime;
                    lblHolidayLogin.Text = oUser.AllowHolidayLogin ? "Allowed" : "Not Allowed";
                    lblUsername.Text = oUser.UserName;
                    lblLastAccess.Text = string.Format("{0:dd MMMM yyyy, hh:mm:ss}", oUser.LastAccess);
                    if (oUser.LastAccess.Year == 1900) lblLastAccess.Text = "-";

                    sessUser = oUser;
                    rgridAuthGroup.Rebind();

                    tdNewUserData.Visible = false;
                    tdNewUserGroupData.Visible = false;
                }

                if (qs_iViewDetail == 1)
                {
                    txtRemarks.Text = oApprovalLog.Remark;
                    txtRemarks.Enabled = false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                oUser = null;
                oNewUser = null;
                oApprovalLog = null;
            }
        }
        /// <summary>
        /// Function in approval mode to compare side by side data between old data and new one. And highlight unmacthed data
        /// </summary>
        private void CompareAndHighlight()
        {
            try
            {
                if (!lblActiveStatus.Text.Equals(lblNewActiveStatus.Text))
                {
                    lblActiveStatus.BackColor =
                    lblNewActiveStatus.BackColor = Color.Yellow;
                }
                if (!lblBlockedStatus.Text.Equals(lblNewBlockedStatus.Text))
                {
                    lblBlockedStatus.BackColor =
                    lblNewBlockedStatus.BackColor = Color.Yellow;
                }
                if (!lblFullName.Text.Equals(lblNewFullName.Text))
                {
                    lblFullName.BackColor =
                    lblNewFullName.BackColor = Color.Yellow;
                }

                if (!lblEmail.Text.Equals(lblNewEmail.Text))
                {
                    lblEmail.BackColor =
                    lblNewEmail.BackColor = Color.Yellow;
                }
                if (!lblUsername.Text.Equals(lblNewUsername.Text))
                {
                    lblUsername.BackColor =
                    lblNewUsername.BackColor = Color.Yellow;
                }
                if (!lblPassword.Text.Equals(lblNewPassword.Text))
                {
                    trChangePasswordNotification.Visible = true;
                }
                if (!lblStartLoginTime.Text.Equals(lblNewStartLoginTime.Text))
                {
                    lblStartLoginTime.BackColor =
                    lblNewStartLoginTime.BackColor = Color.Yellow;
                }
                if (!lblEndLoginTime.Text.Equals(lblNewEndLoginTime.Text))
                {
                    lblEndLoginTime.BackColor = lblNewEndLoginTime.BackColor = Color.Yellow;
                }
                if (!lblHolidayLogin.Text.Equals(lblNewHolidayLogin.Text))
                {
                    lblHolidayLogin.BackColor = lblNewHolidayLogin.BackColor = Color.Yellow;
                }

                /** Compare Between Grid **/
                foreach (GridDataItem oNewItem in rgridNewAuthGroup.MasterTableView.Items)
                {
                    bool bIsFound = false;
                    foreach (GridDataItem oOldItem in rgridAuthGroup.MasterTableView.Items)
                    {
                        if ((oOldItem.DataItem as UserGroup).GroupName == (oNewItem.DataItem as UserGroup).GroupName)
                        {
                            bIsFound = true;
                            break;
                        }
                    }

                    if (!bIsFound)
                    {
                        oNewItem.BackColor = Color.Red;
                    }
                }

                foreach (GridDataItem oNewItem in rgridAuthGroup.MasterTableView.Items)
                {
                    bool bIsFound = false;
                    foreach (GridDataItem oOldItem in rgridNewAuthGroup.MasterTableView.Items)
                    {
                        if ((oOldItem.DataItem as UserGroup).GroupName == (oNewItem.DataItem as UserGroup).GroupName)
                        {
                            bIsFound = true;
                            break;
                        }
                    }

                    if (!bIsFound)
                    {
                        oNewItem.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
        private bool IsUserVerified()
        {
            try
            {
                if (!PFSConfiguration.ActiveDirectory.IsUsingAd)
                    return true;
                else
                {
                    string[] id = HttpContext.Current.User.Identity.Name.Split('\\');
                    User oUser = (User)Session["sessCurrentUser"];
                    string sDecryptedPassword = oUser.DecryptedPassword;
                    using (PFSAD obj = new PFSAD(((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserName, sDecryptedPassword, rblAdDomain.SelectedValue))
                    {
                        //if (!Convert.ToBoolean(rbIsActive.SelectedValue))
                        //{
                        DataSet ds = obj.GetUserDataSet(txtUserName.Text);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtFullName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0]["mail"].ToString();


                            return true;
                        }
                        else
                        {
                            Alert("Bad username, please input valid username...");
                            return false;
                        }
                        //}
                        //else
                        //{
                        //    // Just Verified this if user refer to not to activate
                        //    return true;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Object reference not set to an instance of an object"))
                {
                    Alert("Bad User Name, User Not Exists");
                    return false;
                }
                else
                    throw ex;
            }
        }

        /// <summary>
        /// Function to set page title
        /// </summary>
        //private void SetTitle()
        //{
        //    try
        //    {
        //        if (qs_iViewDetail > 0)
        //        {
        //            divTitle.InnerText = ".:: View Detail ::.";
        //        }
        //        else if (qs_iApprovalID > 0)
        //        {
        //            divTitle.InnerText = ".:: Approval User Request Information ::.";
        //        }
        //        else if ((qs_iUserID > 0) || (qs_iUserID == -1))
        //        {
        //            divTitle.InnerText = ".:: User Input ::.";
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

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
