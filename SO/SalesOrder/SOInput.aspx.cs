﻿using System;
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

        public SalesOrder m_SalesOrderObject
        {
            get { return (Session["sessSalesOrderObject"]) == null ? new SalesOrder() : (SalesOrder)Session["sessSalesOrderObject"]; }
            set { Session["sessSalesOrderObject"] = value; }
        }
        #endregion session and public variable

        #region page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    SalesOrder oSalesOrder = new SalesOrder();
                    m_SalesOrderObject = oSalesOrder;


                    DDLCustomer.DataSource = GetAllCustomer();
                    DDLCustomer.DataTextField = "CustomerName";
                    DDLCustomer.DataValueField = "CustomerId";
                    DDLCustomer.DataBind();

                    if (m_SoId != 0)
                    {
                        RetrieveSalesOrderData();
                        GridInput.DataSource = m_SalesOrderObject.SOItemCollection;
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
                SOItem oSoItem = new SOItem();
                oSoItem.SalesItemId = -1;
                m_SalesOrderObject.SOItemCollection.Add(oSoItem);
                int iCount = m_SalesOrderObject.SOItemCollection.Count;
                GridInput.SetEditRow(iCount - 1);
                GridInput.DataSource = m_SalesOrderObject.SOItemCollection;
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
                    m_SalesOrderObject.SOItemCollection.RemoveAt(e.RowIndex);
                }
                GridInput.DataSource = m_SalesOrderObject.SOItemCollection;
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
                GridInput.DataSource = m_SalesOrderObject.SOItemCollection;
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
                GridViewRow rGridRow = GridInput.Rows[e.RowIndex];
                SOItem oSoItem = new SOItem();
                oSoItem.ItemName = txtItem.Text;
                oSoItem.Quantity = Convert.ToInt32(txtQty.Text);
                oSoItem.Price = Convert.ToDouble(txtPrice.Text);

                m_SalesOrderObject.SOItemCollection[rGridRow.DataItemIndex].ItemName = oSoItem.ItemName;
                m_SalesOrderObject.SOItemCollection[rGridRow.DataItemIndex].Quantity = oSoItem.Quantity;
                m_SalesOrderObject.SOItemCollection[rGridRow.DataItemIndex].Price = oSoItem.Price;

                GridInput.EditIndex = -1;
                GridInput.DataSource = m_SalesOrderObject.SOItemCollection;
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
                m_SalesOrderObject.SOItemCollection.RemoveAt(e.RowIndex);
                GridInput.DataSource = m_SalesOrderObject.SOItemCollection;
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
                    GridInput.DataSource = m_SalesOrderObject.SOItemCollection;
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
                UpdateDataSO();
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
                Response.Redirect("~/SalesOrder/SOList.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion page event

        #region method
        private void RetrieveSalesOrderData()
        {
            SalesOrder oSalesOrder = new SalesOrder();
            oSalesOrder.DAL_RetrieveId(m_SoId);

            txtSales.Text = oSalesOrder.SalesOrderNo;
            txtDate.Text = oSalesOrder.OrderDate.ToString();
            DDLCustomer.SelectedValue = oSalesOrder.CustomerId.ToString();
            txtaddres.Text = oSalesOrder.Address;

            GridInput.DataSource = oSalesOrder.SOItemCollection;
            GridInput.DataBind();

            m_SalesOrderObject = oSalesOrder;
        }

        private CustomerCollection GetAllCustomer()
        {
            CustomerCollection oCustCollection = new CustomerCollection();
            oCustCollection.DAL_Load();
            return oCustCollection;
        }

        private void UpdateDataSO()
        {
            m_SalesOrderObject.SalesSoId = m_SoId;
            m_SalesOrderObject.SalesOrderNo = txtSales.Text;
            m_SalesOrderObject.CustomerId = Convert.ToInt32(DDLCustomer.SelectedValue);
            m_SalesOrderObject.OrderDate = Convert.ToDateTime(txtDate.Text);
            m_SalesOrderObject.Address = txtaddres.Text;
            bool bIsSuccess = m_SalesOrderObject.DAL_Update();
            if (!bIsSuccess)
            {
                PFSBasePage.AlertMessageBox(this, "Update Failed");
                return;
            }
            else
            {
                PFSBasePage.AlertMessageBox(this, "Update Success");
                Response.Redirect("SOList.aspx");
            }
        }
        #endregion method
    }
}