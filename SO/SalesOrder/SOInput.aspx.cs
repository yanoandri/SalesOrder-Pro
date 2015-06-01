using System;
using System.Reflection;
using System.Web.UI.WebControls;
using SO.BusinessLogicLayer;
using PFSHelper.Lib;
using PFSHelper.BusinessLogicLayer;

namespace SO
{
    public partial class SOInput : PFSBasePage
    {
        #region session and properties
        protected int m_qsSoId
        {
            get { return Request.QueryString["SOID"] == null ? 0 : Convert.ToInt32(Request.QueryString["SOID"]); }
        }

        protected string m_sRefNumber
        {
            get { return PFSCommon.GenerateRefNumber(); }
        }

        protected SalesOrder m_sessSalesOrderObject
        {
            get { return (Session["sessSalesOrderObject"]) == null ? new SalesOrder() : (SalesOrder)Session["sessSalesOrderObject"]; }
            set { Session["sessSalesOrderObject"] = value; }
        }

        public int m_vsSoItemId
        {
            get { return (ViewState["SOITEMID"]) == null ? 0 : (int)ViewState["SOITEMID"]; }
            set { ViewState["SOITEMID"] = value; }
        }

        protected Double dGrandtotal = 0;
        #endregion session and public variable

        #region page event
        protected void Page_Load(object sender, EventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                if (!IsPostBack)
                {
                    if (!Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SOINPUT_VIEW.ToString()))
                    {
                        NoPermission();
                    }

                    btnSave.Visible = Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SOINPUT_SAVE.ToString());

                    SalesOrder oSalesOrder = new SalesOrder();
                    m_sessSalesOrderObject = oSalesOrder;


                    ddlCustomer.DataSource = GetAllCustomer();
                    ddlCustomer.DataTextField = "CustomerName";
                    ddlCustomer.DataValueField = "CustomerId";
                    ddlCustomer.DataBind();

