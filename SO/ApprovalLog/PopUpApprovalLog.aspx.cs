using System;
using System.Reflection;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using PSC.BusinessLogicLayer;

namespace SE.WebUI
{
    public partial class PopUpApprovalLog : PFSBasePage
    {
        #region Region: Query String
        private string ListDetailDescription
        {
            get { return Request.QueryString["desc"] == null ? null : Convert.ToString(Request.QueryString["desc"]); }
        }
        #endregion

        #region Region: Properties
        string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
        #endregion

        #region Region: Events
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                rptList.DataSource = GetList();
                rptList.DataBind();

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=PendingCustomerRegistrationReport.xls");
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
        protected void rgridList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgridList.DataSource = GetList();
            }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        #endregion

        #region Region: Data Access
        private ApprovalLogCollection GetList()
        {
            ApprovalLogCollection oApprovalLogCollection = new ApprovalLogCollection();

            try
            {
                switch (ListDetailDescription)
                {
                    case "Pending":
                        oApprovalLogCollection.DAL_LoadPendingByUser();
                        break;
                    case "Approved":
                        oApprovalLogCollection.DAL_LoadApproved();
                        break;
                    case "Rejected":
                        oApprovalLogCollection.DAL_LoadRejected();
                        break;
                    case "NeedApproval":
                        oApprovalLogCollection.DAL_LoadNeedApproval();
                        break;
                    case "ApprovedByUser":
                        oApprovalLogCollection.DAL_LoadApprovedByUser();
                        break;
                    case "RejectedByUser":
                        oApprovalLogCollection.DAL_LoadRejectedByUser();
                        break;
                    default:
                        oApprovalLogCollection.DAL_LoadWithCreateByName(null, null, null, null, null, null, null, null, null, null, null, 52);
                        break;
                }


                return oApprovalLogCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}