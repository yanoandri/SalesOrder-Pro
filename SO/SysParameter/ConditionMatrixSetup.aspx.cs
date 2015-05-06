using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using PSC.BusinessLogicLayer;
using PSC.BusinessLogicLayer.Enumeration;
using Telerik.Web.UI;

namespace PSC.Web.UI.SysParameter
{
    public partial class ConditionMatrixSetup : PFSBasePage
    {
        #region Session
        private VulnerableCheckingCriteriaCollection sessVulnerableCheckingCriteriaCollection
        {
            get { return Session["sessVulnerableCheckingCriteriaCollection"] == null ? new VulnerableCheckingCriteriaCollection() : (VulnerableCheckingCriteriaCollection)Session["sessVulnerableCheckingCriteriaCollection"]; }
            set { Session["sessVulnerableCheckingCriteriaCollection"] = value; }
        }
        private CustomerRatingVsProductRatingCollection sessCustomerRatingVsProductRatingCollection
        {
            get { return Session["sessCustomerRatingVsProductRatingCollection"] == null ? new CustomerRatingVsProductRatingCollection() : (CustomerRatingVsProductRatingCollection)Session["sessCustomerRatingVsProductRatingCollection"]; }
            set { Session["sessCustomerRatingVsProductRatingCollection"] = value; }
        }
        private ImportantNotesMatrixCollection sessImportantNotesMatrixCollection
        {
            get { return Session["sessImportantNotesMatrixCollection"] == null ? new ImportantNotesMatrixCollection() : (ImportantNotesMatrixCollection)Session["sessImportantNotesMatrixCollection"]; }
            set { Session["sessImportantNotesMatrixCollection"] = value; }
        }
        private ExceptionRequiredMatrixCollection sessExceptionRequiredMatrixCollection
        {
            get { return Session["sessExceptionRequiredMatrixCollection"] == null ? new ExceptionRequiredMatrixCollection() : (ExceptionRequiredMatrixCollection)Session["sessExceptionRequiredMatrixCollection"]; }
            set { Session["sessExceptionRequiredMatrixCollection"] = value; }
        }
        private ProfileMismatchMatrixCollection sessProfileMismatchMatrixCollection
        {
            get { return Session["sessProfileMismatchMatrixCollection"] == null ? new ProfileMismatchMatrixCollection() : (ProfileMismatchMatrixCollection)Session["sessProfileMismatchMatrixCollection"]; }
            set { Session["sessProfileMismatchMatrixCollection"] = value; }
        }
        #endregion

