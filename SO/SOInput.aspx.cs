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

        public DataRow dr = null;

        public int SOID
        {
            get { return (Session["Edit"]) == null ? 0 : (int)Session["Edit"]; }
            set { Session["Edit"] = value; }
        }


        public DataTable SessionSo
        {
            get { return (Session["SessionSo"]) == null ? new DataTable() : (DataTable)Session["SessionSo"]; }
            set { Session["SessionSo"] = value; }
        }

        

        #endregion session
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SOID != 0)
                {
                    initTable();
                    retrieveData();
                    GridInput.DataSource = SessionSo;
                    GridInput.DataBind();
                }

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
            //int rowCount = SessionSo.Rows.Count;
            GridInput.EditIndex = -1;
            GridInput.DataSource = SessionSo;
            GridInput.DataBind();
        }

        protected void GridInput_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridInput.EditIndex = e.NewEditIndex;
            GridInput.DataSource = SessionSo;
            GridInput.DataBind();
        }

        Double grandtotal = 0;
        protected void GridInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblquantity = (Label)e.Row.FindControl("lblqty");
            Label lblprice = (Label)e.Row.FindControl("lblprice");
            Label lblTotal = (Label)e.Row.FindControl("lblTotal");
            Label lblOrder = (Label)e.Row.FindControl("lblUrut");
            //row bound
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < SessionSo.Rows.Count; i++)
                {
                    SessionSo.Rows[i]["NO_URUT"] = i + 1;
                    //lblOrder.Text = SessionSo.Rows[i]["NO_URUT"].ToString() + 1;
                }

                if (lblquantity == null || lblprice == null)
                {
                }
                else
                {
                    lblTotal.Text = (Convert.ToInt64(lblquantity.Text) * Convert.ToDouble(lblprice.Text)).ToString();
                    grandtotal += Convert.ToDouble(lblTotal.Text);
                }
            }
            //footer control
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                lblGrandTotal.Text = grandtotal.ToString();
            }
        }

        protected void GridInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblItemId = (Label)GridInput.Rows[e.RowIndex].Cells[0].FindControl("lblNo");
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
            GridInput.EditIndex = -1;
            GridInput.DataSource = SessionSo;
            GridInput.DataBind();
        }

        protected void GridInput_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //foreach(dat)

            if (SOID != 0)
            {
                SqlConnection cn = new SqlConnection(strcn);
                cn.Open();
                SqlCommand cmd = new SqlCommand("spx_deleteItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ITEMID", SqlDbType.Int).Value = SessionSo.Rows[e.RowIndex]["SALES_SO_LITEM_ID"].ToString();
                cmd.Parameters.Add("@SOID", SqlDbType.Int).Value = SOID;
                cmd.ExecuteNonQuery();
            }
            else
            {
                SessionSo.Rows.RemoveAt(e.RowIndex);
            }
            GridInput.DataSource = SessionSo;
            GridInput.DataBind();
        }

        protected void GridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument) - 1;
                GridInput.DeleteRow(id);
                GridInput.DataSource = SessionSo;
                GridInput.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SOID != 0)
            {
                updateDataSO();
                Session.RemoveAll();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Update Succesful!'); window.location = 'SOList.aspx';</script>");
            }
            else
            {
                insertData();
            }
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("SOList.aspx");
        }


        #region method
        private void retrieveData()
        {
            SqlConnection cn = new SqlConnection(strcn);
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM SALES_SO WHERE SALES_SO_ID = @SOID", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@SOID", SqlDbType.Int).Value = SOID;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtsales.Text = dr["SO_NO"].ToString();
                txtaddres.Text = dr["ADDRESS"].ToString();
                txtdate.Text = dr["ORDER_DATE"].ToString();
                DDLCustomer.SelectedValue = dr["COM_CUSTOMER_ID"].ToString();

            }
            dr.Close();
            SqlCommand cmd2 = new SqlCommand("spx_detailItem", cn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@SOID", SqlDbType.Int).Value = SOID;
            dr = cmd2.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridInput.DataSource = dt;
            GridInput.DataBind();
            SessionSo = dt;
            dr.Close();

        }

        private void setInitialRow()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NO_URUT", typeof(int))); //untuk delete
            dt.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dt.Columns.Add(new DataColumn("TOTAL", typeof(float)));

            if (SessionSo.Rows.Count < 1)
            {
                int rowcount = SessionSo.Rows.Count;
                dr = dt.NewRow();
                //dr["SALES_SO_LITEM"] = 1;
                dr["NO_URUT"] = 1; //untuk delete
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
                DataRow dr2 = null;
                dr2 = SessionSo.NewRow();
                dr2["ITEM_NAME"] = "";
                dr2["QUANTITY"] = 0;
                dr2["PRICE"] = 0;
                dr2["TOTAL"] = 0;
                SessionSo.Rows.Add(dr2);
                GridInput.SetEditRow(rowcount);
            }
        }

        private void initTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NO_URUT", typeof(int))); //untuk delete
            dt.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dt.Columns.Add(new DataColumn("TOTAL", typeof(float)));
        }


        private void insertData()
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
                    int ins = cmd2.ExecuteNonQuery();
                    if (ins == 1)
                    {
                        Session.RemoveAll();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Save Successful!'); window.location = 'SOList.aspx';</script>");
                    }
                }
            }
        }

        private void updateDataSO()
        {
            SqlConnection cn = new SqlConnection(strcn);
            cn.Open();
            SqlCommand cmd = new SqlCommand("spx_updateSO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SONO", SqlDbType.VarChar).Value = txtsales.Text;
            cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
            cmd.Parameters.Add("@Customer", SqlDbType.Int).Value = DDLCustomer.SelectedValue;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtaddres.Text;
            cmd.Parameters.Add("@SOID", SqlDbType.Int).Value = SOID;
            cmd.ExecuteNonQuery();
            if (SessionSo != null)
            {
                for (int i = 0; i < SessionSo.Rows.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("spx_checkItem", cn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@SOID", SqlDbType.Int).Value = SOID;
                    cmd2.Parameters.Add("@ITEMID", SqlDbType.Int).Value = SessionSo.Rows[i]["SALES_SO_LITEM_ID"].ToString();
                    cmd2.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = SessionSo.Rows[i]["ITEM_NAME"].ToString();
                    cmd2.Parameters.Add("@Quantity", SqlDbType.Int).Value = SessionSo.Rows[i]["QUANTITY"].ToString();
                    cmd2.Parameters.Add("@Price", SqlDbType.Float).Value = SessionSo.Rows[i]["PRICE"].ToString();
                    cmd2.ExecuteNonQuery();

                }
            }
        }
        #endregion method
    }
}