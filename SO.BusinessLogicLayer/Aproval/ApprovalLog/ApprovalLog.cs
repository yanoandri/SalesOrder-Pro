using System;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

#region Region: Revision History///////////////////////////////////////////////////////////////
// Copyright (c) 2013, PT. Profescipta Wahanatehnik. All Rights Reserved.
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

namespace SO.BusinessLogicLayer
{
    //Standard class autogenerated by PFS Generator v5.1
    public partial class ApprovalLog
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        protected long m_iApprovalLogID = 0;
        protected int m_iRefID = 0;
        protected int m_iModuleObjectMemberID = 0;
        protected short m_iApprovalStatusID = 0;
        protected DateTime m_dtCreateDate = DateTime.Parse("01/01/1900");
        protected DateTime m_dtUpdateDate = DateTime.Parse("01/01/1900");
        protected int m_iCreateByUserID = 0;
        protected int m_iUpdateByUserID = 0;
        protected string m_xmlDetail;
        protected string m_sRemark = "NONE";
        protected string m_xmlPreviousDetail;
        protected string m_sMemberCode = "NONE";
        protected string m_sMemberName = "NONE";
        protected string m_sApprovalStatusCode = "NONE";
        #endregion

        #region Region: Constructor////////////////////////////////////////////////////////////
        public ApprovalLog()
        {
            m_iApprovalLogID = -1;
        }
        public ApprovalLog(long iID)
        {
            m_iApprovalLogID = iID;
        }
        public ApprovalLog(
            long iApprovalLogID,
            int iRefID,
            int iModuleObjectMemberID,
            short iApprovalStatusID,
            DateTime dtCreateDate,
            DateTime dtUpdateDate,
            int iCreateByUserID,
            int iUpdateByUserID,
            string xmlDetail,
            string sRemark,
            string xmlPreviousDetail
        )
        {
            m_iApprovalLogID = iApprovalLogID;
            m_iRefID = iRefID;
            m_iModuleObjectMemberID = iModuleObjectMemberID;
            m_iApprovalStatusID = iApprovalStatusID;
            m_dtCreateDate = dtCreateDate;
            m_dtUpdateDate = dtUpdateDate;
            m_iCreateByUserID = iCreateByUserID;
            m_iUpdateByUserID = iUpdateByUserID;
            m_xmlDetail = xmlDetail;
            m_sRemark = sRemark;
            m_xmlPreviousDetail = xmlPreviousDetail;
        }
        #endregion

        #region Region: Properties/////////////////////////////////////////////////////////////
        public long ApprovalLogID
        {
            get { return m_iApprovalLogID; }
            set { m_iApprovalLogID = value; }
        }
        public int RefID
        {
            get { return m_iRefID; }
            set { m_iRefID = value; }
        }
        public int ModuleObjectMemberID
        {
            get { return m_iModuleObjectMemberID; }
            set { m_iModuleObjectMemberID = value; }
        }
        public short ApprovalStatusID
        {
            get { return m_iApprovalStatusID; }
            set { m_iApprovalStatusID = value; }
        }
        public DateTime CreateDate
        {
            get { return m_dtCreateDate; }
            set { m_dtCreateDate = value; }
        }
        public DateTime UpdateDate
        {
            get { return m_dtUpdateDate; }
            set { m_dtUpdateDate = value; }
        }
        public int CreateByUserID
        {
            get { return m_iCreateByUserID; }
            set { m_iCreateByUserID = value; }
        }
        public int UpdateByUserID
        {
            get { return m_iUpdateByUserID; }
            set { m_iUpdateByUserID = value; }
        }
        public string Detail
        {
            get { return m_xmlDetail; }
            set { m_xmlDetail = value; }
        }
        public string Remark
        {
            get { return m_sRemark; }
            set { m_sRemark = value; }
        }
        public string PreviousDetail
        {
            get { return m_xmlPreviousDetail; }
            set { m_xmlPreviousDetail = value; }
        }
        public string MemberCode
        {
            get { return m_sMemberCode; }
            set { m_sMemberCode = value; }
        }
        public string MemberName
        {
            get { return m_sMemberName; }
            set { m_sMemberName = value; }
        }
        public string ApprovalStatusCode
        {
            get { return m_sApprovalStatusCode; }
            set { m_sApprovalStatusCode = value; }
        }
        #endregion

