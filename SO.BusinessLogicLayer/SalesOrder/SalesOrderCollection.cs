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

        #region Region: Field Enumeration /////////////////////////////////////////////////////
        public enum SalesOrderFields
        {
            SalesSoId,
            SalesOrderNo,
            OrderDate,
            CustomerName,
            Address
        }
        #endregion

        #region Region: Sort Method////////////////////////////////////////////////////////////
        public void Sort(SalesOrderFields sortField, bool isAscending)
        {
            switch (sortField)
            {
                case SalesOrderFields.SalesSoId:
                    this.Sort(new SalesOrderIDComparer());
                    break;
                case SalesOrderFields.SalesOrderNo:
                    this.Sort(new SoNoComparer());
                    break;
                case SalesOrderFields.OrderDate:
                    this.Sort(new OrderDateComparer());
                    break;
                case SalesOrderFields.CustomerName:
                    this.Sort(new CustomerNameComparer());
                    break;
                case SalesOrderFields.Address:
                    this.Sort(new AddressComparer());
                    break;
            }
            if (!isAscending) this.Reverse();
        }
        #endregion

        #region Region: IComparer//////////////////////////////////////////////////////////////
        private sealed class SalesOrderIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SalesOrder first = (SalesOrder)x;
                SalesOrder second = (SalesOrder)y;
                return first.SalesSoId.CompareTo(second.SalesSoId);
            }
        }
        private sealed class SoNoComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SalesOrder first = (SalesOrder)x;
                SalesOrder second = (SalesOrder)y;
                return first.SalesOrderNo.CompareTo(second.SalesOrderNo);
            }
        }
        private sealed class OrderDateComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SalesOrder first = (SalesOrder)x;
                SalesOrder second = (SalesOrder)y;
                return first.OrderDate.CompareTo(second.OrderDate);
            }
        }
        private sealed class CustomerNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SalesOrder first = (SalesOrder)x;
                SalesOrder second = (SalesOrder)y;
                return first.CustomerId.CompareTo(second.CustomerId);
            }
        }
        private sealed class AddressComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SalesOrder first = (SalesOrder)x;
                SalesOrder second = (SalesOrder)y;
                return first.Address.CompareTo(second.Address);
            }
        }
        #endregion

        #region Region: Data Access Layer///////////////////////////////////////////////////////////////////
        public bool GetSalesOrderList()
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

        public bool GetSalesOrderList(string p_sKeyword,
            DateTime? p_dtOrderDate)
        {
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_showlist",
                    p_sKeyword,
                    p_dtOrderDate))
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
