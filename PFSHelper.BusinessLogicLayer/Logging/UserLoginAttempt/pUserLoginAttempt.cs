using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class UserLoginAttempt
    {
        /// <summary>
        /// UPDATE LOGIN ATTEMPT FOR SUCCEEDED LOGIN
        /// </summary>
        /// <returns>UPDATE LOGIN ATTEMPT FOR SUCCEEDED LOGIN</returns>
        public bool UpdateSuccessLoginAttempt()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();

            User oUser = new User();
            try
            {
                bool bIsSuccess = UpdateSuccessLoginAttempt(oTrans);

                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
                oUser = null;
            }
        }

        private bool UpdateSuccessLoginAttempt(SqlTransaction oTrans)
        {
            try
            {
                bool bIsSuccess = false;
                m_dtLastSuccessfullLoginDate = DateTime.Now;
                    
                if (DAL_LoadByUsername(m_sUserName))
                {
                    m_iTotalSuccess += 1;

                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(oTrans, "uspPFS_UserLoginAttemptUpdateSuccesful",
                    m_iUserLoginAttemptID,
                                        m_sUserName,
                                        m_dtLastSuccessfullLoginDate,
                                        m_iTotalSuccess
                    ));
                    bIsSuccess = (iError == 0);
                }
                else
                {
                    m_iTotalSuccess += 1;
                    bIsSuccess = DAL_Add();
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {   
                throw Ex;
            }
        }

        /// <summary>
        /// UPDATE LOGIN ATTEMPT FOR FAILED LOGIN
        /// </summary>
        /// <returns>UPDATE LOGIN ATTEMPT FOR FAILED LOGIN</returns>
        public bool UpdateFailLoginAttempt()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();

            User oUser = new User();
            try
            {
                bool bIsSuccess = UpdateFailLoginAttempt(oTrans);

                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (Exception Ex)
            {
                oTrans.Rollback();
                throw Ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
                oUser = null;
            }
        }

        /// <summary>
        /// UPDATE LOGIN ATTEMPT FOR FAILED LOGIN
        /// </summary>
        /// <param name="p_oTrans">Sql Transaction</param>
        /// <returns></returns>
        private bool UpdateFailLoginAttempt(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;

                if (DAL_LoadByUsername(m_sUserName))
                {
                    if(m_dtLastFailedLoginDate > m_dtLastSuccessfullLoginDate)
                        m_iTotalFailed += 1;
                    else
                        m_iTotalFailed = 1;

                    m_dtLastFailedLoginDate = DateTime.Now;

                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_UserLoginAttemptUpdateFailed",
                    m_iUserLoginAttemptID,
                                        m_sUserName,
                                        m_dtLastFailedLoginDate,
                                        m_iTotalFailed,
                                        m_sLastFailedDescription
                    ));
                    bIsSuccess = (iError == 0);
                }
                else
                {
                    m_iTotalFailed += 1;
                    bIsSuccess = DAL_Add(p_oTrans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// REFER TO SP -> "uspPFS_UserLoginAttemptGetByUsername"
        /// </summary>
        /// <param name="sUsername">Username Parameter</param>
        /// <returns>uspPFS_UserLoginAttemptGetByUsername</returns>
        public bool DAL_LoadByUsername(string sUsername)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drUserLoginAttempt = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserLoginAttemptGetByUsername", sUsername))
                {
                    if (drUserLoginAttempt.Read())
                    {
                        m_iUserLoginAttemptID = Convert.ToInt32(drUserLoginAttempt["PFS_USER_LOGIN_ATTEMPT_ID"]);
                        m_sUserName = Convert.ToString(drUserLoginAttempt["USER_NAME"]);
                        m_dtLastSuccessfullLoginDate = Convert.ToDateTime(drUserLoginAttempt["LAST_SUCCESSFULL_LOGIN_DATE"]);
                        m_dtLastFailedLoginDate = Convert.ToDateTime(drUserLoginAttempt["LAST_FAILED_LOGIN_DATE"]);
                        m_iTotalSuccess = Convert.ToInt32(drUserLoginAttempt["TOTAL_SUCCESS"]);
                        m_iTotalFailed = Convert.ToInt32(drUserLoginAttempt["TOTAL_FAILED"]);
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
    }
}