        #region Region: Data Access Methods////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogGet", m_iApprovalLogID))
                {
                    if (dr.Read())
                    {
                        m_iApprovalLogID = Convert.ToInt64(dr["COM_APPROVAL_LOG_ID"]);
                        m_iRefID = Convert.ToInt32(dr["REF_ID"]);
                        m_iModuleObjectMemberID = Convert.ToInt32(dr["PFS_MODULE_OBJECT_MEMBER_ID"]);
                        m_iApprovalStatusID = Convert.ToInt16(dr["COM_APPROVAL_STATUS_ID"]);
                        m_dtCreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                        m_dtUpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                        m_iUpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
                        m_xmlDetail = Convert.ToString(dr["DETAIL"]);
                        m_sRemark = Convert.ToString(dr["REMARK"]);
                        m_xmlPreviousDetail = Convert.ToString(dr["PREVIOUS_DETAIL"]);
                        m_sMemberCode = Convert.ToString(dr["MEMBER_CODE"]);
                        m_sMemberName = Convert.ToString(dr["MEMBER_NAME"]);
                        m_sApprovalStatusCode = Convert.ToString(dr["COM_APPROVAL_STATUS_CODE"]);
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
        public bool DAL_Load(int iID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogGet", iID))
                {
                    if (dr.Read())
                    {
                        m_iApprovalLogID = Convert.ToInt64(dr["COM_APPROVAL_LOG_ID"]);
                        m_iRefID = Convert.ToInt32(dr["REF_ID"]);
                        m_iModuleObjectMemberID = Convert.ToInt32(dr["PFS_MODULE_OBJECT_MEMBER_ID"]);
                        m_iApprovalStatusID = Convert.ToInt16(dr["COM_APPROVAL_STATUS_ID"]);
                        m_dtCreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                        m_dtUpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                        m_iUpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
                        m_xmlDetail = Convert.ToString(dr["DETAIL"]);
                        m_sRemark = Convert.ToString(dr["REMARK"]);
                        m_xmlPreviousDetail = Convert.ToString(dr["PREVIOUS_DETAIL"]);
                        m_sMemberCode = Convert.ToString(dr["MEMBER_CODE"]);
                        m_sMemberName = Convert.ToString(dr["MEMBER_NAME"]);
                        m_sApprovalStatusCode = Convert.ToString(dr["COM_APPROVAL_STATUS_CODE"]);
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

        public bool DAL_Add()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Add(oTrans))
                {
                    oTrans.Commit();
                    return true;
                }
                else
                {
                    oTrans.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_Add(SqlTransaction p_oTrans)
        {
            try
            {
                m_iApprovalLogID = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspCOM_ApprovalLogAdd",

                    m_iRefID,
                    m_iModuleObjectMemberID,
                    m_iApprovalStatusID,
                    m_dtCreateDate,
                    m_dtUpdateDate,
                    m_iCreateByUserID,
                    m_iUpdateByUserID,
                    m_xmlDetail,
                    m_sRemark,
                    m_xmlPreviousDetail
                ));
                if (m_iApprovalLogID < 1) return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_Update()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Update(oTrans))
                {
                    oTrans.Commit();
                    return true;
                }
                else
                {
                    oTrans.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_Update(SqlTransaction p_oTrans)
        {
            try
            {
                if (m_iApprovalLogID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspCOM_ApprovalLogUpdate",
                        m_iApprovalLogID,
                        m_iRefID,
                        m_iModuleObjectMemberID,
                        m_iApprovalStatusID,
                        m_dtCreateDate,
                        m_dtUpdateDate,
                        m_iCreateByUserID,
                        m_iUpdateByUserID,
                        m_xmlDetail,
                        m_sRemark,
                        m_xmlPreviousDetail
                    ));
                    if (iError != 0) return false;
                }
                else return DAL_Add(p_oTrans);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_Delete()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Delete(oTrans))
                {
                    oTrans.Commit();
                    return true;
                }
                else
                {
                    oTrans.Rollback();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_Delete(SqlTransaction p_oTrans)
        {
            try
            {
                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspCOM_ApprovalLogDelete", m_iApprovalLogID);
                return (iRowAffected > 0);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}