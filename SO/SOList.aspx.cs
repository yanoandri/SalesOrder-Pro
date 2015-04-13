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
        #region
        public string connect = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;
        #endregion

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection cn = new SqlConnection(connect);
            cn.Open();
            string cmd = "spx_deleteso";
            SqlCommand sqlcmd = new SqlCommand(cmd, cn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@SOID", SqlDbType.VarChar).Value = GridView1.DataKeys[e.RowIndex].Value.ToString();
            sqlcmd.ExecuteNonQuery();
            cn.Close();
            ShowList();

        }


        #region method
        protected void ShowList()
        {
            SqlConnection cn = new SqlConnection(connect);
            cn.Open();
            string cmd = "spx_showlist";
            SqlCommand sqlcmd = new SqlCommand(cmd, cn);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            cn.Close();
        }

        protected void FindList()
        {
            SqlConnection cn = new SqlConnection(connect);
            cn.Open();
            string cmd = string.Empty;
            if (txtkey.Text != "")
            {
                cmd = "SELECT SALES_SO_ID, a.SO_NO, a.ORDER_DATE, b.CUSTOMER_NAME, a.ADDRESS FROM dbo.SALES_SO a JOIN dbo.COM_CUSTOMER b ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID WHERE (a.SO_NO LIKE '%" + txtkey.Text + "%' OR b.CUSTOMER_NAME LIKE '%" + txtkey.Text + "%')";
            }
            else if (txtCalendar.Text != "")
            {
                cmd = "SELECT SALES_SO_ID, a.SO_NO, a.ORDER_DATE, b.CUSTOMER_NAME, a.ADDRESS FROM dbo.SALES_SO a JOIN dbo.COM_CUSTOMER b ON a.COM_CUSTOMER_ID = b.COM_CUSTOMER_ID WHERE (a.SO_NO LIKE '%" + txtkey.Text + "%' OR b.CUSTOMER_NAME LIKE '%" + txtkey.Text + "%' AND ORDER_DATE= '" + txtCalendar.Text + "')";
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
        #endregion method


    }
}