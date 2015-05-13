using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFSHelper.BusinessLogicLayer;
using System.Web;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace SO.BusinessLogicLayer
{
    public partial class ApprovalLog
    {
        #region Region : Partial Member Variables
        protected string m_sCreateByUserName = string.Empty;
        protected int m_iModuleObjectID = -1;
        protected string m_sObjectName = string.Empty;
        protected int m_iModuleID = -1;
        protected string m_sModuleName = string.Empty;
        protected string m_sApprovalStatusName;
        protected string m_sUpdateByUserName = string.Empty;
        protected string m_sCreateByFullUserName = string.Empty;
        #endregion

        #region Region : Partial Properties
        public string CreateByUserName
        {
            get { return m_sCreateByUserName; }
            set { m_sCreateByUserName = value; }
        }
        public string CreateByFullUserName
        {
            get { return m_sCreateByFullUserName; }
            set { m_sCreateByFullUserName = value; }
        }
        public int ModuleObjectID
        {
            get { return m_iModuleObjectID; }
            set { m_iModuleObjectID = value; }
        }
        public string ObjectName
        {
            get { return m_sObjectName; }
            set { m_sObjectName = value; }
        }
        public int ModuleID
        {
            get { return m_iModuleID; }
            set { m_iModuleID = value; }
        }
        public string ModuleName
        {
            get { return m_sModuleName; }
            set { m_sModuleName = value; }
        }
        public string ApprovalStatusName
        {
            get
            {
                string sStatusName;
                switch (m_sApprovalStatusCode)
                {
                    case "APPROVE":
                        sStatusName = "APPROVED";
                        break;
                    case "PENDING":
                        sStatusName = "PENDING";
                        break;
                    case "REJECT":
                        sStatusName = "REJECTED";
                        break;
                    case "CANCEL":
                        sStatusName = "CANCELLED";
                        break;
                    default:
                        sStatusName = string.Empty;
                        break;
                }
                return sStatusName;
            }
        }
        public string UpdateByUserName
        {
            get { return m_sUpdateByUserName; }
            set { m_sUpdateByUserName = value; }
        }
        #endregion

        #region Region : Partial Methods
        /// <summary>
        /// Refer to SP : "uspCOM_ApprovalLogGetWithModuleObject"
        /// </summary>
        /// <returns></returns>
        public bool DAL_LoadWithWithModuleObject()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drApprovalLog = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogGetWithModuleObject", m_iApprovalLogID))
                {
                    if (drApprovalLog.Read())
                    {
                        m_iApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                        m_iRefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                        m_iModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                        m_iApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                        m_dtCreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                        m_dtUpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                        m_sCreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                        m_iUpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                        m_xmlDetail = Convert.ToString(drApprovalLog["DETAIL"]);
                        m_sRemark = Convert.ToString(drApprovalLog["REMARK"]);
                        m_sMemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                        m_sMemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                        m_iModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                        m_sObjectName = Convert.ToString(drApprovalLog["object_name"]);
                        m_iModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                        m_sModuleName = Convert.ToString(drApprovalLog["module_name"]);
                        m_sApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                        m_sCreateByFullUserName = Convert.ToString(drApprovalLog["FULL_NAME"]);
                        m_xmlPreviousDetail = Convert.ToString(drApprovalLog["PREVIOUS_DETAIL"]);
                        bIsSuccess = true;
                    }
                }
                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadForDashboardCustomerRejectedRegistration(int m_iCustomerRegistrationID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drApprovalLog = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogGetForDashboardCustomerRejectedRegistration", m_iCustomerRegistrationID))
                {
                    if (drApprovalLog.Read())
                    {
                        m_iApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                        m_iRefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                        m_iModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                        m_iApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                        m_dtCreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                        m_dtUpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                        m_sCreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                        m_iUpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                        m_xmlDetail = Convert.ToString(drApprovalLog["DETAIL"]);
                        m_sRemark = Convert.ToString(drApprovalLog["REMARK"]);
                        m_sMemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                        m_sMemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                        m_iModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                        m_sObjectName = Convert.ToString(drApprovalLog["object_name"]);
                        m_iModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                        m_sModuleName = Convert.ToString(drApprovalLog["module_name"]);
                        m_sApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                        m_sCreateByFullUserName = Convert.ToString(drApprovalLog["FULL_NAME"]);
                        m_sUpdateByUserName = Convert.ToString(drApprovalLog["update_by_user_name"]);
                        bIsSuccess = true;
                    }
                }
                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadToGetDuplicateContent(string sObjectParent, string sObjectChild, string sObjectComparer, int iModuleObjectMemberID, object iApprovalLogID)
        {
            try
            {
                int iExist = Convert.ToInt32(SqlHelper.ExecuteScalar(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogGetToGetDuplicateContent",
                       sObjectParent,
                   sObjectChild,
                   sObjectComparer,
                   iModuleObjectMemberID,
                   iApprovalLogID
               ));
                if (iExist == 0) return false;
                else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadToGetDuplicateDateContent(string sObjectParent, string sObjectChildStartDate, string sObjectChildEndDate, string sObjectComparer, int iModuleObjectMemberID, object iApprovalLogID)
        {
            try
            {
                int iExist = Convert.ToInt32(SqlHelper.ExecuteScalar(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogGetToGetDuplicateDateContent",
                       sObjectParent,
                   sObjectChildStartDate,
                   sObjectChildEndDate,
                   sObjectComparer,
                   iModuleObjectMemberID,
                   iApprovalLogID
               ));
                if (iExist == 0) return false;
                else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Approve()
        {
            SqlConnection oConn = PFSHelper.DataAccessLayer.PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = false;
                bIsSuccess = Approve(oTrans);
                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw (ex);
            }
            finally
            {
                PFSHelper.DataAccessLayer.PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool Approve(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iApprovalLogID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspCOM_ApprovalLogUpdate",
                    m_iApprovalLogID,
                                        m_iRefID,
                                        m_iModuleObjectMemberID,
                                        (int)Enumeration.SOEnumeration.ApprovalStatus.APPROVE,
                                        m_dtCreateDate,
                                        m_dtUpdateDate,
                                        m_iCreateByUserID,
                                        m_iUpdateByUserID,
                                        m_xmlDetail,
                                        m_sRemark,
                                        m_xmlPreviousDetail
                    ));
                    bIsSuccess = (iError == 0);
                }
                return (bIsSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddApprovalLog()
        {
            SqlConnection oConn = PFSHelper.DataAccessLayer.PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = false;
                bIsSuccess = AddApprovalLog(oTrans);
                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw (ex);
            }
            finally
            {
                PFSHelper.DataAccessLayer.PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool AddApprovalLog(SqlTransaction p_oTrans)
        {
            try
            {
                m_iApprovalLogID = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspCOM_ApprovalLogAdd",
                    m_iRefID,
                    m_iModuleObjectMemberID,
                    (int)Enumeration.SOEnumeration.ApprovalStatus.PENDING,
                    m_dtCreateDate,
                    m_dtUpdateDate,
                    m_iCreateByUserID,
                    m_iUpdateByUserID,
                    m_xmlDetail,
                    m_sRemark,
                    m_xmlPreviousDetail
                    ));

                bool bIsSuccess = (m_iApprovalLogID >= 0);


                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Reject()
        {
            SqlConnection oConn = PFSHelper.DataAccessLayer.PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = false;
                bIsSuccess = Reject(oTrans);
                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw (ex);
            }
            finally
            {
                PFSHelper.DataAccessLayer.PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool Reject(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iApprovalLogID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspCOM_ApprovalLogUpdate",
                    m_iApprovalLogID,
                                        m_iRefID,
                                        m_iModuleObjectMemberID,
                                        (int)Enumeration.SOEnumeration.ApprovalStatus.REJECT,
                                        m_dtCreateDate,
                                        m_dtUpdateDate,
                                        m_iCreateByUserID,
                                        m_iUpdateByUserID,
                                        m_xmlDetail,
                                        m_sRemark,
                                        m_xmlPreviousDetail
                    ));
                    bIsSuccess = (iError == 0);
                }
                return (bIsSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Close()
        {
            SqlConnection oConn = PFSHelper.DataAccessLayer.PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = false;
                bIsSuccess = Close(oTrans);
                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw (ex);
            }
            finally
            {
                PFSHelper.DataAccessLayer.PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool Close(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iApprovalLogID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspCOM_ApprovalLogUpdate",
                    m_iApprovalLogID,
                                        m_iRefID,
                                        m_iModuleObjectMemberID,
                                        (int)Enumeration.SOEnumeration.ApprovalStatus.CANCEL,
                                        m_dtCreateDate,
                                        DateTime.Now,
                                        m_iCreateByUserID,
                                        ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID,
                                        m_xmlDetail,
                                        m_sRemark,
                                        m_xmlPreviousDetail
                    ));
                    bIsSuccess = (iError == 0);
                }
                return (bIsSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
