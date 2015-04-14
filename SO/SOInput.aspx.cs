using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace SO
{
    public partial class SOInput2 : System.Web.UI.Page
    {
        #region session
        public string strcn = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;

        public DataTable SessionSo
        {
            get { return (Session["SessionSo"]) == null ? new DataTable() : (DataTable)Session["SessionSo"]; }
            set { Session["SessionSo"] = value; }
        }

        public DataRow dr = null;

        #endregion session
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            setInitialRow();
            GridInput.DataSource = SessionSo;
            GridInput.DataBind();
        }

        protected void GridInput_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //initTable();
            GridInput.EditIndex = -1;
            //GridInput.DataSource = dt;
            //GridInput.DataBind();
        }

        protected void GridInput_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            TextBox txtItem = (TextBox)GridInput.Rows[e.RowIndex].Cells[1].FindControl("txtItem");
            Label lblItem = (Label)GridInput.Rows[e.RowIndex].Cells[1].FindControl("lblitem");
            TextBox txtQty = (TextBox)GridInput.Rows[e.RowIndex].Cells[2].FindControl("txtQty");
            Label lblquantity = (Label)GridInput.Rows[e.RowIndex].Cells[2].FindControl("lblqty");
            TextBox txtPrice = (TextBox)GridInput.Rows[e.RowIndex].Cells[3].FindControl("txtprice");
            Label lblprice = (Label)GridInput.Rows[e.RowIndex].Cells[3].FindControl("lblprice");
            Label lblTotal = (Label)GridInput.Rows[e.RowIndex].Cells[4].FindControl("lblTotal");
            GridViewRow r = GridInput.Rows[e.RowIndex];
            SessionSo.Rows[r.DataItemIndex]["ITEM_NAME"] = txtItem.Text;
            SessionSo.Rows[r.DataItemIndex]["QUANTITY"] = txtQty.Text;
            SessionSo.Rows[r.DataItemIndex]["PRICE"] = txtPrice.Text;
            SessionSo.Rows[r.DataItemIndex]["TOTAL"] = (Convert.ToInt64(txtQty.Text) * Convert.ToDouble(txtPrice.Text)).ToString();
            GridInput.EditIndex = -1;
            GridInput.DataSource = SessionSo;
            GridInput.DataBind();


        }

        protected void GridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(strcn);
            cn.Open();
            SqlCommand cmd = new SqlCommand("spx_insertSO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SONO", SqlDbType.VarChar).Value = txtsales.Text;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.Int).Value = DDLCustomer.SelectedValue;
            cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = txtaddres.Text;
            string getValue = cmd.ExecuteScalar().ToString();
            if (SessionSo != null)
            {
                foreach (DataRow dr in SessionSo.Rows)
                {
                    SqlCommand cmd2 = new SqlCommand("spx_insertSOItem", cn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@SOID", SqlDbType.Int).Value = getValue;
                    cmd2.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = dr["ITEM_NAME"].ToString();
                    cmd2.Parameters.Add("@Quantity", SqlDbType.Int).Value = dr["QUANTITY"].ToString();
                    cmd2.Parameters.Add("@Price", SqlDbType.Float).Value = dr["PRICE"].ToString();
                    cmd2.ExecuteNonQuery();
                }

            }

            Response.Redirect("SOList.aspx");
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Session.Remove("SessionSo");
            Session["SessionSo"] = null;
            Response.Redirect("SOList.aspx");
        }

        #region method
        private void setInitialRow()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dt.Columns.Add(new DataColumn("TOTAL", typeof(float)));

            if (SessionSo.Rows.Count < 1)
            {
                int rowcount = SessionSo.Rows.Count;
                dr = dt.NewRow();
                dr["SALES_SO_LITEM_ID"] = 1;
                dr["ITEM_NAME"] = "";
                dr["QUANTITY"] = 0;
                dr["PRICE"] = 0;
                dr["TOTAL"] = 0;
                dt.Rows.Add(dr);
                GridInput.SetEditRow(rowcount);
                SessionSo = dt;
            }
            else if (SessionSo.Rows.Count >= 1)
            {
                int rowcount = SessionSo.Rows.Count;
                int OrderedList;
                DataRow dr2 = null;
                dr2 = SessionSo.NewRow();
                for (OrderedList = 1; OrderedList <= rowcount; OrderedList++)
                {
                    OrderedList.ToString();
                }
                dr2["SALES_SO_LITEM_ID"] = OrderedList;
                dr2["ITEM_NAME"] = "";
                dr2["QUANTITY"] = 0;
                dr2["PRICE"] = 0;
                dr2["TOTAL"] = 0;
                SessionSo.Rows.Add(dr2);
                GridInput.SetEditRow(rowcount);
            }
        }

        #endregion method
    }
}