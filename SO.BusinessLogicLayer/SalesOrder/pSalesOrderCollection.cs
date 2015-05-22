using System;
using System.Data;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace SO.BusinessLogicLayer
{
    public partial class SalesOrderCollection
    {
        /// <summary>
        /// Partial Properties for SalesOrderCollection
        /// </summary>
        public bool DAL_RetrievebyId(int iID, bool p_bIsIncludeChild = true)
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
                            oSales.SalesOrderNo = drSoList["SO_NO"].ToString();
                            oSales.OrderDate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                            oSales.CustomerName = drSoList["CUSTOMER_NAME"].ToString();
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
        public bool DAL_RetrievebyId(bool p_bIsIncludeChild = true)
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
                            oSales.SalesOrderNo = drSoList["SO_NO"].ToString();
                            oSales.OrderDate = Convert.ToDateTime(drSoList["ORDER_DATE"]);
                            oSales.CustomerName = drSoList["CUSTOMER_NAME"].ToString();
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
        public bool DAL_LoadSalesbyKeyDate()
        {
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, CommandType.StoredProcedure, "uspSO_SalesShowList"))
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
        public bool DAL_LoadSalesbyKeyDate(string p_sKeyword,
            DateTime? p_dtOrderDate)
        {
            try
            {
                using (SqlDataReader drSoList = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspSO_SalesShowList",
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
    }
}
