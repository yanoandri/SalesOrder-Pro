using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFSHelper.BusinessLogicLayer;

namespace SO.BusinessLogicLayer
{
    public partial class ApprovalLogCollection
    {
        #region Region Data Access Layer
        public bool DAL_LoadWithCreateByName(
                        string sKeyWords,
                        object iRefID,
                        object iModuleObjectID,
                        object iModuleObjectMemberID,
                        object iApprovalStatusID,
                        object dtCreateDateFrom,
                        object dtCreateDateTo,
                        object dtUpdateDateFrom,
                        object dtUpdateDateTo,
                        object iCreateByUserID,
                        object iUpdateByUserID,
                        object iCurrentUserID
                        )
        {
            try
            {

                using (System.Data.SqlClient.SqlDataReader drApprovalLog = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogListWithModuleObject",
                    sKeyWords,
                    iRefID,
                    iModuleObjectID,
                    iModuleObjectMemberID,
                    iApprovalStatusID,
                    dtCreateDateFrom,
                    dtCreateDateTo,
                    dtUpdateDateFrom,
                    dtUpdateDateTo,
                    iCreateByUserID,
                    iUpdateByUserID,
                    iCurrentUserID
                    ))
                {
                    if (drApprovalLog.HasRows)
                    {
                        while (drApprovalLog.Read())
                        {
                            ApprovalLog oApprovalLog = new ApprovalLog();
                            oApprovalLog.ApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                            oApprovalLog.RefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                            oApprovalLog.ModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oApprovalLog.ApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                            oApprovalLog.CreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                            oApprovalLog.UpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                            oApprovalLog.CreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                            oApprovalLog.CreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                            oApprovalLog.UpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                            oApprovalLog.UpdateByUserName = Convert.ToString(drApprovalLog["UPDATE_BY_USER_NAME"]);
                            //oApprovalLog.Detail = Convert.ToString(drApprovalLog["DETAIL"]);
                            oApprovalLog.Remark = Convert.ToString(drApprovalLog["REMARK"]);
                            oApprovalLog.MemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                            oApprovalLog.MemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                            oApprovalLog.ModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                            oApprovalLog.ObjectName = Convert.ToString(drApprovalLog["object_name"]);
                            oApprovalLog.ModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                            oApprovalLog.ModuleName = Convert.ToString(drApprovalLog["module_name"]);
                            oApprovalLog.ApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                            this.Add(oApprovalLog);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadPendingByUser()
        {
            try
            {
                using (System.Data.SqlClient.SqlDataReader drApprovalLog = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogListPendingByUser",
                    ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID))
                {
                    if (drApprovalLog.HasRows)
                    {
                        while (drApprovalLog.Read())
                        {
                            ApprovalLog oApprovalLog = new ApprovalLog();
                            oApprovalLog.ApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                            oApprovalLog.RefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                            oApprovalLog.ModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oApprovalLog.ApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                            oApprovalLog.CreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                            oApprovalLog.UpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                            oApprovalLog.CreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                            oApprovalLog.CreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                            oApprovalLog.UpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                            //oApprovalLog.Detail = Convert.ToString(drApprovalLog["DETAIL"]);
                            oApprovalLog.Remark = Convert.ToString(drApprovalLog["REMARK"]);
                            oApprovalLog.MemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                            oApprovalLog.MemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                            oApprovalLog.ModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                            oApprovalLog.ObjectName = Convert.ToString(drApprovalLog["object_name"]);
                            oApprovalLog.ModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                            oApprovalLog.ModuleName = Convert.ToString(drApprovalLog["module_name"]);
                            oApprovalLog.ApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                            this.Add(oApprovalLog);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadApproved()
        {
            try
            {
                using (System.Data.SqlClient.SqlDataReader drApprovalLog = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogListApproved",
                    ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID))
                {
                    if (drApprovalLog.HasRows)
                    {
                        while (drApprovalLog.Read())
                        {
                            ApprovalLog oApprovalLog = new ApprovalLog();
                            oApprovalLog.ApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                            oApprovalLog.RefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                            oApprovalLog.ModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oApprovalLog.ApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                            oApprovalLog.CreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                            oApprovalLog.UpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                            oApprovalLog.CreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                            oApprovalLog.CreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                            oApprovalLog.UpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                            //oApprovalLog.Detail = Convert.ToString(drApprovalLog["DETAIL"]);
                            oApprovalLog.Remark = Convert.ToString(drApprovalLog["REMARK"]);
                            oApprovalLog.MemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                            oApprovalLog.MemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                            oApprovalLog.ModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                            oApprovalLog.ObjectName = Convert.ToString(drApprovalLog["object_name"]);
                            oApprovalLog.ModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                            oApprovalLog.ModuleName = Convert.ToString(drApprovalLog["module_name"]);
                            oApprovalLog.ApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                            this.Add(oApprovalLog);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadRejected()
        {
            try
            {

                using (System.Data.SqlClient.SqlDataReader drApprovalLog = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogListRejected",
                    ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID))
                {
                    if (drApprovalLog.HasRows)
                    {
                        while (drApprovalLog.Read())
                        {
                            ApprovalLog oApprovalLog = new ApprovalLog();
                            oApprovalLog.ApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                            oApprovalLog.RefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                            oApprovalLog.ModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oApprovalLog.ApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                            oApprovalLog.CreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                            oApprovalLog.UpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                            oApprovalLog.CreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                            oApprovalLog.CreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                            oApprovalLog.UpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                            //oApprovalLog.Detail = Convert.ToString(drApprovalLog["DETAIL"]);
                            oApprovalLog.Remark = Convert.ToString(drApprovalLog["REMARK"]);
                            oApprovalLog.MemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                            oApprovalLog.MemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                            oApprovalLog.ModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                            oApprovalLog.ObjectName = Convert.ToString(drApprovalLog["object_name"]);
                            oApprovalLog.ModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                            oApprovalLog.ModuleName = Convert.ToString(drApprovalLog["module_name"]);
                            oApprovalLog.ApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                            this.Add(oApprovalLog);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadNeedApproval()
        {
            try
            {

                using (System.Data.SqlClient.SqlDataReader drApprovalLog = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogListNeedApproval",
                    ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID))
                {
                    if (drApprovalLog.HasRows)
                    {
                        while (drApprovalLog.Read())
                        {
                            ApprovalLog oApprovalLog = new ApprovalLog();
                            oApprovalLog.ApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                            oApprovalLog.RefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                            oApprovalLog.ModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oApprovalLog.ApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                            oApprovalLog.CreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                            oApprovalLog.UpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                            oApprovalLog.CreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                            oApprovalLog.CreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                            oApprovalLog.UpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                            //oApprovalLog.Detail = Convert.ToString(drApprovalLog["DETAIL"]);
                            oApprovalLog.Remark = Convert.ToString(drApprovalLog["REMARK"]);
                            oApprovalLog.MemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                            oApprovalLog.MemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                            oApprovalLog.ModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                            oApprovalLog.ObjectName = Convert.ToString(drApprovalLog["object_name"]);
                            oApprovalLog.ModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                            oApprovalLog.ModuleName = Convert.ToString(drApprovalLog["module_name"]);
                            oApprovalLog.ApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                            this.Add(oApprovalLog);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadApprovedByUser()
        {
            try
            {

                using (System.Data.SqlClient.SqlDataReader drApprovalLog = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogListApprovedByUser",
                    ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID))
                {
                    if (drApprovalLog.HasRows)
                    {
                        while (drApprovalLog.Read())
                        {
                            ApprovalLog oApprovalLog = new ApprovalLog();
                            oApprovalLog.ApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                            oApprovalLog.RefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                            oApprovalLog.ModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oApprovalLog.ApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                            oApprovalLog.CreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                            oApprovalLog.UpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                            oApprovalLog.CreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                            oApprovalLog.CreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                            oApprovalLog.UpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                            //oApprovalLog.Detail = Convert.ToString(drApprovalLog["DETAIL"]);
                            oApprovalLog.Remark = Convert.ToString(drApprovalLog["REMARK"]);
                            oApprovalLog.MemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                            oApprovalLog.MemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                            oApprovalLog.ModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                            oApprovalLog.ObjectName = Convert.ToString(drApprovalLog["object_name"]);
                            oApprovalLog.ModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                            oApprovalLog.ModuleName = Convert.ToString(drApprovalLog["module_name"]);
                            oApprovalLog.ApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                            this.Add(oApprovalLog);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadRejectedByUser()
        {
            try
            {

                using (System.Data.SqlClient.SqlDataReader drApprovalLog = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogListRejectedByUser",
                    ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID))
                {
                    if (drApprovalLog.HasRows)
                    {
                        while (drApprovalLog.Read())
                        {
                            ApprovalLog oApprovalLog = new ApprovalLog();
                            oApprovalLog.ApprovalLogID = Convert.ToInt32(drApprovalLog["COM_APPROVAL_LOG_ID"]);
                            oApprovalLog.RefID = Convert.ToInt32(drApprovalLog["REF_ID"]);
                            oApprovalLog.ModuleObjectMemberID = Convert.ToInt32(drApprovalLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oApprovalLog.ApprovalStatusID = Convert.ToInt16(drApprovalLog["COM_APPROVAL_STATUS_ID"]);
                            oApprovalLog.CreateDate = Convert.ToDateTime(drApprovalLog["CREATE_DATE"]);
                            oApprovalLog.UpdateDate = Convert.ToDateTime(drApprovalLog["UPDATE_DATE"]);
                            oApprovalLog.CreateByUserID = Convert.ToInt32(drApprovalLog["CREATE_BY_USER_ID"]);
                            oApprovalLog.CreateByUserName = Convert.ToString(drApprovalLog["CREATE_BY_USER_NAME"]);
                            oApprovalLog.UpdateByUserID = Convert.ToInt32(drApprovalLog["UPDATE_BY_USER_ID"]);
                            //oApprovalLog.Detail = Convert.ToString(drApprovalLog["DETAIL"]);
                            oApprovalLog.Remark = Convert.ToString(drApprovalLog["REMARK"]);
                            oApprovalLog.MemberCode = Convert.ToString(drApprovalLog["MEMBER_CODE"]);
                            oApprovalLog.MemberName = Convert.ToString(drApprovalLog["MEMBER_NAME"]);
                            oApprovalLog.ModuleObjectID = Convert.ToInt32(drApprovalLog["pfs_module_object_id"]);
                            oApprovalLog.ObjectName = Convert.ToString(drApprovalLog["object_name"]);
                            oApprovalLog.ModuleID = Convert.ToInt32(drApprovalLog["pfs_module_id"]);
                            oApprovalLog.ModuleName = Convert.ToString(drApprovalLog["module_name"]);
                            oApprovalLog.ApprovalStatusCode = Convert.ToString(drApprovalLog["COM_APPROVAL_STATUS_CODE"]);
                            this.Add(oApprovalLog);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion

        public int IndexOf(ApprovalLog p_oApproval)
        {
            return m_oApprovalLogList.IndexOf(p_oApproval);
        }

    }
}
