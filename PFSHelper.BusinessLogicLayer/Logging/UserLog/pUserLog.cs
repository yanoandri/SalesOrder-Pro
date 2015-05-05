using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class UserLog
    {
        #region Member Variables

        private int m_iObjectID = 0;
        private string m_sObjectName = string.Empty;
        private int m_iModuleID = 0;
        private string m_sModuleName = string.Empty;
        private string m_sFullName = string.Empty;
        private int m_iUserID = 0;

        #endregion

        #region Properties

        public int ObjectID
        {
            get { return m_iObjectID; }
            set { m_iObjectID = value; }
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
        public string FullName
        {
            get { return m_sFullName; }
            set { m_sFullName = value; }
        }

        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }
        #endregion

        #region Constructors

        public UserLog(
			string p_sUserName,
			string sReferenceNumber,
			string sIpAddress,
			DateTime dtLogDate,
			string sDescription,
			string xmlDetail,
			short iStatus,
			int iModuleObjectMemberID,
            string p_sPreviousDetail
			)
		{
			m_sUserName = p_sUserName;
			m_sReferenceNumber = sReferenceNumber;
			m_sIpAddress = sIpAddress;
			m_dtLogDate = dtLogDate;
			m_sDescription = sDescription;
			m_xmlDetail = xmlDetail;
			m_iStatus = iStatus;
			m_iModuleObjectMemberID = iModuleObjectMemberID;
            m_xmlPreviousDetail = p_sPreviousDetail;
		}
        #endregion
        
        #region Methods

        public bool DAL_AddByUserID()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();

            try
            {
                bool bIsSuccess = DAL_AddByUserID(oTrans);

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

        public bool DAL_AddByUserID(SqlTransaction p_oTrans)
        {
            try
            {
                m_iUserLogID = Convert.ToInt64(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserLogAdd",
                    m_sUserName,
                    m_sReferenceNumber,
                    m_sIpAddress,
                    m_dtLogDate,
                    m_sDescription,
                    m_xmlDetail,
                    m_iStatus,
                    m_iModuleObjectMemberID,
                    m_bIsPurge,
                    m_xmlPreviousDetail
                    ));

                bool bIsSuccess = (m_iUserLogID > 0);


                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_LoadLastLogByUserID(int iUserID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drUserLog = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, 
                    "uspPFS_UserLogGetLastLogByUserID", iUserID))
                {
                    if (drUserLog.Read())
                    {
                        m_iUserLogID = Convert.ToInt64(drUserLog["PFS_USER_LOG_ID"]);
                        m_sUserName = Convert.ToString(drUserLog["USER_NAME"]);
                        m_sReferenceNumber = Convert.ToString(drUserLog["REFERENCE_NUMBER"]);
                        m_sIpAddress = Convert.ToString(drUserLog["IP_ADDRESS"]);
                        m_dtLogDate = Convert.ToDateTime(drUserLog["LOG_DATE"]);
                        m_sDescription = Convert.ToString(drUserLog["DESCRIPTION"]);
                        m_xmlDetail = Convert.ToString(drUserLog["DETAIL"]);
                        m_iStatus = Convert.ToInt16(drUserLog["STATUS"]);
                        m_iModuleObjectMemberID = Convert.ToInt32(drUserLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                        m_sUserName = Convert.ToString(drUserLog["USER_NAME"]);
                        m_sFullName = Convert.ToString(drUserLog["FULL_NAME"]);
                        m_sMemberCode = Convert.ToString(drUserLog["MEMBER_CODE"]);
                        m_sMemberName = Convert.ToString(drUserLog["MEMBER_NAME"]);
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

        public bool PurgeData()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();

            try
            {
                if (!PurgeData(oTrans))
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

        public bool PurgeData(SqlTransaction p_oTrans)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_UserLogSetPurgeStatus", 
                    m_iUserLogID, 
                    m_bIsPurge) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
