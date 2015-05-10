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
    public partial class SOList : System.Web.UI.Page
    {
        #region session and properties

        private SalesOrderCollection sessSalesOrderCollection
        {
            get { return Session["sessSalesOrderCollection"] == null ? null : (SalesOrderCollection)Session["sessSalesOrderCollection"]; }
            set { Session["sessSalesOrderCollection"] = value; }
        }

        #endregion session and properties

        #region page event

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GridView1.DataSource = GetSalesOrder();
                    GridView1.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.DataSource = GetSalesOrder();
                GridView1.DataBind();
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
                Response.Redirect("SOInput.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                { 
                    Session["Edit"] = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("SOInput.aspx?SOID=" + Session["Edit"]);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataSource = sessSalesOrderCollection;
                GridView1.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SalesOrder oSales = new SalesOrder();
                oSales.SalesSoId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                oSales.DAL_DeleteFullSO();
                Response.Redirect("SOList.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }
        }

        #endregion page event

        #region method

        private SalesOrderCollection GetSalesOrder()
        {
            sessSalesOrderCollection = new SalesOrderCollection();
            try
            {
                string sKeyword = null;
                DateTime? dtOrderDate;
                dtOrderDate = null;
                if (!string.IsNullOrWhiteSpace(txtkey.Text)) sKeyword = txtkey.Text;
                if (!string.IsNullOrWhiteSpace(txtCalendar.Text)) dtOrderDate = Convert.ToDateTime(txtCalendar.Text);
                sessSalesOrderCollection.DAL_LoadSalesbyKeyDate(sKeyword, dtOrderDate);
                return sessSalesOrderCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion method

    }
}