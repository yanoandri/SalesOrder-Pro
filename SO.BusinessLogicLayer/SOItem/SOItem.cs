using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace SO
{
    public class SOItem
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        protected int m_iSoid = 0;
        protected string m_sSono = "-";
        protected DateTime m_dtOrderDate = DateTime.Parse("01/01/1900");
        protected string m_sCustomerName = "-";
        protected string m_sAddress = "-";
        protected int m_iItemId = 0;
        protected string m_sItemName = "-";
        protected int m_iQuantity = 0;
        protected float m_fPrice = 0;
        #endregion

        #region Region: Constructor///////////////////////////////////////////////////////
        public SOItem()
        {
            m_iSoid = -1;
        }

        public SOItem(int iID)
        {
            m_iSoid = iID;
        }

        public SOItem(
            int p_iSoid,
            string p_sSono,
            DateTime p_dtOrderDate,
            string p_sCustomerName,
            string p_sAddress,
            int p_iItemId,
            string p_sItemName,
            int p_iQuantity,
            float p_fPrice)
        {
            m_iSoid = p_iSoid;
            m_sSono = p_sSono;
            m_dtOrderDate = p_dtOrderDate;
            m_sCustomerName = p_sCustomerName;
            m_sAddress = p_sAddress;
            m_iItemId = p_iItemId;
            m_sItemName = p_sItemName;
            m_iQuantity = p_iQuantity;
            m_fPrice = p_fPrice;
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
        public int SalesItemId
        {
            get { return m_iItemId; }
            set { m_iItemId = value; }
        }
        public string ItemName
        {
            get { return m_sItemName; }
            set { m_sItemName = value; }
        }
        public int Quantity
        {
            get { return m_iQuantity; }
            set { m_iQuantity = value; }
        }
        public float Price
        {
            get { return m_fPrice; }
            set { m_fPrice = value; }
        }
        #endregion
    }
}
