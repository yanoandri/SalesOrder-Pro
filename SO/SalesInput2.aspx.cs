using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Threading;


namespace WebApplication1
{
    public partial class Add : System.Web.UI.Page
    {
        public string str = "SERVER=SEAGORO-PC\\SQL2008;Database=SalesOrder;Uid=sa;Pwd=sql2008";

        public string Flag
        {
            get { return (string)ViewState["Flag"]; }
            set { ViewState["Flag"] = value; }
        }

        public int SoID
        {
            get { return (int)ViewState["SoID"]; }
            set { ViewState["SoID"] = value; }
        }


        public DataTable DTDetail
        {
            get { return (DataTable)ViewState["DTDetail"]; }
            set { ViewState["DTDetail"] = value; }
        }

        public DataTable DT2
        {
            get { return (DataTable)ViewState["DT2"]; }
            set { ViewState["DT2"] = value; }
        }

        DataRow DR;



        public int JmlRow
        {
            get { return (int)ViewState["JmlRow"]; }
            set { ViewState["JmlRow"] = value; }
        }


        decimal GrandTotal = 0;

        public int IDtemp
        {
            get { return ViewState["IDtemp"] == null ? -1 : ((int)ViewState["IDtemp"]) - 1; }
            set { ViewState["IDtemp"] = value; }
        }

        public int RowID
        {
            get { return ViewState["RowID"] == null ? 1 : ((int)ViewState["RowID"]) + 1; }
            set { ViewState["RowID"] = value; }
        }




        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Flag = Request.QueryString["Flag"];
                SoID = Convert.ToInt32(Request.QueryString["SoID"]);

                SqlConnection conn = new SqlConnection(str);
                SqlCommand command = new SqlCommand();
                conn.Open();
                command.Connection = conn;
                DataTable DTCustomer = new DataTable();
                command.CommandText = "sp_SalesCustomer";
                command.CommandType = CommandType.StoredProcedure;
                DTCustomer.Load(command.ExecuteReader());
                DDLCustomer.DataValueField = "CustomerID";
                DDLCustomer.DataTextField = "CustomerName";
                DDLCustomer.DataSource = DTCustomer;
                DDLCustomer.DataBind();
                DDLCustomer.Items.Insert(0, " Select One ");
                CreateDataTable();



                if (Flag == "EDIT")
                {

                    DataTable DT = new DataTable();
                    command.CommandText = "sp_GetSales";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@SOID", SqlDbType.VarChar);
                    command.Parameters["@SOID"].Value = SoID; 
                    
                    DT.Load(command.ExecuteReader());

                    txtSalesOrderNo.Text = DT.Rows[0]["SO_NO"].ToString();
                    txtOrderDate.Text = DT.Rows[0]["ORDER_DATE"].ToString();
                    txtAddress.Value = DT.Rows[0]["ADDRESS"].ToString();
                    DDLCustomer.SelectedValue = DT.Rows[0]["Customer_ID"].ToString();



                    SqlCommand command2 = new SqlCommand("sp_SalesListDetail", conn);
                    command2.CommandType = CommandType.StoredProcedure;
                    
                    
                    command2.Parameters.Add("@SOID", SqlDbType.Int);
                    command2.Parameters["@SOID"].Value = SoID;
                    DTDetail.Load(command2.ExecuteReader());

                    DT2 = new DataTable();
                    DT2.Load(command2.ExecuteReader());


                }


                GridInput.DataSource = DTDetail;
                GridInput.DataBind();

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand command = new SqlCommand();
            SqlCommand command2 = new SqlCommand();
            SqlTransaction transaction;
            transaction = conn.BeginTransaction();



