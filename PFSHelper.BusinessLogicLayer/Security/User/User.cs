using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
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
    //Standard class autogenerated by PFS Generator v5.0
    public partial class User
    {
        #region Region: Member Variables///////////////////////////////////////////////////////////
        protected UserDetailCollection m_oUserDetailCollection = null;
        protected int m_iUserID = 0;
        protected string m_sUserName = "NONE";
        protected string m_sPassword = "NONE";
        protected string m_sFullName = "NONE";
        protected string m_sTitle = "NONE";
        protected string m_sEmail = "NONE";
        protected string m_sStartLoginTime = "NONE";
        protected string m_sEndLoginTime = "NONE";
        protected bool m_bAllowHolidayLogin = false;
        protected bool m_bAllowWeekendLogin = false;
        protected bool m_bIsActive = false;
        protected bool m_bIsNeedApproval = false;
        protected DateTime m_dtLastAccess = DateTime.Parse("01/01/1900");
        protected bool m_bIsLogin = false;
        protected DateTime m_dtCreateDate = DateTime.Parse("01/01/1900");
        protected int m_iCreateByUserID = 0;
        protected DateTime m_dtUpdateDate = DateTime.Parse("01/01/1900");
        protected int m_iUpdateByUserID = 0;
        #endregion

        #region Region: Constructor////////////////////////////////////////////////////////////////
        public User()
        {
            m_iUserID = -1;
            m_oUserDetailCollection = new UserDetailCollection();
        }
        public User(int iID)
        {
            m_oUserDetailCollection = new UserDetailCollection();
            m_iUserID = iID;
        }

        public User(
            UserDetail oUserDetails,
            int iUserID,
            string sUserName,
            string sPassword,
            string sFullName,
            string sTitle,
            string sEmail,
            string sStartLoginTime,
            string sEndLoginTime,
            bool bAllowHolidayLogin,
            bool bAllowWeekendLogin,
            bool bIsActive,
            bool bIsNeedApproval,
            DateTime dtLastAccess,
            bool bIsLogin,
            DateTime dtCreateDate,
            int iCreateByUserID,
            DateTime dtUpdateDate,
            int iUpdateByUserID
            )
        {
            m_oUserDetailCollection = new UserDetailCollection();
            m_iUserID = iUserID;
            m_sUserName = sUserName;
            m_sPassword = sPassword;
            m_sFullName = sFullName;
            m_sTitle = sTitle;
            m_sEmail = sEmail;
            m_sStartLoginTime = sStartLoginTime;
            m_sEndLoginTime = sEndLoginTime;
            m_bAllowHolidayLogin = bAllowHolidayLogin;
            m_bAllowWeekendLogin = bAllowWeekendLogin;
            m_bIsActive = bIsActive;
            m_bIsNeedApproval = bIsNeedApproval;
            m_dtLastAccess = dtLastAccess;
            m_bIsLogin = bIsLogin;
            m_dtCreateDate = dtCreateDate;
            m_iCreateByUserID = iCreateByUserID;
            m_dtUpdateDate = dtUpdateDate;
            m_iUpdateByUserID = iUpdateByUserID;
        }

        #endregion

        #region Region: Properties/////////////////////////////////////////////////////////////////
        public UserDetailCollection UserDetails
        {
            get { return m_oUserDetailCollection; }
            set { m_oUserDetailCollection = value; }
        }

        public int UserID
        {
            get { return m_iUserID; }
            set { m_iUserID = value; }
        }

        public string UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }

        public string Password
        {
            get { return m_sPassword; }
            set { m_sPassword = value; }
        }

        public string FullName
        {
            get { return m_sFullName; }
            set { m_sFullName = value; }
        }

        public string Title
        {
            get { return m_sTitle; }
            set { m_sTitle = value; }
        }

        public string Email
        {
            get { return m_sEmail; }
            set { m_sEmail = value; }
        }

        public string StartLoginTime
        {
            get { return m_sStartLoginTime; }
            set { m_sStartLoginTime = value; }
        }

        public string EndLoginTime
        {
            get { return m_sEndLoginTime; }
            set { m_sEndLoginTime = value; }
        }

        public bool AllowHolidayLogin
        {
            get { return m_bAllowHolidayLogin; }
            set { m_bAllowHolidayLogin = value; }
        }

        public bool AllowWeekendLogin
        {
            get { return m_bAllowWeekendLogin; }
            set { m_bAllowWeekendLogin = value; }
        }

        public bool IsActive
        {
            get { return m_bIsActive; }
            set { m_bIsActive = value; }
        }

        public bool IsNeedApproval
        {
            get { return m_bIsNeedApproval; }
            set { m_bIsNeedApproval = value; }
        }

        public DateTime LastAccess
        {
            get { return m_dtLastAccess; }
            set { m_dtLastAccess = value; }
        }

        public bool IsLogin
        {
            get { return m_bIsLogin; }
            set { m_bIsLogin = value; }
        }

        public DateTime CreateDate
        {
            get { return m_dtCreateDate; }
            set { m_dtCreateDate = value; }
        }

        public int CreateByUserID
        {
            get { return m_iCreateByUserID; }
            set { m_iCreateByUserID = value; }
        }

        public DateTime UpdateDate
        {
            get { return m_dtUpdateDate; }
            set { m_dtUpdateDate = value; }
        }

        public int UpdateByUserID
        {
            get { return m_iUpdateByUserID; }
            set { m_iUpdateByUserID = value; }
        }
        #endregion

        #region Region: Data Access Methods////////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drUser = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserGet", m_iUserID))
                {
                    if (drUser.Read())
                    {
                        m_iUserID = Convert.ToInt32(drUser["PFS_USER_ID"]);
                        m_sUserName = Convert.ToString(drUser["USER_NAME"]);
                        m_sPassword = Convert.ToString(drUser["PASSWORD"]);
                        m_sFullName = Convert.ToString(drUser["FULL_NAME"]);
                        m_sTitle = Convert.ToString(drUser["TITLE"]);
                        m_sEmail = Convert.ToString(drUser["EMAIL"]);
                        m_sStartLoginTime = Convert.ToString(drUser["START_LOGIN_TIME"]);
                        m_sEndLoginTime = Convert.ToString(drUser["END_LOGIN_TIME"]);
                        m_bAllowHolidayLogin = Convert.ToBoolean(drUser["ALLOW_HOLIDAY_LOGIN"]);
                        m_bAllowWeekendLogin = Convert.ToBoolean(drUser["ALLOW_WEEKEND_LOGIN"]);
                        m_bIsActive = Convert.ToBoolean(drUser["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(drUser["IS_NEED_APPROVAL"]);
                        m_dtLastAccess = Convert.ToDateTime(drUser["LAST_ACCESS"]);
                        m_bIsLogin = Convert.ToBoolean(drUser["IS_LOGIN"]);
                        m_dtCreateDate = Convert.ToDateTime(drUser["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drUser["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(drUser["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(drUser["UPDATE_BY_USER_ID"]);
                        m_sSecurityQuestion = Convert.ToString(drUser["SECURITY_QUESTION"]);
                        m_sSecurityAnswer = Convert.ToString(drUser["SECURITY_ANSWER"]);
                        m_iTodayFailedLoginAttempts = Convert.ToInt32(drUser["TODAY_FAILED_LOGIN_ATTEMPTS"]);
                        m_dtLastFailedLoginDate = Convert.ToDateTime(drUser["LAST_FAILED_LOGIN_DATE"]);
                        m_bIsBlocked = Convert.ToBoolean(drUser["IS_BLOCKED"]);
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

        public bool DAL_LoadWithChild()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drUser = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserGet", m_iUserID))
                {
                    if (drUser.Read())
                    {
                        m_iUserID = Convert.ToInt32(drUser["PFS_USER_ID"]);
                        m_sUserName = Convert.ToString(drUser["USER_NAME"]);
                        m_sPassword = Convert.ToString(drUser["PASSWORD"]);
                        m_sFullName = Convert.ToString(drUser["FULL_NAME"]);
                        m_sTitle = Convert.ToString(drUser["TITLE"]);
                        m_sEmail = Convert.ToString(drUser["EMAIL"]);
                        m_sStartLoginTime = Convert.ToString(drUser["START_LOGIN_TIME"]);
                        m_sEndLoginTime = Convert.ToString(drUser["END_LOGIN_TIME"]);
                        m_bAllowHolidayLogin = Convert.ToBoolean(drUser["ALLOW_HOLIDAY_LOGIN"]);
                        m_bAllowWeekendLogin = Convert.ToBoolean(drUser["ALLOW_WEEKEND_LOGIN"]);
                        m_bIsActive = Convert.ToBoolean(drUser["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(drUser["IS_NEED_APPROVAL"]);
                        m_dtLastAccess = Convert.ToDateTime(drUser["LAST_ACCESS"]);
                        m_bIsLogin = Convert.ToBoolean(drUser["IS_LOGIN"]);
                        m_dtCreateDate = Convert.ToDateTime(drUser["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drUser["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(drUser["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(drUser["UPDATE_BY_USER_ID"]);
                        m_sSecurityQuestion = Convert.ToString(drUser["SECURITY_QUESTION"]);
                        m_sSecurityAnswer = Convert.ToString(drUser["SECURITY_ANSWER"]);
                        m_iTodayFailedLoginAttempts = Convert.ToInt32(drUser["TODAY_FAILED_LOGIN_ATTEMPTS"]);
                        m_dtLastFailedLoginDate = Convert.ToDateTime(drUser["LAST_FAILED_LOGIN_DATE"]);
                        m_bIsBlocked = Convert.ToBoolean(drUser["IS_BLOCKED"]);
                        m_oUserDetailCollection.DAL_LoadByUserID(m_iUserID);
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
                using (SqlDataReader drUser = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserGet", iID))
                {
                    if (drUser.Read())
                    {
                        m_iUserID = Convert.ToInt32(drUser["PFS_USER_ID"]);
                        m_sUserName = Convert.ToString(drUser["USER_NAME"]);
                        m_sPassword = Convert.ToString(drUser["PASSWORD"]);
                        m_sFullName = Convert.ToString(drUser["FULL_NAME"]);
                        m_sTitle = Convert.ToString(drUser["TITLE"]);
                        m_sEmail = Convert.ToString(drUser["EMAIL"]);
                        m_sStartLoginTime = Convert.ToString(drUser["START_LOGIN_TIME"]);
                        m_sEndLoginTime = Convert.ToString(drUser["END_LOGIN_TIME"]);
                        m_bAllowHolidayLogin = Convert.ToBoolean(drUser["ALLOW_HOLIDAY_LOGIN"]);
                        m_bAllowWeekendLogin = Convert.ToBoolean(drUser["ALLOW_WEEKEND_LOGIN"]);
                        m_bIsActive = Convert.ToBoolean(drUser["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(drUser["IS_NEED_APPROVAL"]);
                        m_dtLastAccess = Convert.ToDateTime(drUser["LAST_ACCESS"]);
                        m_bIsLogin = Convert.ToBoolean(drUser["IS_LOGIN"]);
                        m_dtCreateDate = Convert.ToDateTime(drUser["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drUser["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(drUser["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(drUser["UPDATE_BY_USER_ID"]);
                        m_sSecurityQuestion = Convert.ToString(drUser["SECURITY_QUESTION"]);
                        m_sSecurityAnswer = Convert.ToString(drUser["SECURITY_ANSWER"]);
                        m_iTodayFailedLoginAttempts = Convert.ToInt32(drUser["TODAY_FAILED_LOGIN_ATTEMPTS"]);
                        m_dtLastFailedLoginDate = Convert.ToDateTime(drUser["LAST_FAILED_LOGIN_DATE"]);
                        m_bIsBlocked = Convert.ToBoolean(drUser["IS_BLOCKED"]);
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

        public bool DAL_LoadWithChild(int iID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drUser = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserGet", iID))
                {
                    if (drUser.Read())
                    {
                        m_iUserID = Convert.ToInt32(drUser["PFS_USER_ID"]);
                        m_sUserName = Convert.ToString(drUser["USER_NAME"]);
                        m_sPassword = Convert.ToString(drUser["PASSWORD"]);
                        m_sFullName = Convert.ToString(drUser["FULL_NAME"]);
                        m_sTitle = Convert.ToString(drUser["TITLE"]);
                        m_sEmail = Convert.ToString(drUser["EMAIL"]);
                        m_sStartLoginTime = Convert.ToString(drUser["START_LOGIN_TIME"]);
                        m_sEndLoginTime = Convert.ToString(drUser["END_LOGIN_TIME"]);
                        m_bAllowHolidayLogin = Convert.ToBoolean(drUser["ALLOW_HOLIDAY_LOGIN"]);
                        m_bAllowWeekendLogin = Convert.ToBoolean(drUser["ALLOW_WEEKEND_LOGIN"]);
                        m_bIsActive = Convert.ToBoolean(drUser["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(drUser["IS_NEED_APPROVAL"]);
                        m_dtLastAccess = Convert.ToDateTime(drUser["LAST_ACCESS"]);
                        m_bIsLogin = Convert.ToBoolean(drUser["IS_LOGIN"]);
                        m_dtCreateDate = Convert.ToDateTime(drUser["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(drUser["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(drUser["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(drUser["UPDATE_BY_USER_ID"]);
                        m_sSecurityQuestion = Convert.ToString(drUser["SECURITY_QUESTION"]);
                        m_sSecurityAnswer = Convert.ToString(drUser["SECURITY_ANSWER"]);
                        m_iTodayFailedLoginAttempts = Convert.ToInt32(drUser["TODAY_FAILED_LOGIN_ATTEMPTS"]);
                        m_dtLastFailedLoginDate = Convert.ToDateTime(drUser["LAST_FAILED_LOGIN_DATE"]);
                        m_bIsBlocked = Convert.ToBoolean(drUser["IS_BLOCKED"]);
                        m_oUserDetailCollection.DAL_LoadByUserID(m_iUserID);

                        //Get group name
                        m_oUserGroupList.DAL_Load(null, m_iUserID, null);
                        int Index = 0;
                        foreach (UserGroup oUserGroupItem in m_oUserGroupList)
                        {
                            m_sUserGroup += oUserGroupItem.GroupName;
                            Index++;
                            if (Index < m_oUserGroupList.Count) m_sUserGroup += string.Format(", ");
                        }

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

        public bool DAL_Update()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = false;
                bIsSuccess = DAL_Update(oTrans);
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

        public bool DAL_Update(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iUserID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserUpdate",
                    m_iUserID,
                                        m_sUserName,
                                        m_sPassword,
                                        m_sFullName,
                                        m_sTitle,
                                        m_sEmail,
                                        m_bIsActive,
                                        m_bIsNeedApproval,
                                        m_dtLastAccess,
                                        m_bIsLogin,
                                        m_dtCreateDate,
                                        m_iCreateByUserID,
                                        m_dtUpdateDate,
                                        m_iUpdateByUserID,
                                        m_sStartLoginTime,
                                        m_sEndLoginTime,
                                        m_bAllowHolidayLogin,
                                        m_bAllowWeekendLogin,
                                        m_sSecurityQuestion,
                                        m_sSecurityAnswer,
                                        m_iTodayFailedLoginAttempts,
                                        m_dtLastFailedLoginDate,
                                        m_bIsBlocked
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

        public bool DAL_UpdateWithChild()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = false;
                bIsSuccess = DAL_UpdateWithChild(oTrans);
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

        public bool DAL_UpdateWithChild(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iUserID > 0)
                {
                    //Check duplicate user name
                    bool bIsFound = false;
                    User oCheckUser = new User();

                    bIsFound = oCheckUser.DAL_LoadByUserName(m_sUserName, m_iUserID);
                    if (bIsFound && oCheckUser.UserID != m_iUserID)
                    {
                        throw new Exception("Duplicate user name, update aborted.");
                    }

                    int iError = Convert.ToInt32(SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_UserUpdate",
                    m_iUserID,
                                        m_sUserName,
                                        m_sPassword,
                                        m_sFullName,
                                        m_sTitle,
                                        m_sEmail,
                                        m_bIsActive,
                                        m_bIsNeedApproval,
                                        m_dtLastAccess,
                                        m_bIsLogin,
                                        m_dtCreateDate,
                                        m_iCreateByUserID,
                                        m_dtUpdateDate,
                                        m_iUpdateByUserID,
                                        m_sStartLoginTime,
                                        m_sEndLoginTime,
                                        m_bAllowHolidayLogin,
                                        m_bAllowWeekendLogin,
                                        m_sSecurityQuestion,
                                        m_sSecurityAnswer,
                                        m_iTodayFailedLoginAttempts,
                                        m_dtLastFailedLoginDate,
                                        m_bIsBlocked
                    ));
                    bIsSuccess = (iError > 0);

                    #region Delete appropriate child
                    if (bIsSuccess)
                    {
                        //*** Retrieve the original list first
                        UserDetailCollection oUserDetailDeletedList = new UserDetailCollection();
                        if (oUserDetailDeletedList.DAL_LoadByUserID(m_iUserID))
                        {
                            //*** Then Compare to get deleted list
                            foreach (UserDetail oUserDetailIterator in m_oUserDetailCollection)
                            {
                                //** Such a Hassle just to get a deleted list
                                for (int i = 0; i < oUserDetailDeletedList.Count; i++)
                                {
                                    if (oUserDetailDeletedList[i].UserDetailID == oUserDetailIterator.UserDetailID)
                                    {
                                        oUserDetailDeletedList.RemoveAt(i);
                                        break;
                                    }
                                }
                            }

                            bIsSuccess = oUserDetailDeletedList.DAL_Delete(p_oTrans);
                            if (!bIsSuccess) return bIsSuccess;
                        }
                    }
                    #endregion

                    #region Delete appropriate child USER GROUP
                    if (bIsSuccess)
                    {
                        //*** Retrieve the original list first
                        UserGroupCollection oUserGroupDeletedList = new UserGroupCollection();
                        if (oUserGroupDeletedList.DAL_LoadByUserID(m_iUserID))
                        {
                            //*** Then Compare to get deleted list
                            foreach (UserGroup oUserGroupIterator in m_oUserGroupList)
                            {
                                //** Such a Hassle just to get a deleted list
                                for (int i = 0; i < oUserGroupDeletedList.Count; i++)
                                {
                                    if (oUserGroupDeletedList[i].UserGroupID == oUserGroupIterator.UserGroupID)
                                    {
                                        oUserGroupDeletedList.RemoveAt(i);
                                        break;
                                    }
                                }
                            }

                            bIsSuccess = oUserGroupDeletedList.DAL_Delete(p_oTrans);
                        }
                    }
                    #endregion

                    #region Update appropriate child User Detail
                    if (bIsSuccess)
                    {
                        for (int i = 0; i < m_oUserDetailCollection.Count; i++)
                        {
                            m_oUserDetailCollection[i].UserID = m_iUserID;
                        }
                        bIsSuccess = m_oUserDetailCollection.DAL_Update(p_oTrans);
                        if (!bIsSuccess) return bIsSuccess;

                    }
                    #endregion

                    #region update appropriate child USER GROUP
                    if (bIsSuccess)
                    {
                        for (int i = 0; i < m_oUserGroupList.Count; i++)
                        {
                            m_oUserGroupList[i].UserID = m_iUserID;
                        }
                        bIsSuccess = m_oUserGroupList.DAL_Update(p_oTrans);
                    }
                    #endregion
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

        public bool DAL_Delete()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_Delete(oTrans);

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

        public bool DAL_Delete(SqlTransaction p_oTrans)
        {
            try
            {
                #region Delete child first

                if (!m_oUserDetailCollection.DAL_Delete(p_oTrans)) return false;
                if (!m_oUserGroupList.DAL_Delete(p_oTrans)) return false;
                #endregion

                #region Delete Constraint

                UserLogCollection oUserLogCollection = new UserLogCollection();
                oUserLogCollection.LoadByUserID(m_iUserID);
                oUserLogCollection.DAL_Delete(p_oTrans);

                oUserLogCollection.Clear();
                oUserLogCollection = null;

                #endregion

                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_UserDelete", m_iUserID);

                return (iRowAffected > 0);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public bool DAL_Add()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_Add(oTrans);

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

        public bool DAL_Add(SqlTransaction p_oTrans)
        {
            try
            {
                m_iUserID = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserAdd",

                    m_sUserName,
                    m_sPassword,
                    m_sFullName,
                    m_sTitle,
                    m_sEmail,
                    m_bIsActive,
                    m_bIsNeedApproval,
                    m_dtLastAccess,
                    m_bIsLogin,
                    m_dtCreateDate,
                    m_iCreateByUserID,
                    m_dtUpdateDate,
                    m_iUpdateByUserID,
                    m_sStartLoginTime,
                    m_sEndLoginTime,
                    m_bAllowHolidayLogin,
                    m_bAllowWeekendLogin,
                    m_sSecurityQuestion,
                    m_sSecurityAnswer,
                    m_iTodayFailedLoginAttempts,
                    m_dtLastFailedLoginDate,
                    m_bIsBlocked
                    ));

                bool bIsSuccess = (m_iUserID >= 0);

                #region Add appropriate child
                if (bIsSuccess)
                {
                    if (bIsSuccess)
                    {
                        for (int i = 0; i < m_oUserDetailCollection.Count; i++)
                        {
                            m_oUserDetailCollection[i].UserID = m_iUserID;
                        }
                        bIsSuccess = m_oUserDetailCollection.DAL_Add(p_oTrans);
                    }

                    #region Delete appropriate child USER GROUP
                    //*** Retrieve the original list first
                    UserGroupCollection oUserGroupDeletedList = new UserGroupCollection();
                    if (oUserGroupDeletedList.DAL_LoadByUserID(m_iUserID))
                    {
                        //*** Then Compare to get deleted list
                        foreach (UserGroup oUserGroupIterator in m_oUserGroupList)
                        {
                            //** Such a Hassle just to get a deleted list
                            for (int i = 0; i < oUserGroupDeletedList.Count; i++)
                            {
                                if (oUserGroupDeletedList[i].UserGroupID == oUserGroupIterator.UserGroupID)
                                {
                                    oUserGroupDeletedList.RemoveAt(i);
                                    break;
                                }
                            }
                        }

                        bIsSuccess = oUserGroupDeletedList.DAL_Delete(p_oTrans);
                    }

                    #endregion

                    #region update appropriate child USER GROUP
                    if (bIsSuccess)
                    {
                        for (int i = 0; i < m_oUserGroupList.Count; i++)
                        {
                            m_oUserGroupList[i].UserID = m_iUserID;
                        }
                        bIsSuccess = m_oUserGroupList.DAL_Update(p_oTrans);
                    }
                    #endregion

                }
                #endregion

                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    } //** Class
} //** Name Space