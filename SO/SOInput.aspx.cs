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


        public DataTable SessionSoItem
        {
            get { return (Session["SessionSoItem"]) == null ? new DataTable() : (DataTable)Session["SessionSoItem"]; }
            set { Session["SessionSoItem"] = value; }
        }

        public DataTable SessionDelete
        {
            get { return (Session["SessionDelete"]) == null ? new DataTable() : (DataTable)Session["SessionDelete"]; }
            set { Session["SessionDelete"] = value; }
        }

        public int soItemId
        {
            get { return (ViewState["SOITEMID"]) == null ? 0 : (int)ViewState["SOITEMID"]; }
            set { ViewState["SOITEMID"] = value; }
        }



        #endregion session

        #region page event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SOID != 0)
                {
                    retrieveData();
                }

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            setInitialRow();
            GridInput.DataSource = SessionSoItem;
            GridInput.DataBind();
        }

        protected void GridInput_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //int rowCount = SessionSo.Rows.Count;
            GridInput.EditIndex = -1;
            GridInput.DataSource = SessionSoItem;
            GridInput.DataBind();
        }

        protected void GridInput_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridInput.EditIndex = e.NewEditIndex;
            GridInput.DataSource = SessionSoItem;
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
                for (int i = 0; i < SessionSoItem.Rows.Count; i++)
                {
                    SessionSoItem.Rows[i]["NO_URUT"] = i + 1;
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
            SessionSoItem.Rows[r.DataItemIndex]["ITEM_NAME"] = txtItem.Text;
            SessionSoItem.Rows[r.DataItemIndex]["QUANTITY"] = txtQty.Text;
            SessionSoItem.Rows[r.DataItemIndex]["PRICE"] = txtPrice.Text;
            GridInput.EditIndex = -1;
            GridInput.DataSource = SessionSoItem;
            GridInput.DataBind();
        }

        protected void GridInput_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            SessionSoItem.Rows.RemoveAt(e.RowIndex - 1);
            GridInput.DataSource = SessionSoItem;
            GridInput.DataBind();
        }

        protected void GridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                //if (SOID != 0)
                //{

                //    SessionDelete = new DataTable();
                //    DataSet ds = new DataSet();
                //    SessionDelete.Columns.Add(new DataColumn("NO_URUT", typeof(int))); //untuk delete
                //    SessionDelete.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
                //    SessionDelete.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
                //    SessionDelete.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
                //    SessionDelete.Columns.Add(new DataColumn("PRICE", typeof(float)));
                //    SessionDelete.Columns.Add(new DataColumn("TOTAL", typeof(float)));
                //    DataRow drow, drow2;
                //    int i;
                //    if (SessionDelete.Rows.Count < 1)
                //    {
                //        drow = SessionDelete.NewRow();
                //        for (i = 0; i <= SessionDelete.Rows.Count; i++)
                //        {
                //            Convert.ToInt32(i);
                //        }
                //        drow["NO_URUT"] = SessionSoItem.Rows[id - 1]["NO_URUT"].ToString();
                //        drow["SALES_SO_LITEM_ID"] = SessionSoItem.Rows[id - 1]["SALES_SO_LITEM_ID"].ToString();
                //        drow["ITEM_NAME"] = SessionSoItem.Rows[id - 1]["ITEM_NAME"].ToString(); ;
                //        drow["QUANTITY"] = SessionSoItem.Rows[id - 1]["QUANTITY"].ToString(); ;
                //        drow["PRICE"] = SessionSoItem.Rows[id - 1]["PRICE"].ToString(); ;
                //        SessionDelete.Rows.Add(drow);
                //        ds.Tables.Add(SessionDelete);
                //    }
                //    else if (SessionDelete.Rows.Count >= 1)
                //    {
                //        drow2 = SessionDelete.NewRow();
                //        for (i = 0; i <= SessionDelete.Rows.Count; i++)
                //        {
                //            Convert.ToInt32(i);
                //        }
                //        drow2["NO_URUT"] = i;
                //        drow2["SALES_SO_LITEM_ID"] = SessionSoItem.Rows[id - 1]["SALES_SO_LITEM_ID"].ToString();
                //        drow2["ITEM_NAME"] = SessionSoItem.Rows[id - 1]["ITEM_NAME"].ToString(); ;
                //        drow2["QUANTITY"] = SessionSoItem.Rows[id - 1]["QUANTITY"].ToString(); ;
                //        drow2["PRICE"] = SessionSoItem.Rows[id - 1]["PRICE"].ToString(); ;
                //        SessionDelete.Rows.Add(drow2);
                //        ds.Tables.Add(SessionDelete);
                //    }
                //    //ds.Tables.Add(SessionDelete);
                //}
                GridInput.DeleteRow(id);
                GridInput.DataSource = SessionSoItem;
                GridInput.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SOID != 0)
            {
                //updateDataSO();
                #region remove old SO Item
                SqlConnection cn = new SqlConnection(strcn);
                cn.Open();
                SqlCommand cmd = new SqlCommand("spx_detailItem", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SOID", SqlDbType.Int).Value = SOID;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds); //pakai dataset
                foreach (DataRow drdb in ds.Tables[0].Rows) //convert ke int
                {
                    Boolean dbisfound = false;
                    foreach (DataRow drgrid in SessionSoItem.Rows)
                    {
                        if (Convert.ToInt32(drdb["SALES_SO_LITEM_ID"]) == Convert.ToInt32(drgrid["SALES_SO_LITEM_ID"]))
                        {
                            updateDataSO();//panggil sp update soITEM
                            dbisfound = true;
                            break;
                        }
                    }
                    if (!dbisfound)
                    {
                        //delete SOITEMID by drdb
                        int rowDB = Convert.ToInt32(drdb["SALES_SO_LITEM_ID"]);
                        SqlCommand cmd2 = new SqlCommand("spx_deleteitemid", cn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@ITEMID", SqlDbType.Int).Value = rowDB;
                        cmd2.ExecuteNonQuery();
                    }
                }
                #endregion
                foreach (DataRow dr in SessionSoItem.Rows)
                {
                    if (Convert.ToInt32(dr["SALES_SO_LITEM_ID"]) > 0) //convert ke integer
                    {
                        //panggil sp update soITEM
                        updateDataSO();
                    }
                    else
                    {
                        //add
                        insertData();
                    }
                }
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
        #endregion page event

        #region method lama
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
            if (SessionSoItem != null)
            {
                for (int i = 0; i < SessionSoItem.Rows.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("spx_checkItem", cn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@SOID", SqlDbType.Int).Value = SOID;
                    cmd2.Parameters.Add("@ITEMID", SqlDbType.Int).Value = SessionSoItem.Rows[i]["SALES_SO_LITEM_ID"].ToString();
                    cmd2.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = SessionSoItem.Rows[i]["ITEM_NAME"].ToString();
                    cmd2.Parameters.Add("@Quantity", SqlDbType.Int).Value = SessionSoItem.Rows[i]["QUANTITY"].ToString();
                    cmd2.Parameters.Add("@Price", SqlDbType.Float).Value = SessionSoItem.Rows[i]["PRICE"].ToString();
                    cmd2.ExecuteNonQuery();

                }
            }
        }
        #endregion method lama

        #region method baru
        private void setInitialRow()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NO_URUT", typeof(int))); //untuk delete
            dt.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dt.Columns.Add(new DataColumn("TOTAL", typeof(float)));

            soItemId -= 1;

            if (SessionSoItem.Rows.Count < 1)
            {
                int rowcount = SessionSoItem.Rows.Count;
                dr = dt.NewRow();
                dr["NO_URUT"] = 1; //untuk delete
                dr["SALES_SO_LITEM_ID"] = soItemId;
                dr["ITEM_NAME"] = "";
                dr["QUANTITY"] = 0;
                dr["PRICE"] = 0;
                dr["TOTAL"] = 0;
                dt.Rows.Add(dr);
                GridInput.SetEditRow(rowcount);
                SessionSoItem = dt;
            }
            else if (SessionSoItem.Rows.Count >= 1)
            {
                int rowcount = SessionSoItem.Rows.Count;
                DataRow dr2 = null;
                dr2 = SessionSoItem.NewRow();
                dr2["SALES_SO_LITEM_ID"] = soItemId;
                dr2["ITEM_NAME"] = "";
                dr2["QUANTITY"] = 0;
                dr2["PRICE"] = 0;
                dr2["TOTAL"] = 0;
                SessionSoItem.Rows.Add(dr2);
                GridInput.SetEditRow(rowcount);
            }
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
            if (SessionSoItem != null)
            {
                foreach (DataRow dr in SessionSoItem.Rows)
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
            dt.Columns.Add(new DataColumn("NO_URUT", typeof(int))); //untuk delete
            dt.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dt.Columns.Add(new DataColumn("TOTAL", typeof(float)));
            int i;
            while (dr.Read())
            {
                DataRow drow = dt.NewRow();
                for (i = 0; i <= dt.Rows.Count; i++)
                {
                    Convert.ToInt32(i);
                }
                drow["NO_URUT"] = i;
                drow["SALES_SO_LITEM_ID"] = dr["SALES_SO_LITEM_ID"].ToString();
                drow["ITEM_NAME"] = dr["ITEM_NAME"].ToString();
                drow["QUANTITY"] = dr["QUANTITY"].ToString();
                drow["PRICE"] = dr["PRICE"].ToString();
                dt.Rows.Add(drow);
            }
            GridInput.DataSource = dt;
            GridInput.DataBind();
            SessionSoItem = dt;
            dr.Close();

        }
        #endregion method baru
    }
}