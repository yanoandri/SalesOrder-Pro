using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SO
{
    public partial class SOInput2 : System.Web.UI.Page
    {
        #region session and public variable
        public string m_strcn = ConfigurationManager.ConnectionStrings["SOConnectionString"].ConnectionString;

        public DataRow m_drInitTable = null;

        public int m_SOID
        {
            get { return (Session["Edit"]) == null ? 0 : (int)Session["Edit"]; }
            set { Session["Edit"] = value; }
        }

        public DataTable m_SessionSoItem
        {
            get { return (Session["SessionSoItem"]) == null ? new DataTable() : (DataTable)Session["SessionSoItem"]; }
            set { Session["SessionSoItem"] = value; }
        }

        public int m_soItemId
        {
            get { return (ViewState["SOITEMID"]) == null ? 0 : (int)ViewState["SOITEMID"]; }
            set { ViewState["SOITEMID"] = value; }
        }

        #endregion session and public variable

        #region page event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (m_SOID != 0)
                    {
                        retrieveData();
                    }

                }
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
                setInitialRow();
                GridInput.DataSource = m_SessionSoItem;
                GridInput.DataBind();
                btnAdd.Visible = false;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                m_SessionSoItem.Rows.RemoveAt(e.RowIndex);
                GridInput.DataSource = m_SessionSoItem;
                GridInput.DataBind();
                btnAdd.Visible = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridInput.EditIndex = e.NewEditIndex;
                GridInput.DataSource = m_SessionSoItem;
                GridInput.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Double dGrandtotal = 0;
        protected void GridInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                Label lblquantity = (Label)e.Row.FindControl("lblqty");
                Label lblprice = (Label)e.Row.FindControl("lblprice");
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                Label lblOrder = (Label)e.Row.FindControl("lblUrut");
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int iNoUrut = 0; iNoUrut < m_SessionSoItem.Rows.Count; iNoUrut++)
                    {
                        m_SessionSoItem.Rows[iNoUrut]["NO_URUT"] = iNoUrut + 1;
                    }

                    if (lblquantity == null || lblprice == null)
                    {
                    }
                    else
                    {
                        lblTotal.Text = (Convert.ToInt64(lblquantity.Text) * Convert.ToDouble(lblprice.Text)).ToString("#,##0.##");
                        dGrandtotal += Convert.ToDouble(lblTotal.Text);
                    }
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                    lblGrandTotal.Text = dGrandtotal.ToString("#,##0.##");
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                TextBox txtItem = (TextBox)GridInput.Rows[e.RowIndex].Cells[1].FindControl("txtItem");
                TextBox txtQty = (TextBox)GridInput.Rows[e.RowIndex].Cells[2].FindControl("txtQty");
                TextBox txtPrice = (TextBox)GridInput.Rows[e.RowIndex].Cells[3].FindControl("txtprice");
                GridViewRow rGridRow = GridInput.Rows[e.RowIndex];
                m_SessionSoItem.Rows[rGridRow.DataItemIndex]["ITEM_NAME"] = txtItem.Text;
                m_SessionSoItem.Rows[rGridRow.DataItemIndex]["QUANTITY"] = txtQty.Text;
                m_SessionSoItem.Rows[rGridRow.DataItemIndex]["PRICE"] = txtPrice.Text;
                GridInput.EditIndex = -1;
                GridInput.DataSource = m_SessionSoItem;
                GridInput.DataBind();
                btnAdd.Visible = true;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                m_SessionSoItem.Rows.RemoveAt(e.RowIndex - 1);
                GridInput.DataSource = m_SessionSoItem;
                GridInput.DataBind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridInput_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    int iNoUrut = Convert.ToInt32(e.CommandArgument);
                    GridInput.DeleteRow(iNoUrut);
                    GridInput.DataSource = m_SessionSoItem;
                    GridInput.DataBind();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_SOID != 0)
                {
                    #region remove old SO Item
                    SqlConnection cnDatasetDetail = new SqlConnection(m_strcn);
                    cnDatasetDetail.Open();
                    SqlCommand cmdSelectDetail = new SqlCommand("uspSO_detailItem", cnDatasetDetail);
                    cmdSelectDetail.CommandType = CommandType.StoredProcedure;
                    cmdSelectDetail.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
                    DataSet dsDetaiItem = new DataSet();
                    SqlDataAdapter daDetailItem = new SqlDataAdapter(cmdSelectDetail);
                    daDetailItem.Fill(dsDetaiItem);
                    foreach (DataRow drFromDatabase in dsDetaiItem.Tables[0].Rows)
                    {
                        Boolean blsDbisfound = false;
                        foreach (DataRow drFromGrid in m_SessionSoItem.Rows)
                        {
                            if (Convert.ToInt32(drFromDatabase["SALES_SO_LITEM_ID"]) == Convert.ToInt32(drFromGrid["SALES_SO_LITEM_ID"]))
                            {
                                SqlCommand cmdUpdateSO = new SqlCommand("uspSO_updateSO", cnDatasetDetail);
                                cmdUpdateSO.CommandType = CommandType.StoredProcedure;
                                cmdUpdateSO.Parameters.Add("@p_SONO", SqlDbType.VarChar).Value = txtsales.Text;
                                cmdUpdateSO.Parameters.Add("@p_OrderDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
                                cmdUpdateSO.Parameters.Add("@p_Customer", SqlDbType.Int).Value = DDLCustomer.SelectedValue;
                                cmdUpdateSO.Parameters.Add("@p_Address", SqlDbType.VarChar).Value = txtaddres.Text;
                                cmdUpdateSO.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
                                cmdUpdateSO.ExecuteNonQuery();
                                if (m_SessionSoItem != null)
                                {
                                    SqlCommand cmdCheckItem = new SqlCommand("uspSO_checkItem", cnDatasetDetail);
                                    cmdCheckItem.CommandType = CommandType.StoredProcedure;
                                    cmdCheckItem.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
                                    cmdCheckItem.Parameters.Add("@p_ITEMID", SqlDbType.Int).Value = drFromGrid["SALES_SO_LITEM_ID"].ToString();
                                    cmdCheckItem.Parameters.Add("@p_ItemName", SqlDbType.VarChar).Value = drFromGrid["ITEM_NAME"].ToString();
                                    cmdCheckItem.Parameters.Add("@p_Quantity", SqlDbType.Int).Value = drFromGrid["QUANTITY"].ToString();
                                    cmdCheckItem.Parameters.Add("@p_Price", SqlDbType.Float).Value = drFromGrid["PRICE"].ToString();
                                    cmdCheckItem.ExecuteNonQuery();
                                }
                                blsDbisfound = true;
                                break;
                            }
                        }
                        if (!blsDbisfound)
                        {
                            int iRowDB = Convert.ToInt32(drFromDatabase["SALES_SO_LITEM_ID"]);
                            SqlCommand cmdDeleteItemID = new SqlCommand("uspSO_deleteitemid", cnDatasetDetail);
                            cmdDeleteItemID.CommandType = CommandType.StoredProcedure;
                            cmdDeleteItemID.Parameters.Add("@p_ITEMID", SqlDbType.Int).Value = iRowDB;
                            cmdDeleteItemID.ExecuteNonQuery();
                        }
                    }
                    #endregion remove old SO Item
                    #region update new SO Item
                    foreach (DataRow drFromGrid in m_SessionSoItem.Rows)
                    {
                        if (Convert.ToInt32(drFromGrid["SALES_SO_LITEM_ID"]) > 0) //convert ke integer
                        {
                            SqlCommand cmdUpdateSO2 = new SqlCommand("uspSO_updateSO", cnDatasetDetail);
                            cmdUpdateSO2.CommandType = CommandType.StoredProcedure;
                            cmdUpdateSO2.Parameters.Add("@p_SONO", SqlDbType.VarChar).Value = txtsales.Text;
                            cmdUpdateSO2.Parameters.Add("@p_OrderDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
                            cmdUpdateSO2.Parameters.Add("@p_Customer", SqlDbType.Int).Value = DDLCustomer.SelectedValue;
                            cmdUpdateSO2.Parameters.Add("@p_Address", SqlDbType.VarChar).Value = txtaddres.Text;
                            cmdUpdateSO2.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
                            cmdUpdateSO2.ExecuteNonQuery();
                            if (m_SessionSoItem != null)
                            {
                                SqlCommand cmdCheckItem2 = new SqlCommand("uspSO_checkItem", cnDatasetDetail);
                                cmdCheckItem2.CommandType = CommandType.StoredProcedure;
                                cmdCheckItem2.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
                                cmdCheckItem2.Parameters.Add("@p_ITEMID", SqlDbType.Int).Value = drFromGrid["SALES_SO_LITEM_ID"].ToString();
                                cmdCheckItem2.Parameters.Add("@p_ItemName", SqlDbType.VarChar).Value = drFromGrid["ITEM_NAME"].ToString();
                                cmdCheckItem2.Parameters.Add("@p_Quantity", SqlDbType.Int).Value = drFromGrid["QUANTITY"].ToString();
                                cmdCheckItem2.Parameters.Add("@p_Price", SqlDbType.Float).Value = drFromGrid["PRICE"].ToString();
                                cmdCheckItem2.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            if (m_SessionSoItem != null)
                            {
                                SqlCommand cmdInsertSOItem = new SqlCommand("uspSO_insertSOItem", cnDatasetDetail);
                                cmdInsertSOItem.CommandType = CommandType.StoredProcedure;
                                cmdInsertSOItem.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
                                cmdInsertSOItem.Parameters.Add("@p_ItemName", SqlDbType.VarChar).Value = drFromGrid["ITEM_NAME"].ToString();
                                cmdInsertSOItem.Parameters.Add("@p_Quantity", SqlDbType.Int).Value = drFromGrid["QUANTITY"].ToString();
                                cmdInsertSOItem.Parameters.Add("@p_Price", SqlDbType.Float).Value = drFromGrid["PRICE"].ToString();
                                cmdInsertSOItem.ExecuteNonQuery();
                            }
                        }
                    }
                    Session.RemoveAll();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Update Succesful!'); window.location = 'SOList.aspx';</script>");
                    #endregion update new SO Item
                }
                else
                {
                    insertData();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Session.RemoveAll();
                Response.Redirect("SOList.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion page event

        #region method
        private void setInitialRow()
        {
            DataTable dtInitialTable = new DataTable();
            dtInitialTable.Columns.Add(new DataColumn("NO_URUT", typeof(int))); //untuk delete
            dtInitialTable.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dtInitialTable.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dtInitialTable.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dtInitialTable.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dtInitialTable.Columns.Add(new DataColumn("TOTAL", typeof(float)));
            m_soItemId -= 1;
            if (m_SessionSoItem.Rows.Count < 1)
            {
                int iRowCount = m_SessionSoItem.Rows.Count;
                m_drInitTable = dtInitialTable.NewRow();
                m_drInitTable["NO_URUT"] = 1;
                m_drInitTable["SALES_SO_LITEM_ID"] = m_soItemId;
                dtInitialTable.Rows.Add(m_drInitTable);
                GridInput.SetEditRow(iRowCount);
                m_SessionSoItem = dtInitialTable;
            }
            else if (m_SessionSoItem.Rows.Count >= 1)
            {
                int iRowCount = m_SessionSoItem.Rows.Count;
                DataRow drInitialTable = null;
                drInitialTable = m_SessionSoItem.NewRow();
                drInitialTable["SALES_SO_LITEM_ID"] = m_soItemId;
                m_SessionSoItem.Rows.Add(drInitialTable);
                GridInput.SetEditRow(iRowCount);
            }
        }

        private void insertData()
        {
            SqlConnection cnInsertData = new SqlConnection(m_strcn);
            cnInsertData.Open();
            SqlCommand cmdInsertSO = new SqlCommand("uspSO_insertSO", cnInsertData);
            cmdInsertSO.CommandType = CommandType.StoredProcedure;
            cmdInsertSO.Parameters.Add("@p_SONO", SqlDbType.VarChar).Value = txtsales.Text;
            cmdInsertSO.Parameters.Add("@p_OrderDate", SqlDbType.DateTime).Value = Convert.ToDateTime(txtdate.Text);
            cmdInsertSO.Parameters.Add("@p_CUSTOMER", SqlDbType.Int).Value = DDLCustomer.SelectedValue;
            cmdInsertSO.Parameters.Add("@p_ADDRESS", SqlDbType.VarChar).Value = txtaddres.Text;
            string strGetValue = cmdInsertSO.ExecuteScalar().ToString();
            if (m_SessionSoItem != null)
            {
                foreach (DataRow drDetailItem in m_SessionSoItem.Rows)
                {
                    SqlCommand cmdInsertSOItem = new SqlCommand("uspSO_insertSOItem", cnInsertData);
                    cmdInsertSOItem.CommandType = CommandType.StoredProcedure;
                    cmdInsertSOItem.Parameters.Add("@p_SOID", SqlDbType.Int).Value = strGetValue;
                    cmdInsertSOItem.Parameters.Add("@p_ItemName", SqlDbType.VarChar).Value = drDetailItem["ITEM_NAME"].ToString();
                    cmdInsertSOItem.Parameters.Add("@p_Quantity", SqlDbType.Int).Value = drDetailItem["QUANTITY"].ToString();
                    cmdInsertSOItem.Parameters.Add("@p_Price", SqlDbType.Float).Value = drDetailItem["PRICE"].ToString();
                    int iInsert = cmdInsertSOItem.ExecuteNonQuery();
                    if (iInsert == 1)
                    {
                        Session.RemoveAll();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('Save Successful!'); window.location = 'SOList.aspx';</script>");
                    }
                }
            }
        }

        private void retrieveData()
        {
            SqlConnection cnRetrieve = new SqlConnection(m_strcn);
            cnRetrieve.Open();
            SqlCommand cmdRetrieveSO = new SqlCommand("SELECT CONVERT(VARCHAR(11),ORDER_DATE,21) as ORDER_DATE, ADDRESS, SO_NO, COM_CUSTOMER_ID FROM SALES_SO WITH (NOLOCK) WHERE SALES_SO_ID = @p_SOID", cnRetrieve);
            cmdRetrieveSO.CommandType = CommandType.Text;
            cmdRetrieveSO.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
            SqlDataReader drSO;
            drSO = cmdRetrieveSO.ExecuteReader();
            while (drSO.Read())
            {
                txtsales.Text = drSO["SO_NO"].ToString();
                txtaddres.Text = drSO["ADDRESS"].ToString();
                txtdate.Text = drSO["ORDER_DATE"].ToString();
                DDLCustomer.SelectedValue = drSO["COM_CUSTOMER_ID"].ToString();
            }
            drSO.Close();
            SqlCommand cmdRetrieveSOItem = new SqlCommand("uspSO_detailItem", cnRetrieve);
            cmdRetrieveSOItem.CommandType = CommandType.StoredProcedure;
            cmdRetrieveSOItem.Parameters.Add("@p_SOID", SqlDbType.Int).Value = m_SOID;
            drSO = cmdRetrieveSOItem.ExecuteReader();
            DataTable dtDetailItem = new DataTable();
            dtDetailItem.Columns.Add(new DataColumn("NO_URUT", typeof(int))); //untuk delete
            dtDetailItem.Columns.Add(new DataColumn("SALES_SO_LITEM_ID", typeof(int)));
            dtDetailItem.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dtDetailItem.Columns.Add(new DataColumn("QUANTITY", typeof(int)));
            dtDetailItem.Columns.Add(new DataColumn("PRICE", typeof(float)));
            dtDetailItem.Columns.Add(new DataColumn("TOTAL", typeof(float)));
            int iNoUrut;
            while (drSO.Read())
            {
                DataRow drDetailItem = dtDetailItem.NewRow();
                for (iNoUrut = 0; iNoUrut <= dtDetailItem.Rows.Count; iNoUrut++)
                {
                    Convert.ToInt32(iNoUrut);
                }
                drDetailItem["NO_URUT"] = iNoUrut;
                drDetailItem["SALES_SO_LITEM_ID"] = drSO["SALES_SO_LITEM_ID"].ToString();
                drDetailItem["ITEM_NAME"] = drSO["ITEM_NAME"].ToString();
                drDetailItem["QUANTITY"] = drSO["QUANTITY"].ToString();
                drDetailItem["PRICE"] = drSO["PRICE"].ToString();
                dtDetailItem.Rows.Add(drDetailItem);
            }
            GridInput.DataSource = dtDetailItem;
            GridInput.DataBind();
            m_SessionSoItem = dtDetailItem;
            drSO.Close();

        }
        #endregion method
    }
}