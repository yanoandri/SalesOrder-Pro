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


        #endregion session
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOList.aspx");
        }

        #region method

     
        /*protected void ShowGridEdit()
        {
            SqlConnection cn = new SqlConnection(strcn);
            cn.Open();
            SqlCommand cmd = new SqlCommand("spx_geteditsalesitem",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            GridInput.DataSource = ds;
            GridInput.DataBind();
        }*/
        #endregion method
    }
}