        #region Properties
        private int vsLastIDExceptionRequired
        {
            get { return ViewState["vsLastIDExceptionRequired"] == null ? -1 : (int)ViewState["vsLastIDExceptionRequired"]; }
            set { ViewState["vsLastIDExceptionRequired"] = value; }
        }
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                if (!Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.PRE_CON_MATRIX_READ.ToString()))
                    NoPermission();
                btnSave.Visible = Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.PRE_CON_MATRIX_UPDATE.ToString());

                if (!IsPostBack)
                {
                    sessVulnerableCheckingCriteriaCollection = null;
                    sessCustomerRatingVsProductRatingCollection = null;
                    sessExceptionRequiredMatrixCollection = null;
                    sessImportantNotesMatrixCollection = null;
                    sessProfileMismatchMatrixCollection = null;
                    BindDdlEducationBackground();
                    ViewConditionAndMatrixSetup();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }

        }
        protected void btnCreateNewExceptionRequiredMatrix_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rgridExceptionRequiredMatrixList.Items.Count; i++)
            {
                rgridExceptionRequiredMatrixList.Items[i].Edit = false;
            }

            System.Collections.Specialized.ListDictionary ldNewValues = new System.Collections.Specialized.ListDictionary();
            ldNewValues["ExceptionRequiredMatrixID"] = 0;
            rgridExceptionRequiredMatrixList.MasterTableView.InsertItem(ldNewValues);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                int iStatusVulnerableCheckingCriteriaCollection = 0;
                int iStatusImportantNotesMatrixCollection = 0;
                int iStatusCustomerRatingVsProductRatingCollection = 0;
                int iStatusExceptionRequiredMatrix = 0;
                int iStatusProfileMismatchMatrix = 0;

                if (Convert.ToInt32(tbAge1To.Text) < Convert.ToInt32(tbAge1From.Text)) {
                    Alert("Age (1) at Vulnerable Checking Criteria Matrix: Age To may not lower than Age From");
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbAge2To.Text) 
                    || Convert.ToInt32(tbAge2To.Text) == 0)
                {
                }
                else {
                    if (Convert.ToInt32(tbAge2To.Text) < Convert.ToInt32(tbAge2From.Text))
                    {
                        Alert("Age (2) at Vulnerable Checking Criteria Matrix: Age To may not lower than Age From");
                        return;
                    }   
                }


                #region VulnerableCheckingCriteria
                for (int i = 0; i < sessVulnerableCheckingCriteriaCollection.Count; i++)
                {
                    if (sessVulnerableCheckingCriteriaCollection[i].VulnerableCheckingCriteriaID == (int)PSCEnumeration.ConditionMatrixSetupVulnerableCheckingCriteria.AGE1)
                    {
                        int iMaxValue;
                        if (PFSCommon.IsNumeric(tbAge1To.Text))
                        {
                            iMaxValue = Convert.ToInt32(tbAge1To.Text);
                        }
                        else
                        {
                            iMaxValue = 0;
                        }
                        sessVulnerableCheckingCriteriaCollection[i].Value = Convert.ToInt32(tbAge1From.Text);
                        sessVulnerableCheckingCriteriaCollection[i].MaxValue = iMaxValue;
                        sessVulnerableCheckingCriteriaCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessVulnerableCheckingCriteriaCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessVulnerableCheckingCriteriaCollection[i].VulnerableCheckingCriteriaID == (int)PSCEnumeration.ConditionMatrixSetupVulnerableCheckingCriteria.AGE2)
                    {
                        int iMaxValue;
                        if (PFSCommon.IsNumeric(tbAge2To.Text))
                        {
                            iMaxValue = Convert.ToInt32(tbAge2To.Text);
                        }
                        else
                        {
                            iMaxValue = 0;
                        }
                        sessVulnerableCheckingCriteriaCollection[i].Value = Convert.ToInt32(tbAge2From.Text);
                        sessVulnerableCheckingCriteriaCollection[i].MaxValue = iMaxValue;
                        sessVulnerableCheckingCriteriaCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessVulnerableCheckingCriteriaCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessVulnerableCheckingCriteriaCollection[i].VulnerableCheckingCriteriaID == (int)PSCEnumeration.ConditionMatrixSetupVulnerableCheckingCriteria.EDUCATION_BACKGROUND)
                    {
                        if (ddlEducationBackground.SelectedValue != "-1")
                        {
                            sessVulnerableCheckingCriteriaCollection[i].Value = Convert.ToInt32(ddlEducationBackground.SelectedValue);
                            sessVulnerableCheckingCriteriaCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                            sessVulnerableCheckingCriteriaCollection[i].UpdateDate = DateTime.Now;
                        }
                    }
                }
                #endregion

                #region ImportantNotesMatrix
                for (int i = 0; i < sessImportantNotesMatrixCollection.Count; i++)
                {
                    if (sessImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_1.ToString())
                    {
                        sessImportantNotesMatrixCollection[i].IsP1Checked = cbImportantNotesMatrixParam1P1.Checked;
                        sessImportantNotesMatrixCollection[i].IsP2Checked = cbImportantNotesMatrixParam1P2.Checked;
                        sessImportantNotesMatrixCollection[i].IsP3Checked = cbImportantNotesMatrixParam1P3.Checked;
                        sessImportantNotesMatrixCollection[i].IsP4Checked = cbImportantNotesMatrixParam1P4.Checked;
                        sessImportantNotesMatrixCollection[i].IsP5Checked = cbImportantNotesMatrixParam1P5.Checked;
                        sessImportantNotesMatrixCollection[i].IsMismatchChecked = cbImportantNotesMatrixParam1Mismatch.Checked;
                        sessImportantNotesMatrixCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessImportantNotesMatrixCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_2.ToString())
                    {
                        sessImportantNotesMatrixCollection[i].IsP1Checked = cbImportantNotesMatrixParam2P1.Checked;
                        sessImportantNotesMatrixCollection[i].IsP2Checked = cbImportantNotesMatrixParam2P2.Checked;
                        sessImportantNotesMatrixCollection[i].IsP3Checked = cbImportantNotesMatrixParam2P3.Checked;
                        sessImportantNotesMatrixCollection[i].IsP4Checked = cbImportantNotesMatrixParam2P4.Checked;
                        sessImportantNotesMatrixCollection[i].IsP5Checked = cbImportantNotesMatrixParam2P5.Checked;
                        sessImportantNotesMatrixCollection[i].IsMismatchChecked = cbImportantNotesMatrixParam2Mismatch.Checked;
                        sessImportantNotesMatrixCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessImportantNotesMatrixCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_3.ToString())
                    {
                        sessImportantNotesMatrixCollection[i].IsP1Checked = cbImportantNotesMatrixParam3P1.Checked;
                        sessImportantNotesMatrixCollection[i].IsP2Checked = cbImportantNotesMatrixParam3P2.Checked;
                        sessImportantNotesMatrixCollection[i].IsP3Checked = cbImportantNotesMatrixParam3P3.Checked;
                        sessImportantNotesMatrixCollection[i].IsP4Checked = cbImportantNotesMatrixParam3P4.Checked;
                        sessImportantNotesMatrixCollection[i].IsP5Checked = cbImportantNotesMatrixParam3P5.Checked;
                        sessImportantNotesMatrixCollection[i].IsMismatchChecked = cbImportantNotesMatrixParam3MisMatch.Checked;
                        sessImportantNotesMatrixCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessImportantNotesMatrixCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_4.ToString())
                    {
                        sessImportantNotesMatrixCollection[i].IsP1Checked = cbImportantNotesMatrixParam4P1.Checked;
                        sessImportantNotesMatrixCollection[i].IsP2Checked = cbImportantNotesMatrixParam4P2.Checked;
                        sessImportantNotesMatrixCollection[i].IsP3Checked = cbImportantNotesMatrixParam4P3.Checked;
                        sessImportantNotesMatrixCollection[i].IsP4Checked = cbImportantNotesMatrixParam4P4.Checked;
                        sessImportantNotesMatrixCollection[i].IsP5Checked = cbImportantNotesMatrixParam4P5.Checked;
                        sessImportantNotesMatrixCollection[i].IsMismatchChecked = cbImportantNotesMatrixParam4Mismatch.Checked;
                        sessImportantNotesMatrixCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessImportantNotesMatrixCollection[i].UpdateDate = DateTime.Now;
                    }
                }
                #endregion

                #region CustomerRatingVsProductRating
                for (int i = 0; i < sessCustomerRatingVsProductRatingCollection.Count; i++)
                {
                    if (sessCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C1)
                    {
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException = GenerateStringRatingC1WithoutException();
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException = GenerateStringRatingC1WithException();
                        sessCustomerRatingVsProductRatingCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessCustomerRatingVsProductRatingCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C2)
                    {
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException = GenerateStringRatingC2WithoutException();
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException = GenerateStringRatingC2WithException();
                        sessCustomerRatingVsProductRatingCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessCustomerRatingVsProductRatingCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C3)
                    {
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException = GenerateStringRatingC3WithoutException();
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException = GenerateStringRatingC3WithException();
                        sessCustomerRatingVsProductRatingCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessCustomerRatingVsProductRatingCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C4)
                    {
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException = GenerateStringRatingC4WithoutException();
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException = GenerateStringRatingC4WithException();
                        sessCustomerRatingVsProductRatingCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessCustomerRatingVsProductRatingCollection[i].UpdateDate = DateTime.Now;
                    }
                    if (sessCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C5)
                    {
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException = GenerateStringRatingC5WithoutException();
                        sessCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException = GenerateStringRatingC5WithException();
                        sessCustomerRatingVsProductRatingCollection[i].UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                        sessCustomerRatingVsProductRatingCollection[i].UpdateDate = DateTime.Now;
                    }
                }
                #endregion

                #region ProfileMismatchMatrix
                foreach (GridItem oGridItem in rgridProfileMismatchMatrixList.MasterTableView.Items)
                {
                    DropDownList ddlOperatorNo = (DropDownList)oGridItem.FindControl("ddlOperatorNo");
                    RadNumericTextBox tbValueNoPercent = (RadNumericTextBox)oGridItem.FindControl("tbValueNoPercent");
                    DropDownList ddlOperatorYes = oGridItem.FindControl("ddlOperatorYes") as DropDownList;
                    RadNumericTextBox tbValueYesPercent = (RadNumericTextBox)oGridItem.FindControl("tbValueYesPercent");

                    int iAssetClassID = Convert.ToInt32(oGridItem.OwnerTableView.DataKeyValues[oGridItem.ItemIndex]["AssetClassID"]);
                    ProfileMismatchMatrix oProfileMismatchMatrix = new ProfileMismatchMatrix();

                    oProfileMismatchMatrix.AssetClassID = iAssetClassID;
                    oProfileMismatchMatrix.OperatorIDNo = Convert.ToInt32(ddlOperatorNo.SelectedValue);
                    oProfileMismatchMatrix.OperatorIDYes = Convert.ToInt32(ddlOperatorYes.SelectedValue);
                    oProfileMismatchMatrix.ValueNoPercent = Convert.ToDouble(tbValueNoPercent.Text);
                    oProfileMismatchMatrix.ValueYesPercent = Convert.ToDouble(tbValueYesPercent.Text);
                    oProfileMismatchMatrix.UpdateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                    oProfileMismatchMatrix.IsActive = true;
                    oProfileMismatchMatrix.UpdateDate = DateTime.Now;

                    iStatusProfileMismatchMatrix = Convert.ToInt32(oProfileMismatchMatrix.DAL_UpdateByAssetClass());
                }
                #endregion

                #region Vulnerable Checking Criteria
                iStatusVulnerableCheckingCriteriaCollection = Convert.ToInt32(sessVulnerableCheckingCriteriaCollection.DAL_Update());

                #endregion

                #region Important Notes Matrix
                iStatusImportantNotesMatrixCollection = Convert.ToInt32(sessImportantNotesMatrixCollection.DAL_Update());
                #endregion

                #region Customer Rating Vs Product Rating
                iStatusCustomerRatingVsProductRatingCollection = Convert.ToInt32(sessCustomerRatingVsProductRatingCollection.DAL_Update());
                #endregion

                #region Exception Required Matrix
                string sDescription = string.Empty;
                iStatusExceptionRequiredMatrix = Convert.ToInt32(sessExceptionRequiredMatrixCollection.DAL_UpdateLikeParentChild());
                if (iStatusVulnerableCheckingCriteriaCollection == 0 &&
                    iStatusProfileMismatchMatrix == 0 && iStatusImportantNotesMatrixCollection == 0 && iStatusCustomerRatingVsProductRatingCollection == 0 &&
               iStatusExceptionRequiredMatrix == 0)
                {
                    sDescription += " Not successful save CODE:" + sRefNumber;
                }
                else
                {
                    sDescription += " successful save.";
                }
                #endregion
                Response.Write("<script>alert('" + sDescription + "'); location.href='ConditionMatrixSetup.aspx'</script>");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Home/Home.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        protected void cbRating5WithExceptionNotAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRating5WithExceptionNotAllowed.Checked == true)
            {
                cbRating5WithExceptionP1.Checked = false;
                cbRating5WithExceptionP1.Enabled = false;
                cbRating5WithExceptionP2.Checked = false;
                cbRating5WithExceptionP2.Enabled = false;
                cbRating5WithExceptionP3.Checked = false;
                cbRating5WithExceptionP3.Enabled = false;
                cbRating5WithExceptionP4.Checked = false;
                cbRating5WithExceptionP4.Enabled = false;
                cbRating5WithExceptionP5.Checked = false;
                cbRating5WithExceptionP5.Enabled = false;
            }
            else
            {
                cbRating5WithExceptionP1.Enabled = true;
                cbRating5WithExceptionP2.Enabled = true;
                cbRating5WithExceptionP3.Enabled = true;
                cbRating5WithExceptionP4.Enabled = true;
                cbRating5WithExceptionP5.Enabled = true;
            }
        }
        protected void cbRating4WithExceptionNotAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRating4WithExceptionNotAllowed.Checked == true)
            {
                cbRating4WithExceptionP1.Checked = false;
                cbRating4WithExceptionP1.Enabled = false;
                cbRating4WithExceptionP2.Checked = false;
                cbRating4WithExceptionP2.Enabled = false;
                cbRating4WithExceptionP3.Checked = false;
                cbRating4WithExceptionP3.Enabled = false;
                cbRating4WithExceptionP4.Checked = false;
                cbRating4WithExceptionP4.Enabled = false;
                cbRating4WithExceptionP5.Checked = false;
                cbRating4WithExceptionP5.Enabled = false;
            }
            else
            {
                cbRating4WithExceptionP1.Enabled = true;
                cbRating4WithExceptionP2.Enabled = true;
                cbRating4WithExceptionP3.Enabled = true;
                cbRating4WithExceptionP4.Enabled = true;
                cbRating4WithExceptionP5.Enabled = true;
            }
        }
        protected void cbRating3WithExceptionNotAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRating3WithExceptionNotAllowed.Checked == true)
            {
                cbRating3WithExceptionP1.Checked = false;
                cbRating3WithExceptionP1.Enabled = false;
                cbRating3WithExceptionP2.Checked = false;
                cbRating3WithExceptionP2.Enabled = false;
                cbRating3WithExceptionP3.Checked = false;
                cbRating3WithExceptionP3.Enabled = false;
                cbRating3WithExceptionP4.Checked = false;
                cbRating3WithExceptionP4.Enabled = false;
                cbRating3WithExceptionP5.Checked = false;
                cbRating3WithExceptionP5.Enabled = false;
            }
            else
            {
                cbRating3WithExceptionP1.Enabled = true;
                cbRating3WithExceptionP2.Enabled = true;
                cbRating3WithExceptionP3.Enabled = true;
                cbRating3WithExceptionP4.Enabled = true;
                cbRating3WithExceptionP5.Enabled = true;
            }
        }
        protected void cbRating2WithExceptionNotAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRating2WithExceptionNotAllowed.Checked == true)
            {
                cbRating2WithExceptionP1.Checked = false;
                cbRating2WithExceptionP1.Enabled = false;
                cbRating2WithExceptionP2.Checked = false;
                cbRating2WithExceptionP2.Enabled = false;
                cbRating2WithExceptionP3.Checked = false;
                cbRating2WithExceptionP3.Enabled = false;
                cbRating2WithExceptionP4.Checked = false;
                cbRating2WithExceptionP4.Enabled = false;
                cbRating2WithExceptionP5.Checked = false;
                cbRating2WithExceptionP5.Enabled = false;
            }
            else
            {
                cbRating2WithExceptionP1.Enabled = true;
                cbRating2WithExceptionP2.Enabled = true;
                cbRating2WithExceptionP3.Enabled = true;
                cbRating2WithExceptionP4.Enabled = true;
                cbRating2WithExceptionP5.Enabled = true;
            }
        }
        protected void cbRating1WithExceptionNotAllowed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRating1WithExceptionNotAllowed.Checked == true)
            {
                cbRating1WithExceptionP1.Checked = false;
                cbRating1WithExceptionP1.Enabled = false;
                cbRating1WithExceptionP2.Checked = false;
                cbRating1WithExceptionP2.Enabled = false;
                cbRating1WithExceptionP3.Checked = false;
                cbRating1WithExceptionP3.Enabled = false;
                cbRating1WithExceptionP4.Checked = false;
                cbRating1WithExceptionP4.Enabled = false;
                cbRating1WithExceptionP5.Checked = false;
                cbRating1WithExceptionP5.Enabled = false;
            }
            else
            {
                cbRating1WithExceptionP1.Enabled = true;
                cbRating1WithExceptionP2.Enabled = true;
                cbRating1WithExceptionP3.Enabled = true;
                cbRating1WithExceptionP4.Enabled = true;
                cbRating1WithExceptionP5.Enabled = true;
            }
        }
        #endregion

        #region Grid Event
        #region ProfileMismatchMatrix

        protected void rgridProfileMismatchMatrixList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                rgridProfileMismatchMatrixList.DataSource = GetProfileMismatchMatrixList();
            }
            catch (ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                ram.Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }

        protected void rgridProfileMismatchMatrixList_ItemDataBound(object sender, GridItemEventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                if (e.Item.ItemType == GridItemType.AlternatingItem || e.Item.ItemType == GridItemType.Item)
                {
                    int iAssetClass = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "AssetClassID"));
                    ProfileMismatchMatrixCollection oProfileMismatchMatrixCollection = new ProfileMismatchMatrixCollection();
                    oProfileMismatchMatrixCollection.DAL_LoadByAssetClassIDWithProductRatingScore(iAssetClass);
                    string sProductRatingScore = "";
                    for (int i = 0; i < oProfileMismatchMatrixCollection.Count; i++)
                    {
                        if (i == 0)
                        {
                            sProductRatingScore = sProductRatingScore + oProfileMismatchMatrixCollection[i].ProductRatingScore;
                        }
                        else
                        {
                            sProductRatingScore = sProductRatingScore + ";" + oProfileMismatchMatrixCollection[i].ProductRatingScore;
                        }
                    }
                    Label lbProductRatingScore = (Label)e.Item.FindControl("lbProductRatingScore");
                    lbProductRatingScore.Text = sProductRatingScore;
                    DropDownList ddlOperatorNo = (DropDownList)e.Item.FindControl("ddlOperatorNo");
                    BindDdlOperator(ddlOperatorNo);
                    ddlOperatorNo.SelectedValue = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "OperatorIDNo"));
                    DropDownList ddlOperatorYes = (DropDownList)e.Item.FindControl("ddlOperatorYes");
                    BindDdlOperator(ddlOperatorYes);
                    ddlOperatorYes.SelectedValue = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "OperatorIDYes"));
                }
                //else if (e.Item.ItemType == GridItemType.CommandItem)
                //{
                //    RadToolBar RadTBUser = (RadToolBar)e.Item.FindControl("RadTBUser");
                //    RadTBUser.Visible = Security.CheckSecurity(SecurityEnumeration.SecurityModuleObjectMember.SCR_USR_CREATE.ToString());
                //}

                //if (e.Item is Telerik.Web.UI.GridCommandItem)
                //{
                //    //Change RadToolBarButton Text
                //    ((Telerik.Web.UI.RadToolBarButton)e.Item.Controls[0].Controls[1].Controls[0]).Text = "Create New User";
                //}
            }
            catch (ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                ram.Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        #endregion

        #region Grid ExceptionRequiredMatrix
        protected void rgridExceptionRequiredMatrixList_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                rgridExceptionRequiredMatrixList.DataSource = GetExceptionRequiredMatrixList();
            }
            catch (ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                ram.Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        protected void rgridExceptionRequiredMatrixList_ItemCommand(object source, GridCommandEventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            ExceptionRequiredMatrix oExceptionRequiredMatrix = new ExceptionRequiredMatrix();

            try
            {
                if (e.CommandName == "Insert")
                {
                    for (int i = 0; i < rgridExceptionRequiredMatrixList.Items.Count; i++)
                    {
                        rgridExceptionRequiredMatrixList.Items[i].Edit = false;
                    }

                    e.Canceled = true;
                    System.Collections.Specialized.ListDictionary ldNewValues = new System.Collections.Specialized.ListDictionary();
                    ldNewValues["ExceptionRequiredMatrixID"] = 0;
                    e.Item.OwnerTableView.InsertItem(ldNewValues);
                }

                if (e.CommandName == RadGrid.InitInsertCommandName)
                {
                    for (int i = 0; i < rgridExceptionRequiredMatrixList.Items.Count; i++)
                    {
                        rgridExceptionRequiredMatrixList.Items[i].Edit = false;
                    }

                    e.Canceled = true;
                    System.Collections.Specialized.ListDictionary ldNewValues = new System.Collections.Specialized.ListDictionary();
                    ldNewValues["ExceptionRequiredMatrixID"] = 0;
                    e.Item.OwnerTableView.InsertItem(ldNewValues);
                }
                else if (e.CommandName == RadGrid.UpdateCommandName
                    || e.CommandName == RadGrid.PerformInsertCommandName)
                {
                    DropDownList ddlIsVc = (DropDownList)e.Item.FindControl("ddlIsVc");
                    DropDownList ddlIsRiskMismatch = (DropDownList)e.Item.FindControl("ddlIsRiskMismatch");
                    DropDownList ddlExceptionRequireStatus = (DropDownList)e.Item.FindControl("ddlExceptionRequireStatus");
                    CheckBox cbIsActive = (CheckBox)e.Item.FindControl("cbIsActive");

                    if (e.CommandName == RadGrid.UpdateCommandName)
                    {
                        int iExceptionRequiredMatrixID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExceptionRequiredMatrixID"]);
                        if (e.Item.ItemIndex >= 0)
                        {

                            IEnumerable<ExceptionRequiredMatrix> oExceptionRequiredMatrixCheckDuplicate = from ExceptionRequiredMatrix oExceptionRequiredMatrixCheck in sessExceptionRequiredMatrixCollection
                                                                                                          where oExceptionRequiredMatrixCheck.IsVc == Convert.ToBoolean(ddlIsVc.SelectedValue)
                                                                                                          where oExceptionRequiredMatrixCheck.IsRiskMismatch == Convert.ToBoolean(ddlIsRiskMismatch.SelectedValue)
                                                                                                          select oExceptionRequiredMatrixCheck;
                            if (oExceptionRequiredMatrixCheckDuplicate.Count() == 0)
                            {
                                int iIndex = 0;
                                foreach (ExceptionRequiredMatrix oExceptionRequiredMatrixDelete in sessExceptionRequiredMatrixCollection)
                                {
                                    if (oExceptionRequiredMatrixDelete.ExceptionRequiredMatrixID == iExceptionRequiredMatrixID)
                                    {
                                        sessExceptionRequiredMatrixCollection.RemoveAt(iIndex);
                                        break;
                                    }
                                    iIndex++;
                                }
                                sessExceptionRequiredMatrixCollection.Add(oExceptionRequiredMatrix);
                            }
                            else
                            {
                                if (oExceptionRequiredMatrixCheckDuplicate.ElementAt(0).ExceptionRequiredMatrixID == iExceptionRequiredMatrixID)
                                {
                                    int iIndex = 0;
                                    foreach (ExceptionRequiredMatrix oExceptionRequiredMatrixDelete in sessExceptionRequiredMatrixCollection)
                                    {
                                        if (oExceptionRequiredMatrixDelete.ExceptionRequiredMatrixID == iExceptionRequiredMatrixID)
                                        {
                                            sessExceptionRequiredMatrixCollection[iIndex].ExceptionRequiredMatrixID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExceptionRequiredMatrixID"]);
                                            sessExceptionRequiredMatrixCollection[iIndex].UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                                            sessExceptionRequiredMatrixCollection[iIndex].UpdateDate = DateTime.Now;
                                            sessExceptionRequiredMatrixCollection[iIndex].IsRiskMismatch = Convert.ToBoolean(ddlIsRiskMismatch.SelectedValue);
                                            sessExceptionRequiredMatrixCollection[iIndex].IsActive = cbIsActive.Checked;
                                            sessExceptionRequiredMatrixCollection[iIndex].IsVc = Convert.ToBoolean(ddlIsVc.SelectedValue);
                                            sessExceptionRequiredMatrixCollection[iIndex].ExceptionRequireStatus = Convert.ToBoolean(ddlExceptionRequireStatus.SelectedValue);
                                            break;
                                        }
                                        iIndex++;
                                    }
                                }
                                else
                                {
                                    Alert("There is already same data (VC and Risk Mismatch has same value).");
                                }
                            }
                        }

                        BindGridExceptionRequiredMatrix();
                    }
                    else if (e.CommandName == RadGrid.PerformInsertCommandName)
                    {
                        #region Insert
                        oExceptionRequiredMatrix.ExceptionRequiredMatrixID = vsLastIDExceptionRequired;

                        IEnumerable<ExceptionRequiredMatrix> oExceptionRequiredMatrixCheckDuplicate = from ExceptionRequiredMatrix oExceptionRequiredMatrixCheck in sessExceptionRequiredMatrixCollection
                                                                                                      where oExceptionRequiredMatrixCheck.IsVc == Convert.ToBoolean(ddlIsVc.SelectedValue)
                                                                                                      where oExceptionRequiredMatrixCheck.IsRiskMismatch == Convert.ToBoolean(ddlIsRiskMismatch.SelectedValue)
                                                                                                      select oExceptionRequiredMatrixCheck;
                        if (oExceptionRequiredMatrixCheckDuplicate.Count() == 0)
                        {
                            oExceptionRequiredMatrix.CreateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                            oExceptionRequiredMatrix.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                            oExceptionRequiredMatrix.CreateDate = DateTime.Now;
                            oExceptionRequiredMatrix.UpdateDate = DateTime.Now;
                            oExceptionRequiredMatrix.IsRiskMismatch = Convert.ToBoolean(ddlIsRiskMismatch.SelectedValue);
                            oExceptionRequiredMatrix.IsActive = cbIsActive.Checked;
                            oExceptionRequiredMatrix.IsVc = Convert.ToBoolean(ddlIsVc.SelectedValue);
                            oExceptionRequiredMatrix.ExceptionRequireStatus = Convert.ToBoolean(ddlExceptionRequireStatus.SelectedValue);
                            sessExceptionRequiredMatrixCollection.Add(oExceptionRequiredMatrix);
                        }
                        else
                        {
                            Alert("There is already same data (VC and Risk Mismatch has same value).");
                        }
                        vsLastIDExceptionRequired = vsLastIDExceptionRequired - 1;
                        BindGridExceptionRequiredMatrix();
                        #endregion
                    }

                    e.Item.Edit = false;
                    BindGridExceptionRequiredMatrix();
                }
                else if (e.CommandName == RadGrid.EditCommandName)
                {
                    rgridExceptionRequiredMatrixList.MasterTableView.IsItemInserted = false;
                }
                else if (e.CommandName == RadGrid.DeleteCommandName)
                {
                    oExceptionRequiredMatrix.ExceptionRequiredMatrixID = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExceptionRequiredMatrixID"]);
                    int iExceptionRequiredMatrixId = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExceptionRequiredMatrixID"]);
                    int iIndex = 0;
                    foreach (ExceptionRequiredMatrix oExceptionRequiredMatrixDelete in sessExceptionRequiredMatrixCollection)
                    {
                        if (oExceptionRequiredMatrixDelete.ExceptionRequiredMatrixID == iExceptionRequiredMatrixId)
                        {
                            sessExceptionRequiredMatrixCollection.RemoveAt(iIndex);
                            break;
                        }
                        iIndex++;
                    }
                    BindGridExceptionRequiredMatrix();
                }
                else if (e.CommandName == "Cancel")
                {
                    //GridPagerItem pagerItem = (GridPagerItem)rgridGroupList.MasterTableView.GetItems(GridItemType.Pager)[0];
                    //pagerItem.Enabled = false;
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                ram.Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        protected void rgridExceptionRequiredMatrixList_ItemDataBound(object source, GridItemEventArgs e)
        {
            string sRefNumber = PFSCommon.GenerateRefNumber();
            try
            {
                if (e.Item.ItemType == GridItemType.EditItem)
                {
                    DropDownList ddlIsVs = (DropDownList)e.Item.FindControl("ddlIsVc");
                    Bind_DdlIsVs(ddlIsVs);

                    ddlIsVs.SelectedValue = DataBinder.Eval(e.Item, "DataItem.IsVc").ToString();

                    DropDownList ddlIsRiskMismatch = (DropDownList)e.Item.FindControl("ddlIsRiskMismatch");
                    Bind_DdlIsRiskMismatch(ddlIsRiskMismatch);
                    ddlIsRiskMismatch.SelectedValue = DataBinder.Eval(e.Item, "DataItem.IsRiskMismatch").ToString();

                    DropDownList ddlExceptionRequireStatus = (DropDownList)e.Item.FindControl("ddlExceptionRequireStatus");
                    Bind_DdlExceptionRequireStatus(ddlExceptionRequireStatus);
                    ddlExceptionRequireStatus.SelectedValue = DataBinder.Eval(e.Item, "DataItem.ExceptionRequireStatus").ToString();

                    CheckBox cbIsActive = (CheckBox)e.Item.FindControl("cbIsActive");
                    cbIsActive.Checked = DataBinder.Eval(e.Item, "DataItem.IsActive").ToString() == "True" ? true : false;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(sRefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                ram.Alert(string.Format("{0} ({1})", GeneralError(), sRefNumber));
            }
        }
        #endregion
        #endregion

        #region Data Binding
        private void BindDdlEducationBackground()
        {
            try
            {
                ddlEducationBackground.DataSource = null;

                EducationCollection oEducationCollection = new EducationCollection();
                oEducationCollection.DAL_Load();

                ddlEducationBackground.DataSource = oEducationCollection;
                ddlEducationBackground.DataTextField = "EducationName";
                ddlEducationBackground.DataValueField = "EducationID";
                ddlEducationBackground.DataBind();

                ListItem li = new ListItem(STRING_SELECT_ONE, "-1");
                ddlEducationBackground.Items.Insert(0, li);
                ddlEducationBackground.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindDdlOperator(DropDownList cmbMyCombo)
        {
            try
            {
                OperatorCollection oOperatorCollection = new OperatorCollection();
                oOperatorCollection.DAL_Load();
                oOperatorCollection.Sort(OperatorCollection.OperatorFields.OperatorCode, true);

                cmbMyCombo.DataSource = oOperatorCollection;
                cmbMyCombo.DataTextField = "OperatorCode";
                cmbMyCombo.DataValueField = "OperatorID";
                cmbMyCombo.DataBind();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private void Bind_DdlIsVs(DropDownList p_oDropDownList)
        {
            p_oDropDownList.Items.Clear();
            p_oDropDownList.Items.Add(new ListItem("Yes", "True"));
            p_oDropDownList.Items.Add(new ListItem("No", "False"));

        }
        private void Bind_DdlIsRiskMismatch(DropDownList p_oDropDownList)
        {
            p_oDropDownList.Items.Clear();
            p_oDropDownList.Items.Add(new ListItem("Yes", "True"));
            p_oDropDownList.Items.Add(new ListItem("No", "False"));

        }
        private void Bind_DdlExceptionRequireStatus(DropDownList p_oDropDownList)
        {
            p_oDropDownList.Items.Clear();
            p_oDropDownList.Items.Add(new ListItem("Yes", "True"));
            p_oDropDownList.Items.Add(new ListItem("No", "False"));

        }
        #endregion

        #region Method
        private void BindGridExceptionRequiredMatrix()
        {
            rgridExceptionRequiredMatrixList.Rebind();
        }
        #region Generate String Rating
        private string GenerateStringRatingC1WithException()
        {
            string sValueWithException = "";
            if (cbRating1WithExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P1";
                }
                else
                {
                    sValueWithException = "P1";
                }
            }
            if (cbRating1WithExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P2";
                }
                else
                {
                    sValueWithException = "P2";
                }
            }
            if (cbRating1WithExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P3";
                }
                else
                {
                    sValueWithException = "P3";
                }
            }
            if (cbRating1WithExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P4";
                }
                else
                {
                    sValueWithException = "P4";
                }
            }
            if (cbRating1WithExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P5";
                }
                else
                {
                    sValueWithException = "P5";
                }
            }
            if (cbRating1WithExceptionNotAllowed.Checked)
            {
                sValueWithException = "NOT_ALLOWED";
            }
            return sValueWithException;
        }
        private string GenerateStringRatingC1WithoutException()
        {
            string sValueWithoutException = "";
            if (cbRating1WithoutExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P1";
                }
                else
                {
                    sValueWithoutException = "P1";
                }
            }
            if (cbRating1WithoutExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P2";
                }
                else
                {
                    sValueWithoutException = "P2";
                }
            }
            if (cbRating1WithoutExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P3";
                }
                else
                {
                    sValueWithoutException = "P3";
                }
            }
            if (cbRating1WithoutExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P4";
                }
                else
                {
                    sValueWithoutException = "P4";
                }
            }
            if (cbRating1WithoutExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P5";
                }
                else
                {
                    sValueWithoutException = "P5";
                }
            }
            return sValueWithoutException;
        }
        private string GenerateStringRatingC2WithException()
        {
            string sValueWithException = "";
            if (cbRating2WithExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P1";
                }
                else
                {
                    sValueWithException = "P1";
                }
            }
            if (cbRating2WithExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P2";
                }
                else
                {
                    sValueWithException = "P2";
                }
            }
            if (cbRating2WithExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P3";
                }
                else
                {
                    sValueWithException = "P3";
                }
            }
            if (cbRating2WithExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P4";
                }
                else
                {
                    sValueWithException = "P4";
                }
            }
            if (cbRating2WithExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P5";
                }
                else
                {
                    sValueWithException = "P5";
                }
            }
            if (cbRating2WithExceptionNotAllowed.Checked)
            {
                sValueWithException = "NOT_ALLOWED";
            }
            return sValueWithException;
        }
        private string GenerateStringRatingC2WithoutException()
        {
            string sValueWithoutException = "";
            if (cbRating2WithoutExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P1";
                }
                else
                {
                    sValueWithoutException = "P1";
                }
            }
            if (cbRating2WithoutExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P2";
                }
                else
                {
                    sValueWithoutException = "P2";
                }
            }
            if (cbRating2WithoutExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P3";
                }
                else
                {
                    sValueWithoutException = "P3";
                }
            }
            if (cbRating2WithoutExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P4";
                }
                else
                {
                    sValueWithoutException = "P4";
                }
            }
            if (cbRating2WithoutExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P5";
                }
                else
                {
                    sValueWithoutException = "P5";
                }
            }
            return sValueWithoutException;
        }
        private string GenerateStringRatingC3WithException()
        {
            string sValueWithException = "";
            if (cbRating3WithExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P1";
                }
                else
                {
                    sValueWithException = "P1";
                }
            }
            if (cbRating3WithExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P2";
                }
                else
                {
                    sValueWithException = "P2";
                }
            }
            if (cbRating3WithExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P3";
                }
                else
                {
                    sValueWithException = "P3";
                }
            }
            if (cbRating3WithExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P4";
                }
                else
                {
                    sValueWithException = "P4";
                }
            }
            if (cbRating3WithExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P5";
                }
                else
                {
                    sValueWithException = "P5";
                }
            }
            if (cbRating3WithExceptionNotAllowed.Checked)
            {
                sValueWithException = "NOT_ALLOWED";
            }
            return sValueWithException;
        }
        private string GenerateStringRatingC3WithoutException()
        {
            string sValueWithoutException = "";
            if (cbRating3WithoutExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P1";
                }
                else
                {
                    sValueWithoutException = "P1";
                }
            }
            if (cbRating3WithoutExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P2";
                }
                else
                {
                    sValueWithoutException = "P2";
                }
            }
            if (cbRating3WithoutExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P3";
                }
                else
                {
                    sValueWithoutException = "P3";
                }
            }
            if (cbRating3WithoutExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P4";
                }
                else
                {
                    sValueWithoutException = "P4";
                }
            }
            if (cbRating3WithoutExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P5";
                }
                else
                {
                    sValueWithoutException = "P5";
                }
            }
            return sValueWithoutException;
        }
        private string GenerateStringRatingC4WithException()
        {
            string sValueWithException = "";
            if (cbRating4WithExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P1";
                }
                else
                {
                    sValueWithException = "P1";
                }
            }
            if (cbRating4WithExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P2";
                }
                else
                {
                    sValueWithException = "P2";
                }
            }
            if (cbRating4WithExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P3";
                }
                else
                {
                    sValueWithException = "P3";
                }
            }
            if (cbRating4WithExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P4";
                }
                else
                {
                    sValueWithException = "P4";
                }
            }
            if (cbRating4WithExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P5";
                }
                else
                {
                    sValueWithException = "P5";
                }
            }
            if (cbRating4WithExceptionNotAllowed.Checked)
            {
                sValueWithException = "NOT_ALLOWED";
            }
            return sValueWithException;
        }
        private string GenerateStringRatingC4WithoutException()
        {
            string sValueWithoutException = "";
            if (cbRating4WithoutExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P1";
                }
                else
                {
                    sValueWithoutException = "P1";
                }
            }
            if (cbRating4WithoutExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P2";
                }
                else
                {
                    sValueWithoutException = "P2";
                }
            }
            if (cbRating4WithoutExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P3";
                }
                else
                {
                    sValueWithoutException = "P3";
                }
            }
            if (cbRating4WithoutExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P4";
                }
                else
                {
                    sValueWithoutException = "P4";
                }
            }
            if (cbRating4WithoutExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P5";
                }
                else
                {
                    sValueWithoutException = "P5";
                }
            }
            return sValueWithoutException;
        }
        private string GenerateStringRatingC5WithException()
        {
            string sValueWithException = "";
            if (cbRating5WithExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P1";
                }
                else
                {
                    sValueWithException = "P1";
                }
            }
            if (cbRating5WithExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P2";
                }
                else
                {
                    sValueWithException = "P2";
                }
            }
            if (cbRating5WithExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P3";
                }
                else
                {
                    sValueWithException = "P3";
                }
            }
            if (cbRating5WithExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P4";
                }
                else
                {
                    sValueWithException = "P4";
                }
            }
            if (cbRating5WithExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithException))
                {
                    sValueWithException = sValueWithException + ";P5";
                }
                else
                {
                    sValueWithException = "P5";
                }
            }
            if (cbRating5WithExceptionNotAllowed.Checked)
            {
                sValueWithException = "NOT_ALLOWED";
            }
            return sValueWithException;
        }
        private string GenerateStringRatingC5WithoutException()
        {
            string sValueWithoutException = "";
            if (cbRating5WithoutExceptionP1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P1";
                }
                else
                {
                    sValueWithoutException = "P1";
                }
            }
            if (cbRating5WithoutExceptionP2.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P2";
                }
                else
                {
                    sValueWithoutException = "P2";
                }
            }
            if (cbRating5WithoutExceptionP3.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P3";
                }
                else
                {
                    sValueWithoutException = "P3";
                }
            }
            if (cbRating5WithoutExceptionP4.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P4";
                }
                else
                {
                    sValueWithoutException = "P4";
                }
            }
            if (cbRating5WithoutExceptionP5.Checked)
            {
                if (!string.IsNullOrWhiteSpace(sValueWithoutException))
                {
                    sValueWithoutException = sValueWithoutException + ";P5";
                }
                else
                {
                    sValueWithoutException = "P5";
                }
            }
            return sValueWithoutException;
        }
        #endregion
        private void ViewConditionAndMatrixSetup()
        {
            #region VulnerableCheckingCriteria
            sessVulnerableCheckingCriteriaCollection = new VulnerableCheckingCriteriaCollection();

            VulnerableCheckingCriteriaCollection oVulnerableCheckingCriteriaCollection = new VulnerableCheckingCriteriaCollection();
            oVulnerableCheckingCriteriaCollection.DAL_Load();

            foreach (VulnerableCheckingCriteria oVulnerableCheckingCriteria in oVulnerableCheckingCriteriaCollection)
            {
                if (oVulnerableCheckingCriteria.VulnerableCheckingCriteriaID == (int)PSCEnumeration.ConditionMatrixSetupVulnerableCheckingCriteria.AGE1)
                {
                    tbAge1From.Text = Convert.ToString(oVulnerableCheckingCriteria.Value);
                    tbAge1To.Text = (oVulnerableCheckingCriteria.MaxValue == 0) ? "" : Convert.ToString(oVulnerableCheckingCriteria.MaxValue);
                }
                if (oVulnerableCheckingCriteria.VulnerableCheckingCriteriaID == (int)PSCEnumeration.ConditionMatrixSetupVulnerableCheckingCriteria.AGE2)
                {
                    tbAge2From.Text = Convert.ToString(oVulnerableCheckingCriteria.Value);
                    tbAge2To.Text = (oVulnerableCheckingCriteria.MaxValue == 0) ? "" : Convert.ToString(oVulnerableCheckingCriteria.MaxValue);
                }
                if (oVulnerableCheckingCriteria.VulnerableCheckingCriteriaID == (int)PSCEnumeration.ConditionMatrixSetupVulnerableCheckingCriteria.EDUCATION_BACKGROUND)
                {
                    ddlEducationBackground.SelectedValue = Convert.ToString(oVulnerableCheckingCriteria.Value);
                }
                sessVulnerableCheckingCriteriaCollection.Add(oVulnerableCheckingCriteria);
            }
            #endregion

            #region ImportantNotesMatrix
            sessImportantNotesMatrixCollection = new ImportantNotesMatrixCollection();
            ImportantNotesMatrixCollection oImportantNotesMatrixCollection = new ImportantNotesMatrixCollection();
            oImportantNotesMatrixCollection.DAL_Load();

            for (int i = 0; i < oImportantNotesMatrixCollection.Count; i++)
            {
                if (oImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_1.ToString())
                {
                    lbImportantNotesMatrixParam1.Text = PFSCommon.GetSysParam(oImportantNotesMatrixCollection[i].RefCode);
                    cbImportantNotesMatrixParam1P1.Checked = oImportantNotesMatrixCollection[i].IsP1Checked;
                    cbImportantNotesMatrixParam1P2.Checked = oImportantNotesMatrixCollection[i].IsP2Checked;
                    cbImportantNotesMatrixParam1P3.Checked = oImportantNotesMatrixCollection[i].IsP3Checked;
                    cbImportantNotesMatrixParam1P4.Checked = oImportantNotesMatrixCollection[i].IsP4Checked;
                    cbImportantNotesMatrixParam1P5.Checked = oImportantNotesMatrixCollection[i].IsP5Checked;
                    cbImportantNotesMatrixParam1Mismatch.Checked = oImportantNotesMatrixCollection[i].IsMismatchChecked;
                }
                if (oImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_2.ToString())
                {
                    lbImportantNotesMatrixParam2.Text = PFSCommon.GetSysParam(oImportantNotesMatrixCollection[i].RefCode);
                    cbImportantNotesMatrixParam2P1.Checked = oImportantNotesMatrixCollection[i].IsP1Checked;
                    cbImportantNotesMatrixParam2P2.Checked = oImportantNotesMatrixCollection[i].IsP2Checked;
                    cbImportantNotesMatrixParam2P3.Checked = oImportantNotesMatrixCollection[i].IsP3Checked;
                    cbImportantNotesMatrixParam2P4.Checked = oImportantNotesMatrixCollection[i].IsP4Checked;
                    cbImportantNotesMatrixParam2P5.Checked = oImportantNotesMatrixCollection[i].IsP5Checked;
                    cbImportantNotesMatrixParam2Mismatch.Checked = oImportantNotesMatrixCollection[i].IsMismatchChecked;
                }
                if (oImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_3.ToString())
                {
                    lbImportantNotesMatrixParam3.Text = PFSCommon.GetSysParam(oImportantNotesMatrixCollection[i].RefCode);
                    cbImportantNotesMatrixParam3P1.Checked = oImportantNotesMatrixCollection[i].IsP1Checked;
                    cbImportantNotesMatrixParam3P2.Checked = oImportantNotesMatrixCollection[i].IsP2Checked;
                    cbImportantNotesMatrixParam3P3.Checked = oImportantNotesMatrixCollection[i].IsP3Checked;
                    cbImportantNotesMatrixParam3P4.Checked = oImportantNotesMatrixCollection[i].IsP4Checked;
                    cbImportantNotesMatrixParam3P5.Checked = oImportantNotesMatrixCollection[i].IsP5Checked;
                    cbImportantNotesMatrixParam3MisMatch.Checked = oImportantNotesMatrixCollection[i].IsMismatchChecked;
                }
                if (oImportantNotesMatrixCollection[i].RefCode == PSCEnumeration.ImportantNotesMatrixRefCode.IMPORTANT_NOTES_MATRIX_PARAM_4.ToString())
                {
                    lbImportantNotesMatrixParam4.Text = PFSCommon.GetSysParam(oImportantNotesMatrixCollection[i].RefCode);
                    cbImportantNotesMatrixParam4P1.Checked = oImportantNotesMatrixCollection[i].IsP1Checked;
                    cbImportantNotesMatrixParam4P2.Checked = oImportantNotesMatrixCollection[i].IsP2Checked;
                    cbImportantNotesMatrixParam4P3.Checked = oImportantNotesMatrixCollection[i].IsP3Checked;
                    cbImportantNotesMatrixParam4P4.Checked = oImportantNotesMatrixCollection[i].IsP4Checked;
                    cbImportantNotesMatrixParam4P5.Checked = oImportantNotesMatrixCollection[i].IsP5Checked;
                    cbImportantNotesMatrixParam4Mismatch.Checked = oImportantNotesMatrixCollection[i].IsMismatchChecked;
                }
                sessImportantNotesMatrixCollection.Add(oImportantNotesMatrixCollection[i]);
            }
            #endregion

            #region CustomerRatingVsProductRating
            sessCustomerRatingVsProductRatingCollection = new CustomerRatingVsProductRatingCollection();
            CustomerRatingVsProductRatingCollection oCustomerRatingVsProductRatingCollection = new CustomerRatingVsProductRatingCollection();
            oCustomerRatingVsProductRatingCollection.DAL_Load();
            for (int i = 0; i < oCustomerRatingVsProductRatingCollection.Count; i++)
            {
                if (oCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C1)
                {
                    string[] oWithNoExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException.Split(';');
                    foreach (string oWithNoException in oWithNoExceptions)
                    {
                        switch (oWithNoException.Trim())
                        {
                            case "P1":
                                cbRating1WithoutExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating1WithoutExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating1WithoutExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating1WithoutExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating1WithoutExceptionP5.Checked = true;
                                break;
                        }

                    }
                    string[] oWithExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException.Split(';');
                    foreach (string oWithException in oWithExceptions)
                    {
                        switch (oWithException.Trim())
                        {
                            case "P1":
                                cbRating1WithExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating1WithExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating1WithExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating1WithExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating1WithExceptionP5.Checked = true;
                                break;
                            case "NOT_ALLOWED":
                                cbRating1WithExceptionNotAllowed.Checked = true;
                                cbRating1WithExceptionP1.Checked = false;
                                cbRating1WithExceptionP1.Enabled = false;
                                cbRating1WithExceptionP2.Checked = false;
                                cbRating1WithExceptionP2.Enabled = false;
                                cbRating1WithExceptionP3.Checked = false;
                                cbRating1WithExceptionP3.Enabled = false;
                                cbRating1WithExceptionP4.Checked = false;
                                cbRating1WithExceptionP4.Enabled = false;
                                cbRating1WithExceptionP5.Checked = false;
                                cbRating1WithExceptionP5.Enabled = false;
                                break;
                        }
                    }
                }
                if (oCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C2)
                {
                    string[] oWithNoExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException.Split(';');
                    foreach (string oWithNoException in oWithNoExceptions)
                    {
                        switch (oWithNoException.Trim())
                        {
                            case "P1":
                                cbRating2WithoutExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating2WithoutExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating2WithoutExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating2WithoutExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating2WithoutExceptionP5.Checked = true;
                                break;
                        }

                    }
                    string[] oWithExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException.Split(';');
                    foreach (string oWithException in oWithExceptions)
                    {
                        switch (oWithException.Trim())
                        {
                            case "P1":
                                cbRating2WithExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating2WithExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating2WithExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating2WithExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating2WithExceptionP5.Checked = true;
                                break;
                            case "NOT_ALLOWED":
                                cbRating2WithExceptionNotAllowed.Checked = true;
                                cbRating2WithExceptionP1.Checked = false;
                                cbRating2WithExceptionP1.Enabled = false;
                                cbRating2WithExceptionP2.Checked = false;
                                cbRating2WithExceptionP2.Enabled = false;
                                cbRating2WithExceptionP3.Checked = false;
                                cbRating2WithExceptionP3.Enabled = false;
                                cbRating2WithExceptionP4.Checked = false;
                                cbRating2WithExceptionP4.Enabled = false;
                                cbRating2WithExceptionP5.Checked = false;
                                cbRating2WithExceptionP5.Enabled = false;
                                break;
                        }
                    }
                }
                if (oCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C3)
                {
                    string[] oWithNoExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException.Split(';');
                    foreach (string oWithNoException in oWithNoExceptions)
                    {
                        switch (oWithNoException.Trim())
                        {
                            case "P1":
                                cbRating3WithoutExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating3WithoutExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating3WithoutExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating3WithoutExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating3WithoutExceptionP5.Checked = true;
                                break;
                        }

                    }
                    string[] oWithExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException.Split(';');
                    foreach (string oWithException in oWithExceptions)
                    {
                        switch (oWithException.Trim())
                        {
                            case "P1":
                                cbRating3WithExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating3WithExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating3WithExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating3WithExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating3WithExceptionP5.Checked = true;
                                break;
                            case "NOT_ALLOWED":
                                cbRating3WithExceptionNotAllowed.Checked = true;
                                cbRating3WithExceptionP1.Checked = false;
                                cbRating3WithExceptionP1.Enabled = false;
                                cbRating3WithExceptionP2.Checked = false;
                                cbRating3WithExceptionP2.Enabled = false;
                                cbRating3WithExceptionP3.Checked = false;
                                cbRating3WithExceptionP3.Enabled = false;
                                cbRating3WithExceptionP4.Checked = false;
                                cbRating3WithExceptionP4.Enabled = false;
                                cbRating3WithExceptionP5.Checked = false;
                                cbRating3WithExceptionP5.Enabled = false;
                                break;
                        }
                    }
                }
                if (oCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C4)
                {
                    string[] oWithNoExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException.Split(';');
                    foreach (string oWithNoException in oWithNoExceptions)
                    {
                        switch (oWithNoException.Trim())
                        {
                            case "P1":
                                cbRating4WithoutExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating4WithoutExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating4WithoutExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating4WithoutExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating4WithoutExceptionP5.Checked = true;
                                break;
                        }

                    }
                    string[] oWithExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException.Split(';');
                    foreach (string oWithException in oWithExceptions)
                    {
                        switch (oWithException.Trim())
                        {
                            case "P1":
                                cbRating4WithExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating4WithExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating4WithExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating4WithExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating4WithExceptionP5.Checked = true;
                                break;
                            case "NOT_ALLOWED":
                                cbRating4WithExceptionNotAllowed.Checked = true;
                                cbRating4WithExceptionP1.Checked = false;
                                cbRating4WithExceptionP1.Enabled = false;
                                cbRating4WithExceptionP2.Checked = false;
                                cbRating4WithExceptionP2.Enabled = false;
                                cbRating4WithExceptionP3.Checked = false;
                                cbRating4WithExceptionP3.Enabled = false;
                                cbRating4WithExceptionP4.Checked = false;
                                cbRating4WithExceptionP4.Enabled = false;
                                cbRating4WithExceptionP5.Checked = false;
                                cbRating4WithExceptionP5.Enabled = false;
                                break;
                        }
                    }
                }
                if (oCustomerRatingVsProductRatingCollection[i].CustomerRiskRatingID == (int)PSCEnumeration.ConditionMatrixSetupCustomerRiskRating.C5)
                {
                    string[] oWithNoExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithNoException.Split(';');
                    foreach (string oWithNoException in oWithNoExceptions)
                    {
                        switch (oWithNoException.Trim())
                        {
                            case "P1":
                                cbRating5WithoutExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating5WithoutExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating5WithoutExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating5WithoutExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating5WithoutExceptionP5.Checked = true;
                                break;
                        }

                    }
                    string[] oWithExceptions = oCustomerRatingVsProductRatingCollection[i].ProductRatingToWithException.Split(';');
                    foreach (string oWithException in oWithExceptions)
                    {
                        switch (oWithException.Trim())
                        {
                            case "P1":
                                cbRating5WithExceptionP1.Checked = true;
                                break;
                            case "P2":
                                cbRating5WithExceptionP2.Checked = true;
                                break;
                            case "P3":
                                cbRating5WithExceptionP3.Checked = true;
                                break;
                            case "P4":
                                cbRating5WithExceptionP4.Checked = true;
                                break;
                            case "P5":
                                cbRating5WithExceptionP5.Checked = true;
                                break;
                            case "NOT_ALLOWED":
                                cbRating5WithExceptionNotAllowed.Checked = true;
                                cbRating5WithExceptionP1.Checked = false;
                                cbRating5WithExceptionP1.Enabled = false;
                                cbRating5WithExceptionP2.Checked = false;
                                cbRating5WithExceptionP2.Enabled = false;
                                cbRating5WithExceptionP3.Checked = false;
                                cbRating5WithExceptionP3.Enabled = false;
                                cbRating5WithExceptionP4.Checked = false;
                                cbRating5WithExceptionP4.Enabled = false;
                                cbRating5WithExceptionP5.Checked = false;
                                cbRating5WithExceptionP5.Enabled = false;
                                break;
                        }
                    }
                }
                sessCustomerRatingVsProductRatingCollection.Add(oCustomerRatingVsProductRatingCollection[i]);
            }
            #endregion
        }
        private ExceptionRequiredMatrixCollection GetExceptionRequiredMatrixList()
        {
            ExceptionRequiredMatrixCollection oExceptionRequiredMatrixCollection = new ExceptionRequiredMatrixCollection();
            if (sessExceptionRequiredMatrixCollection == null || sessExceptionRequiredMatrixCollection.Count == 0)
            {
                oExceptionRequiredMatrixCollection.DAL_Load(null, null, null, null, null, false, null, null, null, null, null, null);
                sessExceptionRequiredMatrixCollection = oExceptionRequiredMatrixCollection;
            }
            else
            {
                oExceptionRequiredMatrixCollection = sessExceptionRequiredMatrixCollection;
            }
            return oExceptionRequiredMatrixCollection;
        }
        private ProfileMismatchMatrixCollection GetProfileMismatchMatrixList()
        {
            ProfileMismatchMatrixCollection oProfileMismatchMatrixCollection = new ProfileMismatchMatrixCollection();
            if (sessProfileMismatchMatrixCollection == null || sessProfileMismatchMatrixCollection.Count == 0)
            {
                oProfileMismatchMatrixCollection.ListDistictAssetClass();
                sessProfileMismatchMatrixCollection = oProfileMismatchMatrixCollection;
            }
            else
            {
                oProfileMismatchMatrixCollection = sessProfileMismatchMatrixCollection;
            }

            return oProfileMismatchMatrixCollection;
        }
        #endregion
    }
}