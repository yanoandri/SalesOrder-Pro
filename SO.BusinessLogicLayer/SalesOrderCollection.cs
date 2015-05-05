using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;
using System.Collections;

namespace SO.BusinessLogicLayer
{
    [System.Xml.Serialization.XmlRoot("SalesOrders")]
    public partial class SalesOrderCollection : ICollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////////////////
        private ArrayList m_oSalesOrderList = new ArrayList();
        #endregion

        #region Region: Constructor///////////////////////////////////////////////////////////////////
        public SalesOrderCollection()
        {
        }
        #endregion 

        #region Region: Properties///////////////////////////////////////////////////////////////////
        public int Count
        {
            get { return m_oSalesOrderList.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public SalesOrder this[int index]
        {
            get { return (SalesOrder)m_oSalesOrderList[index]; }
        }
        #endregion

        #region Region: List Method///////////////////////////////////////////////////////////////////
        public void Sort(IComparer oComparer)
        {
            m_oSalesOrderList.Sort(oComparer);
        }

        public void Reverse()
        {
            m_oSalesOrderList.Reverse();
        }

        public void Add(SalesOrder oSalesOrder)
        {
            m_oSalesOrderList.Add(oSalesOrder);
        }

        public void RemoveAt(int index)
        {
            m_oSalesOrderList.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            m_oSalesOrderList.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return m_oSalesOrderList.GetEnumerator();
        }
        #endregion

        #region Region: Field Enumeration///////////////////////////////////////////////////////////////////

        #endregion

        #region Region: Data Access Methods///////////////////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, CommandType.StoredProcedure, "uspSO_showlist"))
                {
                    if (drSoList.HasRows)
                    {
                        while (drSoList.Read())
                        {
                            SalesOrder oSalesOrder = new SalesOrder();
                            oSalesOrder.SalesSoId = Convert.ToInt32(drSoList["SALES_SO_ID"]);
                            oSalesOrder.SalesOrderNo = drSoList["SO_NO"].ToString();
                            oSalesOrder.OrderDate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                            oSalesOrder.CustomerName = drSoList["CUSTOMER_NAME"].ToString();
                            oSalesOrder.Address = drSoList["ADDRESS"].ToString();
                            this.Add(oSalesOrder);
                        }
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
        #endregion
    }
}
