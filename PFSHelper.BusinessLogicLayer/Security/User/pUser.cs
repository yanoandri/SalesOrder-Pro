using System;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;
using PFSHelper.Lib;

#region Region: Revision History
//20 Aug 2013 - Alvin
//Adding member variables and properties to support new security policy
#endregion

namespace PFSHelper.BusinessLogicLayer
{
    public partial class User
    {
        #region Region : Partial Member Variables
        protected UserGroupCollection m_oUserGroupList = new UserGroupCollection();
        protected string m_sUserGroup = "";
        protected string m_sDecryptedPassword = "";
        protected string m_sSecurityQuestion = "";
        protected string m_sSecurityAnswer = "";
        protected int m_iTodayFailedLoginAttempts = 0;
        protected DateTime m_dtLastFailedLoginDate = DateTime.Parse("1900/01/01");
        protected bool m_bIsBlocked = false;
        protected string m_sCreatedByName = "";
        #endregion

        #region Region : Partial Properties
        public UserGroupCollection UserGroupList
        {
            get { return m_oUserGroupList; }
            set { m_oUserGroupList = value; }
        }
        public string UserGroupItem
        {
            get { return m_sUserGroup; }
            set { m_sUserGroup = value; }
        }
        public string DecryptedPassword
        {
            get { return m_sDecryptedPassword; }
            set { m_sDecryptedPassword = value; }
        }
        public string SecurityQuestion 
        {
            get { return m_sSecurityQuestion; }
            set { m_sSecurityQuestion = value; }
        }
        public string SecurityAnswer
        {
            get { return m_sSecurityAnswer; }
            set { m_sSecurityAnswer = value; }
        }
        public int TodayFailedLoginAttempts
        {
            get { return m_iTodayFailedLoginAttempts; }
            set { m_iTodayFailedLoginAttempts = value; }
        }
        public DateTime LastFailedLoginDate
        {
            get { return m_dtLastFailedLoginDate; }
            set { m_dtLastFailedLoginDate = value; }
        }
        public bool IsBlocked
        {
            get { return m_bIsBlocked; }
            set { m_bIsBlocked = value; }
        }
        public string CreatedByName
        {
            get { return m_sCreatedByName; }
            set { m_sCreatedByName = value; }
        }
        #endregion

        #region Region : Methods

        public User Clone()
        {

            User oUserClone = new User();

            oUserClone.UserID = 0;
            oUserClone.UserName = "NONE";
            oUserClone.Password = "NONE";
            oUserClone.FullName = "NONE";
            oUserClone.Title = "NONE";
            oUserClone.Email = "NONE";
            oUserClone.IsActive = true;
            oUserClone.LastAccess = Convert.ToDateTime("01/01/1900");
            oUserClone.IsLogin = false;
            oUserClone.CreateDate = DateTime.Now;
            oUserClone.CreateByUserID = 0;
            oUserClone.UpdateDate = DateTime.Now;
            oUserClone.UpdateByUserID = 0;
            oUserClone.UserGroupItem = "NONE";
            oUserClone.UserGroupList = new UserGroupCollection();
            //oUserClone.IsNoLock = m_bIsNoLock;

            return oUserClone;
        }

        #endregion

