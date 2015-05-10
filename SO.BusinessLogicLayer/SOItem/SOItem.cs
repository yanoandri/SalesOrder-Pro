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
    public partial class SOItem
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        protected int m_iItemId = 0;
        protected int m_iSoId = 0;
        protected string m_sItemName = "-";
        protected int m_iQuantity = 0;
        protected Double m_dPrice = 0;
        #endregion

        #region Region: Constructor///////////////////////////////////////////////////////
        public SOItem()
        {
            m_iSoId = -1;
        }
        public SOItem(int iID)
        {
            m_iSoId = iID;
        }

        public SOItem(
            int p_iItemId,
            int p_iSoId,
            string p_sItemName,
            int p_iQuantity,
            float p_fPrice)
        {
            
            m_iItemId = p_iItemId;
            m_iSoId = p_iSoId;
            m_sItemName = p_sItemName;
            m_iQuantity = p_iQuantity;
            m_dPrice = p_fPrice;
        }
        #endregion

        #region Region: Properties///////////////////////////////////////////////////////
        public int SalesItemId
        {
            get { return m_iItemId; }
            set { m_iItemId = value; }
        }
        public int SoId
        {
            get { return m_iSoId; }
            set { m_iSoId = value; }
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
        public Double Price
        {
            get { return m_dPrice; }
            set { m_dPrice = value; }
        }
        #endregion

        #region Region: Data Access Methods///////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drItemList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_ItemLoad", m_iSoId))
                {
                    if (drItemList.Read())
                    {
                        m_iItemId = Convert.ToInt32(drItemList["SALES_SO_LITEM_ID"]);
                        m_iSoId = Convert.ToInt32(drItemList["SALES_SO_ID"]);
                        m_sItemName = drItemList["ITEM_NAME"].ToString();
                        m_iQuantity = Convert.ToInt32(drItemList["QUANTITY"]);
                        m_dPrice = Convert.ToDouble(drItemList["PRICE"]);
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
        public bool DAL_LoadById(int iID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drItemList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_RetrieveSalesOrder", iID))
                {
                    if (drItemList.Read())
                    {
                        m_iItemId = Convert.ToInt32(drItemList["SALES_SO_LITEM_ID"]);
                        m_iSoId = Convert.ToInt32(drItemList["SALES_SO_ID"]);
                        m_sItemName = drItemList["ITEM_NAME"].ToString();
                        m_iQuantity = Convert.ToInt32(drItemList["QUANTITY"]);
                        m_dPrice = Convert.ToDouble(drItemList["PRICE"]);
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
                m_iItemId = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspSO_ItemInsert",
                    m_iSoId,
                    m_sItemName,
                    m_iQuantity,
                    m_dPrice
                    ));
                if (m_iItemId < 1) return false;
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
        public bool DAL_Update(SqlTransaction p_oTrans)
        {
            try
            {
                if (m_iItemId > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspSO_ItemUpdate",
                        m_sItemName,
                        m_iQuantity,
                        m_dPrice
                    ));
                    if (iError != 0) return false;
                }
                else return DAL_Add(p_oTrans);

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
        public bool DAL_Delete(SqlTransaction p_oTrans)
        {
            try
            {
                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspSO_ItemDelete", m_iItemId);
                return (iRowAffected > 0);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
