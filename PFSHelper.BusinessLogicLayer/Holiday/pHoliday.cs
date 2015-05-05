using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;
using System;
using System.Data;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class Holiday
    {
        private const string m_sFrequenceParameter = "FREQ=";
        private const string m_iCountParameter = "COUNT=";
        private const string m_dtUntilDateParameter = "UNTIL=";
        private const char m_sDelimiter = ';';
        private DateTime m_dtHolidayDate;

        public DateTime HolidayDate
        {
            get { return m_dtHolidayDate; }
            set { m_dtHolidayDate = value; }
        }

        public enum FREQ
        {
            HOURLY,
            DAILY,
            WEEKLY,
            MONTHLY,
            YEARLY,
            NONE
        }

        public FREQ Freq
        {
            get
            {
                FREQ m_eFreq;
                int iStart = Recurrance.IndexOf(m_sFrequenceParameter) > 0 ? Recurrance.IndexOf(m_sFrequenceParameter) + m_sFrequenceParameter.Length : 0;
                int iEnd = iStart > 0 ? Recurrance.IndexOf(m_sDelimiter, iStart) : 0;

                if (iStart > 0 && iEnd > 0)
                {
                    switch (Recurrance.Substring(iStart, iEnd - iStart))
                    {
                        case "HOURLY":
                            m_eFreq = FREQ.HOURLY;
                            break;
                        case "DAILY":
                            m_eFreq = FREQ.DAILY;
                            break;
                        case "WEEKLY":
                            m_eFreq = FREQ.WEEKLY;
                            break;
                        case "MONTHLY":
                            m_eFreq = FREQ.MONTHLY;
                            break;
                        case "YEARLY":
                            m_eFreq = FREQ.YEARLY;
                            break;
                        default:
                            m_eFreq = FREQ.NONE;
                            break;
                    }
                }
                else
                {
                    m_eFreq = FREQ.NONE;
                }

                return m_eFreq;
            }
        }
        public int? RepeatCount
        {
            get
            {
                int iStart = Recurrance.IndexOf(m_iCountParameter) > 0 ? Recurrance.IndexOf(m_iCountParameter) + m_iCountParameter.Length : 0;
                int iEnd = iStart > 0 ? Recurrance.IndexOf(m_sDelimiter, iStart) : 0;
                int? iCount;

                if (iStart > 0 && iEnd > 0)
                    iCount = int.Parse(Recurrance.Substring(iStart, iEnd - iStart));
                else
                    iCount = null;

                return iCount;
            }
        }

        public DateTime? UntilDate
        {
            get
            {
                int iStart = Recurrance.IndexOf(m_dtUntilDateParameter) > 0 ? Recurrance.IndexOf(m_dtUntilDateParameter) + m_dtUntilDateParameter.Length : 0;
                int iEnd = iStart > 0 ? Recurrance.IndexOf(m_sDelimiter, iStart) : 0;
                DateTime? dtUntil;

                if (iStart > 0 && iEnd > 0)
                    dtUntil = DateTime.Parse(Recurrance.Substring(iStart, iEnd - iStart).Substring(0,8).Insert(6,"-").Insert(4,"-"));
                else
                    dtUntil = null;

                return dtUntil;
            }
        }
        public DateTime? EndOfHoliday
        {
            get
            {
                DateTime? oDate = null;
                if (UntilDate != null)
                    oDate = UntilDate;
                else if (RepeatCount != null)
                    switch (Freq)
                    {
                        case FREQ.HOURLY:
                            oDate = null;
                            break;
                        case FREQ.DAILY:
                            oDate = m_dtHolidayStartdate.AddDays(Convert.ToDouble(RepeatCount));
                            break;
                        case FREQ.MONTHLY:
                            oDate = m_dtHolidayStartdate.AddMonths(Convert.ToInt32(RepeatCount));
                            break;
                        case FREQ.WEEKLY:
                            oDate = m_dtHolidayStartdate.AddDays(Convert.ToDouble(RepeatCount * 7));
                            break;
                        case FREQ.YEARLY:
                            oDate = m_dtHolidayStartdate.AddYears(Convert.ToInt32(RepeatCount));
                            break;
                        case FREQ.NONE:
                            oDate = null;
                            break;
                    }
                else if (m_dtHolidayEnddate.Subtract(m_dtHolidayStartdate).Days > 1)
                    //oDate = m_dtHolidayEnddate.AddDays(-1);
                    oDate = m_dtHolidayEnddate;
                else if (m_sRecurrance.Length > 0)
                    oDate = null;
                else
                    oDate = m_dtHolidayStartdate;

                return oDate;
            }
        }
        public static bool TodayHolidayCheck()
        {
            //using (SqlDataReader drHoliday = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_HolidayCheck"))
            //{
            //    return drHoliday.Read();
            //}


            HolidayCollection oHolidayList = new HolidayCollection();
            oHolidayList.DAL_LoadForList(null, null, null, null);

            //DataTable dtHolidayDate = new DataTable();
            //dtHolidayDate.Columns.Add("Date");

            //DataColumn[] dcKeys = new DataColumn[1];
            //dcKeys[0] = dtHolidayDate.Columns[0];
            //dtHolidayDate.PrimaryKey = dcKeys;

            HolidayDateDetailCollection oDetailList = new HolidayDateDetailCollection();
            oHolidayList.CopyToDetail(ref oDetailList);
            oDetailList.Sort(true);

            foreach (HolidayDateDetail oDetail in oDetailList)
            {
                if (oDetail.HolidayDate.Date == DateTime.Now.Date)
                    return true;
            }

            return false;
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
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw (ex);
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_AddForHolidayDate(SqlTransaction p_oTrans)
        {
            int iSucccess = 0;
            try
            {
                iSucccess = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_HolidayDateAdd",

                    m_iHolidayID,
                    m_dtHolidayDate
                    ));

                bool bIsSuccess = (iSucccess >= 0);


                return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_DeleteForHolidayDate()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_DeleteForHolidayDate(oTrans);

                if (!bIsSuccess)
                {
                    oTrans.Rollback();
                    return false;
                }

                oTrans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                oTrans.Rollback();
                throw (ex);
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        public bool DAL_DeleteForHolidayDate(SqlTransaction p_oTrans)
        {
            try
            {
                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_HolidayDateCheckToDeleteExistingHoliday", m_iHolidayID);
                return (iRowAffected > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REFER TO SP : uspCOM_StatementCourierUpdateByApprovalStatus
        /// </summary>
        /// <param name="p_oTrans">SQL Transaction</param>
        /// <param name="bIsNeedApproval">Approval Status</param>
        /// <returns>True if Transaction success, false if Transaction failed</returns>
        public bool UpdateApprovalStatus(SqlTransaction p_oTrans, bool bIsNeedApproval)
        {
            try
            {
                bool bIsSuccess = false;
                if (m_iHolidayID > 0)
                {
                    int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_HolidayUpdateByApprovalStatus",
                        m_iHolidayID,
                        bIsNeedApproval,
                        m_dtUpdateDate,
                        m_iUpdateByUserID
                    ));
                    bIsSuccess = (iError == 0);
                }
                return (bIsSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REFER TO SP : "uspCOM_StatementCourierUpdateByRejection"
        /// </summary>
        /// <param name="p_oTrans">SQL Transaction</param>
        /// <param name="bIsNeedApproval">Approval Status</param>
        /// <returns>True if Transaction success, false if Transaction failed</returns>
        public bool RejectApprovalRequest(SqlTransaction p_oTrans)
        {
            try
            {
                bool bIsSuccess = false;

                int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_HolidayUpdateByRejection",
                    m_iHolidayID
                ));

                bIsSuccess = (iError == 0);

                return (bIsSuccess);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
