


using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using PFSHelper.DataAccessLayer;

#region Region: Revision History///////////////////////////////////////////////////////////////
// Copyright (c) 2011, PT. Profescipta Wahanatehnik. All Rights Reserved.
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
//
// $Log:$
//
#endregion

namespace PFSHelper.BusinessLogicLayer
{
	//Standard class autogenerated by PFS Generator v5.0
	[System.Xml.Serialization.XmlRoot("SystemLog")]
	public partial class SystemLogCollection  : ICollection
	{
		#region Region: Member Variables///////////////////////////////////////////////////////////
        private ArrayList m_oSystemLogList = new ArrayList();
		private int m_iPageSize = 10;
		private int m_iPageNumber = 1;
		#endregion
		#region Region: Constructor///////////////////////////////////////////////////////////////////
		public SystemLogCollection()
		{
			m_iPageSize = 10;
			m_iPageNumber = 1;
		}
		#endregion
		#region Region: Properties///////////////////////////////////////////////////////////////////		
		public SystemLog this[int index]
        {
            get { return (SystemLog)m_oSystemLogList[index]; }
        }
        public int Count
        {
            get { return m_oSystemLogList.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
		public int PageSize
        {
            get { return m_iPageSize; }
			set { m_iPageSize = value; }
        }
		public int PageNumber
        {
            get { return m_iPageNumber; }
			set { m_iPageNumber = value; }
        }
		#endregion
		#region Region: List Method///////////////////////////////////////////////////////////////////		
		public void Sort(IComparer oComparer)
		{
			m_oSystemLogList.Sort(oComparer);
		}

		public void Reverse()
		{
			m_oSystemLogList.Reverse();
		}

        public void CopyTo(Array a, int index)
        {
            m_oSystemLogList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oSystemLogList.GetEnumerator();
        }
        public void Add(SystemLog oObject)
        {
            m_oSystemLogList.Add(oObject);
        }
		public void RemoveAt(int index)
		{
			m_oSystemLogList.RemoveAt(index);
		}
		#endregion
		#region Region: Field Enumeration ///////////////////////////////////////////////////////////
		public enum SystemLogFields 
		{
			SystemLogID,
			ReferenceNumber,
			ProcessID,
			LogDate,
			Status,
			Description,
			Detail
		}//End Enum
		#endregion
		#region Region: Sort Method///////////////////////////////////////////////////////////////////
		public void Sort (SystemLogFields sortField, bool isAscending) 
		{
			switch (sortField) 
			{		
					
			case SystemLogFields.SystemLogID:
				this.Sort(new SystemLogIDComparer());
				break;
		
			case SystemLogFields.ReferenceNumber:
				this.Sort(new ReferenceNumberComparer());
				break;
		
			case SystemLogFields.ProcessID:
				this.Sort(new ProcessIDComparer());
				break;
		
			case SystemLogFields.LogDate:
				this.Sort(new LogDateComparer());
				break;
		
			case SystemLogFields.Status:
				this.Sort(new StatusComparer());
				break;
		
			case SystemLogFields.Description:
				this.Sort(new DescriptionComparer());
				break;
		
			case SystemLogFields.Detail:
				this.Sort(new DetailComparer());
				break;		
			}
			if(!isAscending) this.Reverse();
		}//End SortField
		#endregion
		#region Region: IComparer///////////////////////////////////////////////////////////////////

		private sealed class SystemLogIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SystemLog first = (SystemLog) x;
				SystemLog second = (SystemLog) y;
				return first.SystemLogID.CompareTo(second.SystemLogID);
			}
		}	
		private sealed class ReferenceNumberComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SystemLog first = (SystemLog) x;
				SystemLog second = (SystemLog) y;
				return first.ReferenceNumber.CompareTo(second.ReferenceNumber);
			}
		}	
		private sealed class ProcessIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SystemLog first = (SystemLog) x;
				SystemLog second = (SystemLog) y;
				return first.ProcessID.CompareTo(second.ProcessID);
			}
		}	
		private sealed class LogDateComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SystemLog first = (SystemLog) x;
				SystemLog second = (SystemLog) y;
				return first.LogDate.CompareTo(second.LogDate);
			}
		}	
		private sealed class StatusComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SystemLog first = (SystemLog) x;
				SystemLog second = (SystemLog) y;
				return first.Status.CompareTo(second.Status);
			}
		}	
		private sealed class DescriptionComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SystemLog first = (SystemLog) x;
				SystemLog second = (SystemLog) y;
				return first.Description.CompareTo(second.Description);
			}
		}	
		private sealed class DetailComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SystemLog first = (SystemLog) x;
				SystemLog second = (SystemLog) y;
				return first.Detail.CompareTo(second.Detail);
			}
		}	
		#endregion
		#region Region: Data Access Layer ///////////////////////////////////////////////////////////////////
		public bool DAL_Load(
						string sKeyWords,
						object iProcessID,
						object dtLogDateFrom,
						object dtLogDateTo
						
						)
        {
            try
            {
				
				using(SqlDataReader drSystemLog = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SystemLogList",
					sKeyWords ,
					iProcessID,
					dtLogDateFrom,
					dtLogDateTo
					))
            	{
					if (drSystemLog.HasRows)
                    {
						while (drSystemLog.Read())
						{
							SystemLog oSystemLog =  new SystemLog();		
							oSystemLog.SystemLogID = Convert.ToInt64(drSystemLog["PFS_SYSTEM_LOG_ID"]);
							oSystemLog.ReferenceNumber = Convert.ToString(drSystemLog["REFERENCE_NUMBER"]);
							oSystemLog.ProcessID = Convert.ToInt32(drSystemLog["COM_PROCESS_ID"]);
							oSystemLog.LogDate = Convert.ToDateTime(drSystemLog["LOG_DATE"]);
							oSystemLog.Status = Convert.ToInt32(drSystemLog["STATUS"]);
							oSystemLog.Description = Convert.ToString(drSystemLog["DESCRIPTION"]);
                            oSystemLog.Detail = Convert.ToString(drSystemLog["DETAIL"]);
							this.Add(oSystemLog);
						}
						return true;
					} //*** if (dr.HasRows)
					else 
					{
						return false;
					}
            	}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }

		
		public bool DAL_Load()
        {
            try
            {
				using(SqlDataReader drSystemLog = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SystemLogList"))
            	{
					if (drSystemLog.HasRows)
                    {
						while (drSystemLog.Read())
						{
							SystemLog oSystemLog =  new SystemLog();		
							oSystemLog.SystemLogID = Convert.ToInt64(drSystemLog["PFS_SYSTEM_LOG_ID"]);
							oSystemLog.ReferenceNumber = Convert.ToString(drSystemLog["REFERENCE_NUMBER"]);
							oSystemLog.ProcessID = Convert.ToInt32(drSystemLog["COM_PROCESS_ID"]);
							oSystemLog.LogDate = Convert.ToDateTime(drSystemLog["LOG_DATE"]);
							oSystemLog.Status = Convert.ToInt32(drSystemLog["STATUS"]);
							oSystemLog.Description = Convert.ToString(drSystemLog["DESCRIPTION"]);
                            oSystemLog.Detail = Convert.ToString(drSystemLog["DETAIL"]);
							this.Add(oSystemLog);
						}
						return true;
					}
					else 
					{
						return false;	
					}
            	}
			}
			catch(Exception ex)
			{
				throw ex;
			}
        }
		

		public bool DAL_LoadByProcessID(int iID)
        {
            try
            {
				return this.DAL_Load(
					null,
					iID,
					null,
					null
					);
            }
            catch (Exception ex)
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
                bool bIsSuccess = DAL_Update(oTrans);

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
		public bool DAL_Update(SqlTransaction p_oTrans)
		{
			try
			{
				int iSuccessCounter = 0;
				foreach (SystemLog oSystemLog in m_oSystemLogList)
				{
					bool bIsSuccess = oSystemLog.DAL_Update(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oSystemLogList.Count)
                    return false;
                else
                    return true;
			}

			catch (Exception ex)
			{
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
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
				int iSuccessCounter = 0;
				foreach (SystemLog oSystemLog in m_oSystemLogList)
				{
					bool bIsSuccess = oSystemLog.DAL_Add(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oSystemLogList.Count)
                    return false;
                else
                    return true;
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
            catch (Exception ex)
            {
                throw ex;
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
				int iSuccessCounter = 0;
				foreach (SystemLog oSystemLog in m_oSystemLogList)
				{
					bool bIsSuccess = oSystemLog.DAL_Delete(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oSystemLogList.Count)
                    return false;
                else
                    return true;
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}	
		#endregion
	} //** Class
} //** Name Space