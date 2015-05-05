using System;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class UserLogCollection
    {
        public bool DAL_LoadWithModuleName(
            string sKeyWords,
            string p_sUserName,
            object dtLogDateFrom,
            object dtLogDateTo,
            object iModuleObjectMemberID)
        {
            try
            {

                using (SqlDataReader drUserLog = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, 
                    "uspPFS_UserLogListWithModuleName",
                    sKeyWords,
                    p_sUserName,
                    dtLogDateFrom,
                    dtLogDateTo,
                    iModuleObjectMemberID
                    ))
                {
                    if (drUserLog.HasRows)
                    {
                        while (drUserLog.Read())
                        {
                            UserLog oUserLog = new UserLog();
                            oUserLog.UserLogID = Convert.ToInt64(drUserLog["PFS_USER_LOG_ID"]);
                            oUserLog.UserName = Convert.ToString(drUserLog["USER_NAME"]);
                            oUserLog.ReferenceNumber = Convert.ToString(drUserLog["REFERENCE_NUMBER"]);
                            oUserLog.IpAddress = Convert.ToString(drUserLog["IP_ADDRESS"]);
                            oUserLog.LogDate = Convert.ToDateTime(drUserLog["LOG_DATE"]);
                            oUserLog.Description = Convert.ToString(drUserLog["DESCRIPTION"]);
                            oUserLog.Detail = Convert.ToString(drUserLog["DETAIL"]);
                            oUserLog.Status = Convert.ToInt16(drUserLog["STATUS"]);
                            oUserLog.ModuleObjectMemberID = Convert.ToInt32(drUserLog["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oUserLog.UserID = Convert.ToInt32(drUserLog["PFS_USER_ID"]);
                            oUserLog.UserName = Convert.ToString(drUserLog["USER_NAME"]);
                            oUserLog.FullName = Convert.ToString(drUserLog["FULL_NAME"]);
                            oUserLog.MemberCode = Convert.ToString(drUserLog["MEMBER_CODE"]);
                            oUserLog.MemberName = Convert.ToString(drUserLog["MEMBER_NAME"]);
                            oUserLog.ObjectID = Convert.ToInt32(drUserLog["PFS_MODULE_OBJECT_ID"]);
                            oUserLog.ObjectName = Convert.ToString(drUserLog["OBJECT_NAME"]);
                            oUserLog.ModuleID = Convert.ToInt32(drUserLog["PFS_MODULE_ID"]);
                            oUserLog.ModuleName = Convert.ToString(drUserLog["MODULE_NAME"]);
                            this.Add(oUserLog);
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

        public bool LoadByUserID(int p_iUserID)
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, 
                    "uspPFSHelper_UserLogLoadByUserID",
                    p_iUserID))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserLog oUserLog = new UserLog();

                            oUserLog.UserLogID = Convert.ToInt64(dr["PFS_USER_LOG_ID"]);
                            oUserLog.UserName = Convert.ToString(dr["USER_NAME"]);
                            oUserLog.ReferenceNumber = Convert.ToString(dr["REFERENCE_NUMBER"]);
                            oUserLog.IpAddress = Convert.ToString(dr["IP_ADDRESS"]);
                            oUserLog.LogDate = Convert.ToDateTime(dr["LOG_DATE"]);
                            oUserLog.Description = Convert.ToString(dr["DESCRIPTION"]);
                            oUserLog.Detail = Convert.ToString(dr["DETAIL"]);
                            oUserLog.Status = Convert.ToInt16(dr["STATUS"]);
                            oUserLog.ModuleObjectMemberID = Convert.ToInt32(dr["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oUserLog.MemberCode = Convert.ToString(dr["MEMBER_CODE"]);
                            oUserLog.MemberName = Convert.ToString(dr["MEMBER_NAME"]);
                            this.Add(oUserLog);
                        }
                        return true;
                    }
                    else return false;
                }
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
                if (PurgeData(oTrans))
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
            catch (Exception ex)
            {
                throw ex;
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
                foreach (UserLog oUserLog in m_oUserLogList)
                {
                    oUserLog.IsPurge = true;

                    if (!oUserLog.PurgeData(p_oTrans)) return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
