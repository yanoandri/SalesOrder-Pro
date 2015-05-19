﻿using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SO.BusinessLogicLayer;
using System.Collections.Generic;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;

namespace SO
{
    public partial class SOList : PFSBasePage
    {
        #region session and properties

        private SalesOrderCollection SessSalesOrderCollection
        {
            get { return Session["sessSalesOrderCollection"] == null ? null : (SalesOrderCollection)Session["sessSalesOrderCollection"]; }
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
                if (!Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_ADD.ToString()))
                {
                    NoPermission();
                }
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
                    Session["Edit"] = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("SOInput.aspx?SOID=" + Session["Edit"]);
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
            short iStatus = 1;
            string sDescription = "Delete Item";
            string sPreviousDetail = "<xml />";
            Group oGroup = new Group(Convert.ToInt32(Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_DELETE.ToString())));
            try
            {
                if (!Security.CheckSecurity(SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_DELETE.ToString()))
                {
                    NoPermission();
                }
                SalesOrder oSales = new SalesOrder();
                oSales.SalesSoId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
                oSales.DAL_DeleteFullSO();
                SessSalesOrderCollection.RemoveAt(e.RowIndex);
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
              oGroup,
              iStatus,
              (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SALES_SO_DELETE,
              sPreviousDetail);

                oGroup = null;
                sRefNumber = null;
                sDescription = null;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnConfirmDelete = (Button)e.Row.Cells[5].FindControl("btnDelete");
                if (btnConfirmDelete != null)
                {
                    string sSoNo = SessSalesOrderCollection[e.Row.DataItemIndex].SalesOrderNo.ToString();
                    btnConfirmDelete.OnClientClick = string.Format("return confirm('Are you sure want to delete " + sSoNo + " ?')");
                }
            }
        }

        #endregion page event

        #region method

        private SalesOrderCollection GetSalesOrder()
        {
            SalesOrderCollection oSoCollection = new SalesOrderCollection();
            try
            {
                string sKeyword = null;
                DateTime? dtOrderDate;
                dtOrderDate = null;
                if (!string.IsNullOrWhiteSpace(txtkey.Text)) sKeyword = txtkey.Text;
                if (!string.IsNullOrWhiteSpace(txtCalendar.Text)) dtOrderDate = Convert.ToDateTime(txtCalendar.Text);
                oSoCollection.DAL_LoadSalesbyKeyDate(sKeyword, dtOrderDate);
                SessSalesOrderCollection = oSoCollection;
                return oSoCollection;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion method
    }
}