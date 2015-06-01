using System;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace SO.BusinessLogicLayer
{
    public partial class SalesOrder
    {
        /// <summary>
        /// Partial Properties for SalesOrder
        /// </summary>
        /// 

        #region Region: Member Variables///////////////////////////////////////////////////////
        protected string m_sCustomerName = "-";
        #endregion

        #region Region: Properties///////////////////////////////////////////////////////
        public string CustomerName
        {
            get { return m_sCustomerName; }
            set { m_sCustomerName = value; }
        }
        #endregion

        #region Region: Data Access Method///////////////////////////////////////////////////////
        public bool DAL_RetrieveId(bool bWithChild = true)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_SalesRetrieve", m_iSoid))
                {
                    if (drSoList.Read())
                    {
                        m_sSono = drSoList["SO_NO"].ToString();
                        m_dtOrderDate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                        m_sCustomerId = Convert.ToInt32(drSoList["COM_CUSTOMER_ID"]);
                        m_sAddress = drSoList["ADDRESS"].ToString();
                        bIsSuccess = true;
                        if (bWithChild)
                        {
                            m_oSOItemCollection.DAL_LoadbyId(m_iSoid);
                        }
                    }
                    return bIsSuccess;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_RetrieveId(int iID, bool bWithChild = true)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_SalesRetrieve", iID))
                {
                    if (drSoList.Read())
                    {
                        m_sSono = drSoList["SO_NO"].ToString();
                        m_dtOrderDate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                        m_sCustomerId = Convert.ToInt32(drSoList["COM_CUSTOMER_ID"]);
                        m_sAddress = drSoList["ADDRESS"].ToString();
                        bIsSuccess = true;
                        if (bWithChild)
                        {
                            m_oSOItemCollection.DAL_LoadbyId(iID);
                        }
                    }
                    return bIsSuccess;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_DeleteFullSO()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_DeleteFullSO(oTrans))
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
        public bool DAL_DeleteFullSO(SqlTransaction p_oTrans)
        {
            try
            {
                int iResult = SqlHelper.ExecuteNonQuery(p_oTrans, "uspSO_SalesFullDelete", m_iSoid);
                return (iResult > 0);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