                    if (m_qsSoId != 0)
                    {
                        RetrieveSalesOrderData();
                        gvGridInput.DataSource = m_sessSalesOrderObject.SOItemCollection;
                        gvGridInput.DataBind();
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                SOItem oSoItem = new SOItem();
                m_vsSoItemId -= 1;
                oSoItem.SalesItemId = m_vsSoItemId;
                m_sessSalesOrderObject.SOItemCollection.Add(oSoItem);
                int iCount = m_sessSalesOrderObject.SOItemCollection.Count;
                gvGridInput.SetEditRow(iCount - 1);
                gvGridInput.DataSource = m_sessSalesOrderObject.SOItemCollection;
                gvGridInput.DataBind();
                btnAdd.Visible = false;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvGridInput_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                m_sessSalesOrderObject.SOItemCollection.RemoveAt(e.RowIndex);
                gvGridInput.DataSource = m_sessSalesOrderObject.SOItemCollection;
                gvGridInput.DataBind();
                btnAdd.Visible = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvGridInput_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                gvGridInput.EditIndex = e.NewEditIndex;
                gvGridInput.DataSource = m_sessSalesOrderObject.SOItemCollection;
                gvGridInput.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvGridInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblQuantity = (Label)e.Row.FindControl("lblQty");
                    Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                    Label lblTotal = (Label)e.Row.FindControl("lblTotal");

                    if (!(lblQuantity == null || lblPrice == null))
                    {
                        lblTotal.Text = (Convert.ToInt64(lblQuantity.Text) * Convert.ToDouble(lblPrice.Text)).ToString("#,##0.##");
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
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvGridInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                Label lblItemId = (Label)gvGridInput.Rows[e.RowIndex].Cells[0].FindControl("lblNo");
                TextBox txtItem = (TextBox)gvGridInput.Rows[e.RowIndex].Cells[1].FindControl("txtItem");
                TextBox txtQty = (TextBox)gvGridInput.Rows[e.RowIndex].Cells[2].FindControl("txtQty");
                TextBox txtPrice = (TextBox)gvGridInput.Rows[e.RowIndex].Cells[3].FindControl("txtprice");
                GridViewRow rGridRow = gvGridInput.Rows[e.RowIndex];
                SOItem oSoItem = new SOItem();
                oSoItem.ItemName = txtItem.Text.Trim();
                oSoItem.Quantity = Convert.ToInt32(txtQty.Text);
                oSoItem.Price = Convert.ToDouble(txtPrice.Text);

                m_sessSalesOrderObject.SOItemCollection[rGridRow.DataItemIndex].ItemName = oSoItem.ItemName;
                m_sessSalesOrderObject.SOItemCollection[rGridRow.DataItemIndex].Quantity = oSoItem.Quantity;
                m_sessSalesOrderObject.SOItemCollection[rGridRow.DataItemIndex].Price = oSoItem.Price;

                gvGridInput.EditIndex = -1;
                gvGridInput.DataSource = m_sessSalesOrderObject.SOItemCollection;
                gvGridInput.DataBind();
                btnAdd.Visible = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvGridInput_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                m_sessSalesOrderObject.SOItemCollection.RemoveAt(e.RowIndex);
                gvGridInput.DataSource = m_sessSalesOrderObject.SOItemCollection;
                gvGridInput.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvGridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    int iNoUrut = Convert.ToInt32(e.CommandArgument);
                    gvGridInput.DeleteRow(iNoUrut);
                    gvGridInput.DataSource = m_sessSalesOrderObject.SOItemCollection;
                    gvGridInput.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            short iStatus = 0;
            string sDescription = "Save Sales Order";
            string sPreviousDetail = "<xml />";
            SalesOrder oSalesOrder = new SalesOrder(Convert.ToInt32(Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SOINPUT_SAVE.ToString())));
            try
            {
                    if (m_sessSalesOrderObject.SOItemCollection.Count != 0)
                    {
                        if (m_qsSoId != 0)
                        {
                            sDescription = "Update Sales Order";
                        }
                        iStatus = 1;
                        UpdateDataSO();
                    }
                    else
                    {
                        if (m_qsSoId != 0)
                        {
                            sDescription = "Update Sales Order";
                        }
                        AlertMessageBox(this, "Please Fill Your Item!");
                    }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
            finally
            {
                Security.WriteUserLog(
               sRefNumber,
               sDescription,
               oSalesOrder,
               iStatus,
               (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SOINPUT_SAVE,
               sPreviousDetail);

                oSalesOrder = null;
                sRefNumber = null;
                sDescription = null;
                sPreviousDetail = null;
            }
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                Session.RemoveAll();
                Response.Redirect("~/SalesOrder/SOList.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        #endregion page event

        #region method
        private void RetrieveSalesOrderData()
        {
            SalesOrder oSalesOrder = new SalesOrder();
            oSalesOrder.DAL_RetrieveId(m_qsSoId);

            txtSales.Text = oSalesOrder.SalesOrderNo;
            txtDate.Text = oSalesOrder.OrderDate.ToString();
            ddlCustomer.SelectedValue = oSalesOrder.CustomerId.ToString();
            txtaddres.Text = oSalesOrder.Address;

            gvGridInput.DataSource = oSalesOrder.SOItemCollection;
            gvGridInput.DataBind();

            m_sessSalesOrderObject = oSalesOrder;
        }

        private CustomerCollection GetAllCustomer()
        {
            CustomerCollection oCustCollection = new CustomerCollection();
            oCustCollection.DAL_Load();
            return oCustCollection;
        }

        private void UpdateDataSO()
        {
                m_sessSalesOrderObject.SalesSoId = m_qsSoId;
                m_sessSalesOrderObject.SalesOrderNo = txtSales.Text;
                m_sessSalesOrderObject.CustomerId = Convert.ToInt32(ddlCustomer.SelectedValue);
                m_sessSalesOrderObject.OrderDate = Convert.ToDateTime(txtDate.Text);
                m_sessSalesOrderObject.Address = txtaddres.Text;
                bool bIsSuccess = m_sessSalesOrderObject.DAL_Update();
                if (!bIsSuccess)
                {
                    AlertMessageBox(this, "Update Failed");
                    return;
                }
                else
                {
                    AlertMessageBox(this, "Update Success!");
                    Response.Redirect("SOList.aspx");
                }
        }
        #endregion method
    }
}