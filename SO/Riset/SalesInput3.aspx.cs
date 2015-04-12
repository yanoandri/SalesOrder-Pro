using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;



namespace asp_3
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        public int SOID
        {
            get { return Convert.ToInt32(Request.QueryString["SOID"] == null ? "0" : Request.QueryString["SOID"].ToString()); }
        }

        #region Session
        private List<SO_Item> sessSO_Item
        {
            get { return (Session["sessSO_Item"] == null) ? new List<SO_Item>() : (List<SO_Item>)Session["sessSO_Item"]; }
            set { Session["sessSO_Item"] = value; }
        }

        private List<SO_Item> sessSO_ItemForDelete
        {
            get { return (Session["sessSO_ItemForDelete"] == null) ? new List<SO_Item>() : (List<SO_Item>)Session["sessSO_ItemForDelete"]; }
            set { Session["sessSO_ItemForDelete"] = value; }
        }

        private  int SALES_SO_ITEM_ID 
        {
            get { return Session["SALES_SO_ITEM_ID"] == null ? -1 : (int)Session["SALES_SO_ITEM_ID"] - 1; }
        
        }
        #endregion


        #region Form Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindDDLCustomer();

                sessSO_Item = new List<SO_Item>();
                BindData();
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesList.aspx");
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            AddRows(-1);
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    string strKoneksi = @"Data Source=seagoro-pc\sql2008;Initial Catalog=SalesOrder;User ID=sa;Password=sql2008";
                    SqlConnection conn = new SqlConnection(strKoneksi);
                    conn.Open();

                    if (SOID <= 0)
                    {

                        SqlCommand cmd = new SqlCommand("Insert into SALES_SO (SO_NO,ORDER_DATE,COM_CUSTOMER_ID,ADDRESS) values ('" + txtsales.Text + "','" + txtdate.Text + "','" + DDLCustomer.SelectedValue + "','" + txtaddres.Text + "') select @@identity ", conn);
                        
                        int iSoId = Convert.ToInt32(cmd.ExecuteScalar());

                        if (sessSO_Item != null)
                        {
                            
                            int itemCount;
                            itemCount = sessSO_Item.Count;
                            for (int i = 0; i < itemCount; i++)
                            {

                                string itemName = sessSO_Item[i].ITEM_NAME;
                                string quantity = sessSO_Item[i].QUANTITY;
                                string price = sessSO_Item[i].PRICE;


                                cmd = new SqlCommand("Insert into SALES_SO_ITEM (SALES_SO_ID,ITEM_NAME,QUANTITY,PRICE) values ('" + iSoId + "','" + itemName + "','" + quantity + "','" + price + "')", conn);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("UPDATE SALES_SO SET SO_NO='" + txtsales.Text + "',ORDER_DATE='" + txtdate.Text + "',COM_CUSTOMER_ID='" + DDLCustomer.SelectedValue + "',ADDRESS='" + txtaddres.Text + "' WHERE SALES_SO_ID=" + SOID.ToString(), conn);
                        cmd2.ExecuteNonQuery();


                        if (sessSO_Item != null)
                        {
                            int itemCount;
                            itemCount = sessSO_Item.Count;
                            for (int i = 0; i < itemCount; i++)
                            {

                                int ItemID = sessSO_Item[i].SALES_SO_ITEM_ID;
                                string itemName = sessSO_Item[i].ITEM_NAME;
                                string quantity = sessSO_Item[i].QUANTITY;
                                string price = sessSO_Item[i].PRICE;

                                if (ItemID >= 0)
                                {
                                    SqlCommand cmd3 = new SqlCommand("UPDATE SALES_SO_ITEM SET ITEM_NAME='" + itemName + "',QUANTITY='" + quantity + "',PRICE='" + price + "' WHERE SALES_SO_ITEM_ID=" + ItemID.ToString(), conn);
                                    cmd3.ExecuteNonQuery();
                                }

                                if (ItemID < 0)
                                {
                                    SqlCommand cmd3 = new SqlCommand("Insert into SALES_SO_ITEM (SALES_SO_ID,ITEM_NAME,QUANTITY,PRICE) values ('" + SOID + "','" + itemName + "','" + quantity + "','" + price + "')", conn);
                                    cmd3.ExecuteNonQuery();
                                }

                            }

                            if (sessSO_ItemForDelete != null)
                            {
                                for (int x = 0; x < sessSO_ItemForDelete.Count; x++)
                                {
                                    int ItemID2 = sessSO_ItemForDelete[x].SALES_SO_ITEM_ID;
                                    SqlCommand cmd3 = new SqlCommand("delete SALES_SO_ITEM where SALES_SO_ITEM_ID  =" + ItemID2, conn);
                                    cmd3.ExecuteNonQuery();
                                }

                            }

                        }
                    }

                    conn.Close();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Successfully'); window.location = 'SalesList.aspx';</script>");

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }


        #endregion

        #region Grid Event
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridInput.EditIndex = e.NewEditIndex;
            GridInput.DataSource = sessSO_Item;
            GridInput.DataBind();

        }

        protected void GridView1_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {

            GridInput.EditIndex = -1;

            if (sessSO_Item[e.RowIndex].ITEM_NAME == string.Empty &&
                sessSO_Item[e.RowIndex].QUANTITY == string.Empty &&
                sessSO_Item[e.RowIndex].PRICE == string.Empty)
            {
                RemoveRows(e.RowIndex);
            }

            GridInput.DataSource = sessSO_Item;
            GridInput.DataBind();

        }

        decimal sum = 0;
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int ItemID = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                List<SO_Item> listSO_Item = new List<SO_Item>();
                SO_Item oSO_Item_del = new SO_Item();

                listSO_Item = sessSO_ItemForDelete;
                oSO_Item_del.SALES_SO_ITEM_ID = ItemID;

                listSO_Item.Add(oSO_Item_del);

                sessSO_ItemForDelete = listSO_Item;

                RemoveRows(gvr.RowIndex);
                GridInput.DataSource = sessSO_Item;
                GridInput.DataBind();

            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow oRow = GridInput.Rows[e.RowIndex];
            List<SO_Item> listSO_Item = new List<SO_Item>();
            listSO_Item = sessSO_Item;

            TextBox txtItem = (TextBox)oRow.Cells[1].FindControl("txtItem");
            TextBox txtQty = (TextBox)oRow.Cells[2].FindControl("txtQty");
            TextBox txtprice = (TextBox)oRow.Cells[3].FindControl("txtprice");
            Label lblTotal = (Label)oRow.Cells[4].FindControl("lblTotal");

            listSO_Item[e.RowIndex].ITEM_NAME = txtItem.Text;
            listSO_Item[e.RowIndex].QUANTITY = txtQty.Text;
            listSO_Item[e.RowIndex].PRICE = txtprice.Text;
            listSO_Item[e.RowIndex].TOTAL = (Convert.ToInt32(txtQty.Text) * Convert.ToDouble(txtprice.Text)).ToString();

            sessSO_Item = listSO_Item;

            GridInput.EditIndex = -1;
            GridInput.DataSource = sessSO_Item;
            GridInput.DataBind();

        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblQty = (Label)e.Row.Cells[2].FindControl("lblqty");
                Label lblprice = (Label)e.Row.Cells[3].FindControl("lblprice");
                Label lblTotal = (Label)e.Row.Cells[4].FindControl("lbltotal");
                
                if (lblQty != null)
                {
                    int quantity = int.Parse(lblQty.Text.Trim());
                    int price = int.Parse(lblprice.Text.Trim());
                    int total = quantity * price;

                    lblTotal.Text = total.ToString();
                    sum += total;

                 }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                lblGrandTotal.Text = sum.ToString();
            }
        }
        #endregion

        #region Method
        private void AddRows(int iRowIndex)
        {
            SO_Item oSO_Item = new SO_Item();
            oSO_Item.SALES_SO_ITEM_ID = SALES_SO_ITEM_ID;
            oSO_Item.ITEM_NAME = string.Empty;
            oSO_Item.QUANTITY = string.Empty;
            oSO_Item.PRICE = string.Empty;

            sessSO_Item.Add(oSO_Item);
            
            GridInput.DataSource = sessSO_Item;
            GridInput.EditIndex = (iRowIndex == -1) ? sessSO_Item.Count - 1 : iRowIndex; //set edit index berdasarkan row
            GridInput.DataBind();
        }
        private void RemoveRows(int iRowIndex)
        {
            sessSO_Item.RemoveAt(iRowIndex);
        }
        #endregion

        #region Data Binding
        private void BindDDLCustomer()
        {
            string strKoneksi = @"Data Source=seagoro-pc\sql2008;Initial Catalog=SalesOrder;User ID=sa;Password=sql2008";
            SqlConnection con = new SqlConnection(strKoneksi);
            string com = "Select * from COM_CUSTOMER";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            DDLCustomer.DataSource = dt;
            DDLCustomer.DataTextField = "CUSTOMER_NAME";
            DDLCustomer.DataValueField = "COM_CUSTOMER_ID";
            DDLCustomer.DataBind();

            DDLCustomer.Items.Insert(0, new ListItem("Select One", "-1"));
            DDLCustomer.Items[0].Selected = true;
        }

        private void BindData()
        {
            string cnString = ConfigurationManager.ConnectionStrings["SalesOrderConnectionString2"].ConnectionString; ;
            SqlConnection conn = new SqlConnection(cnString);//tested and working
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT SALES_SO.SO_NO,SALES_SO.SALES_SO_ID,SALES_SO.ORDER_DATE, SALES_SO.ADDRESS,COM_CUSTOMER.CUSTOMER_NAME,COM_CUSTOMER.COM_CUSTOMER_ID FROM SALES_SO INNER JOIN COM_CUSTOMER ON SALES_SO.COM_CUSTOMER_ID=COM_CUSTOMER.COM_CUSTOMER_ID where SALES_SO_ID= " + SOID.ToString(), conn);

            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {

                txtsales.Text = rdr["SO_NO"].ToString();
                txtdate.Text = rdr["ORDER_DATE"].ToString();
                txtaddres.Text = rdr["ADDRESS"].ToString();
                DDLCustomer.SelectedValue = rdr["COM_CUSTOMER_ID"].ToString();

            }
            rdr.Close();

            string sql = "select SALES_SO_ITEM_ID,ITEM_NAME,QUANTITY, PRICE, QUANTITY * PRICE AS TOTAL  from SALES_SO_ITEM where SALES_SO_ID= " + SOID.ToString();

            SqlCommand cmd2 = new SqlCommand(sql, conn);

            DataSet ds1 = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd2);
            sda.Fill(ds1);

            if (ds1.Tables[0] != null)
            { 
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    SO_Item oSO_Item = new SO_Item();
                    oSO_Item.SALES_SO_ITEM_ID = Convert.ToInt32(ds1.Tables[0].Rows[i][0]);
                    oSO_Item.ITEM_NAME = ds1.Tables[0].Rows[i][1].ToString();
                    oSO_Item.QUANTITY = ds1.Tables[0].Rows[i][2].ToString();
                    oSO_Item.PRICE = ds1.Tables[0].Rows[i][3].ToString();
                    oSO_Item.TOTAL = ds1.Tables[0].Rows[i][4].ToString();

                    sessSO_Item.Add(oSO_Item);
                }

            }

            GridInput.DataSource = sessSO_Item;
            GridInput.DataBind();

            conn.Close();

        }
        #endregion
    }
}
