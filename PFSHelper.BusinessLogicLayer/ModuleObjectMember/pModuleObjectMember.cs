using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class ModuleObjectMember
    {
        public static bool CheckIsWithApproval(int ModuleObjectMemberID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberGet", ModuleObjectMemberID))
                {
                    if (dr.Read())
                    {
                        bIsSuccess = Convert.ToBoolean(dr["IS_WITH_APPROVAL_PROCCESS"]);
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
