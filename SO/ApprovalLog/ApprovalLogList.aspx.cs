
using System;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using SO.BusinessLogicLayer;
using SO.BusinessLogicLayer.Enumeration;
using Telerik.Web.UI;

/// <summary>
/// Summary description for ApprovalLogList.
/// </summary>
/// 
public partial class SE_WebUI_ApprovalLogList : PFSBasePage
{
    #region Filter Parameters

    string sKeywords;
    object iModuleObjectID;
    object iModuleObjectMemberID;
    object iApprovalStatusID;
    #endregion

    #region Properties 

    string RefNumber = PFSCommon.GenerateRefNumber();
    int? qs_iApprovalStatusID
    {
        get { return Convert.ToInt32(Request.QueryString["ApprovalStatusID"]); }
    }
    #endregion

    #region Form Events 

    protected void Page_Load(object sender, System.EventArgs e)
    {
        try
        {
            // Put user code to initialize the page here
            if (!IsPostBack)
            {
                if (!Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.APP_LOG_READ.ToString()))
                    NoPermission();
                btnExportToExcel.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.APP_LOG_EXPORT_EXCEL.ToString());
                //*** Bind Filter MemberCode Combo
                Bind_cmbMemberCode(cmbFilterObjectCode, true);
                Bind_cmbFilterObjectCode(cmbFilterObjectMember);
                //*** Bind Filter ApprovalStatusCode Combo
                Bind_cmbApprovalStatusCode(cmbFilterApprovalStatusCode, true);

                if (qs_iApprovalStatusID != null)
                    cmbFilterApprovalStatusCode.SelectedValue = qs_iApprovalStatusID.ToString();

                rgridApprovalLogList.Rebind();
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        try
        {
            rgridApprovalLogList.Rebind();
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ApprovalLogList.aspx");
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        try
        {
            ApprovalLogCollection oApprovalLogList = new ApprovalLogCollection();
            rgridApprovalLogList.DataSource = GetApprovalLogList();
            rgridApprovalLogList.DataBind();
            oApprovalLogList = rgridApprovalLogList.DataSource as ApprovalLogCollection;

            if (oApprovalLogList.Count > 0)
            {
                string[] sArrAprovalID = new string[oApprovalLogList.Count];
                foreach (ApprovalLog oApprovalLog in oApprovalLogList)
                {
                    sArrAprovalID[oApprovalLogList.IndexOf(oApprovalLog)] = oApprovalLog.ApprovalLogID.ToString();
                    if (oApprovalLogList.IndexOf(oApprovalLog) > 0)
                    {
                        if (oApprovalLog.ModuleObjectID != oApprovalLogList[oApprovalLogList.IndexOf(oApprovalLog) - 1].ModuleObjectID
                            || oApprovalLog.ModuleObjectMemberID != oApprovalLogList[oApprovalLogList.IndexOf(oApprovalLog) - 1].ModuleObjectMemberID)
                        {
                            Alert("You can't approve multiple request with different data,\r\n please filter this list with more specific data");
                            return;
                        }
                        else if (oApprovalLog.ApprovalStatusID != (int)SOEnumeration.ApprovalStatus.PENDING)
                        {
                            Alert("Please select data with status 'PENDING' only");
                            return;
                        }
                    }
                }

                MultiApprovalProcess(oApprovalLogList);
            }
            else
            {
                Alert("No Approval request selected");
                return;
            }
            //Response.Redirect("~/ApprovalLog/ApprovalLogMultiple.aspx?ids=" + string.Join("~", sArrAprovalID));
        }
        catch (Exception ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {

    }
    protected void OnExportToExcel(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void cmbFilterObjectMember_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        lblRequestType.Visible = cmbFilterObjectMember.Visible = (cmbFilterObjectCode.SelectedIndex > 0);
        Bind_cmbFilterObjectCode(cmbFilterObjectMember);
    }
    #endregion

    #region Data Grid Events 

    protected void rgridApprovalLogList_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "ChangePageSize")
            {
                Label lblApprovalLogID = (Label)e.Item.FindControl("lblApprovalLogID");
                Label lblModuleObjectID = (Label)e.Item.FindControl("lblModuleObjectID");
                Label lblModuleObjectMemberID = (Label)e.Item.FindControl("lblModuleObjectMemberID");
                LinkButton lblActionText = (LinkButton)e.Item.FindControl("btnApprovalAction");

                if (e.CommandName == "Approval")
                {
                    if (lblActionText.Text == "APPROVAL")
                        SingleApprovalProcess(
                            Convert.ToInt32(lblModuleObjectID.Text), 
                            Convert.ToInt32(lblApprovalLogID.Text), 
                            Convert.ToInt32(lblModuleObjectMemberID.Text));
                }
                else if (e.CommandName == "VIEW DETAIL")
                {
                    ViewDetail(
                        Convert.ToInt32(lblModuleObjectID.Text), 
                        Convert.ToInt32(lblApprovalLogID.Text), 
                        Convert.ToInt32(lblModuleObjectMemberID.Text));
                }

                rgridApprovalLogList.Rebind();
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    protected void rgridApprovalLogList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Label lblApprovalStatusName = (Label)e.Item.FindControl("lblApprovalStatusName");
                Label lblDetail = (Label)e.Item.FindControl("lblDetail");
                lblDetail.Text = Server.HtmlEncode(lblDetail.Text);

                if (lblApprovalStatusName.Text.ToUpper() == "APPROVED")
                {
                    lblApprovalStatusName.ForeColor = System.Drawing.Color.Green;
                }
                else if (lblApprovalStatusName.Text.ToUpper() == "PENDING")
                {
                    lblApprovalStatusName.ForeColor = System.Drawing.Color.Blue;
                }
                else if (lblApprovalStatusName.Text.ToUpper() == "REJECTED"
                        || lblApprovalStatusName.Text.ToUpper() == "CANCELLED")
                {
                    lblApprovalStatusName.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    protected void rgridApprovalLogList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            rgridApprovalLogList.DataSource = GetApprovalLogList();
        }
        catch (Exception ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    #endregion

    #region Data Binding 

    protected void Bind_cmbMemberCode(Telerik.Web.UI.RadComboBox cmbMyCombo, bool bIsFilter)
    {
        try
        {
            ModuleObjectCollection oModuleObjectCollection = new ModuleObjectCollection();
            oModuleObjectCollection.DAL_LoadForApprovalLogBinding();
            oModuleObjectCollection.Sort(ModuleObjectCollection.ModuleObjectFields.ObjectName, true);
            cmbMyCombo.DataSource = oModuleObjectCollection;
            cmbMyCombo.DataTextField = "ObjectName";
            cmbMyCombo.DataValueField = "ModuleObjectID";
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
    protected void Bind_cmbApprovalStatusCode(Telerik.Web.UI.RadComboBox cmbMyCombo, bool bIsFilter)
    {
        try
        {
            ApprovalStatusCollection oApprovalStatusCollection = new ApprovalStatusCollection();
            oApprovalStatusCollection.DAL_Load();

            cmbMyCombo.DataSource = oApprovalStatusCollection;
            cmbMyCombo.DataTextField = "ApprovalStatusName";
            cmbMyCombo.DataValueField = "ApprovalStatusID";
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
    protected void Bind_cmbFilterObjectCode(Telerik.Web.UI.RadComboBox cmbMyCombo)
    {
        try
        {
            cmbFilterObjectMember.Items.Clear();

            if (cmbFilterObjectCode.SelectedIndex > 0)
            {
                ModuleObjectMemberCollection oModuleObjectMemberList = new ModuleObjectMemberCollection();
                oModuleObjectMemberList.DAL_LoadForApprovalLogBinding(Convert.ToInt32(cmbFilterObjectCode.SelectedValue));
                oModuleObjectMemberList.Sort(ModuleObjectMemberCollection.ModuleObjectMemberFields.MemberName, true);
                cmbMyCombo.DataSource = oModuleObjectMemberList;
                cmbMyCombo.DataTextField = "MemberName";
                cmbMyCombo.DataValueField = "ModuleObjectMemberID";
                cmbMyCombo.DataBind();
            }

            Telerik.Web.UI.RadComboBoxItem cbiAll = new Telerik.Web.UI.RadComboBoxItem("All", "0");
            cmbMyCombo.Items.Insert(0, cbiAll);
            cmbMyCombo.SelectedValue = "0";
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    #endregion

    #region Data Access 

    protected ApprovalLogCollection GetApprovalLogList()
    {
        try
        {
            sKeywords = tbFilterKeywords.Text.Trim();
            if (string.IsNullOrWhiteSpace(sKeywords))
            {
                sKeywords = null;
            }

            //** MemberCode Filter Controls
            if (cmbFilterObjectCode.SelectedValue == "0")
            {
                iModuleObjectID = null;
            }
            else
            {
                iModuleObjectID = Convert.ToInt32(cmbFilterObjectCode.SelectedValue);
            }
            //** MemberCode Filter Controls
            if (cmbFilterObjectMember.SelectedValue == "0")
            {
                iModuleObjectMemberID = null;
            }
            else
            {
                iModuleObjectMemberID = Convert.ToInt32(cmbFilterObjectMember.SelectedValue);
            }
            //** ApprovalStatusCode Filter Controls
            if (cmbFilterApprovalStatusCode.SelectedValue == "0")
            {
                iApprovalStatusID = null;
            }
            else
            {
                iApprovalStatusID = Convert.ToInt32(cmbFilterApprovalStatusCode.SelectedValue);
            }

            ApprovalLogCollection oApprovalLogList = new ApprovalLogCollection();
            oApprovalLogList.DAL_LoadWithCreateByName(
                        sKeywords,
                        null,
                        iModuleObjectID,
                        iModuleObjectMemberID,
                        iApprovalStatusID,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        ((CustomPrincipal)HttpContext.Current.User).User.UserID
                    );

            //btnApprove.Visible = CheckIsGridForCustomerModuleOnly(oApprovalLogList);

            return oApprovalLogList;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    #endregion

    #region Methods 

    private bool SingleApprovalProcess(int iModuleObjectID, int ApprovalLogID, int? oGroupObjectMember = null)
    {
        try
        {
            switch (iModuleObjectID)
            {
                case (int)SOEnumeration.PFSModuleObject.User:
                    Response.Redirect("~/Security/UserInput.aspx?ID=" + ApprovalLogID);
                    break;
                case (int)SOEnumeration.PFSModuleObject.Group:
                    if (oGroupObjectMember == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS)
                        Response.Redirect("~/Security/AccessRight.aspx?ID=" + ApprovalLogID + "&isgroup=false");
                    else
                        Response.Redirect("~/Security/AccessRight.aspx?ID=" + ApprovalLogID + "&isgroup=true");
                    break;
                default:
                    break;
            }
            return true;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    private bool MultiApprovalProcess(ApprovalLogCollection p_oApprovalList)
    {
    //    bool bIsSuccess = true;
    //    string sDescription = "Approve Multiple Request";
    //    string sRefNumber = RefNumber;
    //    string sRemarkSummary = string.Empty;
    //    //short iStatus = 0;
    //    int iTotalApprovalNumber = p_oApprovalList.Count;
    //    int iSuccessApprovalNumber = 0;
    //    int iObjectMemberID = 0;

    //    CustomerRegistrationCollection oApprovalObject = new CustomerRegistrationCollection(); ;

    //    try
    //    {
    //        foreach (ApprovalLog oApprovalLog in p_oApprovalList)
    //        {
    //            iObjectMemberID = oApprovalLog.ModuleObjectMemberID;

    //            if (oApprovalLog.ModuleObjectID == (int)OTSCEnumeration.PFSModuleObject.CustomerRegistration)
    //            {
    //                CustomerRegistration oCustomerRegistration = new CustomerRegistration();

    //                oApprovalLog.DAL_LoadWithCreateByName();
    //                oApprovalLog.Remark = string.Empty;
    //                oCustomerRegistration = (CustomerRegistration)PFSXMLTools.DeserializeObjectUsingUnicode<CustomerRegistration>(oApprovalLog.Detail);

    //                if (oApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.CUS_REG_REG
    //                    || oApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.CUS_REREG_EDIT
    //                    || oApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.CUS_MTN_CANCELLATION
    //                    || oApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.CUS_MTN_EDIT
    //                    || oApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.CUS_MTN_FORCE_ACTIVE
    //                    || oApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.CUS_MTN_FORCE_SUSPEND)
    //                {
    //                    if (Approval.UpdateApprovalLog(oCustomerRegistration, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.OTSCEnumeration.ApprovalStatus.APPROVE, ref sRemarkSummary))
    //                        iSuccessApprovalNumber++;

    //                    oApprovalObject.Add(oCustomerRegistration);
    //                }
    //                else
    //                {
    //                    bIsSuccess = false;
    //                }
    //            }

    //            if (!bIsSuccess) break;
    //        }

    //        if (!bIsSuccess)
    //        {
    //            sDescription += " not successful CODE:" + sRefNumber;
    //            Alert(sDescription);
    //        }
    //        else
    //        {
    //            sDescription += " successfully";

    //            if (p_oApprovalList.Count == iSuccessApprovalNumber)
    //            {
    //                sDescription += " approve all data";
    //            }
    //            else
    //            {
    //                sDescription += " with details :";
    //                sDescription += string.Format("\\n- {0} total approval", p_oApprovalList.Count);
    //                sDescription += string.Format("\\n- {0} success", iSuccessApprovalNumber);
    //                sDescription += string.Format("\\n- {0} failed", p_oApprovalList.Count - iSuccessApprovalNumber);
    //            }
    //            Alert(sDescription);
    //            rgridApprovalLogList.DataSource = GetApprovalLogList();
    //            rgridApprovalLogList.DataBind();

    //        }
    //    }
    //    catch (Exception Ex)
    //    {
    //        ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
    //        Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
    //    }
    //    finally
    //    {
    //        Security.WriteUserLog(sRefNumber, sDescription, oApprovalObject, bIsSuccess ? (short)1 : (short)0, iObjectMemberID);

    //        //*** Dispose Any Object ***?//
    //        sDescription = null;
    //        //oApprovalLog = null;
    //        //oCustomerRegistration = null;
    //        //oCustomerInfo = null;
    //        //oStatementEmail = null;
    //    } 
        return true;

    }
    private bool ViewDetail(int iModuleObjectID, int ApprovalLogID, int? oGroupObjectMember = null)
    {
        try
        {
            switch (iModuleObjectID)
            {
                case (int)SOEnumeration.PFSModuleObject.User:
                    Response.Redirect("~/Security/UserInput.aspx?ID=" + ApprovalLogID + "&View=1");
                    break;
                case (int)SOEnumeration.PFSModuleObject.Group:
                    if (oGroupObjectMember == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS)
                        Response.Redirect("~/Security/AccessRight.aspx?ID=" + ApprovalLogID + "&isgroup=false&View=1");
                    else
                        Response.Redirect("~/Security/AccessRight.aspx?ID=" + ApprovalLogID + "&isgroup=true&View=1");
                    break;
                default:
                    break;
            }
            return true;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    private void ExportToExcel()
    {
        rptList.DataSource = GetApprovalLogList();
        rptList.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=ApprovalLogReport.xls");
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
