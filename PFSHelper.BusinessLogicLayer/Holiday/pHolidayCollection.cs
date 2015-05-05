using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class HolidayCollection
    {
        public bool DAL_LoadForList(
                        string sKeyWords,
                        object dtHolidayStartdate,
                        object dtHolidayEnddate,
                        object iHolidayID
                        )
        {
            try
            {

                using (SqlDataReader drHoliday = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_HolidayListForList",
                    sKeyWords,
                    dtHolidayStartdate,
                    dtHolidayEnddate,
                    iHolidayID
                    ))
                {
                    if (drHoliday.HasRows)
                    {
                        while (drHoliday.Read())
                        {
                            Holiday oHoliday = new Holiday();
                            oHoliday.HolidayID = Convert.ToInt32(drHoliday["PFS_HOLIDAY_ID"]);
                            oHoliday.HolidayStartdate = Convert.ToDateTime(drHoliday["PFS_HOLIDAY_STARTDATE"]);
                            oHoliday.HolidayEnddate = Convert.ToDateTime(drHoliday["PFS_HOLIDAY_ENDDATE"]);
                            oHoliday.HolidayDesc = Convert.ToString(drHoliday["PFS_HOLIDAY_DESC"]);
                            oHoliday.Recurrance = Convert.ToString(drHoliday["RECURRANCE"]);
                            oHoliday.RecurranceParentID = Convert.ToString(drHoliday["RECURRANCE_PARENT_ID"]);
                            oHoliday.IsNeedApproval = Convert.ToBoolean(drHoliday["IS_NEED_APPROVAL"]);
                            oHoliday.CreateByUserID = Convert.ToInt32(drHoliday["CREATE_BY_USER_ID"]);
                            oHoliday.CreateDate = Convert.ToDateTime(drHoliday["CREATE_DATE"]);
                            oHoliday.UpdateByUserID = Convert.ToInt32(drHoliday["UPDATE_BY_USER_ID"]);
                            oHoliday.UpdateDate = Convert.ToDateTime(drHoliday["UPDATE_DATE"]);
                            this.Add(oHoliday);
                        }
                        return true;
                    } //*** if (dr.HasRows)
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CopyToDetail(ref HolidayDateDetailCollection p_oHolidayDateDetailCollection)
        {
            p_oHolidayDateDetailCollection.Clear();

            foreach (Holiday oHoliday in this)
            {
                if (oHoliday.HolidayEnddate.Subtract(oHoliday.HolidayStartdate).Days > 1)
                {
                    for (int i = 0; i <= oHoliday.HolidayEnddate.Subtract(oHoliday.HolidayStartdate).Days; i++)
                    {
                        HolidayDateDetail oDateDetail = new HolidayDateDetail()
                        {
                            HolidayID = oHoliday.HolidayID,
                            HolidayDate = oHoliday.HolidayStartdate.AddDays(i),
                            HolidayDesc = oHoliday.HolidayDesc,
                            CreateByUserID = oHoliday.CreateByUserID,
                            CreateDate = oHoliday.CreateDate,
                            UpdateByUserID = oHoliday.UpdateByUserID,
                            UpdateDate = oHoliday.UpdateDate
                        };
                        p_oHolidayDateDetailCollection.Add(oDateDetail);
                    }
                }
                else if (oHoliday.RepeatCount != null)
                {
                    for (int i = 0; i < oHoliday.RepeatCount + 1; i++)
                    {
                        HolidayDateDetail oDateDetail = new HolidayDateDetail()
                        {
                            HolidayID = oHoliday.HolidayID,
                            HolidayDesc = oHoliday.HolidayDesc,
                            CreateByUserID = oHoliday.CreateByUserID,
                            CreateDate = oHoliday.CreateDate,
                            UpdateByUserID = oHoliday.UpdateByUserID,
                            UpdateDate = oHoliday.UpdateDate
                        };

                        if (oHoliday.Recurrance.Contains("HOURLY")) { /** Not Implemented Yet **/}
                        else if (oHoliday.Recurrance.Contains("DAILY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddDays(i);
                        }
                        else if (oHoliday.Recurrance.Contains("WEEKLY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddDays(i * 7);
                        }
                        else if (oHoliday.Recurrance.Contains("MONTHLY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddMonths(i);
                        }
                        else if (oHoliday.Recurrance.Contains("YEARLY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddYears(i);
                        }
                        else
                        {
                            throw new Exception("Unknown Recurrance");
                        }

                        p_oHolidayDateDetailCollection.Add(oDateDetail);
                    }
                }
                else if (oHoliday.UntilDate != null)
                {
                    DateTime? dtUntil = new DateTime();
                    int i = 0;
                    while (dtUntil < oHoliday.UntilDate)
                    {
                        HolidayDateDetail oDateDetail = new HolidayDateDetail()
                        {
                            HolidayID = oHoliday.HolidayID,
                            HolidayDesc = oHoliday.HolidayDesc,
                            CreateByUserID = oHoliday.CreateByUserID,
                            CreateDate = oHoliday.CreateDate,
                            UpdateByUserID = oHoliday.UpdateByUserID,
                            UpdateDate = oHoliday.UpdateDate
                        };

                        if (oHoliday.Recurrance.Contains("HOURLY")) { /** Not Implemented Yet **/}
                        else if (oHoliday.Recurrance.Contains("DAILY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddDays(i);
                        }
                        else if (oHoliday.Recurrance.Contains("WEEKLY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddDays(i * 7);
                        }
                        else if (oHoliday.Recurrance.Contains("MONTHLY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddMonths(i);
                        }
                        else if (oHoliday.Recurrance.Contains("YEARLY"))
                        {
                            oDateDetail.HolidayDate = oHoliday.HolidayStartdate.AddYears(i);
                        }
                        else
                        {
                            throw new Exception("Unknown Recurrance");
                        }

                        dtUntil = oDateDetail.HolidayDate;

                        if (dtUntil > oHoliday.UntilDate)
                            break;

                        i++;
                        p_oHolidayDateDetailCollection.Add(oDateDetail);
                    }
                }
                else if (oHoliday.Recurrance.Length > 0)
                {
                    DateTime? dtUntil = new DateTime();
                    int i = 0;
                    while (dtUntil <= DateTime.Now.AddYears(10))
                    {
                        DateTime dtEndDate = new DateTime();
                        HolidayDateDetail oDateDetail = new HolidayDateDetail()
                        {
                            HolidayID = oHoliday.HolidayID,
                            HolidayDesc = oHoliday.HolidayDesc,
                            CreateByUserID = oHoliday.CreateByUserID,
                            CreateDate = oHoliday.CreateDate,
                            UpdateByUserID = oHoliday.UpdateByUserID,
                            UpdateDate = oHoliday.UpdateDate
                        };
                        if (oHoliday.Recurrance.Contains("HOURLY")) { /** Not Implemented Yet **/}
                        else if (oHoliday.Recurrance.Contains("DAILY"))
                        {
                            dtEndDate = oHoliday.HolidayStartdate.AddDays(i);
                        }
                        else if (oHoliday.Recurrance.Contains("WEEKLY"))
                        {
                            dtEndDate = oHoliday.HolidayStartdate.AddDays(i * 7);
                        }
                        else if (oHoliday.Recurrance.Contains("MONTHLY"))
                        {
                            dtEndDate = oHoliday.HolidayStartdate.AddMonths(i);
                        }
                        else if (oHoliday.Recurrance.Contains("YEARLY"))
                        {
                            dtEndDate = oHoliday.HolidayStartdate.AddYears(i);
                        }
                        else
                        {
                            throw new Exception("Unknown Recurrance");
                        }

                        oDateDetail.HolidayDate = dtEndDate;
                        dtUntil = oDateDetail.HolidayDate;
                        i++;
                        p_oHolidayDateDetailCollection.Add(oDateDetail);
                    }
                }
                else
                {
                    HolidayDateDetail oDateDetail = new HolidayDateDetail()
                    {
                        HolidayID = oHoliday.HolidayID,
                        HolidayDesc = oHoliday.HolidayDesc,
                        CreateByUserID = oHoliday.CreateByUserID,
                        CreateDate = oHoliday.CreateDate,
                        UpdateByUserID = oHoliday.UpdateByUserID,
                        UpdateDate = oHoliday.UpdateDate
                    };

                    oDateDetail.HolidayDate = oHoliday.HolidayStartdate;
                    p_oHolidayDateDetailCollection.Add(oDateDetail);
                }
            }
        }

        public void Remove(Holiday oObject)
        {
            m_oHolidayList.Remove(oObject);
        }

        public bool DAL_AddForHolidayDate()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_AddForHolidayDate(oTrans);

                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }

        public bool DAL_AddForHolidayDate(SqlTransaction p_oTrans)
        {
            try
            {
                int iSuccessCounter = 0;
                foreach (Holiday oHoliday in m_oHolidayList)
                {
                    bool bIsSuccess = oHoliday.DAL_AddForHolidayDate(p_oTrans);
                    if (!bIsSuccess) break;
                    iSuccessCounter++;
                }
                if (iSuccessCounter < m_oHolidayList.Count)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