            try
            {

                if (Flag == "ADD")
                {
                    command = new SqlCommand("sp_SalesSave", conn, transaction);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@SOID", SqlDbType.Int);
                    command.Parameters["@SOID"].Direction = ParameterDirection.Output;

                    command.Parameters.Add("@SoNo", SqlDbType.VarChar);
                    command.Parameters["@SoNo"].Value = txtSalesOrderNo.Text;

                    command.Parameters.Add("@SoDate", SqlDbType.DateTime);
                    command.Parameters["@SoDate"].Value = Convert.ToDateTime(txtOrderDate.Text);

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = Convert.ToInt32(DDLCustomer.SelectedValue);

                    command.Parameters.Add("@Address", SqlDbType.VarChar);
                    command.Parameters["@Address"].Value = txtAddress.Value;

                    command.ExecuteNonQuery();

                    int GetSOID = Convert.ToInt32(command.Parameters["@SOID"].Value);

                    if (DTDetail != null)
                    {
                        for (int i = 0; i < DTDetail.Rows.Count; i++)
                        {

                            command2 = new SqlCommand("sp_SalesSaveDetail_2", conn, transaction);
                            command2.CommandType = CommandType.StoredProcedure;
                            command2.Parameters.Add("@SOID", SqlDbType.Int);
                            command2.Parameters["@SOID"].Value = GetSOID;
                            command2.Parameters.Add("@ItemName", SqlDbType.VarChar);
                            command2.Parameters["@ItemName"].Value = DTDetail.Rows[i]["ItemName"].ToString();
                            command2.Parameters.Add("@Quantity", SqlDbType.Int);
                            command2.Parameters["@Quantity"].Value = DTDetail.Rows[i]["Quantity"].ToString();
                            command2.Parameters.Add("@Price", SqlDbType.Decimal);
                            command2.Parameters["@Price"].Value = DTDetail.Rows[i]["Price"].ToString();
                            command2.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                }

                else if (Flag == "EDIT")
                {

                    command = new SqlCommand("sp_SalesEdit", conn, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@SOID", SqlDbType.Int);
                    command.Parameters["@SOID"].Value = SoID;

                    command.Parameters.Add("@SoNo", SqlDbType.VarChar);
                    command.Parameters["@SoNo"].Value = txtSalesOrderNo.Text;

                    command.Parameters.Add("@SoDate", SqlDbType.DateTime);
                    command.Parameters["@SoDate"].Value = Convert.ToDateTime(txtOrderDate.Text);

                    command.Parameters.Add("@CustomerID", SqlDbType.Int);
                    command.Parameters["@CustomerID"].Value = Convert.ToInt32(DDLCustomer.SelectedValue);

                    command.Parameters.Add("@Address", SqlDbType.VarChar);
                    command.Parameters["@Address"].Value = txtAddress.Value;
                    command.ExecuteNonQuery();



                    if (DTDetail != null)
                    {
                        for (int i = 0; i < DTDetail.Rows.Count; i++)
                        {
                            int J = Convert.ToInt32(DTDetail.Rows[i]["ItemID"].ToString());



                            if (J < 0)
                            {
                                command2 = new SqlCommand("sp_SalesSaveDetail_2", conn, transaction);
                                command2.CommandType = CommandType.StoredProcedure;
                                command2.Parameters.Add("@SOID", SqlDbType.Int);
                                command2.Parameters["@SOID"].Value = SoID;
                                command2.Parameters.Add("@ItemName", SqlDbType.VarChar);
                                command2.Parameters["@ItemName"].Value = DTDetail.Rows[i]["ItemName"].ToString();
                                command2.Parameters.Add("@Quantity", SqlDbType.Int);
                                command2.Parameters["@Quantity"].Value = DTDetail.Rows[i]["Quantity"].ToString();
                                command2.Parameters.Add("@Price", SqlDbType.Decimal);
                                command2.Parameters["@Price"].Value = DTDetail.Rows[i]["Price"].ToString();
                                command2.ExecuteNonQuery();
                            }
                            else if (J > 0)
                            {
                                command2 = new SqlCommand("sp_SalesEditDetail", conn, transaction);
                                command2.CommandType = CommandType.StoredProcedure;

                                command2.Parameters.Add("@ItemID", SqlDbType.Int);
                                command2.Parameters["@ItemID"].Value = Convert.ToInt32(DTDetail.Rows[i]["ItemID"].ToString());
                                command2.Parameters.Add("@ItemName", SqlDbType.VarChar);
                                command2.Parameters["@ItemName"].Value = DTDetail.Rows[i]["ItemName"].ToString();
                                command2.Parameters.Add("@Quantity", SqlDbType.Int);
                                command2.Parameters["@Quantity"].Value = DTDetail.Rows[i]["Quantity"].ToString();
                                command2.Parameters.Add("@Price", SqlDbType.Decimal);
                                command2.Parameters["@Price"].Value = DTDetail.Rows[i]["Price"].ToString();
                                command2.ExecuteNonQuery();
                            }

                        }
                    }


                    var rowsOnlyInDT1 = from r1 in DT2.AsEnumerable()
                                        join r2 in DTDetail.AsEnumerable()
                                        on r1.Field<int>("ItemID") equals r2.Field<int>("ItemID") into groupJoin
                                        from subRow in groupJoin.DefaultIfEmpty()
                                        where subRow == null
                                        select r1;

                    DataTable result = rowsOnlyInDT1.CopyToDataTable();
                    if (result != null)
                    {
                        for (int i = 0; i < result.Rows.Count; i++)
                        {
                            command2 = new SqlCommand("sp_SalesDeleteDetail", conn, transaction);
                            command2.CommandType = CommandType.StoredProcedure;

                            command2.Parameters.Add("@ItemID", SqlDbType.Int);
                            command2.Parameters["@ItemID"].Value = Convert.ToInt32(result.Rows[i]["ItemID"].ToString());

                            command2.ExecuteNonQuery();
                        }
                    }



                    transaction.Commit();
                }
                Session.Remove("Table1");
                //Response.Redirect("SalesList.aspx");
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Successfully'); window.location = 'SalesList.aspx';</script>");
            }
            catch (Exception)
            {
            }
          
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("Table1");
            Session["Table1"] = null;
            Response.Redirect("SalesList.aspx");
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {

            CreateDataTable();
            CreatNewRow();
            GridInput.DataSource = DTDetail;
            GridInput.DataBind();
            btnAddItem.Visible = false;

        }

        protected void CreateDataTable()
        {
            DTDetail = new DataTable();
            DTDetail.Columns.Add("RowID", typeof(Int32));
            DTDetail.Columns.Add("ItemID", typeof(Int32));
            DTDetail.Columns.Add("ItemName", typeof(string));
            DTDetail.Columns.Add("Quantity", typeof(Int32));
            DTDetail.Columns.Add("Price", typeof(float));
            DTDetail.Columns.Add("Total", typeof(float));

            if (Session["Table1"] == null)
            {
                Session.Add("Table1", DTDetail);
            }
            else
            {
                DTDetail = (DataTable)Session["Table1"];
            }

        }

        private void CreatNewRow()
        {

            JmlRow = DTDetail.Rows.Count;
            DR = DTDetail.NewRow();
            DR["ItemID"] = IDtemp;
            DR["ItemName"] = "";
            DR["Quantity"] = "0";
            DR["Price"] = "0";
            DR["Total"] = "0";
            IDtemp = (int)DR["ItemID"];
            DTDetail.Rows.Add(DR);
            GridInput.SetEditRow(JmlRow);


        }




        protected void GridViewInput_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            CreateDataTable();
            Label i = (Label)GridInput.Rows[e.RowIndex].FindControl("lblRowID");
            DTDetail.Rows.RemoveAt(Convert.ToInt32(i.Text) - 1);
            GridInput.DataSource = DTDetail;
            GridInput.DataBind();

        }

        protected void GridViewInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CreateDataTable();

            TextBox lblItemName = (TextBox)GridInput.Rows[e.RowIndex].FindControl("txtItemName");
            TextBox lblQty = (TextBox)GridInput.Rows[e.RowIndex].FindControl("txtQty");
            TextBox lblPrice = (TextBox)GridInput.Rows[e.RowIndex].FindControl("txtPrice");
            Label lblTotal = (Label)GridInput.Rows[e.RowIndex].FindControl("lblTotal");

            GridViewRow row = GridInput.Rows[e.RowIndex];
            DTDetail.Rows[row.DataItemIndex]["ItemName"] = lblItemName.Text;
            DTDetail.Rows[row.DataItemIndex]["Quantity"] = lblQty.Text;
            DTDetail.Rows[row.DataItemIndex]["Price"] = lblPrice.Text;
            DTDetail.Rows[row.DataItemIndex]["Total"] = (Convert.ToInt32(lblQty.Text) * Convert.ToDouble(lblPrice.Text)).ToString();


            GridInput.EditIndex = -1;
            GridInput.DataSource = DTDetail;
            GridInput.DataBind();
            btnAddItem.Visible = true;

        }

        protected void GridViewInput_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CreateDataTable();
            GridInput.EditIndex = e.NewEditIndex;
            GridInput.DataSource = DTDetail;
            GridInput.DataBind();
        }

        protected void GridViewInput_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridInput.EditIndex = -1;
            CreateDataTable();
            GridInput.DataSource = DTDetail;
            GridInput.DataBind();
            btnAddItem.Visible = true;
        }

        protected void GridViewInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < DTDetail.Rows.Count; i++)
                {
                    DTDetail.Rows[i]["RowID"] = i + 1;
                }


                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Decimal Total = Convert.ToDecimal(lblTotal.Text);
                GrandTotal += Total;


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                lblGrandTotal.Text = String.Format("{0:N}", GrandTotal);
            }
        }




    }
}