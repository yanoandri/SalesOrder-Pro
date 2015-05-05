﻿using System;
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

namespace PFSHelper.BusinessLogicLayer
{
    //Standard class autogenerated by PFS Generator v5.1
    public partial class UserPasswordHistory
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        protected long m_iUserPasswordHistoryID = 0;
        protected int m_iUserID = 0;
        protected string m_sPassword = "NONE";
        protected DateTime m_dtCreateDate = DateTime.Parse("01/01/1900");
        protected string m_sUserName = "NONE";
        protected string m_sFullName = "NONE";
        #endregion

        #region Region: Constructor////////////////////////////////////////////////////////////
        public UserPasswordHistory()
        {
            m_iUserPasswordHistoryID = -1;
        }
        public UserPasswordHistory(long iID)
        {
            m_iUserPasswordHistoryID = iID;
        }
        public UserPasswordHistory(
            long iUserPasswordHistoryID,
            int iUserID,
            string sPassword,
            DateTime dtCreateDate
        )
        {
            m_iUserPasswordHistoryID = iUserPasswordHistoryID;
            m_iUserID = iUserID;
            m_sPassword = sPassword;
            m_dtCreateDate = dtCreateDate;
        }
        #endregion

        #region Region: Properties/////////////////////////////////////////////////////////////
        public long UserPasswordHistoryID
        {
            get { return m_iUserPasswordHistoryID; }
            set { m_iUserPasswordHistoryID = value; }
        }
        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }
        public string Password
        {
            get { return m_sPassword; }
            set { m_sPassword = value; }
        }
        public DateTime CreateDate
        {
            get { return m_dtCreateDate; }
            set { m_dtCreateDate = value; }
        }
        public string UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }
        public string FullName
        {
            get { return m_sFullName; }
            set { m_sFullName = value; }
        }
        #endregion

        #region Region: Data Access Methods////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserPasswordHistoryGet", m_iUserPasswordHistoryID))
                {
                    if (dr.Read())
                    {
                        m_iUserPasswordHistoryID = Convert.ToInt64(dr["PFS_USER_PASSWORD_HISTORY_ID"]);
                        m_iUserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                        m_sPassword = Convert.ToString(dr["PASSWORD"]);
                        m_dtCreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                        m_sUserName = Convert.ToString(dr["USER_NAME"]);
                        m_sFullName = Convert.ToString(dr["FULL_NAME"]);
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
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserPasswordHistoryGet", iID))
                {
                    if (dr.Read())
                    {
                        m_iUserPasswordHistoryID = Convert.ToInt64(dr["PFS_USER_PASSWORD_HISTORY_ID"]);
                        m_iUserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                        m_sPassword = Convert.ToString(dr["PASSWORD"]);
                        m_dtCreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                        m_sUserName = Convert.ToString(dr["USER_NAME"]);
                        m_sFullName = Convert.ToString(dr["FULL_NAME"]);
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
                m_iUserPasswordHistoryID = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserPasswordHistoryAdd",

                    m_iUserID,
                    m_sPassword,
                    m_dtCreateDate
                ));
                if (m_iUserPasswordHistoryID < 1) return false;
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
                if (m_iUserPasswordHistoryID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserPasswordHistoryUpdate",
                        m_iUserPasswordHistoryID,
                        m_iUserID,
                        m_sPassword,
                        m_dtCreateDate
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
                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_UserPasswordHistoryDelete", m_iUserPasswordHistoryID);
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