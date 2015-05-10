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
    public partial class SOInput : System.Web.UI.Page
    {
        #region session and properties
        public int m_SoId
        {
            get { return (Session["Edit"]) == null ? 0 : (int)Session["Edit"]; }
            set { Session["Edit"] = value; }
        }

        public DataTable m_SessionItemDatatable
        {
            get { return (Session["SessionItemDatatable"]) == null ? new DataTable() : (DataTable)Session["SessionItemDatatable"]; }
            set { Session["SessionItemDatatable"] = value; }
        }
        //riset 2 collection
        public SalesOrder m_SessionSalesOrder
        {
            get { return (Session["m_SessionSalesOrder"]) == null ? new SalesOrder() : (SalesOrder)Session["m_SessionSalesOrder"]; }
            set { Session["m_SessionSalesOrder"] = value; }
        }
        public SOItemCollection m_SessionItemCollection
        {
            get { return (Session["sessItemCollection"]) == null ? new SOItemCollection() : (SOItemCollection)Session["sessItemCollection"]; }
            set { Session["sessItemCollection"] = value; }
        }

        #endregion session and public variable

        #region page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Customer oCustomer = new Customer();
                    DDLCustomer.DataSource = GetAllCustomer();
                    DDLCustomer.DataTextField = "CustomerName";
                    DDLCustomer.DataValueField = "CustomerId";
                    DDLCustomer.DataBind();


                    if (m_SoId != 0)
                    {

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
                GridInput.DataSource = m_SessionItemDatatable;
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
                if (m_SoId != 0)
                {
                    GridInput.EditIndex = -1;
                }
                else
                {
                    m_SessionItemCollection.RemoveAt(e.RowIndex);
                }
                GridInput.DataSource = m_SessionItemDatatable;
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
                GridInput.DataSource = m_SessionItemDatatable;
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
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblquantity = (Label)e.Row.FindControl("lblqty");
                    Label lblprice = (Label)e.Row.FindControl("lblprice");
                    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                    Label lblOrder = (Label)e.Row.FindControl("lblUrut");

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
                Label lblItemId = (Label)GridInput.Rows[e.RowIndex].Cells[0].FindControl("lblNo");
                TextBox txtItem = (TextBox)GridInput.Rows[e.RowIndex].Cells[1].FindControl("txtItem");
                TextBox txtQty = (TextBox)GridInput.Rows[e.RowIndex].Cells[2].FindControl("txtQty");
                TextBox txtPrice = (TextBox)GridInput.Rows[e.RowIndex].Cells[3].FindControl("txtprice");
                SOItem oSOItem = new SOItem();
                GridViewRow rGridRow = GridInput.Rows[e.RowIndex];
                oSOItem.ItemName = txtItem.Text;
                oSOItem.Quantity = Convert.ToInt32(txtQty.Text);
                oSOItem.Price = Convert.ToDouble(txtPrice.Text);
                m_SessionItemDatatable.Rows[rGridRow.DataItemIndex]["ItemName"] = oSOItem.ItemName;
                m_SessionItemDatatable.Rows[rGridRow.DataItemIndex]["Quantity"] = oSOItem.Quantity;
                m_SessionItemDatatable.Rows[rGridRow.DataItemIndex]["Price"] = oSOItem.Price;
                m_SessionSalesOrder.SOItemCollection.Add(oSOItem);
                GridInput.EditIndex = -1;
                GridInput.DataSource = m_SessionItemDatatable;
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
                m_SessionItemCollection.RemoveAt(e.RowIndex - 1);
                GridInput.DataSource = m_SessionItemDatatable;
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
                    GridInput.DataSource = m_SessionItemDatatable;
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
        private void insertData()
        {
            m_SessionSalesOrder = new SalesOrder();
            SOItem oSOItem = new SOItem();
            m_SessionSalesOrder.SalesOrderNo = txtSales.Text;
            m_SessionSalesOrder.OrderDate = Convert.ToDateTime(txtDate.Text);
            m_SessionSalesOrder.CustomerId = Convert.ToInt32(DDLCustomer.SelectedValue);
            m_SessionSalesOrder.Address = txtaddres.Text;
            int iCount = m_SessionSalesOrder.SOItemCollection.Count;
            //m_SessionSalesOrder.SOItemCollection[1].SoId = m_SessionSalesOrder.SalesSoId;
            //m_SessionSalesOrder.SOItemCollection[1].ItemName = oSOItem.ItemName;
            //m_SessionSalesOrder.SOItemCollection[1].Quantity = oSOItem.Quantity;
            //m_SessionSalesOrder.SOItemCollection[1].Price = oSOItem.Price;
            bool bIsSuccess = m_SessionSalesOrder.DAL_Add();
            if (!bIsSuccess)
            {
                PFSBasePage.AlertMessageBox(this, "Save Failed!");
            }
            else
            {
                PFSBasePage.AlertMessageBox(this, "Save Success!");
            }
        }

        private void RetrieveSalesOrderData()
        {
            //SOItem oSOItem = new SOItem();
            //oSOItem.DAL_LoadById(m_SOID);
            //txtSales.Text = oSOItem.SalesOrderNo;
            //txtDate.Text = oSOItem.OrderDate.ToString();
            //DDLCustomer.SelectedItem.Text = oSOItem.CustomerName;
            //txtaddres.Text = oSOItem.Address;
        }

        //private SOItemCollection GetItemCollection()
        //{
        //    SOItemCollection oSoItemCollection = new SOItemCollection();
        //    //oSoItemCollection.GetDataItembyId(m_SOID);
        //    return oSoItemCollection;
        //}

        private CustomerCollection GetAllCustomer()
        {
            CustomerCollection oCustCollection = new CustomerCollection();
            oCustCollection.DAL_Load();
            return oCustCollection;
        }

        private void setInitialRow()
        {
            m_SessionSalesOrder = new SalesOrder();
            DataTable dtInit = new DataTable();
            DataRow drInitTable, drAfterFirstRow = null;
            dtInit.Columns.Add(new DataColumn("SalesItemId", typeof(int)));
            dtInit.Columns.Add(new DataColumn("ItemName", typeof(string)));
            dtInit.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dtInit.Columns.Add(new DataColumn("Price", typeof(Double)));
            if (m_SessionItemDatatable.Rows.Count < 1)
            {
                int iCount = dtInit.Rows.Count;
                drInitTable = dtInit.NewRow();
                drInitTable["SalesItemId"] = 1;
                dtInit.Rows.Add(drInitTable);
                GridInput.SetEditRow(iCount);
                m_SessionItemDatatable = dtInit;

            }
            else if (m_SessionItemDatatable.Rows.Count >= 1)
            {
                int iCount = m_SessionItemDatatable.Rows.Count;
                drAfterFirstRow = m_SessionItemDatatable.NewRow();
                drAfterFirstRow["SalesItemId"] = 1;
                m_SessionItemDatatable.Rows.Add(drAfterFirstRow);
                GridInput.SetEditRow(iCount);
            }
        }
        #endregion method
    }
}