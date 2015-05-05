using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace SO.BusinessLogicLayer
{
    public class SOCollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        protected int m_iSoid;
        protected string m_sSono;
        public DateTime m_dtOrderdate;
        public string m_sCustomerName;
        protected string m_sAddress;
        #endregion

        #region Region: Constructor///////////////////////////////////////////////////////
        public SOCollection()
        {
        }
        #endregion

        #region Region: Properties///////////////////////////////////////////////////////
        public int Soid
        {
            get { return m_iSoid; }
            set { m_iSoid = value; }
        }
        public string Sono
        {
            get { return m_sSono; }
            set { m_sSono = value; }
        }
        public DateTime OrderDate
        {
            get { return m_dtOrderdate; }
            set { m_dtOrderdate = value; }
        }
        public string CustomerName
        {
            get { return m_sCustomerName; }
            set { m_sCustomerName = value; }
        }
        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }
        #endregion

        #region Region: Data Access Methods///////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            try
            {
                bool bIsSuccess = false;
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, CommandType.StoredProcedure, "uspSO_showlist"))
                {
                    if (drSoList.HasRows)
                    {
                        while (drSoList.Read())
                        {
                            m_iSoid = Convert.ToInt32(drSoList["SALES_SO_ID"]);
                            m_sSono = drSoList["SO_NO"].ToString();
                            m_dtOrderdate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                            m_sCustomerName = drSoList["CUSTOMER_NAME"].ToString();
                            m_sAddress = drSoList["ADDRESS"].ToString();
                            bIsSuccess = true;
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
        #endregion





    }
}
