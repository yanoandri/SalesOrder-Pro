


using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using PFSHelper.DataAccessLayer;

#region Region: Revision History///////////////////////////////////////////////////////////////
// Copyright (c) 2012, PT. Profescipta Wahanatehnik. All Rights Reserved.
//
// This software, all associated documentation, and all copies
// are CONFIDENTIAL INFORMATION of PT. Profescipta Wahanatehnik. 
// http://www.profescipta.com
//
// $Workfile:$
// $Revision:$
// $Date:$
//
// DESCRIPTION
//
// $Log:$
//
#endregion

namespace PFSHelper.BusinessLogicLayer
{
	//Standard class autogenerated by PFS Generator v5.0
	public partial class Holiday
	{
		#region Region: Member Variables///////////////////////////////////////////////////////////
		protected int m_iHolidayID = 0;
		protected DateTime m_dtHolidayStartdate = DateTime.Parse("01/01/1900");
		protected DateTime m_dtHolidayEnddate = DateTime.Parse("01/01/1900");
		protected string m_sHolidayDesc = "NONE";
		protected string m_sRecurrance = null;
		protected string m_iRecurranceParentID = null;
		protected bool m_bIsNeedApproval = false;
		protected int m_iCreateByUserID = 0;
		protected DateTime m_dtCreateDate = DateTime.Parse("01/01/1900");
		protected int m_iUpdateByUserID = 0;
		protected DateTime m_dtUpdateDate = DateTime.Parse("01/01/1900");
		#endregion
		
		#region Region: Constructor////////////////////////////////////////////////////////////////
		public Holiday()
		{
			m_iHolidayID = -1;
		}	
		public Holiday(int iID)
		{
			m_iHolidayID = iID;
		}

		public Holiday(
			int iHolidayID,
			DateTime dtHolidayStartdate,
			DateTime dtHolidayEnddate,
			string sHolidayDesc,
			string sRecurrance,
            string iRecurranceParentID,
			bool bIsNeedApproval,
			int iCreateByUserID,
			DateTime dtCreateDate,
			int iUpdateByUserID,
			DateTime dtUpdateDate
			)
		{
			m_iHolidayID = iHolidayID;
			m_dtHolidayStartdate = dtHolidayStartdate;
			m_dtHolidayEnddate = dtHolidayEnddate;
			m_sHolidayDesc = sHolidayDesc;
			m_sRecurrance = sRecurrance;
			m_iRecurranceParentID = iRecurranceParentID;
			m_bIsNeedApproval = bIsNeedApproval;
			m_iCreateByUserID = iCreateByUserID;
			m_dtCreateDate = dtCreateDate;
			m_iUpdateByUserID = iUpdateByUserID;
			m_dtUpdateDate = dtUpdateDate;
		}

		#endregion
		
		#region Region: Properties/////////////////////////////////////////////////////////////////
		
		public int HolidayID
		{
			get {return m_iHolidayID;}
			set {m_iHolidayID = value;}
		}

		public DateTime HolidayStartdate
		{
			get {return m_dtHolidayStartdate;}
			set {m_dtHolidayStartdate = value;}
		}

		public DateTime HolidayEnddate
		{
			get {return m_dtHolidayEnddate;}
			set {m_dtHolidayEnddate = value;}
		}

		public string HolidayDesc
		{
			get {return m_sHolidayDesc;}
			set {m_sHolidayDesc = value;}
		}

		public string Recurrance
		{
			get {return m_sRecurrance;}
			set {m_sRecurrance = value;}
		}

        public string RecurranceParentID
		{
			get {return m_iRecurranceParentID;}
			set {m_iRecurranceParentID = value;}
		}

		public bool IsNeedApproval
		{
			get {return m_bIsNeedApproval;}
			set {m_bIsNeedApproval = value;}
		}

		public int CreateByUserID
		{
			get {return m_iCreateByUserID;}
			set {m_iCreateByUserID = value;}
		}

		public DateTime CreateDate
		{
			get {return m_dtCreateDate;}
			set {m_dtCreateDate = value;}
		}

		public int UpdateByUserID
		{
			get {return m_iUpdateByUserID;}
			set {m_iUpdateByUserID = value;}
		}

		public DateTime UpdateDate
		{
			get {return m_dtUpdateDate;}
			set {m_dtUpdateDate = value;}
		}
		#endregion
		
