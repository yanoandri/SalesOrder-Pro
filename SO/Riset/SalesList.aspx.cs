using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace asp_3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        #region event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load();

            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            {
                load();
            }
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesInput.aspx");
        }

        #endregion 

        #region grid
        protected void GridList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int  ID = Convert.ToInt32(e.CommandArgument.ToString());
         
            if (e.CommandName == "Edit")
            {
                Response.Redirect("SalesInput.aspx?SOID=" + ID);
            }
           
            
        }
        protected void GridList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridList.PageIndex = e.NewPageIndex;
            load();
        }
        protected void GridList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            {
                GridViewRow row = (GridViewRow)GridList.Rows[e.RowIndex];
                string cnString = ConfigurationManager.ConnectionStrings["SalesOrderConnectionString2"].ConnectionString; ;
                var conn = new SqlConnection(cnString);//tested and working
                conn.Open();
                var cmd = new SqlCommand("delete FROM SALES_SO_LITEM where SALES_SO_ID='" + Convert.ToInt32(GridList.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
                cmd.ExecuteNonQuery();
                var cmd2 = new SqlCommand("delete FROM SALES_SO where SALES_SO_ID='" + Convert.ToInt32(GridList.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
                load();

            }
        }
        protected void GridList_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            GridList.EditIndex = -1;
            load();
        }
        protected void GridList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button btnAlertStatus = (Button)e.Row.FindControl("btnDelete");


            }
        }
        #endregion 

        #region method

        protected void load()
        {
            

            string strKoneksi = @"Data Source=.\sql2k8;Initial Catalog=SO;User ID=sa;Password=sql2008";
            var conn = new SqlConnection(strKoneksi);
            conn.Open();

            string sql = "SELECT SALES_SO_ID,SO_NO,ORDER_DATE,COM_CUSTOMER.COM_CUSTOMER_ID,CUSTOMER_NAME FROM SALES_SO JOIN COM_CUSTOMER ON SALES_SO.COM_CUSTOMER_ID=COM_CUSTOMER.COM_CUSTOMER_ID WHERE  (SO_NO  like '%"
                + txtkey.Text + "%'or CUSTOMER_NAME  like '%" + txtkey.Text + "%')";

            if (txtDate.Text != "")
            {
                sql = sql + "AND ORDER_DATE = '" + txtDate.Text + "'";

            }

            SqlCommand cmd = new SqlCommand(sql, conn);

            var ds1 = new DataSet();
            var sda = new SqlDataAdapter(cmd);
            sda.Fill(ds1);
            GridList.DataSource = ds1;
            GridList.DataBind();
            conn.Close();
        }

       
        #endregion 

    }
}