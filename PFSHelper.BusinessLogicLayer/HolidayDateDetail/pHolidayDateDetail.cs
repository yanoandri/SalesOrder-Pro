using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class HolidayDateDetail
    {
        public bool DAL_LoadByHolidayDate(DateTime dtHolidayDate, object iHolidayID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drHoliday = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_HolidayDateGetByHolidayDate", dtHolidayDate, iHolidayID))
                {
                    if (drHoliday.Read())
                    {
                        m_iHolidayDateID = Convert.ToInt32(drHoliday["PFS_HOLIDAY_DATE_ID"]);
                        m_dtHolidayDate = Convert.ToDateTime(drHoliday["HOLIDAY_DATE"]);
                        m_iHolidayID = Convert.ToInt32(drHoliday["PFS_HOLIDAY_ID"]);
                       
                        bIsSuccess = true;
                    }
                }
                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }	
    }
}
