using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SO
{
    public partial class SOList : System.Web.UI.Page
    {
        #region public variable

        public string m_connect = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;

        #endregion public variable

        #region page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ShowList();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                FindList();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SOInput.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Session["Edit"] = Convert.ToInt32(e.CommandArgument.ToString());

                if (e.CommandName == "Edit")
                {
                    Response.Redirect("SOInput.aspx?SOID=" + Session["Edit"]);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                ShowList();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlConnection cnDeleteSO = new SqlConnection(m_connect);
                cnDeleteSO.Open();
                string strDeleteSO = "uspSO_deleteso";
                SqlCommand cmdDeleteSO = new SqlCommand(strDeleteSO, cnDeleteSO);
                cmdDeleteSO.CommandType = CommandType.StoredProcedure;
                cmdDeleteSO.Parameters.Add("@p_SOID", SqlDbType.VarChar).Value = GridView1.DataKeys[e.RowIndex].Value.ToString();
                cmdDeleteSO.ExecuteNonQuery();
                cnDeleteSO.Close();
                ShowList();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion page event

        #region method
        protected void ShowList()
        {
            SqlConnection cnShowList = new SqlConnection(m_connect);
            cnShowList.Open();
            string strShowList = "uspSO_showlist";
            SqlCommand cmdShowList = new SqlCommand(strShowList, cnShowList);
            cmdShowList.CommandType = CommandType.StoredProcedure;
            DataSet dsShowList = new DataSet();
            SqlDataAdapter daShowList = new SqlDataAdapter(cmdShowList);
            daShowList.Fill(dsShowList);
            GridView1.DataSource = dsShowList;
            GridView1.DataBind();
            cnShowList.Close();
        }

        protected void FindList()
        {
            SqlConnection cnFindList = new SqlConnection(m_connect);
            SqlCommand cmdFindList = new SqlCommand("uspSO_findlist", cnFindList);
            cmdFindList.CommandType = CommandType.StoredProcedure;
            cmdFindList.Parameters.Add("@p_Keyword", SqlDbType.VarChar).Value = txtkey.Text;
            if (txtCalendar.Text != "")
            {
                cmdFindList.Parameters.Add("@p_OrderDate", SqlDbType.DateTime).Value = DateTime.Parse(txtCalendar.Text);
            }
            else
            {
                cmdFindList.Parameters.Add("@p_OrderDate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            DataSet dsFindList = new DataSet();
            SqlDataAdapter daFindAdapter = new SqlDataAdapter(cmdFindList);
            daFindAdapter.Fill(dsFindList);
            GridView1.DataSource = dsFindList;
            GridView1.DataBind();
            cnFindList.Close();
        }
        #endregion method

    }
}