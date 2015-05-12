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
    [System.Xml.Serialization.XmlRoot("CustomerOrders")]
    public partial class CustomerCollection : ICollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////////////////
        private ArrayList m_oCustomerList = new ArrayList();
        #endregion

        #region Region: Properties///////////////////////////////////////////////////////////////////
        public int Count
        {
            get { return m_oCustomerList.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public Customer this[int index]
        {
            get { return (Customer)m_oCustomerList[index]; }
        }
        #endregion

        #region Region: List Method///////////////////////////////////////////////////////////////////
        public void Sort(IComparer oComparer)
        {
            m_oCustomerList.Sort(oComparer);
        }

        public void Reverse()
        {
            m_oCustomerList.Reverse();
        }

        public void Add(Customer oCustomer)
        {
            m_oCustomerList.Add(oCustomer);
        }

        public void RemoveAt(int index)
        {
            m_oCustomerList.RemoveAt(index);
        }

        public void CopyTo(Array array, int index)
        {
            m_oCustomerList.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return m_oCustomerList.GetEnumerator();
        }
        #endregion

        #region Region: Field Enumeration /////////////////////////////////////////////////////
        public enum CustomerFields
        {
            CustomerId,
            CustomerName
        }
        #endregion

        #region Region: Sort Method////////////////////////////////////////////////////////////
        public void Sort(CustomerFields SortField, bool isAscending)
        {
            switch (SortField)
            {
                case CustomerFields.CustomerId:
                    this.Sort(new CustomerIdComparer());
                    break;
                case CustomerFields.CustomerName:
                    this.Sort(new CustomerNameComparer());
                    break;
            }
            if (!isAscending) this.Reverse();
        }
        #endregion

        #region Region: IComparer//////////////////////////////////////////////////////////////
        private sealed class CustomerIdComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Customer first = (Customer)x;
                Customer second = (Customer)y;
                return first.CustomerId.CompareTo(second.CustomerId);
            }
        }
        private sealed class CustomerNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Customer first = (Customer)x;
                Customer second = (Customer)y;
                return first.CustomerName.CompareTo(second.CustomerName);
            }
        }
        #endregion

        #region Region: Data Access Methods//////////////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drCustomerList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_CustomerLoad"))
                {
                    if (drCustomerList.HasRows)
                    {
                        while (drCustomerList.Read())
                        {
                            Customer oCustomer = new Customer();
                            oCustomer.CustomerId = Convert.ToInt32(drCustomerList["COM_CUSTOMER_ID"]);
                            oCustomer.CustomerName = drCustomerList["CUSTOMER_NAME"].ToString();
                            this.Add(oCustomer);
                        }
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
