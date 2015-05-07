using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SO.BusinessLogicLayer;
using System.Collections.Generic;
using PFSHelper.Lib;

namespace SO
{
    public partial class SOInput2 : System.Web.UI.Page
    {
        #region session and public variable
        public string m_strcn = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;

        public DataRow m_drInitTable = null;

        public int m_SOID
        {
            get { return (Session["Edit"]) == null ? 0 : (int)Session["Edit"]; }
            set { Session["Edit"] = value; }
        }

        public int m_soItemId
        {
            get { return (ViewState["SOITEMID"]) == null ? 0 : (int)ViewState["SOITEMID"]; }
            set { ViewState["SOITEMID"] = value; }
        }

        public SalesOrder m_sessSalesOrder
        {
            get { return (Session["sessSalesOrder"]) == null ? new SalesOrder() : (SalesOrder)Session["sessSalesOrder"]; }
            set { Session["sessSalesOrder"] = value; }
        }

        #endregion session and public variable
        
        #region page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    if (m_SOID != 0)
                    {
                        RetrieveSalesOrderData();
                        GridInput.DataSource = GetItemCollection();
                        GridInput.DataBind();
                        
                    }

                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                setInitialRow();
                GridInput.DataSource = m_sessSalesOrder.SOItemCollection;
                GridInput.DataBind();
                btnAdd.Visible = false;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                if (m_SOID != 0)
                {
                    GridInput.EditIndex = -1;
                }
                else
                {
                    m_sessSalesOrder.SOItemCollection.RemoveAt(e.RowIndex);
                }
                GridInput.DataSource = m_sessSalesOrder.SOItemCollection;
                GridInput.DataBind();
                btnAdd.Visible = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridInput.EditIndex = e.NewEditIndex;
                GridInput.DataSource = m_sessSalesOrder;
                GridInput.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Double dGrandtotal = 0;
        protected void GridInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Label lblquantity = (Label)e.Row.FindControl("lblqty");
                Label lblprice = (Label)e.Row.FindControl("lblprice");
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label lblOrder = (Label)e.Row.FindControl("lblUrut");
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                    if (lblquantity == null || lblprice == null)
                    {
                    }
                    else
                    {
                        lblTotal.Text = (Convert.ToInt64(lblquantity.Text) * Convert.ToDouble(lblprice.Text)).ToString("#,##0.##");
                        dGrandtotal += Convert.ToDouble(lblTotal.Text);
                    }
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                    lblGrandTotal.Text = dGrandtotal.ToString("#,##0.##");
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                TextBox txtItem = (TextBox)GridInput.Rows[e.RowIndex].Cells[1].FindControl("txtItem");
                TextBox txtQty = (TextBox)GridInput.Rows[e.RowIndex].Cells[2].FindControl("txtQty");
                TextBox txtPrice = (TextBox)GridInput.Rows[e.RowIndex].Cells[3].FindControl("txtprice");
                GridViewRow rGridRow = GridInput.Rows[e.RowIndex];
                m_sessSalesOrder.SOItemCollection[rGridRow.DataItemIndex].ItemName = txtItem.Text;
                m_sessSalesOrder.SOItemCollection[rGridRow.DataItemIndex].Quantity = Convert.ToInt32(txtQty.Text);
                m_sessSalesOrder.SOItemCollection[rGridRow.DataItemIndex].Price = Convert.ToDouble(txtPrice.Text);
                GridInput.EditIndex = -1;
                GridInput.DataSource = m_sessSalesOrder.SOItemCollection;
                GridInput.DataBind();
                btnAdd.Visible = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                m_sessSalesOrder.SOItemCollection.RemoveAt(e.RowIndex - 1);
                GridInput.DataSource = m_sessSalesOrder.SOItemCollection;
                GridInput.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    int iNoUrut = Convert.ToInt32(e.CommandArgument);
                    GridInput.DeleteRow(iNoUrut);
                    GridInput.DataSource = m_sessSalesOrder.SOItemCollection;
                    GridInput.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                insertData();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Session.RemoveAll();
                Response.Redirect("SOList.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion page event

        #region method
        private void setInitialRow()
        {
           
            m_soItemId -= 1;
            if (m_sessSalesOrder.SOItemCollection.Count < 1)
            {
                m_sessSalesOrder.SOItemCollection.Add(new SOItem());
                int iRowCount = m_sessSalesOrder.SOItemCollection.Count;
                //m_sessSalesOrder.SOItemCollection[0].NoUrut = 1;
                //m_sessSalesOrder.SOItemCollection[0].SalesItemId = m_soItemId;
                GridInput.SetEditRow(iRowCount);
            }
            else if (m_sessSalesOrder.SOItemCollection.Count >= 1)
            {
                int iRowCount = m_sessSalesOrder.SOItemCollection.Count;
                m_sessSalesOrder.SOItemCollection[0].SalesItemId = m_soItemId;
                GridInput.SetEditRow(iRowCount);
            }
        }

        private void insertData()
        {
            SalesOrder oSalesOrder = m_sessSalesOrder;
            oSalesOrder.SalesOrderNo = txtSales.Text;
            oSalesOrder.OrderDate = Convert.ToDateTime(txtDate.Text);
            oSalesOrder.CustomerId = Convert.ToInt32(DDLCustomer.SelectedValue);
            oSalesOrder.Address = txtaddres.Text;            
            //SOItemCollection oItemCollection = new SOItemCollection();
            oSalesOrder.DAL_Add();
            Response.Redirect("SOList.aspx");
            //SqlConnection cnInsertData = new SqlConnection(m_strcn);
            //cnInsertData.Open();
            //SqlCommand cmdInsertSO = new SqlCommand("uspSO_insertSO", cnInsertData);
            //cmdInsertSO.CommandType = CommandType.StoredProcedure;
            //cmdInsertSO.Parameters.Add("@p_SONO", SqlDbType.VarChar).Value = txtSales.Text;
            //cmdInsertSO.Parameters.Add("@p_OrderDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDate.Text);
            //cmdInsertSO.Parameters.Add("@p_CUSTOMER", SqlDbType.Int).Value = DDLCustomer.SelectedValue;
            //cmdInsertSO.Parameters.Add("@p_ADDRESS", SqlDbType.VarChar).Value = txtaddres.Text;
            //string strGetValue = cmdInsertSO.ExecuteScalar().ToString();
            //if (m_sessSalesOrder.SOItemCollection != null)
            //{
            //    foreach (DataRow drDetailItem in m_sessSalesOrder.SOItemCollection.Rows)
            //    {
            //        SqlCommand cmdInsertSOItem = new SqlCommand("uspSO_insertSOItem", cnInsertData);
            //        cmdInsertSOItem.CommandType = CommandType.StoredProcedure;
            //        cmdInsertSOItem.Parameters.Add("@p_SOID", SqlDbType.Int).Value = strGetValue;
            //        cmdInsertSOItem.Parameters.Add("@p_ItemName", SqlDbType.VarChar).Value = drDetailItem["ITEM_NAME"].ToString();
            //        cmdInsertSOItem.Parameters.Add("@p_Quantity", SqlDbType.Int).Value = drDetailItem["QUANTITY"].ToString();
            //        cmdInsertSOItem.Parameters.Add("@p_Price", SqlDbType.Float).Value = drDetailItem["PRICE"].ToString();
            //        int iInsert = cmdInsertSOItem.ExecuteNonQuery();
            //        if (iInsert == 1)
            //        {
            //            Session.RemoveAll();
            //            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Save Successful!'); window.location = 'SOList.aspx';</script>");
            //        }
            //    }
            //}
        }

        private void RetrieveSalesOrderData()
        {
            SOItem oSOItem = new SOItem();
            oSOItem.DAL_LoadById(m_SOID);
            txtSales.Text = oSOItem.SalesOrderNo;
            txtDate.Text = oSOItem.OrderDate.ToString();
            DDLCustomer.SelectedItem.Text = oSOItem.CustomerName;
            txtaddres.Text = oSOItem.Address;
        }

        private SOItemCollection GetItemCollection()
        {
            SOItemCollection oSoItemCollection = new SOItemCollection();
            oSoItemCollection.GetDataItembyId(m_SOID);
            return oSoItemCollection;
        }
        #endregion method
    }
}