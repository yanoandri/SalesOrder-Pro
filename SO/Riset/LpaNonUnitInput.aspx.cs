using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using PFSHelper.Lib;
using ProTaksatur.WebService;
using ProTaksatur.WebUI.App_Code;
using Telerik.Web.UI;
using System.Web;
using System.Globalization;

namespace ProTaksatur.WebUI
{
    public partial class LpaNonUnitInput : PFSBasePage
    {
        #region ViewState
        private int vsIndexNumberGridFacilityBuilding
        {
            get { return ViewState["vsIndexNumberGridFacilityBuilding"] == null ? 0 : Convert.ToInt32(ViewState["vsIndexNumberGridFacilityBuilding"]); }
            set { ViewState["vsIndexNumberGridFacilityBuilding"] = value; }
        }

        private int vsLpaUnitCertificateId
        {
            get { return ViewState["vsLpaUnitCertificateId"] == null ? 0 : (int)ViewState["vsLpaUnitCertificateId"]; }
            set { ViewState["vsLpaUnitCertificateId"] = value; }
        }
        private int vsLpaNonUnitContactId
        {
            get { return ViewState["vsLpaNonUnitContactId"] == null ? 0 : (int)ViewState["vsLpaNonUnitContactId"]; }
            set { ViewState["vsLpaNonUnitContactId"] = value; }
        }
        private int vsLpaNonUnitLandDescriptionId
        {
            get { return ViewState["vsLpaNonUnitLandDescriptionId"] == null ? 0 : (int)ViewState["vsLpaNonUnitLandDescriptionId"]; }
            set { ViewState["vsLpaNonUnitLandDescriptionId"] = value; }
        }
        private int vsLpaNonUnitLandPostiveId
        {
            get { return ViewState["vsLpaNonUnitLandPostiveId"] == null ? 0 : (int)ViewState["vsLpaNonUnitLandPostiveId"]; }
            set { ViewState["vsLpaNonUnitLandPostiveId"] = value; }
        }
        private int vsLpaNonUnitLandNegativeId
        {
            get { return ViewState["vsLandNegativeId"] == null ? 0 : (int)ViewState["vsLandNegativeId"]; }
            set { ViewState["vsLandNegativeId"] = value; }
        }
        private int vsLpaNonUnitDataBuildingId
        {
            get { return ViewState["vsLpaNonUnitDataBuildingId"] == null ? 0 : (int)ViewState["vsLpaNonUnitDataBuildingId"]; }
            set { ViewState["vsLpaNonUnitDataBuildingId"] = value; }
        }
        private int vsLpaNonUnitFacilityBuildingId
        {
            get { return ViewState["vsLpaNonUnitFacilityBuildingId"] == null ? 0 : (int)ViewState["vsLpaNonUnitFacilityBuildingId"]; }
            set { ViewState["vsLpaNonUnitFacilityBuildingId"] = value; }
        }
        private int vsLpaNonUnitBuildingDescriptionId
        {
            get { return ViewState["vsLpaNonUnitBuildingDescriptionId"] == null ? 0 : (int)ViewState["vsLpaNonUnitBuildingDescriptionId"]; }
            set { ViewState["vsLpaNonUnitBuildingDescriptionId"] = value; }
        }
        private int vsLpaNonUnitBuildingPostiveId
        {
            get { return ViewState["vsLpaNonUnitBuildingPostiveId"] == null ? 0 : (int)ViewState["vsLpaNonUnitBuildingPostiveId"]; }
            set { ViewState["vsLpaNonUnitBuildingPostiveId"] = value; }
        }
        private int vsLpaNonUnitBuildingNegativeId
        {
            get { return ViewState["vsLpaNonUnitBuildingNegativeId"] == null ? 0 : (int)ViewState["vsLpaNonUnitBuildingNegativeId"]; }
            set { ViewState["vsLpaNonUnitBuildingNegativeId"] = value; }
        }
        private int vsLpaNonUnitValueLandId
        {
            get { return ViewState["vsLpaNonUnitValueLandId"] == null ? 0 : (int)ViewState["vsLpaNonUnitValueLandId"]; }
            set { ViewState["vsLpaNonUnitValueLandId"] = value; }
        }
        private int vsLpaNonUnitValueBuildingId
        {
            get { return ViewState["vsLpaNonUnitValueBuildingId"] == null ? 0 : (int)ViewState["vsLpaNonUnitValueBuildingId"]; }
            set { ViewState["vsLpaNonUnitValueBuildingId"] = value; }
        }
        private int vsLpaNonUnitValueFacilityId
        {
            get { return ViewState["vsLpaNonUnitValueFacilityId"] == null ? 0 : (int)ViewState["vsLpaNonUnitValueFacilityId"]; }
            set { ViewState["vsLpaNonUnitValueFacilityId"] = value; }
        }
        private int vsLpaNonUnitTaxLandId
        {
            get { return ViewState["vsLpaNonUnitTaxLandId"] == null ? 0 : (int)ViewState["vsLpaNonUnitTaxLandId"]; }
            set { ViewState["vsLpaNonUnitTaxLandId"] = value; }
        }
        private int vsLpaNonUnitSpecialInformationId
        {
            get { return ViewState["vsLpaNonUnitSpecialInformationId"] == null ? 0 : (int)ViewState["vsLpaNonUnitSpecialInformationId"]; }
            set { ViewState["vsLpaNonUnitSpecialInformationId"] = value; }
        }
        private int vsLpaNonUnitTotalMarketPriceId
        {
            get { return ViewState["vsLpaNonUnitTotalMarketPriceId"] == null ? 0 : (int)ViewState["vsLpaNonUnitTotalMarketPriceId"]; }
            set { ViewState["vsLpaNonUnitTotalMarketPriceId"] = value; }
        }
        private int vsLpaNonUnitOpinionId
        {
            get { return ViewState["vsLpaNonUnitOpinionId"] == null ? 0 : (int)ViewState["vsLpaNonUnitOpinionId"]; }
            set { ViewState["vsLpaNonUnitOpinionId"] = value; }
        }
        private int vsLpaComparativeNonUnitId
        {
            get { return ViewState["vsLpaComparativeNonUnitId"] == null ? 0 : (int)ViewState["vsLpaComparativeNonUnitId"]; }
            set { ViewState["vsLpaComparativeNonUnitId"] = value; }
        }
        private int vsDocumentCalculationID
        {
            get { return ViewState["vsDocumentCalculationID"] == null ? 0 : (int)ViewState["vsDocumentCalculationID"]; }
            set { ViewState["vsDocumentCalculationID"] = value; }
        }
        private int vsLpaNonUnitLandId
        {
            get { return ViewState["vsLpaNonUnitLandId"] == null ? 0 : (int)ViewState["vsLpaNonUnitLandId"]; }
            set { ViewState["vsLpaNonUnitLandId"] = value; }
        }
        private int vsLpaNonUnitBuildingId
        {
            get { return ViewState["vsLpaNonUnitBuildingId"] == null ? 0 : (int)ViewState["vsLpaNonUnitBuildingId"]; }
            set { ViewState["vsLpaNonUnitBuildingId"] = value; }
        }
        private int vsLpaNonUnitFacilityId
        {
            get { return ViewState["vsLpaNonUnitFacilityId"] == null ? 0 : (int)ViewState["vsLpaNonUnitFacilityId"]; }
            set { ViewState["vsLpaNonUnitFacilityId"] = value; }
        }
        private int vsMarketComparativeContactId
        {
            get { return ViewState["vsMarketComparativeContactId"] == null ? 0 : (int)ViewState["vsMarketComparativeContactId"]; }
            set { ViewState["vsMarketComparativeContactId"] = value; }
        }

        #endregion

        #region Session
        private LpaService sessLpa
        {
            get { return Session["sessLpa"] == null ? new LpaService() : (LpaService)Session["sessLpa"]; }
            set { Session["sessLpa"] = value; }
        }
        private NISPWebLogin sessNISPWebLogin
        {
            get { return Session["sessNISPWebLogin"] == null ? null : (NISPWebLogin)Session["sessNISPWebLogin"]; }
        }
        private OrderCollateralDetailService sessOrderCollateralDetail
        {
            get { return Session["sessOrderCollateralDetail"] == null ? new OrderCollateralDetailService() : (OrderCollateralDetailService)Session["sessOrderCollateralDetail"]; }
            set { Session["sessOrderCollateralDetail"] = value; }
        }
        private int sessLpaIdResultSearch
        {
            get { return Session["sessLpaIdResultSearch"] == null ? 0 : Convert.ToInt32(Session["sessLpaIdResultSearch"]); }
            set { Session["sessLpaIdResultSearch"] = value; }
        }
        private int sessSearchMarketComparativeIdResultSearch
        {
            get { return Session["sessSearchMarketComparativeIdResultSearch"] == null ? 0 : (int)Session["sessSearchMarketComparativeIdResultSearch"]; }
            set { Session["sessSearchMarketComparativeIdResultSearch"] = value; }
        }
        private int sessPostalId
        {
            get { return Session["sessPostalId"] == null ? 0 : Convert.ToInt32(Session["sessPostalId"]); }
            set { Session["sessPostalId"] = value; }
        }
        private int sessVillageId
        {
            get { return Session["sessVillageId"] == null ? 0 : Convert.ToInt32(Session["sessVillageId"]); }
            set { Session["sessVillageId"] = value; }
        }
        #endregion

        #region Variables
        private string qsBackUrl { get { return Request.QueryString["BackUrl"] == null ? "" : Request.QueryString["BackUrl"].ToString(); } }
        private int qsOrderCollateralDetailId
        { get { return Request.QueryString["qsOrderCollateralDetailId"] == null ? 0 : Convert.ToInt32(Request.QueryString["qsOrderCollateralDetailId"]); } }
        public int qsLpaId { get { return Request.QueryString["qsLpaId"] == null ? 0 : Convert.ToInt32(Request.QueryString["qsLpaId"]); } }
        private string qsActionType
        {
            get { return Request.QueryString["ActionType"] == null ? "" : Request.QueryString["ActionType"].ToString(); }
        }
        private int qsCollateralCategoryId
        {
            get { return Request.QueryString["qsCollateralCategoryId"] == null ? 0 : Convert.ToInt32(Request.QueryString["qsCollateralCategoryId"]); }
        }
        private int qsCollateralTypeId
        {
            get { return Request.QueryString["qsCollateralTypeId"] == null ? 0 : Convert.ToInt32(Request.QueryString["qsCollateralTypeId"]); }
        }
        #endregion

        #region Form Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    HttpContext.Current.Response.AppendHeader("Refresh", Convert.ToString(((HttpContext.Current.Session.Timeout * 60) - 10))
                       + "; Url=../Error/SessionTimeOut.htm");

                    sessLpa = null;
                    sessLpaIdResultSearch = 0;
                    sessOrderCollateralDetail = null;
                    sessPostalId = 0;
                    sessSearchMarketComparativeIdResultSearch = 0;

                    #region Load CollateralDetail and LpaComparativeNonunit, Lpa
                    OrderCollateralDetailService oOrderCollateralDetailService = new OrderCollateralDetailService();
                    OrderCollateralDetailServiceClient oOrderCollateralDetailServiceClient = new OrderCollateralDetailServiceClient();

                    try
                    {
                        oOrderCollateralDetailServiceClient.OrderCollateralDetailGet(sessNISPWebLogin.UserName, qsOrderCollateralDetailId,
                            true, out oOrderCollateralDetailService);
                        oOrderCollateralDetailServiceClient.Close();
                        sessOrderCollateralDetail = oOrderCollateralDetailService;

                    }
                    catch (System.ServiceModel.FaultException fe)
                    {
                        if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                        {
                            Response.Redirect("~/Error/SessionTimeOut.htm", true);
                        }
                        else
                        {
                            throw fe;
                        }
                    }
                    #region Set Up Lpa
                    sessLpa = null; 

