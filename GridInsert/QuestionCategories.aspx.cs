using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class QuestionCategories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }



    private void BindData()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("SELECT cat_id, cat_name FROM quest_categories", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        if (((LinkButton)GridView1.Rows[0].Cells[0].Controls[0]).Text == "Insert")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO quest_categories(cat_name) VALUES(@cat_name)";
            cmd.Parameters.Add("@cat_name", SqlDbType.VarChar).Value = ((TextBox)GridView1.Rows[0].Cells[2].Controls[0]).Text;

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE quest_categories SET cat_name=@cat_name WHERE cat_id=@cat_id";
            cmd.Parameters.Add("@cat_name", SqlDbType.VarChar).Value = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
        }


        GridView1.EditIndex = -1;
        BindData();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("SELECT cat_id, cat_name FROM quest_categories", con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        // Here we'll add a blank row to the returned DataTable
        DataRow dr = dt.NewRow();
        dt.Rows.InsertAt(dr, 0);
        //Creating the first row of GridView to be Editable
        GridView1.EditIndex = 0;
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //Changing the Text for Inserting a New Record
        ((LinkButton)GridView1.Rows[0].Cells[0].Controls[0]).Text = "Insert";

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE FROM quest_categories WHERE cat_id=@cat_id";
        cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);

        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        BindData();

    }


}
