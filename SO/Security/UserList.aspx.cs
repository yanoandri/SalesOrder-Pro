using System;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using SO.BusinessLogicLayer.Enumeration;
using Telerik.Web.UI;

public partial class Security_UserList : PFSBasePage
{
    #region Session
    private UserCollection sessUserCollection
    {
        get { return Session["sessUserCollection"] == null ? null : (UserCollection)Session["sessUserCollection"]; }
        set { Session["sessUserCollection"] = value; }
    }
    #endregion

    #region Properties
    #region QueryString

    private int qs_iGroupID
    {
        get { return Request.QueryString["GroupID"] == null ? -1 : Convert.ToInt32(Request.QueryString["GroupID"]); }
    }
    #endregion

    string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
    #endregion

    #region Method
    private void BindGrid()
    {
        try
        {
            sessUserCollection = null;
            rgridUserList.Rebind();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    private UserCollection GetUserList()
    {
        UserCollection oUserList = new UserCollection();
        try
        {
            if (sessUserCollection == null || sessUserCollection.Count == 0)
            {
                string sKeyword = null;
                string sGroups = null;
                object bIsActive = null;

                if (!string.IsNullOrWhiteSpace(txtFilterKeywords.Text)) sKeyword = txtFilterKeywords.Text;
                if (ddlStatus.SelectedValue != "-1") bIsActive = Convert.ToBoolean(ddlStatus.SelectedValue);
                if (ddlGroup.SelectedValue != "-1") sGroups = Convert.ToString(ddlGroup.SelectedValue);

                if (qs_iGroupID > 0)
                {
                    ddlGroup.Visible = lblGroup.Visible = btnCreateNewUser.Visible = btnExportToExcel.Visible = false;
                    oUserList.DAL_Load(sKeyword, qs_iGroupID.ToString(), bIsActive);
                }
                else
                {
                    oUserList.DAL_Load(sKeyword, sGroups, bIsActive);
                }

                sessUserCollection = oUserList;
            }
            else
            {
                oUserList = sessUserCollection;
            }

            return oUserList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Event
    protected void Page_Load(object sender, EventArgs e)
    {
        string sRefNumber = RefNumber;
        try
        {
            if (!Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_USR_READ.ToString()))
                NoPermission();
            btnCreateNewUser.Visible = Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_USR_CREATE.ToString());

            if (!IsPostBack)
            {
                sessUserCollection = null;
                BindDdlGroup();

                rgridUserList.Rebind();

            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, System.Reflection.MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
        finally
        {
            sRefNumber = null;
        }
    }
    protected void rgridUserList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        try
        {
            rgridUserList.DataSource = GetUserList();
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    protected void rgridUserList_ItemCommand(object source, GridCommandEventArgs e)
    {
        User oUser = new User();
        string sRefNumber = RefNumber;
        string sRemark = string.Empty;
        string sDescription = "Delete User";
        short iStatus = 0;

        try
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                Response.Redirect("UserInput.aspx?UserID=-1");
            }
            else if (e.CommandName == RadGrid.EditCommandName)
            {
                Response.Redirect(string.Format("UserInput.aspx?UserID={0}", Convert.ToInt32(rgridUserList.MasterTableView.DataKeyValues[e.Item.ItemIndex]["UserID"])));
            }
            else if (e.CommandName == RadGrid.DeleteCommandName)
            {
                oUser.DAL_LoadWithChild(Convert.ToInt32(rgridUserList.MasterTableView.DataKeyValues[e.Item.ItemIndex]["UserID"]));

                if (PFSHelper.BusinessLogicLayer.User.IsHaveRelation(oUser.UserID))
                {
                    sDescription += " failed, this user having some relation to another data";
                    Alert(sDescription);
                    return;
                }

                oUser.IsNeedApproval = true;
                SO.BusinessLogicLayer.ApprovalLog oApprovalLog = new SO.BusinessLogicLayer.ApprovalLog()
                {
                    RefID = Convert.ToInt32(oUser.UserID),
                    ModuleObjectMemberID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_USR_DELETE,
                    ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING,
                    CreateDate = DateTime.Now,
                    CreateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID,
                    PreviousDetail = PFSXMLTools.SerializeObjectUsingUnicode<User>(oUser),
                    Detail = PFSXMLTools.SerializeObjectUsingUnicode<User>(oUser)
                };

                iStatus = Convert.ToInt16(SO.BusinessLogicLayer.Approval.UpdateApprovalLog(oUser, oApprovalLog, SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.PENDING, ref sRemark));

                if (iStatus == 0)
                {
                    sDescription = "Delete User not successful CODE:" + sRefNumber;
                }
                else
                {
                    BindGrid();
                }
            }
            else if (e.CommandName == RadGrid.ExportToExcelCommandName)
            {
                rptList.DataSource = GetUserList();
                rptList.DataBind();

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Statement Engine - UserList.xls");
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
            if (Ex is System.Threading.ThreadAbortException)
            {
                //** Do Nothing, Just Bypass this exception **//
            }
            else
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        finally
        {
            if (e.CommandName == RadGrid.DeleteCommandName)
                Security.WriteUserLog(sRefNumber, sDescription, oUser, iStatus, (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.PFSModuleObjectMember.SCR_USR_DELETE);

            sRefNumber = null;
        }
    }
    protected void rgridUserList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        string sRefNumber = PFSCommon.GenerateRefNumber();

        try
        {
            if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
            {
                ImageButton btnEdit = (ImageButton)e.Item.FindControl("btnEdit");
                ImageButton btnDelete = (ImageButton)e.Item.FindControl("btnDelete");
                HyperLink hlUserName = (HyperLink)e.Item.FindControl("hlUserName");
                Label lblNeedApproval = (Label)e.Item.FindControl("lblNeedApproval");

                btnEdit.Visible = (Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE.ToString()) &&
                    !((CheckBox)e.Item.FindControl("cbIsNeedApproval")).Checked);
                btnDelete.Visible = (Security.CheckSecurity(SOEnumeration.PFSModuleObjectMember.SCR_USR_DELETE.ToString()) &&
                    !((CheckBox)e.Item.FindControl("cbIsNeedApproval")).Checked);
                lblNeedApproval.Visible = (((CheckBox)e.Item.FindControl("cbIsNeedApproval")).Checked);

                //Can't delete own user
                int iUserID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserID"]);
                if (iUserID == ((CustomPrincipal)HttpContext.Current.User).User.UserID
                    || qs_iGroupID > 0)
                {
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

                hlUserName.NavigateUrl = "~/Security/UserDetail.aspx?UserID=" + iUserID;

                Label lblLastAccess = (Label)e.Item.FindControl("lblLastAccess");
                DateTime dtLastAccess = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "LastAccess"));
                if (dtLastAccess.Year == 1900) lblLastAccess.Text = "-";
            }
            else if (e.Item.ItemType == GridItemType.CommandItem)
            {
                RadToolBar RadTBUser = (RadToolBar)e.Item.FindControl("RadTBUser");
                RadTBUser.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_USR_CREATE.ToString());
            }

            if (e.Item is Telerik.Web.UI.GridCommandItem)
            {
                //Change RadToolBarButton Text
                ((Telerik.Web.UI.RadToolBarButton)e.Item.Controls[0].Controls[1].Controls[0]).Text = "Create New User";
            }
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
        }
    }
    protected void btnFilterSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGrid();
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
            Response.Redirect("UserList.aspx");
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            rptList.DataSource = GetUserList();
            rptList.DataBind();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=UserList.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
            litCss.RenderControl(oHtmlTextWriter);
            rptList.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }
        catch (Exception Ex)
        {
            ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
            Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
        }
    }
    #endregion

    #region Data Binding

    private void BindDdlGroup()
    {
        try
        {
            ddlGroup.DataSource = null;

            GroupCollection oGroupCollection = new GroupCollection();
            oGroupCollection.DAL_Load(null, true, null, null, null, null, null, null, null);
            oGroupCollection.Sort(GroupCollection.GroupFields.GroupName, true);

            ddlGroup.DataSource = oGroupCollection;
            ddlGroup.DataTextField = "GroupName";
            ddlGroup.DataValueField = "GroupID";
            ddlGroup.DataBind();

            ListItem li = new ListItem(STRING_SELECT_ONE, "-1");
            ddlGroup.Items.Insert(0, li);
            ddlGroup.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}
