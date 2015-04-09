using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace SO
{
    public partial class SOList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowList();
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            FindList();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOInput.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ID = Convert.ToInt32(e.CommandArgument.ToString());
            //GridViewRow row = (GridViewRow)GridView1.Rows[e.CommandArgument];
            if (e.CommandName == "Edit")
            {
                Response.Redirect("SOInput.aspx?SOID=" + ID);
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowList();
        }


        #region method
        protected void ShowList()
        {
            string connect = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(connect);
            cn.Open();
            string cmd = "SELECT SALES_SO_ID, a.SO_NO, a.ORDER_DATE, b.CUSTOMER_NAME, a.ADDRESS FROM dbo.SALES_SO a JOIN dbo.COM_CUSTOMER b ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID";
            SqlCommand sqlcmd = new SqlCommand(cmd, cn);
            sqlcmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            cn.Close();
        }

        protected void FindList()
        {
            string connect = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(connect);
            cn.Open();
            string cmd = "SELECT SALES_SO_ID, a.SO_NO, a.ORDER_DATE, b.CUSTOMER_NAME, a.ADDRESS FROM dbo.SALES_SO a JOIN dbo.COM_CUSTOMER b ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID WHERE (a.SO_NO LIKE '%" + txtkey.Text + "%' OR b.CUSTOMER_NAME LIKE '%" + txtkey.Text + "%')";
            if (txtCalendar.Text != "")
            {
                cmd = cmd + "AND ORDER_DATE= '" + txtCalendar.Text + "'";
            }
            SqlCommand sqlcmd = new SqlCommand(cmd, cn);
            sqlcmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            cn.Close();

        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string connect = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(connect);
            cn.Open();
            string cmd = "DELETE SALES_SO WHERE SALES_SO_ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            SqlCommand sqlcmd = new SqlCommand(cmd, cn);
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.ExecuteNonQuery();
            cn.Close();
            ShowList();

        }
        #endregion method



        


    }
}