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

        public DataTable dt = new DataTable();

        public DataRow dr = null;

        #endregion session
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initTable();
                GridInput.DataSource = dt;
                GridInput.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            initTable();
            newRow();
            GridInput.DataSource = dt;
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
            //initTable();
            //GridInput.EditIndex = e.NewEditIndex;
            //GridInput.DataSource = dt;
            //GridInput.DataBind();
        }

        protected void GridInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            initTable();
            TextBox txtItem = (TextBox)GridInput.Rows[e.RowIndex].Cells[1].FindControl("txtItem");
            Label lblItem = (Label)GridInput.Rows[e.RowIndex].Cells[1].FindControl("lblitem");
            TextBox txtQty = (TextBox)GridInput.Rows[e.RowIndex].Cells[2].FindControl("txtQty");
            Label lblquantity = (Label)GridInput.Rows[e.RowIndex].Cells[2].FindControl("lblqty");
            TextBox txtPrice = (TextBox)GridInput.Rows[e.RowIndex].Cells[3].FindControl("txtprice");
            Label lblprice = (Label)GridInput.Rows[e.RowIndex].Cells[3].FindControl("lblprice");
            Label lblTotal = (Label)GridInput.Rows[e.RowIndex].Cells[4].FindControl("lblTotal");

            GridViewRow r = GridInput.Rows[e.RowIndex];
            //String str = ((TextBox)(r.Cells[1].Controls[0])).Text;

           
            dr = dt.NewRow();

            //dt.Rows.Add(new DataRow(lblItem.Text));
            dr["ITEM_NAME"] = txtItem.Text;
            dr["QUANTITY"] = txtQty.Text;
            dr["PRICE"] = txtPrice.Text;
            dr["TOTAL"] = (Convert.ToInt16(txtQty.Text) * Convert.ToDouble(txtPrice.Text)).ToString();
            //dt.Rows[r.DataItemIndex]["QUANTITY"] = lblquantity;
            //dt.Rows[r.DataItemIndex]["PRICE"] = lblprice;
            //dt.Rows[r.DataItemIndex]["TOTAL"] = (Convert.ToDouble(lblquantity) * Convert.ToDouble(lblprice));
            dt.Rows.Add(dr);
            GridInput.EditIndex = -1;
            GridInput.DataSource = dt;
            GridInput.DataBind();

            
        }

        protected void GridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOList.aspx");
        }

        #region method
        protected void initTable()
        {
            //dt = new DataTable();
            dt.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dt.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dt.Columns.Add(new DataColumn("TOTAL", typeof(float)));

        }

        protected void newRow()
        {
            int rowcount = dt.Rows.Count;
            dr = dt.NewRow();
            dr["SALES_SO_LITEM_ID"] = 1;
            dr["ITEM_NAME"] = "";
            dr["QUANTITY"] = 0;
            dr["PRICE"] = 0;
            dr["TOTAL"] = 0;
            dt.Rows.Add(dr);
            GridInput.SetEditRow(rowcount);
        }
        #endregion method
    }
}