using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

#region Region: Revision History///////////////////////////////////////////////////////////////
// Copyright (c) 2011, PT. Profescipta Wahanatehnik. All Rights Reserved.
//
// This software, all associated documentation, and all copies
// are CONFIDENTIAL INFORMATION of PT. Profescipta Wahanatehnik. 
// http://www.profescipta.com
//
// $Workfile:$
// $Revision:$
// $Date:$
//
// DESCRIPTION
//
// $Log:$
//
#endregion

namespace PFSHelper.BusinessLogicLayer
{

    public partial class Group
    {

        #region Region : Partial Module Object Fields
        protected ModuleObjectMemberGroupCollection m_oGroupMemberCollection = null;
        protected int m_iModuleID;
        protected int m_iModuleObjectID;
        protected int m_iModuleObjectMemberID;
        protected string m_sModuleCode;
        protected string m_sModuleName;
        protected string m_sModuleDescription;
        protected string m_sUpdateByUsername = string.Empty;
        protected string m_sCreateByUsername = string.Empty;
        protected int m_iTotalUser;

        #endregion

        #region Region : Partial Module Object Properties
        public int ModuleID
        {
            get { return m_iModuleID; }
            set { m_iModuleID = value; }
        }
        public int ModuleObjectID
        {
            get { return m_iModuleObjectID; }
            set { m_iModuleObjectID = value; }
        }
        public int ModuleObjectMemberID
        {
            get { return m_iModuleObjectMemberID; }
            set { m_iModuleObjectMemberID = value; }
        }
        public string ModuleCode
        {
            get { return m_sModuleCode; }
            set { m_sModuleCode = value; }
        }
        public string ModuleName
        {
            get { return m_sModuleName; }
            set { m_sModuleName = value; }
        }
        public string ModuleDescription
        {
            get { return m_sModuleDescription; }
            set { m_sModuleDescription = value; }
        }
        public string CreateByUsername
        {
            get { return m_sCreateByUsername; }
            set { m_sCreateByUsername = value; }
        }
        public string UpdateByUsername
        {
            get { return m_sUpdateByUsername; }
            set { m_sUpdateByUsername = value; }
        }
        public int TotalUser
        {
            get { return m_iTotalUser; }
            set { m_iTotalUser = value; }
        }
        public ModuleObjectMemberGroupCollection GroupMemberCollection
        {
            get { return m_oGroupMemberCollection; }
            set { m_oGroupMemberCollection = value; }
        }
        #endregion

