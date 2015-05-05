


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
//
// $Log:$
//
#endregion

namespace PFSHelper.BusinessLogicLayer
{
	//Standard class autogenerated by PFS Generator v5.0
	[System.Xml.Serialization.XmlRoot("Holiday")]
	public partial class HolidayCollection  : ICollection
	{
		#region Region: Member Variables///////////////////////////////////////////////////////////
        private ArrayList m_oHolidayList = new ArrayList();
		private int m_iPageSize = 10;
		private int m_iPageNumber = 1;
		#endregion
		#region Region: Constructor///////////////////////////////////////////////////////////////////
		public HolidayCollection()
		{
			m_iPageSize = 10;
			m_iPageNumber = 1;
		}
		#endregion
		#region Region: Properties///////////////////////////////////////////////////////////////////		
		public Holiday this[int index]
        {
            get { return (Holiday)m_oHolidayList[index]; }
        }
        public int Count
        {
            get { return m_oHolidayList.Count; }
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
			m_oHolidayList.Sort(oComparer);
		}

		public void Reverse()
		{
			m_oHolidayList.Reverse();
		}

        public void CopyTo(Array a, int index)
        {
            m_oHolidayList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oHolidayList.GetEnumerator();
        }
        public void Add(Holiday oObject)
        {
            m_oHolidayList.Add(oObject);
        }
		public void RemoveAt(int index)
		{
			m_oHolidayList.RemoveAt(index);
		}
		#endregion
		#region Region: Field Enumeration ///////////////////////////////////////////////////////////
		public enum HolidayFields 
		{
			HolidayID,
			HolidayStartdate,
			HolidayEnddate,
			HolidayDesc,
			Recurrance,
			RecurranceParentID,
			IsNeedApproval,
			CreateByUserID,
			CreateDate,
			UpdateByUserID,
			UpdateDate
		}//End Enum
		#endregion
		#region Region: Sort Method///////////////////////////////////////////////////////////////////
		public void Sort (HolidayFields sortField, bool isAscending) 
		{
			switch (sortField) 
			{		
					
			case HolidayFields.HolidayID:
				this.Sort(new HolidayIDComparer());
				break;
		
			case HolidayFields.HolidayStartdate:
				this.Sort(new HolidayStartdateComparer());
				break;
		
			case HolidayFields.HolidayEnddate:
				this.Sort(new HolidayEnddateComparer());
				break;
		
			case HolidayFields.HolidayDesc:
				this.Sort(new HolidayDescComparer());
				break;
		
			case HolidayFields.Recurrance:
				this.Sort(new RecurranceComparer());
				break;
		
			case HolidayFields.RecurranceParentID:
				this.Sort(new RecurranceParentIDComparer());
				break;
		
			case HolidayFields.IsNeedApproval:
				this.Sort(new IsNeedApprovalComparer());
				break;
		
			case HolidayFields.CreateByUserID:
				this.Sort(new CreateByUserIDComparer());
				break;
		
			case HolidayFields.CreateDate:
				this.Sort(new CreateDateComparer());
				break;
		
			case HolidayFields.UpdateByUserID:
				this.Sort(new UpdateByUserIDComparer());
				break;
		
			case HolidayFields.UpdateDate:
				this.Sort(new UpdateDateComparer());
				break;
			}
			if(!isAscending) this.Reverse();
		}//End SortField
		#endregion
		#region Region: IComparer///////////////////////////////////////////////////////////////////

		private sealed class HolidayIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.HolidayID.CompareTo(second.HolidayID);
			}
		}	
		private sealed class HolidayStartdateComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.HolidayStartdate.CompareTo(second.HolidayStartdate);
			}
		}	
		private sealed class HolidayEnddateComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.HolidayEnddate.CompareTo(second.HolidayEnddate);
			}
		}	
		private sealed class HolidayDescComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.HolidayDesc.CompareTo(second.HolidayDesc);
			}
		}	
		private sealed class RecurranceComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.Recurrance.CompareTo(second.Recurrance);
			}
		}	
		private sealed class RecurranceParentIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.RecurranceParentID.CompareTo(second.RecurranceParentID);
			}
		}	
		private sealed class IsNeedApprovalComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.IsNeedApproval.CompareTo(second.IsNeedApproval);
			}
		}	
		private sealed class CreateByUserIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.CreateByUserID.CompareTo(second.CreateByUserID);
			}
		}	
		private sealed class CreateDateComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.CreateDate.CompareTo(second.CreateDate);
			}
		}	
		private sealed class UpdateByUserIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.UpdateByUserID.CompareTo(second.UpdateByUserID);
			}
		}	
		private sealed class UpdateDateComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Holiday first = (Holiday) x;
				Holiday second = (Holiday) y;
				return first.UpdateDate.CompareTo(second.UpdateDate);
			}
		}	
		#endregion
		#region Region: Data Access Layer ///////////////////////////////////////////////////////////////////
		public bool DAL_Load(
						string sKeyWords,
						object dtHolidayStartdateFrom,
						object dtHolidayStartdateTo,
						object dtHolidayEnddateFrom,
						object dtHolidayEnddateTo,
						object iRecurranceParentID,
						object bIsNeedApproval,
						object iCreateByUserID,
						object dtCreateDateFrom,
						object dtCreateDateTo,
						object iUpdateByUserID,
						object dtUpdateDateFrom,
						object dtUpdateDateTo
						
						)
        {
            try
            {
				
				using(SqlDataReader drHoliday = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_HolidayList",
					sKeyWords ,
					dtHolidayStartdateFrom,
					dtHolidayStartdateTo,
					dtHolidayEnddateFrom,
					dtHolidayEnddateTo,
					iRecurranceParentID,
					bIsNeedApproval,
					iCreateByUserID,
					dtCreateDateFrom,
					dtCreateDateTo,
					iUpdateByUserID,
					dtUpdateDateFrom,
					dtUpdateDateTo
					))
            	{
					if (drHoliday.HasRows)
                    {
						while (drHoliday.Read())
						{
							Holiday oHoliday =  new Holiday();		
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
			catch(Exception ex)
			{
				throw ex;
			}
        }

		
		public bool DAL_Load()
        {
            try
            {
				using(SqlDataReader drHoliday = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_HolidayList"))
            	{
					if (drHoliday.HasRows)
                    {
						while (drHoliday.Read())
						{
							Holiday oHoliday =  new Holiday();		
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
				foreach (Holiday oHoliday in m_oHolidayList)
				{
					bool bIsSuccess = oHoliday.DAL_Update(p_oTrans);
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
				foreach (Holiday oHoliday in m_oHolidayList)
				{
					bool bIsSuccess = oHoliday.DAL_Add(p_oTrans);
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
				foreach (Holiday oHoliday in m_oHolidayList)
				{
					bool bIsSuccess = oHoliday.DAL_Delete(p_oTrans);
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
		#endregion
	} //** Class
} //** Name Space