                    LpaService oLpaService = new LpaService();
                    if (qsLpaId > 0)
                    {
                        #region Load Information
                        try
                        {
                            LpaServiceClient oLpaServiceClientViewMode = new LpaServiceClient();

                            if (oLpaServiceClientViewMode.GetWithNonUnitChild(
                                sessNISPWebLogin.UserName,
                                qsLpaId,
                                out oLpaService) == 1)
                            {
                                sessLpa = oLpaService;

                                #region Bind DropDownList

                                Bind_ddlLpaOrderType();
                                Bind_ddlCollateralType();
                                Bind_ddlCompletionBuildingIdByDeveloper();
                                Bind_ddlCompletionBuilidngByInspection();
                                Bind_ddlPhaseConstruction();
                                Bind_ddlDocumentCalculationTypeForBuilding();
                                Bind_ddlDocumentCalculationTypeForFacility();
                                Bind_ddlDocumentCalculationTypeForLand();
                                Bind_ddlDocumentCalculationForTotalMarketPrice();
                                Bind_ddlDocumentCalculationType();

                                #endregion

                                if (sessLpa.OldLpaId > 0)
                                {
                                    LpaService oLpaServiceOld = new LpaService();
                                    LpaServiceClient oLpaServiceClientOld = new LpaServiceClient();

                                    if (oLpaServiceClientOld.LpaGet(
                                        sessNISPWebLogin.UserName,
                                        sessLpa.OldLpaId,
                                        out oLpaServiceOld) == 1)
                                    {
                                        lblOldLPA.Text = oLpaServiceOld.LpaCode;
                                    }
                                    oLpaServiceClientOld.Close();
                                    oLpaServiceClientOld = null;
                                    oLpaServiceOld = null;
                                }

                                if (sessLpa.LpaNonUnitServices.Count == 0)
                                {
                                    return;
                                }

                                ddlCollateralType.SelectedValue = sessLpa.CollateralType.ToString();
                                lblCollateralType.Text = ddlCollateralType.SelectedItem.ToString();
                                ddlLpaType.SelectedValue = sessLpa.LpaOrderTypeId.ToString();
                                lblLPAType.Text = ddlLpaType.SelectedItem.ToString();
                                lblInvestigateDate.Text = PFSCommon.FormatDate(sessLpa.DocumentInvestigateDate);
                                lblDocumentReportDate.Text = PFSCommon.FormatDate(sessLpa.DocumentReportDate);
                                lblLandArea.Text = sessLpa.LpaNonUnitServices[0].LandArea.ToString();
                                lblWidthStreet.Text = sessLpa.LpaNonUnitServices[0].WidthStreet.ToString();
                                lblNorthernBoundary.Text = sessLpa.LpaNonUnitServices[0].NorthernBoundary;
                                lblSouthernBoundary.Text = sessLpa.LpaNonUnitServices[0].SouthernBoundary;
                                lblEasternBoundary.Text = sessLpa.LpaNonUnitServices[0].EasternBoundary;
                                lblWesternBoundary.Text = sessLpa.LpaNonUnitServices[0].WesternBoundary;
                                lblAreaPosition.Text = sessLpa.LpaNonUnitServices[0].AreaPosition;
                                lblCluster.Text = sessLpa.LpaNonUnitServices[0].Cluster;
                                lblKomplek.Text = sessLpa.LpaNonUnitServices[0].Residential == true ? "Ya" : "Tidak";
                                lblBuildingFloor.Text = sessLpa.LpaNonUnitServices[0].BuildingFloor.ToString();
                                lblDeveloperName.Text = sessLpa.LpaNonUnitServices[0].DeveloperName;
                                lblInTouchPersonName.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonName;
                                lblInTouchPersonPosition.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonPosition;

                                if (sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByDeveloper > 0)
                                {
                                    lblCompletionBuilidngByDeveloper.Text = sessLpa.LpaNonUnitServices[0].CompletionBuildingDescriptionByDeveloper;
                                }

                                if (sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByInspection > 0)
                                {
                                    lblCompletionBuilidngByInspection.Text = sessLpa.LpaNonUnitServices[0].CompletionBuildingDescriptionByInspection;
                                }

                                if (sessLpa.LpaNonUnitServices[0].PhaseConstructionId > 0)
                                {
                                    lblPhaseConstruction.Text = sessLpa.LpaNonUnitServices[0].PhaseConstructionDescription;
                                }

                                lblProgressConstruction.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].ProgressConstruction); 

                                CalculateTotalMarketPrice();

                                if (qsActionType == "View")
                                {
                                    btnSave.Visible = false;
                                    btnSaveAsDraft.Visible = false;
                                    btnPending.Visible = false;
                                    btAddNewBuildingDescription.Visible = false;
                                    btAddNewBuildingNegativeFactor.Visible = false;
                                    btAddNewBuildingPositiveFactor.Visible = false;
                                    btAddNewLandDescription.Visible = false;
                                    btAddNewLandNegativeFactor.Visible = false;
                                    btAddNewLandPositiveFactor.Visible = false;
                                    btAddNewLpaNonUnitContactPerson.Visible = false;
                                    btAddNewLpaNonUnitFacilityBuilding.Visible = false;
                                    btAddNewOpinion.Visible = false;
                                    btAddNewSpecialInformation.Visible = false;
                                    rtbLiquidationFactor.Enabled = false;

                                    lbtAddCertificate.Text = "click to view detail";
                                    lbtAddDataBuilding.Text = "click to view detail";
                                    lbtAddFacility.Text = "click to view detail";
                                    lbtAddLandData.Text = "click to view detail";
                                    lbtAddMarketComparative.Text = "click to view detail";
                                    lbtAddNewValueBuilding.Text = "click to view detail";
                                    lbtAddNonUnitBuilding.Text = "click to view detail";
                                    lbtAddNonUnitFacility.Text = "click to view detail";
                                    lbtAddNonUnitLand.Text = "click to view detail";
                                    lbtAddTaxLand.Text = "click to view detail";
                                    lbtAddTotalMarketPrice.Text = "click to view detail";
                                    lbtAddValueLand.Text = "click to view detail";
                                    lbtLPAInformation.Text = "click to view detail";
                                }
                            }
                        }
                        catch (System.ServiceModel.FaultException fe)
                        {
                            if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                            {
                                Response.Redirect("~/Error/SessionTimeOut.htm", true);
                            }
                            else
                            {
                                throw fe;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        oLpaService.LpaNonUnitServices = new List<LpaNonUnitService>();
                        oLpaService.LpaNonUnitServices.Add(new LpaNonUnitService());
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitCertificateServices = new List<LpaNonUnitCertificateService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices = new List<LpaNonUnitDataBuildingService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices = new List<LpaNonUnitFacilityBuildingService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitLandServices = new List<LpaNonUnitLandService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitBuildingServices = new List<LpaNonUnitBuildingService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitFacilityServices = new List<LpaNonUnitFacilityService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitTaxLandServices = new List<LpaNonUnitTaxLandService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices = new List<LpaNonUnitTotalMarketPriceService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitOpinionServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices = new List<LpaDescriptionService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitContactServices = new List<LpaContactService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitLandServices = new List<LpaNonUnitLandService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitBuildingServices = new List<LpaNonUnitBuildingService>();
                        oLpaService.LpaNonUnitServices[0].LpaNonUnitFacilityServices = new List<LpaNonUnitFacilityService>();

                        oLpaService.LpaComparativeNonunitServices = new List<LpaComparativeNonunitService>();
                    }

                    #endregion

                    if (qsLpaId <= 0)
                    {
                        #region Bind Data Market Comparative
                        foreach (WebService.OrderComparativeNonUnitService oOrderComparativeNonUnitService in oOrderCollateralDetailService.OrderComparativeNonUnitServices)
                        {
                            LpaComparativeNonunitService oLpaComparativeNonunitService = new LpaComparativeNonunitService();
                            oLpaComparativeNonunitService.ComparativeNonUnitAddress1 = oOrderComparativeNonUnitService.CollateralAddress1;
                            oLpaComparativeNonunitService.ComparativeNonUnitAddress2 = oOrderComparativeNonUnitService.CollateralAddress2;
                            oLpaComparativeNonunitService.ComparativeNonUnitAddress3 = oOrderComparativeNonUnitService.CollateralAddress3;
                            oLpaComparativeNonunitService.ComparativeNonUnitAmount = oOrderComparativeNonUnitService.SellingPriceLocalCurrency;
                            oLpaComparativeNonunitService.ComparativeNonUnitAreaPosition = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitBuildingArea = oOrderComparativeNonUnitService.BuildingArea;
                            oLpaComparativeNonunitService.ComparativeNonUnitCluster = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitCondition = oOrderComparativeNonUnitService.DataCondition;
                            oLpaComparativeNonunitService.ComparativeNonUnitCreatedYear = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitDataPercentage = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitDataSource = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitDataSourceDescription = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitDataStatus = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitDataStatusDescription = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitDepreciation = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitDescription = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitDirection = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitDiscountRecommended = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitFurnishPrice = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitIsRegency = false;
                            oLpaComparativeNonunitService.ComparativeNonUnitLandArea = oOrderComparativeNonUnitService.LandArea;
                            oLpaComparativeNonunitService.ComparativeNonUnitLegality = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitMarketingName = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitMarketingPhone = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitNewBuildingPrice = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitPosition = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitRadius = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitRangeArea = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitRenovationYear = "";
                            oLpaComparativeNonunitService.ComparativeNonUnitSellingDate = DateTime.Now;
                            oLpaComparativeNonunitService.ComparativeNonUnitSellingPriceDiscount = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitSellingPriceHomeCurrency = 0;
                            oLpaComparativeNonunitService.ComparativeNonUnitWidthStreet = 0;
                            oLpaComparativeNonunitService.CreateByUserId = "";
                            oLpaComparativeNonunitService.CreateDate = DateTime.Now;
                            oLpaComparativeNonunitService.LpaComparativeNonUnitId = vsLpaComparativeNonUnitId = vsLpaComparativeNonUnitId - 1;
                            oLpaComparativeNonunitService.RefDatabaseId = oOrderComparativeNonUnitService.RefDatabaseId;
                            oLpaComparativeNonunitService.RefOrderCollateralDetailId = qsOrderCollateralDetailId;
                            oLpaComparativeNonunitService.LpaContactComparativeServices = new List<LpaContactComparativeService>();

                            foreach (WebService.OrderContactComparativeService oOrderContactComparativeService in oOrderComparativeNonUnitService.OrderContactComparativeServices)
                            {
                                oLpaComparativeNonunitService.ComparativeNonUnitMarketingName = oOrderContactComparativeService.OrderContactComparativeName;

                                if ((oOrderContactComparativeService.OrderContactComparativeMobileNo != ""
                                || oOrderContactComparativeService.OrderContactComparativeMobileNo != "-")
                                && (oOrderContactComparativeService.OrderContactComparativePhoneNo != ""
                                    || oOrderContactComparativeService.OrderContactComparativePhoneNo != "-"))
                                {
                                    oLpaComparativeNonunitService.ComparativeNonUnitMarketingPhone =
                                        string.Format("{0} / {1}", oOrderContactComparativeService.OrderContactComparativePhoneNo, oOrderContactComparativeService.OrderContactComparativeMobileNo);
                                }
                                else if (oOrderContactComparativeService.OrderContactComparativeMobileNo == ""
                                    || oOrderContactComparativeService.OrderContactComparativeMobileNo == "-")
                                {
                                    oLpaComparativeNonunitService.ComparativeNonUnitMarketingPhone = oOrderContactComparativeService.OrderContactComparativePhoneNo;
                                }
                                else if (oOrderContactComparativeService.OrderContactComparativePhoneNo == ""
                                    || oOrderContactComparativeService.OrderContactComparativePhoneNo == "-")
                                {
                                    oLpaComparativeNonunitService.ComparativeNonUnitMarketingPhone = oOrderContactComparativeService.OrderContactComparativeMobileNo;
                                }
                                break;

                            }

                            oLpaService.LpaComparativeNonunitServices.Add(oLpaComparativeNonunitService);
                            oLpaComparativeNonunitService = null;
                        }
                        #endregion

                        #region Load Document

                        if (sessOrderCollateralDetail.OrderDocumentServices != null || sessOrderCollateralDetail.OrderDocumentServices.Count > 0)
                        {
                            foreach (OrderDocumentService oOrderDocumentService in sessOrderCollateralDetail.OrderDocumentServices)
                            {
                                if (oOrderDocumentService.DocumentTypeId == (int)Enumeration.SetupDocumentType.Sertifikat)
                                {
                                    LpaNonUnitCertificateService oLpaNonUnitCertificateService = new LpaNonUnitCertificateService();
                                    oLpaNonUnitCertificateService.CertificateDate = DateTime.Parse("1900/1/1");
                                    oLpaNonUnitCertificateService.LpaNonUnitCertificateId = vsLpaUnitCertificateId = vsLpaUnitCertificateId - 1;
                                    oLpaNonUnitCertificateService.CertificateName = oOrderDocumentService.OrderDocumentAliasName;
                                    oLpaNonUnitCertificateService.CertificateNo = oOrderDocumentService.OrderDocumentCode;
                                    oLpaNonUnitCertificateService.DocumentBlueprintDate = DateTime.Parse("1900/1/1");
                                    oLpaNonUnitCertificateService.DocumentSurveyCertificateDate = DateTime.Parse("1900/1/1");
                                    oLpaNonUnitCertificateService.CertificateExpiredDate = oOrderDocumentService.OrderDocumentDate;

                                    oLpaService.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Add(oLpaNonUnitCertificateService);
                                    oLpaNonUnitCertificateService = null;
                                }
                                else if (oOrderDocumentService.DocumentTypeId == (int)Enumeration.SetupDocumentType.IjinBangunan)
                                {
                                    LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService = new LpaNonUnitDataBuildingService();
                                    oLpaNonUnitDataBuildingService.LpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId - 1;
                                    oLpaNonUnitDataBuildingService.LpaNonUnitDataBuildingPermitsBuildingType = oOrderDocumentService.OrderDocumentAliasName;
                                    oLpaNonUnitDataBuildingService.CreateDate = oLpaNonUnitDataBuildingService.UpdateDate = DateTime.Now;
                                    oLpaNonUnitDataBuildingService.CreateByUserId = oLpaNonUnitDataBuildingService.UpdateByUserId = sessNISPWebLogin.UserName;
                                    oLpaNonUnitDataBuildingService.BuildingPermitsCreateDate = new DateTime(1900, 1, 1);

                                    oLpaService.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.Add(oLpaNonUnitDataBuildingService);
                                    oLpaNonUnitDataBuildingService = null;
                                }
                            }
                        }
                        #endregion

                        #region Load Spesification Building

                        try
                        {
                            List<SetupSpesificationBuildingService> oSetupSpesificationBuildingServiceList = new List<SetupSpesificationBuildingService>();
                            SetupSpesificationBuildingServiceClient oSetupSpesificationBuildingServiceClient = new SetupSpesificationBuildingServiceClient();

                            oSetupSpesificationBuildingServiceClient.SetupSpesificationBuildingList(
                                sessNISPWebLogin.UserName,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                null,
                                out oSetupSpesificationBuildingServiceList);

                            foreach (SetupSpesificationBuildingService oSetupSpesificationBuildingService in oSetupSpesificationBuildingServiceList)
                            {
                                LpaNonUnitFacilityBuildingService oLpaNonUnitFacilityBuildingService = new LpaNonUnitFacilityBuildingService();
                                oLpaNonUnitFacilityBuildingService.FacilityAliasName = oSetupSpesificationBuildingService.SpesificationBuildingName;
                                oLpaNonUnitFacilityBuildingService.FacilityDescription = "";
                                oLpaNonUnitFacilityBuildingService.LpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId - 1;

                                oLpaService.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices.Add(oLpaNonUnitFacilityBuildingService);

                                oLpaNonUnitFacilityBuildingService = null;
                            }
                        }
                        catch (System.ServiceModel.FaultException fe)
                        {
                            if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                            {
                                Response.Redirect("~/Error/SessionTimeOut.htm", true);
                            }
                            else
                            {
                                throw fe;
                            }
                        }
                        #endregion

                        #region Load Contact Person

                        if (sessOrderCollateralDetail.OrderContactServices != null && sessOrderCollateralDetail.OrderContactServices.Count > 0)
                        {
                            foreach (OrderContactService oOrderContactService in sessOrderCollateralDetail.OrderContactServices)
                            {
                                LpaContactService oLpaContactService = new LpaContactService();
                                oLpaContactService.LpaContactId = vsLpaNonUnitContactId = vsLpaNonUnitContactId - 1;
                                oLpaContactService.LpaContactMobileNo = oOrderContactService.OrderContactHandphone;
                                oLpaContactService.LpaContactName = oOrderContactService.OrderContactName;
                                oLpaContactService.LpaContactPhoneNo = oOrderContactService.OrderContactTelephone;
                                oLpaContactService.CreateByUserId = sessNISPWebLogin.UserName;
                                oLpaContactService.UpdateByUserId = sessNISPWebLogin.UserName;
                                oLpaContactService.CreateDate = oLpaContactService.UpdateDate = DateTime.Now;
                                oLpaContactService.RefId = qsCollateralCategoryId;
                                oLpaService.LpaNonUnitServices[0].LpaNonUnitContactServices.Add(oLpaContactService);

                                oLpaContactService = null;
                            }
                        }
                        #endregion

                        if (qsCollateralTypeId != 0)
                            oLpaService.CollateralType = qsCollateralTypeId;

                        if (qsCollateralCategoryId != 0)
                            oLpaService.CollateralCategory = qsCollateralCategoryId;

                        sessLpa = oLpaService;

                        #region Bind DropDownList

                        Bind_ddlLpaOrderType();
                        Bind_ddlCollateralType();
                        Bind_ddlCompletionBuildingIdByDeveloper();
                        Bind_ddlCompletionBuilidngByInspection();
                        Bind_ddlPhaseConstruction();
                        Bind_ddlDocumentCalculationTypeForBuilding();
                        Bind_ddlDocumentCalculationTypeForFacility();
                        Bind_ddlDocumentCalculationTypeForLand();
                        Bind_ddlDocumentCalculationForTotalMarketPrice();
                        Bind_ddlDocumentCalculationType();                    

                        #endregion
                    }

                    ddlLpaType.SelectedValue = Convert.ToString((int)Enumeration.LpaOrderType.NewLpa);
                    ddlLpaType.Enabled = false;

                    lblLPAType.Text = ddlLpaType.SelectedItem.Text; 
             
                    #endregion

                    if (sessLpa.CollateralCategory != (int)Enumeration.DatabaseCollateralCategory.NonUnitProgressBangunan)
                    {
                        colCompletionDeveloper.Attributes.Add("style", "display:none;");
                        colProgressConstruction.Attributes.Add("style", "display:none;");
                        colBuildingFloor.Attributes.Add("style", "display:none;");
                        colInTouchPersonName.Attributes.Add("style", "display:none;");
                        rfvddlCompletionBuilidngByInspection.Enabled = false;
                        rfvddlCompletionBuildingIdByDeveloper.Enabled = false;
                        rfvddlPhaseConstruction.Enabled = false;
                        rfvtbProgressConstruction.Enabled = false;
                        rfvtbBuildingFloor.Enabled = false;
                        rfvtbDeveloperName.Enabled = false;
                        rfvInTouchPersonName.Enabled = false;
                        rfvtbInTouchPersonPosition.Enabled = false;
                        InspectionInput.Attributes.Add("style", "display:none;");
                        DeveloperInput.Attributes.Add("style", "display:none;");
                        ContructionInput.Attributes.Add("style", "display:none;");
                        ProgressInput.Attributes.Add("style", "display:none;");
                        BuildingFloorInput.Attributes.Add("style", "display:none;");
                        DeveloperNameInput.Attributes.Add("style", "display:none;");
                        InTouchPersonNameInput.Attributes.Add("style", "display:none;");
                        InTouchPersonPositionInput.Attributes.Add("style", "display:none;");
                    }

                    Bind_ddlSourceDataDescription();
                    Bind_ddlStatusDataDescription();

                    SetupCollateralCategoryService oSetupCollateralCategoryService = new SetupCollateralCategoryService();
                    SetupCollateralCategoryServiceClient oSetupCollateralCategoryServiceClient = new SetupCollateralCategoryServiceClient();

                    try
                    {
                        oSetupCollateralCategoryServiceClient.SetupCollateralCategoryGet(sessNISPWebLogin.UserName, sessLpa.CollateralCategory,
                            out oSetupCollateralCategoryService);
                        oSetupCollateralCategoryServiceClient.Close();
                    }
                    catch (System.ServiceModel.FaultException fe)
                    {
                        if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                        {
                            Response.Redirect("~/Error/SessionTimeOut.htm", true);
                        }
                        else
                        {
                            throw fe;
                        }
                    }
                    lblCollateralCategory.Text = oSetupCollateralCategoryService.SetupCollateralCategoryName;

                    OrderCollateralService oOrderCollateralService = new OrderCollateralService();
                    OrderCollateralServiceClient oOrderCollateralServiceClient = new OrderCollateralServiceClient();

                    try
                    {
                        oOrderCollateralServiceClient.OrderCollateralGet(
                            sessNISPWebLogin.UserName,
                            sessOrderCollateralDetail.OrderCollateralId,
                            false,
                            out oOrderCollateralService);
                    }
                    catch (System.ServiceModel.FaultException fe)
                    {
                        if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                        {
                            Response.Redirect("~/Error/SessionTimeOut.htm", true);
                        }
                        else
                        {
                            throw fe;
                        }
                    }
                    rdpDocumentInvestigateDate.MaxDate = DateTime.Now;
                    if (oOrderCollateralService.SubmitDate.Date > new DateTime(1900, 1, 1))
                    {
                        rdpDocumentInvestigateDate.MinDate = oOrderCollateralService.SubmitDate.Date;
                    }

                    #region Cek Order Arm Or not

                    if (!oOrderCollateralService.IsArm)
                    {
                        liquidationFactor.Style.Add("display", "none");
                        totalLiquidationFactor.Style.Add("display", "none");
                        lbtAddTotalMarketPrice.Visible = false;
                    }

                    #endregion

                    //rdpDocumentReportDate.MaxDate = DateTime.Now;
                    rdpCertificateDate.MinDate = new DateTime(1900, 1, 1);
                    rdpDocumentSurveyCertificateDate.MinDate = new DateTime(1900, 1, 1);
                    rdpDocumentBlueprintDate.MinDate = new DateTime(1900, 1, 1);
                    rdpPermitsDate.MinDate = new DateTime(1900, 1, 1);
                    rdpCertificateDate.MaxDate = DateTime.Now;
                    rdpPermitsDate.MaxDate = DateTime.Now;
                    rdpDocumentBlueprintDate.MaxDate = DateTime.Now;

                    if (ddlDocumentCalculationForTotalMarketPrice.SelectedValue != null)
                    {
                        int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);

                        LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService = null;
                        oLpaNonUnitTotalMarketPriceService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices
                            .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                        if (oLpaNonUnitTotalMarketPriceService != null)
                        {
                            lblTotalMarketPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.TotalMarketPrice);
                            lblLiquidationAmount.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationAmount);
                            lblLiquidationValuePercentage.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage);
                        }
                    }

                    btnOldLpa.OnClientClick = string.Format("return PopupSearchLpa('{0}{1}')",
                        "../PopUp/PopUpSearchLpa.aspx?qsCollateralCategoryId=",
                        (int)ProTaksatur.WebUI.App_Code.Enumeration.DatabaseCollateralCategory.NonUnit);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnReloadLpaData_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    LpaService oLpaService = new LpaService();
                    LpaServiceClient oLpaServiceClient = new LpaServiceClient();
                    if (oLpaServiceClient.GetWithNonUnitChild(
                        sessNISPWebLogin.UserName,
                        sessLpaIdResultSearch,
                        out oLpaService) == 1)
                    {
                        tbOldLPA.Text = oLpaService.LpaCode;
                    }

                    oLpaServiceClient.Close();
                    oLpaService = null;
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnReloadGridMarketComparative_Click(object sender, EventArgs e)
        {
            try
            {
                rgMarketComparative.Rebind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void lbtCompareMarketComparative_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                showDialog("CompareMarketComparativeNonUnit.aspx?qsLPANo=" + this.lblLpaNo.Text + "&ActionType=" + qsActionType);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", ProTaksatur.WebUI.App_Code.GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #region Form LPAInformation
        protected void ddlLpaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (ddlLpaType.SelectedValue != null)
                {
                    if (ddlLpaType.SelectedValue == Convert.ToString((int)ProTaksatur.WebUI.App_Code.Enumeration.LpaOrderType.NewLpa))
                        btnOldLpa.Enabled = false;
                    else
                        btnOldLpa.Enabled = true;
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rdpDocumentInvestigateDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rdpDocumentInvestigateDate.SelectedDate != null)
                {
                    rdpDocumentReportDate.MinDate = rdpDocumentInvestigateDate.SelectedDate.Value;
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void lbtAddLPAInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                tbOldLPA.Text = lblOldLPA.Text;

                if (sessLpa.CollateralType > 0)
                {
                    //ddlCollateralType.Items.FindByValue(sessLpa.CollateralType.ToString()).Selected = true;
                    ddlCollateralType.SelectedValue = sessLpa.CollateralType.ToString();
                }

                if (sessLpa.DocumentReportDate > new DateTime(1900, 1, 1))
                    rdpDocumentReportDate.SelectedDate = sessLpa.DocumentReportDate;

                if (sessLpa.DocumentInvestigateDate > new DateTime(1900, 1, 1))
                    rdpDocumentInvestigateDate.SelectedDate = sessLpa.DocumentInvestigateDate;

                lblCollateralCategoryEntry.Text = lblCollateralCategory.Text;

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    btnSaveLPAInformation.Visible = false;
                    ddlLpaType.Enabled = false;
                    ddlCollateralType.Enabled = false;
                    rdpDocumentReportDate.Enabled = false;
                    rdpDocumentInvestigateDate.Enabled = false;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaInformation');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveLPAInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpaIdResultSearch > 0)
                {
                    #region Load Old Lpa
                    LpaService oLpaService = new LpaService();
                    LpaServiceClient oLpaServiceClient = new LpaServiceClient();

                    if (oLpaServiceClient.GetWithNonUnitChild(
                        sessNISPWebLogin.UserName,
                        sessLpaIdResultSearch,
                        out oLpaService) == 1)
                    {

                        sessLpa = oLpaService;
                        sessLpa.LpaId = qsLpaId;

                        if (sessLpa.LpaNonUnitServices != null)
                        {
                            foreach (LpaNonUnitService oLpaNonUnitService in sessLpa.LpaNonUnitServices)
                            {
                                oLpaNonUnitService.LpaNonUnitId = -1;

                                #region Building Descirpiton
                                if (oLpaNonUnitService.LpaNonUnitBuildingDescriptionServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitBuildingDescriptionService in oLpaNonUnitService.LpaNonUnitBuildingDescriptionServices)
                                    {
                                        oLpaNonUnitBuildingDescriptionService.LpaDescriptionId = vsLpaNonUnitBuildingDescriptionId = vsLpaNonUnitBuildingDescriptionId - 1;
                                    }
                                }
                                #endregion

                                #region Building Negatif Factor
                                if (oLpaNonUnitService.LpaNonUnitBuildingNegativeFactorServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitBuildingNegativeFactorService in oLpaNonUnitService.LpaNonUnitBuildingNegativeFactorServices)
                                    {
                                        oLpaNonUnitBuildingNegativeFactorService.LpaDescriptionId = vsLpaNonUnitBuildingNegativeId = vsLpaNonUnitBuildingNegativeId - 1;
                                    }
                                }

                                #endregion

                                #region BUilding Positif Factor
                                if (oLpaNonUnitService.LpaNonUnitBuildingPositiveFactorServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitBUildingPositifFactorService in oLpaNonUnitService.LpaNonUnitBuildingPositiveFactorServices)
                                    {
                                        oLpaNonUnitBUildingPositifFactorService.LpaDescriptionId = vsLpaNonUnitBuildingPostiveId = vsLpaNonUnitBuildingPostiveId - 1;
                                    }
                                }
                                #endregion

                                #region Data Certificate
                                if (oLpaNonUnitService.LpaNonUnitCertificateServices != null)
                                {
                                    foreach (LpaNonUnitCertificateService oLpaNonUnitCertificateService in oLpaNonUnitService.LpaNonUnitCertificateServices)
                                    {
                                        oLpaNonUnitCertificateService.LpaNonUnitCertificateId = vsLpaUnitCertificateId = vsLpaUnitCertificateId - 1;
                                    }
                                }

                                #endregion

                                #region Contact Service

                                if (oLpaNonUnitService.LpaNonUnitContactServices != null)
                                {
                                    foreach (LpaContactService oLpaContactService in oLpaNonUnitService.LpaNonUnitContactServices)
                                    {
                                        oLpaContactService.LpaContactId = vsLpaNonUnitContactId = vsLpaNonUnitContactId - 1;
                                    }
                                }
                                #endregion

                                #region Data BUilding
                                if (oLpaNonUnitService.LpaNonUnitDataBuildingServices != null)
                                {
                                    foreach (LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService in oLpaNonUnitService.LpaNonUnitDataBuildingServices)
                                    {
                                        oLpaNonUnitDataBuildingService.LpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId - 1;
                                    }
                                }
                                #endregion

                                #region Facility Building
                                if (oLpaNonUnitService.LpaNonUnitFacilityBuildingServices != null)
                                {
                                    foreach (LpaNonUnitFacilityBuildingService oLpaNonUnitFacilityBuildingService in oLpaNonUnitService.LpaNonUnitFacilityBuildingServices)
                                    {
                                        oLpaNonUnitFacilityBuildingService.LpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId - 1;
                                    }
                                }
                                #endregion

                                #region Land Description
                                if (oLpaNonUnitService.LpaNonUnitLandDescriptionServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitLandDescriptionServices in oLpaNonUnitService.LpaNonUnitLandDescriptionServices)
                                    {
                                        oLpaNonUnitLandDescriptionServices.LpaDescriptionId = vsLpaNonUnitLandDescriptionId = vsLpaNonUnitLandDescriptionId - 1;
                                    }
                                }
                                #endregion

                                #region Land Negative
                                if (oLpaNonUnitService.LpaNonUnitLandNegativeFactorServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitLandNegativeFactorServices in oLpaNonUnitService.LpaNonUnitLandNegativeFactorServices)
                                    {
                                        oLpaNonUnitLandNegativeFactorServices.LpaDescriptionId = vsLpaNonUnitLandNegativeId = vsLpaNonUnitLandNegativeId - 1;
                                    }
                                }
                                #endregion

                                #region Land Positif Factor
                                if (oLpaNonUnitService.LpaNonUnitLandPositiveFactorServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitLandPositiveFactorServices in oLpaNonUnitService.LpaNonUnitLandPositiveFactorServices)
                                    {
                                        oLpaNonUnitLandPositiveFactorServices.LpaDescriptionId = vsLpaNonUnitLandPostiveId = vsLpaNonUnitLandPostiveId - 1;
                                    }
                                }
                                #endregion

                                #region Opinion
                                if (oLpaNonUnitService.LpaNonUnitOpinionServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitOpinionServices in oLpaNonUnitService.LpaNonUnitOpinionServices)
                                    {
                                        oLpaNonUnitOpinionServices.LpaDescriptionId = vsLpaNonUnitOpinionId = vsLpaNonUnitOpinionId - 1;
                                    }
                                }
                                #endregion

                                #region Special Information
                                if (oLpaNonUnitService.LpaNonUnitSpecialInformationServices != null)
                                {
                                    foreach (LpaDescriptionService oLpaNonUnitSpecialInformationServices in oLpaNonUnitService.LpaNonUnitSpecialInformationServices)
                                    {
                                        oLpaNonUnitSpecialInformationServices.LpaDescriptionId = vsLpaNonUnitSpecialInformationId = vsLpaNonUnitSpecialInformationId - 1;
                                    }
                                }
                                #endregion

                                #region Tax Land
                                if (oLpaNonUnitService.LpaNonUnitTaxLandServices != null)
                                {
                                    foreach (LpaNonUnitTaxLandService oLpaNonUnitTaxLandService in oLpaNonUnitService.LpaNonUnitTaxLandServices)
                                    {
                                        oLpaNonUnitTaxLandService.LpaNonUnitTaxLandId = vsLpaNonUnitTaxLandId = vsLpaNonUnitTaxLandId - 1;
                                    }
                                }
                                #endregion

                                #region Total MArket Price
                                if (oLpaNonUnitService.LpaNonUnitTotalMarketPriceServices != null)
                                {
                                    foreach (LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService in oLpaNonUnitService.LpaNonUnitTotalMarketPriceServices)
                                    {
                                        oLpaNonUnitTotalMarketPriceService.LpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId - 1;
                                    }
                                }
                                #endregion

                                #region NonUnit Building
                                if (oLpaNonUnitService.LpaNonUnitBuildingServices != null)
                                {
                                    foreach (LpaNonUnitBuildingService oLpaNonUnitBuildingService in oLpaNonUnitService.LpaNonUnitBuildingServices)
                                    {
                                        oLpaNonUnitBuildingService.LpaNonUnitBuildingId = vsLpaNonUnitBuildingId = vsLpaNonUnitBuildingId - 1;

                                        if (oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices != null)
                                        {
                                            foreach (LpaNonUnitValueBuildingService oLpaNonUnitValueBuildingService in oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices)
                                            {
                                                oLpaNonUnitValueBuildingService.LpaNonUnitValueBuildingId = vsLpaNonUnitValueBuildingId = vsLpaNonUnitValueBuildingId - 1;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                #region Facility
                                if (oLpaNonUnitService.LpaNonUnitFacilityServices != null)
                                {
                                    foreach (LpaNonUnitFacilityService oLpaNonUnitFacilityService in oLpaNonUnitService.LpaNonUnitFacilityServices)
                                    {
                                        oLpaNonUnitFacilityService.LpaNonUnitFacilityId = vsLpaNonUnitFacilityId = vsLpaNonUnitFacilityId - 1;

                                        if (oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices != null)
                                        {
                                            foreach (LpaNonUnitValueFacilityService oLpaNonUnitValueFacilityService in oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices)
                                            {
                                                oLpaNonUnitValueFacilityService.LpaNonUnitValueFacilityId = vsLpaNonUnitFacilityId = vsLpaNonUnitFacilityId - 1;
                                            }
                                        }
                                    }
                                }
                                #endregion

                                #region Value Land
                                if (oLpaNonUnitService.LpaNonUnitLandServices != null)
                                {
                                    foreach (LpaNonUnitLandService oLpaNonUnitLandService in oLpaNonUnitService.LpaNonUnitLandServices)
                                    {
                                        oLpaNonUnitLandService.LpaNonUnitLandId = vsLpaNonUnitLandId = vsLpaNonUnitLandId - 1;

                                        if (oLpaNonUnitLandService.LpaNonUnitValueLandServices != null)
                                        {
                                            foreach (LpaNonUnitValueLandService oLpaNonUnitValueLandService in oLpaNonUnitLandService.LpaNonUnitValueLandServices)
                                            {
                                                oLpaNonUnitValueLandService.LpaNonUnitValueLandId = vsLpaNonUnitValueLandId = vsLpaNonUnitValueLandId - 1;
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                        }

                        rgBuildingDescription.Rebind();
                        rgBuildingNegativeFactor.Rebind();
                        rgBuildingPositiveFactor.Rebind();
                        rgDataBuilding.Rebind();
                        rgLandDescription.Rebind();
                        rgLandNegativeFactor.Rebind();
                        rgLandPositiveFactor.Rebind();
                        rgLpaNonUnitCertificate.Rebind();
                        rgLpaNonUnitContactPerson.Rebind();
                        rgLpaNonUnitFacilityBuilding.Rebind();
                        rgValueBuilding.Rebind();
                        rgValueFacility.Rebind();
                        rgValueLand.Rebind();
                        rgMarketComparative.Rebind();
                        rgOpinion.Rebind();
                        rgSpecialInformation.Rebind();
                        rgTaxLand.Rebind();

                        lblLandArea.Text = sessLpa.LpaNonUnitServices[0].LandArea.ToString();
                        lblWidthStreet.Text = sessLpa.LpaNonUnitServices[0].WidthStreet.ToString();
                        lblNorthernBoundary.Text = sessLpa.LpaNonUnitServices[0].NorthernBoundary;
                        lblSouthernBoundary.Text = sessLpa.LpaNonUnitServices[0].SouthernBoundary;
                        lblEasternBoundary.Text = sessLpa.LpaNonUnitServices[0].EasternBoundary;
                        lblWesternBoundary.Text = sessLpa.LpaNonUnitServices[0].WesternBoundary;
                        lblAreaPosition.Text = sessLpa.LpaNonUnitServices[0].AreaPosition;
                        lblCluster.Text = sessLpa.LpaNonUnitServices[0].Cluster;
                        lblKomplek.Text = sessLpa.LpaNonUnitServices[0].Residential == true ? "Ya" : "Tidak";

                        if (sessLpa.LpaNonUnitServices[0].LandArea > 0)
                            rtbLandArea.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].LandArea);

                        if (sessLpa.LpaNonUnitServices[0].WidthStreet > 0)
                            rtbWidthStreet.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].WidthStreet);

                        tbNorthernBoundary.Text = sessLpa.LpaNonUnitServices[0].NorthernBoundary;
                        tbSouthernBoundary.Text = sessLpa.LpaNonUnitServices[0].SouthernBoundary;
                        tbEasternBoundary.Text = sessLpa.LpaNonUnitServices[0].EasternBoundary;
                        tbWesternBoundary.Text = sessLpa.LpaNonUnitServices[0].WesternBoundary;
                        tbAreaPosition.Text = sessLpa.LpaNonUnitServices[0].AreaPosition;
                        tbCluster.Text = sessLpa.LpaNonUnitServices[0].Cluster;

                        if (sessLpa.LpaNonUnitServices[0].Residential)
                            rdbTrueKomplek.Checked = true;
                        else
                            rdbFalseKomplek.Checked = true;

                        lblPhaseConstruction.Text = sessLpa.LpaNonUnitServices[0].PhaseConstructionDescription;
                        lblCompletionBuilidngByDeveloper.Text = sessLpa.LpaNonUnitServices[0].CompletionBuildingDescriptionByDeveloper;
                        lblCompletionBuilidngByInspection.Text = sessLpa.LpaNonUnitServices[0].CompletionBuildingDescriptionByInspection;
                        lblProgressConstruction.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].ProgressConstruction);
                        lblBuildingFloor.Text = sessLpa.LpaNonUnitServices[0].BuildingFloor.ToString();
                        lblDeveloperName.Text = sessLpa.LpaNonUnitServices[0].DeveloperName;
                        lblInTouchPersonName.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonName;
                        lblInTouchPersonPosition.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonPosition;

                    }
                    sessLpaIdResultSearch = 0;

                    #endregion
                }

                lblOldLPA.Text = tbOldLPA.Text;
                if (ddlLpaType.SelectedValue != null)
                {
                    sessLpa.LpaOrderTypeId = Convert.ToInt32(ddlLpaType.SelectedValue);
                }
                sessLpa.DocumentReportDate = rdpDocumentReportDate.SelectedDate.Value;
                sessLpa.DocumentInvestigateDate = rdpDocumentInvestigateDate.SelectedDate.Value;
                if (ddlCollateralType.SelectedValue != null)
                {
                    sessLpa.CollateralType = Convert.ToInt32(ddlCollateralType.SelectedValue);
                }
                else
                {
                    sessLpa.CollateralType = 0;
                }
                lblOldLPA.Text = tbOldLPA.Text;
                lblLPAType.Text = ddlLpaType.SelectedItem.Text;
                lblDocumentReportDate.Text = PFSCommon.FormatDate(rdpDocumentReportDate.SelectedDate.Value);
                lblInvestigateDate.Text = PFSCommon.FormatDate(rdpDocumentInvestigateDate.SelectedDate.Value);
                lblCollateralType.Text = ddlCollateralType.SelectedItem.Text;

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                tbOldLPA.Text = "";
                sessLpaIdResultSearch = 0;

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Form Certificate
        protected void lbtAddCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                string sNavigatePopUp = "../PopUp/PopUpSearchMaster.aspx?";
                btnCertificateZipCode.OnClientClick = string.Format("return openRadWindowGeneral('{0}Master={1}&ClientId={2}')",
                       sNavigatePopUp, ProTaksatur.WebUI.App_Code.Enumeration.PopUpSearch.Postal.ToString(), tbCertificateZipCode.ClientID);

                btnVillageSearch.OnClientClick = string.Format("return openRadWindowGeneral('{0}Master={1}&ClientId={2}')",
                        sNavigatePopUp, ProTaksatur.WebUI.App_Code.Enumeration.PopUpSearch.Village.ToString(), tbCertificateVillage.ClientID);

                if (rgLpaNonUnitCertificate.SelectedItems.Count > 0)
                {
                    int iSelectedLpaNonUnitCertificateId = (int)rgLpaNonUnitCertificate.SelectedValues["LpaNonUnitCertificateId"];
                    hfCertificateId.Value = iSelectedLpaNonUnitCertificateId.ToString();
                    LpaNonUnitCertificateService oLpaNonUnitCertificateService = sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices
                        .Where(o => o.LpaNonUnitCertificateId == iSelectedLpaNonUnitCertificateId).FirstOrDefault();
                    tbCertificateName.Text = oLpaNonUnitCertificateService.CertificateName;
                    tbCertificateNo.Text = oLpaNonUnitCertificateService.CertificateNo;
                    tbCertificateVillage.Text = oLpaNonUnitCertificateService.CertificateVillage;
                    if (oLpaNonUnitCertificateService.CertificateDate.Date <= (new DateTime(1900, 1, 1)))
                    {
                        rdpCertificateDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpCertificateDate.SelectedDate = oLpaNonUnitCertificateService.CertificateDate;
                    }
                    if (oLpaNonUnitCertificateService.CertificateExpiredDate.Date <= (new DateTime(1900, 1, 1)))
                    {
                        rdpExpiredDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpExpiredDate.SelectedDate = oLpaNonUnitCertificateService.CertificateExpiredDate;
                    }
                    tbDocumentSurveyCertificateNo.Text = oLpaNonUnitCertificateService.DocumentSurveyCertificateNo;
                    if (oLpaNonUnitCertificateService.DocumentSurveyCertificateDate.Date <= (new DateTime(1900, 1, 1)))
                    {
                        rdpDocumentSurveyCertificateDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpDocumentSurveyCertificateDate.SelectedDate = oLpaNonUnitCertificateService.DocumentSurveyCertificateDate;
                    }
                    tbDocumentBlueprintNo.Text = oLpaNonUnitCertificateService.DocumentBlueprintNo;

                    if (oLpaNonUnitCertificateService.DocumentBlueprintDate.Date <= (new DateTime(1900, 1, 1)))
                    {
                        rdpDocumentBlueprintDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpDocumentBlueprintDate.SelectedDate = oLpaNonUnitCertificateService.DocumentBlueprintDate;
                    }
                    rtbDocumentLandArea.Text = PFSCommon.FormatNumber(oLpaNonUnitCertificateService.DocumentLandArea);
                    tbDocumentOwner.Text = oLpaNonUnitCertificateService.DocumentOwner;
                    tbCertificateAddress1.Text = oLpaNonUnitCertificateService.CertificateAddress1;
                    tbCertificateAddress2.Text = oLpaNonUnitCertificateService.CertificateAddress2;
                    tbCertificateAddress3.Text = oLpaNonUnitCertificateService.CertificateAddress3;
                    tbCertificateSubDistrict.Text = oLpaNonUnitCertificateService.CertificateSubDistrict;
                    tbCertificateCity.Text = oLpaNonUnitCertificateService.CertificateCity;
                    tbCertificateProvince.Text = oLpaNonUnitCertificateService.CertificateProvince;
                    tbCertificateZipCode.Text = oLpaNonUnitCertificateService.CertificateZipCode;
                }
                else
                {
                    hfCertificateId.Value = "0";
                    tbCertificateName.Text = "";
                    tbCertificateNo.Text = "";
                    tbCertificateVillage.Text = "";
                    rdpCertificateDate.SelectedDate = null;
                    rdpDocumentBlueprintDate.SelectedDate = null;
                    rdpExpiredDate.SelectedDate = null;
                    rdpDocumentBlueprintDate.SelectedDate = null;
                    rtbDocumentLandArea.Text = "";
                    rdpDocumentSurveyCertificateDate.SelectedDate = null;
                    tbDocumentSurveyCertificateNo.Text = "";
                    tbDocumentBlueprintNo.Text = "";
                    tbDocumentOwner.Text = "";
                    tbCertificateAddress1.Text = "";
                    tbCertificateAddress2.Text = "";
                    tbCertificateAddress3.Text = "";
                    tbCertificateSubDistrict.Text = "";
                    tbCertificateCity.Text = "";
                    tbCertificateProvince.Text = "";
                    tbCertificateZipCode.Text = "";
                }

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbCertificateName.Enabled = false;
                    tbCertificateNo.Enabled = false;
                    tbCertificateVillage.Enabled = false;
                    rdpCertificateDate.Enabled = false;
                    rtbDocumentLandArea.Enabled = false;
                    tbDocumentOwner.Enabled = false;
                    tbCertificateAddress1.Enabled = false;
                    tbCertificateAddress2.Enabled = false;
                    tbCertificateAddress3.Enabled = false;
                    tbCertificateSubDistrict.Enabled = false;
                    tbCertificateCity.Enabled = false;
                    tbCertificateProvince.Enabled = false;
                    tbCertificateZipCode.Enabled = false;
                    rdpCertificateDate.Enabled = false;
                    rdpDocumentBlueprintDate.Enabled = false;
                    rdpExpiredDate.Enabled = false;
                    tbDocumentSurveyCertificateNo.Enabled = false;
                    tbDocumentBlueprintNo.Enabled = false;
                    rdpDocumentSurveyCertificateDate.Enabled = false;
                    btnDocumentTypeSearch.Enabled = false;
                    btnVillageSearch.Enabled = false;
                    btnSubDistrictSearch.Enabled = false;
                    btnCitySearch.Enabled = false;
                    btnProvinceSearch.Enabled = false;
                    btnCertificateZipCode.Enabled = false;
                    btnSaveCertificate.Visible = false;
                    btnDeleteCertificate.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaCertificate');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDocumentTypeSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ram.ResponseScripts.Add(string.Format("return openRadWindowDocument('{0}','{1}')",
                    sessLpa.CollateralCategory, tbCertificateName.ClientID));
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnVillageSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ram.ResponseScripts.Add(string.Format("return openRadWindowGeneral('../PopUp/PopUpSearchMaster.aspx?Master={0}&ClientId={1}&PostalID={2}')",
                    Enumeration.PopUpSearch.Village.ToString(), tbCertificateVillage.ClientID, sessPostalId));
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSubDistrictSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ram.ResponseScripts.Add(string.Format("return openRadWindowGeneral('../PopUp/PopUpSearchMaster.aspx?Master={0}&ClientId={1}')",
                    Enumeration.PopUpSearch.Subdistrict.ToString(), tbCertificateSubDistrict.ClientID));
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCitySearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ram.ResponseScripts.Add(string.Format("return openRadWindowGeneral('../PopUp/PopUpSearchMaster.aspx?Master={0}&ClientId={1}')",
                    Enumeration.PopUpSearch.City.ToString(), tbCertificateCity.ClientID));
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnProvinceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ram.ResponseScripts.Add(string.Format("return openRadWindowGeneral('../PopUp/PopUpSearchMaster.aspx?Master={0}&ClientId={1}')",
                    Enumeration.PopUpSearch.Province.ToString(), tbCertificateProvince.ClientID));
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCertificateZipCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ram.ResponseScripts.Add(string.Format("return openRadWindowGeneral('../PopUp/PopUpSearchMaster.aspx?Master={0}&ClientId={1}&VillageID={2}')",
                    Enumeration.PopUpSearch.Postal.ToString(), tbCertificateZipCode.ClientID, sessVillageId));
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }
                int iHfCertificateId = 0;
                LpaNonUnitCertificateService oLpaNonUnitCertificateService = null;

                if (PFSCommon.IsNumeric(hfCertificateId.Value))
                {
                    iHfCertificateId = Convert.ToInt32(hfCertificateId.Value);
                }

                if (iHfCertificateId != 0)
                {
                    oLpaNonUnitCertificateService = sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Where(o => o.LpaNonUnitCertificateId == iHfCertificateId).FirstOrDefault();
                }
                else
                {
                    oLpaNonUnitCertificateService = new LpaNonUnitCertificateService();
                    oLpaNonUnitCertificateService.LpaNonUnitCertificateId = vsLpaUnitCertificateId = vsLpaUnitCertificateId - 1;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Add(oLpaNonUnitCertificateService);
                }

                oLpaNonUnitCertificateService.CertificateName = tbCertificateName.Text;
                oLpaNonUnitCertificateService.CertificateNo = tbCertificateNo.Text;
                oLpaNonUnitCertificateService.CertificateVillage = tbCertificateVillage.Text;
                oLpaNonUnitCertificateService.CertificateDate = rdpCertificateDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpCertificateDate.SelectedDate.Value;
                oLpaNonUnitCertificateService.CertificateExpiredDate = rdpExpiredDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpExpiredDate.SelectedDate.Value;
                oLpaNonUnitCertificateService.DocumentSurveyCertificateNo = tbDocumentSurveyCertificateNo.Text;
                oLpaNonUnitCertificateService.DocumentSurveyCertificateDate = rdpDocumentSurveyCertificateDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpDocumentSurveyCertificateDate.SelectedDate.Value;
                oLpaNonUnitCertificateService.DocumentBlueprintNo = tbDocumentBlueprintNo.Text;
                oLpaNonUnitCertificateService.DocumentBlueprintDate = rdpDocumentBlueprintDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpDocumentBlueprintDate.SelectedDate.Value;
                if (PFSCommon.IsNumeric(rtbDocumentLandArea.Text))
                {
                    oLpaNonUnitCertificateService.DocumentLandArea = Convert.ToDouble(rtbDocumentLandArea.Text, new CultureInfo("id-ID"));
                }
                oLpaNonUnitCertificateService.DocumentOwner = tbDocumentOwner.Text;
                oLpaNonUnitCertificateService.CertificateAddress1 = tbCertificateAddress1.Text;
                oLpaNonUnitCertificateService.CertificateAddress2 = tbCertificateAddress2.Text;
                oLpaNonUnitCertificateService.CertificateAddress3 = tbCertificateAddress3.Text;
                oLpaNonUnitCertificateService.CertificateSubDistrict = tbCertificateSubDistrict.Text;
                oLpaNonUnitCertificateService.CertificateCity = tbCertificateCity.Text;
                oLpaNonUnitCertificateService.CertificateProvince = tbCertificateProvince.Text;
                oLpaNonUnitCertificateService.CertificateZipCode = tbCertificateZipCode.Text;

                lblLandArea.Text = "0";
                foreach (LpaNonUnitCertificateService item in sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices)
                {
                    lblLandArea.Text =
                        (Convert.ToDouble(lblLandArea.Text == "" ? "0" : lblLandArea.Text) + item.DocumentLandArea).
                            ToString();
                }

                sessLpa.LpaNonUnitServices[0].LandArea =
                    Convert.ToDouble(lblLandArea.Text == "" ? "0" : lblLandArea.Text);
                rtbValueLandArea.Text = sessLpa.LpaNonUnitServices[0].LandArea.ToString();

                rgLpaNonUnitCertificate.Rebind();
                rgLpaNonUnitCertificate.SelectedIndexes.Clear();
                hfCertificateId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgLpaNonUnitCertificate.SelectedValues != null && rgLpaNonUnitCertificate.SelectedValues.Count > 0)
                {

                    int iSelectedLpaUnitCertificateId = (int)rgLpaNonUnitCertificate.SelectedValues["LpaNonUnitCertificateId"];
                    LpaNonUnitCertificateService oLpaNonUnitCertificateService = sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices
                        .Where(o => o.LpaNonUnitCertificateId == iSelectedLpaUnitCertificateId).FirstOrDefault();
                    if (oLpaNonUnitCertificateService != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Remove(oLpaNonUnitCertificateService);
                    }

                    lblLandArea.Text = "0";
                    foreach (LpaNonUnitCertificateService item in sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices)
                    {
                        lblLandArea.Text =
                            (Convert.ToDouble(lblLandArea.Text == "" ? "0" : lblLandArea.Text) + item.DocumentLandArea).
                                ToString();
                    }

                    sessLpa.LpaNonUnitServices[0].LandArea =
                        Convert.ToDouble(lblLandArea.Text == "" ? "0" : lblLandArea.Text);
                    rtbValueLandArea.Text = sessLpa.LpaNonUnitServices[0].LandArea.ToString();
                    rgLpaNonUnitCertificate.Rebind();
                    rgLpaNonUnitCertificate.SelectedIndexes.Clear();
                    hfCertificateId.Value = "0";

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                hfCertificateId.Value = "0";
                rgLpaNonUnitCertificate.Rebind();
                rgLpaNonUnitCertificate.SelectedIndexes.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void tbCertificateZipCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PostalService oPostalService = new PostalService();
                PostalServiceClient oPostalServiceclient = new PostalServiceClient();
                if (oPostalServiceclient.PostalGetByCode(sessNISPWebLogin.UserName,
                                                         tbCertificateZipCode.Text.Trim(),
                                                         out oPostalService) == 1)
                {
                    sessPostalId = oPostalService.PostalId;
                    btnReloadSearchMaster_Click(this, new EventArgs());
                }
                else
                {
                    sessPostalId = 0;
                    btnReloadSearchMaster_Click(this, new EventArgs());
                }
                oPostalServiceclient.Close();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", ProTaksatur.WebUI.App_Code.GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void tbCertificateVillage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                VillageService oVillageService = new VillageService();
                VillageServiceClient oPostalServiceclient = new VillageServiceClient();
                if (oPostalServiceclient.VillageGetByName(sessNISPWebLogin.UserName,
                                                         tbCertificateVillage.Text.Trim(),
                                                         out oVillageService) == 1)
                {
                    sessVillageId = oVillageService.VillageId;
                    btnReloadSearchMaster_Click(this, new EventArgs());
                }
                else
                {
                    sessVillageId = 0;
                    btnReloadSearchMaster_Click(this, new EventArgs());
                }
                oPostalServiceclient.Close();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", ProTaksatur.WebUI.App_Code.GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        #region Form Land Data

        protected void lbtAddLandData_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                rtbLandArea.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].LandArea);
                rtbWidthStreet.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].WidthStreet);

                if (sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByInspection > 0)
                    ddlCompletionBuilidngByInspection.SelectedValue = sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByInspection.ToString();

                if (sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByDeveloper > 0)
                    ddlCompletionBuildingIdByDeveloper.SelectedValue = sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByDeveloper.ToString();

                if (sessLpa.LpaNonUnitServices[0].PhaseConstructionId > 0)
                    ddlPhaseConstruction.SelectedValue = sessLpa.LpaNonUnitServices[0].PhaseConstructionId.ToString();

                tbProgressConstruction.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].ProgressConstruction);

                tbNorthernBoundary.Text = sessLpa.LpaNonUnitServices[0].NorthernBoundary;
                tbSouthernBoundary.Text = sessLpa.LpaNonUnitServices[0].SouthernBoundary;
                tbEasternBoundary.Text = sessLpa.LpaNonUnitServices[0].EasternBoundary;
                tbWesternBoundary.Text = sessLpa.LpaNonUnitServices[0].WesternBoundary;
                tbAreaPosition.Text = sessLpa.LpaNonUnitServices[0].AreaPosition;
                tbCluster.Text = sessLpa.LpaNonUnitServices[0].Cluster;
                tbBuildingFloor.Value = sessLpa.LpaNonUnitServices[0].BuildingFloor;
                tbDeveloperName.Text = sessLpa.LpaNonUnitServices[0].DeveloperName;
                tbInTouchPersonName.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonName;
                tbInTouchPersonPosition.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonPosition;

                if (sessLpa.LpaNonUnitServices[0].Residential)
                    rdbTrueKomplek.Checked = true;
                else
                    rdbFalseKomplek.Checked = true;

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbNorthernBoundary.Enabled = false;
                    tbSouthernBoundary.Enabled = false;
                    tbEasternBoundary.Enabled = false;
                    tbWesternBoundary.Enabled = false;
                    tbAreaPosition.Enabled = false;
                    tbCluster.Enabled = false;
                    btnSavaLPALandData.Visible = false;
                    ddlPhaseConstruction.Enabled = false;
                    ddlCompletionBuildingIdByDeveloper.Enabled = false;
                    ddlCompletionBuilidngByInspection.Enabled = false;
                    tbProgressConstruction.Enabled = false;
                    tbBuildingFloor.Enabled = false;
                    tbDeveloperName.Enabled = false;
                    tbInTouchPersonName.Enabled = false;
                    tbInTouchPersonPosition.Enabled = false;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaLandData');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSavaLPALandData_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (PFSCommon.IsNumeric(rtbLandArea.Text))
                {
                    sessLpa.LpaNonUnitServices[0].LandArea = Convert.ToDouble(rtbLandArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    sessLpa.LpaNonUnitServices[0].LandArea = 0;
                }

                if (PFSCommon.IsNumeric(rtbWidthStreet.Text))
                {
                    sessLpa.LpaNonUnitServices[0].WidthStreet = Convert.ToDouble(rtbWidthStreet.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    sessLpa.LpaNonUnitServices[0].WidthStreet = 0;
                }

                sessLpa.LpaNonUnitServices[0].NorthernBoundary = tbNorthernBoundary.Text;
                sessLpa.LpaNonUnitServices[0].SouthernBoundary = tbSouthernBoundary.Text;
                sessLpa.LpaNonUnitServices[0].EasternBoundary = tbEasternBoundary.Text;
                sessLpa.LpaNonUnitServices[0].WesternBoundary = tbWesternBoundary.Text;
                sessLpa.LpaNonUnitServices[0].AreaPosition = tbAreaPosition.Text;
                sessLpa.LpaNonUnitServices[0].Cluster = tbCluster.Text;
                sessLpa.LpaNonUnitServices[0].Residential = rdbTrueKomplek.Checked ? true : false;

                if (PFSCommon.IsNumeric(tbProgressConstruction.Text))
                {
                    sessLpa.LpaNonUnitServices[0].ProgressConstruction = Convert.ToDouble(tbProgressConstruction.Text, new CultureInfo("id-ID"));
                    lblProgressConstruction.Text = PFSCommon.FormatNumber(sessLpa.LpaNonUnitServices[0].ProgressConstruction);
                }

                if (ddlCompletionBuildingIdByDeveloper.SelectedValue != null && ddlCompletionBuildingIdByDeveloper.SelectedValue != "0")
                {
                    sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByDeveloper = Convert.ToInt32(ddlCompletionBuildingIdByDeveloper.SelectedValue);
                    lblCompletionBuilidngByDeveloper.Text = ddlCompletionBuildingIdByDeveloper.SelectedItem.Text;
                }
                if (ddlCompletionBuilidngByInspection.SelectedValue != null && ddlCompletionBuilidngByInspection.SelectedValue != "0")
                {
                    sessLpa.LpaNonUnitServices[0].CompletionBuildingIdByInspection = Convert.ToInt32(ddlCompletionBuilidngByInspection.SelectedValue);
                    lblCompletionBuilidngByInspection.Text = ddlCompletionBuilidngByInspection.SelectedItem.Text;
                }
                if (ddlPhaseConstruction.SelectedValue != null && ddlPhaseConstruction.SelectedValue != "0")
                {
                    sessLpa.LpaNonUnitServices[0].PhaseConstructionId = Convert.ToInt32(ddlPhaseConstruction.SelectedValue);
                    lblPhaseConstruction.Text = ddlPhaseConstruction.SelectedItem.Text;
                }

                sessLpa.LpaNonUnitServices[0].BuildingFloor = tbBuildingFloor.Value == null ? 0 : (int)tbBuildingFloor.Value.Value;
                sessLpa.LpaNonUnitServices[0].DeveloperName = tbDeveloperName.Text;
                sessLpa.LpaNonUnitServices[0].InTouchPersonName = tbInTouchPersonName.Text;
                sessLpa.LpaNonUnitServices[0].InTouchPersonPosition = tbInTouchPersonPosition.Text;
                lblLandArea.Text = rtbLandArea.Text;
                lblWidthStreet.Text = rtbWidthStreet.Text;
                lblNorthernBoundary.Text = tbNorthernBoundary.Text;
                lblSouthernBoundary.Text = tbSouthernBoundary.Text;
                lblEasternBoundary.Text = tbEasternBoundary.Text;
                lblWesternBoundary.Text = tbWesternBoundary.Text;
                lblAreaPosition.Text = tbAreaPosition.Text;
                lblCluster.Text = tbCluster.Text;
                lblKomplek.Text = rdbTrueKomplek.Checked ? "Ya" : "Tidak";
                lblBuildingFloor.Text = sessLpa.LpaNonUnitServices[0].BuildingFloor.ToString();
                lblDeveloperName.Text = sessLpa.LpaNonUnitServices[0].DeveloperName;
                lblInTouchPersonName.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonName;
                lblInTouchPersonPosition.Text = sessLpa.LpaNonUnitServices[0].InTouchPersonPosition;

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());

                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        #region Form Data Building
        protected void lbtAddDataBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgDataBuilding.SelectedItems.Count > 0)
                {
                    int iSelectedId = (int)rgDataBuilding.SelectedValues["LpaNonUnitDataBuildingId"];
                    hfDataBuildingId.Value = iSelectedId.ToString();
                    LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices
                        .Where(o => o.LpaNonUnitDataBuildingId == iSelectedId).FirstOrDefault();
                    tbPermitsType.Text = oLpaNonUnitDataBuildingService.LpaNonUnitDataBuildingPermitsBuildingType;
                    tbPermitsNo.Text = oLpaNonUnitDataBuildingService.BuildingPermitsNo;
                    if (oLpaNonUnitDataBuildingService.BuildingPermitsCreateDate.Date <= (new DateTime(1900, 1, 1)))
                    {
                        rdpPermitsDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpPermitsDate.SelectedDate = oLpaNonUnitDataBuildingService.BuildingPermitsCreateDate;
                    }
                    tbPermitsName.Text = oLpaNonUnitDataBuildingService.BuildingPermitsName;
                    tbPermitsLocation.Text = oLpaNonUnitDataBuildingService.BuildingPermitsLocation;
                    tbPermitsBuildingType.Text = oLpaNonUnitDataBuildingService.BuildingPermitsType;
                    rtbPermitsArea.Text = PFSCommon.FormatNumber(oLpaNonUnitDataBuildingService.BuildingPermitsArea);
                    tbPhysicalBuildingType.Text = oLpaNonUnitDataBuildingService.PhysicalBuildingType;
                    rtbPhysicalArea.Text = PFSCommon.FormatNumber(oLpaNonUnitDataBuildingService.PhysicalArea);
                    if (PFSCommon.IsNumeric(oLpaNonUnitDataBuildingService.BuildingCreatedYear))
                    {
                        rtbCreatedYear.Text = oLpaNonUnitDataBuildingService.BuildingCreatedYear;
                    }
                    if (PFSCommon.IsNumeric(oLpaNonUnitDataBuildingService.RenovationYear))
                    {
                        rtbRenovationYear.Text = oLpaNonUnitDataBuildingService.RenovationYear;
                    }
                    tbUsedFor.Text = oLpaNonUnitDataBuildingService.BuildingUsedFor;
                    tbPhysicalUsage.Text = oLpaNonUnitDataBuildingService.PhysicalUsage;
                    tbOccupant.Text = oLpaNonUnitDataBuildingService.BuildingOccupant;
                    tbOccupantRelation.Text = oLpaNonUnitDataBuildingService.BuildingOccupantRelationWithDebitur;
                    tbAssignedBy.Text = oLpaNonUnitDataBuildingService.AssignedBy;
                    tbAssignedRelation.Text = oLpaNonUnitDataBuildingService.AssignedRelationWithDebitur;
                }
                else
                {
                    hfDataBuildingId.Value = "0";
                    tbPermitsName.Text = "";
                    tbPermitsLocation.Text = "";
                    tbPermitsBuildingType.Text = "";
                    rtbPermitsArea.Text = "";
                    tbPhysicalBuildingType.Text = "";
                    rtbPhysicalArea.Text = null;
                    rtbCreatedYear.Text = "";
                    rtbRenovationYear.Text = "";
                    tbUsedFor.Text = "";
                    tbPhysicalUsage.Text = "";
                    tbOccupant.Text = "";
                    tbOccupantRelation.Text = "";
                    tbAssignedBy.Text = "";
                    tbAssignedRelation.Text = "";
                    tbPermitsType.Text = "";
                    tbPermitsNo.Text = "";

                }

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbPermitsName.Enabled = false;
                    tbPermitsLocation.Enabled = false;
                    tbPermitsBuildingType.Enabled = false;
                    rtbPermitsArea.Enabled = false;
                    tbPhysicalBuildingType.Enabled = false;
                    rtbPhysicalArea.Enabled = false;
                    rtbCreatedYear.Enabled = false;
                    rtbRenovationYear.Enabled = false;
                    tbUsedFor.Enabled = false;
                    tbPhysicalUsage.Enabled = false;
                    tbOccupant.Enabled = false;
                    tbOccupantRelation.Enabled = false;
                    tbAssignedBy.Enabled = false;
                    tbAssignedRelation.Enabled = false;
                    tbPermitsType.Enabled = false;
                    tbPermitsNo.Enabled = false;
                    rdpPermitsDate.Enabled = false;
                    btnSaveDataBuilding.Visible = false;
                    btnDeleteDataBuilding.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaDataBuilding');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveDataBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (!PFSCommon.IsNumeric(rtbCreatedYear.Text.Trim()) || Convert.ToInt32(rtbCreatedYear.Text.Trim()) > DateTime.Now.Year)
                {
                    Alert("Tahun Dibangun Tidak Valid");
                    return;
                }

                if (rtbRenovationYear.Text.Trim().Length > 0)
                {
                    if (!PFSCommon.IsNumeric(rtbRenovationYear.Text.Trim()) || Convert.ToInt32(rtbRenovationYear.Text.Trim()) > DateTime.Now.Year)
                    {
                        Alert("Tahun Direnovasi Tidak Valid");
                        return;
                    }
                }

                LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService = null;
                int iHfDataBuildingId = 0;

                if (PFSCommon.IsNumeric(hfDataBuildingId.Value))
                {
                    iHfDataBuildingId = Convert.ToInt32(hfDataBuildingId.Value);
                }
                if (iHfDataBuildingId != 0)
                {
                    oLpaNonUnitDataBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices
                        .Where(o => o.LpaNonUnitDataBuildingId == iHfDataBuildingId).FirstOrDefault();
                }
                else
                {
                    oLpaNonUnitDataBuildingService = new LpaNonUnitDataBuildingService();
                    oLpaNonUnitDataBuildingService.LpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId - 1;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.Add(oLpaNonUnitDataBuildingService);
                }

                oLpaNonUnitDataBuildingService.LpaNonUnitDataBuildingPermitsBuildingType = tbPermitsType.Text;
                oLpaNonUnitDataBuildingService.BuildingPermitsNo = tbPermitsNo.Text;
                oLpaNonUnitDataBuildingService.BuildingPermitsCreateDate = rdpPermitsDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpPermitsDate.SelectedDate.Value;
                oLpaNonUnitDataBuildingService.BuildingPermitsName = tbPermitsName.Text;
                oLpaNonUnitDataBuildingService.BuildingPermitsLocation = tbPermitsLocation.Text;
                oLpaNonUnitDataBuildingService.BuildingPermitsType = tbPermitsBuildingType.Text;

                if (PFSCommon.IsNumeric(rtbPermitsArea.Text))
                {
                    oLpaNonUnitDataBuildingService.BuildingPermitsArea = Convert.ToDouble(rtbPermitsArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitDataBuildingService.BuildingPermitsArea = 0;
                }
                oLpaNonUnitDataBuildingService.PhysicalBuildingType = tbPhysicalBuildingType.Text;

                if (PFSCommon.IsNumeric(rtbPhysicalArea.Text))
                {
                    oLpaNonUnitDataBuildingService.PhysicalArea = Convert.ToDouble(rtbPhysicalArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitDataBuildingService.PhysicalArea = 0;
                }

                oLpaNonUnitDataBuildingService.BuildingCreatedYear = rtbCreatedYear.Text;
                oLpaNonUnitDataBuildingService.RenovationYear = rtbRenovationYear.Text;
                oLpaNonUnitDataBuildingService.BuildingUsedFor = tbUsedFor.Text;
                oLpaNonUnitDataBuildingService.PhysicalUsage = tbPhysicalUsage.Text;
                oLpaNonUnitDataBuildingService.BuildingOccupant = tbOccupant.Text;
                oLpaNonUnitDataBuildingService.BuildingOccupantRelationWithDebitur = tbOccupantRelation.Text;
                oLpaNonUnitDataBuildingService.AssignedBy = tbAssignedBy.Text;
                oLpaNonUnitDataBuildingService.AssignedRelationWithDebitur = tbAssignedRelation.Text;

                rgDataBuilding.Rebind();
                rgDataBuilding.SelectedIndexes.Clear();
                hfDataBuildingId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteDataBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgDataBuilding.SelectedValues != null && rgDataBuilding.SelectedValues.Count > 0)
                {

                    int iSelectedId = (int)rgDataBuilding.SelectedValues["LpaNonUnitDataBuildingId"];
                    LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices
                        .Where(o => o.LpaNonUnitDataBuildingId == iSelectedId).FirstOrDefault();
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.Remove(oLpaNonUnitDataBuildingService);

                    rgDataBuilding.Rebind();
                    rgDataBuilding.SelectedIndexes.Clear();
                    hfDataBuildingId.Value = "0";

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelDataBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                hfDataBuildingId.Value = "0";
                rgDataBuilding.Rebind();
                rgDataBuilding.SelectedIndexes.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Form Value Land

        protected void lbtAddValueLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitLand.SelectedItems.Count == 0)
                {
                    Alert("Pilih Salah Satu Data Deskripsi Tanah");
                    return;
                }

                if (rgNonUnitLand.SelectedItems.Count > 0)
                {
                    int iDocumentCalculationid = Convert.ToInt32(ddlDocumentCalculationTypeForLand.SelectedValue);
                    int iNonUnitLandId = (int)rgNonUnitLand.SelectedValues["LpaNonUnitLandId"];
                    hfValueLandId.Value = iNonUnitLandId.ToString();
                    LpaNonUnitLandService oLpaNonUnitLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                        .Where(o => o.LpaNonUnitLandId == iNonUnitLandId).FirstOrDefault();

                    LpaNonUnitValueLandService oLpaNonUnitValueLandService = oLpaNonUnitLandService.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationid).FirstOrDefault();

                    if (oLpaNonUnitValueLandService != null)
                    {
                        tbLandDescription.Text = oLpaNonUnitValueLandService.LandDescription;
                        rtbValueLandArea.Text = PFSCommon.FormatNumber(Convert.ToInt32(oLpaNonUnitValueLandService.ValueLandArea) == 0 ? Convert.ToDouble(lblLandArea.Text == "" ? "0" : lblLandArea.Text) : oLpaNonUnitValueLandService.ValueLandArea);
                        rtbValueLandPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandPrice);
                        rtbLandAdjustment.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.LandAdjustment);
                        rtbValueLandPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);
                        rtbAsjusmentCalc.Text = PFSCommon.FormatNumber(((oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice));
                        rtbTotalValueLandCalc.Text = PFSCommon.FormatNumber((oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice) - (oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);
                    }
                    else
                    {
                        tbLandDescription.Text = "";
                        rtbValueLandArea.Text = lblLandArea.Text;
                        rtbValueLandPrice.Text = "0";
                        rtbLandAdjustment.Value = 0;
                        rtbValueLandPriceCalc.Text = "0";
                        rtbAsjusmentCalc.Text = "0";
                        rtbTotalValueLandCalc.Text = "0";
                        rtbValueLandPriceCalc.Text = "0";

                        if (sessLpa.LpaComparativeNonunitServices != null)
                        {
                            double dTotal = 0;

                            foreach (LpaComparativeNonunitService oLpaComparativeNonUnitService in sessLpa.LpaComparativeNonunitServices)
                            {
                                double dPredictioValue = (oLpaComparativeNonUnitService.ComparativeNonUnitAmount - oLpaComparativeNonUnitService.ComparativeNonUnitFurnishPrice) * ((100 - oLpaComparativeNonUnitService.ComparativeNonUnitSellingPriceDiscount) / 100);

                                double dEstimateBuildingValue =
                                    oLpaComparativeNonUnitService.ComparativeNonUnitBuildingArea *
                                         oLpaComparativeNonUnitService.ComparativeNonUnitNewBuildingPrice
                                         * (1 - (oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation / 100));

                                double dEstimateLandValue =
                                     (((dPredictioValue) -
                                      ((oLpaComparativeNonUnitService.ComparativeNonUnitBuildingArea) *
                                      (oLpaComparativeNonUnitService.ComparativeNonUnitNewBuildingPrice) *
                                      (1 - (oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation) / 100))) /
                                      (oLpaComparativeNonUnitService.ComparativeNonUnitLandArea));

                                double dIndicationUnitValue = (dEstimateLandValue * oLpaComparativeNonUnitService.ComparativeNonUnitDataPercentage) / 100;
                                dTotal += dIndicationUnitValue;
                            }

                            rtbValueLandPrice.Text = PFSCommon.FormatNumber(dTotal);
                        }
                    }
                }
                //else
                //{


                //}

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbLandDescription.Enabled = false;
                    rtbValueLandArea.Enabled = false;
                    rtbValueLandPrice.Enabled = false;
                    rtbLandAdjustment.Enabled = false;
                    rtbValueLandPriceCalc.Enabled = false;
                    rtbAsjusmentCalc.Enabled = false;
                    rtbTotalValueLandCalc.Enabled = false;
                    rtbValueLandPriceCalc.Enabled = false;
                    btnSaveValueLand.Visible = false;
                    btnDeleteValueLand.Visible = false;

                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaValueLand');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveValueLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                LpaNonUnitValueLandService oLpaNonUnitValueLandService = null;
                int iHfValueLandId = 0;
                if (PFSCommon.IsNumeric(hfValueLandId.Value))
                {
                    iHfValueLandId = Convert.ToInt32(hfValueLandId.Value);
                }

                if (iHfValueLandId != 0)
                {
                    oLpaNonUnitValueLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                        .Where(o => o.LpaNonUnitLandId == iHfValueLandId).FirstOrDefault().LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == Convert.ToInt32(ddlDocumentCalculationTypeForLand.SelectedValue)).FirstOrDefault();

                    if (oLpaNonUnitValueLandService == null)
                    {
                        oLpaNonUnitValueLandService = new LpaNonUnitValueLandService();
                        oLpaNonUnitValueLandService.LpaNonUnitValueLandId = vsLpaNonUnitValueLandId = vsLpaNonUnitValueLandId - 1;
                        oLpaNonUnitValueLandService.DocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForLand.SelectedValue);
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Where(o => o.LpaNonUnitLandId == iHfValueLandId)
                        .FirstOrDefault().LpaNonUnitValueLandServices.Add(oLpaNonUnitValueLandService);
                    }

                }
                //else
                //{

                //}


                //oLpaNonUnitValueLandService.LandDescription = Server.HtmlEncode(tbLandDescription.Text.Trim());

                if (PFSCommon.IsNumeric(rtbValueLandArea.Text))
                {
                    oLpaNonUnitValueLandService.ValueLandArea = Convert.ToDouble(rtbValueLandArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitValueLandService.ValueLandArea = 0;
                }

                if (PFSCommon.IsNumeric(rtbValueLandPrice.Text))
                {
                    oLpaNonUnitValueLandService.ValueLandPrice = Convert.ToDouble(rtbValueLandPrice.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitValueLandService.ValueLandPrice = 0;
                }

                oLpaNonUnitValueLandService.LandAdjustment = rtbLandAdjustment.Value == null ? 0 : rtbLandAdjustment.Value.Value;

                lblValueLandArea.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandArea);
                lblValueLandPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandPrice);
                lblLandAdjusment.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.LandAdjustment);
                lblValueLandPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);
                lblAdjusmentCalc.Text = PFSCommon.FormatNumber(((oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice));
                lblTotalValueLandCalc.Text = PFSCommon.FormatNumber((oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice) - (oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);

                CalculateTotalMarketPrice();

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelValueLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteValueLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitLand.SelectedValues != null && rgNonUnitLand.SelectedValues.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForLand.SelectedValue);
                    int iNonUnitLandId = (int)rgNonUnitLand.SelectedValues["LpaNonUnitLandId"];
                    LpaNonUnitLandService oLpaNonUnitLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                        .Where(o => o.LpaNonUnitLandId == iNonUnitLandId).FirstOrDefault();

                    LpaNonUnitValueLandService oLpaNonUnitValueLandService = oLpaNonUnitLandService.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueLandService != null)
                    {
                        oLpaNonUnitLandService.LpaNonUnitValueLandServices.Remove(oLpaNonUnitValueLandService);
                        lblValueLandArea.Text = "";
                        lblValueLandPrice.Text = "";
                        lblLandAdjusment.Text = "";
                        lblValueLandPriceCalc.Text = "";
                        lblAdjusmentCalc.Text = "";
                        lblTotalValueLandCalc.Text = "";
                    }

                    CalculateTotalMarketPrice();

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        #region Form Value Bulding

        protected void lbtAddNewValueBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitBuilding.SelectedItems.Count == 0)
                {
                    Alert("Pilih Salah Satu Data Deskripsi Bangunan");
                    return;
                }

                if (rgNonUnitBuilding.SelectedItems.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForBuilding.SelectedValue);
                    int iSelectedId = (int)rgNonUnitBuilding.SelectedValues["LpaNonUnitBuildingId"];
                    hfValueBuildingId.Value = iSelectedId.ToString();
                    LpaNonUnitBuildingService oLpaNonUnitBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iSelectedId).FirstOrDefault();
                    LpaNonUnitValueBuildingService oLpaNonUnitValueBuildingService = oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueBuildingService != null)
                    {
                        tbBuildingName.Text = oLpaNonUnitValueBuildingService.BuildingName;
                        rtbBuildingArea.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea);
                        rtbBuildingPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingPrice);
                        rtbTotalPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea * oLpaNonUnitValueBuildingService.BuildingPrice);
                        rtbBuildingProgress.Value = oLpaNonUnitValueBuildingService.BuildingProgress;
                        rtbBuildingProgressCalc.Text = PFSCommon.FormatNumber(rtbBuildingProgress.Value.Value / 100 * Convert.ToDouble(rtbTotalPriceCalc.Text, new CultureInfo("id-ID")));
                        rtbBuildingDepreciation.Value = oLpaNonUnitValueBuildingService.BuildingDepreciation;
                        rtbBuildingDepreciationCalc.Text = PFSCommon.FormatNumber(rtbBuildingDepreciation.Value.Value / 100 * Convert.ToDouble(rtbBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        rtbRepairCost.Value = oLpaNonUnitValueBuildingService.RepairCost;
                        rtbRepairCostCalc.Text = PFSCommon.FormatNumber(rtbRepairCost.Value.Value / 100 * Convert.ToDouble(rtbBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        rtbEconomicAsumption.Value = oLpaNonUnitValueBuildingService.EconomicAsumption;
                        rtbEconomicAsumptionCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(rtbBuildingProgressCalc.Text, new CultureInfo("id-ID")) / 100 * rtbEconomicAsumption.Value.Value);
                        rtbTotalSummaryCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(rtbBuildingDepreciationCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(rtbEconomicAsumptionCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(rtbRepairCostCalc.Text, new CultureInfo("id-ID")));
                    }
                    else
                    {
                        tbBuildingName.Text = "";
                        rtbBuildingArea.Text = "0";
                        rtbBuildingPrice.Text = "0";
                        rtbTotalPriceCalc.Text = "0";
                        rtbBuildingProgress.Value = 0;
                        rtbBuildingProgressCalc.Text = "0";
                        rtbBuildingDepreciation.Value = 0;
                        rtbBuildingDepreciationCalc.Text = "0";
                        rtbRepairCost.Value = 0;
                        rtbRepairCostCalc.Text = "0";
                        rtbEconomicAsumption.Value = 0;
                        rtbEconomicAsumptionCalc.Text = "0";
                        rtbTotalSummaryCalc.Text = "0";

                        if (sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices != null)
                        {
                            if (ddlDocumentCalculationTypeForBuilding.SelectedItem.Text == Enumeration.DocumentCalculationType.Dokumen.ToString())
                            {
                                foreach (LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService in sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices)
                                {
                                    if (oLpaNonUnitDataBuildingService.BuildingPermitsType.Equals(oLpaNonUnitBuildingService.BuildingDescription))
                                    {
                                        rtbBuildingArea.Text = PFSCommon.FormatNumber(oLpaNonUnitDataBuildingService.BuildingPermitsArea);
                                        break;
                                    }
                                }
                            }
                            else if (ddlDocumentCalculationTypeForBuilding.SelectedItem.Text == Enumeration.DocumentCalculationType.Fisik.ToString())
                            {
                                foreach (LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService in sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices)
                                {
                                    if (oLpaNonUnitDataBuildingService.PhysicalBuildingType.Equals(oLpaNonUnitBuildingService.BuildingDescription))
                                    {
                                        rtbBuildingArea.Text = PFSCommon.FormatNumber(oLpaNonUnitDataBuildingService.PhysicalArea);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                //else
                //{

                //}

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbBuildingName.Enabled = false;
                    rtbBuildingArea.Enabled = false;
                    rtbBuildingPrice.Enabled = false;
                    rtbTotalPriceCalc.Enabled = false;
                    rtbBuildingProgress.Enabled = false;
                    rtbBuildingProgressCalc.Enabled = false;
                    rtbBuildingDepreciation.Enabled = false;
                    rtbBuildingDepreciationCalc.Enabled = false;
                    rtbRepairCost.Enabled = false;
                    rtbRepairCostCalc.Enabled = false;
                    rtbEconomicAsumption.Enabled = false;
                    rtbEconomicAsumptionCalc.Enabled = false;
                    rtbTotalSummaryCalc.Enabled = false;
                    btnSaveValueBuilding.Visible = false;
                    btnDeleteValueBuilding.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaValueBuilding');", true);

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveValueBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                LpaNonUnitValueBuildingService oLpaNonUnitValueBuildingService = null;
                int iHfValuebuildingId = 0;
                int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForBuilding.SelectedValue);
                if (PFSCommon.IsNumeric(hfValueBuildingId.Value))
                {
                    iHfValuebuildingId = Convert.ToInt32(hfValueBuildingId.Value);
                }

                if (iHfValuebuildingId != 0)
                {
                    oLpaNonUnitValueBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iHfValuebuildingId).FirstOrDefault().LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueBuildingService == null)
                    {
                        oLpaNonUnitValueBuildingService = new LpaNonUnitValueBuildingService();
                        oLpaNonUnitValueBuildingService.LpaNonUnitValueBuildingId = vsLpaNonUnitValueBuildingId = vsLpaNonUnitValueBuildingId - 1;
                        oLpaNonUnitValueBuildingService.DocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForBuilding.SelectedValue);
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Where(o => o.LpaNonUnitBuildingId == iHfValuebuildingId).FirstOrDefault()
                            .LpaNonUnitValueBuildingServices.Add(oLpaNonUnitValueBuildingService);
                    }
                }
                //else
                //{
                //    oLpaNonUnitValueBuildingService = new LpaNonUnitValueBuildingService();
                //    oLpaNonUnitValueBuildingService.LpaNonUnitValueBuildingId = vsLpaNonUnitValueLandId = vsLpaNonUnitValueLandId - 1;
                //    oLpaNonUnitValueBuildingService.DocumentCalculationId = vsDocumentCalculationID;
                //    //sessLpa.LpaNonUnitServices[0].Lp
                //}

                //oLpaNonUnitValueBuildingService.BuildingName = tbBuildingName.Text;
                if (PFSCommon.IsNumeric(rtbBuildingArea.Text))
                {
                    oLpaNonUnitValueBuildingService.BuildingArea = Convert.ToDouble(rtbBuildingArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitValueBuildingService.BuildingArea = 0;
                }

                if (PFSCommon.IsNumeric(rtbBuildingPrice.Text))
                {
                    oLpaNonUnitValueBuildingService.BuildingPrice = Convert.ToDouble(rtbBuildingPrice.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitValueBuildingService.BuildingPrice = 0;
                }

                oLpaNonUnitValueBuildingService.BuildingProgress = rtbBuildingProgress.Value == null ? 0 : rtbBuildingProgress.Value.Value;
                oLpaNonUnitValueBuildingService.BuildingDepreciation = rtbBuildingDepreciation.Value == null ? 0 : rtbBuildingDepreciation.Value.Value;
                oLpaNonUnitValueBuildingService.RepairCost = rtbRepairCost.Value == null ? 0 : rtbRepairCost.Value.Value;
                oLpaNonUnitValueBuildingService.EconomicAsumption = rtbEconomicAsumption.Value == null ? 0 : rtbEconomicAsumption.Value.Value;

                lblBuildingArea.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea);
                lblBuildingPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingPrice);
                lblBuildingProgress.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingProgress);
                lblBuildingDepreciation.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingDepreciation);
                lblRepairCost.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.RepairCost);
                lblEconomicAsumption.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.EconomicAsumption);
                lblTotalPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea * oLpaNonUnitValueBuildingService.BuildingPrice);
                lblBuildingProgressCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingProgress / 100 * Convert.ToDouble(lblTotalPriceCalc.Text, new CultureInfo("id-ID")));
                lblBuildingDepreciationCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingDepreciation / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                lblRepairCostCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.RepairCost / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                lblEconomicAsumptionCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) / 100 * oLpaNonUnitValueBuildingService.EconomicAsumption);
                lblTotalSummaryCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingDepreciationCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblEconomicAsumptionCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblRepairCostCalc.Text, new CultureInfo("id-ID")));
                lblBuildingValue.Text = PFSCommon.FormatNumber((Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) - Convert.ToDouble(lblTotalSummaryCalc.Text, new CultureInfo("id-ID"))));

                CalculateTotalMarketPrice();

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteValueBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitBuilding.SelectedValues != null && rgNonUnitBuilding.SelectedValues.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForBuilding.SelectedValue);
                    int iLpaNonBuildingLandId = (int)rgNonUnitBuilding.SelectedValues["LpaNonUnitBuildingId"];
                    LpaNonUnitBuildingService oLpaNonUnitBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iLpaNonBuildingLandId).FirstOrDefault();

                    LpaNonUnitValueBuildingService oLpaNonUnitValueBuildingService = oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueBuildingService != null)
                    {
                        oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices.Remove(oLpaNonUnitValueBuildingService);

                        lblBuildingArea.Text = "";
                        lblBuildingPrice.Text = "";
                        lblTotalPriceCalc.Text = "";
                        lblBuildingProgress.Text = "";
                        lblBuildingProgressCalc.Text = "";
                        lblBuildingDepreciation.Text = "";
                        lblBuildingDepreciationCalc.Text = "";
                        lblRepairCost.Text = "";
                        lblRepairCostCalc.Text = "";
                        lblEconomicAsumption.Text = "";
                        lblEconomicAsumptionCalc.Text = "";
                        lblTotalSummaryCalc.Text = "";
                        lblBuildingValue.Text = "";
                    }

                    CalculateTotalMarketPrice();

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelValueBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }


                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Form Value Facility
        protected void lbtAddFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitFacility.SelectedItems.Count == 0)
                {
                    Alert("Jenis Sarana Prasarana Harus di Pilih");
                    return;
                }
                if (rgNonUnitFacility.SelectedItems.Count > 0)
                {
                    int iDocumentCalculationid = Convert.ToInt32(ddlDocumentCalculationTypeForFacility.SelectedValue);
                    int iNonUnitFacilityId = (int)rgNonUnitFacility.SelectedValues["LpaNonUnitFacilityId"];
                    hfValueFacilityId.Value = iNonUnitFacilityId.ToString();
                    LpaNonUnitFacilityService oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iNonUnitFacilityId).FirstOrDefault();

                    LpaNonUnitValueFacilityService oLpaNonUnitValueFacilityService = oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationid).FirstOrDefault();

                    if (oLpaNonUnitValueFacilityService != null)
                    {
                        rtbFacilityMeasurement.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement);
                        tbFacilityUnitOfMeasure.Text = oLpaNonUnitValueFacilityService.FacilityUnitOfMeasure;
                        rtbFacilityAmountHomeCurrency.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);
                        rntValueFacility.Text = PFSCommon.FormatNumber((oLpaNonUnitValueFacilityService.FacilityMeasurement * oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency));
                    }
                    else
                    {
                        tbFacilityName.Text = "";
                        rtbFacilityMeasurement.Text = "0";
                        tbFacilityUnitOfMeasure.Text = "";
                        rtbFacilityAmountHomeCurrency.Text = "0";
                        rntValueFacility.Text = null;
                    }

                }
                //else
                //{
                //    tbFacilityName.Text = "";
                //    rtbFacilityMeasurement.Text = "0";
                //    tbFacilityUnitOfMeasure.Text = "";
                //    rtbFacilityAmountHomeCurrency.Text = "0";
                //    rntValueFacility.Text = null;
                //    hfValueFacilityId.Value = "0";
                //}

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbFacilityName.Enabled = false;
                    rtbFacilityMeasurement.Enabled = false;
                    tbFacilityUnitOfMeasure.Enabled = false;
                    rtbFacilityAmountHomeCurrency.Enabled = false;
                    rntValueFacility.Enabled = false;

                    btnSaveValueFacility.Visible = false;
                    btnDeleteValueFacility.Visible = false;

                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#valueFacility');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveValueFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                LpaNonUnitValueFacilityService oLpaNonUnitValueFacilityService = null;
                int iHfValueFacilityId = 0;
                int iDocumentCalculationid = Convert.ToInt32(ddlDocumentCalculationTypeForFacility.SelectedValue);

                if (PFSCommon.IsNumeric(hfValueFacilityId.Value))
                {
                    iHfValueFacilityId = Convert.ToInt32(hfValueFacilityId.Value);
                }

                if (iHfValueFacilityId != 0)
                {
                    LpaNonUnitFacilityService oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iHfValueFacilityId).FirstOrDefault();

                    oLpaNonUnitValueFacilityService = oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationid).FirstOrDefault();

                    if (oLpaNonUnitValueFacilityService == null)
                    {
                        oLpaNonUnitValueFacilityService = new LpaNonUnitValueFacilityService();
                        oLpaNonUnitValueFacilityService.DocumentCalculationId = iDocumentCalculationid;
                        oLpaNonUnitValueFacilityService.LpaNonUnitValueFacilityId = vsLpaNonUnitValueFacilityId = vsLpaNonUnitValueFacilityId - 1;
                        oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices.Add(oLpaNonUnitValueFacilityService);
                    }
                }
                //else
                //{
                //    oLpaNonUnitValueFacilityService = new LpaNonUnitValueFacilityService();
                //    oLpaNonUnitValueFacilityService.LpaNonUnitValueFacilityId = vsLpaNonUnitValueFacilityId = vsLpaNonUnitValueFacilityId - 1;
                //    oLpaNonUnitValueFacilityService.DocumentCalculationId = vsDocumentCalculationID;
                //    sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices.Add(oLpaNonUnitValueFacilityService);
                //}

                //oLpaNonUnitValueFacilityService.FacilityName = tbFacilityName.Text;
                if (PFSCommon.IsNumeric(rtbFacilityMeasurement.Text))
                {
                    oLpaNonUnitValueFacilityService.FacilityMeasurement = Convert.ToDouble(rtbFacilityMeasurement.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitValueFacilityService.FacilityMeasurement = 0;
                }

                oLpaNonUnitValueFacilityService.FacilityUnitOfMeasure = tbFacilityUnitOfMeasure.Text;

                if (PFSCommon.IsNumeric(rtbFacilityAmountHomeCurrency.Text))
                {
                    oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency = Convert.ToDouble(rtbFacilityAmountHomeCurrency.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency = 0;
                }

                rntValueFacility.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement * oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);

                lblFacilityMeasurement.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement);
                lblFacilityUnitOfMeasure.Text = oLpaNonUnitValueFacilityService.FacilityUnitOfMeasure;
                lblFacilityAmountHomeCurrency.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);
                lblValueFacility.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement * oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);

                CalculateTotalMarketPrice();
                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteValueFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitFacility.SelectedValues != null && rgNonUnitFacility.SelectedValues.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForFacility.SelectedValue);
                    int iNonUnitFacilityId = (int)rgNonUnitFacility.SelectedValues["LpaNonUnitFacilityId"];

                    LpaNonUnitFacilityService oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iNonUnitFacilityId).FirstOrDefault();

                    LpaNonUnitValueFacilityService oLpaNonUnitValueFacilityService = oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices.Where
                        (o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueFacilityService != null)
                    {
                        oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices.Remove(oLpaNonUnitValueFacilityService);

                        lblFacilityMeasurement.Text = "";
                        lblFacilityUnitOfMeasure.Text = "";
                        lblFacilityAmountHomeCurrency.Text = "";
                        lblValueFacility.Text = "";
                    }

                    CalculateTotalMarketPrice();

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelValueFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Form TaxLand
        protected void lbtAddTaxLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgTaxLand.SelectedItems.Count > 0)
                {
                    int iSelectedId = (int)rgTaxLand.SelectedValues["LpaNonUnitTaxLandId"];
                    hfTaxLandId.Value = iSelectedId.ToString();
                    LpaNonUnitTaxLandService oLpaNonUnitTaxlandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices
                        .Where(o => o.LpaNonUnitTaxLandId == iSelectedId).FirstOrDefault();

                    tbTaxLandDataValue.Text = oLpaNonUnitTaxlandService.TaxLandDataValue;
                    rtbTaxLandYear.Value = Convert.ToInt32(oLpaNonUnitTaxlandService.TaxLandYear);
                    rtbTaxLandArea.Text = PFSCommon.FormatNumber(oLpaNonUnitTaxlandService.TaxLandArea);
                    rtbTaxBuildingArea.Text = PFSCommon.FormatNumber(oLpaNonUnitTaxlandService.TaxBuildingArea);
                    rtbTaxLandPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitTaxlandService.TaxLandPrice);
                    rtbTaxBuildingPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitTaxlandService.TaxBuildingPrice);
                    rntValueTaxLand.Text = PFSCommon.FormatNumber(((oLpaNonUnitTaxlandService.TaxLandArea * oLpaNonUnitTaxlandService.TaxLandPrice)
                        + (oLpaNonUnitTaxlandService.TaxBuildingArea * oLpaNonUnitTaxlandService.TaxBuildingPrice)));
                }
                else
                {
                    tbTaxLandDataValue.Text = "";
                    rtbTaxLandYear.Value = null;
                    rtbTaxLandArea.Text = "0";
                    rtbTaxBuildingArea.Text = "0";
                    rtbTaxLandPrice.Text = "0";
                    rtbTaxBuildingPrice.Text = "0";
                    //tbValueTaxLand.Text = ((oLpaUnitTaxlandService.TaxLandArea * oLpaUnitTaxlandService.TaxLandPrice)
                    //    + (oLpaUnitTaxlandService.TaxBuildingArea * oLpaUnitTaxlandService.TaxBuildingPrice)).ToString("#,##0.00"); 
                    rntValueTaxLand.Text = "";
                    hfTaxLandId.Value = "0";
                }

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbTaxLandDataValue.Enabled = false;
                    rtbTaxLandYear.Enabled = false;
                    rtbTaxLandArea.Enabled = false;
                    rtbTaxBuildingArea.Enabled = false;
                    rtbTaxLandPrice.Enabled = false;
                    rtbTaxBuildingPrice.Enabled = false;
                    rntValueTaxLand.Enabled = false;
                    btnSaveTaxLand.Visible = false;
                    btnDeleteTaxLand.Visible = false;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#taxLand');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveTaxLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                int iHfTaxLandId = 0;
                LpaNonUnitTaxLandService oLpaNonUnitTaxlandService = null;

                if (PFSCommon.IsNumeric(hfTaxLandId.Value))
                {
                    iHfTaxLandId = Convert.ToInt32(hfTaxLandId.Value);
                }

                if (iHfTaxLandId != 0)
                {
                    oLpaNonUnitTaxlandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices
                        .Where(o => o.LpaNonUnitTaxLandId == iHfTaxLandId).FirstOrDefault();
                }
                else
                {
                    oLpaNonUnitTaxlandService = new LpaNonUnitTaxLandService();
                    oLpaNonUnitTaxlandService.LpaNonUnitTaxLandId = vsLpaNonUnitTaxLandId = vsLpaNonUnitTaxLandId - 1;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices.Add(oLpaNonUnitTaxlandService);
                }

                oLpaNonUnitTaxlandService.TaxLandDataValue = tbTaxLandDataValue.Text;
                oLpaNonUnitTaxlandService.TaxLandYear = rtbTaxLandYear.Value == null ? "" : rtbTaxLandYear.Value.Value.ToString();
                if (PFSCommon.IsNumeric(rtbTaxLandArea.Text))
                {
                    oLpaNonUnitTaxlandService.TaxLandArea = Convert.ToDouble(rtbTaxLandArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitTaxlandService.TaxLandArea = 0;
                }

                if (PFSCommon.IsNumeric(rtbTaxBuildingArea.Text))
                {
                    oLpaNonUnitTaxlandService.TaxBuildingArea = Convert.ToDouble(rtbTaxBuildingArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitTaxlandService.TaxBuildingArea = 0;
                }

                if (PFSCommon.IsNumeric(rtbTaxLandPrice.Text))
                {
                    oLpaNonUnitTaxlandService.TaxLandPrice = Convert.ToDouble(rtbTaxLandPrice.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitTaxlandService.TaxLandPrice = 0;
                }

                if (PFSCommon.IsNumeric(rtbTaxBuildingPrice.Text))
                {
                    oLpaNonUnitTaxlandService.TaxBuildingPrice = Convert.ToDouble(rtbTaxBuildingPrice.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaNonUnitTaxlandService.TaxBuildingPrice = 0;
                }


                rgTaxLand.Rebind();
                rgTaxLand.SelectedIndexes.Clear();
                hfTaxLandId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteTaxLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgTaxLand.SelectedValues != null && rgTaxLand.SelectedValues.Count > 0)
                {

                    int iSelectedId = (int)rgTaxLand.SelectedValues["LpaNonUnitTaxLandId"];
                    LpaNonUnitTaxLandService oLpaNonUnitTaxlandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices
                        .Where(o => o.LpaNonUnitTaxLandId == iSelectedId).FirstOrDefault();
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices.Remove(oLpaNonUnitTaxlandService);

                    rgTaxLand.Rebind();
                    rgTaxLand.SelectedIndexes.Clear();
                    hfTaxLandId.Value = "0";

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelTaxLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                hfTaxLandId.Value = "0";
                rgTaxLand.Rebind();
                rgTaxLand.SelectedIndexes.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Market Comparative
        protected void lbtAddMarketComparative_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaComparativeNonunitServices.Count == 3 && rgMarketComparative.SelectedItems.Count == 0)
                {
                    Alert("Market Comparative tidak dapat ditambah lagi");
                    return;
                }

                rdpComparativeNonUnitSellingDate.MaxDate = DateTime.Now;
                rdpOfferingDate.MaxDate = DateTime.Now;
               
                if (rgMarketComparative.SelectedItems.Count > 0)
                {
                    int iSelectedId = (int)rgMarketComparative.SelectedValues["LpaComparativeNonUnitId"];
                    hfMarketComparativeId.Value = iSelectedId.ToString();
                    LpaComparativeNonunitService oLpaComparativeNonUnitService = sessLpa.LpaComparativeNonunitServices
                        .Where(o => o.LpaComparativeNonUnitId == iSelectedId).FirstOrDefault();

                    if (oLpaComparativeNonUnitService.ComparativeNonUnitSellingDate <= DateTime.Parse("1900/1/1"))
                    {
                        rdpComparativeNonUnitSellingDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpComparativeNonUnitSellingDate.SelectedDate = oLpaComparativeNonUnitService.ComparativeNonUnitSellingDate;
                    }
                    if (oLpaComparativeNonUnitService.ComparativeNonUnitDataStatus > 0 && ddlComparativeNonUnitDataStatus.Items.Count > 0)
                    {
                        ddlComparativeNonUnitDataStatus.SelectedValue = oLpaComparativeNonUnitService.ComparativeNonUnitDataStatus.ToString();
                    }
                    tbComparativeNonUnitDataStatusDescription.Text = oLpaComparativeNonUnitService.ComparativeNonUnitDataStatusDescription;

                    if (oLpaComparativeNonUnitService.ComparativeNonUnitDataSource > 0 && ddlComparativeNonUnitDataSource.Items.Count > 0)
                    {
                        ddlComparativeNonUnitDataSource.SelectedValue = oLpaComparativeNonUnitService.ComparativeNonUnitDataSource.ToString();
                    }
                    tbComparativeNonUnitDataSourceDescription.Text = oLpaComparativeNonUnitService.ComparativeNonUnitDataSourceDescription;
                    tbComparativeNonUnitAddress1.Text = oLpaComparativeNonUnitService.ComparativeNonUnitAddress1;
                    tbComparativeNonUnitAddress2.Text = oLpaComparativeNonUnitService.ComparativeNonUnitAddress2;
                    tbComparativeNonUnitAddress3.Text = oLpaComparativeNonUnitService.ComparativeNonUnitAddress3;
                    rtbComparativeNonUnitRadius.Text = PFSCommon.FormatNumber(oLpaComparativeNonUnitService.ComparativeNonUnitRadius);
                    rtbComparativeNonUnitWidthStreet.Text = PFSCommon.FormatNumber(oLpaComparativeNonUnitService.ComparativeNonUnitWidthStreet);
                    tbComparativeNonUnitLegality.Text = oLpaComparativeNonUnitService.ComparativeNonUnitLegality;
                    rtbComparativeNonUnitAmount.Text = PFSCommon.FormatNumber(oLpaComparativeNonUnitService.ComparativeNonUnitAmount);
                    tbComparativeNonUnitPosition.Text = oLpaComparativeNonUnitService.ComparativeNonUnitPosition;
                    tbComparativeNonUnitDirection.Text = oLpaComparativeNonUnitService.ComparativeNonUnitDirection;
                    rtbComparativeNonUnitLandArea.Text = PFSCommon.FormatNumber(oLpaComparativeNonUnitService.ComparativeNonUnitLandArea);
                    rtbComparativeNonUnitBuildingArea.Text = PFSCommon.FormatNumber(oLpaComparativeNonUnitService.ComparativeNonUnitBuildingArea);
                    if (string.IsNullOrWhiteSpace(oLpaComparativeNonUnitService.ComparativeNonUnitCreatedYear))
                    {
                        rtbComparativeNonUnitCreatedYear.Text = "";
                    }
                    else
                    {
                        if (PFSCommon.IsNumeric(oLpaComparativeNonUnitService.ComparativeNonUnitCreatedYear))
                        {
                            rtbComparativeNonUnitCreatedYear.Value = Convert.ToInt32(oLpaComparativeNonUnitService.ComparativeNonUnitCreatedYear);
                        }
                    }
                    if (string.IsNullOrWhiteSpace(oLpaComparativeNonUnitService.ComparativeNonUnitRenovationYear))
                    {
                        rtbComparativeNonUnitRenovationYear.Text = "";
                    }
                    else
                    {
                        if (PFSCommon.IsNumeric(oLpaComparativeNonUnitService.ComparativeNonUnitRenovationYear))
                        {
                            rtbComparativeNonUnitRenovationYear.Value = Convert.ToInt32(oLpaComparativeNonUnitService.ComparativeNonUnitRenovationYear);
                        }
                    }
                    tbComparativeNonUnitAreaPosition.Text = oLpaComparativeNonUnitService.ComparativeNonUnitAreaPosition;
                    //rtbComparativeNonUnitSellingPriceHomeCurrency.Value = oLpaComparativeNonUnitService.ComparativeNonUnitSellingPriceHomeCurrency;
                    rtbComparativeNonUnitDiscountRecommended.Value = oLpaComparativeNonUnitService.ComparativeNonUnitDiscountRecommended;
                    tbComparativeSalesName.Text = oLpaComparativeNonUnitService.ComparativeNonUnitMarketingName;
                    tbComparativeSalesPhoneNo.Text = oLpaComparativeNonUnitService.ComparativeNonUnitMarketingPhone;

                    rtbComparativeNonUnitSellingPriceDiscount.Value = oLpaComparativeNonUnitService.ComparativeNonUnitSellingPriceDiscount;
                    rtbComparativeNonUnitFurnishPrice.Text = PFSCommon.FormatNumber(oLpaComparativeNonUnitService.ComparativeNonUnitFurnishPrice);
                    tbComparativeNonUnitDescription.Text = oLpaComparativeNonUnitService.ComparativeNonUnitDescription;
                    rtbComparativeNonUnitNewBuildingPrice.Text = PFSCommon.FormatNumber(oLpaComparativeNonUnitService.ComparativeNonUnitNewBuildingPrice);
                    rtbComparativeNonUnitDepreciation.Value = oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation;
                    rtbComparativeNonUnitDataPercentage.Value = oLpaComparativeNonUnitService.ComparativeNonUnitDataPercentage;
                    rntPredictioValue.Text = PFSCommon.FormatNumber((oLpaComparativeNonUnitService.ComparativeNonUnitAmount - oLpaComparativeNonUnitService.ComparativeNonUnitFurnishPrice) * ((100 - oLpaComparativeNonUnitService.ComparativeNonUnitSellingPriceDiscount) / 100));
                    if (!PFSCommon.IsNumeric(rntPredictioValue.Text))
                        rntPredictioValue.Text = "0";

                    //rntPredictionValueAfterAdjusment.Text = PFSCommon.FormatNumber(Convert.ToDouble(rntPredictioValue.Text, new CultureInfo("id-ID")) * oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation / 100 < 0 ? 0 : Convert.ToDouble(rntPredictioValue.Text, new CultureInfo("id-ID")) * oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation / 100);

                    //if (rntPredictionValueAfterAdjusment.Text.Trim().Length == 0)
                    //    rntPredictionValueAfterAdjusment.Text = "0";

                    if (!PFSCommon.IsNumeric(rtbComparativeNonUnitNewBuildingPrice.Text))
                        rtbComparativeNonUnitNewBuildingPrice.Text = "0";

                    tbEstimateBuildingValue.Text =
                        PFSCommon.FormatNumber(
                            (Convert.ToDouble(rtbComparativeNonUnitBuildingArea.Text, new CultureInfo("id-ID")) *
                             Convert.ToDouble(rtbComparativeNonUnitNewBuildingPrice.Text, new CultureInfo("id-ID"))
                             * (1 - (Convert.ToDouble(rtbComparativeNonUnitDepreciation.Text, new CultureInfo("id-ID")) / 100))))
                                .ToString();

                    tbEstimateLandValue.Text =
                        PFSCommon.FormatNumber(
                         (((Convert.ToDouble(
                             rntPredictioValue.Text == "" ? "0" : rntPredictioValue.Text,
                             new CultureInfo("id-ID"))) -
                          ((Convert.ToDouble(rtbComparativeNonUnitBuildingArea.Text, new CultureInfo("id-ID"))) *
                          (Convert.ToDouble(rtbComparativeNonUnitNewBuildingPrice.Text, new CultureInfo("id-ID"))) *
                          (1 - ((Convert.ToDouble(rtbComparativeNonUnitDepreciation.Text == "" ? "0" : rtbComparativeNonUnitDepreciation.Text, new CultureInfo("id-ID"))) / 100)))) /
                          Convert.ToDouble(rtbComparativeNonUnitLandArea.Text, new CultureInfo("id-ID")))).ToString();

                    rntIndicationUnitValue.Text = PFSCommon.FormatNumber((Convert.ToDouble(tbEstimateLandValue.Text == "" ? "0" : Convert.ToDouble(tbEstimateLandValue.Text, new CultureInfo("id-ID")).ToString()) * oLpaComparativeNonUnitService.ComparativeNonUnitDataPercentage) / 100);

                    if (oLpaComparativeNonUnitService.OfferingDate <= new DateTime(1900, 1, 1))
                    {
                        rdpOfferingDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpOfferingDate.SelectedDate = oLpaComparativeNonUnitService.OfferingDate;
                    }

                    if (oLpaComparativeNonUnitService.ConfirmationDate <= new DateTime(1900, 1, 1))
                    {
                        rdpConfirmationDate.SelectedDate = null;
                    }
                    else
                    {
                        rdpConfirmationDate.SelectedDate = oLpaComparativeNonUnitService.ConfirmationDate;
                    }
                }
                else
                {
                    rdpComparativeNonUnitSellingDate.SelectedDate = null;
                    ddlComparativeNonUnitDataStatus.SelectedIndex = 0;
                    tbComparativeNonUnitDataStatusDescription.Text = "";
                    ddlComparativeNonUnitDataSource.SelectedIndex = 0;
                    tbComparativeNonUnitDataSourceDescription.Text = "";
                    tbComparativeNonUnitAddress1.Text = "";
                    tbComparativeNonUnitAddress2.Text = "";
                    tbComparativeNonUnitAddress3.Text = "";
                    rtbComparativeNonUnitRadius.Text = "";
                    rtbComparativeNonUnitWidthStreet.Text = "";
                    tbComparativeNonUnitLegality.Text = "";
                    rtbComparativeNonUnitAmount.Text = "";
                    tbComparativeNonUnitPosition.Text = "";
                    tbComparativeNonUnitDirection.Text = "";
                    rtbComparativeNonUnitLandArea.Text = "";
                    rtbComparativeNonUnitBuildingArea.Text = "";
                    rtbComparativeNonUnitCreatedYear.Text = "";
                    rtbComparativeNonUnitRenovationYear.Text = "";
                    tbComparativeNonUnitAreaPosition.Text = "";
                    //rtbComparativeNonUnitSellingPriceHomeCurrency.Value = null;
                    rtbComparativeNonUnitDiscountRecommended.Text = "0";
                    rtbComparativeNonUnitSellingPriceDiscount.Value = null;
                    rtbComparativeNonUnitFurnishPrice.Text = "";
                    tbComparativeNonUnitDescription.Text = "";
                    rtbComparativeNonUnitNewBuildingPrice.Text = "0";
                    rtbComparativeNonUnitDepreciation.Value = null;
                    rtbComparativeNonUnitDataPercentage.Value = null;
                    tbComparativeSalesName.Text = "";
                    tbComparativeSalesPhoneNo.Text = "";
                    rntPredictioValue.Text = "";
                    tbEstimateBuildingValue.Text = "";
                    rntIndicationUnitValue.Text = "";
                    tbEstimateLandValue.Text = "";

                    hfMarketComparativeId.Value = "0";
                }

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    rdpComparativeNonUnitSellingDate.Enabled = false;
                    ddlComparativeNonUnitDataStatus.Enabled = false;
                    tbComparativeNonUnitDataStatusDescription.Enabled = false;
                    ddlComparativeNonUnitDataSource.Enabled = false;
                    tbComparativeNonUnitDataSourceDescription.Enabled = false;
                    tbComparativeNonUnitAddress1.Enabled = false;
                    tbComparativeNonUnitAddress2.Enabled = false;
                    tbComparativeNonUnitAddress3.Enabled = false;
                    rtbComparativeNonUnitRadius.Enabled = false;
                    rtbComparativeNonUnitWidthStreet.Enabled = false;
                    tbComparativeNonUnitLegality.Enabled = false;
                    rtbComparativeNonUnitAmount.Enabled = false;
                    tbComparativeNonUnitPosition.Enabled = false;
                    tbComparativeNonUnitDirection.Enabled = false;
                    rtbComparativeNonUnitLandArea.Enabled = false;
                    rtbComparativeNonUnitBuildingArea.Enabled = false;
                    rtbComparativeNonUnitCreatedYear.Enabled = false;
                    rtbComparativeNonUnitRenovationYear.Enabled = false;
                    tbComparativeNonUnitAreaPosition.Enabled = false;
                    //rtbComparativeNonUnitSellingPriceHomeCurrency.Value = null;
                    rtbComparativeNonUnitDiscountRecommended.Enabled = false;
                    rtbComparativeNonUnitSellingPriceDiscount.Enabled = false;
                    rtbComparativeNonUnitFurnishPrice.Enabled = false;
                    tbComparativeNonUnitDescription.Enabled = false;
                    rtbComparativeNonUnitNewBuildingPrice.Enabled = false;
                    rtbComparativeNonUnitDepreciation.Enabled = false;
                    rtbComparativeNonUnitDataPercentage.Enabled = false;
                    tbComparativeSalesName.Enabled = false;
                    tbComparativeSalesPhoneNo.Enabled = false;
                    rdpOfferingDate.Enabled = false;
                    rdpConfirmationDate.Enabled = false;
                    btnSaveMarketComparative.Visible = false;
                    btnDeleteMarketComparative.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#marketComparative');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveMarketComparative_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rtbComparativeNonUnitCreatedYear.Text.Trim().Length > 0)
                {
                    if (!PFSCommon.IsNumeric(rtbComparativeNonUnitCreatedYear.Text.Trim()) || Convert.ToInt32(rtbComparativeNonUnitCreatedYear.Text.Trim()) > DateTime.Now.Year)
                    {
                        Alert("Tahun Dibangun Tidak Valid");
                        return;
                    }
                }

                if (rtbComparativeNonUnitRenovationYear.Text.Trim().Length > 0)
                {
                    if (!PFSCommon.IsNumeric(rtbComparativeNonUnitRenovationYear.Text.Trim()) || Convert.ToInt32(rtbComparativeNonUnitRenovationYear.Text.Trim()) > DateTime.Now.Year)
                    {
                        Alert("Tahun Direnovasi Tidak Valid");
                        return;
                    }
                }

                int iHfMarketComparativeId = 0;
                LpaComparativeNonunitService oLpaComparativeNonUnitService = new LpaComparativeNonunitService();
                if (PFSCommon.IsNumeric(hfMarketComparativeId.Value))
                {
                    iHfMarketComparativeId = Convert.ToInt32(hfMarketComparativeId.Value);
                }
                oLpaComparativeNonUnitService.ComparativeNonUnitSellingDate = rdpComparativeNonUnitSellingDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpComparativeNonUnitSellingDate.SelectedDate.Value;
                oLpaComparativeNonUnitService.ComparativeNonUnitDataStatusDescription = tbComparativeNonUnitDataStatusDescription.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitDataSourceDescription = tbComparativeNonUnitDataSourceDescription.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitAddress1 = tbComparativeNonUnitAddress1.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitAddress2 = tbComparativeNonUnitAddress2.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitAddress3 = tbComparativeNonUnitAddress3.Text;
                if (PFSCommon.IsNumeric(rtbComparativeNonUnitRadius.Text))
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitRadius = Convert.ToDouble(rtbComparativeNonUnitRadius.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitRadius = 0;
                }

                if (PFSCommon.IsNumeric(rtbComparativeNonUnitWidthStreet.Text))
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitWidthStreet = Convert.ToDouble(rtbComparativeNonUnitWidthStreet.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitWidthStreet = 0;
                }

                if (PFSCommon.IsNumeric(rtbComparativeNonUnitAmount.Text))
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitAmount = Convert.ToDouble(rtbComparativeNonUnitAmount.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitAmount = 0;
                }
                oLpaComparativeNonUnitService.ComparativeNonUnitLegality = tbComparativeNonUnitLegality.Text;

                oLpaComparativeNonUnitService.ComparativeNonUnitPosition = tbComparativeNonUnitPosition.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitDirection = tbComparativeNonUnitDirection.Text;

                if (PFSCommon.IsNumeric(rtbComparativeNonUnitLandArea.Text))
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitLandArea = Convert.ToDouble(rtbComparativeNonUnitLandArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitLandArea = 0;
                }

                if (PFSCommon.IsNumeric(rtbComparativeNonUnitBuildingArea.Text))
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitBuildingArea = Convert.ToDouble(rtbComparativeNonUnitBuildingArea.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitBuildingArea = 0;
                }

                oLpaComparativeNonUnitService.ComparativeNonUnitCreatedYear = rtbComparativeNonUnitCreatedYear.Value == null ? "" : rtbComparativeNonUnitCreatedYear.Value.Value.ToString();
                oLpaComparativeNonUnitService.ComparativeNonUnitRenovationYear = rtbComparativeNonUnitRenovationYear.Value == null ? "" : rtbComparativeNonUnitRenovationYear.Value.Value.ToString();
                oLpaComparativeNonUnitService.ComparativeNonUnitAreaPosition = tbComparativeNonUnitAreaPosition.Text;
                // oLpaComparativeNonUnitService.ComparativeNonUnitSellingPriceHomeCurrency = rtbComparativeNonUnitSellingPriceHomeCurrency.Value == null ? 0 : rtbComparativeNonUnitSellingPriceHomeCurrency.Value.Value;
                oLpaComparativeNonUnitService.ComparativeNonUnitSellingPriceDiscount = rtbComparativeNonUnitSellingPriceDiscount.Value == null ? 0 : rtbComparativeNonUnitSellingPriceDiscount.Value.Value;

                if (PFSCommon.IsNumeric(rtbComparativeNonUnitFurnishPrice.Text))
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitFurnishPrice = Convert.ToDouble(rtbComparativeNonUnitFurnishPrice.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitFurnishPrice = 0;
                }

                oLpaComparativeNonUnitService.ComparativeNonUnitDescription = tbComparativeNonUnitDescription.Text;

                if (PFSCommon.IsNumeric(rtbComparativeNonUnitNewBuildingPrice.Text))
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitNewBuildingPrice = Convert.ToDouble(rtbComparativeNonUnitNewBuildingPrice.Text, new CultureInfo("id-ID"));
                }
                else
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitNewBuildingPrice = 0;
                }

                oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation = rtbComparativeNonUnitDepreciation.Value == null ? 0 : rtbComparativeNonUnitDepreciation.Value.Value;
                oLpaComparativeNonUnitService.ComparativeNonUnitDataPercentage = rtbComparativeNonUnitDataPercentage.Value == null ? 0 : rtbComparativeNonUnitDataPercentage.Value.Value;
                if (ddlComparativeNonUnitDataSource.SelectedValue != null)
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitDataSource = Convert.ToInt32(ddlComparativeNonUnitDataSource.SelectedValue);
                    oLpaComparativeNonUnitService.SourceDataDescription = ddlComparativeNonUnitDataSource.SelectedItem.ToString();
                }

                if (ddlComparativeNonUnitDataStatus.SelectedValue != null)
                {
                    oLpaComparativeNonUnitService.ComparativeNonUnitDataStatus = Convert.ToInt32(ddlComparativeNonUnitDataStatus.SelectedValue);
                    oLpaComparativeNonUnitService.StatusDataDescription = ddlComparativeNonUnitDataStatus.SelectedItem.Text;
                }
                oLpaComparativeNonUnitService.ComparativeNonUnitDataSourceDescription = tbComparativeNonUnitDataSourceDescription.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitDataStatusDescription = tbComparativeNonUnitDataStatusDescription.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitMarketingName = tbComparativeSalesName.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitMarketingPhone = tbComparativeSalesPhoneNo.Text;
                oLpaComparativeNonUnitService.ComparativeNonUnitDiscountRecommended = rtbComparativeNonUnitDiscountRecommended.Value == null ? 0 : rtbComparativeNonUnitDiscountRecommended.Value.Value;
                oLpaComparativeNonUnitService.OfferingDate = rdpOfferingDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpOfferingDate.SelectedDate.Value;
                oLpaComparativeNonUnitService.ConfirmationDate = rdpConfirmationDate.SelectedDate == null ? new DateTime(1900, 1, 1) : rdpConfirmationDate.SelectedDate.Value;

                oLpaComparativeNonUnitService.RefOrderCollateralDetailId = qsOrderCollateralDetailId;

                if (iHfMarketComparativeId != 0)
                {
                    if (rgMarketComparative.SelectedValues["LpaComparativeNonUnitId"] != null)
                    {
                        int iSelectedId = (int)rgMarketComparative.SelectedValues["LpaComparativeNonUnitId"];
                        for (int i = 0; i < sessLpa.LpaComparativeNonunitServices.Count; i++)
                        {
                            if (sessLpa.LpaComparativeNonunitServices[i].LpaComparativeNonUnitId == iSelectedId)
                            {
                                oLpaComparativeNonUnitService.LpaComparativeNonUnitId = iSelectedId;

                                if (sessSearchMarketComparativeIdResultSearch != 0)
                                {
                                    oLpaComparativeNonUnitService.RefDatabaseId = sessSearchMarketComparativeIdResultSearch;
                                    sessSearchMarketComparativeIdResultSearch = 0;
                                }

                                oLpaComparativeNonUnitService.LpaContactComparativeServices = sessLpa.LpaComparativeNonunitServices[i].LpaContactComparativeServices;
                                sessLpa.LpaComparativeNonunitServices[i] = oLpaComparativeNonUnitService;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    oLpaComparativeNonUnitService.LpaComparativeNonUnitId = vsLpaComparativeNonUnitId = vsLpaComparativeNonUnitId - 1;
                    sessLpa.LpaComparativeNonunitServices.Add(oLpaComparativeNonUnitService);

                    if (sessSearchMarketComparativeIdResultSearch != 0)
                    {
                        oLpaComparativeNonUnitService.RefDatabaseId = sessSearchMarketComparativeIdResultSearch;
                        sessSearchMarketComparativeIdResultSearch = 0;
                    }
                    sessLpa.LpaComparativeNonunitServices[sessLpa.LpaComparativeNonunitServices.Count - 1].LpaContactComparativeServices = new List<LpaContactComparativeService>();

                }

                rgMarketComparative.Rebind();
                rgMarketComparative.SelectedIndexes.Clear();
                hfMarketComparativeId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteMarketComparative_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgMarketComparative.SelectedValues != null && rgMarketComparative.SelectedValues.Count > 0)
                {

                    int iSelectedId = (int)rgMarketComparative.SelectedValues["LpaComparativeNonUnitId"];
                    LpaComparativeNonunitService oLpaComparativeNonUnitService = sessLpa.LpaComparativeNonunitServices
                        .Where(o => o.LpaComparativeNonUnitId == iSelectedId).FirstOrDefault();
                    sessLpa.LpaComparativeNonunitServices.Remove(oLpaComparativeNonUnitService);

                    rgMarketComparative.Rebind();
                    rgMarketComparative.SelectedIndexes.Clear();
                    hfMarketComparativeId.Value = "0";

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelMarketComparative_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                hfMarketComparativeId.Value = "0";
                rgMarketComparative.Rebind();
                rgMarketComparative.SelectedIndexes.Clear();

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rdpComparativeNonUnitSellingDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rdpComparativeNonUnitSellingDate.SelectedDate == null)
                {
                    rtbComparativeNonUnitDiscountRecommended.Value = 0;
                    return;
                }

                if (ddlComparativeNonUnitDataStatus.SelectedValue == "0")
                {
                    rtbComparativeNonUnitDiscountRecommended.Value = 0;
                    return;
                }

                if (Convert.ToInt32(ddlComparativeNonUnitDataStatus.SelectedValue) == (int)ProTaksatur.WebUI.App_Code.Enumeration.DataStatus.Terjual
                    || Convert.ToInt32(ddlComparativeNonUnitDataStatus.SelectedValue) == (int)ProTaksatur.WebUI.App_Code.Enumeration.DataStatus.Tersewa
                    || Convert.ToInt32(ddlComparativeNonUnitDataStatus.SelectedValue) == (int)ProTaksatur.WebUI.App_Code.Enumeration.DataStatus.TidakDitawarkan)
                {
                    rtbComparativeNonUnitDiscountRecommended.Text = "0";
                    return;
                }

                double dDifferenceDate = (DateTime.Now - rdpComparativeNonUnitSellingDate.SelectedDate.Value).TotalDays / 30;
                double dRecommendedValue = 0;
                if (dDifferenceDate <= 0)
                {
                    dRecommendedValue = 0;
                }
                else if (dDifferenceDate < 3)
                {
                    dRecommendedValue = 5;
                }
                else if (dDifferenceDate < 10)
                {
                    dRecommendedValue = 10;
                }
                else if (dDifferenceDate < 12)
                {
                    dRecommendedValue = 15;
                }
                else if (dDifferenceDate < 18)
                {
                    dRecommendedValue = 20;
                }
                else if (dDifferenceDate < 24)
                {
                    dRecommendedValue = 25;
                }
                else
                {
                    dRecommendedValue = 30;
                }

                rtbComparativeNonUnitDiscountRecommended.Value = dRecommendedValue;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }

        }
        #endregion

        #region Form Non Unit Land

        protected void lbtAddNonUnitLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitLand.SelectedItems.Count > 0)
                {
                    int iSelectedId = (int)rgNonUnitLand.SelectedValues["LpaNonUnitLandId"];
                    hfNonUnitLandId.Value = iSelectedId.ToString();
                    LpaNonUnitLandService oLpaNonUnitLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                        .Where(o => o.LpaNonUnitLandId == iSelectedId).FirstOrDefault();

                    tbNonUnitLandDescription.Text = oLpaNonUnitLandService.LandDescription;
                }
                else
                {
                    tbNonUnitLandDescription.Text = "";
                }

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbNonUnitLandDescription.Enabled = false;
                    btnSaveNonUnitLand.Visible = false;
                    btnDeleteNonUnitLand.Visible = false;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaNonUnitLand');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveNonUnitLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                int iHfNonUnitLandId = 0;
                LpaNonUnitLandService oLpaNonUnitLandService = null;

                if (PFSCommon.IsNumeric(hfNonUnitLandId.Value))
                {
                    iHfNonUnitLandId = Convert.ToInt32(hfNonUnitLandId.Value);
                }

                if (iHfNonUnitLandId != 0)
                {
                    oLpaNonUnitLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                  .Where(o => o.LpaNonUnitLandId == iHfNonUnitLandId).FirstOrDefault();
                    oLpaNonUnitLandService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oLpaNonUnitLandService.UpdateDate = DateTime.Now;
                }
                else
                {
                    oLpaNonUnitLandService = new LpaNonUnitLandService();
                    oLpaNonUnitLandService.LpaNonUnitLandId = vsLpaNonUnitLandId = vsLpaNonUnitLandId - 1;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Add(oLpaNonUnitLandService);
                    oLpaNonUnitLandService.CreateByUserId = oLpaNonUnitLandService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oLpaNonUnitLandService.CreateDate = oLpaNonUnitLandService.UpdateDate = DateTime.Now;
                    oLpaNonUnitLandService.LpaNonUnitValueLandServices = new List<LpaNonUnitValueLandService>();
                }

                oLpaNonUnitLandService.LandDescription = tbNonUnitLandDescription.Text.Trim();

                rgNonUnitLand.Rebind();
                hfNonUnitLandId.Value = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteNonUnitLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitLand.SelectedValues != null && rgNonUnitLand.SelectedValues.Count > 0)
                {
                    int iSelectedId = (int)rgNonUnitLand.SelectedValues["LpaNonUnitLandId"];
                    LpaNonUnitLandService oLpaNonUnitLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                        .Where(o => o.LpaNonUnitLandId == iSelectedId).FirstOrDefault();

                    if (oLpaNonUnitLandService != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Remove(oLpaNonUnitLandService);
                    }

                    rgNonUnitLand.Rebind();
                    hfNonUnitLandId.Value = "0";
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelNonUnitLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                rgNonUnitLand.Rebind();
                rgNonUnitLand.SelectedIndexes.Clear();
                hfNonUnitLandId.Value = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Form Non Unit Building

        protected void lbtAddNonUnitBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitBuilding.SelectedItems.Count > 0)
                {
                    int iSelectedId = (int)rgNonUnitBuilding.SelectedValues["LpaNonUnitBuildingId"];
                    hfNonUnitBuildingId.Value = iSelectedId.ToString();
                    LpaNonUnitBuildingService oLpaNonUnitBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iSelectedId).FirstOrDefault();
                    tbBuildingDescription.Text = oLpaNonUnitBuildingService.BuildingDescription;
                }
                else
                {
                    tbBuildingDescription.Text = "";
                }

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbBuildingDescription.Enabled = false;
                    btnSaveNonUnitBuilding.Visible = false;
                    btnDeleteNonUnitBuilding.Visible = false;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaNonUnitBuilding');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveNonUnitBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                int iHfNonUnitBuildingId = 0;
                LpaNonUnitBuildingService oLpaNonUnitBuildingService = null;

                if (PFSCommon.IsNumeric(hfNonUnitBuildingId.Value))
                {
                    iHfNonUnitBuildingId = Convert.ToInt32(hfNonUnitBuildingId.Value);
                }

                if (iHfNonUnitBuildingId != 0)
                {
                    oLpaNonUnitBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iHfNonUnitBuildingId).FirstOrDefault();
                    oLpaNonUnitBuildingService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oLpaNonUnitBuildingService.UpdateDate = DateTime.Now;
                }
                else
                {
                    oLpaNonUnitBuildingService = new LpaNonUnitBuildingService();
                    oLpaNonUnitBuildingService.LpaNonUnitBuildingId = vsLpaNonUnitBuildingId = vsLpaNonUnitBuildingId - 1;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Add(oLpaNonUnitBuildingService);
                    oLpaNonUnitBuildingService.CreateByUserId = oLpaNonUnitBuildingService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oLpaNonUnitBuildingService.CreateDate = oLpaNonUnitBuildingService.UpdateDate = DateTime.Now;
                    oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices = new List<LpaNonUnitValueBuildingService>();
                }

                oLpaNonUnitBuildingService.BuildingDescription = tbBuildingDescription.Text;

                rgNonUnitBuilding.Rebind();
                hfNonUnitBuildingId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteNonUnitBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitBuilding.SelectedValues != null && rgNonUnitBuilding.SelectedValues.Count > 0)
                {
                    int iSelectedId = (int)rgNonUnitBuilding.SelectedValues["LpaNonUnitBuildingId"];
                    LpaNonUnitBuildingService oLpaNonUnitBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iSelectedId).FirstOrDefault();

                    if (oLpaNonUnitBuildingService != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Remove(oLpaNonUnitBuildingService);
                    }
                }

                rgNonUnitBuilding.Rebind();
                hfNonUnitBuildingId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelNonUnitBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                rgNonUnitBuilding.Rebind();
                hfNonUnitBuildingId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        #region Form Non Unit Facility

        protected void lbtAddNonUnitFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitFacility.SelectedItems.Count > 0)
                {
                    int iSelectedId = (int)rgNonUnitFacility.SelectedValues["LpaNonUnitFacilityId"];
                    hfNonUnitFacilityId.Value = iSelectedId.ToString();
                    LpaNonUnitFacilityService oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iSelectedId).FirstOrDefault();
                    tbFacilityDescription.Text = oLpaNonUnitFacilityService.FacilityDescription;
                }
                else
                {
                    tbFacilityDescription.Text = "";
                }

                if (qsLpaId > 0 && qsActionType == "View")
                {
                    tbFacilityDescription.Enabled = false;
                    btnSaveNonUnitFacility.Visible = false;
                    btnDeleteNonUnitFacility.Visible = false;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#lpaNonUnitFacility');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveNonUnitFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                int iHfNonUnitFacilityId = 0;
                LpaNonUnitFacilityService oLpaNonUnitFacilityService = null;

                if (PFSCommon.IsNumeric(hfNonUnitFacilityId.Value))
                {
                    iHfNonUnitFacilityId = Convert.ToInt32(hfNonUnitFacilityId.Value);
                }

                if (iHfNonUnitFacilityId != 0)
                {
                    oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iHfNonUnitFacilityId).FirstOrDefault();
                    oLpaNonUnitFacilityService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oLpaNonUnitFacilityService.UpdateDate = DateTime.Now;
                }
                else
                {
                    oLpaNonUnitFacilityService = new LpaNonUnitFacilityService();
                    oLpaNonUnitFacilityService.LpaNonUnitFacilityId = vsLpaNonUnitFacilityId = vsLpaNonUnitFacilityId - 1;
                    oLpaNonUnitFacilityService.CreateByUserId = oLpaNonUnitFacilityService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oLpaNonUnitFacilityService.CreateDate = oLpaNonUnitFacilityService.UpdateDate = DateTime.Now;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices.Add(oLpaNonUnitFacilityService);
                    oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices = new List<LpaNonUnitValueFacilityService>();
                }

                oLpaNonUnitFacilityService.FacilityDescription = tbFacilityDescription.Text;

                rgNonUnitFacility.Rebind();
                rgNonUnitFacility.SelectedIndexes.Clear();
                hfNonUnitFacilityId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnDeleteNonUnitFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitFacility.SelectedValues != null && rgNonUnitFacility.SelectedValues.Count > 0)
                {
                    int iSelectedId = (int)rgNonUnitFacility.SelectedValues["LpaNonUnitFacilityId"];
                    LpaNonUnitFacilityService oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iSelectedId).FirstOrDefault();

                    if (oLpaNonUnitFacilityService != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices.Remove(oLpaNonUnitFacilityService);
                    }
                }

                rgNonUnitFacility.Rebind();
                rgNonUnitFacility.SelectedIndexes.Clear();
                hfNonUnitFacilityId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnCancelNonUnitFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                rgNonUnitFacility.Rebind();
                rgNonUnitFacility.SelectedIndexes.Clear();
                hfNonUnitFacilityId.Value = "0";

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Form TotalMarketPrice
        protected void lbtAddTotalMarketPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }
                int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);
                LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService = null;
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();
                }

                if (oLpaNonUnitTotalMarketPriceService == null)
                {
                    oLpaNonUnitTotalMarketPriceService = new LpaNonUnitTotalMarketPriceService();
                    oLpaNonUnitTotalMarketPriceService.LpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId - 1;
                    oLpaNonUnitTotalMarketPriceService.DocumentCalculationId = iDocumentCalculationId;
                    oLpaNonUnitTotalMarketPriceService.LiquidationAmount = 0;
                    oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = 0;
                    if (sessLpa.LpaNonUnitServices != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices.Add(oLpaNonUnitTotalMarketPriceService);
                    }
                }
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService.TotalMarketPrice = (
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Sum(n => n.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => ((100 - o.LandAdjustment) / 100 * (o.ValueLandArea * o.ValueLandPrice)))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Sum(n => n.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => (((o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea) - ((o.EconomicAsumption / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.RepairCost / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.BuildingDepreciation / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea))))))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices.Sum(n => n.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => o.FacilityMeasurement * o.FacilityAmountHomeCurrency))
                    );
                }
                tbTotalMarketPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.TotalMarketPrice);
                rtbLiquidationValuePercentage.Value = oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage;
                tbLiquidationAmount.Text = PFSCommon.FormatNumber((100 - oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage) / 100 * oLpaNonUnitTotalMarketPriceService.TotalMarketPrice);

                if (qsActionType == "View")
                {
                    tbTotalMarketPrice.Enabled = false;
                    tbLiquidationAmount.Enabled = false;
                    rtbLiquidationValuePercentage.Enabled = false;
                    btnSaveTotalMarketPrice.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#totalMarketPrice');", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveTotalMarketPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);
                LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService = null;
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();
                }

                if (oLpaNonUnitTotalMarketPriceService == null)
                {
                    oLpaNonUnitTotalMarketPriceService = new LpaNonUnitTotalMarketPriceService();
                    oLpaNonUnitTotalMarketPriceService.LpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId - 1;
                    oLpaNonUnitTotalMarketPriceService.DocumentCalculationId = iDocumentCalculationId;
                    oLpaNonUnitTotalMarketPriceService.LiquidationAmount = 0;
                    oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = 0;
                    if (sessLpa.LpaNonUnitServices != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices.Add(oLpaNonUnitTotalMarketPriceService);
                    }
                }
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService.TotalMarketPrice = (
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Sum(n => n.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => ((100 - o.LandAdjustment) / 100 * (o.ValueLandArea * o.ValueLandPrice)))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Sum(n => n.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => (((o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea) - ((o.EconomicAsumption / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.RepairCost / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.BuildingDepreciation / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea))))))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices.Sum(n => n.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => o.FacilityMeasurement * o.FacilityAmountHomeCurrency))
                    );
                }

                oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = rtbLiquidationValuePercentage.Value == null ? 0 : rtbLiquidationValuePercentage.Value.Value;
                oLpaNonUnitTotalMarketPriceService.LiquidationAmount = (100 - oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage) / 100 * oLpaNonUnitTotalMarketPriceService.TotalMarketPrice;

                lblTotalMarketPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.TotalMarketPrice);
                lblLiquidationAmount.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationAmount);
                lblLiquidationValuePercentage.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage);

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rtbLiquidationValuePercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);
                LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService = null;
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();
                }

                if (oLpaNonUnitTotalMarketPriceService == null)
                {
                    oLpaNonUnitTotalMarketPriceService = new LpaNonUnitTotalMarketPriceService();
                    oLpaNonUnitTotalMarketPriceService.LpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId - 1;
                    oLpaNonUnitTotalMarketPriceService.DocumentCalculationId = iDocumentCalculationId;
                    oLpaNonUnitTotalMarketPriceService.LiquidationAmount = 0;
                    oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = 0;
                    if (sessLpa.LpaNonUnitServices != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices.Add(oLpaNonUnitTotalMarketPriceService);
                    }
                }
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService.TotalMarketPrice = (
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Sum(n => n.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => ((100 - o.LandAdjustment) / 100 * (o.ValueLandArea * o.ValueLandPrice)))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Sum(n => n.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => (((o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea) - ((o.EconomicAsumption / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.RepairCost / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.BuildingDepreciation / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea))))))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices.Sum(n => n.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => o.FacilityMeasurement * o.FacilityAmountHomeCurrency))
                    );
                }

                oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = rtbLiquidationValuePercentage.Value == null ? 0 : rtbLiquidationValuePercentage.Value.Value;
                oLpaNonUnitTotalMarketPriceService.LiquidationAmount = (100 - oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage) / 100 * oLpaNonUnitTotalMarketPriceService.TotalMarketPrice;

                tbLiquidationAmount.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationAmount);

                // CalculateByDocumentTypeId();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        /* #region Form Contact Person Comparative

        protected void lbtAddMarketComparativeContactPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgMarketComparative.SelectedItems.Count == 0)
                {
                    Alert("Pilih Salah Satu Data Market Comparative");
                    return;
                }

                if (rgMarketComparative.SelectedItems.Count > 0)
                {
                    int iMarketComparativeId = (int)rgMarketComparative.SelectedValues["LpaComparativeNonUnitId"];
                    LpaComparativeNonunitService oLpaComparativeNonunitService = sessLpa.LpaComparativeNonunitServices
                        .Where(o => o.LpaComparativeNonUnitId == iMarketComparativeId).FirstOrDefault();

                    if (rgMarketCOmparativeContactPerson.SelectedItems.Count > 0)
                    {
                        int iCOntactCOmparativeId = (int)rgMarketCOmparativeContactPerson.SelectedValues["LpaContactComparativeContactId"];
                        hfComparativeContactId.Value = iCOntactCOmparativeId.ToString();
                        LpaContactComparativeService oLpaContactComparativeService = oLpaComparativeNonunitService.LpaContactComparativeServices
                            .Where(o => o.LpaContactComparativeContactId == iCOntactCOmparativeId).FirstOrDefault();

                        tbLpaContactComparativeContactName.Text = oLpaContactComparativeService.LpaContactComparativeContactName;
                        tbLpaContactComparativeContactTelephone.Text = oLpaContactComparativeService.LpaContactComparativeContactTelephone;
                        tbLpaContactComparativeContactHandphone.Text = oLpaContactComparativeService.LpaContactComparativeContactHandphone;
                    }
                    else
                    {
                        tbLpaContactComparativeContactName.Text = "";
                        tbLpaContactComparativeContactTelephone.Text = "";
                        tbLpaContactComparativeContactHandphone.Text = "";
                        hfComparativeContactId.Value = "0";
                    }

                    if (qsLpaId > 0 && qsActionType == "View")
                    {
                        tbLpaContactComparativeContactName.Enabled = false;
                        tbLpaContactComparativeContactTelephone.Enabled = false;
                        tbLpaContactComparativeContactHandphone.Enabled = false;
                        btForGridComparativeContactSave.Visible = false;
                        btForGridComparativeContactDelete.Visible = false;
                    }

                    ScriptManager.RegisterStartupScript(this, GetType(), "", "openSlider('#pnForGridComparativeContact');", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btForGridComparativeContactSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgMarketComparative.SelectedItems.Count == 0)
                {
                    Alert("Pilih Salah Satu Data Market Comparative");
                    return;
                }

                if (rgMarketComparative.SelectedItems.Count > 0)
                {
                    int iMarketComparativeId = (int)rgMarketComparative.SelectedValues["LpaComparativeNonUnitId"];
                    LpaComparativeNonunitService oLpaComparativeNonunitService = sessLpa.LpaComparativeNonunitServices
                        .Where(o => o.LpaComparativeNonUnitId == iMarketComparativeId).FirstOrDefault();

                    int iHfLpaCOntactComparativeId = 0;
                    LpaContactComparativeService oLpaContactComparativeService = null;

                    if (PFSCommon.IsNumeric(hfComparativeContactId.Value))
                    {
                        iHfLpaCOntactComparativeId = Convert.ToInt32(hfComparativeContactId.Value);
                    }

                    if (iHfLpaCOntactComparativeId != 0)
                    {
                        oLpaContactComparativeService = oLpaComparativeNonunitService.LpaContactComparativeServices
                            .Where(o => o.LpaContactComparativeContactId == iHfLpaCOntactComparativeId).FirstOrDefault();
                        oLpaContactComparativeService.UpdateDate = DateTime.Now;
                        oLpaContactComparativeService.UpdateByUserId = sessNISPWebLogin.UserName;
                    }
                    else
                    {
                        oLpaContactComparativeService = new LpaContactComparativeService();
                        oLpaContactComparativeService.CreateDate = oLpaComparativeNonunitService.UpdateDate = DateTime.Now;
                        oLpaContactComparativeService.CreateByUserId = oLpaComparativeNonunitService.UpdateByUserId = sessNISPWebLogin.UserName;
                        oLpaContactComparativeService.LpaContactComparativeContactId = vsMarketComparativeContactId = vsMarketComparativeContactId - 1;
                        oLpaComparativeNonunitService.LpaContactComparativeServices.Add(oLpaContactComparativeService);
                    }

                    oLpaContactComparativeService.LpaContactComparativeContactName = tbLpaContactComparativeContactName.Text.Trim();
                    oLpaContactComparativeService.LpaContactComparativeContactHandphone = tbLpaContactComparativeContactHandphone.Text.Trim();
                    oLpaContactComparativeService.LpaContactComparativeContactTelephone = tbLpaContactComparativeContactTelephone.Text.Trim();

                    hfComparativeContactId.Value = "0";
                    rgMarketCOmparativeContactPerson.Rebind();
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btForGridComparativeContactDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgMarketComparative.SelectedItems.Count == 0)
                {
                    Alert("Pilih Salah Satu Data Market Comparative");
                    return;
                }

                if (rgMarketComparative.SelectedItems.Count > 0)
                {
                    int iMarketComparativeId = (int)rgMarketComparative.SelectedValues["LpaComparativeNonUnitId"];
                    LpaComparativeNonunitService oLpaComparativeNonunitService = sessLpa.LpaComparativeNonunitServices
                        .Where(o => o.LpaComparativeNonUnitId == iMarketComparativeId).FirstOrDefault();

                    if (rgMarketCOmparativeContactPerson.SelectedValues != null && rgMarketCOmparativeContactPerson.SelectedValues.Count > 0)
                    {
                        int iCOntactCOmparativeId = (int)rgMarketCOmparativeContactPerson.SelectedValues["LpaContactComparativeContactId"];
                        LpaContactComparativeService oLpaContactComparativeService = oLpaComparativeNonunitService.LpaContactComparativeServices
                            .Where(o => o.LpaContactComparativeContactId == iCOntactCOmparativeId).FirstOrDefault();

                        if (oLpaContactComparativeService != null)
                        {
                            oLpaComparativeNonunitService.LpaContactComparativeServices.Remove(oLpaContactComparativeService);
                        }
                    }

                    hfComparativeContactId.Value = "0";
                    rgMarketCOmparativeContactPerson.Rebind();
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "", "closeSlider();", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btForGridComparativeContactCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                hfComparativeContactId.Value = "0";
                rgMarketCOmparativeContactPerson.Rebind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion */

        #region TextBox Events
        protected void rtbLiquidationFactor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateByDocumentTypeID();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }

        }

        #endregion

        #region DropDownList Events

        protected void ddlDocumentCalculationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                CalculateByDocumentTypeID();

                rgValueBuilding.Rebind();
                rgValueLand.Rebind();
                rgValueFacility.Rebind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }

        }

        protected void ddlDocumentCalculationTypeForLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitLand.SelectedItems.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForLand.SelectedValue);
                    int iNonUnitLandId = (int)rgNonUnitLand.SelectedValues["LpaNonUnitLandId"];
                    LpaNonUnitLandService oLpaNonUnitLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                        .Where(o => o.LpaNonUnitLandId == iNonUnitLandId).FirstOrDefault();

                    LpaNonUnitValueLandService oLpaNonUnitValueLandService = oLpaNonUnitLandService.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueLandService != null)
                    {
                        lblValueLandArea.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandArea);
                        lblValueLandPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandPrice);
                        lblLandAdjusment.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.LandAdjustment);
                        lblValueLandPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);
                        lblAdjusmentCalc.Text = PFSCommon.FormatNumber(((oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice));
                        lblTotalValueLandCalc.Text = PFSCommon.FormatNumber((oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice) - (oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);
                    }
                    else
                    {
                        lblValueLandArea.Text = "";
                        lblValueLandPrice.Text = "";
                        lblLandAdjusment.Text = "";
                        lblValueLandPriceCalc.Text = "";
                        lblAdjusmentCalc.Text = "";
                        lblTotalValueLandCalc.Text = "";
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void ddlDocumentCalculationTypeForBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitBuilding.SelectedItems.Count > 0)
                {
                    int iNonUnitBuildingId = (int)rgNonUnitBuilding.SelectedValues["LpaNonUnitBuildingId"];
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForBuilding.SelectedValue);

                    LpaNonUnitBuildingService oLpaNonUnitBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iNonUnitBuildingId).FirstOrDefault();

                    LpaNonUnitValueBuildingService oLpaNonUnitValueBuildingService = oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueBuildingService != null)
                    {
                        lblBuildingArea.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea);
                        lblBuildingPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingPrice);
                        lblBuildingProgress.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingProgress);
                        lblBuildingDepreciation.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingDepreciation);
                        lblRepairCost.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.RepairCost);
                        lblEconomicAsumption.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.EconomicAsumption);
                        lblTotalPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea * oLpaNonUnitValueBuildingService.BuildingPrice);
                        lblBuildingProgressCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingProgress / 100 * Convert.ToDouble(lblTotalPriceCalc.Text, new CultureInfo("id-ID")));
                        lblBuildingDepreciationCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingDepreciation / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        lblRepairCostCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.RepairCost / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        lblEconomicAsumptionCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) / 100 * oLpaNonUnitValueBuildingService.EconomicAsumption);
                        lblTotalSummaryCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingDepreciationCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblEconomicAsumptionCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblRepairCostCalc.Text, new CultureInfo("id-ID")));
                        lblBuildingValue.Text = PFSCommon.FormatNumber((Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) - Convert.ToDouble(lblTotalSummaryCalc.Text, new CultureInfo("id-ID"))));
                    }
                    else
                    {
                        lblBuildingArea.Text = "";
                        lblBuildingPrice.Text = "";
                        lblBuildingProgress.Text = "";
                        lblBuildingDepreciation.Text = "";
                        lblRepairCost.Text = "";
                        lblEconomicAsumption.Text = "";
                        lblTotalPriceCalc.Text = "";
                        lblBuildingProgressCalc.Text = "";
                        lblBuildingDepreciationCalc.Text = "";
                        lblRepairCostCalc.Text = "";
                        lblEconomicAsumptionCalc.Text = "";
                        lblTotalSummaryCalc.Text = "";
                        lblBuildingValue.Text = "";
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void ddlDocumentCalculationTypeForFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitFacility.SelectedItems.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForFacility.SelectedValue);
                    int iNonUnitFacilityId = (int)rgNonUnitFacility.SelectedValues["LpaNonUnitFacilityId"];

                    LpaNonUnitFacilityService oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iNonUnitFacilityId).FirstOrDefault();

                    LpaNonUnitValueFacilityService oLpaNonUnitValueFacilityService = oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueFacilityService != null)
                    {
                        lblFacilityMeasurement.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement);
                        lblFacilityUnitOfMeasure.Text = oLpaNonUnitValueFacilityService.FacilityUnitOfMeasure;
                        lblFacilityAmountHomeCurrency.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);
                        lblValueFacility.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement * oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);
                    }
                    else
                    {
                        lblFacilityMeasurement.Text = "";
                        lblFacilityUnitOfMeasure.Text = "";
                        lblFacilityAmountHomeCurrency.Text = "";
                        lblValueFacility.Text = "";
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void ddlDocumentCalculationForTotalMarketPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);
                LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService = null;
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();
                }

                if (oLpaNonUnitTotalMarketPriceService == null)
                {
                    oLpaNonUnitTotalMarketPriceService = new LpaNonUnitTotalMarketPriceService();
                    oLpaNonUnitTotalMarketPriceService.LpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId - 1;
                    oLpaNonUnitTotalMarketPriceService.DocumentCalculationId = iDocumentCalculationId;
                    oLpaNonUnitTotalMarketPriceService.LiquidationAmount = 0;
                    oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = 0;
                    if (sessLpa.LpaNonUnitServices != null)
                    {
                        sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices.Add(oLpaNonUnitTotalMarketPriceService);
                    }
                }
                if (sessLpa.LpaNonUnitServices != null)
                {
                    oLpaNonUnitTotalMarketPriceService.TotalMarketPrice = (
                   sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Sum(n => n.LpaNonUnitValueLandServices
                       .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                       .Sum(o => ((100 - o.LandAdjustment) / 100 * (o.ValueLandArea * o.ValueLandPrice)))) +
                   sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Sum(n => n.LpaNonUnitValueBuildingServices
                       .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                       .Sum(o => (((o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea) - ((o.EconomicAsumption / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.RepairCost / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.BuildingDepreciation / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea))))))) +
                   sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices.Sum(n => n.LpaNonUnitValueFacilityServices
                       .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                       .Sum(o => o.FacilityMeasurement * o.FacilityAmountHomeCurrency))
                    );
                }

                oLpaNonUnitTotalMarketPriceService.LiquidationAmount = (100 - oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage) / 100 * oLpaNonUnitTotalMarketPriceService.TotalMarketPrice;

                lblTotalMarketPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.TotalMarketPrice);
                lblLiquidationAmount.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationAmount);
                lblLiquidationValuePercentage.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void ddlComparativeNonUnitDataStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlComparativeNonUnitDataStatus.SelectedValue != null)
                {
                    if (ddlComparativeNonUnitDataStatus.SelectedValue != "0")
                        tbComparativeNonUnitDataStatusDescription.Text = ddlComparativeNonUnitDataStatus.SelectedItem.Text;

                    if (ddlComparativeNonUnitDataStatus.SelectedValue != null && ddlComparativeNonUnitDataStatus.SelectedValue != "0")
                    {
                        if (Convert.ToInt32(ddlComparativeNonUnitDataStatus.SelectedValue) == (int)ProTaksatur.WebUI.App_Code.Enumeration.DataStatus.Terjual
                            || Convert.ToInt32(ddlComparativeNonUnitDataStatus.SelectedValue) == (int)ProTaksatur.WebUI.App_Code.Enumeration.DataStatus.Tersewa
                            || Convert.ToInt32(ddlComparativeNonUnitDataStatus.SelectedValue) == (int)ProTaksatur.WebUI.App_Code.Enumeration.DataStatus.TidakDitawarkan)
                        {
                            rtbComparativeNonUnitDiscountRecommended.Text = "0";
                            return;
                        }

                        if (rdpComparativeNonUnitSellingDate.SelectedDate == null)
                        {
                            rtbComparativeNonUnitDiscountRecommended.Value = 0;
                            return;
                        }

                        double dDifferenceDate = (DateTime.Now - rdpComparativeNonUnitSellingDate.SelectedDate.Value).TotalDays / 30;
                        double dRecommendedValue = 0;
                        if (dDifferenceDate <= 0)
                        {
                            dRecommendedValue = 0;
                        }
                        else if (dDifferenceDate < 3)
                        {
                            dRecommendedValue = 5;
                        }
                        else if (dDifferenceDate < 10)
                        {
                            dRecommendedValue = 10;
                        }
                        else if (dDifferenceDate < 12)
                        {
                            dRecommendedValue = 15;
                        }
                        else if (dDifferenceDate < 18)
                        {
                            dRecommendedValue = 20;
                        }
                        else if (dDifferenceDate < 24)
                        {
                            dRecommendedValue = 25;
                        }
                        else
                        {
                            dRecommendedValue = 30;
                        }

                        rtbComparativeNonUnitDiscountRecommended.Value = dRecommendedValue;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void ddlComparativeNonUnitDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlComparativeNonUnitDataSource.SelectedValue != null)
                {
                    if (ddlComparativeNonUnitDataSource.SelectedValue != "0")
                        tbComparativeNonUnitDataSourceDescription.Text = ddlComparativeNonUnitDataSource.SelectedItem.Text;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Button Events
        protected void btnOldLpa_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                ram.ResponseScripts.Add(string.Format("openPopUpSearchLpa('{0}{1}')", "../PopUp/PopUpSearchLpa.aspx?qsCollateralCategoryId=", (int)ProTaksatur.WebUI.App_Code.Enumeration.DatabaseCollateralCategory.NonUnit));
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (sessLpa == null)
                        Response.Redirect("~/Error/SessionTimeOut.htm");

                    #region Validation
                    if (lblLPAType.Text.Trim().Length == 0)
                    {
                        Alert("Jenis Lpa harus diisi");
                        return;
                    }

                    if (sessLpa.DocumentInvestigateDate <= new DateTime(1900,1,1))
                    {
                        Alert("Tanggal Investigasi Harus diisi");
                        return;
                    }

                    if (sessLpa.DocumentReportDate <= new DateTime(1900,1,1))
                    {
                        Alert("Tanggal Report Date Harus diisi");
                        return;
                    }

                    if (lblCollateralType.Text.Trim().Length == 0)
                    {
                        Alert("Jenis Agunan Harus diisi");
                        return;
                    }

                    if (lblLandArea.Text.Trim().Length == 0)
                    {
                        Alert("Luas Tanah Harus diisi");
                        return;
                    }

                    if (lblWidthStreet.Text.Trim().Length == 0)
                    {
                        Alert("Lebar Jalan Harus diisi");
                        return;
                    }

                    if (lblNorthernBoundary.Text.Trim().Length == 0)
                    {
                        Alert("Batas Utara Harus diisi");
                        return;
                    }

                    if (lblSouthernBoundary.Text.Trim().Length == 0)
                    {
                        Alert("Batas Selatan Harus diisi");
                        return;
                    }

                    if (lblEasternBoundary.Text.Trim().Length == 0)
                    {
                        Alert("Batas Timur Harus diisi");
                        return;
                    }

                    if (lblWesternBoundary.Text.Trim().Length == 0)
                    {
                        Alert("Batas Barat Harus diisi");
                        return;
                    }

                    if (lblAreaPosition.Text.Trim().Length == 0)
                    {
                        Alert("Area Kawasan Harus diisi");
                        return;
                    }

                    if (lblCluster.Text.Trim().Length == 0)
                    {
                        Alert("Cluster Harus diisi");
                        return;
                    }

                    if (lblKomplek.Text.Trim().Length == 0)
                    {
                        Alert("Komplek Harus diisi");
                        return;
                    }

                    if (sessLpa.CollateralCategory == (int)Enumeration.DatabaseCollateralCategory.NonUnitProgressBangunan)
                    {
                        if (lblPhaseConstruction.Text.Trim().Length == 0)
                        {
                            Alert("Kondisi Agunan Harus diisi");
                            return;
                        }

                        if (lblProgressConstruction.Text.Trim().Length == 0)
                        {
                            Alert("Besaran Progress Harus diisi");
                            return;
                        }

                        if (lblCompletionBuilidngByDeveloper.Text.Trim().Length == 0)
                        {
                            Alert("Tahap Kontruksi (Berdasarkan Developer) Harus diisi");
                            return;
                        }

                        if (lblCompletionBuilidngByInspection.Text.Trim().Length == 0)
                        {
                            Alert("Tahap Kontruksi (Berdasarkan Inspeksi) Harus diisi");
                            return;
                        }

                        if (lblBuildingFloor.Text.Trim().Length == 0)
                        {
                            Alert("Jumlah Lantai Harus diisi");
                            return;
                        }

                        if (lblDeveloperName.Text.Trim().Length == 0)
                        {
                            Alert("Nama Developer Harus diisi");
                            return;
                        }

                        if (lblInTouchPersonName.Text.Trim().Length == 0)
                        {
                            Alert("Saat Inspeksi Bertemu harus diisi");
                            return;
                        }

                        if (lblInTouchPersonPosition.Text.Trim().Length == 0)
                        {
                            Alert("Bagian Harus diisi (Data Tanah)");
                            return;
                        }
                    }

                    if (sessLpa.LpaComparativeNonunitServices.Count == 0)
                    {
                        Alert("Market Comparative Harus diisi");
                        return;
                    }

                    if (sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Count == 0)
                    {
                        Alert("Data Sertifikat Harus diisi!");
                        return;
                    }

                    if (sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices.Count == 0)
                    {
                        Alert("Data Contact Person Harus Diisi");
                        return;
                    }

                    //SysParamService oSysParam = new SysParamService();
                    //SysParamServiceClient oSysParamClient = new SysParamServiceClient();

                    //oSysParamClient.SysParamGet(
                    //    sessNISPWebLogin.UserName,
                    //    Enumeration.SysParam.TANAH_KOSONG.ToString(),
                    //    out oSysParam);
                    //oSysParamClient.Close();
                    //oSysParamClient = null;

                    //if (!oSysParam.Value.ToLower().Equals(lblCollateralType.Text))
                    //{
                    //    if (sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.Count == 0)
                    //    {
                    //        Alert("Data Bangunan Harus Diisi");
                    //        return;
                    //    }
                    //}

                    if (sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Count == 0)
                    {
                        Alert("Perhitungan Nilai Tanah Harus Diisi");
                        return;
                    }
                    else
                    {
                        int iIndex = 1;
                        foreach (LpaNonUnitLandService oLpaNonUnitLandService in sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices)
                        {
                            if (oLpaNonUnitLandService.LpaNonUnitValueLandServices == null || oLpaNonUnitLandService.LpaNonUnitValueLandServices.Count == 0)
                            {
                                Alert(string.Format("Perhitungan Nilai Tanah Detail Perhitungan Deskripsi Tanah No {0} Harus Diisi", iIndex));
                                return;
                            }
                        }

                    }

                    //if (!oSysParam.Value.ToLower().Equals(lblCollateralType.Text))
                    //{
                    //    if (sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Count == 0)
                    //    {
                    //        Alert("Perhitungan Nilai Bangunan Harus Diisi");
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        int iIndex = 1;
                    //        foreach (LpaNonUnitBuildingService oLpaNonUnitBuildingService in sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices)
                    //        {
                    //            if (oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices == null || oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices.Count == 0)
                    //            {
                    //                Alert(string.Format("Perhitungan Nilai Bangunan Detail Perhitungan Deskripsi Bangunan No {0} Harus Diisi", iIndex));
                    //                return;
                    //            }
                    //        }
                    //    }
                    //}

                    double dWeightPercentage = 0;
                    foreach (LpaComparativeNonunitService oLpaComparativenonUnitService in sessLpa.LpaComparativeNonunitServices)
                    {
                        dWeightPercentage += oLpaComparativenonUnitService.ComparativeNonUnitDataPercentage;
                    }

                    if (dWeightPercentage != 100)
                    {
                        Alert("Bobot Data Market Comparative Tidak Sama Dengan 100%");
                        return;
                    }
                    #endregion

                    int iID = 0;

                    LpaService oLpaService = new LpaService();
                    oLpaService = sessLpa;

                    #region Validation Contact, Comparative, Sertifikat

                    if (!ValidateGridContactForRequiredField(oLpaService))
                        return;
                    if (!ValidateGridMarketCompartiveForRequiredField(oLpaService))
                        return;

                    if (!ValidateGridDataSertificateForRequeiredField(oLpaService))
                        return;

                    #endregion

                    #region Set Data Spesification Value building

                    foreach (GridItem oGridItem in rgLpaNonUnitFacilityBuilding.MasterTableView.Items)
                    {
                        TextBox tbFacilityDescription = oGridItem.FindControl("tbFacilityDescription") as TextBox;

                        LpaNonUnitFacilityBuildingService oLpaNonUnitFacilityBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices
                            .Where(o => o.LpaNonUnitFacilityBuildingId == Convert.ToInt32(oGridItem.OwnerTableView.DataKeyValues[oGridItem.ItemIndex]["LpaNonUnitFacilityBuildingId"])).FirstOrDefault();
                        oLpaNonUnitFacilityBuildingService.FacilityDescription = tbFacilityDescription.Text.Trim();
                    }
                    #endregion

                    #region Calculate Total Market Price

                    if (ddlDocumentCalculationForTotalMarketPrice.Items.Count > 0)
                    {
                        int iSelectedId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);
                        foreach (ListItem oListItem in ddlDocumentCalculationForTotalMarketPrice.Items)
                        {
                            ddlDocumentCalculationForTotalMarketPrice.SelectedValue = oListItem.Value;
                            CalculateTotalMarketPrice();
                        }

                        ddlDocumentCalculationForTotalMarketPrice.SelectedValue = iSelectedId.ToString();
                    }
                    #endregion

                    #region Set QuarterCode For Lpa Code
                    string sQuarterCode = sessNISPWebLogin.OfficeIdSibs;
                    sQuarterCode += "/" + sessNISPWebLogin.NIK;
                    if (Convert.ToInt32(ddlLpaType.SelectedValue) == (int)Enumeration.LpaOrderType.NewLpa)
                    {
                        sQuarterCode += "/New LPA";
                    }
                    else
                    {
                        sQuarterCode += "/" + ddlLpaType.SelectedItem.Text;
                    }
                    sQuarterCode += "/";
                    sQuarterCode += sessOrderCollateralDetail.SurveyorTeamOriginId == (int)ProTaksatur.WebUI.App_Code.Enumeration.SurveyorTeamOriginId.Internal ? "IN" : "EX";
                    sQuarterCode += "/";

                    #region Get Credit Type

                    OrderCollateralService oOrderCollateralService = new OrderCollateralService();
                    OrderCollateralServiceClient oOrderCollateralServiceClient = new OrderCollateralServiceClient();
                    oOrderCollateralServiceClient.GetCollateral(
                        sessNISPWebLogin.UserName,
                        sessOrderCollateralDetail.OrderCollateralId,
                        false,
                        out oOrderCollateralService);

                    List<OrderCollateralService> oOrderCollateralList = new List<OrderCollateralService>();
                    oOrderCollateralServiceClient.OrderCollateralListWithFilter(
                        sessNISPWebLogin.UserName,
                        oOrderCollateralService.CollateralCode,
                        null,
                        null,
                        null,
                        null,
                        null,
                        out oOrderCollateralList);

                    oOrderCollateralServiceClient.Close();
                    oOrderCollateralServiceClient = null;

                    // Add Credit type to Quarter Code
                    sQuarterCode += oOrderCollateralList[0].SetupCreditTypeDescription;
                    oOrderCollateralList = null;

                    #endregion
                    #endregion

                    oLpaService.QuarterCode = sQuarterCode;
                    oLpaService.CreateByUserId = oLpaService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oLpaService.CreateDate = oLpaService.UpdateDate = DateTime.Now;
                    oLpaService.OrderCollateralDetailId = qsOrderCollateralDetailId;

                    if (qsCollateralCategoryId != 0)
                        sessLpa.CollateralCategory = qsCollateralCategoryId;

                    oLpaService.ApprovalStatusId = (int)ProTaksatur.WebUI.App_Code.Enumeration.ApprovalStatus.Created;
                    oLpaService.ApprovalStatusDescription = ProTaksatur.WebUI.App_Code.Enumeration.ApprovalStatus.Created.ToString();
                    oLpaService.CollateralLiquidationPercentage = 0;

                    ApprovalService oApproval = new ApprovalService();
                    ApprovalServiceClient oApprovalServiceClient = new ApprovalServiceClient();

                    oApprovalServiceClient.ApprovalGetByFilters(
                        sessNISPWebLogin.GroupId,
                        false,
                        sessNISPWebLogin.UserName,
                        out oApproval);
                    oApprovalServiceClient.Close();

                    oLpaService.ApprovalApproverCode = sessNISPWebLogin.ManagerId;
                    oLpaService.ApprovalApproverDate = DateTime.Now;
                    oLpaService.ApprovalApproverName = sessNISPWebLogin.ManagerName;
                    oLpaService.CreateEmail = sessNISPWebLogin.EmployeeEmail;

                    #region Set Value History Approval Lpa
                    ServicesClient oServicesClient = new ServicesClient();
                    HistoryApprovalLpaServiceClient oHistoryApprovalLpaServiceClient = new HistoryApprovalLpaServiceClient();
                    HistoryApprovalLpaService oHistoryApprovalLpaService = new HistoryApprovalLpaService();
                    HistoryApprovalLpaService oHistoryApprovalLpaPreviousService = new HistoryApprovalLpaService();
                    int iBusinessDays = 0;
                    DateTime dtDocumentReceiveDate = DateTime.Now;

                    if (sessLpa.LpaId > 0)
                    {
                        oHistoryApprovalLpaServiceClient.HistoryApprovalLpaGetPreviousRelated(sessNISPWebLogin.UserName, sessLpa.LpaId,
                            out oHistoryApprovalLpaPreviousService);
                        oHistoryApprovalLpaServiceClient.Close();

                        if (oHistoryApprovalLpaPreviousService.HistoryApprovalLpaId > 0)
                        {
                            dtDocumentReceiveDate = oHistoryApprovalLpaPreviousService.CreateDate;
                            iBusinessDays = oServicesClient.GetTotalWorkingDays(sessNISPWebLogin.UserName, oHistoryApprovalLpaPreviousService.CreateDate, DateTime.Now);
                        }
                    }

                    oHistoryApprovalLpaService.ApprovalLpaEmployeeId = sessNISPWebLogin.NIK;
                    oHistoryApprovalLpaService.ApprovalLpaEmployeeName = sessNISPWebLogin.FullName;
                    oHistoryApprovalLpaService.ApprovalLpaGroupCode = oApproval.ApprovalGroupCode;
                    oHistoryApprovalLpaService.ApprovalLpaGroupName = oApproval.ApprovalGroupName;
                    oHistoryApprovalLpaService.BussinessDay = iBusinessDays;
                    oHistoryApprovalLpaService.CreateByUserId = oHistoryApprovalLpaService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oHistoryApprovalLpaService.CreateDate = oHistoryApprovalLpaService.UpdateDate = DateTime.Now;
                    oHistoryApprovalLpaService.DocumentLpaReceiveDate = dtDocumentReceiveDate;
                    oHistoryApprovalLpaService.DocumentLpaApprovalDate = oHistoryApprovalLpaService.DocumentLpaReceiveDate = DateTime.Now;
                    oHistoryApprovalLpaService.OrderCollateralDetailId = qsOrderCollateralDetailId;
                    oHistoryApprovalLpaService.StatusDescription = ProTaksatur.WebUI.App_Code.Enumeration.ApprovalStatus.Created.ToString();
                    oHistoryApprovalLpaService.StatusId = (int)ProTaksatur.WebUI.App_Code.Enumeration.ApprovalStatus.Created;
                    oHistoryApprovalLpaService.LpaApprovalId = oApproval.ApprovalId;

                    #endregion

                    LpaServiceClient oLpaServiceClient = new LpaServiceClient();

                    bool bIsSuccess = false;

                    if (sessLpa.LpaId > 0)
                    {
                        if (oLpaServiceClient.UpdateWithNonUnitChild(sessNISPWebLogin.UserName, oLpaService, oHistoryApprovalLpaService, false) == 1)
                            bIsSuccess = true;
                        else
                            bIsSuccess = false;
                    }
                    else
                    {
                        if ((oLpaServiceClient.AddWithNonUnitChild(sessNISPWebLogin.UserName, oLpaService, oHistoryApprovalLpaService, false, out iID)) == 1)
                        {
                            sessLpa.LpaId = iID;
                            bIsSuccess = true;
                        }
                        else
                        {
                            bIsSuccess = false;
                        }
                    }
                    if (bIsSuccess)
                    {
                        LpaService oLpaServiceResultAdd = new LpaService();
                        LpaServiceClient oLpaServiceResultAddClient = new LpaServiceClient();

                        oLpaServiceResultAddClient.LpaGet(
                            sessNISPWebLogin.UserName,
                            sessLpa.LpaId,
                            out oLpaServiceResultAdd);

                        CultureInfo ciCustom = new CultureInfo("id-ID");

                        ServicesClient oService = new ServicesClient();
                        oService.SendEmail(
                        sessNISPWebLogin.ManagerEmail,
                        "",
                        "Notifikasi Order",
                        string.Format("Telah Dilakukan {0} Order LPA No {1} pada Hari {2} Tanggal {3} Mohon Diperiksa Kembali", "Input", oLpaServiceResultAdd.LpaCode, DateTime.Today.ToString("dddd", ciCustom), PFSCommon.FormatDate(DateTime.Now)),
                        null,
                        false);

                        Alert(string.Format("{0} Dengan Nomor {1}", PFSMessage.General.SUCCESS_ADD, oLpaServiceResultAdd.LpaCode));

                        oLpaServiceClient.Close();
                        oLpaServiceClient = null;
                        oHistoryApprovalLpaService = null;
                        oApproval = null;
                        sessLpa = null;
                        sessLpaIdResultSearch = 0;
                        sessOrderCollateralDetail = null;
                        oLpaServiceResultAdd = null;
                        oLpaServiceResultAddClient.Close();
                        oLpaServiceResultAddClient = null;
                        ram.ResponseScripts.Add("window.location='../DisplayAppraisal/DisplayAppraisalList.aspx'");
                        // Response.Redirect(string.Format("~/DisplayAppraisal/DisplayAppraisalList.aspx"));
                    }
                    else
                    {
                        Alert(PFSMessage.General.NOT_SUCCESS_ADD);
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnSaveAsDraft_Click(object sender, EventArgs e)
        {
            ProcessDraftAndPending(true);
        }

        protected void btnPending_Click(object sender, EventArgs e)
        {
            ProcessDraftAndPending(false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (sessLpa == null)
            {
                Response.Redirect("~/Error/SessionTimeOut.htm");
            }

            Response.Redirect(qsBackUrl);
        }

        protected void btAddNewLpaNonUnitContactPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewLpaNonUnitContactPerson.Visible = false;
                rgLpaNonUnitContactPerson.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewLandDescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewLandDescription.Visible = false;
                rgLandDescription.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewLandPositiveFactor_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewLandPositiveFactor.Visible = false;
                rgLandPositiveFactor.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewLandNegativeFactor_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewLandNegativeFactor.Visible = false;
                rgLandNegativeFactor.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewLpaNonUnitFacilityBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                vsIndexNumberGridFacilityBuilding = 0;

                LpaService oLpaService = new LpaService();
                oLpaService = sessLpa;

                List<SetupSpesificationBuildingService> oSetupSpesificationBuildingServiceList = new List<SetupSpesificationBuildingService>();
                SetupSpesificationBuildingServiceClient oSetupSpesificationBuildingServiceClient = new SetupSpesificationBuildingServiceClient();

                oSetupSpesificationBuildingServiceClient.SetupSpesificationBuildingList(
                    sessNISPWebLogin.UserName,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    out oSetupSpesificationBuildingServiceList);

                foreach (SetupSpesificationBuildingService oSetupSpesificationBuildingService in oSetupSpesificationBuildingServiceList)
                {
                    LpaNonUnitFacilityBuildingService oLpaUnitFacilityBuildingService = new LpaNonUnitFacilityBuildingService();
                    oLpaUnitFacilityBuildingService.FacilityAliasName = oSetupSpesificationBuildingService.SpesificationBuildingName;
                    oLpaUnitFacilityBuildingService.FacilityDescription = "";
                    oLpaUnitFacilityBuildingService.LpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId - 1;

                    oLpaService.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices.Add(oLpaUnitFacilityBuildingService);

                    sessLpa = oLpaService;

                    oLpaUnitFacilityBuildingService = null;
                }

                rgLpaNonUnitFacilityBuilding.Rebind();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewBuildingDescription_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewBuildingDescription.Visible = false;
                rgBuildingDescription.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewBuildingPositiveFactor_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewBuildingPositiveFactor.Visible = false;
                rgBuildingPositiveFactor.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewBuildingNegativeFactor_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewBuildingNegativeFactor.Visible = false;
                rgBuildingNegativeFactor.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewValueLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewValueBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewValueBuilding.Visible = false;
                rgValueBuilding.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewValueFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewValueFacility.Visible = false;
                rgValueFacility.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewLpaNonUnitTaxLand_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewLpaNonUnitTaxLand.Visible = false;
                rgTaxLand.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewSpecialInformation_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewSpecialInformation.Visible = false;
                rgSpecialInformation.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewMarketComparative_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewMarketComparative.Visible = false;
                rgMarketComparative.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btAddNewOpinion_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                btAddNewOpinion.Visible = false;
                rgOpinion.MasterTableView.InsertItem();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnReloadSearchMaster_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (sessLpa == null)
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm");
                    }

                    // set PopUpSearch
                    #region SetPopUpSearch

                    string sNavigatePopUp = "../PopUp/PopUpSearchMaster.aspx?";

                    btnVillageSearch.OnClientClick = string.Format("return openRadWindowGeneral('{0}Master={1}&ClientId={2}&PostalID={3}')",
                        sNavigatePopUp, ProTaksatur.WebUI.App_Code.Enumeration.PopUpSearch.Village.ToString(), tbCertificateVillage.ClientID, sessPostalId);

                    btnCertificateZipCode.OnClientClick = string.Format("return openRadWindowGeneral('{0}Master={1}&ClientId={2}&VillageID={3}&DisableSelectMode=1')",
                       sNavigatePopUp, ProTaksatur.WebUI.App_Code.Enumeration.PopUpSearch.Postal.ToString(), tbCertificateZipCode.ClientID, sessVillageId);

                    #endregion

                    if (sessPostalId > 0)
                    {
                        PostalService oPostalService = new PostalService();
                        PostalServiceClient oPostalServiceclient = new PostalServiceClient();

                        if (oPostalServiceclient.GetMasterRelatedByPostal(
                            sessNISPWebLogin.UserName,
                            sessPostalId,
                            out oPostalService) == 1)
                        {
                            tbCertificateVillage.Text = oPostalService.VillageName;
                            tbCertificateSubDistrict.Text = oPostalService.SubDistrictName;
                            tbCertificateCity.Text = oPostalService.CityName;
                            tbCertificateZipCode.Text = oPostalService.PostalZipCode;
                            tbCertificateProvince.Text = oPostalService.ProvinceName;
                        }
                        sessPostalId = 0;
                    }
                    else if (sessVillageId > 0)
                    {

                        VillageService oVillageService = new VillageService();
                        VillageServiceClient oVillageServiceclient = new VillageServiceClient();

                        if (oVillageServiceclient.VillageGet(
                            sessNISPWebLogin.UserName,
                            sessVillageId,
                            out oVillageService) == 1)
                        {
                            tbCertificateVillage.Text = oVillageService.VillageName;

                            sessVillageId = 0;
                        }
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void btnRefreshMarketComparative_Click(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                try
                {
                    DatabaseNonUnitService oDatabaseNonUnitService = new DatabaseNonUnitService();
                    DatabaseNonUnitServiceClient oDatabaseNonUnitServiceClient = new DatabaseNonUnitServiceClient();

                    if (oDatabaseNonUnitServiceClient.DatabaseNonUnitGet(
                        sessNISPWebLogin.UserName, sessSearchMarketComparativeIdResultSearch, out oDatabaseNonUnitService) == 1)
                    {
                        if (oDatabaseNonUnitService.DatabaseNonUnitSellingDate.Date > new DateTime(1900, 1, 1))
                            rdpComparativeNonUnitSellingDate.SelectedDate = oDatabaseNonUnitService.DatabaseNonUnitSellingDate;

                        ddlComparativeNonUnitDataStatus.SelectedValue = oDatabaseNonUnitService.DatabaseNonUnitDataStatusId.ToString();
                        tbComparativeNonUnitDataStatusDescription.Text = oDatabaseNonUnitService.DatabaseNonUnitDataStatusDescription;
                        ddlComparativeNonUnitDataSource.SelectedValue = oDatabaseNonUnitService.DatabaseNonUnitDataSourceId.ToString();
                        tbComparativeNonUnitDataSourceDescription.Text = oDatabaseNonUnitService.DatabaseNonUnitDataSourceDescription;
                        tbComparativeNonUnitAddress1.Text = oDatabaseNonUnitService.DatabaseNonUnitAddress1;
                        tbComparativeNonUnitAddress2.Text = oDatabaseNonUnitService.DatabaseNonUnitAddress2;
                        tbComparativeNonUnitAddress3.Text = oDatabaseNonUnitService.DatabaseNonUnitAddress3;

                        if (oDatabaseNonUnitService.DatabaseNonUnitResidential)
                        {
                            rdbComparativeResidentialTrue.Checked = true;
                            rdbComparativeResidentialFalse.Checked = false;
                        }
                        else
                        {
                            rdbComparativeResidentialFalse.Checked = true;
                            rdbComparativeResidentialTrue.Checked = false;
                        }

                        tbComparativeNonUnitCLuster.Text = oDatabaseNonUnitService.DatabaseNonUnitCluster;
                        tbComparativeDataCondition.Text = oDatabaseNonUnitService.DatabaseNonUnitSellingCondition;
                        rtbComparativeNonUnitRadius.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitRadius);
                        rtbComparativeNonUnitWidthStreet.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitWidthStreet);
                        tbComparativeNonUnitLegality.Text = oDatabaseNonUnitService.DatabaseNonUnitLegality;
                        tbComparativeNonUnitPosition.Text = oDatabaseNonUnitService.DatabaseNonUnitPosition;
                        tbComparativeNonUnitDirection.Text = oDatabaseNonUnitService.DatabaseNonUnitDirection;
                        rtbComparativeNonUnitLandArea.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitLandArea);
                        rtbComparativeNonUnitBuildingArea.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitBuildingArea);

                        if (PFSCommon.IsNumeric(oDatabaseNonUnitService.DatabaseNonUnitBuildingYear))
                            rtbComparativeNonUnitCreatedYear.Text = oDatabaseNonUnitService.DatabaseNonUnitBuildingYear;

                        if (PFSCommon.IsNumeric(oDatabaseNonUnitService.DatabaseNonUnitRenovationYear))
                            rtbComparativeNonUnitRenovationYear.Text = oDatabaseNonUnitService.DatabaseNonUnitRenovationYear;

                        tbComparativeNonUnitAreaPosition.Text = oDatabaseNonUnitService.DatabaseNonUnitAreaPosition;
                        rtbComparativeNonUnitNewBuildingPrice.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitNewBuildingPrice);
                        rtbComparativeNonUnitAmount.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitSellingPrice);
                        rtbComparativeNonUnitSellingPriceDiscount.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitSellingPriceDiscount);
                        rtbComparativeNonUnitDiscountRecommended.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitDiscountRecommended);
                        rtbComparativeNonUnitFurnishPrice.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitFurnishPrice);
                        rntPredictioValue.Text = PFSCommon.FormatNumber((oDatabaseNonUnitService.DatabaseNonUnitSellingPrice - oDatabaseNonUnitService.DatabaseNonUnitFurnishPrice) * ((100 - oDatabaseNonUnitService.DatabaseNonUnitSellingPriceDiscount) / 100));
                        rtbComparativeNonUnitDepreciation.Text = PFSCommon.FormatNumber(oDatabaseNonUnitService.DatabaseNonUnitDepreciation);
                        tbEstimateBuildingValue.Text =
                             PFSCommon.FormatNumber(
                            (oDatabaseNonUnitService.DatabaseNonUnitBuildingArea *
                             oDatabaseNonUnitService.DatabaseNonUnitNewBuildingPrice
                             * (1 - (oDatabaseNonUnitService.DatabaseNonUnitDepreciation / 100))));

                        tbEstimateLandValue.Text =
                            PFSCommon.FormatNumber(
                         (((Convert.ToDouble(
                             rntPredictioValue.Text == "" ? "0" : rntPredictioValue.Text,
                             new CultureInfo("id-ID"))) -
                          ((Convert.ToDouble(rtbComparativeNonUnitBuildingArea.Text, new CultureInfo("id-ID"))) *
                          (Convert.ToDouble(rtbComparativeNonUnitNewBuildingPrice.Text, new CultureInfo("id-ID"))) *
                          (1 - ((Convert.ToDouble(rtbComparativeNonUnitDepreciation.Text == "" ? "0" : rtbComparativeNonUnitDepreciation.Text, new CultureInfo("id-ID"))) / 100)))) /
                          Convert.ToDouble(rtbComparativeNonUnitLandArea.Text, new CultureInfo("id-ID")))).ToString();

                        if (PFSCommon.IsNumeric(rtbComparativeNonUnitDataPercentage.Text))
                        {
                            rntIndicationUnitValue.Text = PFSCommon.FormatNumber((Convert.ToDouble(tbEstimateLandValue.Text == "" ? "0" : Convert.ToDouble(tbEstimateLandValue.Text, new CultureInfo("id-ID")).ToString()) * Convert.ToDouble(rtbComparativeNonUnitDataPercentage.Text == "" ? "0" : rtbComparativeNonUnitDataPercentage.Text, new CultureInfo("id-ID"))));
                        }

                        tbComparativeNonUnitDescription.Text = oDatabaseNonUnitService.DatabaseNonUnitDescription;
                        tbComparativeSalesName.Text = oDatabaseNonUnitService.DatabaseNonUnitMarketingName;
                        tbComparativeSalesPhoneNo.Text = oDatabaseNonUnitService.DatabaseNonUnitMarketingPhone;

                        if (oDatabaseNonUnitService.OfferingDate > new DateTime(1900, 1, 1))
                        {
                            rdpOfferingDate.SelectedDate = oDatabaseNonUnitService.OfferingDate;
                        }

                        if (oDatabaseNonUnitService.ConfirmationDate > new DateTime(1900, 1, 1))
                            rdpConfirmationDate.SelectedDate = oDatabaseNonUnitService.ConfirmationDate;
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion
        #endregion

        #region Grid Events
        #region Grid NonUnitCertificate

        protected void rgLpaNonUnitCertificate_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaNonUnitCertificateService> oLpaNonUnitCertificateServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices;
                rgLpaNonUnitCertificate.DataSource = oLpaNonUnitCertificateServices;

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        /* protected void rgLpaNonUnitCertificate_ItemCommand(object sender, GridCommandEventArgs e)
         {
             try
             {
                 if (e.CommandName == "PerformInsert")
                 {
                     LpaNonUnitCertificateService oLpaNonUnitCertificateService = new LpaNonUnitCertificateService();
                     oLpaNonUnitCertificateService.LpaNonUnitCertificateId = vsLpaUnitCertificateId = vsLpaUnitCertificateId - 1;
                     oLpaNonUnitCertificateService.CertificateName = ((TextBox)e.Item.FindControl("tbCertificateName")).Text.Trim();
                     oLpaNonUnitCertificateService.CertificateNo = ((TextBox)e.Item.FindControl("tbCertificateNo")).Text.Trim();
                     oLpaNonUnitCertificateService.CertificateDate = ((RadDatePicker)e.Item.FindControl("rdpCertificateDate")).SelectedDate.Value;
                     oLpaNonUnitCertificateService.CertificateExpiredDate = ((RadDatePicker)e.Item.FindControl("rdpCertificateExpiredDate")).SelectedDate == null ? new DateTime(1900, 1, 1) : ((RadDatePicker)e.Item.FindControl("rdpCertificateExpiredDate")).SelectedDate.Value;
                     oLpaNonUnitCertificateService.DocumentLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbDocumentLandArea")).Value.Value;
                     oLpaNonUnitCertificateService.DocumentOwner = ((TextBox)e.Item.FindControl("tbDocumentOwner")).Text.Trim();

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Add(oLpaNonUnitCertificateService);

                     rgLpaNonUnitCertificate.Rebind();
                     btAddNewLpaNonUnitCertificate.Visible = true;
                 }
                 else if (e.CommandName == "Update")
                 {
                     int iLpaNonUnitCertificateIndex = 0;

                     for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Count; i++)
                     {
                         if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitCertificateId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[i].LpaNonUnitCertificateId)
                         {
                             iLpaNonUnitCertificateIndex = i;
                             break;
                         }
                     }

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[iLpaNonUnitCertificateIndex].CertificateName = ((TextBox)e.Item.FindControl("tbCertificateName")).Text.Trim();
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[iLpaNonUnitCertificateIndex].CertificateNo = ((TextBox)e.Item.FindControl("tbCertificateNo")).Text.Trim();
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[iLpaNonUnitCertificateIndex].CertificateDate = ((RadDatePicker)e.Item.FindControl("rdpCertificateDate")).SelectedDate.Value;
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[iLpaNonUnitCertificateIndex].CertificateExpiredDate = ((RadDatePicker)e.Item.FindControl("rdpCertificateExpiredDate")).SelectedDate.Value;
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[iLpaNonUnitCertificateIndex].DocumentLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbDocumentLandArea")).Value.Value;
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[iLpaNonUnitCertificateIndex].DocumentOwner = ((TextBox)e.Item.FindControl("tbDocumentOwner")).Text.Trim();

                     rgLpaNonUnitCertificate.Rebind();
                     btAddNewLpaNonUnitCertificate.Visible = true;
                 }
                 else if (e.CommandName == "Delete")
                 {
                     int iLpaNonUnitCertificateIndex = 0;

                     for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.Count; i++)
                     {
                         if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitCertificateId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices[i].LpaNonUnitCertificateId)
                         {
                             iLpaNonUnitCertificateIndex = i;
                             break;
                         }
                     }

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitCertificateServices.RemoveAt(iLpaNonUnitCertificateIndex);
                     rgLpaNonUnitCertificate.Rebind();
                 }
                 else if (e.CommandName == "Edit")
                 {
                     btAddNewLpaNonUnitCertificate.Visible = false;
                 }
                 else if (e.CommandName == "Cancel")
                 {
                     rgLpaNonUnitCertificate.Rebind();
                     btAddNewLpaNonUnitCertificate.Visible = true;
                 }
             }
             catch (System.Threading.ThreadAbortException) { }
             catch (Exception Ex)
             {
                 e.Canceled = true;

                 string sRefNumber = PFSCommon.GenerateRefNumber();

                 ServicesClient oServicesClient = new ServicesClient();
                 oServicesClient.LogError(
                     sessNISPWebLogin.UserName,
                     sRefNumber,
                     GetType().FullName,
                     MethodInfo.GetCurrentMethod().Name,
                     Ex.ToString());
                 oServicesClient.Close();
                 oServicesClient = null;

                 Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
             }
         }

         protected void rgLpaNonUnitCertificate_ItemDataBound(object sender, GridItemEventArgs e)
         {
             try
             {
                 RadDatePicker rdpCertificateDate = (RadDatePicker)e.Item.FindControl("rdpCertificateDate");
                 RadDatePicker rdpCertificateExpiredDate = (RadDatePicker)e.Item.FindControl("rdpCertificateExpiredDate");
                 RadNumericTextBox rtbDocumentLandArea = (RadNumericTextBox)e.Item.FindControl("rtbDocumentLandArea");

                 if (e.Item is GridDataItem)
                 {
                     Label lblCertificateDate = (Label)e.Item.FindControl("lblCertificateDate");

                     if (Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "CertificateDate")) == new DateTime(1900, 1, 1))
                     {
                         lblCertificateDate.Text = "";
                     }
                     else
                     {
                         lblCertificateDate.Text = DataBinder.Eval(e.Item.DataItem, "CertificateDate").ToString();
                     }
                 }

                 if (!e.Item.OwnerTableView.IsItemInserted && rdpCertificateDate != null && rdpCertificateExpiredDate != null && rtbDocumentLandArea != null)
                 {
                     rdpCertificateDate.SelectedDate = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "CertificateDate"));
                     rdpCertificateExpiredDate.SelectedDate = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "CertificateExpiredDate"));
                     rtbDocumentLandArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "DocumentLandArea"));
                 }
             }
             catch (System.Threading.ThreadAbortException) { }
             catch (Exception Ex)
             {
                 string sRefNumber = PFSCommon.GenerateRefNumber();

                 ServicesClient oServicesClient = new ServicesClient();
                 oServicesClient.LogError(
                     sessNISPWebLogin.UserName,
                     sRefNumber,
                     GetType().FullName,
                     MethodInfo.GetCurrentMethod().Name,
                     Ex.ToString());
                 oServicesClient.Close();
                 oServicesClient = null;

                 Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
             }
         } */
        #endregion

        #region Grid NonUnitContactPerson
        protected void rgLpaNonUnitContactPerson_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaContactService> oLpaContactServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices;
                rgLpaNonUnitContactPerson.DataSource = oLpaContactServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLpaNonUnitContactPerson_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaContactService oLpaContactService = new LpaContactService();
                    oLpaContactService.LpaContactId = vsLpaNonUnitContactId = vsLpaNonUnitContactId - 1;
                    oLpaContactService.LpaContactName = ((TextBox)e.Item.FindControl("tbLpaContactName")).Text.Trim();
                    oLpaContactService.LpaContactPhoneNo = ((TextBox)e.Item.FindControl("tbLpaContactPhoneNo")).Text.Trim();
                    oLpaContactService.LpaContactMobileNo = ((TextBox)e.Item.FindControl("tbLpaContactMobileNo")).Text.Trim();
                    oLpaContactService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices.Add(oLpaContactService);

                    rgLpaNonUnitContactPerson.Rebind();
                    btAddNewLpaNonUnitContactPerson.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iLpaContactIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaContactId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices[i].LpaContactId)
                        {
                            iLpaContactIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices[iLpaContactIndex].LpaContactName = ((TextBox)e.Item.FindControl("tbLpaContactName")).Text.Trim();
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices[iLpaContactIndex].LpaContactPhoneNo = ((TextBox)e.Item.FindControl("tbLpaContactPhoneNo")).Text.Trim();
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices[iLpaContactIndex].LpaContactMobileNo = ((TextBox)e.Item.FindControl("tbLpaContactMobileNo")).Text.Trim();

                    rgLpaNonUnitContactPerson.Rebind();
                    btAddNewLpaNonUnitContactPerson.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iLpaContactIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaContactId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices[i].LpaContactId)
                        {
                            iLpaContactIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitContactServices.RemoveAt(iLpaContactIndex);
                    rgLpaNonUnitContactPerson.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewLpaNonUnitContactPerson.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgLpaNonUnitContactPerson.Rebind();
                    btAddNewLpaNonUnitContactPerson.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLpaNonUnitContactPerson_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid KeteranganTanah
        protected void rgLandDescription_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices;
                rgLandDescription.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLandDescription_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitLandDescriptionId = vsLpaNonUnitLandDescriptionId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.LandDescription;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices.Add(oLpaDescriptionService);

                    rgLandDescription.Rebind();
                    btAddNewLandDescription.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices[iLpaDescriptiontIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgLandDescription.Rebind();
                    btAddNewLandDescription.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandDescriptionServices.RemoveAt(iLpaDescriptiontIndex);
                    rgLandDescription.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewLandDescription.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgLandDescription.Rebind();
                    btAddNewLandDescription.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLandDescription_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid PositifTanah
        protected void rgLandPositiveFactor_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices;
                rgLandPositiveFactor.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLandPositiveFactor_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitLandPostiveId = vsLpaNonUnitLandPostiveId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.PositiveFactorLand;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices.Add(oLpaDescriptionService);

                    rgLandPositiveFactor.Rebind();
                    btAddNewLandPositiveFactor.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iLpaPositiveIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices[i].LpaDescriptionId)
                        {
                            iLpaPositiveIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices[iLpaPositiveIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgLandPositiveFactor.Rebind();
                    btAddNewLandPositiveFactor.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iLpaPositiveIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices[i].LpaDescriptionId)
                        {
                            iLpaPositiveIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandPositiveFactorServices.RemoveAt(iLpaPositiveIndex);
                    rgLandDescription.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewLandPositiveFactor.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgLandPositiveFactor.Rebind();
                    btAddNewLandPositiveFactor.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLandPositiveFactor_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid NegatifTanah
        protected void rgLandNegativeFactor_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices;
                rgLandNegativeFactor.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLandNegativeFactor_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitLandNegativeId = vsLpaNonUnitLandNegativeId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.NegativeFactorLand;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices.Add(oLpaDescriptionService);

                    rgLandNegativeFactor.Rebind();
                    btAddNewLandNegativeFactor.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iLpaNegativeIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices[i].LpaDescriptionId)
                        {
                            iLpaNegativeIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices[iLpaNegativeIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgLandNegativeFactor.Rebind();
                    btAddNewLandNegativeFactor.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iLpaNegativeIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices[i].LpaDescriptionId)
                        {
                            iLpaNegativeIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandNegativeFactorServices.RemoveAt(iLpaNegativeIndex);
                    rgLandDescription.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewLandNegativeFactor.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgLandNegativeFactor.Rebind();
                    btAddNewLandNegativeFactor.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLandNegativeFactor_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid DataBuilding
        protected void rgDataBuilding_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaNonUnitDataBuildingService> oLpaNonUnitDataBuildingServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices;
                rgDataBuilding.DataSource = oLpaNonUnitDataBuildingServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        /* protected void rgDataBuilding_ItemCommand(object sender, GridCommandEventArgs e)
         {
             try
             {
                 if (e.CommandName == "PerformInsert")
                 {
                     LpaNonUnitDataBuildingService oLpaNonUnitDataBuildingService = new LpaNonUnitDataBuildingService();
                     oLpaNonUnitDataBuildingService.LpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId = vsLpaNonUnitDataBuildingId - 1;
                     oLpaNonUnitDataBuildingService.BuildingPermitsType = ((TextBox)e.Item.FindControl("tbBuildingPermitsType")).Text.Trim();
                     oLpaNonUnitDataBuildingService.BuildingPermitsNo = ((TextBox)e.Item.FindControl("tbBuildingPermitsNo")).Text.Trim();
                     oLpaNonUnitDataBuildingService.BuildingPermitsCreateDate = ((RadDatePicker)e.Item.FindControl("rdpBuildingPermitsCreateDate")).SelectedDate.Value;
                     oLpaNonUnitDataBuildingService.BuildingPermitsArea = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingPermitsArea")).Value.Value;
                     oLpaNonUnitDataBuildingService.PhysicalArea = ((RadNumericTextBox)e.Item.FindControl("rtbPhysicalArea")).Value.Value;
                     oLpaNonUnitDataBuildingService.BuildingCreatedYear = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingCreatedYear")).Value.ToString();
                     oLpaNonUnitDataBuildingService.RenovationYear = ((RadNumericTextBox)e.Item.FindControl("rtbRenovationYear")).Value.ToString();

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.Add(oLpaNonUnitDataBuildingService);

                     rgDataBuilding.Rebind();
                     btAddNewDataBuilding.Visible = true;
                 }
                 else if (e.CommandName == "Update")
                 {
                     int iDataBuildingIndex = 0;

                     for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.Count; i++)
                     {
                         if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitDataBuildingId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[i].LpaNonUnitDataBuildingId)
                         {
                             iDataBuildingIndex = i;
                             break;
                         }
                     }

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[iDataBuildingIndex].BuildingPermitsType = ((TextBox)e.Item.FindControl("tbBuildingPermitsType")).Text.Trim();
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[iDataBuildingIndex].BuildingPermitsNo = ((TextBox)e.Item.FindControl("tbBuildingPermitsNo")).Text.Trim();
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[iDataBuildingIndex].BuildingPermitsCreateDate = ((RadDatePicker)e.Item.FindControl("rdpBuildingPermitsCreateDate")).SelectedDate.Value;
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[iDataBuildingIndex].BuildingPermitsArea = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingPermitsArea")).Value.Value;
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[iDataBuildingIndex].PhysicalArea = ((RadNumericTextBox)e.Item.FindControl("rtbPhysicalArea")).Value.Value;
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[iDataBuildingIndex].BuildingCreatedYear = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingCreatedYear")).Value.ToString();
                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[iDataBuildingIndex].RenovationYear = ((RadNumericTextBox)e.Item.FindControl("rtbRenovationYear")).Value.ToString();

                     rgDataBuilding.Rebind();
                     btAddNewDataBuilding.Visible = true;
                 }
                 else if (e.CommandName == "Delete")
                 {
                     int iDataBuildingIndex = 0;

                     for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.Count; i++)
                     {
                         if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitDataBuildingId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices[i].LpaNonUnitDataBuildingId)
                         {
                             iDataBuildingIndex = i;
                             break;
                         }
                     }

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitDataBuildingServices.RemoveAt(iDataBuildingIndex);
                     rgLandDescription.Rebind();
                 }
                 else if (e.CommandName == "Edit")
                 {
                     btAddNewDataBuilding.Visible = false;
                 }
                 else if (e.CommandName == "Cancel")
                 {
                     rgDataBuilding.Rebind();
                     btAddNewDataBuilding.Visible = true;
                 }
             }
             catch (System.Threading.ThreadAbortException) { }
             catch (Exception Ex)
             {
                 e.Canceled = true;

                 string sRefNumber = PFSCommon.GenerateRefNumber();

                 ServicesClient oServicesClient = new ServicesClient();
                 oServicesClient.LogError(
                     sessNISPWebLogin.UserName,
                     sRefNumber,
                     GetType().FullName,
                     MethodInfo.GetCurrentMethod().Name,
                     Ex.ToString());
                 oServicesClient.Close();
                 oServicesClient = null;

                 Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
             }
         }

         protected void rgDataBuilding_ItemDataBound(object sender, GridItemEventArgs e)
         {
             try
             {
                 RadDatePicker rdpBuildingPermitsCreateDate = (RadDatePicker)e.Item.FindControl("rdpBuildingPermitsCreateDate");
                 RadNumericTextBox rtbBuildingPermitsArea = (RadNumericTextBox)e.Item.FindControl("rtbBuildingPermitsArea");
                 RadNumericTextBox rtbPhysicalArea = (RadNumericTextBox)e.Item.FindControl("rtbPhysicalArea");
                 RadNumericTextBox rtbBuildingCreatedYear = (RadNumericTextBox)e.Item.FindControl("rtbBuildingCreatedYear");
                 RadNumericTextBox rtbRenovationYear = (RadNumericTextBox)e.Item.FindControl("rtbRenovationYear");

                 if (!e.Item.OwnerTableView.IsItemInserted && rdpBuildingPermitsCreateDate != null && rtbBuildingPermitsArea != null && rtbPhysicalArea != null &&
                     rtbBuildingCreatedYear != null && rtbRenovationYear != null)
                 {
                     rdpBuildingPermitsCreateDate.SelectedDate = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "BuildingPermitsCreateDate"));
                     rtbBuildingPermitsArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingPermitsArea"));
                     rtbBuildingPermitsArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingPermitsArea"));
                     rtbBuildingPermitsArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingPermitsArea"));
                     rtbBuildingPermitsArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingPermitsArea"));
                 }
             }
             catch (System.Threading.ThreadAbortException) { }
             catch (Exception Ex)
             {
                 string sRefNumber = PFSCommon.GenerateRefNumber();

                 ServicesClient oServicesClient = new ServicesClient();
                 oServicesClient.LogError(
                     sessNISPWebLogin.UserName,
                     sRefNumber,
                     GetType().FullName,
                     MethodInfo.GetCurrentMethod().Name,
                     Ex.ToString());
                 oServicesClient.Close();
                 oServicesClient = null;

                 Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
             }
         }  */
        #endregion

        #region Grid FacilityBuilding
        protected void rgLpaNonUnitFacilityBuilding_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaNonUnitFacilityBuildingService> oLpaNonUnitFacilityBuildingServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices;
                rgLpaNonUnitFacilityBuilding.DataSource = oLpaNonUnitFacilityBuildingServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLpaNonUnitFacilityBuilding_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaNonUnitFacilityBuildingService oLpaNonUnitFacilityBuildingService = new LpaNonUnitFacilityBuildingService();
                    oLpaNonUnitFacilityBuildingService.LpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId = vsLpaNonUnitFacilityBuildingId - 1;
                    oLpaNonUnitFacilityBuildingService.FacilityAliasName = ((TextBox)e.Item.FindControl("tbFacilityAliasName")).Text.Trim();
                    oLpaNonUnitFacilityBuildingService.FacilityDescription = ((TextBox)e.Item.FindControl("tbFacilityDescription")).Text.Trim();

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices.Add(oLpaNonUnitFacilityBuildingService);

                    rgLpaNonUnitFacilityBuilding.Rebind();
                    //  btAddNewLpaNonUnitFacilityBuilding.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iFacilityBuildingIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitFacilityBuildingId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices[i].LpaNonUnitFacilityBuildingId)
                        {
                            iFacilityBuildingIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices[iFacilityBuildingIndex].FacilityAliasName = ((TextBox)e.Item.FindControl("tbFacilityAliasName")).Text.Trim();
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices[iFacilityBuildingIndex].FacilityDescription = ((TextBox)e.Item.FindControl("tbFacilityDescription")).Text.Trim();

                    rgLpaNonUnitFacilityBuilding.Rebind();
                    //  btAddNewLpaNonUnitFacilityBuilding.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    vsIndexNumberGridFacilityBuilding = 0;

                    LpaService oLpaService = new LpaService();
                    oLpaService = sessLpa;

                    List<SetupSpesificationBuildingService> oSetupSpesificationBuildingServiceList = new List<SetupSpesificationBuildingService>();
                    SetupSpesificationBuildingServiceClient oSetupSpesificationBuildingServiceClient = new SetupSpesificationBuildingServiceClient();

                    oSetupSpesificationBuildingServiceClient.SetupSpesificationBuildingList(
                        sessNISPWebLogin.UserName,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        out oSetupSpesificationBuildingServiceList);
                    int iIndexForRemove = 0;

                    foreach (SetupSpesificationBuildingService oSetupSpesificationBuildingService in oSetupSpesificationBuildingServiceList)
                    {


                        LpaNonUnitFacilityBuildingService oLpaNonUnitFacilityBuildingServiceCheck =
                            sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices
                                .Where(
                                    o =>
                                    o.LpaNonUnitFacilityBuildingId ==
                                    Convert.ToInt32(
                                        e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex + iIndexForRemove][
                                            "LpaNonUnitFacilityBuildingId"])).FirstOrDefault();

                        sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices.Remove(
                            oLpaNonUnitFacilityBuildingServiceCheck);


                        iIndexForRemove++;
                    }



                    rgLpaNonUnitFacilityBuilding.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    //   btAddNewLpaNonUnitFacilityBuilding.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgLpaNonUnitFacilityBuilding.Rebind();
                    //   btAddNewLpaNonUnitFacilityBuilding.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgLpaNonUnitFacilityBuilding_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    //ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");
                    TextBox tbFacilityDescription = e.Item.FindControl("tbFacilityDescription") as TextBox;
                    Label lblrgridNumber = (Label)e.Item.FindControl("lblrgridNumber");

                    vsIndexNumberGridFacilityBuilding++;

                    lblrgridNumber.Text = vsIndexNumberGridFacilityBuilding.ToString();

                    if (vsIndexNumberGridFacilityBuilding == 1)
                        ibtDelete.Visible = true;
                    else
                        ibtDelete.Visible = false;

                    e.Item.Cells[e.Item.Cells.Count - 1].BackColor = System.Drawing.Color.White;


                    if (vsIndexNumberGridFacilityBuilding == 8)
                        vsIndexNumberGridFacilityBuilding = 0;


                    if (qsActionType == "View")
                    {
                        //ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                        tbFacilityDescription.Enabled = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", "Apakah anda yakin ingin menghapus 8 baris terpilih?");

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid KeteranganBangunan
        protected void rgBuildingDescription_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices;
                rgBuildingDescription.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgBuildingDescription_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitBuildingDescriptionId = vsLpaNonUnitBuildingDescriptionId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.BuildingDescription;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices.Add(oLpaDescriptionService);

                    rgBuildingDescription.Rebind();
                    btAddNewBuildingDescription.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices[iLpaDescriptiontIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgBuildingDescription.Rebind();
                    btAddNewBuildingDescription.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingDescriptionServices.RemoveAt(iLpaDescriptiontIndex);
                    rgBuildingDescription.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewBuildingDescription.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgBuildingDescription.Rebind();
                    btAddNewBuildingDescription.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgBuildingDescription_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid PositifBangunan
        protected void rgBuildingPositiveFactor_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices;
                rgBuildingPositiveFactor.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgBuildingPositiveFactor_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitBuildingPostiveId = vsLpaNonUnitBuildingPostiveId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.PositiveFactorBuilding;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices.Add(oLpaDescriptionService);

                    rgBuildingPositiveFactor.Rebind();
                    btAddNewBuildingPositiveFactor.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices[iLpaDescriptiontIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgBuildingPositiveFactor.Rebind();
                    btAddNewBuildingPositiveFactor.Visible = true; ;
                }
                else if (e.CommandName == "Delete")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingPositiveFactorServices.RemoveAt(iLpaDescriptiontIndex);
                    rgBuildingPositiveFactor.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewBuildingPositiveFactor.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgBuildingPositiveFactor.Rebind();
                    btAddNewBuildingPositiveFactor.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgBuildingPositiveFactor_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid NegatifBangunan
        protected void rgBuildingNegativeFactor_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices;
                rgBuildingNegativeFactor.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgBuildingNegativeFactor_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitBuildingNegativeId = vsLpaNonUnitBuildingNegativeId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.NegativeFactorBuilding;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices.Add(oLpaDescriptionService);

                    rgBuildingNegativeFactor.Rebind();
                    btAddNewBuildingNegativeFactor.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices[iLpaDescriptiontIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgBuildingNegativeFactor.Rebind();
                    btAddNewBuildingNegativeFactor.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iLpaDescriptiontIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices[i].LpaDescriptionId)
                        {
                            iLpaDescriptiontIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingNegativeFactorServices.RemoveAt(iLpaDescriptiontIndex);
                    rgBuildingNegativeFactor.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewBuildingNegativeFactor.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgBuildingNegativeFactor.Rebind();
                    btAddNewBuildingNegativeFactor.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgBuildingNegativeFactor_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid ValueLand
        protected void rgValueLand_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                //if (sessLpa.LpaNonUnitServices.Count == 0)
                //{
                //    return;
                //}
                //List<LpaNonUnitValueLandService> oLpaNonUnitValueLandServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitValueLandServices
                //    .Where(o => o.DocumentCalculationId == vsDocumentCalculationID).ToList();
                //rgValueLand.DataSource = oLpaNonUnitValueLandServices;

                //CalculateByDocumentTypeID();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        /* protected void rgValueLand_ItemCommand(object sender, GridCommandEventArgs e)
         {
             try
             {
                 if (e.CommandName == "PerformInsert")
                 {
                     LpaNonUnitValueLandService oLpaNonUnitValueLandService = new LpaNonUnitValueLandService();
                     oLpaNonUnitValueLandService.LpaNonUnitValueLandId = vsLpaNonUnitValueLandId = vsLpaNonUnitValueLandId - 1;
                     oLpaNonUnitValueLandService.DocumentCalculationId = vsDocumentCalculationID;
                     oLpaNonUnitValueLandService.LandDescription = ((TextBox)e.Item.FindControl("tbLandDescription")).Text.Trim();
                     oLpaNonUnitValueLandService.ValueLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbValueLandArea")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbValueLandArea")).Value.Value;
                     oLpaNonUnitValueLandService.ValueLandPrice = ((RadNumericTextBox)e.Item.FindControl("rtbValueLandPrice")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbValueLandPrice")).Value.Value;
                     oLpaNonUnitValueLandService.LandAdjustment = ((RadNumericTextBox)e.Item.FindControl("rtbLandAdjustment")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbLandAdjustment")).Value.Value;

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitValueLandServices.Add(oLpaNonUnitValueLandService);

                     rgValueLand.Rebind();
                     btAddNewValueLand.Visible = true;
                 }
                 else if (e.CommandName == "Update")
                 {
                     int iValueLandIndex = 0;

                     LpaService oLpaService = sessLpa;
                     for (int i = 0; i < oLpaService.LpaNonUnitServices[0].LpaNonUnitValueLandServices.Count; i++)
                     {
                         if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitValueLandId"]) == oLpaService.LpaNonUnitServices[0].LpaNonUnitValueLandServices[i].LpaNonUnitValueLandId)
                         {
                             iValueLandIndex = i;
                             break;
                         }
                     }

                     oLpaService.LpaNonUnitServices[0].LpaNonUnitValueLandServices[iValueLandIndex].LandDescription = ((TextBox)e.Item.FindControl("tbLandDescription")).Text.Trim();
                     oLpaService.LpaNonUnitServices[0].LpaNonUnitValueLandServices[iValueLandIndex].ValueLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbValueLandArea")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbValueLandArea")).Value.Value;
                     oLpaService.LpaNonUnitServices[0].LpaNonUnitValueLandServices[iValueLandIndex].ValueLandPrice = ((RadNumericTextBox)e.Item.FindControl("rtbValueLandPrice")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbValueLandPrice")).Value.Value;
                     oLpaService.LpaNonUnitServices[0].LpaNonUnitValueLandServices[iValueLandIndex].LandAdjustment = ((RadNumericTextBox)e.Item.FindControl("rtbLandAdjustment")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbLandAdjustment")).Value.Value;

                     sessLpa = oLpaService;
                     oLpaService = null;
                     rgValueLand.Rebind();
                     btAddNewValueLand.Visible = true;
                 }
                 else if (e.CommandName == "Delete")
                 {
                     int iValueLandIndex = 0;

                     for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitValueLandServices.Count; i++)
                     {
                         if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitValueLandId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitValueLandServices[i].LpaNonUnitValueLandId)
                         {
                             iValueLandIndex = i;
                             break;
                         }
                     }

                     sessLpa.LpaNonUnitServices[0].LpaNonUnitValueLandServices.RemoveAt(iValueLandIndex);
                     rgValueLand.Rebind();
                 }
                 else if (e.CommandName == "Edit")
                 {
                     btAddNewValueLand.Visible = false;
                 }
                 else if (e.CommandName == "Cancel")
                 {
                     rgValueLand.Rebind();
                     btAddNewValueLand.Visible = true;
                 }
             }
             catch (System.Threading.ThreadAbortException) { }
             catch (Exception Ex)
             {
                 e.Canceled = true;

                 string sRefNumber = PFSCommon.GenerateRefNumber();

                 ServicesClient oServicesClient = new ServicesClient();
                 oServicesClient.LogError(
                     sessNISPWebLogin.UserName,
                     sRefNumber,
                     GetType().FullName,
                     MethodInfo.GetCurrentMethod().Name,
                     Ex.ToString());
                 oServicesClient.Close();
                 oServicesClient = null;

                 Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
             }
         } */

        protected void rgValueLand_ItemDataBound(object sender, GridItemEventArgs e)
        {

            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                    /* RadNumericTextBox rtbValueLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbValueLandArea"));
                     RadNumericTextBox rtbValueLandPrice = ((RadNumericTextBox)e.Item.FindControl("rtbValueLandPrice"));
                     RadNumericTextBox rtbLandAdjustment = ((RadNumericTextBox)e.Item.FindControl("rtbLandAdjustment"));

                     if (!e.Item.OwnerTableView.IsItemInserted)
                     {
                         if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ValueLandArea")))
                         {
                             rtbValueLandArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ValueLandArea"));
                         }

                         if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ValueLandPrice")))
                         {
                             rtbValueLandPrice.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ValueLandPrice"));
                         }

                         if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "LandAdjustment")))
                         {
                             rtbLandAdjustment.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "LandAdjustment"));
                         }
                     }*/
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    double dValueLandArea = 0;
                    double dValueLandPrice = 0;
                    double dLandAdjustment = 0;

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ValueLandArea")))
                    {
                        dValueLandArea = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ValueLandArea"));
                    }

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ValueLandPrice")))
                    {
                        dValueLandPrice = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ValueLandPrice"));
                    }

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "LandAdjustment")))
                    {
                        dLandAdjustment = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "LandAdjustment"));
                    }

                    Label lblValueLandPriceCalc = ((Label)e.Item.FindControl("lblValueLandPriceCalc"));
                    Label lblLandAdjustmentCalc = ((Label)e.Item.FindControl("lblLandAdjustmentCalc"));
                    Label lblValueMarketLandPriceCalc = ((Label)e.Item.FindControl("lblValueMarketLandPriceCalc"));

                    lblValueLandPriceCalc.Text = PFSCommon.FormatNumber(dValueLandArea * dValueLandPrice);
                    lblLandAdjustmentCalc.Text = PFSCommon.FormatNumber((dLandAdjustment / 100) * dValueLandArea * dValueLandPrice);
                    lblValueMarketLandPriceCalc.Text = PFSCommon.FormatNumber((dValueLandArea * dValueLandPrice) - (dLandAdjustment / 100) * dValueLandArea * dValueLandPrice);

                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid ValueBuilding
        protected void rgValueBuilding_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                //List<LpaNonUnitValueBuildingService> oLpaNonUnitValueBuildingServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices
                //    .Where(o => o.DocumentCalculationId == vsDocumentCalculationID).ToList();
                //rgValueBuilding.DataSource = oLpaNonUnitValueBuildingServices;

                //CalculateByDocumentTypeID();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgValueBuilding_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaNonUnitValueBuildingService oLpaNonUnitValueBuildingService = new LpaNonUnitValueBuildingService();
                    oLpaNonUnitValueBuildingService.LpaNonUnitValueBuildingId = vsLpaNonUnitValueBuildingId = vsLpaNonUnitValueBuildingId - 1;
                    oLpaNonUnitValueBuildingService.DocumentCalculationId = vsDocumentCalculationID;
                    oLpaNonUnitValueBuildingService.BuildingName = ((TextBox)e.Item.FindControl("tbBuildingName")).Text.Trim();
                    oLpaNonUnitValueBuildingService.BuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingArea")).Value.Value;
                    oLpaNonUnitValueBuildingService.BuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingPrice")).Value.Value;
                    oLpaNonUnitValueBuildingService.BuildingProgress = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingProgress")).Value.Value;
                    oLpaNonUnitValueBuildingService.BuildingDepreciation = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingDepreciation")).Value.Value;
                    oLpaNonUnitValueBuildingService.RepairCost = ((RadNumericTextBox)e.Item.FindControl("rtbRepairCost")).Value.Value;
                    oLpaNonUnitValueBuildingService.EconomicAsumption = ((RadNumericTextBox)e.Item.FindControl("rtbEconomicAsumption")).Value.Value;

                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices.Add(oLpaNonUnitValueBuildingService);

                    rgValueBuilding.Rebind();
                    btAddNewValueBuilding.Visible = true;
                }
                else if (e.CommandName == "Update")
                {

                    //for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices.Count; i++)
                    //{
                    //    if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitValueBuildingId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[i].LpaNonUnitValueBuildingId)
                    //    {
                    //        iValueBuildingIndex = i;
                    //        break;
                    //    }
                    //}

                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[iValueBuildingIndex].BuildingName = ((TextBox)e.Item.FindControl("tbBuildingName")).Text.Trim();
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[iValueBuildingIndex].BuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingArea")).Value.Value;
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[iValueBuildingIndex].BuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingPrice")).Value.Value;
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[iValueBuildingIndex].BuildingProgress = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingProgress")).Value.Value;
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[iValueBuildingIndex].BuildingDepreciation = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingDepreciation")).Value.Value;
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[iValueBuildingIndex].RepairCost = ((RadNumericTextBox)e.Item.FindControl("rtbRepairCost")).Value.Value;
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[iValueBuildingIndex].EconomicAsumption = ((RadNumericTextBox)e.Item.FindControl("rtbEconomicAsumption")).Value.Value;

                    //rgValueBuilding.Rebind();
                    //btAddNewValueBuilding.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {

                    //for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices.Count; i++)
                    //{
                    //    if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitValueBuildingId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices[i].LpaNonUnitValueBuildingId)
                    //    {
                    //        iValueBuildingIndex = i;
                    //        break;
                    //    }
                    //}

                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices.RemoveAt(iValueBuildingIndex);
                    //rgValueBuilding.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewValueBuilding.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgValueBuilding.Rebind();
                    btAddNewValueBuilding.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgValueBuilding_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                    /*RadNumericTextBox rtbBuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingPrice"));
                    RadNumericTextBox rtbBuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingArea"));
                    RadNumericTextBox rtbTotalPriceCalc = ((RadNumericTextBox)e.Item.FindControl("rtbTotalPriceCalc"));
                    RadNumericTextBox rtbBuildingProgress = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingProgress"));
                    RadNumericTextBox rtbBuildingDepreciation = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingDepreciation"));
                    RadNumericTextBox rtbBuildingProgressCalc = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingProgressCalc"));
                    RadNumericTextBox rtbBuildingDepreciationCalc = ((RadNumericTextBox)e.Item.FindControl("rtbBuildingDepreciationCalc"));
                    RadNumericTextBox rtbRepairCost = ((RadNumericTextBox)e.Item.FindControl("rtbRepairCost"));
                    RadNumericTextBox rtbRepairCostCalc = ((RadNumericTextBox)e.Item.FindControl("rtbRepairCostCalc"));
                    RadNumericTextBox rtbEconomicAsumption = ((RadNumericTextBox)e.Item.FindControl("rtbEconomicAsumption"));
                    RadNumericTextBox rtbTotalSummaryCalc = ((RadNumericTextBox)e.Item.FindControl("rtbTotalSummaryCalc"));
                    RadNumericTextBox rtbEconomicAsumptionCalc = ((RadNumericTextBox)e.Item.FindControl("rtbEconomicAsumptionCalc"));

                    if (!e.Item.OwnerTableView.IsItemInserted)
                    {
                        if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingPrice")))
                        {
                            rtbBuildingPrice.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingPrice"));
                        }
                        else
                        {
                            rtbBuildingPrice.Value = 0;
                        }

                        if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingArea")))
                        {
                            rtbBuildingArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingArea"));
                        }
                        else
                        {
                            rtbBuildingArea.Value = 0;
                        }

                        rtbTotalPriceCalc.Value = rtbBuildingPrice.Value.Value * rtbBuildingArea.Value.Value;

                        if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingProgress")))
                        {
                            rtbBuildingProgress.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingProgress"));
                        }
                        else
                        {
                            rtbBuildingProgress.Value = 0;
                        }

                        rtbBuildingProgressCalc.Value = rtbBuildingProgress.Value.Value / 100 * rtbTotalPriceCalc.Value.Value;

                        if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingDepreciation")))
                        {
                            rtbBuildingDepreciation.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingDepreciation"));
                        }
                        else
                        {
                            rtbBuildingDepreciation.Value = 0;
                        }

                        rtbBuildingDepreciationCalc.Value = rtbBuildingDepreciation.Value.Value / 100 * rtbTotalPriceCalc.Value.Value;

                        if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "RepairCost")))
                        {
                            rtbRepairCost.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "RepairCost"));
                        }
                        else
                        {
                            rtbRepairCost.Value = 0;
                        }

                        rtbRepairCostCalc.Value = rtbRepairCost.Value.Value / 100 * rtbTotalPriceCalc.Value.Value;

                        if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "EconomicAsumption")))
                        {
                            rtbEconomicAsumption.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "EconomicAsumption"));
                        }
                        else
                        {
                            rtbEconomicAsumption.Value = 0;
                        }

                        rtbEconomicAsumptionCalc.Value = rtbTotalPriceCalc.Value.Value / 100 * rtbEconomicAsumptionCalc.Value.Value;

                        rtbTotalSummaryCalc.Value = rtbBuildingDepreciationCalc.Value.Value + rtbBuildingDepreciationCalc.Value.Value + rtbRepairCostCalc.Value.Value; 
                    }*/
                }

                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    double dBuildingPrice = 0;
                    double dBuildingArea = 0;
                    double dBuildingProgress = 0;
                    double dBuildingDepreciation = 0;
                    double dRepairCost = 0;
                    double dEconomicAsumption = 0;

                    Label lblTotalPriceCalc = ((Label)e.Item.FindControl("lblTotalPriceCalc"));
                    Label lblBuildingProgressCalc = ((Label)e.Item.FindControl("lblBuildingProgressCalc"));
                    Label lblBuildingDepreciationCalc = ((Label)e.Item.FindControl("lblBuildingDepreciationCalc"));
                    Label lblRepairCostCalc = ((Label)e.Item.FindControl("lblRepairCostCalc"));
                    Label lblEconomicAsumptionCalc = ((Label)e.Item.FindControl("lblEconomicAsumptionCalc"));
                    Label lblTotalSummaryCalc = ((Label)e.Item.FindControl("lblTotalSummaryCalc"));

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingPrice")))
                    {
                        dBuildingPrice = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingPrice"));
                    }

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingArea")))
                    {
                        dBuildingArea = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingArea"));
                    }

                    lblTotalPriceCalc.Text = PFSCommon.FormatNumber(dBuildingPrice * dBuildingArea);

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingProgress")))
                    {
                        dBuildingProgress = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingProgress"));
                    }

                    lblBuildingProgressCalc.Text = PFSCommon.FormatNumber(dBuildingProgress / 100 * dBuildingPrice * dBuildingArea);

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "BuildingDepreciation")))
                    {
                        dBuildingDepreciation = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "BuildingDepreciation"));
                    }

                    lblBuildingDepreciationCalc.Text = PFSCommon.FormatNumber(dBuildingDepreciation / 100 * dBuildingPrice * dBuildingArea);

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "RepairCost")))
                    {
                        dRepairCost = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "RepairCost"));
                    }

                    lblRepairCostCalc.Text = PFSCommon.FormatNumber(dRepairCost / 100 * dBuildingPrice * dBuildingArea);

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "EconomicAsumption")))
                    {
                        dEconomicAsumption = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "EconomicAsumption"));
                    }

                    lblEconomicAsumptionCalc.Text = PFSCommon.FormatNumber(dEconomicAsumption / 100 * dBuildingPrice * dBuildingArea);

                    lblTotalSummaryCalc.Text = PFSCommon.FormatNumber((dEconomicAsumption / 100 * dBuildingPrice * dBuildingArea) + (dRepairCost / 100 * dBuildingPrice * dBuildingArea) + (dBuildingDepreciation / 100 * dBuildingPrice * dBuildingArea));

                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid ValueFacility
        protected void rgValueFacility_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                //List<LpaNonUnitValueFacilityService> oLpaNonUnitValueFacilityServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices
                //    .Where(o => o.DocumentCalculationId == vsDocumentCalculationID).ToList();
                //rgValueFacility.DataSource = oLpaNonUnitValueFacilityServices;

                //CalculateByDocumentTypeID();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgValueFacility_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaNonUnitValueFacilityService oLpaNonUnitValueFacilityService = new LpaNonUnitValueFacilityService();
                    oLpaNonUnitValueFacilityService.LpaNonUnitValueFacilityId = vsLpaNonUnitValueFacilityId = vsLpaNonUnitValueFacilityId - 1;
                    oLpaNonUnitValueFacilityService.DocumentCalculationId = vsDocumentCalculationID;
                    oLpaNonUnitValueFacilityService.FacilityName = ((TextBox)e.Item.FindControl("tbFacilityName")).Text.Trim();
                    oLpaNonUnitValueFacilityService.FacilityMeasurement = ((RadNumericTextBox)e.Item.FindControl("rtbFacilityMeasurement")).Value.Value;
                    oLpaNonUnitValueFacilityService.FacilityUnitOfMeasure = ((TextBox)e.Item.FindControl("tbFacilityUnitOfMeasure")).Text.Trim();
                    oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency = ((RadNumericTextBox)e.Item.FindControl("rtbFacilityAmountHomeCurrency")).Value.Value;

                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices.Add(oLpaNonUnitValueFacilityService);

                    rgValueFacility.Rebind();
                    btAddNewValueFacility.Visible = true;
                }
                else if (e.CommandName == "Update")
                {

                    //for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices.Count; i++)
                    //{
                    //    if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitValueFacilityId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices[i].LpaNonUnitValueFacilityId)
                    //    {
                    //        iValueFacilityIndex = i;
                    //        break;
                    //    }
                    //}

                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices[iValueFacilityIndex].FacilityName = ((TextBox)e.Item.FindControl("tbFacilityName")).Text.Trim();
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices[iValueFacilityIndex].FacilityMeasurement = ((RadNumericTextBox)e.Item.FindControl("rtbFacilityMeasurement")).Value.Value;
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices[iValueFacilityIndex].FacilityUnitOfMeasure = ((TextBox)e.Item.FindControl("tbFacilityUnitOfMeasure")).Text.Trim();
                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices[iValueFacilityIndex].FacilityAmountHomeCurrency = ((RadNumericTextBox)e.Item.FindControl("rtbFacilityAmountHomeCurrency")).Value.Value;

                    rgValueFacility.Rebind();
                    btAddNewValueFacility.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {

                    //for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices.Count; i++)
                    //{
                    //    if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitValueFacilityId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices[i].LpaNonUnitValueFacilityId)
                    //    {
                    //        iValueFacilityIndex = i;
                    //        break;
                    //    }
                    //}

                    //sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices.RemoveAt(iValueFacilityIndex);
                    //rgValueFacility.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewValueFacility.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgValueFacility.Rebind();
                    btAddNewValueFacility.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgValueFacility_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                    //RadNumericTextBox rtbFacilityMeasurement = ((RadNumericTextBox)e.Item.FindControl("rtbFacilityMeasurement"));
                    //RadNumericTextBox rtbFacilityAmountHomeCurrency = ((RadNumericTextBox)e.Item.FindControl("rtbFacilityAmountHomeCurrency"));
                    //RadNumericTextBox rtbValueCalc = ((RadNumericTextBox)e.Item.FindControl("rtbValueCalc"));

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "FacilityMeasurement")))
                    //{
                    //    rtbFacilityMeasurement.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "FacilityMeasurement"));
                    //}
                    //else
                    //{
                    //    rtbFacilityMeasurement.Value = 0;
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "FacilityAmountHomeCurrency")))
                    //{
                    //    rtbFacilityAmountHomeCurrency.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "FacilityAmountHomeCurrency"));
                    //}
                    //else
                    //{
                    //    rtbFacilityAmountHomeCurrency.Value = 0;
                    //}

                    //rtbValueCalc.Value = rtbFacilityAmountHomeCurrency.Value.Value * rtbFacilityMeasurement.Value.Value;
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    double dFacilityMeasurement = 0;
                    double dFacilityAmountHomeCurrency = 0;
                    Label lblValueCalc = ((Label)e.Item.FindControl("lblValueCalc"));

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "FacilityMeasurement")))
                    {
                        dFacilityMeasurement = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "FacilityMeasurement"));
                        dFacilityAmountHomeCurrency = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "FacilityAmountHomeCurrency"));
                    }

                    lblValueCalc.Text = PFSCommon.FormatNumber(dFacilityAmountHomeCurrency * dFacilityMeasurement);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid TaxLand
        protected void rgTaxLand_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaNonUnitTaxLandService> oLpaNonUnitTaxLandServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices;
                rgTaxLand.DataSource = oLpaNonUnitTaxLandServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgTaxLand_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaNonUnitTaxLandService oLpaNonUnitTaxLandService = new LpaNonUnitTaxLandService();
                    oLpaNonUnitTaxLandService.LpaNonUnitTaxLandId = vsLpaNonUnitTaxLandId = vsLpaNonUnitTaxLandId - 1;
                    oLpaNonUnitTaxLandService.TaxLandDataValue = ((TextBox)e.Item.FindControl("tbTaxLandDataValue")).Text.Trim();
                    oLpaNonUnitTaxLandService.TaxLandYear = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandYear")).Value.ToString();
                    oLpaNonUnitTaxLandService.TaxLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandArea")).Value.Value;
                    oLpaNonUnitTaxLandService.TaxBuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbTaxBuildingArea")).Value.Value;
                    oLpaNonUnitTaxLandService.TaxLandPrice = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandPrice")).Value.Value;
                    oLpaNonUnitTaxLandService.TaxBuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbTaxBuildingPrice")).Value.Value;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices.Add(oLpaNonUnitTaxLandService);

                    rgTaxLand.Rebind();
                    btAddNewLpaNonUnitTaxLand.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iTaxLandIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitTaxLandId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[i].LpaNonUnitTaxLandId)
                        {
                            iTaxLandIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[iTaxLandIndex].TaxLandDataValue = ((TextBox)e.Item.FindControl("tbTaxLandDataValue")).Text.Trim();
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[iTaxLandIndex].TaxLandYear = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandYear")).Value.ToString();
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[iTaxLandIndex].TaxLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandArea")).Value.Value;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[iTaxLandIndex].TaxBuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbTaxBuildingArea")).Value.Value;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[iTaxLandIndex].TaxLandPrice = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandPrice")).Value.Value;
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[iTaxLandIndex].TaxBuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbTaxBuildingPrice")).Value.Value;

                    rgTaxLand.Rebind();
                    btAddNewLpaNonUnitTaxLand.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iTaxLandIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaNonUnitTaxLandId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices[i].LpaNonUnitTaxLandId)
                        {
                            iTaxLandIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTaxLandServices.RemoveAt(iTaxLandIndex);
                    rgTaxLand.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewLpaNonUnitTaxLand.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgTaxLand.Rebind();
                    btAddNewLpaNonUnitTaxLand.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgTaxLand_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                    //RadNumericTextBox rtbPbbValueCalc = ((RadNumericTextBox)e.Item.FindControl("rtbPbbValueCalc"));
                    //RadNumericTextBox rtbTaxLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandArea"));
                    //RadNumericTextBox rtbTaxBuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbTaxBuildingArea"));
                    //RadNumericTextBox rtbTaxLandPrice = ((RadNumericTextBox)e.Item.FindControl("rtbTaxLandPrice"));
                    //RadNumericTextBox rtbTaxBuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbTaxBuildingPrice"));

                    //if (!e.Item.OwnerTableView.IsItemInserted)
                    //{
                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxLandArea")))
                    //    {
                    //        rtbTaxLandArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxLandArea"));
                    //    }
                    //    else
                    //    {
                    //        rtbTaxLandArea.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxBuildingArea")))
                    //    {
                    //        rtbTaxBuildingArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxBuildingArea"));
                    //    }
                    //    else
                    //    {
                    //        rtbTaxBuildingArea.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxLandPrice")))
                    //    {
                    //        rtbTaxLandPrice.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxLandPrice"));
                    //    }
                    //    else
                    //    {
                    //        rtbTaxLandPrice.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxBuildingPrice")))
                    //    {
                    //        rtbTaxBuildingPrice.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxBuildingPrice"));
                    //    }
                    //    else
                    //    {
                    //        rtbTaxBuildingPrice.Value = 0;
                    //    }

                    //    rtbPbbValueCalc.Value = (rtbTaxLandArea.Value.Value * rtbTaxLandPrice.Value.Value) + (rtbTaxBuildingArea.Value.Value * rtbTaxBuildingPrice.Value.Value);
                    //}
                }

                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    double dTaxLandArea = 0;
                    double dTaxBuildingArea = 0;
                    double dTaxLandPrice = 0;
                    double dTaxBuildingPrice = 0;

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxLandArea")))
                    {
                        dTaxLandArea = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxLandArea"));
                    }

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxBuildingArea")))
                    {
                        dTaxBuildingArea = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxBuildingArea"));
                    }

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxLandPrice")))
                    {
                        dTaxLandPrice = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxLandPrice"));
                    }

                    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "TaxBuildingPrice")))
                    {
                        dTaxBuildingPrice = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "TaxBuildingPrice"));
                    }

                    Label lblPbbValueCalc = ((Label)e.Item.FindControl("lblPbbValueCalc"));
                    lblPbbValueCalc.Text = PFSCommon.FormatNumber((dTaxLandArea * dTaxLandPrice) + (dTaxBuildingArea * dTaxBuildingPrice));
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid InformasiSyaratKhusus
        protected void rgSpecialInformation_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices;
                rgSpecialInformation.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgSpecialInformation_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitSpecialInformationId = vsLpaNonUnitSpecialInformationId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.SpecialInformation;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices.Add(oLpaDescriptionService);

                    rgSpecialInformation.Rebind();
                    btAddNewSpecialInformation.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iSyaratKhususIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices[i].LpaDescriptionId)
                        {
                            iSyaratKhususIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices[iSyaratKhususIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgSpecialInformation.Rebind();
                    btAddNewSpecialInformation.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iSyaratKhususIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices[i].LpaDescriptionId)
                        {
                            iSyaratKhususIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitSpecialInformationServices.RemoveAt(iSyaratKhususIndex);
                    rgSpecialInformation.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewSpecialInformation.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgSpecialInformation.Rebind();
                    btAddNewSpecialInformation.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgSpecialInformation_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid MarketComparative
        protected void rgMarketComparative_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                List<LpaComparativeNonunitService> oLpaComparativeNonunitServices = sessLpa.LpaComparativeNonunitServices;
                rgMarketComparative.DataSource = oLpaComparativeNonunitServices;

                if (sessLpa.LpaComparativeNonunitServices != null)
                {
                    double dTotal = 0;
                    double dWeghtPercentage = 0;

                    foreach (LpaComparativeNonunitService oLpaComparativeNonUnitService in sessLpa.LpaComparativeNonunitServices)
                    {
                        double dPredictioValue = (oLpaComparativeNonUnitService.ComparativeNonUnitAmount - oLpaComparativeNonUnitService.ComparativeNonUnitFurnishPrice) * ((100 - oLpaComparativeNonUnitService.ComparativeNonUnitSellingPriceDiscount) / 100);

                        double dEstimateBuildingValue =
                            oLpaComparativeNonUnitService.ComparativeNonUnitBuildingArea *
                                 oLpaComparativeNonUnitService.ComparativeNonUnitNewBuildingPrice
                                 * (1 - (oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation / 100));

                        double dEstimateLandValue =
                             (((dPredictioValue) -
                              ((oLpaComparativeNonUnitService.ComparativeNonUnitBuildingArea) *
                              (oLpaComparativeNonUnitService.ComparativeNonUnitNewBuildingPrice) *
                              (1 - (oLpaComparativeNonUnitService.ComparativeNonUnitDepreciation) / 100))) /
                              (oLpaComparativeNonUnitService.ComparativeNonUnitLandArea));

                        double dIndicationUnitValue = (dEstimateLandValue * oLpaComparativeNonUnitService.ComparativeNonUnitDataPercentage) / 100;
                        dTotal += dIndicationUnitValue;
                        dWeghtPercentage += oLpaComparativeNonUnitService.ComparativeNonUnitDataPercentage;
                    }

                    lblTotalIndicationMarketValue.Text = PFSCommon.FormatNumber(dTotal);
                    lblTotalWeightPercentage.Text = PFSCommon.FormatNumber(dWeghtPercentage);
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgMarketComparative_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaComparativeNonunitService oLpaComparativeNonunitService = new LpaComparativeNonunitService();
                    oLpaComparativeNonunitService.LpaComparativeNonUnitId = vsLpaComparativeNonUnitId = vsLpaComparativeNonUnitId - 1;
                    oLpaComparativeNonunitService.RefDatabaseId = Convert.ToInt32(((RadNumericTextBox)e.Item.FindControl("rtbRefDatabaseId")).Value);
                    oLpaComparativeNonunitService.ComparativeNonUnitSellingDate = ((RadDatePicker)e.Item.FindControl("rdpComparativeNonUnitSellingDate")).SelectedDate == null ? new DateTime(1900, 1, 1) : ((RadDatePicker)e.Item.FindControl("rdpComparativeNonUnitSellingDate")).SelectedDate.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDataStatus = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedValue == null ? 0 : Convert.ToInt32(((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedValue);
                    oLpaComparativeNonunitService.SourceDataDescription = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedValue == null ? "-" : ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedItem.ToString();
                    oLpaComparativeNonunitService.ComparativeNonUnitDataSource = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedValue == null ? 0 : Convert.ToInt32(((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedValue);
                    oLpaComparativeNonunitService.StatusDataDescription = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedValue == null ? "-" : ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedItem.ToString();
                    oLpaComparativeNonunitService.ComparativeNonUnitMarketingName = ((TextBox)e.Item.FindControl("tbComparativeNonUnitMarketingName")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitMarketingPhone = ((TextBox)e.Item.FindControl("tbComparativeNonUnitMarketingPhone")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitAddress1 = ((TextBox)e.Item.FindControl("tbComparativeNonUnitAddress1")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitLandArea")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitWidthStreet = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitWidthStreet")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitWidthStreet")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitLegality = ((TextBox)e.Item.FindControl("tbComparativeNonUnitLegality")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitCondition = ((TextBox)e.Item.FindControl("tbComparativeNonUnitCondition")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitRangeArea = ((TextBox)e.Item.FindControl("tbComparativeNonUnitRangeArea")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitIsRegency = ((RadioButton)e.Item.FindControl("rdpComparativeNonUnitIsRegencyFalse")).Checked;
                    oLpaComparativeNonunitService.ComparativeNonUnitCluster = ((TextBox)e.Item.FindControl("tbComparativeNonUnitCluster")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitPosition = ((TextBox)e.Item.FindControl("tbComparativeNonUnitPosition")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitLandArea")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitLandArea")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitBuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitBuildingArea")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitBuildingArea")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitCreatedYear = ((TextBox)e.Item.FindControl("tbComparativeNonUnitCreatedYear")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitRenovationYear = ((TextBox)e.Item.FindControl("tbComparativeNonUnitRenovationYear")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitAreaPosition = ((TextBox)e.Item.FindControl("tbComparativeNonUnitAreaPosition")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitSellingPriceHomeCurrency = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceHomeCurrency")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceHomeCurrency")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDiscountRecommended = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDiscountRecommended")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDiscountRecommended")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitSellingPriceDiscount = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceDiscount")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceDiscount")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitFurnishPrice = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitFurnishPrice")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitFurnishPrice")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDescription = ((TextBox)e.Item.FindControl("tbComparativeNonUnitDescription")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitNewBuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitNewBuildingPrice")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitNewBuildingPrice")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDepreciation = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDepreciation")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDepreciation")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDataPercentage = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDataPercentage")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDataPercentage")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDataSourceDescription = ((TextBox)e.Item.FindControl("tbComparativeNonUnitDataSourceDescription")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitDataStatusDescription = ((TextBox)e.Item.FindControl("tbComparativeNonUnitDataStatusDescription")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitRadius = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitRadius")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitRadius")).Value.Value;

                    oLpaComparativeNonunitService.ComparativeNonUnitSellingPriceHomeCurrency = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceHomeCurrency")).Value.Value;
                    //oLpaComparativeNonunitService

                    sessLpa.LpaComparativeNonunitServices.Add(oLpaComparativeNonunitService);

                    rgMarketComparative.Rebind();
                    btAddNewMarketComparative.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iComparativeIndex = 0;

                    for (int i = 0; i < sessLpa.LpaComparativeNonunitServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaComparativeNonUnitId"]) == sessLpa.LpaComparativeNonunitServices[i].LpaComparativeNonUnitId)
                        {
                            iComparativeIndex = i;
                            break;
                        }
                    }

                    LpaComparativeNonunitService oLpaComparativeNonunitService = new LpaComparativeNonunitService();
                    oLpaComparativeNonunitService.LpaComparativeNonUnitId = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaComparativeNonUnitId"]);
                    oLpaComparativeNonunitService.RefDatabaseId = Convert.ToInt32(((RadNumericTextBox)e.Item.FindControl("rtbRefDatabaseId")).Value);
                    oLpaComparativeNonunitService.ComparativeNonUnitSellingDate = ((RadDatePicker)e.Item.FindControl("rdpComparativeNonUnitSellingDate")).SelectedDate == null ? new DateTime(1900, 1, 1) : ((RadDatePicker)e.Item.FindControl("rdpComparativeNonUnitSellingDate")).SelectedDate.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDataStatus = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedValue == null ? 0 : Convert.ToInt32(((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedValue);
                    oLpaComparativeNonunitService.StatusDataDescription = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedValue == null ? "-" : ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus")).SelectedItem.ToString();
                    oLpaComparativeNonunitService.ComparativeNonUnitDataSource = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedValue == null ? 0 : Convert.ToInt32(((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedValue);
                    oLpaComparativeNonunitService.SourceDataDescription = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedValue == null ? "-" : ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource")).SelectedItem.ToString();
                    oLpaComparativeNonunitService.ComparativeNonUnitMarketingName = ((TextBox)e.Item.FindControl("tbComparativeNonUnitMarketingName")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitMarketingPhone = ((TextBox)e.Item.FindControl("tbComparativeNonUnitMarketingPhone")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitAddress1 = ((TextBox)e.Item.FindControl("tbComparativeNonUnitAddress1")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitLandArea")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitWidthStreet = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitWidthStreet")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitWidthStreet")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitLegality = ((TextBox)e.Item.FindControl("tbComparativeNonUnitLegality")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitCondition = ((TextBox)e.Item.FindControl("tbComparativeNonUnitCondition")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitRangeArea = ((TextBox)e.Item.FindControl("tbComparativeNonUnitRangeArea")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitIsRegency = ((RadioButton)e.Item.FindControl("rdpComparativeNonUnitIsRegencyFalse")).Checked;
                    oLpaComparativeNonunitService.ComparativeNonUnitCluster = ((TextBox)e.Item.FindControl("tbComparativeNonUnitCluster")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitPosition = ((TextBox)e.Item.FindControl("tbComparativeNonUnitPosition")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitLandArea")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitLandArea")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitBuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitBuildingArea")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitBuildingArea")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitCreatedYear = ((TextBox)e.Item.FindControl("tbComparativeNonUnitCreatedYear")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitRenovationYear = ((TextBox)e.Item.FindControl("tbComparativeNonUnitRenovationYear")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitAreaPosition = ((TextBox)e.Item.FindControl("tbComparativeNonUnitAreaPosition")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitSellingPriceHomeCurrency = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceHomeCurrency")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceHomeCurrency")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDiscountRecommended = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDiscountRecommended")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDiscountRecommended")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitSellingPriceDiscount = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceDiscount")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceDiscount")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitFurnishPrice = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitFurnishPrice")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitFurnishPrice")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDescription = ((TextBox)e.Item.FindControl("tbComparativeNonUnitDescription")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitNewBuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitNewBuildingPrice")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitNewBuildingPrice")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDepreciation = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDepreciation")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDepreciation")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDataPercentage = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDataPercentage")).Value == null ? 0 : ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDataPercentage")).Value.Value;
                    oLpaComparativeNonunitService.ComparativeNonUnitDataSourceDescription = ((TextBox)e.Item.FindControl("tbComparativeNonUnitDataSourceDescription")).Text.Trim();
                    oLpaComparativeNonunitService.ComparativeNonUnitDataStatusDescription = ((TextBox)e.Item.FindControl("tbComparativeNonUnitDataStatusDescription")).Text.Trim();

                    sessLpa.LpaComparativeNonunitServices[iComparativeIndex] = oLpaComparativeNonunitService;

                    rgMarketComparative.Rebind();
                    btAddNewMarketComparative.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iComparativeIndex = 0;

                    for (int i = 0; i < sessLpa.LpaComparativeNonunitServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaComparativeNonUnitId"]) == sessLpa.LpaComparativeNonunitServices[i].LpaComparativeNonUnitId)
                        {
                            iComparativeIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaComparativeNonunitServices.RemoveAt(iComparativeIndex);
                    rgMarketComparative.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewMarketComparative.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgMarketComparative.Rebind();
                    btAddNewMarketComparative.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgMarketComparative_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                    //RadNumericTextBox rtbComparativeNonUnitRadius = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitRadius"));
                    //RadNumericTextBox rtbComparativeNonUnitWidthStreet = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitWidthStreet"));
                    //RadNumericTextBox rtbComparativeNonUnitLandArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitLandArea"));
                    //RadNumericTextBox rtbComparativeNonUnitBuildingArea = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitBuildingArea"));
                    //RadNumericTextBox rtbComparativeNonUnitSellingPriceHomeCurrency = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceHomeCurrency"));
                    //RadNumericTextBox rtbComparativeNonUnitDiscountRecommended = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDiscountRecommended"));
                    //RadNumericTextBox rtbComparativeNonUnitFurnishPrice = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitFurnishPrice"));
                    //RadNumericTextBox rtbComparativeNonUnitNewBuildingPrice = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitNewBuildingPrice"));
                    //RadNumericTextBox rtbComparativeNonUnitDataPercentage = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDataPercentage"));
                    //RadNumericTextBox rtbComparativeNonUnitSellingPriceDiscount = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitSellingPriceDiscount"));
                    //RadNumericTextBox rtbIndicationPrice = ((RadNumericTextBox)e.Item.FindControl("rtbIndicationPrice"));
                    //RadNumericTextBox rtbIndicationLandPriceCalc = ((RadNumericTextBox)e.Item.FindControl("rtbIndicationLandPriceCalc"));
                    //RadNumericTextBox rtbPredictionLandValueCalc = ((RadNumericTextBox)e.Item.FindControl("rtbPredictionLandValueCalc"));
                    //RadNumericTextBox rtbComparativeNonUnitDepreciation = ((RadNumericTextBox)e.Item.FindControl("rtbComparativeNonUnitDepreciation"));
                    //DropDownList ddlComparativeNonUnitDataStatus = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataStatus"));
                    //DropDownList ddlComparativeNonUnitDataSource = ((DropDownList)e.Item.FindControl("ddlComparativeNonUnitDataSource"));
                    //RadDatePicker rdpComparativeNonUnitSellingDate = ((RadDatePicker)e.Item.FindControl("rdpComparativeNonUnitSellingDate"));

                    //Bind_ddlSourceDataDescription(ddlComparativeNonUnitDataSource);
                    //Bind_ddlStatusDataDescription(ddlComparativeNonUnitDataStatus);

                    //if (!e.Item.OwnerTableView.IsItemInserted)
                    //{
                    //    if (PFSCommon.IsDate(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingDate")) && Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingDate")).Date > new DateTime(1900, 1, 1))
                    //    {
                    //        rdpComparativeNonUnitSellingDate.SelectedDate = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingDate"));
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitRadius")))
                    //    {
                    //        rtbComparativeNonUnitRadius.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitRadius"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitRadius.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitWidthStreet")))
                    //    {
                    //        rtbComparativeNonUnitWidthStreet.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitWidthStreet"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitWidthStreet.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitLandArea")))
                    //    {
                    //        rtbComparativeNonUnitLandArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitLandArea"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitLandArea.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitBuildingArea")))
                    //    {
                    //        rtbComparativeNonUnitBuildingArea.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitBuildingArea"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitBuildingArea.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceHomeCurrency")))
                    //    {
                    //        rtbComparativeNonUnitSellingPriceHomeCurrency.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceHomeCurrency"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitSellingPriceHomeCurrency.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDiscountRecommended")))
                    //    {
                    //        rtbComparativeNonUnitDiscountRecommended.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDiscountRecommended"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitDiscountRecommended.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitRadius")))
                    //    {
                    //        rtbComparativeNonUnitRadius.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitRadius"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitRadius.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitFurnishPrice")))
                    //    {
                    //        rtbComparativeNonUnitFurnishPrice.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitFurnishPrice"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitFurnishPrice.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitNewBuildingPrice")))
                    //    {
                    //        rtbComparativeNonUnitNewBuildingPrice.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitNewBuildingPrice"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitNewBuildingPrice.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitFurnishPrice")))
                    //    {
                    //        rtbComparativeNonUnitFurnishPrice.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitFurnishPrice"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitFurnishPrice.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataPercentage")))
                    //    {
                    //        rtbComparativeNonUnitDataPercentage.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataPercentage"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitDataPercentage.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceDiscount")))
                    //    {
                    //        rtbComparativeNonUnitSellingPriceDiscount.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceDiscount"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitSellingPriceDiscount.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDepreciation")))
                    //    {
                    //        rtbComparativeNonUnitDepreciation.Value = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDepreciation"));
                    //    }
                    //    else
                    //    {
                    //        rtbComparativeNonUnitDepreciation.Value = 0;
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataStatus")))
                    //    {
                    //        ddlComparativeNonUnitDataStatus.SelectedValue = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataStatus"));
                    //    }

                    //    if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataSource")))
                    //    {
                    //        ddlComparativeNonUnitDataSource.SelectedValue = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataStatus"));
                    //    }

                    //    rtbIndicationPrice.Value = (rtbComparativeNonUnitSellingPriceHomeCurrency.Value.Value * (100 - rtbComparativeNonUnitSellingPriceDiscount.Value.Value) / 100) / 100 - rtbComparativeNonUnitFurnishPrice.Value.Value;

                    //    rtbIndicationLandPriceCalc.Value = (rtbIndicationPrice.Value.Value - (rtbComparativeNonUnitBuildingArea.Value.Value * rtbComparativeNonUnitNewBuildingPrice.Value.Value * (100 - rtbComparativeNonUnitDepreciation.Value.Value) / 100) / rtbComparativeNonUnitLandArea.Value.Value);

                    //    rtbPredictionLandValueCalc.Value = rtbIndicationLandPriceCalc.Value.Value * rtbComparativeNonUnitDataPercentage.Value.Value / 100;
                    //}
                }

                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    //double dComparativeNonUnitSellingPriceHomeCurrency = 0;
                    //double dComparativeNonUnitSellingPriceDiscount = 0;
                    //double dComparativeNonUnitFurnishPrice = 0;
                    //double dIndicationLandPriceCalc = 0;
                    //double dComparativeNonUnitBuildingArea = 0;
                    //double dComparativeNonUnitNewBuildingPrice = 0;
                    //double dComparativeNonUnitDepreciation = 0;
                    //double dComparativeNonUnitLandArea = 0;
                    //double dPredictionLandValueCalc = 0;
                    //double dComparativeNonUnitDataPercentage = 0;
                    //double dIndicationPriceCalc = 0;

                    //Label lblIndicationLandPriceCalc = ((Label)e.Item.FindControl("lblIndicationLandPriceCalc"));
                    //Label lblPredictionLandValueCalc = ((Label)e.Item.FindControl("lblPredictionLandValueCalc"));
                    //Label lblIndicationPriceCalc = ((Label)e.Item.FindControl("lblIndicationPriceCalc"));

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceHomeCurrency")))
                    //{
                    //    dComparativeNonUnitSellingPriceHomeCurrency = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceHomeCurrency"));
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceDiscount")))
                    //{
                    //    dComparativeNonUnitSellingPriceDiscount = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitSellingPriceDiscount"));
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitFurnishPrice")))
                    //{
                    //    dComparativeNonUnitFurnishPrice = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitFurnishPrice"));
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitBuildingArea")))
                    //{
                    //    dComparativeNonUnitBuildingArea = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitBuildingArea"));
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitNewBuildingPrice")))
                    //{
                    //    dComparativeNonUnitNewBuildingPrice = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitNewBuildingPrice"));
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDepreciation")))
                    //{
                    //    dComparativeNonUnitDepreciation = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDepreciation"));
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitLandArea")))
                    //{
                    //    dComparativeNonUnitLandArea = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitLandArea"));
                    //}

                    //if (PFSCommon.IsNumeric(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataPercentage")))
                    //{
                    //    dComparativeNonUnitDataPercentage = Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "ComparativeNonUnitDataPercentage"));
                    //}

                    //dIndicationPriceCalc = (dComparativeNonUnitSellingPriceHomeCurrency * (100 - dComparativeNonUnitSellingPriceDiscount) / 100) / 100 - dComparativeNonUnitFurnishPrice;

                    //lblIndicationPriceCalc.Text = PFSCommon.FormatNumber(dIndicationPriceCalc);

                    //dIndicationLandPriceCalc = (dIndicationLandPriceCalc - (dComparativeNonUnitBuildingArea * dComparativeNonUnitNewBuildingPrice * (100 - dComparativeNonUnitDepreciation) / 100) / dComparativeNonUnitLandArea);
                    //lblIndicationLandPriceCalc.Text = PFSCommon.FormatNumber(dIndicationLandPriceCalc);

                    //dPredictionLandValueCalc = dIndicationLandPriceCalc * dComparativeNonUnitDataPercentage / 100;

                    //lblPredictionLandValueCalc.Text = PFSCommon.FormatNumber(dPredictionLandValueCalc);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgMarketComparative_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid Opinion
        protected void rgOpinion_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }
                List<LpaDescriptionService> oLpaDescriptionServices = sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices;
                rgOpinion.DataSource = oLpaDescriptionServices;
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgOpinion_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.CommandName == "PerformInsert")
                {
                    LpaDescriptionService oLpaDescriptionService = new LpaDescriptionService();
                    oLpaDescriptionService.LpaDescriptionId = vsLpaNonUnitBuildingNegativeId = vsLpaNonUnitBuildingNegativeId - 1;
                    oLpaDescriptionService.LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();
                    oLpaDescriptionService.LpaDescriptionTypeId = (int)ProTaksatur.WebUI.App_Code.Enumeration.LpaDescriptionType.Opinion;
                    oLpaDescriptionService.RefId = sessLpa.CollateralCategory;

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices.Add(oLpaDescriptionService);

                    rgOpinion.Rebind();
                    btAddNewOpinion.Visible = true;
                }
                else if (e.CommandName == "Update")
                {
                    int iOpinionIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices[i].LpaDescriptionId)
                        {
                            iOpinionIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices[iOpinionIndex].LpaDesc = ((TextBox)e.Item.FindControl("tbLpaDesc")).Text.Trim();

                    rgOpinion.Rebind();
                    btAddNewOpinion.Visible = true;
                }
                else if (e.CommandName == "Delete")
                {
                    int iOpinionIndex = 0;

                    for (int i = 0; i < sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices.Count; i++)
                    {
                        if (Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["LpaDescriptionId"]) == sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices[i].LpaDescriptionId)
                        {
                            iOpinionIndex = i;
                            break;
                        }
                    }

                    sessLpa.LpaNonUnitServices[0].LpaNonUnitOpinionServices.RemoveAt(iOpinionIndex);
                    rgOpinion.Rebind();
                }
                else if (e.CommandName == "Edit")
                {
                    btAddNewOpinion.Visible = false;
                }
                else if (e.CommandName == "Cancel")
                {
                    rgOpinion.Rebind();
                    btAddNewOpinion.Visible = true;
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                e.Canceled = true;

                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgOpinion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (e.Item.ItemType == GridItemType.EditItem)
                {
                }
                if (e.Item.ItemType == GridItemType.Item
                    || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    ImageButton ibtEdit = (ImageButton)e.Item.FindControl("ibtEdit");
                    ImageButton ibtDelete = (ImageButton)e.Item.FindControl("ibtDelete");

                    if (qsActionType == "View")
                    {
                        ibtEdit.Visible = false;
                        ibtDelete.Visible = false;
                    }

                    ibtDelete.OnClientClick = String.Format("return confirm('{0}');", PFSMessage.General.CONFIRM_DELETE_SELECTED);

                    //ibtEdit.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_EDIT.ToString());
                    //ibtDelete.Visible = Security.CheckSecurity(SCA.BusinessLogicLayer.ProTaksatur.WebUI.App_Code.Enumeration.SCAProTaksatur.WebUI.App_Code.Enumeration.PFSModuleObjectMember.PRODUCT_DELETE.ToString());
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }
        #endregion

        #region Grid Non Unit Land

        protected void rgNonUnitLand_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }

                rgNonUnitLand.DataSource = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices;

                lblValueLandArea.Text = "";
                lblValueLandPrice.Text = "";
                lblLandAdjusment.Text = "";
                lblValueLandPriceCalc.Text = "";
                lblAdjusmentCalc.Text = "";
                lblTotalValueLandCalc.Text = "";
                lblLandDescirption.Text = "";

                CalculateTotalMarketPrice();

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgNonUnitLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (rgNonUnitLand.SelectedItems.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForLand.SelectedValue);
                    int iNonUnitLandId = (int)rgNonUnitLand.SelectedValues["LpaNonUnitLandId"];
                    LpaNonUnitLandService oLpaNonUnitLandService = sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices
                        .Where(o => o.LpaNonUnitLandId == iNonUnitLandId).FirstOrDefault();

                    lblLandDescirption.Text = oLpaNonUnitLandService.LandDescription;
                    LpaNonUnitValueLandService oLpaNonUnitValueLandService = oLpaNonUnitLandService.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueLandService != null)
                    {
                        lblValueLandArea.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandArea);
                        lblValueLandPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandPrice);
                        lblLandAdjusment.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.LandAdjustment);
                        lblValueLandPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);
                        lblAdjusmentCalc.Text = PFSCommon.FormatNumber(((oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice));
                        lblTotalValueLandCalc.Text = PFSCommon.FormatNumber((oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice) - (oLpaNonUnitValueLandService.LandAdjustment / 100) * oLpaNonUnitValueLandService.ValueLandArea * oLpaNonUnitValueLandService.ValueLandPrice);
                    }
                    else
                    {
                        lblValueLandArea.Text = "";
                        lblValueLandPrice.Text = "";
                        lblLandAdjusment.Text = "";
                        lblValueLandPriceCalc.Text = "";
                        lblAdjusmentCalc.Text = "";
                        lblTotalValueLandCalc.Text = "";
                    }
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        #region Grid Non Unit Building

        protected void rgNonUnitBuilding_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }

                rgNonUnitBuilding.DataSource = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices;

                lblBuildingArea.Text = "";
                lblBuildingPrice.Text = "";
                lblBuildingProgress.Text = "";
                lblBuildingDepreciation.Text = "";
                lblRepairCost.Text = "";
                lblEconomicAsumption.Text = "";
                lblTotalPriceCalc.Text = "";
                lblBuildingProgressCalc.Text = "";
                lblBuildingDepreciationCalc.Text = "";
                lblRepairCostCalc.Text = "";
                lblEconomicAsumptionCalc.Text = "";
                lblTotalSummaryCalc.Text = "";
                lblBuildingDescription.Text = "";
                lblBuildingValue.Text = "";

                CalculateTotalMarketPrice();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgNonUnitBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }

                if (rgNonUnitBuilding.SelectedItems.Count > 0)
                {
                    int iNonUnitBuildingId = (int)rgNonUnitBuilding.SelectedValues["LpaNonUnitBuildingId"];
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForBuilding.SelectedValue);

                    LpaNonUnitBuildingService oLpaNonUnitBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices
                        .Where(o => o.LpaNonUnitBuildingId == iNonUnitBuildingId).FirstOrDefault();

                    lblBuildingDescription.Text = oLpaNonUnitBuildingService.BuildingDescription;
                    LpaNonUnitValueBuildingService oLpaNonUnitValueBuildingService = oLpaNonUnitBuildingService.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueBuildingService != null)
                    {
                        lblBuildingArea.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea);
                        lblBuildingPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingPrice);
                        lblBuildingProgress.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingProgress);
                        lblBuildingDepreciation.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingDepreciation);
                        lblRepairCost.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.RepairCost);
                        lblEconomicAsumption.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.EconomicAsumption);
                        lblTotalPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea * oLpaNonUnitValueBuildingService.BuildingPrice);
                        lblBuildingProgressCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingProgress / 100 * Convert.ToDouble(lblTotalPriceCalc.Text, new CultureInfo("id-ID")));
                        lblBuildingDepreciationCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingDepreciation / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        lblRepairCostCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.RepairCost / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        lblEconomicAsumptionCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) / 100 * oLpaNonUnitValueBuildingService.EconomicAsumption);
                        lblTotalSummaryCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingDepreciationCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblEconomicAsumptionCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblRepairCostCalc.Text, new CultureInfo("id-ID")));
                        lblBuildingValue.Text = PFSCommon.FormatNumber((Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) - Convert.ToDouble(lblTotalSummaryCalc.Text, new CultureInfo("id-ID"))));

                        //lblTotalPriceCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingArea * oLpaNonUnitValueBuildingService.BuildingPrice);
                        //lblBuildingProgressCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingProgress / 100 * Convert.ToDouble(lblTotalPriceCalc.Text, new CultureInfo("id-ID")));
                        //lblBuildingDepreciationCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.BuildingDepreciation / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        //lblRepairCostCalc.Text = PFSCommon.FormatNumber(oLpaNonUnitValueBuildingService.RepairCost / 100 * Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")));
                        //lblEconomicAsumptionCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) / 100 * oLpaNonUnitValueBuildingService.EconomicAsumption);
                        //lblTotalSummaryCalc.Text = PFSCommon.FormatNumber(Convert.ToDouble(lblBuildingDepreciationCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblEconomicAsumptionCalc.Text, new CultureInfo("id-ID")) + Convert.ToDouble(lblRepairCostCalc.Text, new CultureInfo("id-ID")));
                        //lblBuildingValue.Text = PFSCommon.FormatNumber((Convert.ToDouble(lblBuildingProgressCalc.Text, new CultureInfo("id-ID")) - Convert.ToDouble(lblTotalSummaryCalc.Text, new CultureInfo("id-ID"))));
                    }
                    else
                    {
                        lblBuildingArea.Text = "";
                        lblBuildingPrice.Text = "";
                        lblBuildingProgress.Text = "";
                        lblBuildingDepreciation.Text = "";
                        lblRepairCost.Text = "";
                        lblEconomicAsumption.Text = "";
                        lblTotalPriceCalc.Text = "";
                        lblBuildingProgressCalc.Text = "";
                        lblBuildingDepreciationCalc.Text = "";
                        lblRepairCostCalc.Text = "";
                        lblEconomicAsumptionCalc.Text = "";
                        lblTotalSummaryCalc.Text = "";
                        lblBuildingValue.Text = "";
                    }
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        #region Grid Non Unit Facility

        protected void rgNonUnitFacility_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }

                rgNonUnitFacility.DataSource = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices;

                lblFacilityMeasurement.Text = "";
                lblFacilityUnitOfMeasure.Text = "";
                lblFacilityAmountHomeCurrency.Text = "";
                lblValueFacility.Text = "";
                lblFacilityDescription.Text = "";

                CalculateTotalMarketPrice();

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void rgNonUnitFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (sessLpa == null)
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm");
                }

                if (sessLpa.LpaNonUnitServices.Count == 0)
                {
                    return;
                }

                if (rgNonUnitFacility.SelectedItems.Count > 0)
                {
                    int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationTypeForFacility.SelectedValue);
                    int iNonUnitFacilityId = (int)rgNonUnitFacility.SelectedValues["LpaNonUnitFacilityId"];

                    LpaNonUnitFacilityService oLpaNonUnitFacilityService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices
                        .Where(o => o.LpaNonUnitFacilityId == iNonUnitFacilityId).FirstOrDefault();
                    lblFacilityDescription.Text = oLpaNonUnitFacilityService.FacilityDescription;

                    LpaNonUnitValueFacilityService oLpaNonUnitValueFacilityService = oLpaNonUnitFacilityService.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();

                    if (oLpaNonUnitValueFacilityService != null)
                    {
                        lblFacilityMeasurement.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement);
                        lblFacilityUnitOfMeasure.Text = oLpaNonUnitValueFacilityService.FacilityUnitOfMeasure;
                        lblFacilityAmountHomeCurrency.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);
                        lblValueFacility.Text = PFSCommon.FormatNumber(oLpaNonUnitValueFacilityService.FacilityMeasurement * oLpaNonUnitValueFacilityService.FacilityAmountHomeCurrency);
                    }
                    else
                    {
                        lblFacilityMeasurement.Text = "";
                        lblFacilityUnitOfMeasure.Text = "";
                        lblFacilityAmountHomeCurrency.Text = "";
                        lblValueFacility.Text = "";
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        #endregion

        #endregion

        #region Methods
        private void Bind_ddlCollateralType()
        {
            try
            {
                try
                {
                    List<SetupCollateralTypeService> oSetupCollateralTypeServices = new List<SetupCollateralTypeService>();
                    SetupCollateralTypeServiceClient oSetupCollateralTypeServiceClient = new SetupCollateralTypeServiceClient();
                    oSetupCollateralTypeServiceClient.SetupCollateralTypeList(sessNISPWebLogin.UserName, null, sessLpa.CollateralCategory,
                        null, null, null, null, null, null, null, null, out oSetupCollateralTypeServices);

                    oSetupCollateralTypeServiceClient.Close();
                    ddlCollateralType.DataSource = oSetupCollateralTypeServices;
                    ddlCollateralType.DataTextField = "SetupCollateralTypeName";
                    ddlCollateralType.DataValueField = "SetupCollateralTypeId";
                    ddlCollateralType.DataBind();
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }

        }

        private void Bind_ddlDocumentCalculationType()
        {
            try
            {
                try
                {
                    List<SetupDocumentCalculationTypeService> oSetupDocumentCalculationTypeServices = new List<SetupDocumentCalculationTypeService>();
                    SetupDocumentCalculationTypeServiceClient oSetupDocumentCalculationTypeServiceClient = new SetupDocumentCalculationTypeServiceClient();
                    oSetupDocumentCalculationTypeServiceClient.SetupDocumentCalculationTypeList(sessNISPWebLogin.UserName, null, null,
                        sessLpa.CollateralCategory, null, null, null, null, null, null, out oSetupDocumentCalculationTypeServices);
                    oSetupDocumentCalculationTypeServiceClient.Close();

                    for (int i = 0; i < oSetupDocumentCalculationTypeServices.Count; i++)
                    {
                        ddlDocumentCalculationType.Items.Add(new ListItem(oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeName,
                            oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeId.ToString()));
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        private void Bind_ddlLpaOrderType()
        {
            try
            {
                List<DocumentLpaTypeService> oDocumentLpaTypeList = new List<DocumentLpaTypeService>();
                DocumentLpaTypeServiceClient oDocumentLpaTypeServiceClient = new DocumentLpaTypeServiceClient();
                oDocumentLpaTypeServiceClient.DocumentLpaTypeList(sessNISPWebLogin.UserName, null, null, null, null, null, null, null, null,
                    out oDocumentLpaTypeList);
                oDocumentLpaTypeServiceClient.Close();
                oDocumentLpaTypeServiceClient = null;
                ddlLpaType.DataSource = oDocumentLpaTypeList;
                ddlLpaType.DataTextField = "LpaTypeDescription";
                ddlLpaType.DataValueField = "DocumentLpaTypeId";
                ddlLpaType.DataBind();
            }
            catch (System.ServiceModel.FaultException fe)
            {
                if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm", true);
                }
                else
                {
                    throw fe;
                }
            }
        }

        private void Bind_ddlCompletionBuilidngByInspection()
        {
            List<SetupCompletionBuildingService> oSetupCompletionBuildingServiceList = new List<SetupCompletionBuildingService>();
            SetupCompletionBuildingServiceClient oSetupCompletionBuildingServiceClient = new SetupCompletionBuildingServiceClient();

            if (oSetupCompletionBuildingServiceClient.SetupCompletionBuildingList(
                sessNISPWebLogin.UserName,
                null,
                null,
                out oSetupCompletionBuildingServiceList) == 1)
            {
                oSetupCompletionBuildingServiceList.RemoveAt(0);
                ddlCompletionBuilidngByInspection.DataSource = oSetupCompletionBuildingServiceList;
                ddlCompletionBuilidngByInspection.DataTextField = "CompletionBuildingDescription";
                ddlCompletionBuilidngByInspection.DataValueField = "CompletionBuildingId";
                ddlCompletionBuilidngByInspection.DataBind();
            }

            ListItem cbiOne = new ListItem(STRING_SELECT_ONE, "0");
            ddlCompletionBuilidngByInspection.Items.Insert(0, cbiOne);
            ddlCompletionBuilidngByInspection.SelectedValue = "0";

            oSetupCompletionBuildingServiceList = null;
            oSetupCompletionBuildingServiceClient.Close();
            oSetupCompletionBuildingServiceClient = null;
        }

        private void Bind_ddlCompletionBuildingIdByDeveloper()
        {
            List<SetupCompletionBuildingService> oSetupCompletionBuildingServiceList = new List<SetupCompletionBuildingService>();
            SetupCompletionBuildingServiceClient oSetupCompletionBuildingServiceClient = new SetupCompletionBuildingServiceClient();

            if (oSetupCompletionBuildingServiceClient.SetupCompletionBuildingList(
                sessNISPWebLogin.UserName,
                null,
                null,
                out oSetupCompletionBuildingServiceList) == 1)
            {
                oSetupCompletionBuildingServiceList.RemoveAt(0);
                ddlCompletionBuildingIdByDeveloper.DataSource = oSetupCompletionBuildingServiceList;
                ddlCompletionBuildingIdByDeveloper.DataTextField = "CompletionBuildingDescription";
                ddlCompletionBuildingIdByDeveloper.DataValueField = "CompletionBuildingId";
                ddlCompletionBuildingIdByDeveloper.DataBind();
            }

            ListItem cbiOne = new ListItem(STRING_SELECT_ONE, "0");
            ddlCompletionBuildingIdByDeveloper.Items.Insert(0, cbiOne);
            ddlCompletionBuildingIdByDeveloper.SelectedValue = "0";

            oSetupCompletionBuildingServiceList = null;
            oSetupCompletionBuildingServiceClient.Close();
            oSetupCompletionBuildingServiceClient = null;
        }

        private void Bind_ddlPhaseConstruction()
        {
            List<SetupPhaseConstructionService> oSetupPhaseConstructionServiceList = new List<SetupPhaseConstructionService>();
            SetupPhaseConstructionServiceClient oSetupPhaseConstructionServiceClient = new SetupPhaseConstructionServiceClient();

            if (oSetupPhaseConstructionServiceClient.SetupPhaseConstructionList(
                sessNISPWebLogin.UserName,
                null,
                null,
                out oSetupPhaseConstructionServiceList) == 1)
            {
                oSetupPhaseConstructionServiceList.RemoveAt(0);
                ddlPhaseConstruction.DataSource = oSetupPhaseConstructionServiceList;
                ddlPhaseConstruction.DataTextField = "PhaseConstructionDescription";
                ddlPhaseConstruction.DataValueField = "SetupPhaseConstructionId";
                ddlPhaseConstruction.DataBind();
            }

            ListItem cbiOne = new ListItem(STRING_SELECT_ONE, "0");
            ddlPhaseConstruction.Items.Insert(0, cbiOne);
            ddlPhaseConstruction.SelectedValue = "0";

            oSetupPhaseConstructionServiceList = null;
            oSetupPhaseConstructionServiceClient.Close();
            oSetupPhaseConstructionServiceClient = null;
        }

        private void CalculateByDocumentTypeID()
        {
            vsDocumentCalculationID = Convert.ToInt32(ddlDocumentCalculationType.SelectedValue);

            LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService = null;
            oLpaNonUnitTotalMarketPriceService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices
                .Where(o => o.DocumentCalculationId == vsDocumentCalculationID).FirstOrDefault();

            if (oLpaNonUnitTotalMarketPriceService == null)
            {
                oLpaNonUnitTotalMarketPriceService = new LpaNonUnitTotalMarketPriceService();
                oLpaNonUnitTotalMarketPriceService.LpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId - 1;
                oLpaNonUnitTotalMarketPriceService.DocumentCalculationId = vsDocumentCalculationID;
                sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices.Add(oLpaNonUnitTotalMarketPriceService);
            }

            //oLpaNonUnitTotalMarketPriceService.TotalMarketPrice = (
            //    sessLpa.LpaNonUnitServices[0].LpaNonUnitValueLandServices
            //        .Where(o => o.DocumentCalculationId == vsDocumentCalculationID)
            //        .Sum(o => ((100 - o.LandAdjustment) / 100 * (o.ValueLandArea * o.ValueLandPrice))) +
            //    sessLpa.LpaNonUnitServices[0].LpaNonUnitValueBuildingServices
            //        .Where(o => o.DocumentCalculationId == vsDocumentCalculationID)
            //        .Sum(o => (o.BuildingPrice * o.BuildingArea - ((o.EconomicAsumption / 100 * o.BuildingPrice * o.BuildingArea) + (o.RepairCost / 100 * o.BuildingPrice * o.BuildingArea) + (o.BuildingDepreciation / 100 * o.BuildingPrice * o.BuildingArea)))) +
            //    sessLpa.LpaNonUnitServices[0].LpaNonUnitValueFacilityServices
            //        .Where(o => o.DocumentCalculationId == vsDocumentCalculationID)
            //        .Sum(o => o.FacilityMeasurement * o.FacilityAmountHomeCurrency)
            //);

            oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = rtbLiquidationFactor.Value == null ? 0 : rtbLiquidationFactor.Value.Value;
            oLpaNonUnitTotalMarketPriceService.LiquidationAmount = oLpaNonUnitTotalMarketPriceService.TotalMarketPrice
            * (100 - oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage) / 100;

            tbMarketValueCalculation.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.TotalMarketPrice);
            tbLiquidationValue.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationAmount);

            //rgValueLand.Rebind();
            //rgValueBuilding.Rebind();
            //rgValueFacility.Rebind();
        }

        protected void CalculateTotalMarketPrice()
        {
            int iDocumentCalculationId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);
            LpaNonUnitTotalMarketPriceService oLpaNonUnitTotalMarketPriceService = null;
            if (sessLpa.LpaNonUnitServices != null)
            {
                oLpaNonUnitTotalMarketPriceService = sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices
                    .Where(o => o.DocumentCalculationId == iDocumentCalculationId).FirstOrDefault();
            }

            if (oLpaNonUnitTotalMarketPriceService == null)
            {
                oLpaNonUnitTotalMarketPriceService = new LpaNonUnitTotalMarketPriceService();
                oLpaNonUnitTotalMarketPriceService.LpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId = vsLpaNonUnitTotalMarketPriceId - 1;
                oLpaNonUnitTotalMarketPriceService.DocumentCalculationId = iDocumentCalculationId;
                oLpaNonUnitTotalMarketPriceService.LiquidationAmount = 0;
                oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage = 0;
                if (sessLpa.LpaNonUnitServices != null)
                {
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitTotalMarketPriceServices.Add(oLpaNonUnitTotalMarketPriceService);
                }
            }
            if (sessLpa.LpaNonUnitServices != null)
            {
                oLpaNonUnitTotalMarketPriceService.TotalMarketPrice = (
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitLandServices.Sum(n => n.LpaNonUnitValueLandServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => ((100 - o.LandAdjustment) / 100 * (o.ValueLandArea * o.ValueLandPrice)))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitBuildingServices.Sum(n => n.LpaNonUnitValueBuildingServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => (((o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea) - ((o.EconomicAsumption / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.RepairCost / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea)) + (o.BuildingDepreciation / 100 * (o.BuildingProgress / 100 * o.BuildingPrice * o.BuildingArea))))))) +
                    sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityServices.Sum(n => n.LpaNonUnitValueFacilityServices
                        .Where(o => o.DocumentCalculationId == iDocumentCalculationId)
                        .Sum(o => o.FacilityMeasurement * o.FacilityAmountHomeCurrency))
                );
            }

            oLpaNonUnitTotalMarketPriceService.LiquidationAmount = (100 - oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage) / 100 * oLpaNonUnitTotalMarketPriceService.TotalMarketPrice;

            lblTotalMarketPrice.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.TotalMarketPrice);
            lblLiquidationAmount.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationAmount);
            lblLiquidationValuePercentage.Text = PFSCommon.FormatNumber(oLpaNonUnitTotalMarketPriceService.LiquidationValuePercentage);

        }

        protected void Bind_ddlStatusDataDescription()
        {
            try
            {
                List<StatusDataService> oStatusDataServiceList = new List<StatusDataService>();
                StatusDataServiceClient oStatusDataServiceClient = new StatusDataServiceClient();

                if (oStatusDataServiceClient.StatusDataList(
                    sessNISPWebLogin.UserName,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    out oStatusDataServiceList) == 1)
                {
                    ddlComparativeNonUnitDataStatus.DataSource = oStatusDataServiceList;
                    ddlComparativeNonUnitDataStatus.DataValueField = "StatusDataId";
                    ddlComparativeNonUnitDataStatus.DataTextField = "StatusDataDescription";
                    ddlComparativeNonUnitDataStatus.DataBind();

                    ListItem cbiOne = new ListItem(STRING_SELECT_ONE, "0");
                    ddlComparativeNonUnitDataStatus.Items.Insert(0, cbiOne);
                    ddlComparativeNonUnitDataStatus.SelectedValue = "0";
                }

                oStatusDataServiceClient.Close();
                oStatusDataServiceClient = null;
            }
            catch (System.ServiceModel.FaultException fe)
            {
                if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm", true);
                }
                else
                {
                    throw fe;
                }
            }
        }

        protected void Bind_ddlSourceDataDescription()
        {
            try
            {
                List<SourceDataService> oSourceDataServiceList = new List<SourceDataService>();
                SourceDataServiceClient oSourceDataServiceClient = new SourceDataServiceClient();

                if (oSourceDataServiceClient.SourceDataList(
                    sessNISPWebLogin.UserName,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    out oSourceDataServiceList) == 1)
                {
                    ddlComparativeNonUnitDataSource.DataSource = oSourceDataServiceList;
                    ddlComparativeNonUnitDataSource.DataValueField = "SourceDataId";
                    ddlComparativeNonUnitDataSource.DataTextField = "SourceDataDescription";
                    ddlComparativeNonUnitDataSource.DataBind();


                    ListItem cbiOne = new ListItem(STRING_SELECT_ONE, "0");
                    ddlComparativeNonUnitDataSource.Items.Insert(0, cbiOne);
                    ddlComparativeNonUnitDataSource.SelectedValue = "0";
                }
                oSourceDataServiceClient.Close();
                oSourceDataServiceClient = null;
            }
            catch (System.ServiceModel.FaultException fe)
            {
                if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                {
                    Response.Redirect("~/Error/SessionTimeOut.htm", true);
                }
                else
                {
                    throw fe;
                }
            }
        }

        protected bool ValidateGridContactForRequiredField(LpaService oLpaService)
        {
            bool bIsValid = true;
            string sGridNameForMessage = " Grid Contact Person";
            Int32 iIndex = 0;
            foreach (LpaNonUnitService oLpaNonUnitServices in oLpaService.LpaNonUnitServices)
            {
                foreach (LpaContactService oItem in oLpaNonUnitServices.LpaNonUnitContactServices)
                {
                    if (CheckObjectIsDefaultData(oItem.LpaContactName, iIndex, "Nama Contact Person", sGridNameForMessage, 1))
                    {
                        bIsValid = false;
                        break;
                    }
                    else if (CheckObjectIsDefaultData(oItem.LpaContactPhoneNo, iIndex, "Contact Telephone", sGridNameForMessage, 1))
                    {
                        bIsValid = false;
                        break;
                    }
                    else if (CheckObjectIsDefaultData(oItem.LpaContactMobileNo, iIndex, "Contact Phone", sGridNameForMessage, 1))
                    {
                        bIsValid = false;
                        break;
                    }
                }
            }


            return bIsValid;
        }

        protected bool ValidateGridMarketCompartiveForRequiredField(LpaService oLpaService)
        {
            bool bIsValid = true;
            string sGridNameForMessage = " Grid Market Comparative";

            Int32 iIndex = 0;

            foreach (LpaComparativeNonunitService oItem in oLpaService.LpaComparativeNonunitServices)
            {

                //if (CheckObjectIsDefaultData(oItem.StatusDataDescription, iIndex, " Status Data", sGridNameForMessage, 1))
                //{
                //    bIsValid = false;
                //    break;
                //}

                //else if (CheckObjectIsDefaultData(oItem.SourceDataDescription, iIndex, " Sumber Data", sGridNameForMessage, 1))
                //{
                //    bIsValid = false;
                //    break;
                //}
                //else 
                if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitSellingDate, iIndex, " Selling Date", sGridNameForMessage, 3))
                {
                    bIsValid = false;
                    break;
                }
                else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitDataStatus, iIndex, " Pilihan Data Status", sGridNameForMessage, 1))
                {
                    bIsValid = false;
                    break;
                }
                else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitDataSource, iIndex, " Pilihan Data Source", sGridNameForMessage, 1))
                {
                    bIsValid = false;
                    break;
                }
                else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitAddress1, iIndex, " Alamat 1", sGridNameForMessage, 1))
                {
                    bIsValid = false;
                    break;
                }
                //else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitRadius, iIndex, " Radius dari Agunan(m)", sGridNameForMessage, 2))
                //{
                //    bIsValid = false;
                //    break;
                //}


                else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitWidthStreet, iIndex, " Lebar Jalan(m) ", sGridNameForMessage, 2))
                {
                    bIsValid = false;
                    break;
                }
                //else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitNewBuildingPrice, iIndex, " Harga Bangun Baru/m2", sGridNameForMessage, 2))
                //{
                //    bIsValid = false;
                //    break;
                //}

                else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitAmount, iIndex, " Harga Penawaran", sGridNameForMessage, 2))
                {
                    bIsValid = false;
                    break;
                }
                //else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitSellingPriceDiscount, iIndex, " Discount(%)", sGridNameForMessage, 2))
                //{
                //    bIsValid = false;
                //    break;
                //}

                else if (CheckObjectIsDefaultData(oItem.ComparativeNonUnitDataPercentage, iIndex, " Bobot Data(%)", sGridNameForMessage, 2))
                {
                    bIsValid = false;
                    break;
                }


                iIndex++;
            }

            return bIsValid;
        }

        protected bool ValidateGridDataSertificateForRequeiredField(LpaService oLpaService)
        {
            bool bIsValid = true;
            string sGridNameForMessage = " Grid Data Sertifikat";

            Int32 iIndex = 0;

            foreach (LpaNonUnitCertificateService oLpaNonUnitCertificateService in oLpaService.LpaNonUnitServices[0].LpaNonUnitCertificateServices)
            {
                if (CheckObjectIsDefaultData(oLpaNonUnitCertificateService.CertificateName, iIndex, " Jenis Dokumen", sGridNameForMessage, 1))
                {
                    bIsValid = false;
                    break;
                }
                else if (CheckObjectIsDefaultData(oLpaNonUnitCertificateService.CertificateNo, iIndex, " Nomor Sertifikat", sGridNameForMessage, 1))
                {
                    bIsValid = false;
                    break;
                }
                else if (CheckObjectIsDefaultData(oLpaNonUnitCertificateService.CertificateDate, iIndex, " Tanggal Terbit Sertifikat", sGridNameForMessage, 3))
                {
                    bIsValid = false;
                    break;
                }
                else if (CheckObjectIsDefaultData(oLpaNonUnitCertificateService.CertificateAddress1, iIndex, " Alamat 1", sGridNameForMessage, 1))
                {
                    bIsValid = false;
                    break;
                }

                iIndex++;
            }

            return bIsValid;
        }

        protected bool CheckObjectIsDefaultData(object oValueData, int iIndex, string sControlNameForMessage, string sGridNameFormessage, Int32 iTargetType)
        {
            bool bIsDefaultData = false;

            if (iTargetType == 1)
            {
                if (Convert.ToString(oValueData) == "" || Convert.ToString(oValueData) == "-")
                {
                    bIsDefaultData = true;
                    Alert(sGridNameFormessage + " " + sControlNameForMessage + " harus diisi");
                }
            }
            else if (iTargetType == 2)
            {
                if (Convert.ToDouble(oValueData) <= 0)
                {
                    bIsDefaultData = true;
                    Alert(sGridNameFormessage + " " + sControlNameForMessage + " harus diisi");
                }
            }
            else if (iTargetType == 3)
            {
                if (Convert.ToDateTime(oValueData) == new DateTime(1900, 1, 1))
                {
                    bIsDefaultData = true;
                    Alert(sGridNameFormessage + " " + sControlNameForMessage + " harus diisi");
                }
            }

            return bIsDefaultData;
        }

        protected void Bind_ddlDocumentCalculationTypeForLand()
        {
            try
            {
                try
                {
                    List<SetupDocumentCalculationTypeService> oSetupDocumentCalculationTypeServices = new List<SetupDocumentCalculationTypeService>();
                    SetupDocumentCalculationTypeServiceClient oSetupDocumentCalculationTypeServiceClient = new SetupDocumentCalculationTypeServiceClient();
                    oSetupDocumentCalculationTypeServiceClient.SetupDocumentCalculationTypeList(sessNISPWebLogin.UserName, null, null,
                        sessLpa.CollateralCategory, null, null, null, null, null, null, out oSetupDocumentCalculationTypeServices);
                    oSetupDocumentCalculationTypeServiceClient.Close();

                    for (int i = 0; i < oSetupDocumentCalculationTypeServices.Count; i++)
                    {
                        ddlDocumentCalculationTypeForLand.Items.Add(new ListItem(oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeName,
                            oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeId.ToString()));
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void Bind_ddlDocumentCalculationTypeForBuilding()
        {
            try
            {
                try
                {
                    List<SetupDocumentCalculationTypeService> oSetupDocumentCalculationTypeServices = new List<SetupDocumentCalculationTypeService>();
                    SetupDocumentCalculationTypeServiceClient oSetupDocumentCalculationTypeServiceClient = new SetupDocumentCalculationTypeServiceClient();
                    oSetupDocumentCalculationTypeServiceClient.SetupDocumentCalculationTypeList(sessNISPWebLogin.UserName, null, null,
                        sessLpa.CollateralCategory, null, null, null, null, null, null, out oSetupDocumentCalculationTypeServices);
                    oSetupDocumentCalculationTypeServiceClient.Close();

                    for (int i = 0; i < oSetupDocumentCalculationTypeServices.Count; i++)
                    {
                        ddlDocumentCalculationTypeForBuilding.Items.Add(new ListItem(oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeName,
                            oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeId.ToString()));
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void Bind_ddlDocumentCalculationTypeForFacility()
        {
            try
            {
                try
                {
                    List<SetupDocumentCalculationTypeService> oSetupDocumentCalculationTypeServices = new List<SetupDocumentCalculationTypeService>();
                    SetupDocumentCalculationTypeServiceClient oSetupDocumentCalculationTypeServiceClient = new SetupDocumentCalculationTypeServiceClient();
                    oSetupDocumentCalculationTypeServiceClient.SetupDocumentCalculationTypeList(sessNISPWebLogin.UserName, null, null,
                        sessLpa.CollateralCategory, null, null, null, null, null, null, out oSetupDocumentCalculationTypeServices);
                    oSetupDocumentCalculationTypeServiceClient.Close();

                    for (int i = 0; i < oSetupDocumentCalculationTypeServices.Count; i++)
                    {
                        ddlDocumentCalculationTypeForFacility.Items.Add(new ListItem(oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeName,
                            oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeId.ToString()));
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void Bind_ddlDocumentCalculationForTotalMarketPrice()
        {
            try
            {
                try
                {
                    List<SetupDocumentCalculationTypeService> oSetupDocumentCalculationTypeServices = new List<SetupDocumentCalculationTypeService>();
                    SetupDocumentCalculationTypeServiceClient oSetupDocumentCalculationTypeServiceClient = new SetupDocumentCalculationTypeServiceClient();
                    oSetupDocumentCalculationTypeServiceClient.SetupDocumentCalculationTypeList(sessNISPWebLogin.UserName, null, null,
                        sessLpa.CollateralCategory, null, null, null, null, null, null, out oSetupDocumentCalculationTypeServices);
                    oSetupDocumentCalculationTypeServiceClient.Close();

                    for (int i = 0; i < oSetupDocumentCalculationTypeServices.Count; i++)
                    {
                        ddlDocumentCalculationForTotalMarketPrice.Items.Add(new ListItem(oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeName,
                            oSetupDocumentCalculationTypeServices[i].SetupDocumentCalculationTypeId.ToString()));
                    }
                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void ProcessDraftAndPending(bool p_bIsDraft)
        {
            try
            {
                try
                {
                    if (sessLpa == null)
                        Response.Redirect("~/Error/SessionTimeOut.htm");

                    #region Set Data Spesification Value building

                    foreach (GridItem oGridItem in rgLpaNonUnitFacilityBuilding.MasterTableView.Items)
                    {
                        TextBox tbFacilityDescription = oGridItem.FindControl("tbFacilityDescription") as TextBox;

                        LpaNonUnitFacilityBuildingService oLpaNonUnitFacilityBuildingService = sessLpa.LpaNonUnitServices[0].LpaNonUnitFacilityBuildingServices
                            .Where(o => o.LpaNonUnitFacilityBuildingId == Convert.ToInt32(oGridItem.OwnerTableView.DataKeyValues[oGridItem.ItemIndex]["LpaNonUnitFacilityBuildingId"])).FirstOrDefault();
                        oLpaNonUnitFacilityBuildingService.FacilityDescription = tbFacilityDescription.Text.Trim();
                    }
                    #endregion

                    #region Set Value History Approval Lpa
                    ServicesClient oServicesClient = new ServicesClient();
                    ApprovalServiceClient oApprovalServiceClient = new ApprovalServiceClient();
                    HistoryApprovalLpaServiceClient oHistoryApprovalLpaServiceClient = new HistoryApprovalLpaServiceClient();
                    ApprovalService oApprovalService = new ApprovalService();
                    HistoryApprovalLpaService oHistoryApprovalLpaService = new HistoryApprovalLpaService();
                    HistoryApprovalLpaService oHistoryApprovalLpaPreviousService = new HistoryApprovalLpaService();
                    int iBusinessDays = 0;
                    DateTime dtDocumentReceiveDate = DateTime.Now;

                    oApprovalServiceClient.ApprovalGetByFilters(sessNISPWebLogin.GroupId, false, sessNISPWebLogin.UserName, out oApprovalService);
                    oApprovalServiceClient.Close();

                    if (sessLpa.LpaId > 0)
                    {
                        oHistoryApprovalLpaServiceClient.HistoryApprovalLpaGetPreviousRelated(sessNISPWebLogin.UserName, sessLpa.LpaId,
                            out oHistoryApprovalLpaPreviousService);
                        oHistoryApprovalLpaServiceClient.Close();

                        if (oHistoryApprovalLpaPreviousService.HistoryApprovalLpaId > 0)
                        {
                            dtDocumentReceiveDate = oHistoryApprovalLpaPreviousService.CreateDate;
                            iBusinessDays = oServicesClient.GetTotalWorkingDays(sessNISPWebLogin.UserName, oHistoryApprovalLpaPreviousService.CreateDate, DateTime.Now);
                        }
                    }

                    oHistoryApprovalLpaService.ApprovalLpaEmployeeId = sessNISPWebLogin.NIK;
                    oHistoryApprovalLpaService.ApprovalLpaEmployeeName = sessNISPWebLogin.FullName;
                    oHistoryApprovalLpaService.ApprovalLpaGroupCode = oApprovalService.ApprovalGroupCode;
                    oHistoryApprovalLpaService.ApprovalLpaGroupName = oApprovalService.ApprovalGroupName;
                    oHistoryApprovalLpaService.BussinessDay = iBusinessDays;
                    oHistoryApprovalLpaService.CreateByUserId = oHistoryApprovalLpaService.UpdateByUserId = sessNISPWebLogin.UserName;
                    oHistoryApprovalLpaService.CreateDate = oHistoryApprovalLpaService.UpdateDate = DateTime.Now;
                    oHistoryApprovalLpaService.DocumentLpaReceiveDate = dtDocumentReceiveDate;
                    oHistoryApprovalLpaService.DocumentLpaApprovalDate = oHistoryApprovalLpaService.DocumentLpaReceiveDate = DateTime.Now;
                    oHistoryApprovalLpaService.OrderCollateralDetailId = qsOrderCollateralDetailId;
                    oHistoryApprovalLpaService.StatusDescription = p_bIsDraft ? Enumeration.ApprovalStatus.Draft.ToString() : Enumeration.ApprovalStatus.Pending.ToString();
                    oHistoryApprovalLpaService.StatusId = p_bIsDraft ? (int)Enumeration.ApprovalStatus.Draft : (int)Enumeration.ApprovalStatus.Pending;
                    oHistoryApprovalLpaService.LpaApprovalId = oApprovalService.ApprovalId;

                    #endregion

                    #region Calculate Total Market Price

                    if (ddlDocumentCalculationForTotalMarketPrice.Items.Count > 0)
                    {
                        int iSelectedId = Convert.ToInt32(ddlDocumentCalculationForTotalMarketPrice.SelectedValue);
                        foreach (ListItem oListItem in ddlDocumentCalculationForTotalMarketPrice.Items)
                        {
                            ddlDocumentCalculationForTotalMarketPrice.SelectedValue = oListItem.Value;
                            CalculateTotalMarketPrice();
                        }

                        ddlDocumentCalculationForTotalMarketPrice.SelectedValue = iSelectedId.ToString();
                    }
                    #endregion

                    sessLpa.LpaCode = string.Format("DRAFT/{0:dd/MM/yyyy}/{1}/{2}", DateTime.Now, sessNISPWebLogin.NIK, sessNISPWebLogin.EmployeeName);
                    sessLpa.OrderCollateralDetailId = qsOrderCollateralDetailId;

                    if (qsCollateralCategoryId != 0)
                        sessLpa.CollateralCategory = qsCollateralCategoryId;

                    sessLpa.ApprovalStatusId = p_bIsDraft ? (int)Enumeration.ApprovalStatus.Draft : (int)Enumeration.ApprovalStatus.Pending;
                    sessLpa.ApprovalStatusDescription = p_bIsDraft ? Enumeration.ApprovalStatus.Draft.ToString() : Enumeration.ApprovalStatus.Pending.ToString();
                    sessLpa.RequesterUserCode = sessNISPWebLogin.EmployeeId;
                    sessLpa.RequesterName = sessNISPWebLogin.EmployeeName;
                    sessLpa.CreateEmail = sessNISPWebLogin.EmployeeEmail;

                    LpaServiceClient oLpaServiceClient = new LpaServiceClient();
                    if (sessLpa.LpaId > 0)
                    {
                        sessLpa.UpdateByUserId = sessNISPWebLogin.UserName;
                        sessLpa.UpdateDate = DateTime.Now;

                        if (oLpaServiceClient.UpdateWithNonUnitChild(sessNISPWebLogin.UserName, sessLpa, oHistoryApprovalLpaService, true) == 1)
                        {
                            Alert(String.Format("{0}", p_bIsDraft ? "Penyimpanan Sementara Berhasil" : "Menunda Dokumen Berhasil"));
                        }
                        else
                        {
                            Alert(String.Format("{0}", p_bIsDraft ? "Penyimpanan Sementara Gagal" : "Menunda Dokumen Gagal"));
                        }
                    }
                    else
                    {
                        int iId = 0;
                        sessLpa.CreateByUserId = sessLpa.UpdateByUserId = sessNISPWebLogin.UserName;
                        sessLpa.CreateDate = sessLpa.UpdateDate = DateTime.Now;

                        if (oLpaServiceClient.AddWithNonUnitChild(sessNISPWebLogin.UserName, sessLpa, oHistoryApprovalLpaService, true, out iId) == 1)
                        {
                            Alert(String.Format("{0}", p_bIsDraft ? "Penyimpanan Sementara Berhasil" : "Menunda Dokumen Berhasil"));
                            sessLpa.LpaId = iId;
                        }
                        else
                        {
                            Alert(String.Format("{0}", p_bIsDraft ? "Penyimpanan Sementara Gagal" : "Menunda Dokumen Gagal"));
                        }
                    }

                    oLpaServiceClient.Close();
                    oLpaServiceClient = null;

                }
                catch (System.ServiceModel.FaultException fe)
                {
                    if (fe.Reason.ToString() == "<<NispLoginWeb.ClsUser is null>>")
                    {
                        Response.Redirect("~/Error/SessionTimeOut.htm", true);
                    }
                    else
                    {
                        throw fe;
                    }
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                string sRefNumber = PFSCommon.GenerateRefNumber();

                ServicesClient oServicesClient = new ServicesClient();
                oServicesClient.LogError(
                    sessNISPWebLogin.UserName,
                    sRefNumber,
                    GetType().FullName,
                    MethodInfo.GetCurrentMethod().Name,
                    Ex.ToString());
                oServicesClient.Close();
                oServicesClient = null;

                Alert(string.Format("{0} ({1})", GeneralConfig.const_sGeneralMessageError, sRefNumber));
            }
        }

        protected void showDialog(string p_sUrl)
        {
            ram.ResponseScripts.Add(string.Format("openPopUpComparer('{0}')", p_sUrl));
        }

        #endregion

    }
}