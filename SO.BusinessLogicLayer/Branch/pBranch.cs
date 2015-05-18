using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PFSHelper.DataAccessLayer;
using System.Data.SqlClient;

namespace SO.BusinessLogicLayer
{
    public partial class Branch
    {
        #region Data Access Layer

        public bool DAL_LoadByBranchCode(string p_sBranchCode)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspCOM_BranchGetByCode", p_sBranchCode))
                {
                    if (dr.Read())
                    {
                        m_iBranchID = Convert.ToInt32(dr["COM_BRANCH_ID"]);
                        m_sBranchCode = Convert.ToString(dr["BRANCH_CODE"]);
                        m_sBranchName = Convert.ToString(dr["BRANCH_NAME"]);
                        m_sDescription = Convert.ToString(dr["DESCRIPTION"]);
                        m_bIsActive = Convert.ToBoolean(dr["IS_ACTIVE"]);
                        m_bIsDeleted = Convert.ToBoolean(dr["IS_DELETED"]);
                        m_dtCreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                        m_iCreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                        m_dtUpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                        m_iUpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
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

        #endregion
    }
}
