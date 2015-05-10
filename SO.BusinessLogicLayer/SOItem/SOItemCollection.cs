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
    [System.Xml.Serialization.XmlRoot("ItemOrders")]
    public partial class SOItemCollection : ICollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////////////////
        private ArrayList m_oItemList = new ArrayList();
        #endregion

        #region Region: Properties///////////////////////////////////////////////////////////////////
        public int Count
        {
            get { return m_oItemList.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public SOItem this[int index]
        {
            get { return (SOItem)m_oItemList[index]; }
        }
        #endregion

        #region Region: List Method///////////////////////////////////////////////////////////////////
        public void Sort(IComparer oComparer)
        {
            m_oItemList.Sort(oComparer);
        }

        public void Reverse()
        {
            m_oItemList.Reverse();
        }

        public void Add(SOItem oItem)
        {
            m_oItemList.Add(oItem);
        }

        public void RemoveAt(int index)
        {
            m_oItemList.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            m_oItemList.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return m_oItemList.GetEnumerator();
        }
        #endregion

        #region Region: Field Enumeration /////////////////////////////////////////////////////
        public enum SOItemFields
        {
            SalesItemId,
            SalesSoId,
            ItemName,
            Quantity,
            Price
        }
        #endregion

        #region Region: Sort Method////////////////////////////////////////////////////////////
        public void Sort(SOItemFields SortField, bool isAscending)
        {
            switch (SortField)
            {
                case SOItemFields.SalesItemId:
                    this.Sort(new SoItemIdComparer());
                    break;
                case SOItemFields.SalesSoId:
                    this.Sort(new SoIdComparer());
                    break;
                case SOItemFields.ItemName:
                    this.Sort(new ItemNameComparer());
                    break;
                case SOItemFields.Quantity:
                    this.Sort(new QuantityComparer());
                    break;
                case SOItemFields.Price:
                    this.Sort(new PriceComparer());
                    break;
            }
            if (!isAscending) this.Reverse();
        }
        #endregion

        #region Region: IComparer//////////////////////////////////////////////////////////////
        private sealed class SoItemIdComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.SalesItemId.CompareTo(second.SalesItemId);
            }
        }
        private sealed class SoIdComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.SoId.CompareTo(second.SoId);
            }
        }

        private sealed class ItemNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.ItemName.CompareTo(second.ItemName);
            }
        }

        private sealed class QuantityComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.Quantity.CompareTo(second.Quantity);
            }
        }

        private sealed class PriceComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.Price.CompareTo(second.Price);
            }
        }
        #endregion

        #region Region: Data Access Methods//////////////////////////////////////////////////////////////

        public bool DAL_LoadbyId()
        {
            try
            {
                using (SqlDataReader drItemList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, CommandType.StoredProcedure, "uspSO_detailItem"))
                {
                    if (drItemList.HasRows)
                    {
                        while (drItemList.Read())
                        {
                            SOItem oSOItem = new SOItem();
                            oSOItem.SalesItemId = Convert.ToInt32(drItemList["SALES_SO_LITEM_ID"]);
                            oSOItem.ItemName = drItemList["ITEM_NAME"].ToString();
                            oSOItem.Quantity = Convert.ToInt32(drItemList["QUANTITY"]);
                            oSOItem.Price = Convert.ToInt32(drItemList["PRICE"]);
                            this.Add(oSOItem);
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
        public bool DAL_LoadbyId(int p_iItemId)
        {
            try
            {
                using (SqlDataReader drItemList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_ItemLoad", p_iItemId))
                {
                    if (drItemList.HasRows)
                    {
                        while (drItemList.Read())
                        {
                            SOItem oItem = new SOItem();
                            oItem.SalesItemId = Convert.ToInt32(drItemList["SALES_SO_LITEM_ID"]);
                            oItem.ItemName = drItemList["ITEM_NAME"].ToString();
                            oItem.Quantity = Convert.ToInt32(drItemList["QUANTITY"]);
                            oItem.Price = Convert.ToInt32(drItemList["PRICE"]);
                            this.Add(oItem);
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
                foreach (SOItem oItem in m_oItemList)
                {
                    if (!oItem.DAL_Add(p_oTrans)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_Update()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Update(oTrans))
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
        public bool DAL_Update(SqlTransaction p_oTrans)
        {
            try
            {
                foreach (SOItem oItem in m_oItemList)
                {
                    if (!oItem.DAL_Update(p_oTrans)) return false;
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
                foreach (SOItem oItem in m_oItemList)
                {
                    if (!oItem.DAL_Delete(p_oTrans)) return false;
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
