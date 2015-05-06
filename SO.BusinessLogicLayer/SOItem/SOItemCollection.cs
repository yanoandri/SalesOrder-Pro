using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;
using System.Collections;

namespace SO
{
    [System.Xml.Serialization.XmlRoot("SOItemItem")]
   public class SOItemCollection : ICollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////////////////
        private ArrayList m_oSOItemItemList = new ArrayList();
        #endregion

        #region Region: Properties///////////////////////////////////////////////////////////////////
        public int Count
        {
            get { return m_oSOItemItemList.Count; }
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
            get { return (SOItem)m_oSOItemItemList[index]; }
        }
        #endregion

        #region Region: List Method///////////////////////////////////////////////////////////////////
        public void Sort(IComparer oComparer)
        {
            m_oSOItemItemList.Sort(oComparer);
        }

        public void Reverse()
        {
            m_oSOItemItemList.Reverse();
        }

        public void Add(SOItem oSOItemItem)
        {
            m_oSOItemItemList.Add(oSOItemItem);
        }

        public void RemoveAt(int index)
        {
            m_oSOItemItemList.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            m_oSOItemItemList.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return m_oSOItemItemList.GetEnumerator();
        }
        #endregion

        #region Region: Field Enumeration /////////////////////////////////////////////////////
        public enum SOItemItemFields
        {
            SalesSoId,
            SalesOrderNo,
            OrderDate,
            CustomerName,
            Address,
            SalesItemId,
            ItemName,
            Quantity,
            Price
        }
        #endregion

        #region Region: Sort Method////////////////////////////////////////////////////////////
        public void Sort(SOItemItemFields SortField, bool isAscending)
        {
            switch (SortField)
            {
                case SOItemItemFields.SalesSoId:
                    this.Sort(new SOItemIDComparer());
                    break;
                case SOItemItemFields.SalesOrderNo:
                    this.Sort(new SoNoComparer());
                    break;
                case SOItemItemFields.OrderDate:
                    this.Sort(new OrderDateComparer());
                    break;
                case SOItemItemFields.CustomerName:
                    this.Sort(new CustomerNameComparer());
                    break;
                case SOItemItemFields.Address:
                    this.Sort(new AddressComparer());
                    break;
                case SOItemItemFields.SalesItemId:
                    this.Sort(new SalesItemIdComparer());
                    break;
                case SOItemItemFields.ItemName:
                    this.Sort(new ItemNameComparer());
                    break;
                case SOItemItemFields.Quantity:
                    this.Sort(new QuantityComparer());
                    break;
                case SOItemItemFields.Price:
                    this.Sort(new PriceComparer());
                    break;
            }
            if (!isAscending) this.Reverse();
        }
        #endregion

        #region Region: IComparer//////////////////////////////////////////////////////////////
        private sealed class SOItemIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.SalesSoId.CompareTo(second.SalesSoId);
            }
        }
        private sealed class SoNoComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.SalesOrderNo.CompareTo(second.SalesOrderNo);
            }
        }
        private sealed class OrderDateComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.OrderDate.CompareTo(second.OrderDate);
            }
        }
        private sealed class CustomerNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.CustomerName.CompareTo(second.CustomerName);
            }
        }
        private sealed class AddressComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.Address.CompareTo(second.Address);
            }
        }

        private sealed class SalesItemIdComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SOItem first = (SOItem)x;
                SOItem second = (SOItem)y;
                return first.SalesItemId.CompareTo(second.SalesItemId);
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
    }
}
