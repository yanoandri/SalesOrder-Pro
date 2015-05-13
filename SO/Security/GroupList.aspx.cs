using System;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using SO.BusinessLogicLayer;
using SO.BusinessLogicLayer.Enumeration;
using Telerik.Web.UI;

public partial class Security_GroupList : PFSBasePage
{
    #region Session
    //private GroupCollection sessGroupCollection
    //{
    //    get { return (GroupCollection)Session["sessGroupCollection"]; }
    //    set { Session["sessGroupCollection"] = value; }
    //}
    #endregion

    #region Properties
    string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;

        try
        {
            if (!Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_GRP_READ.ToString())) NoPermission();
            btnCreateNewGroup.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE.ToString());

            if (!IsPostBack)
            {
                rgridGroupList.Rebind();
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, System.Reflection.MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
    }

    protected void btnFilterSearch_Click(object sender, EventArgs e)
    {
        string sRefNumber = PFSCommon.GenerateRefNumber();
        try
        {
            rgridGroupList.Rebind();
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;
        try
        {
            Response.Redirect("GroupList.aspx");
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
        finally
        {
            sRefNumber = null;
        }
    }
    protected void btnCreateNewGroup_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rgridGroupList.Items.Count; i++)
        {
            rgridGroupList.Items[i].Edit = false;
        }

        System.Collections.Specialized.ListDictionary ldNewValues = new System.Collections.Specialized.ListDictionary();
        ldNewValues["GroupID"] = 0;
        ldNewValues["IsActive"] = true;
        rgridGroupList.MasterTableView.InsertItem(ldNewValues);
    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        #region Use this to export grid list
        rptList.DataSource = GetGroupList();
        rptList.DataBind();

        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=GroupList.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        litCss.RenderControl(oHtmlTextWriter);
        rptList.RenderControl(oHtmlTextWriter);
        Response.Write(oStringWriter.ToString());
        Response.End(); 
        #endregion

        #region Use this to export group matrix
        //GroupCollection oGroupList = new GroupCollection();
        //oGroupList.DAL_Load();

        //StringBuilder sb = new StringBuilder();
        //sb.Append("<h2>Group Matrix Report</h2>");
        //sb.Append(string.Format("<label class='GridSubTitle_Office2007'>Generated Date : {0:dd MMM yyyy}</label><br />", DateTime.Now));
        //sb.Append(string.Format(" <label class='GridSubTitle_Office2007'>Generate By : {0}</label><br /><br />", ((CustomPrincipal)HttpContext.Current.User).User.UserName));
        //sb.Append("<style type='text/css'>.MasterTable_Office2007{border-collapse:separate !important;color:#27413e;}.MasterTable_Office2007 th{padding:0 5px 0 4px;}.MasterTable_Office2007 td{padding:0 4px;}.GridHeader_Office2007{font:bold 10px;background:#d3dbe9 url('Img/GridHeaderBg.gif') repeat-x;padding-left:6px;height:19px;color:#27413e;border-bottom:solid 1px #9eb6ce;text-align:center;}.GridHeader_Office2007 a{color:#27413e;text-decoration:none;}.GridRow_Office2007{background:transparent;height:19px;}.GridRow_Office2007 td{border-right:solid 1px #d0d7e5;border-bottom:solid 1px #d0d7e5;}.textfield{font-size:11px;color:#3d3d3d;font-family:Arial;}</style>");

        //foreach (Group oGroup in oGroupList)
        //{
        //    sb.Append(string.Format("<label style='font:bold 10px;'>Group Name : {0}<br /></label>", oGroup.GroupName));
        //    sb.Append("<table width='100%' class='MasterTable_Office2007' border='1'>");
        //    sb.Append("<tr class='MasterTable_Office2007'>");
        //    sb.Append("<td class='GridHeader_Office2007' >Module</td>");
        //    sb.Append("<td class='GridHeader_Office2007' >Sub Module</td>");
        //    sb.Append("<td class='GridHeader_Office2007' >Access Right</td>");
        //    sb.Append("</tr>");

        //    ModuleCollection oModuleList = new ModuleCollection();
        //    oModuleList.DAL_Load();

        //    bool bHaveAccess = false;
        //    foreach (PFSHelper.BusinessLogicLayer.Module oModule in oModuleList)
        //    {
        //        ModuleObjectCollection oObjectList = new ModuleObjectCollection();
        //        if (oObjectList.DAL_Load(null, oModule.ModuleID))
        //        {
        //            oModule.ModuleObjects = new ModuleObjectCollection();

        //            foreach (ModuleObject oObject in oObjectList)
        //            {
        //                oModule.ModuleObjects.Add(oObject);

        //                ModuleObjectMemberCollection oMemberList = new ModuleObjectMemberCollection();
        //                oMemberList.DAL_Load();

        //                ModuleObjectMemberGroupCollection oGroupAccessList = new ModuleObjectMemberGroupCollection();
        //                if (oGroupAccessList.DAL_LoadOrderByGroupName(null, oModule.ModuleID, oObject.ModuleObjectID, null, oGroup.GroupID))
        //                {
        //                    string sGroupAccess = string.Empty;
        //                    for (int i = 0; i < oGroupAccessList.Count; i++)
        //                    {
        //                        sGroupAccess += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oGroupAccessList[i].MemberName.ToLower()); ;
        //                        if (i < oGroupAccessList.Count - 1)
        //                            sGroupAccess += ", ";
        //                    }

        //                    if (sGroupAccess.Length > 0)
        //                    {
        //                        bHaveAccess = true;
        //                        sb.Append("<tr class='GridRow_Office2007'>");
        //                        sb.Append(String.Format("<td class='textfield'>{0}</td>", oModule.ModuleName));
        //                        sb.Append(String.Format("<td class='textfield'>{0}</td>", oObject.ObjectName));
        //                        sb.Append(String.Format("<td class='textfield'>{0}</td>", sGroupAccess));
        //                        sb.Append("</tr>");
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    if (!bHaveAccess)
        //    {
        //        sb.Append("<tr class='GridRow_Office2007'>");
        //        sb.Append("<td align='center' colspan='3'>No Access</td>");
        //        sb.Append("</tr>");
        //    }

        //    sb.Append("</table>");
        //    sb.Append("<br />");

        //}

        ////sb.Append("<td class='GridHeader_Office2007' colspan='2'>Import</td>");
        ////sb.Append("<td class='GridHeader_Office2007' colspan='2'>Generate eStatement</td>");
        ////sb.Append("<td class='GridHeader_Office2007' colspan='2'>Generate Paper</td>");
        ////sb.Append("<td class='GridHeader_Office2007' colspan='3'>Processing eStatement</td>");
        ////sb.Append("<td class='GridHeader_Office2007' colspan='3'>Processing Paper</td>");
        ////sb.Append("</tr><tr>");
        ////sb.Append("<td class='GridHeader_Office2007'>eStatement</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Paper</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Success</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Failed</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Personal</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Corporate</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Personal</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Corporate</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Personal</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Corporate</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Suppress</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Personal</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Corporate</td>");
        ////sb.Append("<td class='GridHeader_Office2007'>Suppress</td>");
        ////sb.Append("</tr>");

        ////foreach (DataRow dr in dt.Rows)
        ////{
        ////    sb.Append("<tr class='GridRow_Office2007'>");
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:dd-MMM-yyyy HH:mm:ss}</td>", dr["PROCESS_START_DATE"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0}</td>", dr["FILE_LIST"].ToString().Replace("<br />", ",")));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["TOTAL_NON_HC"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["TOTAL_HC"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["VALID_STATEMENT"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["INVALID_STATEMENT"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["GENERATE_ESTATEMENT_PERSONAL"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["GENERATE_ESTATEMENT_CORPORATE"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["GENERATE_PAPER_PERSONAL"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>({0:#,0} + {1:#,0})</td>", dr["GENERATE_ESTATEMENT_CORPORATE"], Convert.ToInt32(dr["GENERATE_PAPER_CORPORATE"]) - Convert.ToInt32(dr["GENERATE_ESTATEMENT_CORPORATE"])));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["PROCESSING_ESTATEMENT_PERSONAL"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["PROCESSING_ESTATEMENT_CORPORATE"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["ESTATEMENT_SUPPRESS"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["PROCESSING_PAPER_PERSONAL"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["PROCESSING_PAPER_CORPORATE"]));
        ////    sb.Append(String.Format("<td align='center' class='textfield'>{0:#,0}</td>", dr["PAPER_SUPPRESS"]));
        ////    sb.Append("</tr>");
        ////}

        //Response.Clear();
        //Response.ContentType = "application/vnd.ms-excel";
        //Response.AppendHeader("content-disposition", "attachment;filename=GroupMatrixReport.xls");
        //Response.Write(sb.ToString());
        //Response.End();
        #endregion
    }
    #endregion

    #region Grid Events

    protected void rgridGroupList_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        string sRefNumber = RefNumber;
        try
        {
            rgridGroupList.DataSource = GetGroupList();
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
    }

    protected void rgridGroupList_ItemCommand(object source, GridCommandEventArgs e)
    {
        string sRefNumber = RefNumber;
        string sRemark = string.Empty;
        short iStatus = 0;
        string sDescription = string.Empty;
        string sPreviousDetail = "<xml />";
        Group oGroup = new Group();
        Group oLastGroupBeforeUpdate = new Group();

        try
        {
            if (e.CommandName == "Member")
            {
                int iGroupID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupID"]);
                Response.Redirect(string.Format("UserList.aspx?GroupID={0}", iGroupID));
            }
            if (e.CommandName == "Insert")
            {
                for (int i = 0; i < rgridGroupList.Items.Count; i++)
                {
                    rgridGroupList.Items[i].Edit = false;
                }

                e.Canceled = true;
                System.Collections.Specialized.ListDictionary ldNewValues = new System.Collections.Specialized.ListDictionary();
                ldNewValues["GroupID"] = 0;
                ldNewValues["IsActive"] = true;
                e.Item.OwnerTableView.InsertItem(ldNewValues);
            }

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                for (int i = 0; i < rgridGroupList.Items.Count; i++)
                {
                    rgridGroupList.Items[i].Edit = false;
                }

                e.Canceled = true;
                System.Collections.Specialized.ListDictionary ldNewValues = new System.Collections.Specialized.ListDictionary();
                ldNewValues["GroupID"] = 0;
                ldNewValues["IsActive"] = true;
                e.Item.OwnerTableView.InsertItem(ldNewValues);
            }
            else if (e.CommandName == RadGrid.UpdateCommandName
                || e.CommandName == RadGrid.PerformInsertCommandName)
            {
                sDescription = "Update Group ";
                Label lblGroupID = (Label)e.Item.FindControl("lblGroupID");
                TextBox txtGroupName = (TextBox)e.Item.FindControl("txtGroupName");
                TextBox txtGroupDescr = (TextBox)e.Item.FindControl("txtGroupDescr");
                CheckBox cbIsActive = (CheckBox)e.Item.FindControl("cbIsActive");
                Group oCheckGroup = new Group();
                object iGroupID = null;
                ApprovalLog oCheckExistingContent = new ApprovalLog();
                if (Convert.ToInt32(lblGroupID.Text) > 0)
                {
                    oGroup.DAL_Load(Convert.ToInt32(lblGroupID.Text));
                }

                oGroup.GroupName = txtGroupName.Text.Trim();
                oGroup.GroupDescr = txtGroupDescr.Text.Trim();
                oGroup.IsActive = cbIsActive.Checked;

                if (Convert.ToInt32(lblGroupID.Text) > 0)
                    iGroupID = Convert.ToInt32(lblGroupID.Text);

                //*** Check Duplication ***//
                if (oCheckGroup.DAL_LoadByGroupName(oGroup.GroupName, iGroupID))
                    Alert("Duplicate group name in Database. Please change the group name");
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("Group", "GroupName", oGroup.GroupName, (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE, null))
                {
                    //*** Duplicate group name detected in ApprovalLog***//
                    Alert("Duplicate group name in Approval Log. Please change the group name");
                }
                else if (oCheckExistingContent.DAL_LoadToGetDuplicateContent("Group", "GroupName", oGroup.GroupName, (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE, null))
                {
                    //*** Duplicate group name detected in ApprovalLog***//
                    Alert("Duplicate group name in Approval Log. Please change the group name");
                }
                else
                {
                    if (e.CommandName == RadGrid.UpdateCommandName)
                    {
                        oGroup.GroupID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupID"]);
                        oGroup.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                        oGroup.UpdateDate = DateTime.Now;
                        
                        oLastGroupBeforeUpdate.DAL_Load(Convert.ToInt32(lblGroupID.Text));
                        ApprovalLog oApprovalLog = new ApprovalLog()
                        {
                            RefID = Convert.ToInt32(oGroup.GroupID),
                            ModuleObjectMemberID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE,
                            ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING,
                            Detail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oGroup),
                            PreviousDetail = sPreviousDetail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oLastGroupBeforeUpdate)
                        };

                        iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING, ref sRemark));

                        if (iStatus == 0)
                        {
                            sDescription += " not successful CODE:" + sRefNumber;
                        }
                        else
                        {
                            PFSCommon.ClearAccessRight();

                            sDescription += "data has been submitted for approval process";
                            BindGrid();
                        }

                        Alert(sDescription);
                    }
                    else if (e.CommandName == RadGrid.PerformInsertCommandName)
                    {
                        sDescription = "Create Group ";
                        oGroup.GroupID = -1;
                        oGroup.CreateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                        oGroup.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                        oGroup.CreateDate = DateTime.Now;
                        oGroup.UpdateDate = DateTime.Now;
                        oGroup.IsActive = cbIsActive.Checked;

                        ApprovalLog oApprovalLog = new ApprovalLog()
                        {
                            RefID = Convert.ToInt32(oGroup.GroupID),
                            ModuleObjectMemberID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE,
                            ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING,
                            Detail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oGroup),
                            PreviousDetail = sPreviousDetail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oGroup)
                        };

                        iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING, ref sRemark));

                        if (iStatus == 0)
                        {
                            sDescription += "not successful CODE:" + sRefNumber;
                        }
                        else
                        {
                            PFSCommon.ClearAccessRight();

                            sDescription += "data has been submitted for approval process";
                            BindGrid();
                        }

                        Alert(sDescription);
                    }
                }

                e.Item.Edit = false;
                BindGrid();
            }
            else if (e.CommandName == RadGrid.EditCommandName)
            {
                rgridGroupList.MasterTableView.IsItemInserted = false;
            }
            else if (e.CommandName == RadGrid.DeleteCommandName)
            {
                sDescription = "Delete Group";

                oGroup.GroupID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupID"]);
                oGroup.DAL_LoadWithTotalUser();

                if (oGroup.TotalUser > 0)
                {
                    sDescription = "Delete Group is not successful. Please remove users in the group before delete it";
                    Alert(sDescription);
                }
                else
                {
                    ApprovalLog oApprovalLog = new ApprovalLog()
                    {
                        RefID = Convert.ToInt32(oGroup.GroupID),
                        ModuleObjectMemberID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_DELETE,
                        ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING,
                        Detail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oGroup),
                        PreviousDetail = sPreviousDetail = PFSXMLTools.SerializeObjectUsingUnicode<Group>(oGroup)
                    };

                    iStatus = Convert.ToInt16(Approval.UpdateApprovalLog(oGroup, oApprovalLog, SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING, ref sRemark));

                    if (iStatus == 0)
                    {
                        sDescription = "Delete Group not successful CODE:" + sRefNumber;
                        Alert(sDescription);
                    }
                    else
                    {
                        BindGrid();
                    }
                }
            }
            else if (e.CommandName == "AccessRight")
            {
                int iGroupID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupID"]);
                Response.Redirect(string.Format("AccessRight.aspx?GroupID={0}", iGroupID));
            }
            else if (e.CommandName == "Cancel")
            {
                //GridPagerItem pagerItem = (GridPagerItem)rgridGroupList.MasterTableView.GetItems(GridItemType.Pager)[0];
                //pagerItem.Enabled = false;
            }
            else if (e.CommandName == RadGrid.ExportToExcelCommandName)
            {
                rptList.DataSource = GetGroupList();
                rptList.DataBind();

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=SO - GroupList.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
                litCss.RenderControl(oHtmlTextWriter);
                rptList.RenderControl(oHtmlTextWriter);
                Response.Write(oStringWriter.ToString());
                Response.End();
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
        finally
        {
            if (e.CommandName == RadGrid.PerformInsertCommandName ||
                e.CommandName == RadGrid.UpdateCommandName ||
                e.CommandName == RadGrid.DeleteCommandName)
            {
                int iModuleObjectMemberID = 0;

                if (e.CommandName == RadGrid.PerformInsertCommandName)
                    iModuleObjectMemberID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE;
                else if (e.CommandName == RadGrid.UpdateCommandName)
                    iModuleObjectMemberID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE;
                else if (e.CommandName == RadGrid.DeleteCommandName)
                    iModuleObjectMemberID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_GRP_DELETE;

                Security.WriteUserLog(sRefNumber, sDescription, oGroup, iStatus, iModuleObjectMemberID, sPreviousDetail);
            }

            //*** Dispose Any Object ***//
            oGroup = null;
            sDescription = null;
            sRefNumber = null;
        }
    }

    protected void rgridGroupList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        string sRefNumber = RefNumber;

        try
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                ImageButton btnEdit = (ImageButton)e.Item.FindControl("btnEdit");
                ImageButton btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
                ImageButton btnAccessRight = (ImageButton)e.Item.FindControl("btnAccessRight");
                Label lblNeedApproval = (Label)e.Item.FindControl("lblNeedApproval");

                btnAccessRight.Visible = (Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS.ToString()) &&
                    !((CheckBox)e.Item.FindControl("cbIsNeedApproval")).Checked);
                btnDelete.Visible = (Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_GRP_DELETE.ToString()) &&
                    !((CheckBox)e.Item.FindControl("cbIsNeedApproval")).Checked);
                btnEdit.Visible = (Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE.ToString()) &&
                    !((CheckBox)e.Item.FindControl("cbIsNeedApproval")).Checked);
                lblNeedApproval.Visible = (((CheckBox)e.Item.FindControl("cbIsNeedApproval")).Checked);

                //Can't delete own group
                int iGroupID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["GroupID"]);
                UserGroupCollection oUserGroupList = ((CustomPrincipal)HttpContext.Current.User).User.UserGroupList;

                foreach (UserGroup oUserGroupItem in oUserGroupList)
                {
                    if (iGroupID == oUserGroupItem.GroupID)
                    {
                        btnDelete.Visible = false;
                        break;
                    }
                }
            }
            else if (e.Item.ItemType == GridItemType.CommandItem)
            {
                RadToolBar RadTBGroup = (RadToolBar)e.Item.FindControl("RadTBGroup");
                RadTBGroup.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_GRP_CREATE.ToString());
            }
            else if (e.Item.ItemType == GridItemType.EditItem)
            {
                ImageButton btnAccessRight = (ImageButton)e.Item.FindControl("btnAccessRight");
                btnAccessRight.Visible = false;
            }

            if (e.Item is Telerik.Web.UI.GridCommandItem)
            {
                //Change RadToolBarButton Text
                ((Telerik.Web.UI.RadToolBarButton)e.Item.Controls[0].Controls[1].Controls[0]).Text = "Create New Group";
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, System.Reflection.MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
    }
    #endregion

    #region Method
    private GroupCollection GetGroupList()
    {
        GroupCollection oGroupList = null;
        try
        {
            string sKeyword = null;
            object bIsActive = null;

            if (!string.IsNullOrWhiteSpace(txtFilterKeywords.Text)) sKeyword = txtFilterKeywords.Text;
            if (ddlStatus.SelectedValue != "-1") bIsActive = Convert.ToBoolean(ddlStatus.SelectedValue);

            oGroupList = new GroupCollection();
            oGroupList.DAL_LoadWithTotalUser(sKeyword, bIsActive, null, null, null, null, null, null, null);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return oGroupList;
    }
    private void BindGrid()
    {
        try
        {
            rgridGroupList.Rebind();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    #endregion
}
