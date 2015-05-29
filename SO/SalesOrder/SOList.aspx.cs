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

        private SalesOrderCollection SessSalesOrderCollection
        {
            get { return Session["sessSalesOrderCollection"] == null ? new SalesOrderCollection() : (SalesOrderCollection)Session["sessSalesOrderCollection"]; }
            set { Session["sessSalesOrderCollection"] = value; }
        }

        public string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }

        #endregion session and properties

        #region page event

        protected void Page_Load(object sender, EventArgs e)
        {
            string sRefNumber = RefNumber;
            try
            {
                if (!Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_READ.ToString()))
                {
                    NoPermission();
                }
                if (!IsPostBack)
                {
                    GetSalesOrder();
                    GridView1.DataSource = SessSalesOrderCollection;
                    GridView1.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string sRefNumber = RefNumber;
            try
            {
                GetSalesOrder();
                GridView1.DataSource = SessSalesOrderCollection;
                GridView1.DataBind();
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
            string sRefNumber = RefNumber;
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string sRefNumber = RefNumber;
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string sRefNumber = RefNumber;
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataSource = SessSalesOrderCollection;
                GridView1.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sRefNumber = RefNumber;
            short iStatus = 0;
            string sDescription = "Delete Sales Order";
            string sPreviousDetail = "<xml />";
            SalesOrder oSales = new SalesOrder();
            try
            {
                oSales.SalesSoId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                oSales.DAL_Load(false);
                if (oSales.DAL_DeleteFullSO())
                {
                    iStatus = 1;
                }
                GridViewRow rGridRow = GridView1.Rows[e.RowIndex];
                SessSalesOrderCollection.RemoveAt(rGridRow.DataItemIndex);
                GridView1.DataSource = SessSalesOrderCollection;
                GridView1.DataBind();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnConfirmDelete = (Button)e.Row.Cells[5].FindControl("btnDelete");
                btnConfirmDelete.Visible = Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_DELETE.ToString());
                if (btnConfirmDelete != null)
                {
                    string sSoNo = SessSalesOrderCollection[e.Row.DataItemIndex].SalesOrderNo.ToString();
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
            if (!string.IsNullOrWhiteSpace(txtkey.Text)) sKeyword = txtkey.Text;
            if (!string.IsNullOrWhiteSpace(txtCalendar.Text)) dtOrderDate = Convert.ToDateTime(txtCalendar.Text);
            oSoCollection.DAL_LoadSalesbyKeyDate(sKeyword, dtOrderDate);
            SessSalesOrderCollection = oSoCollection;
        }

        #endregion method
    }
}