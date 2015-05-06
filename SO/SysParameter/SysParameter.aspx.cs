using System;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using PSC.BusinessLogicLayer.Enumeration;
using Telerik.Web.UI;

namespace PSC.Web.UI.Admin.SysParameter
{
    public partial class SysParameter : PFSBasePage
    {
        #region Session
        private SysParamCollection sessSysParamCollection
        {
            get { return Session["sessSysParamCollection"] == null ? new SysParamCollection() : (SysParamCollection)Session["sessSysParamCollection"]; }
            set { Session["sessSysParamCollection"] = value; }
        }
        #endregion

        #region Properties
        string RefNumber { get { return PFSCommon.GenerateRefNumber(); } }
        const string sMaskPassword = "●●●●●●●●●●●●●●●●";
        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.PRE_SYS_PARAM_READ.ToString()))
                    NoPermission();

                btnSave.Visible = Security.CheckSecurity(PSCEnumeration.PFSModuleObjectMember.PRE_SYS_PARAM_UPDATE.ToString());

                ViewSysParam();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                ExceptionLog.LogError(RefNumber, GetType().FullName, MethodInfo.GetCurrentMethod().Name, Ex);
                Alert(string.Format("{0} ({1})", GeneralError(), RefNumber));
            }
        }
        private void ViewSysParam()
        {
            try
            {
                sessSysParamCollection = new SysParamCollection();

                RadPanelBar oPanelBar = new RadPanelBar();
                oPanelBar.ExpandMode = PanelBarExpandMode.MultipleExpandedItems;
                oPanelBar.Width = new Unit("97%");
                oPanelBar.ID = "pbSysParam";

                SysParamGroupCollection oParamGroupList = new SysParamGroupCollection();
                oParamGroupList.DAL_LoadWithChild(null);

                if (sessSysParamCollection.Count == 0)
                {
                    foreach (SysParamGroup oParamGroup in oParamGroupList)
                    {
                        HtmlTable oTable = new HtmlTable();
                        oTable.Border = 1;
                        oTable.Style[HtmlTextWriterStyle.BorderCollapse] = "Collapse";
                        oTable.Style[HtmlTextWriterStyle.MarginBottom] = "15px";
                        oTable.CellPadding = 5;

                        SysParamCollection oSysParamCollection = new SysParamCollection();
                        oSysParamCollection.DAL_LoadOrderByIndex(null, true, oParamGroup.SysParamGroupID, null);

                        foreach (SysParam oSysParam in oSysParamCollection)
                        {
                            sessSysParamCollection.Add(oSysParam);
                        }

                        oTable.Controls.Add(AddHeader(oParamGroup.ParamGroupName));

                        foreach (SysParam oSysParam in oSysParamCollection)
                        {
                            oTable.Controls.Add(AddRow(oSysParam));
                        }

                        CustomContentTemplate template = new CustomContentTemplate(oTable);

                        RadPanelItem item = new RadPanelItem(oParamGroup.ParamGroupName);
                        item.Style[HtmlTextWriterStyle.FontSize] = "15px";
                        item.Style[HtmlTextWriterStyle.FontWeight] = "Bold";
                        item.ForeColor = Color.FromArgb(1, 134, 193);

                        item.ContentTemplate = new CustomContentTemplate(oTable);
                        template.InstantiateIn(item);
                        oPanelBar.Items.Add(item);
                    }
                }


                phSysParameter.Controls.Add(oPanelBar);

                foreach (RadPanelItem oItem in oPanelBar.Items)
                {
                    oItem.Expanded = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            short iStatus = 0;
            string sDescription = "Update System Parameter";
            string sRefNumber = RefNumber;
            SysParamCollection oPreviousSysParam = new SysParamCollection();
            SysParamGroupCollection oParamGroupList = new SysParamGroupCollection();
            string sXmlPreviousSysParam = string.Empty;

            try
            {
                #region Get Previous Sys Param
                oParamGroupList.DAL_LoadWithChild(null);
                foreach (SysParamGroup oParamGroup in oParamGroupList)
                {
                    SysParamCollection oSysParamCollection = new SysParamCollection();
                    oSysParamCollection.DAL_LoadOrderByIndex(null, true, oParamGroup.SysParamGroupID, null);

                    foreach (SysParam oSysParam in oSysParamCollection)
                    {
                        oPreviousSysParam.Add(oSysParam);
                    }
                }
                #endregion

                foreach (SysParam oSysParam in sessSysParamCollection)
                {
                    RadPanelBar oBar = (RadPanelBar)phSysParameter.FindControl("pbSysParam");
                    foreach (RadPanelItem oItem in oBar.Items)
                    {
                        RadTextBox oTb = oItem.FindControl("tbValue" + oSysParam.Code) as RadTextBox;
                        //TextBox oTb = oItem.FindControl("tbValue" + oSysParam.Code) as TextBox;
                        if (oTb != null && oTb.Text.Length > 0)
                        {
                            if (oSysParam.IsEncrypted)
                            {
                                string sKey = ConfigurationManager.AppSettings.Get("AppId");
                                string sEncryptedValue = string.Empty;
                                PFSCryptography.Encrypt(sKey, oTb.Text, out sEncryptedValue);

                                oSysParam.Value = sEncryptedValue;
                            }
                            else
                            {
                                oSysParam.Value = oTb.Text;
                            }
                            break;
                        }
                    }
                }

                iStatus = Convert.ToInt16(sessSysParamCollection.DAL_Update());
                sXmlPreviousSysParam = PFSXMLTools.SerializeObject(oPreviousSysParam);
                if (iStatus == 0)
                {
                    sDescription += " Not successful CODE:" + sRefNumber;
                    Alert(sDescription);
                }
                else
                {
                    sDescription += " successful";
                    Alert(sDescription);

                    PFSCommon.ClearSysParam();
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
                Security.WriteUserLog(sRefNumber, sDescription, sessSysParamCollection, iStatus, (int)PSC.BusinessLogicLayer.Enumeration.PSCEnumeration.PFSModuleObjectMember.PRE_SYS_PARAM_UPDATE, sXmlPreviousSysParam);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SysParameter.aspx");
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region Methods
        private HtmlTableRow AddRow(SysParam p_oSysParam)
        {
            try
            {
                string sCode = p_oSysParam.Code;
                string sName = p_oSysParam.SysParamName;
                string sValue = p_oSysParam.Value;
                string sDescr = p_oSysParam.Description;

                HtmlTableRow oHtmlTableRow = new HtmlTableRow();
                oHtmlTableRow.Style[HtmlTextWriterStyle.VerticalAlign] = "Top";

                HtmlTableCell htcCode = new HtmlTableCell();
                htcCode.BgColor = "#f3f3f3";

                HtmlTableCell htcColon = new HtmlTableCell();
                htcCode.Style[HtmlTextWriterStyle.PaddingRight] = "10px";

                HtmlTableCell htcValue = new HtmlTableCell();
                htcValue.Style[HtmlTextWriterStyle.PaddingTop] = "5px";

                HtmlTableCell htcDescr = new HtmlTableCell();

                Label lblColon = new Label();
                lblColon.Text = ":";

                Label lblCode = new Label();
                lblCode.ID = "lblCode" + sCode;
                lblCode.Text = sName;
                lblCode.CssClass = "Label";
                lblCode.Width = new Unit(200, UnitType.Pixel);

                RadTextBox tbValue = new RadTextBox();
                //TextBox tbValue = new TextBox();
                if (p_oSysParam.IsEncrypted)
                {
                    tbValue.TextMode = InputMode.Password;
                    tbValue.EmptyMessage = sMaskPassword;
                }

                tbValue.Text = sValue;

                tbValue.ID = "tbValue" + sCode;

                tbValue.Width = new Unit(300, UnitType.Pixel);
                tbValue.CssClass = "TextBox";
                tbValue.EnableViewState = true;

                //tbValue.Style[HtmlTextWriterStyle.PaddingTop] = "50px";

                Label lblDescr = new Label();
                lblDescr.ID = "lblDescr" + sCode;
                lblDescr.Text = sDescr;
                lblDescr.CssClass = "Label";
                lblDescr.Width = new Unit(350, UnitType.Pixel);
                lblDescr.ForeColor = Color.Blue;

                htcCode.Controls.Add(lblCode);
                htcColon.Controls.Add(lblColon);
                htcValue.Controls.Add(tbValue);
                htcDescr.Controls.Add(lblDescr);

                oHtmlTableRow.Controls.Add(htcCode);
                //oHtmlTableRow.Controls.Add(htcColon);
                oHtmlTableRow.Controls.Add(htcValue);
                oHtmlTableRow.Controls.Add(htcDescr);


                return oHtmlTableRow;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private HtmlTableRow AddHeader(string sSysParamGroupName)
        {
            try
            {
                HtmlTableRow oHtmlTableRow = new HtmlTableRow();
                HtmlTableCell htcCode = new HtmlTableCell();
                HtmlTableCell htcEmpty = new HtmlTableCell();
                HtmlTableCell htcValue = new HtmlTableCell();
                HtmlTableCell htcDescr = new HtmlTableCell();

                Label lblCode = new Label();
                lblCode.ID = "lblHeaderCode" + sSysParamGroupName;
                lblCode.Text = "PARAMETER NAME";
                lblCode.CssClass = "Label";
                lblCode.Style.Add(HtmlTextWriterStyle.FontSize, "14px");
                lblCode.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                lblCode.Style.Add(HtmlTextWriterStyle.Color, "#EDEDED");
                lblCode.Style.Add(HtmlTextWriterStyle.TextAlign, "Center");
                lblCode.Width = new Unit(200, UnitType.Pixel);
                //lblCode.Style.Add(HtmlTextWriterStyle.TextDecoration, "underline");

                Label lblValue = new Label();
                lblValue.ID = "tbHeaderValue" + sSysParamGroupName;
                lblValue.Text = "PARAMETER VALUE";
                lblValue.CssClass = "Label";
                lblValue.Style.Add(HtmlTextWriterStyle.FontSize, "14px");
                lblValue.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                lblValue.Style.Add(HtmlTextWriterStyle.Color, "#EDEDED");
                lblValue.Style.Add(HtmlTextWriterStyle.TextAlign, "Center");
                lblValue.Width = new Unit(350, UnitType.Pixel);
                //lblValue.Style.Add(HtmlTextWriterStyle.TextDecoration, "underline");

                Label lblDescr = new Label();
                lblDescr.ID = "lblHeaderDescr" + sSysParamGroupName;
                lblDescr.Text = "DESCRIPTION";
                lblDescr.CssClass = "Label";
                lblDescr.Style.Add(HtmlTextWriterStyle.FontSize, "14px");
                lblDescr.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                lblDescr.Style.Add(HtmlTextWriterStyle.Color, "#EDEDED");
                lblDescr.Style.Add(HtmlTextWriterStyle.TextAlign, "Center");
                lblDescr.Width = new Unit(300, UnitType.Pixel);
                //lblDescr.Style.Add(HtmlTextWriterStyle.TextDecoration, "underline");

                htcCode.Controls.Add(lblCode);
                htcValue.Controls.Add(lblValue);
                htcDescr.Controls.Add(lblDescr);

                oHtmlTableRow.Controls.Add(htcCode);
                //oHtmlTableRow.Controls.Add(htcEmpty);
                oHtmlTableRow.Controls.Add(htcValue);
                oHtmlTableRow.Controls.Add(htcDescr);
                oHtmlTableRow.Style[HtmlTextWriterStyle.BackgroundColor] = "Gray";
                oHtmlTableRow.Style[HtmlTextWriterStyle.Color] = "White";
                return oHtmlTableRow;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region SubClass Item Template
        private class CustomContentTemplate : ITemplate
        {
            private HtmlTable m_oTable { get; set; }
            public CustomContentTemplate(HtmlTable oTable)
            {
                m_oTable = oTable;
            }
            public void InstantiateIn(Control container)
            {
                container.Controls.Add(m_oTable);
            }
        }
        #endregion
    }
}