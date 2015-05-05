using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class UserGroup
    {
        public bool DAL_CheckDuplicate(
            int p_iUserID,
            int p_iGroupID)
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserGroupCheckDuplicate",
                    p_iUserID, p_iGroupID))
                {
                    if (dr.Read())
                    {
                        m_iGroupID = Convert.ToInt32(dr["PFS_GROUP_ID"]);

                        dr.Close();
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
                throw ex;
            }
        }
        public bool DAL_DeleteByUserID(SqlTransaction p_oTrans)
        {
            try
            {
                int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(PFSDataBaseAccess.ConnectionString, "uspPFS_UserGroupDelete",
                    null,
                    m_iUserID,
                    null));

                return (iError == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
