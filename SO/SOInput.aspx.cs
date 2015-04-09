using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SO
{
    public partial class Grid : System.Web.UI.Page
    {
        #region session
        #endregion session
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            /*string ItemName = ((TextBox)GridInput.FooterRow.FindControl("txtItemName")).Text;
            string Quantity = ((TextBox)GridInput.FooterRow.FindControl("txtQuantity")).Text;
            string Price = ((TextBox)GridInput.FooterRow.FindControl("txtPrice")).Text;
            /*SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into customers(CustomerID, ContactName, CompanyName) " +
            "values(@CustomerID, @ContactName, @CompanyName);" +
            "select CustomerID,ContactName,CompanyName from customers";
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID;
            cmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = Price;
            GridView1.DataSource = GetData(cmd);
            GridView1.DataBind();*/
            TambahRow();

        }



        protected void GridInput_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridInput_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #region method
        private void TambahRow()
        {
            int RowIndex = 0;
            if(ViewState["CurrentTable"] != null){
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow dr = null;
                if(dt.Rows.Count > 0){
                    for (int i = 1; i <= dt.Rows.Count;i++ )
                    {
                        TextBox txtItemName = (TextBox)GridInput.Rows[RowIndex].Cells[1].FindControl("txtItem");
                        TextBox txtQuantity = (TextBox)GridInput.Rows[RowIndex].Cells[2].FindControl("txtQty");
                        TextBox txtPrice = (TextBox)GridInput.Rows[RowIndex].Cells[3].FindControl("txtprice");

                        dr = dt.NewRow();
                        dt.Rows[i - 1]["ITEM NAME"] = txtItemName.Text;
                        dt.Rows[i - 1]["QTY"] = txtQuantity.Text;
                        dt.Rows[i - 1]["PRICE"] = txtQuantity.Text;

                        RowIndex++;

                        }
                    dt.Rows.Add(dr);
                    ViewState["CurrentTable"] = dt;
                    GridInput.DataSource = dt;
                    GridInput.DataBind();
                }
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOList.aspx");
        }

        /*private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridInput.Rows[rowIndex].Cells[1].FindControl("txtItemName");
                        TextBox box2 = (TextBox)GridInput.Rows[rowIndex].Cells[2].FindControl("txtQuantity");
                        TextBox box3 = (TextBox)GridInput.Rows[rowIndex].Cells[3].FindControl("txtPrice");

                        box1.Text = dt.Rows[i]["Column1"].ToString();
                        box2.Text = dt.Rows[i]["Column2"].ToString();
                        box3.Text = dt.Rows[i]["Column3"].ToString();

                        rowIndex++;
                    }
                }
            }
        }*/
        #endregion
    }
}