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
    public partial class SalesOrder
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        protected int m_iSoid = 0;
        protected string m_sSono = "-";
        protected DateTime m_dtOrderDate = DateTime.Parse("01/01/1900");
        protected string m_sCustomerName = "-";
        protected string m_sAddress = "-";
        #endregion

        #region Region: Constructor///////////////////////////////////////////////////////
        public SalesOrder()
        {
            m_iSoid = -1;
        }

        public SalesOrder(int iID)
        {
            m_iSoid = iID;
        }

        public SalesOrder(
            int p_iSoid,
            string p_sSono,
            DateTime p_dtOrderDate,
            string p_sCustomerName,
            string p_sAddress)
        {
            m_iSoid = p_iSoid;
            m_sSono = p_sSono;
            m_dtOrderDate = p_dtOrderDate;
            m_sCustomerName = p_sCustomerName;
            m_sAddress = p_sAddress;
        }

        #endregion

        #region Region: Properties///////////////////////////////////////////////////////
        public int SalesSoId
        {
            get { return m_iSoid; }
            set { m_iSoid = value; }
        }
        public string SalesOrderNo
        {
            get { return m_sSono; }
            set { m_sSono = value; }
        }
        public DateTime OrderDate
        {
            get { return m_dtOrderDate; }
            set { m_dtOrderDate = value; }
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





    }
}
