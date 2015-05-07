﻿using System;
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
        private SOItemCollection m_oSOItemCollection = null;

        
        protected int m_iSoid = 0;
        protected string m_sSono = "-";
        protected DateTime m_dtOrderDate = DateTime.Parse("01/01/1900");
        protected string m_sCustomerName = "-";
        protected int m_sCustomerId = 0;
        protected string m_sAddress = "-";
        #endregion

        #region Region: Constructor///////////////////////////////////////////////////////
        public SalesOrder()
        {
            m_oSOItemCollection = new SOItemCollection();
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
        public int CustomerId
        {
            get { return m_sCustomerId; }
            set { m_sCustomerId = value; }
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
        public SOItemCollection SOItemCollection
        {
            get { return m_oSOItemCollection; }
            set { m_oSOItemCollection = value; }
        }
        #endregion

        #region Region: Data Access Method///////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_showlist", CommandType.StoredProcedure, m_iSoid))
                {
                    if (drSoList.Read())
                    {
                        m_iSoid = Convert.ToInt32(drSoList["SALES_SO_ID"]);
                        m_sSono = drSoList["SO_NO"].ToString();
                        m_sCustomerName = drSoList["CUSTOMER_NAME"].ToString();
                        m_sAddress = drSoList["ADDRESS"].ToString();
                        bIsSuccess = true;
                    }
                    return bIsSuccess;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_Load(int iID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_showlist", CommandType.StoredProcedure, iID))
                {
                    if (drSoList.Read())
                    {
                        m_iSoid = Convert.ToInt32(drSoList["SALES_SO_ID"]);
                        m_sSono = drSoList["SO_NO"].ToString();
                        m_sCustomerName = drSoList["CUSTOMER_NAME"].ToString();
                        m_sAddress = drSoList["ADDRESS"].ToString();
                        bIsSuccess = true;
                    }
                    return bIsSuccess;
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
            catch (SqlException ex)
            {
                oTrans.Rollback();
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
                m_iSoid = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspSO_insertSO",
                    m_sSono,
                    m_dtOrderDate,
                    m_sCustomerId,
                    m_sAddress
                ));
                if (m_iSoid < 1) return false;
                #region Add appropriate child
                for (int i = 0; i < m_oSOItemCollection.Count; i++)
                {
                    m_oSOItemCollection[i].SalesSoId = m_iSoid;
                }
                if (!m_oSOItemCollection.DAL_Add(p_oTrans)) return false;
                #endregion
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
                if (DAL_Delete(oTrans) != 0)
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
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public int DAL_Delete(SqlTransaction p_oTrans)
        {
            try
            {
                int iResult = SqlHelper.ExecuteNonQuery(p_oTrans, "uspSO_deleteso", m_iSoid);
                return iResult;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
        #endregion