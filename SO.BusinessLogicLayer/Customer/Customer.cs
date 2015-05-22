using System;
using System.Data;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace SO.BusinessLogicLayer
{
    public partial class Customer
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        protected int m_iCustomerId = 0;
        protected string m_sCustomerName = "-";
        #endregion

        #region Region: Constructor///////////////////////////////////////////////////////
        public Customer()
        {
            m_iCustomerId = -1;
        }
        public Customer(int iID)
        {
            m_iCustomerId = iID;
        }

        public Customer(
            int p_iCustomerId,
            string p_sCustomerName)
        {
            m_iCustomerId = p_iCustomerId;
            m_sCustomerName = p_sCustomerName;
        }
        #endregion

        #region Region: Properties///////////////////////////////////////////////////////
        public int CustomerId
        {
            get { return m_iCustomerId; }
            set { m_iCustomerId = value; }
        }
        public string CustomerName
        {
            get { return m_sCustomerName; }
            set { m_sCustomerName = value; }
        }
        #endregion

        #region Region: Data Access Methods///////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drCustomerList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, CommandType.StoredProcedure, "uspSO_CustomerLoad"))
                {
                    if (drCustomerList.Read())
                    {
                        m_iCustomerId = Convert.ToInt32(drCustomerList["COM_CUSTOMER_ID"]);
                        m_sCustomerName = drCustomerList["CUSTOMER_NAME"].ToString();
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
