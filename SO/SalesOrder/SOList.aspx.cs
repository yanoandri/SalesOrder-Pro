using System;
using System.Reflection;
using System.Web.UI.WebControls;
using SO.BusinessLogicLayer;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;

namespace SO
{
    public partial class SOList : PFSBasePage
    {
        #region session and properties

        private SalesOrderCollection m_sessSalesOrderCollection
        {
            get { return Session["sessSalesOrderCollection"] == null ? new SalesOrderCollection() : (SalesOrderCollection)Session["sessSalesOrderCollection"]; }
            set { Session["sessSalesOrderCollection"] = value; }
        }

        public string m_sRefNumber { get { return PFSCommon.GenerateRefNumber(); } }

        #endregion session and properties

        #region page event

        protected void Page_Load(object sender, EventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                if (!IsPostBack)
                {
                    if (!Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_VIEW.ToString()))
                    {
                        NoPermission();
                    }
                    btnAdd.Visible = Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_ADD.ToString());

                    GetSalesOrder();
                    gvList.DataSource = m_sessSalesOrderCollection;
                    gvList.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                GetSalesOrder();
                gvList.DataSource = m_sessSalesOrderCollection;
                gvList.DataBind();
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
                Response.Redirect("~/SalesOrder/SOInput.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                if (e.CommandName == "Edit")
                {
                    int iSoId = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("SOInput.aspx?SOID=" + iSoId);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            try
            {
                gvList.PageIndex = e.NewPageIndex;
                gvList.DataSource = m_sessSalesOrderCollection;
                gvList.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sRefNumber = m_sRefNumber;
            short iStatus = 0;
            string sDescription = "Delete Sales Order";
            string sPreviousDetail = "<xml />";
            SalesOrder oSales = new SalesOrder(Convert.ToInt32(Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_DELETE.ToString())));
            try
            {
                oSales.SalesSoId = Convert.ToInt32(gvList.DataKeys[e.RowIndex].Value);
                if (oSales.DAL_DeleteFullSO())
                {
                    iStatus = 1;
                }
                GetSalesOrder();
                gvList.DataSource = m_sessSalesOrderCollection;
                gvList.DataBind();
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
              oSales,
              iStatus,
              (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_DELETE,
              sPreviousDetail);

                oSales = null;
                sRefNumber = null;
                sDescription = null;
                sPreviousDetail = null;
            }
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnConfirmDelete = (Button)e.Row.Cells[5].FindControl("btnDelete");
                Button btnConfirmEdit = (Button)e.Row.Cells[5].FindControl("btnEdit");

                btnConfirmEdit.Visible = Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_EDIT.ToString());
                btnConfirmDelete.Visible = Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_DELETE.ToString());

                if (btnConfirmDelete != null)
                {
                    string sSoNo = m_sessSalesOrderCollection[e.Row.DataItemIndex].SalesOrderNo.ToString();
                    btnConfirmDelete.OnClientClick = string.Format("return confirm('Are you sure want to delete {0} ?')", sSoNo);
                }
            }
        }

        #endregion page event

        #region method

        private void GetSalesOrder()
        {
            SalesOrderCollection oSoCollection = new SalesOrderCollection();

            string sKeyword = null;
            DateTime? dtOrderDate;
            dtOrderDate = null;

            if (!string.IsNullOrWhiteSpace(txtkey.Text)) sKeyword = txtkey.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtCalendar.Text)) dtOrderDate = Convert.ToDateTime(txtCalendar.Text);
            oSoCollection.DAL_LoadSalesbyKeyDate(sKeyword, dtOrderDate);

            m_sessSalesOrderCollection = oSoCollection;
        }

        #endregion method
    }
}