		#region Region: Data Access Methods////////////////////////////////////////////////////////
		public bool DAL_Load()
        {
			bool bIsSuccess = false;
            try
            {
				using(SqlDataReader drHoliday = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_HolidayGet", m_iHolidayID))
            	{
					if(drHoliday.Read())
            		{      
						m_iHolidayID = Convert.ToInt32(drHoliday["PFS_HOLIDAY_ID"]);
						m_dtHolidayStartdate = Convert.ToDateTime(drHoliday["PFS_HOLIDAY_STARTDATE"]);
						m_dtHolidayEnddate = Convert.ToDateTime(drHoliday["PFS_HOLIDAY_ENDDATE"]);
						m_sHolidayDesc = Convert.ToString(drHoliday["PFS_HOLIDAY_DESC"]);
						m_sRecurrance = Convert.ToString(drHoliday["RECURRANCE"]);
                        m_iRecurranceParentID = Convert.ToString(drHoliday["RECURRANCE_PARENT_ID"]);
						m_bIsNeedApproval = Convert.ToBoolean(drHoliday["IS_NEED_APPROVAL"]);
						m_iCreateByUserID = Convert.ToInt32(drHoliday["CREATE_BY_USER_ID"]);
						m_dtCreateDate = Convert.ToDateTime(drHoliday["CREATE_DATE"]);
						m_iUpdateByUserID = Convert.ToInt32(drHoliday["UPDATE_BY_USER_ID"]);
						m_dtUpdateDate = Convert.ToDateTime(drHoliday["UPDATE_DATE"]);
						bIsSuccess = true;
           		 	}
            	}
				return bIsSuccess;
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }	
		
		public bool DAL_Load(int iID)
        {
			bool bIsSuccess = false;
            try
            {
				using(SqlDataReader drHoliday = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_HolidayGet",iID))
            	{
					if(drHoliday.Read())
            		{      
						m_iHolidayID = Convert.ToInt32(drHoliday["PFS_HOLIDAY_ID"]);
						m_dtHolidayStartdate = Convert.ToDateTime(drHoliday["PFS_HOLIDAY_STARTDATE"]);
						m_dtHolidayEnddate = Convert.ToDateTime(drHoliday["PFS_HOLIDAY_ENDDATE"]);
						m_sHolidayDesc = Convert.ToString(drHoliday["PFS_HOLIDAY_DESC"]);
						m_sRecurrance = Convert.ToString(drHoliday["RECURRANCE"]);
                        m_iRecurranceParentID = Convert.ToString(drHoliday["RECURRANCE_PARENT_ID"]);
						m_bIsNeedApproval = Convert.ToBoolean(drHoliday["IS_NEED_APPROVAL"]);
						m_iCreateByUserID = Convert.ToInt32(drHoliday["CREATE_BY_USER_ID"]);
						m_dtCreateDate = Convert.ToDateTime(drHoliday["CREATE_DATE"]);
						m_iUpdateByUserID = Convert.ToInt32(drHoliday["UPDATE_BY_USER_ID"]);
						m_dtUpdateDate = Convert.ToDateTime(drHoliday["UPDATE_DATE"]);
						bIsSuccess = true;
           		 	}
            	}
				return bIsSuccess;
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
		
		public bool DAL_Update() 
		{
			SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
			try
			{
				bool bIsSuccess = false;
				bIsSuccess = DAL_Update(oTrans);
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
		public bool DAL_Update(SqlTransaction p_oTrans) 
		{
			try
			{
				bool bIsSuccess = false;
				if (m_iHolidayID > 0)
				{
					int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_HolidayUpdate",
					m_iHolidayID,
										m_dtHolidayStartdate,
										m_dtHolidayEnddate,
										m_sHolidayDesc,
										m_sRecurrance,
										DBNull.Value,
										m_bIsNeedApproval,
										m_iCreateByUserID,
										m_dtCreateDate,
										m_iUpdateByUserID,
										m_dtUpdateDate
					));
					bIsSuccess = (iError == 0);
				}
				else
				{
					bIsSuccess = DAL_Add(p_oTrans);
				}			
				return (bIsSuccess);
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}
		
		
		public bool DAL_Delete() 
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_Delete(oTrans);

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
        public bool DAL_Delete(SqlTransaction p_oTrans) 
        {
            try
            {
										
                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_HolidayDelete", m_iHolidayID);

                return (iRowAffected > 0);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }	
        
		public bool DAL_Add() 
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_Add(oTrans);

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
		public bool DAL_Add(SqlTransaction p_oTrans)
        {
            try
            {
                m_iHolidayID = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_HolidayAdd", 

					m_dtHolidayStartdate,
					m_dtHolidayEnddate,
					m_sHolidayDesc,
					m_sRecurrance,
					m_iRecurranceParentID,
					m_bIsNeedApproval,
					m_iCreateByUserID,
					m_dtCreateDate,
					m_iUpdateByUserID,
					m_dtUpdateDate
					));
					
				bool bIsSuccess = (m_iHolidayID >=0);
				
				
				return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
		//*** This section is a temporary data access for combo, Radio Button etc. ToDo: Delete this and use the proper class definition
		#endregion
	} //** Class
} //** Name Space
