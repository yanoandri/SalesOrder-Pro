using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using PSC.BusinessLogicLayer;

public partial class Security_AccessRight : PFSBasePage
{
    #region Sessions

    private bool sessIsApprovalMode
    {
        get { return Session["IsApprovalMode"] == null ? false : Convert.ToBoolean(Session["IsApprovalMode"]); }
        set { Session["IsApprovalMode"] = value; }
    }
    #endregion

    #region Properties

    public string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
    #endregion

    #region QueryString

    private int qs_iGroupID
    {
        get { return (Request.QueryString["GroupID"] == null) ? 0 : Convert.ToInt32(Request.QueryString["GroupID"]); }
    }
    private int qs_iApprovalID
    {
        get { return (Request.QueryString["ID"] == null) ? 0 : Convert.ToInt32(Request.QueryString["ID"]); }
    }
    private bool qs_bIsGroup
    {
        get { return (Request.QueryString["isgroup"] == null) ? false : Convert.ToBoolean(Request.QueryString["isgroup"]); }
    }
    private int qs_iViewDetail
    {
        get { return Request.QueryString["View"] == null ? 0 : Convert.ToInt32(Request.QueryString["View"]); }
    }
    #endregion

    #region Page Event

    protected void Page_Load(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;

        try
        {
            SwitchToApprovalMode(qs_iApprovalID > 0);
            SetTitle();

            if (qs_iApprovalID > 0)
            {
                if ((!Security.CheckSecurity(PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_APPROVE.ToString())) &&
                    (!Security.CheckSecurity(PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_REJECT.ToString())))
                    NoPermission();

                btnApprove.Visible = Security.CheckSecurity(PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_APPROVE.ToString()) && qs_iViewDetail <= 0;
                btnReject.Visible = Security.CheckSecurity(PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_REJECT.ToString()) && qs_iViewDetail <= 0;

                if (qs_bIsGroup) GetGroupDataApprovalInformation();
                else GetGroupAccessRightDataApprovalInformation();
            }
            else
            {
                if (!IsPostBack)
                {
                    if (!Security.CheckSecurity(PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS.ToString()))
                        NoPermission();

                    BindCmbGroupName(cmbGroupName);
                    if (qs_iGroupID != 0)
                    {
                        GetGroupAccessRight();
                        //AlertMessageBox(Page, "CheckObjectAccess();");
                        ramAccessRight.ResponseScripts.Add("CheckObjectAccess();");
                    }
                    else
                    {
                        Alert("Data not found");
                    }
                }
            }
        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
        finally
        {

        }
    }
    protected void cmbGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;
        try
        {
            Response.Redirect(String.Format("AccessRight.aspx?GroupID={0}", cmbGroupName.SelectedValue), false);
        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;
        short iStatus = 0;
        string sDescription = "Update Access Right";
        string sPreviousDetail = "<xml />";

        Group oGroup = new Group(Convert.ToInt32(cmbGroupName.SelectedValue));
        try
        {
            sPreviousDetail = SaveAccessRight(ref iStatus, ref oGroup);

            if (iStatus == 1) sDescription += " successful and ready to approval process";
            else sDescription += " not successful";

            if (iStatus == 1)
            {
                PFSCommon.ClearAccessRight();

                BackToGroupList(sDescription);
            }
            else Alert(sDescription);

        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
        finally
        {
            Security.WriteUserLog(
                sRefNumber,
                sDescription,
                oGroup,
                iStatus,
                (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS,
                sPreviousDetail);

            //** Dispose Any Objects **//
            oGroup = null;
            sRefNumber = null;
            sDescription = null;
        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;
        string sRemark = string.Empty;
        string sDescription = "Approve Approval Request";
        short iStatus = 0;
        Group oGroup = new Group();
        ApprovalLog oApprovalLog = new ApprovalLog(Convert.ToInt32(qs_iApprovalID));
        ApprovalLog oCheckExistingContent = new ApprovalLog();
        object iGroupID = null;

        try
        {
            oApprovalLog.DAL_LoadWithWithModuleObject();
            oApprovalLog.Remark = txtRemarks.Text;
            oGroup = (Group)PFSXMLTools.DeserializeObjectUsingUnicode<Group>(oApprovalLog.Detail);

            if (oGroup.GroupID > 0)
                iGroupID = oGroup.GroupID;

            if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE)
            {
                sDescription = "Approve Create Group request";
                Group oCheckGroup = new Group();

                //*** Check Duplication ***//
                if (oCheckGroup.DAL_LoadByGroupName(oGroup.GroupName, iGroupID))
                    sDescription = "Duplicate group name in Database. Please change the group name";
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("Group", "GroupName", oGroup.GroupName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE, oApprovalLog.ApprovalLogID))
                {
                    //*** Duplicate group name detected in ApprovalLog***//
                    sDescription = "Duplicate group name in Approval Log. Please change the group name";
                }
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("Group", "GroupName", oGroup.GroupName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE, oApprovalLog.ApprovalLogID))
                {
                    //*** Duplicate group name detected in ApprovalLog***//
                    sDescription = "Duplicate group name in Approval Log. Please change the group name";
                }
                //*** Approve and Add if no duplication ***//
                else
                    if ((iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.APPROVE, ref sRemark))) == 1)
                        sDescription += " successful";
                    else
                        sDescription += " not successful CODE:" + sRefNumber;

            }
            else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE)
            {
                sDescription = "Approve Update Group request";
                bool bIsFound = false;
                Group oCheckGroup = new Group();

                bIsFound = oCheckGroup.DAL_LoadByGroupName(oGroup.GroupName, iGroupID);

                //*** Check Duplication ***//
                if (bIsFound && oCheckGroup.GroupID != oCheckGroup.GroupID)
                    //*** Duplicate name detected ***//
                    sDescription = "Duplicate group name in Database. Please change the group name";
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("Group", "GroupName", oGroup.GroupName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE, oApprovalLog.ApprovalLogID))
                {
                    //*** Duplicate group name detected in ApprovalLog***//
                    sDescription = "Duplicate group name in Approval Log. Please change the group name";
                }
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("Group", "GroupName", oGroup.GroupName, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE, oApprovalLog.ApprovalLogID))
                {
                    //*** Duplicate group name detected in ApprovalLog***//
                    sDescription = "Duplicate group name in Approval Log. Please change the group name";
                }
                else
                    //*** Set Description Status ***//
                    if ((iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.APPROVE, ref sRemark))) == 1)
                        sDescription += " successful";
                    else
                        sDescription += " not successful CODE:" + sRefNumber;

            }
            else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_DELETE)
            {
                sDescription = "Approve Delete Group request";

                iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.APPROVE, ref sRemark));
                if (iStatus == 0)
                    sDescription += " not successfully, Clould be Group already used by another data, delete aborted. CODE:" + sRefNumber;
                else
                    sDescription += " successful";

            }
            else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS)
            {
                sDescription = "Access Right Update";

                iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.APPROVE, ref sRemark));
                if (iStatus == 0)
                    sDescription += " not successful CODE:" + sRefNumber;
                else
                    sDescription += " successful";

            }

            if (iStatus == 1)
            {
                PFSCommon.ClearAccessRight();

                BackToApprovalList(sDescription);
            }
            else Alert(sDescription);

        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception Ex)
        {
            if (Ex is SqlException)
            {
                if (Ex.Message.Contains("FK_PFS_USER_GROUP_PFS_GROUP"))
                {
                    Alert("Delete not successfully, Clould be Group already used by another data, delete aborted.");
                }
            }
            else
            {
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }

            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
        }
        finally
        {
            Security.WriteUserLog(sRefNumber, sDescription, oGroup, iStatus, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_APPROVE);

            oGroup = null;
            oApprovalLog = null;
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        string sRefNumber = PFSCommon.GenerateRefNumber();
        string sRemark = string.Empty;
        string sDescription = "Reject Group Request";
        short iStatus = 0;
        ApprovalLog oApprovalLog = new ApprovalLog(Convert.ToInt32(qs_iApprovalID));
        Group oGroup = new Group();

        try
        {
            oApprovalLog.DAL_LoadWithWithModuleObject();
            oApprovalLog.Remark = txtRemarks.Text;
            oGroup = (Group)PFSXMLTools.DeserializeObjectUsingUnicode<Group>(oApprovalLog.Detail);

            iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.REJECT, ref sRemark));
            if (iStatus == 0)
            {
                sDescription += " not successful CODE:" + sRefNumber;
                Alert(sDescription);
            }
            else
            {
                sDescription += " successful";
                BackToApprovalList(sDescription);
            }
        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, System.Reflection.MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
        finally
        {
            Security.WriteUserLog(sRefNumber, sDescription, oGroup, iStatus, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_REJECT);

            //*** Dispose Any Objects ***//
            sRefNumber = null; ;
            oApprovalLog = null;
            oGroup = null;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;
        try
        {
            if (sessIsApprovalMode)
                BackToApprovalList();
            else
                BackToGroupList();
        }
        catch (System.Threading.ThreadAbortException) { }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
    }
    #endregion

    #region Data Binding

    void BindCmbGroupName(DropDownList cmbMyCombo)
    {
        try
        {
            GroupCollection oGroupCollection = new GroupCollection();
            oGroupCollection.DAL_Load();
            oGroupCollection.Sort(GroupCollection.GroupFields.GroupName, true);

            cmbMyCombo.DataSource = oGroupCollection;
            cmbMyCombo.DataTextField = "GroupName";
            cmbMyCombo.DataValueField = "GroupID";
            cmbMyCombo.DataBind();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    #endregion

    #region Method

    /// <summary>
    /// Back to User list page if this form was called from -> GroupList.aspx
    /// </summary>
    /// <param name="PromptMessage">Message to prompt</param>
    private void BackToGroupList(string PromptMessage = null)
    {
        if (PromptMessage != null)
            Response.Write("<script>alert('" + PromptMessage + "'); location.href='GroupList.aspx'</script>");
        else
            Response.Redirect("GroupList.aspx", false);
    }
    /// <summary>
    /// Back to Approval List page if this form was called from -> ApprovalList.aspx
    /// </summary>
    /// <param name="PromptMessage">Message to prompt</param>
    private void BackToApprovalList(string PromptMessage = null)
    {
        try
        {
            if (PromptMessage != null)
                Response.Write("<script>alert('" + PromptMessage + "'); location.href='../ApprovalLog/ApprovalLogList.aspx'</script>");
            else
                Response.Redirect("../ApprovalLog/ApprovalLogList.aspx");
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    /// <summary>
    /// Main Function in saving access right
    /// </summary>
    /// <returns></returns>
    private string SaveAccessRight(ref short p_iStatus, ref Group oGroup)
    {
        oGroup = new Group();
        Group oLastGroupBeforeUpdate = new Group();
        oGroup.GroupID = Convert.ToInt32(cmbGroupName.SelectedValue);
        oGroup.DAL_LoadWithGroupMember();
        oLastGroupBeforeUpdate.GroupID = Convert.ToInt32(cmbGroupName.SelectedValue);
        oLastGroupBeforeUpdate.DAL_LoadWithGroupMember();
        ModuleObjectMemberGroupCollection oModuleObjectMemberGroupCollection = new ModuleObjectMemberGroupCollection();

        foreach (ModuleObjectMemberGroup oModuleObjectMemberGroup in oGroup.GroupMemberCollection)
        {
            oModuleObjectMemberGroupCollection.Add(oModuleObjectMemberGroup);
        }

        oGroup.GroupMemberCollection = new ModuleObjectMemberGroupCollection();

        int iFor;
        string sMember = "";
        string sRemark = string.Empty;
        string sDescription = string.Empty;
        string sPreviousDetail = "<xml />";

        string sMemberCheck = Request.Form["chkMember"] + "," + Request.Form["rbMember"];
        if (!string.IsNullOrWhiteSpace(sMemberCheck))
        {

            string[] arrLoop = sMemberCheck.Split(new Char[] { ',' });
            for (iFor = 0; iFor < arrLoop.Length; iFor++)
            {
                bool bIsModuleObjectMemberGroupExisting = false;
                string[] arrMember = Convert.ToString(arrLoop[iFor]).Split(new Char[] { '*' });
                if (!string.IsNullOrWhiteSpace(arrMember[0]))
                {
                    if ((Convert.ToInt32(arrMember[3]) == 0) || (Convert.ToInt32(arrMember[3]) == 1))                             //** Is Have Access 
                    {
                        ModuleObjectMemberGroup oGroupMember = new ModuleObjectMemberGroup();
                        ModuleObjectMemberGroupCollection oGroupMemberCollection = new ModuleObjectMemberGroupCollection();
                        oGroupMemberCollection.DAL_Load(null, Convert.ToInt32(arrMember[0]), Convert.ToInt32(arrMember[1]), Convert.ToInt32(arrMember[2]), null);
                        if (oGroupMemberCollection.Count > 0)
                        {
                            oGroupMember.GroupName = oGroup.GroupName;
                            oGroupMember.MemberCode = oGroupMemberCollection[0].MemberCode;
                            oGroupMember.MemberName = oGroupMemberCollection[0].MemberName;
                            oGroupMember.ModuleCode = oGroupMemberCollection[0].ModuleCode;
                            oGroupMember.ModuleName = oGroupMemberCollection[0].ModuleName;
                            oGroupMember.ObjectCode = oGroupMemberCollection[0].ObjectCode;
                            oGroupMember.ObjectName = oGroupMemberCollection[0].ObjectName;
                        }
                        oGroupMember.ModuleID = Convert.ToInt32(arrMember[0]);
                        oGroupMember.ModuleObjectID = Convert.ToInt32(arrMember[1]);
                        oGroupMember.ModuleObjectMemberID = Convert.ToInt32(arrMember[2]);
                        oGroupMember.ModuleObjectMemberGroupID = -1;
                        oGroupMember.GroupID = oGroup.GroupID;

                        foreach (ModuleObjectMemberGroup oModuleObjectMemberGroup in oModuleObjectMemberGroupCollection)
                        {
                            if (oModuleObjectMemberGroup.ModuleObjectMemberID == oGroupMember.ModuleObjectMemberID)
                            {
                                oModuleObjectMemberGroup.ModuleObjectMemberGroupID = -1;
                                oGroup.GroupMemberCollection.Add(oModuleObjectMemberGroup);
                                bIsModuleObjectMemberGroupExisting = true;
                                break;
                            }
                        }

                        if (!bIsModuleObjectMemberGroupExisting)
                            oGroup.GroupMemberCollection.Add(oGroupMember);
                    }

                    if (!string.IsNullOrWhiteSpace(sMember))
                    {
                        sMember = Convert.ToString(arrMember[2]);
                    }
                    else
                    {
                        sMember = sMember + "," + arrMember[2];
                    }
                }
            }
        }

        sDescription = "Update Group Access";

        oGroup.UpdateDate = DateTime.Now;
        oGroup.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;

        ApprovalLog oApprovalLog = new ApprovalLog()
        {
            RefID = Convert.ToInt32(oGroup.GroupID),
            ModuleObjectMemberID = (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS,
            ApprovalStatusID = (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.PENDING,
            Detail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oGroup),
            PreviousDetail = sPreviousDetail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oLastGroupBeforeUpdate)
        };
        p_iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(
            oGroup,
            oApprovalLog,
            PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.ApprovalStatus.PENDING,
            ref sRemark));

        //if (p_iStatus == 0)
        //{
        //    sDescription = "Update Group Access Not successful CODE:" + RefNumber;
        //    Alert(sDescription);
        //}
        //else
        //{
        //    BackToGroupList();
        //}

        if (p_iStatus == 1)
            return sPreviousDetail;
        else
            return "";
    }
    /// <summary>
    /// Function to get data on Detail Approval
    /// </summary>
    private void GetGroupDataApprovalInformation()
    {
        ApprovalLog oApprovalLog = new ApprovalLog(Convert.ToInt32(qs_iApprovalID));
        Group oGroup = new Group();
        Group oNewGroup = new Group();

        try
        {
            oApprovalLog.DAL_LoadWithWithModuleObject();

            lblRequestBy.Text = string.Format("{0} / {1}", oApprovalLog.CreateByUserName, oApprovalLog.CreateByFullUserName);
            lblRequestDate.Text = string.Format("{0:dd-MMM-yyyy HH:mm:ss}", oApprovalLog.CreateDate);
            lblRequestType.Text = oApprovalLog.MemberName;

            if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE)
            {
                tdGroupData.Visible = false;
                tdNewGroupData.ColSpan = 2;

                oNewGroup = (Group)PFSXMLTools.DeserializeObjectUsingUnicode<Group>(oApprovalLog.Detail);
                lblNewActiveStatus.Text = oNewGroup.IsActive ? "Active" : "Not Active";
                lblNewGroupName.Text = oNewGroup.GroupName;
                lblNewGroupDescr.Text = oNewGroup.GroupDescr;
            }
            else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE)
            {
                //oGroup.DAL_Load(oApprovalLog.RefID);
                oGroup = (Group)PFSXMLTools.DeserializeObjectUsingUnicode<Group>(oApprovalLog.PreviousDetail);
                lblActiveStatus.Text = oGroup.IsActive ? "Active" : "Not Active";
                lblGroupName.Text = oGroup.GroupName;
                lblGroupDescr.Text = oGroup.GroupDescr;

                oNewGroup = (Group)PFSXMLTools.DeserializeObjectUsingUnicode<Group>(oApprovalLog.Detail);
                lblNewActiveStatus.Text = oNewGroup.IsActive ? "Active" : "Not Active";
                lblNewGroupName.Text = oNewGroup.GroupName;
                lblNewGroupDescr.Text = oNewGroup.GroupDescr;

                CompareAndHighlight();
            }
            else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_DELETE)
            {
                oGroup = (Group)PFSXMLTools.DeserializeObjectUsingUnicode<Group>(oApprovalLog.Detail);
                lblActiveStatus.Text = oGroup.IsActive ? "Active" : "Not Active";
                lblGroupName.Text = oGroup.GroupName;
                lblGroupDescr.Text = oGroup.GroupDescr;

                tdNewGroupData.Visible = false;
            }
            else if (oApprovalLog.ModuleObjectMemberID == (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS)
            {

            }

            if (qs_iViewDetail == 1)
            {
                txtRemarks.Text = oApprovalLog.Remark;
                txtRemarks.Enabled = false;
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    /// <summary>
    /// Get Approval Information for Access Right Data
    /// </summary>
    private void GetGroupAccessRightDataApprovalInformation()
    {
        Group oGroup = new Group();
        ApprovalLog oApprovalLog = new ApprovalLog();
        ModuleObjectMemberGroupCollection oGroupMemberCollectionApproval = null;

        try
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            tdGroupData.ColSpan = 2;
            int iGroupID = -1;

            if (qs_iApprovalID > 0)
            {
                oApprovalLog.ApprovalLogID = qs_iApprovalID;
                oApprovalLog.DAL_LoadWithWithModuleObject();
                iGroupID = oApprovalLog.RefID;
                oGroupMemberCollectionApproval = ((Group)PFSXMLTools.DeserializeObjectUsingUnicode<Group>(oApprovalLog.Detail)).GroupMemberCollection;

                lblRequestBy.Text = string.Format("{0} / {1}", oApprovalLog.CreateByUserName, oApprovalLog.CreateByFullUserName);
                lblRequestDate.Text = string.Format("{0:dd-MMM-yyyy HH:mm:ss}", oApprovalLog.CreateDate);
                lblRequestType.Text = oApprovalLog.MemberName;

            }
            else if (qs_iGroupID > 0)
            {
                iGroupID = qs_iGroupID;
            }
            else
            {
                iGroupID = Convert.ToInt32(cmbGroupName.SelectedValue);
            }

            oGroup.GroupID = iGroupID;
            oGroup.DAL_LoadWithGroupMember();

            cmbGroupName.SelectedValue = qs_iGroupID.ToString();
            lblActiveStatus.Text = oGroup.IsActive ? "ACTIVE" : "NOT ACTIVE";
            lblGroupName.Text = oGroup.GroupName;
            lblGroupDescr.Text = oGroup.GroupDescr;

            StringBuilder sbLiteral = new StringBuilder();
            using (SqlDataReader drModule = oGroup.GetModule())
            {
                while (drModule.Read())
                {
                    //-- Module --
                    //sbLiteral.Append("<br>");
                    sbLiteral.Append("<table>");
                    sbLiteral.Append("<thead>");
                    sbLiteral.Append("<tr>");
                    sbLiteral.Append("  <th style='width:15%; border:0px 0px 0px 0px; padding-top:0px; vertical-align:middle; padding-bottom:0px; text-align:left; '>");
                    sbLiteral.Append("     <h3 class='AccessRight'>  <strong>" + drModule["module_name"] + "</strong></h3>");
                    sbLiteral.Append("  </th>");
                    sbLiteral.Append("  <th style='width:85%; border:0px 0px 0px 0px; text-align:right; padding-top:0px; padding-bottom:0px; padding-left:10px; color:#000000'>");   //AccessRightHeaderCheckbox
                    sbLiteral.Append("  </th>");
                    sbLiteral.Append("</tr>");
                    sbLiteral.Append("</thead>");
                    sbLiteral.Append("<tbody>");

                    using (SqlDataReader drModuleObject = oGroup.GetModuleObject(drModule["pfs_module_id"]))
                    {
                        while (drModuleObject.Read())
                        {

                            sbLiteral.Append("<tr>");
                            //-- Object --
                            sbLiteral.Append("  <td width=200px height=20 style='padding-left:5px;' valign=middle id='td" + drModuleObject["object_code"] + "'>");
                            sbLiteral.Append(drModuleObject["object_name"].ToString() + "");
                            sbLiteral.Append("  </td>");
                            //------------

                            //-- Member --
                            sbLiteral.Append("<td style='text-align:center; padding-left:10px;'>");
                            sbLiteral.Append("<table style=' border:0px 0px 0px 0px;'");
                            sbLiteral.Append("<tr>");
                            //sbLiteral.Append("  <td style='border-bottom:solid 1px gray;'>");
                            using (SqlDataReader drModuleObjectMember = oGroup.GetModuleObjectMember(iGroupID, Convert.ToInt32(drModuleObject["pfs_module_object_id"])))
                            {
                                //.Append("<table border=0 cellpadding=0 cellspacing=0>");
                                //.Append("  <tr>");
                                // sbLiteral.Append("      <td width='52' valign=top> </td>");
                                //sbLiteral.Append("      </td>");

                                int iCountObject = 0;
                                int iMaxNewRow = 10;
                                int iRow = 1;
                                while (drModuleObjectMember.Read())
                                {
                                    if (Convert.ToString(drModuleObjectMember["member_code"]) != "SCR_USR_LOGIN" &&
                                        Convert.ToString(drModuleObjectMember["member_code"]) != "SCR_USR_LOGOUT")
                                    {
                                        string sHighlightCode = "";
                                        if (CompareGroupMember(oGroupMemberCollectionApproval, drModuleObjectMember))
                                            sHighlightCode = " background-color:Yellow;color:Red; ";

                                        #region Default code, use this part for other application

                                        if (iCountObject == (iMaxNewRow * iRow))
                                        {
                                            iRow = iRow + 1;
                                            sbLiteral.Append("<tr>");
                                            sbLiteral.Append("  <td width='52'>&nbsp;</td>");
                                            sbLiteral.Append("  <td width='52' valign=top>");
                                        }
                                        else
                                        {

                                            if (drModuleObjectMember["member_name"].ToString().Length < 10)
                                            {
                                                sbLiteral.Append("  <td style='width:90px; text-align:center;" + sHighlightCode + " '  valign=top> ");
                                            }
                                            else
                                            {
                                                sbLiteral.Append("  <td style='width:90px; text-align:center;" + sHighlightCode + "' valign=top>");
                                            }
                                        }

                                        if (Convert.ToInt32(drModuleObjectMember["access"]) == 0)
                                        {
                                            if (sHighlightCode.Length > 0)
                                                sbLiteral.Append(String.Format("      <input type=checkbox  disabled='disabled' name=chkMember value='{0}*{1}*{2}*{3}*{4}' onClick=\"chkMember_Change('{0}*{1}*{2}*{3}*{4}')\"  checked>", drModule["pfs_module_id"], drModuleObject["pfs_module_object_id"], drModuleObjectMember["pfs_module_object_member_id"], drModuleObjectMember["access"], drModuleObjectMember["member_name"]));
                                            else
                                                sbLiteral.Append(String.Format("      <input type=checkbox  disabled='disabled' name=chkMember value='{0}*{1}*{2}*{3}*{4}' onClick=\"chkMember_Change('{0}*{1}*{2}*{3}*{4}')\" >", drModule["pfs_module_id"], drModuleObject["pfs_module_object_id"], drModuleObjectMember["pfs_module_object_member_id"], drModuleObjectMember["access"], drModuleObjectMember["member_name"]));
                                        }
                                        else
                                        {
                                            if (sHighlightCode.Length > 0)
                                                sbLiteral.Append(String.Format("      <input type=checkbox  disabled='disabled' name=chkMember value='{0}*{1}*{2}*{3}*{4}' onClick=\"chkMember_Change('{0}*{1}*{2}*{3}*{4}')\" >", drModule["pfs_module_id"], drModuleObject["pfs_module_object_id"], drModuleObjectMember["pfs_module_object_member_id"], drModuleObjectMember["access"], drModuleObjectMember["member_name"]));
                                            else
                                                sbLiteral.Append(String.Format("      <input type=checkbox  disabled='disabled' name=chkMember value='{0}*{1}*{2}*{3}*{4}' onClick=\"chkMember_Change('{0}*{1}*{2}*{3}*{4}')\"  checked>", drModule["pfs_module_id"], drModuleObject["pfs_module_object_id"], drModuleObjectMember["pfs_module_object_member_id"], drModuleObjectMember["access"], drModuleObjectMember["member_name"]));
                                        }
                                        sbLiteral.Append(UppercaseFirst(drModuleObjectMember["member_name"].ToString()));

                                        if (iCountObject == (iMaxNewRow * iRow))
                                        {
                                            //sbLiteral.Append("</tr>");
                                            sbLiteral.Append("</td>");
                                        }
                                        else
                                        {
                                            sbLiteral.Append("</td>");
                                        }
                                        #endregion
                                    }
                                }
                                sbLiteral.Append("</tr>");
                                sbLiteral.Append("</td>");
                                sbLiteral.Append("</table>");
                                sbLiteral.Append("</tr>");
                            }
                            //sbLiteral.Append("</td>");
                            //sbLiteral.Append("</tr>");
                        }
                    }
                    sbLiteral.Append("</tbody>");
                    sbLiteral.Append("</table>");
                }
            }
            ltrBody.Text = sbLiteral.ToString();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            oApprovalLog = null;
            oGroup = null;
            oGroupMemberCollectionApproval = null;
        }
    }
    /// <summary>
    /// Function to make this form in approval input form for this module object
    /// </summary>
    /// <param name="p_ApprovalMode">IsApprovalMode</param>
    private void SwitchToApprovalMode(bool p_ApprovalMode)
    {
        try
        {
            sessIsApprovalMode = p_ApprovalMode;

            //*** INVISIBLE ***//
            if (
            cmbGroupName.Visible =
            btnSave.Visible =
            btnCancel.Visible =

            !(//*** VISIBLE ***//
                trApprovalInformation.Visible =
                trActiveStatus.Visible =
                trNewActiveStatus.Visible =
                tdNewGroupData.Visible =
                trRemarks.Visible =
                btnBack.Visible =
                p_ApprovalMode
            ))
            {//*** If Not In Approval Mode ***//

                tdGroupData.ColSpan = 2;
            }
            else
            {//*** If In Approval Mode ***//

                tdAccessRight.Visible =
                    !(
                         tdNewGroupData.Visible = (qs_bIsGroup)
                    );
            }

            if (qs_iViewDetail == 1)
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    /// <summary>
    /// Function in approval mode to compare side by side data between old data and new one. And highlight unmacthed data
    /// </summary>
    private void CompareAndHighlight()
    {
        try
        {
            if (!lblActiveStatus.Text.Equals(lblNewActiveStatus.Text))
                lblActiveStatus.BackColor = lblNewActiveStatus.BackColor = System.Drawing.Color.Yellow;

            if (!lblGroupName.Text.Equals(lblNewGroupName.Text))
                lblGroupName.BackColor = lblNewGroupName.BackColor = System.Drawing.Color.Yellow;

            if (!lblGroupDescr.Text.Equals(lblNewGroupDescr.Text))
                lblGroupDescr.BackColor = lblNewGroupDescr.BackColor = System.Drawing.Color.Yellow;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    /// <summary>
    /// Function to set page title
    /// </summary>
    private void SetTitle()
    {
        try
        {
            if (qs_iApprovalID > 0)
            {
                if (qs_bIsGroup)
                {
                    if (qs_iViewDetail > 0)
                    {
                        divSubtitle.InnerText = "Group Approval";
                    }
                    else
                    {
                        divSubtitle.InnerText = "Group Request";
                    }
                }
                else
                {
                    if (qs_iViewDetail > 0)
                    {
                        divSubtitle.InnerText = "Access Right Approval";
                    }
                    else
                    {
                        divSubtitle.InnerText = "Access Right Request";
                    }
                }
            }
            else { divSubtitle.InnerText = "Group Access Right"; }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    private string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;
        s = s.ToLower();
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }
    private bool CompareGroupMember(ModuleObjectMemberGroupCollection p_oGroupMemberCollection, SqlDataReader drGroupMember)
    {
        try
        {
            bool bIsNotMatch = false;

            if (Convert.ToBoolean(drGroupMember["access"]))
            {
                foreach (ModuleObjectMemberGroup oGroupMember in p_oGroupMemberCollection)
                {
                    bIsNotMatch = (oGroupMember.ModuleObjectMemberID == Convert.ToInt32(drGroupMember["pfs_module_object_member_id"]));

                    if (bIsNotMatch)
                        break;
                }
                bIsNotMatch = !bIsNotMatch;
            }
            else
            {
                foreach (ModuleObjectMemberGroup oGroupMember in p_oGroupMemberCollection)
                {
                    bIsNotMatch = (oGroupMember.ModuleObjectMemberID == Convert.ToInt32(drGroupMember["pfs_module_object_member_id"]));

                    if (bIsNotMatch)
                        break;
                }
            }

            return bIsNotMatch;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    #endregion

    #region Data Access

    private void GetGroupAccessRight()
    {
        Group oGroup = new Group(qs_iGroupID);

        try
        {
            oGroup.DAL_Load(qs_iGroupID);

            cmbGroupName.SelectedValue = qs_iGroupID.ToString();
            lblGroupDescr.Text = oGroup.GroupDescr;

            StringBuilder sbLiteral = new StringBuilder();
            using (SqlDataReader drModule = oGroup.GetModule())
            {
                while (drModule.Read())
                {
                    //-- Module --
                    sbLiteral.Append("<br>");
                    sbLiteral.Append("<table style='padding:0px 0px 0px 0px;'>");
                    sbLiteral.Append("<thead>");
                    sbLiteral.Append("<tr>");
                    sbLiteral.Append("  <th style='width:15%; border:0px 0px 0px 0px; padding-top:0px; vertical-align:middle; padding-bottom:0px; text-align:left; '>");
                    sbLiteral.Append("    <h3 class='AccessRight'> " + drModule["module_name"] + "</h3>");
                    sbLiteral.Append("  </th>");
                    sbLiteral.Append("  <th style='width:85%; border:0px 0px 0px 0px; text-align:right; padding:0px 15px 0px 0px;  color:#000000'>");
                    sbLiteral.Append("      <input class='click_all' type=checkbox name=chkAllMemberByModule" + drModule["pfs_module_id"] + " value=" + drModule["pfs_module_id"] + " onClick=chkAllMemberByModule_Change(" + drModule["pfs_module_id"] + ") >");
                    sbLiteral.Append("    <strong>All</strong> ");
                    sbLiteral.Append("  </th>");
                    sbLiteral.Append("</tr>");
                    sbLiteral.Append("</thead>");
                    sbLiteral.Append("<tbody>");

                    using (SqlDataReader drModuleObject = oGroup.GetModuleObject(drModule["pfs_module_id"]))
                    {
                        while (drModuleObject.Read())
                        {

                            sbLiteral.Append("<tr>");
                            //-- Object --
                            sbLiteral.Append("  <td id='td" + drModuleObject["object_code"] + "'>");
                            sbLiteral.Append(drModuleObject["object_name"].ToString() + "");
                            sbLiteral.Append("  </td>");

                            //-- Member --
                            #region Member
                            sbLiteral.Append("<td style='text-align:center; padding-left:10px;'>");
                            sbLiteral.Append("<table style=' border:0px 0px 0px 0px;'>");
                            sbLiteral.Append("<tr>");
                            using (SqlDataReader drModuleObjectMember = oGroup.GetModuleObjectMember(Convert.ToInt32(cmbGroupName.SelectedValue), Convert.ToInt32(drModuleObject["pfs_module_object_id"])))
                            {
                                sbLiteral.Append("      <td style='width:90px; text-align:center;' valign='top'>");
                                //-- ALL --
                                if (Convert.ToInt32(drModuleObject["pfs_module_object_id"]) == 7) //7 : Dashboard
                                {
                                    //sbLiteral.Append("          <input type=button name=chkAllMemberByObject" + drModuleObject["pfs_module_object_id"] + " value='Clear All' onClick=chkAllMemberByObject_Change('" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "') >");
                                }
                                else
                                {
                                    sbLiteral.Append("          <input type=checkbox name=chkAllMemberByObject" + drModuleObject["pfs_module_object_id"] + " value=" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + " onClick=chkAllMemberByObject_Change('" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "')>All");
                                }
                                //---------
                                sbLiteral.Append("      </td>");

                                int iCountObject = 0;
                                int iMaxNewRow = 10;
                                int iRow = 1;
                                while (drModuleObjectMember.Read())
                                {
                                    if (Convert.ToString(drModuleObjectMember["member_code"]) != "SCR_USR_LOGIN" &&
                                        Convert.ToString(drModuleObjectMember["member_code"]) != "SCR_USR_LOGOUT")
                                    {
                                        iCountObject = iCountObject + 1;
                                        #region ga kepake
                                        //if (Convert.ToString(drModuleObjectMember["member_code"]) == "AUD_DAS_AUDITOR" ||
                                        //    Convert.ToString(drModuleObjectMember["member_code"]) == "AUD_DAS_SUPERVISOR" ||
                                        //    Convert.ToString(drModuleObjectMember["member_code"]) == "AUD_DAS_PIC" ||
                                        //    Convert.ToString(drModuleObjectMember["member_code"]) == "AUD_DAS__NONE")
                                        //{
                                        //    #region Delete this part if use other application
                                        //    if (iCountObject == (iMaxNewRow * iRow))
                                        //    {
                                        //        iRow = iRow + 1;
                                        //        sbLiteral.Append("<tr>");
                                        //        sbLiteral.Append("  <td width='52'>&nbsp;</td>");
                                        //        sbLiteral.Append("  <td width='52' valign=top>");
                                        //    }
                                        //    else
                                        //    {
                                        //        if (drModuleObjectMember["member_name"].ToString().Length < 10)
                                        //        {
                                        //            sbLiteral.Append("  <td width='90' valign=top>");
                                        //        }
                                        //        else
                                        //        {
                                        //            sbLiteral.Append("  <td width='125' valign=top>");
                                        //        }
                                        //    }

                                        //    if (Convert.ToInt32(drModuleObjectMember["access"]) == 0)
                                        //    {
                                        //        if (drModuleObjectMember["member_name"].ToString().ToUpper() == "NONE")
                                        //        {
                                        //            sbLiteral.Append("      <input type=radio name=rbMember value='" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "*" + drModuleObjectMember["pfs_module_object_member_id"] + "*" + drModuleObjectMember["access"] + "*" + drModuleObjectMember["member_name"] + "' onClick=\"chkMember_Change('" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "*" + drModuleObjectMember["pfs_module_object_member_id"] + "*" + drModuleObjectMember["access"] + "*" + drModuleObjectMember["member_name"] + "')\" checked>");
                                        //        }
                                        //        else
                                        //        {
                                        //            sbLiteral.Append("      <input type=radio name=rbMember value='" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "*" + drModuleObjectMember["pfs_module_object_member_id"] + "*" + drModuleObjectMember["access"] + "*" + drModuleObjectMember["member_name"] + "' onClick=\"chkMember_Change('" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "*" + drModuleObjectMember["pfs_module_object_member_id"] + "*" + drModuleObjectMember["access"] + "*" + drModuleObjectMember["member_name"] + "')\" >");
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        sbLiteral.Append("      <input type=radio name=rbMember value='" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "*" + drModuleObjectMember["pfs_module_object_member_id"] + "*" + drModuleObjectMember["access"] + "*" + drModuleObjectMember["member_name"] + "' onClick=\"chkMember_Change('" + drModule["pfs_module_id"] + "*" + drModuleObject["pfs_module_object_id"] + "*" + drModuleObjectMember["pfs_module_object_member_id"] + "*" + drModuleObjectMember["access"] + "*" + drModuleObjectMember["member_name"] + "')\" checked>");

                                        //    }
                                        //    sbLiteral.Append(UppercaseFirst(drModuleObjectMember["member_name"].ToString()));

                                        //    if (iCountObject == (iMaxNewRow * iRow))
                                        //    {
                                        //        sbLiteral.Append("</tr>");
                                        //        sbLiteral.Append("</td>");
                                        //    }
                                        //    else
                                        //    {
                                        //        sbLiteral.Append("</td>");
                                        //    }
                                        //    #endregion
                                        //}
                                        //else // default code. use this part for other application
                                        //{ 
                                        #endregion
                                        #region Default code, use this part for other application
                                        if (iCountObject == (iMaxNewRow * iRow))
                                        {
                                            iRow = iRow + 1;
                                            sbLiteral.Append("  <td >&nbsp;</td>");
                                            sbLiteral.Append("  <td  valign=top>");
                                        }
                                        else
                                        {
                                            if (drModuleObjectMember["member_name"].ToString().Length < 10)
                                            {
                                                sbLiteral.Append("  <td style='width:90px; text-align:center'  valign=top>");
                                            }
                                            else
                                            {
                                                sbLiteral.Append("  <td  style='width:180px; text-align:center'  valign=top>");
                                            }
                                        }

                                        if (Convert.ToInt32(drModuleObjectMember["access"]) == 0)
                                        {
                                            sbLiteral.Append(string.Format("      <input type=checkbox name=chkMember value='{0}*{1}*{2}*{3}*{4}' onClick=\"chkMember_Change('{0}*{1}*{2}*{3}*{4}')\" >", drModule["pfs_module_id"], drModuleObject["pfs_module_object_id"], drModuleObjectMember["pfs_module_object_member_id"], drModuleObjectMember["access"], drModuleObjectMember["member_name"]));

                                        }
                                        else
                                        {
                                            sbLiteral.Append(string.Format("      <input type=checkbox name=chkMember value='{0}*{1}*{2}*{3}*{4}' onClick=\"chkMember_Change('{0}*{1}*{2}*{3}*{4}')\" checked >", drModule["pfs_module_id"], drModuleObject["pfs_module_object_id"], drModuleObjectMember["pfs_module_object_member_id"], drModuleObjectMember["access"], drModuleObjectMember["member_name"]));

                                        }
                                        sbLiteral.Append(UppercaseFirst(drModuleObjectMember["member_name"].ToString()));

                                        if (iCountObject == (iMaxNewRow * iRow))
                                        {
                                            //sbLiteral.Append("</tr>");
                                            sbLiteral.Append("</td>");
                                        }
                                        else
                                        {
                                            sbLiteral.Append("</td>");
                                        }
                                        #endregion
                                    }
                                    //}
                                }
                            }
                            sbLiteral.Append("</tr>");
                            sbLiteral.Append("</td>");
                            sbLiteral.Append("</table>");
                            #endregion
                            sbLiteral.Append("</tr>");
                        }
                    }
                    //sbLiteral.Append("</table>");
                    sbLiteral.Append("</tbody>");
                    sbLiteral.Append("</table>");



                }
            }
            ltrBody.Text = sbLiteral.ToString();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            oGroup = null;
        }
    }
    #endregion
}
