using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using SO.BusinessLogicLayer;
using SO.BusinessLogicLayer.Constanta;
using SO.BusinessLogicLayer.Enumeration;

namespace SO
{
    public partial class Home : PFSBasePage
    {
        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                if (!IsPostBack)
                {
                    int? iBranch = null;

                    Response.Cache.SetNoStore();
                    Response.Cache.SetAllowResponseInBrowserHistory(false);
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);

                    #region Access Right

                    #region Security

                    mnuUser.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_USR_READ.ToString());
                    mnuGroup.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_GRP_READ.ToString());
                    mnuAuditTrails.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_AUD_READ.ToString());

                    if (mnuUser.Visible
                        || mnuGroup.Visible
                        || mnuAuditTrails.Visible)
                        mnuSecurity.Visible = true;
                    else
                        mnuSecurity.Visible = false;

                    #endregion

                    #region Preferences

                    mnuParameter.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.PRE_SYS_PARAM_READ.ToString());
                    mnuConditionAndMatrix.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.PRE_CON_MATRIX_READ.ToString());

                    if (mnuParameter.Visible
                        || mnuConditionAndMatrix.Visible)
                        mnuPreferences.Visible = true;
                    else
                        mnuPreferences.Visible = false;

                    #endregion

                    #region Master

                    mnuExceptionForm.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.MST_EXC_READ.ToString());
                    mnuProduct.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.MST_PRD_READ.ToString());

                    if (mnuExceptionForm.Visible
                        || mnuProduct.Visible)
                        mnuMaster.Visible = true;
                    else
                        mnuMaster.Visible = false;

                    #endregion

                    #region Transaction
                    mnuManualUpload.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.MNL_UPLOAD_READ.ToString());
                    mnuProductChecking.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.PROD_CHECK_ACTION.ToString());
                    mnuProductOffering.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.PROD_OFFER_ACTION.ToString());

                    if (mnuManualUpload.Visible
                        || mnuProductChecking.Visible
                        || mnuProductOffering.Visible)
                        mnuTransaction.Visible = true;
                    else
                        mnuTransaction.Visible = false;

                    #endregion

                    #region Approval Log

                    mnuApprovalLog.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.APP_LOG_READ.ToString());

                    if (mnuApprovalLog.Visible)
                        mnuParentApproval.Visible = true;
                    else
                        mnuParentApproval.Visible = false;

                    #endregion

                    #region Report

                    mnuReporting.Visible = mnuSubReporting.Visible =
                        (Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_HISTORY_TRANSACION_VIEW.ToString()) ||
                        Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_RISK_EXPIRY_VIEW.ToString()) ||
                        Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_RISK_CHANGES_VIEW.ToString()) ||
                        Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_EXEPTION_LIST_VIEW.ToString()) ||
                        Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_FNA_EXCEPTION_VIEW.ToString()) ||
                        Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_LEVEL_EXCEPTION_VIEW.ToString()) ||
                        Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_RISK_MISSMATCH_VIEW.ToString()));

                    #endregion

                    #region Sales Order

                    #endregion

                    #endregion

                    if (!Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.REPORT_VIEW_ALL_BRANCH_VIEW.ToString()))
                    {
                        int iUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        UserDetailCollection oUserDetailCollection = new UserDetailCollection();
                        oUserDetailCollection.DAL_LoadByUserID(iUserID);

                        if (oUserDetailCollection.Count > 0)
                        {
                            Branch oBranch = new Branch();
                            oBranch.DAL_LoadByBranchCode(oUserDetailCollection[0].BranchCode);
                            iBranch = oBranch.BranchID;
                        }
                    }
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void lsLogout_OnLoggingOut(object sender, LoginCancelEventArgs e)
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
}