        #region " Group Access Method"
        public bool DAL_LoadWithGroupMember()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drGroup = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_GroupGetWithTotalUser", m_iGroupID))
                {
                    if (drGroup.Read())
                    {
                        m_iGroupID = Convert.ToInt32(drGroup["PFS_GROUP_ID"]);
                        m_sGroupName = Convert.ToString(drGroup["GROUP_NAME"]);
                        m_sGroupDescr = Convert.ToString(drGroup["GROUP_DESCR"]);
                        m_bIsActive = Convert.ToBoolean(drGroup["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(drGroup["IS_NEED_APPROVAL"]);
                        m_dtCreateDate = Convert.ToDateTime(drGroup["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drGroup["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(drGroup["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(drGroup["UPDATE_BY_USER_ID"]);
                        m_sCreateByUsername = Convert.ToString(drGroup["CREATE_BY_USERNAME"]);
                        m_sUpdateByUsername = Convert.ToString(drGroup["UPDATE_BY_USERNAME"]);
                        m_iTotalUser = Convert.ToInt32(drGroup["TOTAL_USER"]);
                        m_oGroupMemberCollection.DAL_LoadByGroupID(m_iGroupID);
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
        public bool DAL_LoadByGroupName(string sGroupName, object iGroupID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drGroup = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_GroupGetByGroupName", sGroupName, iGroupID))
                {
                    if (drGroup.Read())
                    {
                        m_iGroupID = Convert.ToInt32(drGroup["PFS_GROUP_ID"]);
                        m_sGroupName = Convert.ToString(drGroup["GROUP_NAME"]);
                        m_sGroupDescr = Convert.ToString(drGroup["GROUP_DESCR"]);
                        m_bIsActive = Convert.ToBoolean(drGroup["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(drGroup["IS_NEED_APPROVAL"]);
                        m_dtCreateDate = Convert.ToDateTime(drGroup["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drGroup["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(drGroup["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(drGroup["UPDATE_BY_USER_ID"]);
                        m_sCreateByUsername = Convert.ToString(drGroup["CREATE_BY_USERNAME"]);
                        m_sUpdateByUsername = Convert.ToString(drGroup["UPDATE_BY_USERNAME"]);
                        m_iTotalUser = Convert.ToInt32(drGroup["TOTAL_USER"]);
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
        public bool DAL_LoadWithTotalUser()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drGroup = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_GroupGetWithTotalUser", m_iGroupID))
                {
                    if (drGroup.Read())
                    {
                        m_iGroupID = Convert.ToInt32(drGroup["PFS_GROUP_ID"]);
                        m_sGroupName = Convert.ToString(drGroup["GROUP_NAME"]);
                        m_sGroupDescr = Convert.ToString(drGroup["GROUP_DESCR"]);
                        m_bIsActive = Convert.ToBoolean(drGroup["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(drGroup["IS_NEED_APPROVAL"]);
                        m_dtCreateDate = Convert.ToDateTime(drGroup["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drGroup["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(drGroup["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(drGroup["UPDATE_BY_USER_ID"]);
                        m_sCreateByUsername = Convert.ToString(drGroup["CREATE_BY_USERNAME"]);
                        m_sUpdateByUsername = Convert.ToString(drGroup["UPDATE_BY_USERNAME"]);
                        m_iTotalUser = Convert.ToInt32(drGroup["TOTAL_USER"]);
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

        // Load Module List
        public SqlDataReader GetModule()
        {
            try
            {
                SqlDataReader objReader;
                objReader = SqlHelper.ExecuteReader(PFSDataBaseAccess.
                    ConnectionString, "uspPFS_ModuleListOrderByIndexOrder",null
                    );
                return objReader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Load Module Object by Modul
        public SqlDataReader GetModuleObject(object p_iModuleID)
        {
            try
            {
                SqlDataReader objReader;
                objReader = SqlHelper.ExecuteReader(PFSDataBaseAccess.
                    ConnectionString, "uspPFS_ModuleObjectListByModuleID", 
                    p_iModuleID
                    );
                return objReader;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Load Module Object Member by Module Object and group access
        public SqlDataReader GetModuleObjectMember(int p_iGroupID, int p_iModuleObjectID)
        {
            try
            {
                SqlDataReader objReader;
                objReader = SqlHelper.ExecuteReader(PFSDataBaseAccess.
                    ConnectionString, "uspPFS_ModuleObjectMemberListByGroupID",
                    p_iGroupID,
                    p_iModuleObjectID
                    );
                return objReader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REFER TO SP -> uspPFS_ModuleObjectMemberGroupAdd
        /// </summary>
        /// <returns>True if insert is success and false if failed</returns>
        public bool GroupAccessInsert()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = GroupAccessInsert(oTrans);
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
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        /// <summary>
        /// REFER TO SP -> uspPFS_ModuleObjectMemberGroupAdd
        /// </summary>
        /// <returns>True if insert is success and false if failed</returns>
        public bool GroupAccessInsert(SqlTransaction oTrans)
        {
            try
            {
                int iRowAffected = SqlHelper.ExecuteNonQuery(oTrans, "uspPFS_ModuleObjectMemberGroupAdd",
                    m_iModuleID,
                    m_iModuleObjectID,
                    m_iModuleObjectMemberID,
                    m_iGroupID
                    );

                return iRowAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REFER TO SP -> "uspPFS_ModuleObjectMemberGroupDeleteByGroupID"
        /// </summary>
        /// <param name="p_arrModuleObjectMemberID">PFS_Module_Object_Member_ID Value</param>
        /// <returns>True if Delete is success and False if failed</returns>
        public bool GroupAccessDelete(string p_arrModuleObjectMemberID)
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = GroupAccessDelete(p_arrModuleObjectMemberID,oTrans);
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
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        /// <summary>
        /// REFER TO SP -> "uspPFS_ModuleObjectMemberGroupDeleteByGroupID"
        /// </summary>
        /// <param name="p_arrModuleObjectMemberID">PFS_Module_Object_Member_ID Value</param>
        /// <returns>True if Delete is success and False if failed</returns>
        public bool GroupAccessDelete(string p_arrModuleObjectMemberID,SqlTransaction p_oTrans)
        {
            try
            {
                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_ModuleObjectMemberGroupDeleteByGroupID",
                    p_arrModuleObjectMemberID,
                    m_iGroupID
                    );

                return iRowAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REFER TO SP : uspPFS_GroupUpdateByApprovalStatus
        /// </summary>
        /// <param name="bIsNeedApproval">Approval Status</param>
        /// <returns>True if Transaction success, false if Transaction failed</returns>
        public bool UpdateApprovalStatus(bool bIsNeedApproval)
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = UpdateApprovalStatus(oTrans, bIsNeedApproval);

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
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        /// <summary>
        /// REFER TO SP : uspPFS_GroupUpdateByApprovalStatus
        /// </summary>
        /// <param name="p_oTrans">SQL Transaction</param>
        /// <param name="bIsNeedApproval">Approval Status</param>
        /// <returns>True if Transaction success, false if Transaction failed</returns>
        public bool UpdateApprovalStatus(SqlTransaction p_oTrans, bool bIsNeedApproval)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iGroupID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_GroupUpdateByApprovalStatus",
                        m_iGroupID,
                        bIsNeedApproval,
                        m_dtUpdateDate,
                        m_iUpdateByUserID
                    ));
                    bIsSuccess = (iError == 0);
                }
                else
                {
                    bIsSuccess = DAL_Add(p_oTrans);
                }
                return (bIsSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// REFER TO SP : uspPFS_GroupUpdateByRejection
        /// </summary>
        /// <param name="bIsNeedApproval">Approval Status</param>
        /// <returns>True if Transaction success, false if Transaction failed</returns>
        public bool RejectApprovalRequest()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = RejectApprovalRequest(oTrans);

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
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        /// <summary>
        /// REFER TO SP : uspPFS_GroupUpdateByRejection
        /// </summary>
        /// <param name="p_oTrans">SQL Transaction</param>
        /// <param name="bIsNeedApproval">Approval Status</param>
        /// <returns>True if Transaction success, false if Transaction failed</returns>
        public bool RejectApprovalRequest(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;

                int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_GroupUpdateByRejection",
                    m_iGroupID
                ));

                bIsSuccess = (iError == 0);

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
