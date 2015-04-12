using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.IO;

namespace A2MS.ui._5_reporting.project_tracking_dashboard
{
    public partial class ProjectOverview : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string curPath = Server.MapPath("~/charts/chartdata/");
            Reportgenerator repgen = new Reportgenerator(curPath);

            if (!IsPostBack)
            {
                int cur_year = int.Parse(Common.Common.activeUniverseYear());

                Common.Common.setDropDownYear(yeardd);
                Common.Common.setDropDownDepartment(departmentdd);

                initiateProject(cur_year);
                initiateAuditor(cur_year);
            }
            userAccess();
        }

        private void userAccess()
        {
            string permission = Common.Common.getPemission("Reporting - Project Tracking");
            if (permission.Equals(""))
            {
                Common.Common.CloseWindowMessageBox("Sorry. You have no permission to access this page.");
            }
        }

        private void initiateProject(int year)
        {
            string selectValueDept = departmentdd.SelectedValue.ToString();
            string cmdText = string.Empty;
            if (departmentdd.SelectedIndex == 0)
                cmdText = @"select cast(AUDIT_PROJECT_CODE_ID as varchar(36)) as AUDIT_PROJECT_ID, PROJECT_NAME 
                            from AUDIT_PROJECT 
                            where audit_year = @year and is_latest = 1 and active = 1 
                            union ALL
                            select cast(NON_AUDIT_PROJECT_CODE_ID as varchar(36)) as NON_AUDIT_PROJECT_ID, PROJECT_NAME 
                            from NON_AUDIT_PROJECT 
                            where NON_AUDIT_YEAR = @year and is_latest = 1 and active = 1 
                            union ALL
                            select TRAINING_ID, TRAINING_NAME 
                            from TRAINING 
                            where TRAINING_YEAR = @year and active = 1 
                            order BY PROJECT_NAME";
            else
                cmdText = @"select cast(AUDIT_PROJECT_CODE_ID as varchar(36)) as AUDIT_PROJECT_ID, PROJECT_NAME  
                        from AUDIT_PROJECT  
                        where audit_year = @year and is_latest = 1 and active = 1 and project_owner = '" + selectValueDept + "' "+
                        "union ALL "+  
                        "select cast(NON_AUDIT_PROJECT_CODE_ID as varchar(36)) as NON_AUDIT_PROJECT_ID, PROJECT_NAME "+ 
                        "from NON_AUDIT_PROJECT "+   
                        "where NON_AUDIT_YEAR = @year and is_latest = 1 and active = 1 and project_owner = '" + selectValueDept + "' "+  
                        "union ALL "+
                        "select TRAINING_ID, TRAINING_NAME "+
                        "from TRAINING where TRAINING_YEAR = @year and active = 1  and training_owner = '" + selectValueDept + "' "+ 
                        "order BY PROJECT_NAME";


            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["A2MSConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, cn);
            cmd.Parameters.Add("@year", SqlDbType.Int, 0).Value = year;
            cmd.Connection = cn;

            SqlDataReader dr;

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
            }
            finally
            {

            }

            if (dr.HasRows)
            {
                projectdd.DataSource = dr;
                projectdd.DataTextField = "PROJECT_NAME";
                projectdd.DataValueField = "AUDIT_PROJECT_ID";
                projectdd.DataBind();
                projectdd.Items.Insert(0, "Please Select");

            }
            else
            {
                projectdd.Items.Clear();
                projectdd.Items.Insert(0, "Please Select");
            }

        }

        private void initiateAuditor(int year)
        {
            string SlctDept = departmentdd.SelectedValue.ToString();
            string SlctProject = projectdd.SelectedValue.ToString(); 
            string cmdText = string.Empty;
             if(projectdd.SelectedIndex != 0)
                cmdText = @"SELECT DISTINCT a.STAFF_ID, a.FULL_NAME 
                FROM (SELECT DISTINCT dbo.STAFF.STAFF_ID, dbo.STAFF.FULL_NAME, dbo.AUDIT_PROJECT.AUDIT_YEAR, dbo.AUDIT_PROJECT.PROJECT_OWNER, dbo.AUDIT_PROGRAM.audit_project_code_id 
                FROM dbo.AUDIT_PROGRAM INNER JOIN dbo.STAFF ON dbo.AUDIT_PROGRAM.PIC = dbo.STAFF.STAFF_ID LEFT OUTER JOIN dbo.AUDIT_PROJECT ON dbo.AUDIT_PROGRAM.AUDIT_PROJECT_CODE_ID = dbo.AUDIT_PROJECT.AUDIT_PROJECT_ID 
                where audit_year = @year and (dbo.AUDIT_PROGRAM.audit_project_code_id = '" + SlctProject + "' or '" + SlctProject + "' = 'Please Select') " +
                "UNION " +
                "SELECT DISTINCT dbo.Staff.STAFF_ID, dbo.STAFF.FULL_NAME, dbo.NON_AUDIT_PROJECT.NON_AUDIT_YEAR, dbo.NON_AUDIT_PROJECT.PROJECT_OWNER, dbo.NON_AUDIT_PROJECT.NON_AUDIT_PROJECT_CODE_ID " +
                "FROM dbo.NON_AUDIT_PROJECT INNER JOIN dbo.STAFF ON dbo.NON_AUDIT_PROJECT.MIC = dbo.STAFF.STAFF_ID " +
                "where non_audit_year = @year and (non_audit_project_code_id = '" + SlctProject + "' or '" + SlctProject + "' = 'Please Select'))a";
             else if (departmentdd.SelectedIndex == 0 && projectdd.SelectedIndex == 0)
                cmdText = @"SELECT DISTINCT a.STAFF_ID, a.FULL_NAME FROM (
                SELECT DISTINCT dbo.STAFF.STAFF_ID, dbo.STAFF.FULL_NAME, dbo.AUDIT_PROJECT.AUDIT_YEAR, dbo.AUDIT_PROJECT.PROJECT_OWNER, dbo.AUDIT_PROGRAM.audit_project_code_id 
                    FROM dbo.AUDIT_PROGRAM INNER JOIN 
                    dbo.STAFF ON dbo.AUDIT_PROGRAM.PIC = dbo.STAFF.STAFF_ID LEFT OUTER JOIN 
                    dbo.AUDIT_PROJECT ON dbo.AUDIT_PROGRAM.AUDIT_PROJECT_CODE_ID = dbo.AUDIT_PROJECT.AUDIT_PROJECT_ID where audit_year = @year  
                    UNION
                    SELECT DISTINCT dbo.Staff.STAFF_ID, dbo.STAFF.FULL_NAME, dbo.NON_AUDIT_PROJECT.NON_AUDIT_YEAR, dbo.NON_AUDIT_PROJECT.PROJECT_OWNER, dbo.NON_AUDIT_PROJECT.NON_AUDIT_PROJECT_CODE_ID
                    FROM dbo.NON_AUDIT_PROJECT INNER JOIN dbo.STAFF ON dbo.NON_AUDIT_PROJECT.MIC = dbo.STAFF.STAFF_ID where non_audit_year = @year )a ";         
             else
                cmdText = @"SELECT DISTINCT a.STAFF_ID, a.FULL_NAME 
                FROM (SELECT DISTINCT dbo.STAFF.STAFF_ID, dbo.STAFF.FULL_NAME, dbo.AUDIT_PROJECT.AUDIT_YEAR, dbo.AUDIT_PROJECT.PROJECT_OWNER, dbo.AUDIT_PROGRAM.audit_project_code_id 
                FROM dbo.AUDIT_PROGRAM INNER JOIN dbo.STAFF ON dbo.AUDIT_PROGRAM.PIC = dbo.STAFF.STAFF_ID LEFT OUTER JOIN dbo.AUDIT_PROJECT ON dbo.AUDIT_PROGRAM.AUDIT_PROJECT_CODE_ID = dbo.AUDIT_PROJECT.AUDIT_PROJECT_ID 
                where audit_year = @year and project_owner= '" + SlctDept + "' and (dbo.AUDIT_PROGRAM.audit_project_code_id = '" + SlctProject + "' or '" + SlctProject + "' = 'Please Select') "+ 
                "UNION "+ 
                "SELECT DISTINCT dbo.Staff.STAFF_ID, dbo.STAFF.FULL_NAME, dbo.NON_AUDIT_PROJECT.NON_AUDIT_YEAR, dbo.NON_AUDIT_PROJECT.PROJECT_OWNER, dbo.NON_AUDIT_PROJECT.NON_AUDIT_PROJECT_CODE_ID "+ 
                "FROM dbo.NON_AUDIT_PROJECT INNER JOIN dbo.STAFF ON dbo.NON_AUDIT_PROJECT.MIC = dbo.STAFF.STAFF_ID "+
                "where non_audit_year = @year and project_owner= '" + SlctDept + "' and (non_audit_project_code_id = '" + SlctProject + "' or '" + SlctProject + "' = 'Please Select'))a";

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["A2MSConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, cn);
            cmd.Parameters.Add("@year", SqlDbType.Int, 0).Value = year;
            cmd.Connection = cn;

            SqlDataReader dr;

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();
            }
            finally
            {
                
            }

            if (dr.HasRows)
            {
                auditordd.DataSource = dr;
                auditordd.DataTextField = "FULL_NAME";
                auditordd.DataValueField = "STAFF_ID";
                auditordd.DataBind();
                auditordd.Items.Insert(0, "Please Select");
            }
            else
            {
                auditordd.Items.Clear();
                auditordd.Items.Insert(0, "Please Select");
            }

        }

        public string generate_pie2dSingle()
        {
            return A2MS.Common.FusionCharts.RenderChart("../../../charts/Pie2d.swf", "", this.generateProjectOverviewXMLSingle(), "myChartId", "500", "280", false, true);
        }

        private string generateProjectOverviewXMLSingle()
        {
            //string filelocation = Server.MapPath("/charts/chartdata/") + "ProjectOverview.xml";
            //string filelocation = XMLLocation + "ProjectOverviewSingle.xml";

            //FileStream fs;
            //StreamReader sr;

            StringWriter sw = new StringWriter();
            XmlTextWriter xmlwr = new XmlTextWriter(sw);
            xmlwr.QuoteChar = '\'';
            xmlwr.WriteStartDocument();
            xmlwr.WriteStartElement("chart");
            //xmlwr.WriteAttributeString("caption", "Project Overview");
            xmlwr.WriteAttributeString("pieradius", "110");
            //xmlwr.WriteAttributeString("subcaption", "xxx");
            xmlwr.WriteAttributeString("xAxisName", "Status");
            xmlwr.WriteAttributeString("yAxisName", "Percentage");
            xmlwr.WriteAttributeString("showPercentageValues", "1"); // tukar ini dgn bawah untuk menukar value/persen di grafik
            xmlwr.WriteAttributeString("showZeroPies ", "0");
            xmlwr.WriteAttributeString("showValues ", "1");
            xmlwr.WriteAttributeString("showLabels ", "0");
            xmlwr.WriteAttributeString("showPercentInToolTip", "0"); // tukar ini dgn atas untuk menukar value/persen di grafik
            xmlwr.WriteAttributeString("enableSmartLabels", "1");
            DataTable dt = getProjectOverviewTable();

            xmlwr.WriteStartElement("set");
            xmlwr.WriteAttributeString("label", dt.Rows[0][0].ToString());
            xmlwr.WriteAttributeString("value", dt.Rows[0][1].ToString());
            xmlwr.WriteAttributeString("color", dt.Rows[0][2].ToString());
            xmlwr.WriteEndElement();
            xmlwr.WriteStartElement("set");
            xmlwr.WriteAttributeString("label", dt.Rows[1][0].ToString());
            xmlwr.WriteAttributeString("value", dt.Rows[1][1].ToString());
            xmlwr.WriteAttributeString("color", dt.Rows[1][2].ToString());
            xmlwr.WriteEndElement();
            xmlwr.WriteStartElement("set");
            xmlwr.WriteAttributeString("label", dt.Rows[2][0].ToString());
            xmlwr.WriteAttributeString("value", dt.Rows[2][1].ToString());
            xmlwr.WriteAttributeString("color", dt.Rows[2][2].ToString());
            xmlwr.WriteEndElement();

            xmlwr.WriteEndElement();
            xmlwr.WriteEndDocument();
            xmlwr.Close();
            sw.Flush();

            //fs = File.Open(filelocation, FileMode.Open);
            //sr = new StreamReader(fs);
            return sw.ToString();
        }

        private DataTable getProjectOverviewTable()
        {
            //set filter
            int year = 0;
            Guid department = new Guid();
            Guid project = new Guid();
            Guid auditor = new Guid();

            year = int.Parse(yeardd.SelectedValue.ToString());
            if (departmentdd.SelectedIndex != 0)
                department = new Guid(departmentdd.SelectedValue.ToString());
            if (projectdd.SelectedIndex != 0)
                project = new Guid(projectdd.SelectedValue.ToString());
            if (auditordd.SelectedIndex > 0)
                auditor = new Guid(auditordd.SelectedValue.ToString());

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["A2MSConnectionString"].ConnectionString);
            SqlCommand objComm = new SqlCommand();
            objComm.Connection = cn;
            objComm.CommandType = CommandType.StoredProcedure;

            objComm.CommandText = "spx_projecttrackingdashboard_get_project_overview";
            //objComm.Parameters.Add("@yeardd", SqlDbType.Int, 0).Value = year;
            SqlParameter year_param = new SqlParameter("@yeardd", SqlDbType.Int, 0);
            year_param.Value = year;
            SqlParameter department_param = new SqlParameter("@department", SqlDbType.UniqueIdentifier, 0);
            SqlParameter project_param = new SqlParameter("@project", SqlDbType.UniqueIdentifier, 0);
            SqlParameter auditor_param = new SqlParameter("@auditor", SqlDbType.UniqueIdentifier, 0);
            if (department == Guid.Empty)
                department_param.Value = DBNull.Value;
            else
                department_param.Value = department;
            if (project == Guid.Empty)
                project_param.Value = DBNull.Value;
            else
                project_param.Value = project;
            if (auditor == Guid.Empty)
                auditor_param.Value = DBNull.Value;
            else
                auditor_param.Value = auditor;

            objComm.Parameters.Add(year_param);
            objComm.Parameters.Add(department_param);
            objComm.Parameters.Add(project_param);
            objComm.Parameters.Add(auditor_param);
            SqlDataAdapter adapter = new SqlDataAdapter(objComm);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                DataColumn dc = new DataColumn("Status", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("Value", typeof(int));
                dt.Columns.Add(dc);
                dc = new DataColumn("Color", typeof(string));
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["Status"] = "Completed";
                dr["Value"] = 0;
                dr["Color"] = "#16365c";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Status"] = "In Progress";
                dr["Value"] = 0;
                dr["Color"] = "#95b3d7";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Status"] = "Not Yet Performed";
                dr["Value"] = 0;
                dr["Color"] = "#a6a6a6";
                dt.Rows.Add(dr);
            }


            return dt;
        }

        protected void departmentdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.initiateProject(int.Parse(yeardd.SelectedValue.ToString()));
            this.initiateAuditor(int.Parse(yeardd.SelectedValue.ToString()));
        }

        protected void yeardd_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.initiateProject(int.Parse(yeardd.SelectedValue.ToString()));
            this.initiateAuditor(int.Parse(yeardd.SelectedValue.ToString()));
        }

        protected void projectdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.initiateAuditor(int.Parse(yeardd.SelectedValue.ToString()));
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Panel refreshed at: " + DateTime.Now.ToLongTimeString();
        }
    }


}
