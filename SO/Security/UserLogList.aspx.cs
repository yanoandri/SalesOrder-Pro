
using System;
using System.Reflection;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using SO.BusinessLogicLayer.Enumeration;
using Telerik.Web.UI;

namespace PFSHelper.WebUI
{
    /// <summary>
    /// Summary description for UserLogList.
    /// </summary>
    public partial class UserLogList : PFSBasePage
    {
        #region Filter Parameters

        string sKeywords;
        string m_sUserName;
        object dtLogDateFrom;
        object dtLogDateTo;
        object iModuleObjectMemberID;
        #endregion

        #region Properties

        string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
        #endregion

        #region Form Events

        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (!Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_AUD_READ.ToString())) NoPermission();

                btnPurge.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_AUD_PURGE.ToString());

                // Put user code to initialize the page here
                if (!IsPostBack)
                {
                    //*** Bind Filter UserName Combo
                    Bind_cmbUserName(cmbFilterUserName, true);

                    //*** Bind Filter MemberCode Combo
                    Bind_cmbMemberCode(cmbFilterMemberCode, true);

                    rgridUserLogList.Rebind();
                }
                else
                {
                    string eventArg = Request["__EVENTARGUMENT"];
                    if (eventArg == "search_datefrom")
                    {
                        calFilterLogDateFrom.DbSelectedDate = calFilterLogDateFrom.InvalidTextBoxValue;
                        calFilterLogDateTo.DbSelectedDate = calFilterLogDateFrom.InvalidTextBoxValue;
                        rgridUserLogList.Rebind();
                    }
                    else if (eventArg == "search_dateto")
                    {
                        calFilterLogDateFrom.DbSelectedDate = calFilterLogDateTo.InvalidTextBoxValue;
                        calFilterLogDateTo.DbSelectedDate = calFilterLogDateTo.InvalidTextBoxValue;
                        rgridUserLogList.Rebind();
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        protected void btnSearch_Click(object sender, System.EventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                rgridUserLogList.Rebind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        protected void btnReset_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("UserLogList.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        protected void btnPurge_Click(object sender, System.EventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            string sDescription = string.Empty;
            UserLogCollection oUserLogList = null;
            bool bIsSuccess = false;
            try
            {
                oUserLogList = GetUserLogList();
                bIsSuccess = oUserLogList.PurgeData();

                if (bIsSuccess)
                    sDescription = "Purge audit trail success";
                else
                    sDescription = "Purge audit trail failed";

                rgridUserLogList.Rebind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
            finally
            {
                Security.WriteUserLog(
                    sRefNumber, 
                    sDescription, 
                    oUserLogList, 
                    Convert.ToInt16(bIsSuccess), 
                    (int)SOEnumeration.PFSModuleObjectMember.SCR_AUD_PURGE);

                oUserLogList.Clear();
                oUserLogList = null;
            }
        }
        protected void btnExport_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExportToExcel();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                if (!(Ex is System.Threading.ThreadAbortException))
                {
                    ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                    Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
                }
            }
        }
        #endregion

        #region Data Grid Events

        protected void rgridUserLogList_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == Telerik.Web.UI.RadGrid.InitInsertCommandName)
                {
                    e.Canceled = true;
                    System.Collections.Specialized.ListDictionary ldNewValues = new System.Collections.Specialized.ListDictionary();
                    ldNewValues["LogDate"] = DateTime.Now;
                    e.Item.OwnerTableView.InsertItem(ldNewValues);
                }
                else if (e.CommandName == Telerik.Web.UI.RadGrid.UpdateCommandName 
                    || e.CommandName == Telerik.Web.UI.RadGrid.PerformInsertCommandName)
                {

                    //*** Obtain all controls during edit mode
                    TextBox tbEditIpAddress = (TextBox)e.Item.FindControl("tbEditIpAddress");
                    Telerik.Web.UI.RadDatePicker calEditLogDate = (Telerik.Web.UI.RadDatePicker)e.Item.FindControl("calEditLogDate");
                    TextBox tbEditDescription = (TextBox)e.Item.FindControl("tbEditDescription");
                    TextBox tbEditDetail = (TextBox)e.Item.FindControl("tbEditDetail");
                    Telerik.Web.UI.RadComboBox cmbEditUserName = (Telerik.Web.UI.RadComboBox)e.Item.FindControl("cmbEditUserName");
                    Telerik.Web.UI.RadComboBox cmbEditMemberCode = (Telerik.Web.UI.RadComboBox)e.Item.FindControl("cmbEditMemberCode");

                    UserLog oUserLog = new UserLog();


                    //*** Assign values from controls to UserLog properties
                    oUserLog.IpAddress = Convert.ToString(tbEditIpAddress.Text);
                    oUserLog.LogDate = calEditLogDate.SelectedDate.Value;
                    oUserLog.Description = Convert.ToString(tbEditDescription.Text);
                    //oUserLog.Detail = Convert.__SQL__Xml(tbEditDetail.Text);
                    oUserLog.UserName = cmbEditUserName.SelectedItem.Text;
                    oUserLog.ModuleObjectMemberID = Convert.ToInt32(cmbEditMemberCode.SelectedValue);

                    if (e.CommandName == Telerik.Web.UI.RadGrid.UpdateCommandName)
                    {
                        Telerik.Web.UI.GridEditableItem editedItem = (Telerik.Web.UI.GridEditableItem)e.Item;
                        oUserLog.UserLogID = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["UserLogID"]);
                        oUserLog.DAL_Update();
                    }
                    else if (e.CommandName == Telerik.Web.UI.RadGrid.PerformInsertCommandName)
                    {
                        oUserLog.DAL_Add();
                    }

                    //rgridCustomerList.Rebind();
                }
                else if (e.CommandName == Telerik.Web.UI.RadGrid.DeleteCommandName)
                {
                    long lID;
                    Telerik.Web.UI.GridEditableItem editedItem = (Telerik.Web.UI.GridEditableItem)e.Item;
                    lID = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["UserLogID"]);
                    UserLog oUserLog = new UserLog(lID);
                    oUserLog.IsPurge = true;

                    oUserLog.PurgeData();
                }
                else if (e.CommandName == "ViewDetail")
                {
                    long lID;
                    Telerik.Web.UI.GridEditableItem editedItem = (Telerik.Web.UI.GridEditableItem)e.Item;
                    Label lblMemberDescr = (Label)e.Item.FindControl("lblMemberDescr");
                    Label lblMemberName = (Label)e.Item.FindControl("lblMemberName");
                    lID = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["UserLogID"]);
                    if ((lblMemberDescr.Text.Trim() == "UPDATE" || lblMemberDescr.Text.Trim() == "ACCESS RIGHT") && (lblMemberName.Text.Trim() == "User" || lblMemberName.Text.Trim() == "Group" || lblMemberName.Text.Trim() == "Sys Param"))
                    {
                        Response.Redirect("UserLogDetail.aspx?UserLogID=" + lID + "&isUpdate=1");
                    }
                    else
                    {
                        Response.Redirect("UserLogDetail.aspx?UserLogID=" + lID);
                    }

                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        protected void rgridUserLogList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is Telerik.Web.UI.GridEditFormItem && e.Item.IsInEditMode)
                {
                    //*******  Calendar Field LogDate
                    Telerik.Web.UI.RadDatePicker calEditLogDate = (Telerik.Web.UI.RadDatePicker)e.Item.FindControl("calEditLogDate");

                    //*******  Combo Box UserName
                    Telerik.Web.UI.RadComboBox cmbEditUserName = (Telerik.Web.UI.RadComboBox)e.Item.FindControl("cmbEditUserName");
                    Label lblEditUserID = (Label)e.Item.FindControl("lblEditUserID");
                    Bind_cmbUserName(cmbEditUserName, false);

                    //*******  Combo Box MemberCode
                    Telerik.Web.UI.RadComboBox cmbEditMemberCode = (Telerik.Web.UI.RadComboBox)e.Item.FindControl("cmbEditMemberCode");
                    Label lblEditModuleObjectMemberID = (Label)e.Item.FindControl("lblEditModuleObjectMemberID");
                    Bind_cmbMemberCode(cmbEditMemberCode, false);

                    if (!e.Item.OwnerTableView.IsItemInserted)
                    {
                        cmbEditUserName.SelectedValue = lblEditUserID.Text;
                        cmbEditMemberCode.SelectedValue = lblEditModuleObjectMemberID.Text;
                    }
                }
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    Label lblSuccessStatus = (Label)e.Item.FindControl("lblSuccessStatus");

                    if (lblSuccessStatus.Text.ToUpper() == "YES")
                    {
                        lblSuccessStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else if (lblSuccessStatus.Text.ToUpper() == "NO")
                    {
                        lblSuccessStatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        protected void rgridUserLogList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgridUserLogList.DataSource = GetUserLogList();
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
      
        #endregion

        #region Data Binding

        protected void Bind_cmbUserName(Telerik.Web.UI.RadComboBox cmbMyCombo, bool bIsFilter)
        {
            try
            {
                UserCollection oUserLogCollection = new UserCollection();
                oUserLogCollection.DAL_Load();
                oUserLogCollection.Sort(UserCollection.UserFields.UserName, true);

                cmbMyCombo.DataSource = oUserLogCollection;
                cmbMyCombo.DataTextField = "UserName";
                cmbMyCombo.DataValueField = "UserID";
                cmbMyCombo.DataBind();
                if (bIsFilter)
                {
                    Telerik.Web.UI.RadComboBoxItem cbiAll = new Telerik.Web.UI.RadComboBoxItem("All", "0");
                    cmbMyCombo.Items.Insert(0, cbiAll);
                    cmbMyCombo.SelectedValue = "0";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected void Bind_cmbMemberCode(Telerik.Web.UI.RadComboBox cmbMyCombo, bool bIsFilter)
        {
            try
            {
                ModuleObjectMemberCollection oModuleObjectMemberCollection = new ModuleObjectMemberCollection();
                oModuleObjectMemberCollection.DAL_Load();

                System.Collections.SortedList oItemList = new System.Collections.SortedList();
                foreach (ModuleObjectMember oMember in oModuleObjectMemberCollection)
                {
                    if(oMember.MemberDescr.ToUpper().Contains("VIEW")
                        || oMember.MemberDescr.ToUpper().Contains("READ"))
                    continue;

                    oItemList.Add(
                        string.Format("{0} - {1}",oMember.ObjectName, oMember.MemberDescr),
                        oMember.ModuleObjectMemberID.ToString());
                }

                cmbMyCombo.DataSource = oItemList;
                cmbMyCombo.DataTextField = "Key";
                cmbMyCombo.DataValueField = "Value";
                cmbMyCombo.DataBind();
                
                if (bIsFilter)
                {
                    Telerik.Web.UI.RadComboBoxItem cbiAll = new Telerik.Web.UI.RadComboBoxItem("All", "0");
                    cmbMyCombo.Items.Insert(0, cbiAll);
                    cmbMyCombo.SelectedValue = "0";
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion

        #region Data Access

        protected UserLogCollection GetUserLogList()
        {
            sKeywords = tbFilterKeywords.Text.Trim();
            if (string.IsNullOrWhiteSpace(sKeywords))
            {
                sKeywords = null;
            }

            //** LogDate Filter Controls
            //cek jika salah satu tanggal ada yg sudah diisi
            if (calFilterLogDateFrom.IsEmpty && !calFilterLogDateTo.IsEmpty)
            {
                calFilterLogDateFrom.DbSelectedDate = calFilterLogDateTo.SelectedDate.Value;
            }
            if (calFilterLogDateTo.IsEmpty && !calFilterLogDateFrom.IsEmpty)
            {
                calFilterLogDateTo.DbSelectedDate = calFilterLogDateFrom.SelectedDate;
            }
            /****/
            if (calFilterLogDateFrom.IsEmpty)
            {
                dtLogDateFrom = null;
            }
            else
            {
                dtLogDateFrom = calFilterLogDateFrom.SelectedDate;
            }
            if (calFilterLogDateTo.IsEmpty)
            {
                dtLogDateTo = null;
            }
            else
            {
                dtLogDateTo = calFilterLogDateTo.SelectedDate;
            }
            //** UserName Filter Controls
            if (cmbFilterUserName.SelectedValue == "0")
            {
                m_sUserName = null;
            }
            else
            {
                m_sUserName = cmbFilterUserName.SelectedItem.Text;
            }
            //** MemberCode Filter Controls
            if (cmbFilterMemberCode.SelectedValue == "0")
            {
                iModuleObjectMemberID = null;
            }
            else
            {
                iModuleObjectMemberID = Convert.ToInt32(cmbFilterMemberCode.SelectedValue);
            }

            UserLogCollection oUserLogList = new UserLogCollection();
            oUserLogList.DAL_LoadWithModuleName(
                sKeywords,
                m_sUserName,
                dtLogDateFrom,
                dtLogDateTo,
                iModuleObjectMemberID
                );

            return oUserLogList;
        }
        private void BindRpt()
        {
            rptList.DataSource = GetUserLogList();
            rptList.DataBind();
        }
        private void ExportToExcel()
        {
            BindRpt();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=AuditTrail.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            litCss.RenderControl(oHtmlTextWriter);
            rptList.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }
        #endregion
    }
}
