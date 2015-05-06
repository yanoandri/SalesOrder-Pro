using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using Telerik.Web.UI;

public partial class Security_UserLogDetail : PFSBasePage
{
    #region QueryString
    private int qs_iUserLogID
    {
        get { return Request.QueryString["UserLogID"] == null ? 0 : Convert.ToInt32(Request.QueryString["UserLogID"]); }
    }
    private string qs_bIsUpdate
    {
        get { return Request.QueryString["isUpdate"] == null ? "0" : Convert.ToString(Request.QueryString["isUpdate"]); }
    }
    #endregion

    #region Properties
    string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        string sRefNumber = PFSCommon.GenerateRefNumber();
        try
        {
            if (!IsPostBack)
            {
                UserLog oUserLog = new UserLog(qs_iUserLogID);
                oUserLog.DAL_Load();

                if (oUserLog.Detail != "FILTERING VIEW LIST")
                {
                    string sXMLDetail = PFSXMLTools.FormatXml(oUserLog.Detail);
                    tbUserLogDetail.Text = sXMLDetail.Replace('<', '[');
                    tbUserLogDetail.Text = tbUserLogDetail.Text.Replace('>', ']');
                }
                else
                {
                    tbUserLogDetail.Text = oUserLog.Detail.Replace('<', '['); ;
                    tbUserLogDetail.Text = tbUserLogDetail.Text.Replace('>', ']'); ;
                }

                tbUserLogDetail.Visible = false;

                HtmlTable oTable = new HtmlTable();
                HtmlTable oLastTable = new HtmlTable();
                oTable.CellPadding = 0;
                oTable.CellSpacing = 0;
                oLastTable.CellPadding = 0;
                oLastTable.CellSpacing = 0;
                StringReader stream = new StringReader(PFSXMLTools.FormatXml(oUserLog.Detail));
                StringReader streamPreviousDetail = new StringReader(PFSXMLTools.FormatXml(oUserLog.PreviousDetail));
                XmlTextReader oReader = new XmlTextReader(stream);
                XmlTextReader oReaderPreviousDetail = new XmlTextReader(streamPreviousDetail);
                StringBuilder sb = new StringBuilder();
                DataSet dsTest = new DataSet();
                DataSet dsPreviousDetail = new DataSet();
                int iColumnNumber = 1;
                RadGrid oPreviousGrid = new RadGrid();
                RadGrid oGrid = new RadGrid();

                dsTest.ReadXml(oReader);
                dsPreviousDetail.ReadXml(oReaderPreviousDetail);

                dsTest.EnforceConstraints = dsPreviousDetail.EnforceConstraints = false;

                #region Previous Detail
                if (qs_bIsUpdate == "1")
                {
                    tdAuditLogData.Visible = tdGridData.Visible = true;
                    foreach (DataTable dtTable in dsPreviousDetail.Tables)
                    {
                        for (int i = 0; i < dtTable.Columns.Count; i++)
                        {
                            if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower().Contains("code") && !oUserLog.PreviousDetail.Contains("<SysParam"))
                            {
                                dtTable.Columns.RemoveAt(i);
                                i--;
                            }
                            else if (oUserLog.PreviousDetail.Contains("<User") && !dtTable.Columns[i].ColumnName.Contains("_"))
                            {
                                if (dtTable.TableName == "UserGroup")
                                {
                                    if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "groupid" && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "groupname")
                                    {
                                        dtTable.Columns.RemoveAt(i);
                                        i--;
                                    }
                                }

                                if (dtTable.TableName == "UserDetail")
                                {
                                    if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "BranchCode"
                                        && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "userid"
                                        && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "username"
                                        && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "fullname")
                                    {
                                        dtTable.Columns.RemoveAt(i);
                                        i--;
                                    }
                                }
                            }
                            else if (oUserLog.PreviousDetail.Contains("<SysParam") && !(dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() == "code" || dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() == "value" || dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() == "description"))
                            {
                                dtTable.Columns.RemoveAt(i);
                                i--;
                            }
                        }

                        //** TABLE RELATIONS **//
                        if (dtTable.ParentRelations.Count > 0 && dtTable.ChildRelations.Count > 0)
                        {
                            continue;
                        }
                        //** CHILD TABLES **//
                        else if (dtTable.ParentRelations.Count > 0)
                        {
                            DataTable dtNewTable = new DataTable();
                            int iGridNumber = 1;

                            dtNewTable.Columns.Add("No");
                            foreach (DataColumn dc in dtTable.Columns)
                            {
                                //loop for header grid
                                dtNewTable.Columns.Add(dc.ColumnName);
                            }

                            foreach (DataRow dr in dtTable.Rows)
                            {
                                DataRow drNewRow = dtNewTable.Rows.Add();
                                drNewRow[0] = iGridNumber;
                                int iCountRow = 1;
                                foreach (DataColumn dc in dtTable.Columns)
                                {
                                    //loop for data grid

                                    drNewRow[iCountRow] = dr[iCountRow - 1];
                                    if (oUserLog.PreviousDetail.Contains("<SysParam") && iCountRow == 1)
                                    {
                                        drNewRow[iCountRow] = drNewRow[iCountRow].ToString().Replace("_", " ");
                                    }
                                    iCountRow++;

                                }

                                iGridNumber++;
                            }
                            oPreviousGrid.DataSource = dtNewTable;
                            oPreviousGrid.DataBind();

                            //** HIDE COLUMN RELATION **//
                            (oPreviousGrid.MasterTableView.GetColumn(dtTable.Columns[dtTable.Columns.Count - 1].ColumnName) as GridColumn).Visible = false;

                            // Adding CSS for Column Number
                            (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).ItemStyle.CssClass = "NumberColomn";
                            (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).HeaderStyle.Width = new Unit(30, UnitType.Pixel);

                            // Setting width and font-bold for id column
                            for (int i = 0; i < dtNewTable.Columns.Count; i++)
                            {
                                if ((oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Substring((oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Length - 2, 2).ToLower() == "id")
                                {
                                    (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).ItemStyle.Font.Bold = true;
                                    (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderStyle.Width = 100;
                                }
                            }

                            oPreviousGrid.MasterTableView.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                            oPreviousGrid.MasterTableView.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                            oPreviousGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                            if (oUserLog.PreviousDetail.Contains("<SysParam"))
                            {
                                oPreviousGrid.ClientSettings.Scrolling.AllowScroll = true;
                                oPreviousGrid.ClientSettings.Scrolling.UseStaticHeaders = true;
                                oPreviousGrid.ClientSettings.Scrolling.SaveScrollPosition = true;
                                oPreviousGrid.ClientSettings.ClientEvents.OnGridCreated = "GridCreated";
                            }
                            oPreviousGrid.SkinID = "AuditTrail";
                            oPreviousGrid.MasterTableView.Rebind();

                            litLastGrid.Controls.Add(oPreviousGrid);
                        }
                        //** PARENT TABLE **//
                        else
                        {
                            if (dtTable.Rows.Count > 1)
                            {
                                oPreviousGrid = new RadGrid();
                                DataTable dtNewTable = new DataTable();
                                int iGridNumber = 1;

                                dtNewTable.Columns.Add("No");
                                foreach (DataColumn dc in dtTable.Columns)
                                {
                                    //loop for header grid

                                    dtNewTable.Columns.Add(dc.ColumnName);
                                }

                                foreach (DataRow dr in dtTable.Rows)
                                {
                                    DataRow drNewRow = dtNewTable.Rows.Add();
                                    drNewRow[0] = iGridNumber;
                                    int iCountRow = 1;
                                    foreach (DataColumn dc in dtTable.Columns)
                                    {
                                        //loop for data grid
                                        drNewRow[iCountRow] = dr[iCountRow - 1];
                                        if (oUserLog.PreviousDetail.Contains("<SysParam") && iCountRow == 1)
                                        {
                                            drNewRow[iCountRow] = drNewRow[iCountRow].ToString().Replace("_", " ");
                                        }
                                        iCountRow++;
                                    }

                                    iGridNumber++;
                                }
                                oPreviousGrid.DataSource = dtNewTable;
                                oPreviousGrid.DataBind();

                                //** HIDE COLUMN RELATION **//
                                if (dtTable.ChildRelations.Count > 0)
                                    (oPreviousGrid.MasterTableView.GetColumn(dtTable.Columns[1].ColumnName) as GridColumn).Visible = false;

                                // Adding CSS for Column Number
                                (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).ItemStyle.CssClass = "NumberColomn";
                                (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).HeaderStyle.Width = new Unit(30, UnitType.Pixel);

                                // Setting width and font-bold for id column
                                for (int i = 0; i < dtNewTable.Columns.Count; i++)
                                {
                                    if ((oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Substring((oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Length - 2, 2).ToLower() == "id")
                                    {
                                        (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).ItemStyle.Font.Bold = true;
                                        (oPreviousGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderStyle.Width = 100;
                                    }
                                }

                                oPreviousGrid.MasterTableView.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                                oPreviousGrid.MasterTableView.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                                oPreviousGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                                if (oUserLog.PreviousDetail.Contains("<SysParam"))
                                {
                                    oPreviousGrid.ClientSettings.Scrolling.AllowScroll = true;
                                    oPreviousGrid.ClientSettings.Scrolling.UseStaticHeaders = true;
                                    oPreviousGrid.ClientSettings.Scrolling.SaveScrollPosition = true;
                                    oPreviousGrid.ClientSettings.ClientEvents.OnGridCreated = "GridCreated";
                                }
                                oPreviousGrid.SkinID = "AuditTrail";
                                oPreviousGrid.MasterTableView.Rebind();

                                litLastGrid.Controls.Add(oPreviousGrid);
                            }
                            else
                            {
                                oLastTable.Controls.Add(AddPreviousHeader(dtTable.TableName));

                                foreach (DataColumn oCol in dtTable.Columns)
                                {
                                    if (oCol.ColumnName.Contains("_"))
                                        continue;
                                    else
                                    {
                                        oLastTable.Controls.Add(AddPreviousRow(Regex.Replace(oCol.ColumnName, "([^^])([A-Z])", "$1 $2"), dtTable.Rows[0][oCol].ToString(), "", iColumnNumber));
                                        iColumnNumber++;
                                    }
                                }

                                phLastSysParameter.Controls.Add(oLastTable);
                            }

                            Literal oLitEmptyControl = new Literal();
                            oLitEmptyControl.Text = "<br/>";

                            phLastSysParameter.Controls.Add(oLitEmptyControl);

                        }
                    }
                }
                else
                {
                    tdAuditLogData.Visible = tdGridData.Visible = false;
                }
                #endregion

                iColumnNumber = 1;

                #region Detail
                foreach (DataTable dtTable in dsTest.Tables)
                {
                    string sTable = dtTable.TableName;
                    int iRows = dtTable.Rows.Count;
                    #region Count Column
                    for (int i = 0; i < dtTable.Columns.Count; i++)
                    {
                        //if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower().Contains("code") && !oUserLog.Detail.Contains("<SysParam"))
                        //{
                        //    dtTable.Columns.RemoveAt(i);
                        //    i--;
                        //}

                        if (oUserLog.Detail.Contains("<User") && !dtTable.Columns[i].ColumnName.Contains("_"))
                        {
                            if (dtTable.TableName == "UserGroup")
                            {
                                if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "groupid" && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "groupname")
                                {
                                    dtTable.Columns.RemoveAt(i);
                                    i--;
                                }
                            }
                            if (dtTable.TableName == "UserDetail")
                            {
                                if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "branchcode")
                                {
                                    dtTable.Columns.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        #region ExceptionForm
                        if (oUserLog.Detail.Contains("<ExceptionForms") && !dtTable.Columns[i].ColumnName.Contains("_"))
                        {
                            if (dtTable.TableName == "ExceptionForm")
                            {
                                if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "productratingscore"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "branchname"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "cif"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "customerfullname"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "assetclassname"
                                    )
                                {
                                    dtTable.Columns.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        #endregion
                        #region Product
                        if (oUserLog.Detail.Contains("<Product") && !dtTable.Columns[i].ColumnName.Contains("_"))
                        {
                            if (dtTable.TableName == "Product")
                            {
                                if (dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "productname"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "productcode"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "ithfrom"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "ithto"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "isactive"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "createdate"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "updatedate"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "fundhouse"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "productratingscore"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "psccustomerobjective1name"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "currencycode"
                                    && dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() != "updatebyuserid"
                                    )
                                {
                                    dtTable.Columns.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                        #endregion
                        else if (oUserLog.Detail.Contains("<SysParam") && !(dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() == "code" || dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() == "value" || dtTable.Columns[i].ColumnName.ToString().Trim().ToLower() == "description"))
                        {
                            dtTable.Columns.RemoveAt(i);
                            i--;
                        }
                    }
                    #endregion

                    //** TABLE RELATIONS **//
                    if (dtTable.ParentRelations.Count > 0 && dtTable.ChildRelations.Count > 0)
                    {
                        continue;
                    }
                    //** CHILD TABLES **//
                    else if (dtTable.ParentRelations.Count > 0)
                    {
                        #region Child Tables
                        DataTable dtNewTable = new DataTable();
                        int iGridNumber = 1;

                        dtNewTable.Columns.Add("No");
                        foreach (DataColumn dc in dtTable.Columns)
                        {
                            //loop for header grid
                            dtNewTable.Columns.Add(dc.ColumnName);
                        }

                        foreach (DataRow dr in dtTable.Rows)
                        {
                            DataRow drNewRow = dtNewTable.Rows.Add();
                            drNewRow[0] = iGridNumber;
                            int iCountRow = 1;
                            foreach (DataColumn dc in dtTable.Columns)
                            {
                                //loop for data grid
                                drNewRow[iCountRow] = dr[iCountRow - 1];
                                if (oUserLog.Detail.Contains("<SysParam") && iCountRow == 1)
                                {
                                    drNewRow[iCountRow] = drNewRow[iCountRow].ToString().Replace("_", " ");
                                }
                                iCountRow++;
                            }

                            iGridNumber++;
                        }
                        oGrid = new RadGrid();
                        oGrid.ID = "rgid" + dtTable.TableName;
                        oGrid.DataSource = dtNewTable;
                        oGrid.DataBind();

                        //** HIDE COLUMN RELATION **//
                        (oGrid.MasterTableView.GetColumn(dtTable.Columns[dtTable.Columns.Count - 1].ColumnName) as GridColumn).Visible = false;

                        // Adding CSS for Column Number
                        (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).ItemStyle.CssClass = "NumberColomn";
                        (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).HeaderStyle.Width = new Unit(30, UnitType.Pixel);

                        // Setting width and font-bold for id column
                        for (int i = 0; i < dtNewTable.Columns.Count; i++)
                        {
                            if ((oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Substring((oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Length - 2, 2).ToLower() == "id")
                            {
                                (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).ItemStyle.Font.Bold = true;
                                (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderStyle.Width = 100;
                            }
                        }

                        oGrid.MasterTableView.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                        oGrid.MasterTableView.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                        oGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                        if (oUserLog.Detail.Contains("<SysParam"))
                        {
                            oGrid.ClientSettings.Scrolling.AllowScroll = true;
                            oGrid.ClientSettings.Scrolling.UseStaticHeaders = true;
                            oGrid.ClientSettings.Scrolling.SaveScrollPosition = true;
                            oGrid.ClientSettings.ClientEvents.OnGridCreated = "GridCreated";
                        }
                        oGrid.SkinID = "RadGridWithoutPaging";
                        oGrid.MasterTableView.Rebind();

                        litGrid.Controls.Add(oGrid);
                        string sValue = litGrid.ToString();
                        //phSysParameter.Controls.Add(oGrid); 
                        #endregion
                    }
                    //** PARENT TABLE **//
                    else
                    {
                        #region Parent Table
                        if (dtTable.Rows.Count > 1)
                        {
                            //RadGrid oGrid = new RadGrid();
                            //oGrid.DataSource = dtTable;
                            //oGrid.DataBind();

                            oGrid = new RadGrid();
                            DataTable dtNewTable = new DataTable();
                            int iGridNumber = 1;

                            dtNewTable.Columns.Add("No");
                            foreach (DataColumn dc in dtTable.Columns)
                            {
                                //loop for header grid

                                dtNewTable.Columns.Add(dc.ColumnName);
                            }

                            foreach (DataRow dr in dtTable.Rows)
                            {
                                DataRow drNewRow = dtNewTable.Rows.Add();
                                drNewRow[0] = iGridNumber;
                                int iCountRow = 1;
                                foreach (DataColumn dc in dtTable.Columns)
                                {
                                    //loop for data grid
                                    drNewRow[iCountRow] = dr[iCountRow - 1];
                                    if (oUserLog.Detail.Contains("<SysParam") && iCountRow == 1)
                                    {
                                        drNewRow[iCountRow] = drNewRow[iCountRow].ToString().Replace("_", " ");
                                    }
                                    iCountRow++;
                                }

                                iGridNumber++;
                            }
                            oGrid.DataSource = dtNewTable;
                            oGrid.DataBind();

                            //** HIDE COLUMN RELATION **//
                            if (dtTable.ChildRelations.Count > 0)
                                (oGrid.MasterTableView.GetColumn(dtTable.Columns[1].ColumnName) as GridColumn).Visible = false;

                            // Adding CSS for Column Number
                            (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).ItemStyle.CssClass = "NumberColomn";
                            (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[0].ColumnName) as GridColumn).HeaderStyle.Width = new Unit(30, UnitType.Pixel);

                            // Setting width and font-bold for id column
                            for (int i = 0; i < dtNewTable.Columns.Count; i++)
                            {
                                if ((oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Substring((oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderText.Length - 2, 2).ToLower() == "id")
                                {
                                    (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).ItemStyle.Font.Bold = true;
                                    (oGrid.MasterTableView.GetColumn(dtNewTable.Columns[i].ColumnName) as GridColumn).HeaderStyle.Width = 100;
                                }
                            }

                            oGrid.MasterTableView.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                            oGrid.MasterTableView.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                            oGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                            if (oUserLog.Detail.Contains("<SysParam"))
                            {
                                oGrid.ClientSettings.Scrolling.AllowScroll = true;
                                oGrid.ClientSettings.Scrolling.UseStaticHeaders = true;
                                oGrid.ClientSettings.Scrolling.SaveScrollPosition = true;
                                oGrid.ClientSettings.ClientEvents.OnGridCreated = "GridCreated";
                            }
                            oGrid.SkinID = "RadGridWithoutPaging";
                            oGrid.MasterTableView.Rebind();

                            litGrid.Controls.Add(oGrid);
                            //phSysParameter.Controls.Add(oGrid);
                        }
                        else
                        {
                            oTable.Controls.Add(AddHeader(dtTable.TableName));

                            foreach (DataColumn oCol in dtTable.Columns)
                            {
                                if (oCol.ColumnName.Contains("_"))
                                    continue;
                                else
                                {
                                    string sValue = string.Empty;
                                    if (oCol.ColumnName.ToString().Contains("Date"))
                                    {
                                        sValue = Convert.ToDateTime(dtTable.Rows[0][oCol]).ToString("dd-MM-yyyy HH:mm:ss.fff tt");
                                    }
                                    else
                                        sValue = dtTable.Rows[0][oCol].ToString();
                                    //string sCol = oCol.ColumnName.ToString();
                                    //string sNewStr = dtTable.Rows[0][oCol].ToString();
                                    oTable.Controls.Add(AddRow(Regex.Replace(oCol.ColumnName, "([^^])([A-Z])", "$1 $2"), sValue, "", iColumnNumber));
                                    iColumnNumber++;
                                }
                            }

                            phSysParameter.Controls.Add(oTable);
                        }

                        Literal oLitEmptyControl = new Literal();
                        oLitEmptyControl.Text = "<br/>";
                        //TextBox oEmptyControl = new TextBox();
                        //oEmptyControl.BorderStyle = BorderStyle.None;
                        //oEmptyControl.Enabled = false;
                        //oEmptyControl.Visible = false;

                        phSysParameter.Controls.Add(oLitEmptyControl);
                        #endregion
                    }
                }
                #endregion

                #region Compare and Highlight
                bool bBreak = false;
                foreach (HtmlTableRow oNewRow in oTable.Rows)
                {
                    bBreak = false;
                    foreach (HtmlTableRow oLastRow in oLastTable.Rows)
                    {
                        if (bBreak)
                        {
                            break;
                        }
                        if (oNewRow.Cells.Count > 1)
                        {
                            if (oLastRow.Cells.Count > 1)
                            {
                                foreach (Label lblNewValue in oNewRow.Cells[1].Controls)
                                {
                                    foreach (Label lblLastValue in oLastRow.Cells[1].Controls)
                                    {
                                        if (lblNewValue.ID == lblLastValue.ID)
                                        {
                                            if (lblNewValue.Text != lblLastValue.Text)
                                            {
                                                lblNewValue.BackColor = lblLastValue.BackColor = Color.Yellow;
                                            }
                                            bBreak = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                #endregion

                #region Compare and Highlight between grid
                foreach (GridDataItem oOldItem in oPreviousGrid.MasterTableView.Items)
                {
                    foreach (GridDataItem oNewItem in oGrid.MasterTableView.Items)
                    {
                        if (oUserLog.Detail.Contains("<SysParam"))
                        {
                            if (oOldItem.Cells[3].Text == oNewItem.Cells[3].Text && oOldItem.Cells[5].Text != oNewItem.Cells[5].Text)
                            {
                                oOldItem.BackColor = Color.Yellow;
                                break;
                            }
                            else
                            {
                                oOldItem.BackColor = Color.Empty;
                            }
                        }
                        else
                        {
                            if (oOldItem.Cells[3].Text != oNewItem.Cells[3].Text)
                            {
                                oOldItem.BackColor = Color.Yellow;
                            }
                            else
                            {
                                oOldItem.BackColor = Color.Empty;
                                break;
                            }
                        }
                    }
                }

                int iCount = 0;
                foreach (GridDataItem oNewItem in oGrid.MasterTableView.Items)
                {
                    iCount++;
                    if (iCount == 103)
                    {

                    }
                    foreach (GridDataItem oOldItem in oPreviousGrid.MasterTableView.Items)
                    {
                        if (oUserLog.Detail.Contains("<SysParam"))
                        {
                            if (oNewItem.Cells[3].Text == oOldItem.Cells[3].Text && oNewItem.Cells[5].Text != oOldItem.Cells[5].Text)
                            {
                                oNewItem.BackColor = Color.Yellow;
                                break;
                            }
                            else
                            {
                                oNewItem.BackColor = Color.Empty;
                            }
                        }
                        else
                        {
                            if (oNewItem.Cells[3].Text != oOldItem.Cells[3].Text)
                            {
                                oNewItem.BackColor = Color.Yellow;
                            }
                            else
                            {
                                oNewItem.BackColor = Color.Empty;
                                break;
                            }
                        }
                    }
                }
                #endregion
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            AlertMessageBox(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    private HtmlTableRow AddPreviousHeader(string sHeaderName)
    {
        try
        {
            HtmlTableRow oHtmlTableRow = new HtmlTableRow();
            HtmlTableCell htcEmpty = new HtmlTableCell();
            HtmlTableCell htcValue = new HtmlTableCell();
            HtmlTableCell htcDescr = new HtmlTableCell();

            lblLastHeaderCode.Text = sHeaderName;

            Label lblValue = new Label();
            lblValue.ID = "tbHeaderValue";
            lblValue.Text = "";
            lblValue.CssClass = "Label";

            Label lblDescr = new Label();
            lblDescr.ID = "lblHeaderDescr";
            lblDescr.Text = "";
            lblDescr.CssClass = "Label";

            htcValue.Controls.Add(lblValue);
            htcDescr.Controls.Add(lblDescr);

            oHtmlTableRow.Controls.Add(htcEmpty);
            oHtmlTableRow.Controls.Add(htcValue);
            oHtmlTableRow.Controls.Add(htcDescr);

            return oHtmlTableRow;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    private HtmlTableRow AddPreviousRow(string sCode, string sValue, string sDescr, int columnNumber)
    {
        try
        {
            HtmlTableRow oHtmlTableRow = new HtmlTableRow();
            HtmlTableCell htcCode = new HtmlTableCell();
            htcCode.Style[HtmlTextWriterStyle.PaddingRight] = "10px";
            htcCode.Style[HtmlTextWriterStyle.Width] = "150px";

            HtmlTableCell htcValue = new HtmlTableCell();
            HtmlTableCell htcDescr = new HtmlTableCell();

            htcCode.Attributes.Add("Class", "frame_lv2-leftcolumn");
            htcValue.Attributes.Add("Class", "frame_lv2-rightcolumn");

            Label lblCode = new Label();
            lblCode.ID = "lblCode" + sCode;
            lblCode.Text = sCode;
            lblCode.CssClass = "Label";

            Label tbValue = new Label();
            tbValue.ID = "tbValue" + sCode;
            tbValue.Text = sValue;
            tbValue.Width = new Unit(350, UnitType.Pixel);
            tbValue.CssClass = "TextBox";

            if (sCode.ToLower() == "email")
            {
                //fill color for email
                tbValue.ForeColor = System.Drawing.Color.Blue;
            }
            if (sCode.Substring(sCode.Length - 2, 2).ToLower() == "id")
            {
                // Setting font-bold for id column
                tbValue.Font.Bold = true;
            }

            Label lblDescr = new Label();
            lblDescr.ID = "lblDescr" + sCode;
            lblDescr.Text = sDescr;
            lblDescr.CssClass = "Label";

            if (!sCode.ToLower().Trim().Contains("password"))
            {
                htcCode.Controls.Add(lblCode);
                htcValue.Controls.Add(tbValue);
                htcDescr.Controls.Add(lblDescr);

                oHtmlTableRow.Controls.Add(htcCode);
                oHtmlTableRow.Controls.Add(htcValue);
                oHtmlTableRow.Controls.Add(htcDescr);
            }

            return oHtmlTableRow;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    private HtmlTableRow AddHeader(string sHeaderName)
    {
        try
        {
            HtmlTableRow oHtmlTableRow = new HtmlTableRow();
            HtmlTableCell htcEmpty = new HtmlTableCell();
            HtmlTableCell htcValue = new HtmlTableCell();
            HtmlTableCell htcDescr = new HtmlTableCell();

            if (tdAuditLogData.Visible)
                lblHeaderCode.Text = "New " + sHeaderName;
            else
                lblHeaderCode.Text = sHeaderName;

            Label lblValue = new Label();
            lblValue.ID = "tbHeaderValue";
            lblValue.Text = "";
            lblValue.CssClass = "Label";

            Label lblDescr = new Label();
            lblDescr.ID = "lblHeaderDescr";
            lblDescr.Text = "";
            lblDescr.CssClass = "Label";

            htcValue.Controls.Add(lblValue);
            htcDescr.Controls.Add(lblDescr);

            oHtmlTableRow.Controls.Add(htcEmpty);
            oHtmlTableRow.Controls.Add(htcValue);
            oHtmlTableRow.Controls.Add(htcDescr);

            return oHtmlTableRow;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    private HtmlTableRow AddRow(string sCode, string sValue, string sDescr, int columnNumber)
    {
        try
        {
            HtmlTableRow oHtmlTableRow = new HtmlTableRow();
            HtmlTableCell htcColon = new HtmlTableCell();
            //HtmlTableCell htcNo = new HtmlTableCell();
            HtmlTableCell htcCode = new HtmlTableCell();
            htcCode.Style[HtmlTextWriterStyle.PaddingRight] = "0px";
            htcCode.Style[HtmlTextWriterStyle.Width] = "150px";

            HtmlTableCell htcValue = new HtmlTableCell();
            HtmlTableCell htcDescr = new HtmlTableCell();

            Label lblColon = new Label();
            lblColon.Text = ":";

            htcCode.Attributes.Add("Class", "frame_lv2-leftcolumn");
            htcValue.Attributes.Add("Class", "frame_lv2-rightcolumn");
            //Label lblNo = new Label();
            //lblNo.ID = "tbValue" + sCode;
            //lblNo.Text = columnNumber.ToString() + ".";
            //lblNo.Width = new Unit(50, UnitType.Pixel);
            //lblNo.CssClass = "Label";

            Label lblCode = new Label();
            lblCode.ID = "lblCode" + sCode;
            lblCode.Text = sCode;
            lblCode.CssClass = "Label";



            Label tbValue = new Label();
            tbValue.ID = "tbValue" + sCode;
            tbValue.Text = sValue;
            tbValue.Width = new Unit(350, UnitType.Pixel);
            tbValue.CssClass = "TextBox";

            if (sCode.ToLower() == "email")
            {
                //fill color for email
                tbValue.ForeColor = System.Drawing.Color.Blue;
            }
            if (sCode.Substring(sCode.Length - 2, 2).ToLower() == "id")
            {
                // Setting font-bold for id column
                tbValue.Font.Bold = true;
            }

            Label lblDescr = new Label();
            lblDescr.ID = "lblDescr" + sCode;
            lblDescr.Text = sDescr;
            lblDescr.CssClass = "Label";

            if (!sCode.ToLower().Trim().Contains("password"))
            {
                //htcNo.Controls.Add(lblNo);
                htcCode.Controls.Add(lblCode);
                htcColon.Controls.Add(lblColon);
                htcValue.Controls.Add(tbValue);
                htcDescr.Controls.Add(lblDescr);

                //oHtmlTableRow.Controls.Add(htcNo);
                oHtmlTableRow.Controls.Add(htcCode);
                oHtmlTableRow.Controls.Add(htcColon);
                oHtmlTableRow.Controls.Add(htcValue);
                oHtmlTableRow.Controls.Add(htcDescr);
            }

            return oHtmlTableRow;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    
    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            //tbUserLogDetail.Text = Server.HtmlEncode(tbUserLogDetail.Text);
            BackToList();
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            AlertMessageBox(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    #endregion

    #region Method
    private void BackToList()
    {
        try
        {
            Response.Redirect("UserLogList.aspx");
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    #endregion
}
