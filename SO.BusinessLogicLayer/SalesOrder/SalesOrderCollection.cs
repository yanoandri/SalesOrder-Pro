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
            CustomerId,
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
                case SalesOrderFields.CustomerId:
                    this.Sort(new CustomerIdComparer());
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
        private sealed class CustomerIdComparer : IComparer
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
        public bool DAL_Load(bool p_bIsIncludeChild = true)
        {
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_SalesRetrieve"))
                {
                    if (drSoList.HasRows)
                    {
                        while (drSoList.Read())
                        {
                            SalesOrder oSales = new SalesOrder();
                            oSales.SalesSoId = Convert.ToInt32(drSoList["SALES_SO_ID"]);
                            oSales.SalesOrderNo = drSoList["SO_NO"].ToString();
                            oSales.OrderDate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                            oSales.CustomerId = Convert.ToInt32(drSoList["COM_CUSTOMER_ID"]);
                            oSales.Address = drSoList["ADDRESS"].ToString();
                            if (p_bIsIncludeChild)
                            {
                                oSales.SOItemCollection.DAL_LoadbyId(oSales.SalesSoId);
                            }
                            this.Add(oSales);
                        }
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_Load(int iID, bool p_bIsIncludeChild = true)
        {
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_SalesRetrieve", iID))
                {
                    if (drSoList.HasRows)
                    {
                        while (drSoList.Read())
                        {
                            SalesOrder oSales = new SalesOrder();
                            oSales.SalesSoId = Convert.ToInt32(drSoList["SALES_SO_ID"]);
                            oSales.SalesOrderNo = drSoList["SO_NO"].ToString();
                            oSales.OrderDate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                            oSales.CustomerId = Convert.ToInt32(drSoList["COM_CUSTOMER_ID"]);
                            oSales.Address = drSoList["ADDRESS"].ToString();
                            if (p_bIsIncludeChild)
                            {
                                oSales.SOItemCollection.DAL_LoadbyId(iID);
                            }
                            this.Add(oSales);
                        }
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_Add()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Add(oTrans))
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_Add(SqlTransaction p_oTrans)
        {
            try
            {
                foreach (SalesOrder oSales in m_oSalesOrderList)
                {
                    if (!oSales.DAL_Add(p_oTrans)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_Update(bool p_bIsIncludeChild = true)
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Update(oTrans, p_bIsIncludeChild))
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_Update(SqlTransaction p_oTrans, bool p_bIsIncludeChild = true)
        {
            try
            {
                foreach (SalesOrder oSales in m_oSalesOrderList)
                {
                    if (!oSales.DAL_Update(p_oTrans, p_bIsIncludeChild)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_Delete()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Delete(oTrans))
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_Delete(SqlTransaction p_oTrans)
        {
            try
            {
                foreach (SalesOrder oSales in m_oSalesOrderList)
                {
                    if (!oSales.DAL_Delete(p_oTrans)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
