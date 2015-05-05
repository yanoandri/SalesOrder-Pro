using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;
using System.Data.SqlTypes;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class UserDetail
    {
        public bool DAL_LoadByUserID()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserDetailGetByUserID", m_iUserID))
                {
                    if (dr.Read())
                    {
                        m_iUserDetailID = Convert.ToInt32(dr["PFS_USER_DETAIL_ID"]);
                        m_iUserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                        m_sUserCode = Convert.ToString(dr["USER_CODE"]);
                        m_sBranchCode = Convert.ToString(dr["BRANCH_CODE"]);
                        m_sDepartmentName = Convert.ToString(dr["DEPARTMENT_NAME"]);
                        m_sPosition = Convert.ToString(dr["POSITION"]);
                        m_dtDob = Convert.ToDateTime(dr["DOB"]);
                        m_sHomeNumber = Convert.ToString(dr["HOME_NUMBER"]);
                        m_sWorkNumber = Convert.ToString(dr["WORK_NUMBER"]);
                        m_sMobileNumber = Convert.ToString(dr["MOBILE_NUMBER"]);
                        //m_byPicture = (SqlBinary)(dr["PICTURE"]);
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
    }
}