        #region Region : Partial Data Access Methods
        public bool DAL_LoadByUserName(string p_sUserName, object p_iUserID, bool? p_bIsLogin = null)
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserGetByUsername",
                        p_sUserName,
                        p_bIsLogin,
                        p_iUserID))
                {
                    if (dr.Read())
                    {
                        m_iUserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                        m_sUserName = Convert.ToString(dr["USER_NAME"].ToString());
                        m_sPassword = Convert.ToString(dr["PASSWORD"].ToString());
                        m_sFullName = Convert.ToString(dr["FULL_NAME"].ToString());
                        m_sTitle = Convert.ToString(dr["TITLE"]);
                        m_sEmail = Convert.ToString(dr["EMAIL"]);
                        m_sStartLoginTime = Convert.ToString(dr["START_LOGIN_TIME"]);
                        m_sEndLoginTime = Convert.ToString(dr["END_LOGIN_TIME"]);
                        m_bAllowHolidayLogin = Convert.ToBoolean(dr["ALLOW_HOLIDAY_LOGIN"]);
                        m_bAllowWeekendLogin = Convert.ToBoolean(dr["ALLOW_WEEKEND_LOGIN"]);
                        m_bIsActive = Convert.ToBoolean(dr["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(dr["IS_NEED_APPROVAL"]);
                        m_dtLastAccess = Convert.ToDateTime(dr["LAST_ACCESS"]);
                        m_bIsLogin = Convert.ToBoolean(dr["IS_LOGIN"]);
                        m_dtCreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
                        m_sSecurityQuestion = Convert.ToString(dr["SECURITY_QUESTION"]);
                        m_sSecurityAnswer = Convert.ToString(dr["SECURITY_ANSWER"]);
                        m_iTodayFailedLoginAttempts = Convert.ToInt32(dr["TODAY_FAILED_LOGIN_ATTEMPTS"]);
                        m_dtLastFailedLoginDate = Convert.ToDateTime(dr["LAST_FAILED_LOGIN_DATE"]);
                        m_bIsBlocked = Convert.ToBoolean(dr["IS_BLOCKED"]);

                        //Get group name
                        m_oUserGroupList.DAL_Load(null, m_iUserID, null);
                        int Index = 0;
                        foreach (UserGroup oUserGroupItem in m_oUserGroupList)
                        {
                            m_sUserGroup += oUserGroupItem.GroupName;
                            Index++;
                            if (Index < m_oUserGroupList.Count) m_sUserGroup += string.Format(", ");
                        }
                        if (m_sUserGroup.Equals("")) m_sUserGroup = "-";
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool DAL_LoadWithGroupName()
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

                        //Get group name
                        m_oUserGroupList.DAL_Load(null, m_iUserID, null);
                        int Index = 0;
                        foreach (UserGroup oUserGroupItem in m_oUserGroupList)
                        {
                            m_sUserGroup += oUserGroupItem.GroupName;
                            Index++;
                            if (Index < m_oUserGroupList.Count) m_sUserGroup += string.Format(", ");
                        }
                    }
                }
                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Deactivate()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = Deactivate(oTrans);

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

        public bool Deactivate(SqlTransaction p_oTrans)
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
                                        false,
                                        m_bIsNeedApproval,
                                        m_dtLastAccess,
                                        m_bIsLogin,
                                        m_dtCreateDate,
                                        m_iCreateByUserID,
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
        
        public bool UpdateApprovalStatus(SqlTransaction p_oTrans, bool bIsNeedApproval)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iUserID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserUpdateByApprovalStatus",
                        m_iUserID,
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
        
        public bool RejectApprovalRequest(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;

                int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserUpdateByRejection",
                    m_iUserID
                ));

                bIsSuccess = (iError == 0);

                return (bIsSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool LoadByUserNameWithoutGroup(string p_sUserName)
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserGetByUsername",
                        p_sUserName,
                        null,
                        null))
                {
                    if (dr.Read())
                    {
                        m_iUserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                        m_sUserName = Convert.ToString(dr["USER_NAME"].ToString());
                        m_sPassword = Convert.ToString(dr["PASSWORD"].ToString());
                        m_sFullName = Convert.ToString(dr["FULL_NAME"].ToString());
                        m_sTitle = Convert.ToString(dr["TITLE"]);
                        m_sEmail = Convert.ToString(dr["EMAIL"]);
                        m_bIsActive = Convert.ToBoolean(dr["IS_ACTIVE"]);
                        m_bIsNeedApproval = Convert.ToBoolean(dr["IS_NEED_APPROVAL"]);
                        m_dtLastAccess = Convert.ToDateTime(dr["LAST_ACCESS"]);
                        m_bIsLogin = Convert.ToBoolean(dr["IS_LOGIN"]);
                        m_dtCreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
                        m_sSecurityQuestion = Convert.ToString(dr["SECURITY_QUESTION"]);
                        m_sSecurityAnswer = Convert.ToString(dr["SECURITY_ANSWER"]);
                        m_iTodayFailedLoginAttempts = Convert.ToInt32(dr["TODAY_FAILED_LOGIN_ATTEMPTS"]);
                        m_dtLastFailedLoginDate = Convert.ToDateTime(dr["LAST_FAILED_LOGIN_DATE"]);
                        m_bIsBlocked = Convert.ToBoolean(dr["IS_BLOCKED"]);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool UpdateLoginStatus(bool IsLogin)
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = false;
                bIsSuccess = UpdateLoginStatus(IsLogin, oTrans);
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

        public bool UpdateLoginStatus(bool IsLogin, SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iUserID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserUpdateLoginStatus",
                    m_iUserID, m_bIsLogin
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

        public bool IsAllowedToLogin(bool IsTodayHoliday)
        {
            bool bIsSuccess = true;

            string[] sWeekDays = PFSCommon.GetSysParam("WEEKEND").Split(',');

            foreach (string sDay in sWeekDays)
            {
                if (sDay.Trim().ToUpper() == DateTime.Now.DayOfWeek.ToString().ToUpper())
                {
                    bIsSuccess = AllowWeekendLogin;
                    break;
                }
            }

            //check jam kerja ketika login di weekday
            if (bIsSuccess)
            {
                bIsSuccess = (DateTime.Now >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(m_sStartLoginTime.Substring(0, 2)), Int32.Parse(m_sStartLoginTime.Substring(3, 2)), 0) &&
                 DateTime.Now <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(m_sEndLoginTime.Substring(0, 2)), Int32.Parse(m_sEndLoginTime.Substring(3, 2)), 0));
            }
            else
            {
                if (IsTodayHoliday)
                    bIsSuccess = AllowHolidayLogin;

                if (bIsSuccess)
                    bIsSuccess = (DateTime.Now >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(m_sStartLoginTime.Substring(0, 2)), Int32.Parse(m_sStartLoginTime.Substring(3, 2)), 0) &&
                     DateTime.Now <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(m_sEndLoginTime.Substring(0, 2)), Int32.Parse(m_sEndLoginTime.Substring(3, 2)), 0));
            }

            return bIsSuccess;
        }

        public static bool IsHaveRelation(int iUserID)
        {
            return SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserCheckTableRelations", iUserID).Read();
        }
        #endregion
    }
}
