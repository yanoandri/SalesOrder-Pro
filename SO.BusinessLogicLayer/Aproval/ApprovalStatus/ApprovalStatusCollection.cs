


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

namespace SO.BusinessLogicLayer
{
	//Standard class autogenerated by PFS Generator v5.0
	[System.Xml.Serialization.XmlRoot("ApprovalStatus")]
	public class ApprovalStatusCollection  : ICollection
	{
		#region Region: Member Variables///////////////////////////////////////////////////////////
        private ArrayList m_oApprovalStatusList = new ArrayList();
		private int m_iPageSize = 10;
		private int m_iPageNumber = 1;
		#endregion
		#region Region: Constructor///////////////////////////////////////////////////////////////////
		public ApprovalStatusCollection()
		{
			m_iPageSize = 10;
			m_iPageNumber = 1;
		}
		#endregion
		#region Region: Properties///////////////////////////////////////////////////////////////////		
		public ApprovalStatus this[int index]
        {
            get { return (ApprovalStatus)m_oApprovalStatusList[index]; }
        }
        public int Count
        {
            get { return m_oApprovalStatusList.Count; }
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
			m_oApprovalStatusList.Sort(oComparer);
		}

		public void Reverse()
		{
			m_oApprovalStatusList.Reverse();
		}

        public void CopyTo(Array a, int index)
        {
            m_oApprovalStatusList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oApprovalStatusList.GetEnumerator();
        }
        public void Add(ApprovalStatus oObject)
        {
            m_oApprovalStatusList.Add(oObject);
        }
		public void RemoveAt(int index)
		{
			m_oApprovalStatusList.RemoveAt(index);
		}
		#endregion
		#region Region: Field Enumeration ///////////////////////////////////////////////////////////
		public enum ApprovalStatusFields 
		{
			ApprovalStatusID,
			ApprovalStatusCode,
			Description
		}//End Enum
		#endregion
		#region Region: Sort Method///////////////////////////////////////////////////////////////////
		public void Sort (ApprovalStatusFields sortField, bool isAscending) 
		{
			switch (sortField) 
			{		
					
			case ApprovalStatusFields.ApprovalStatusID:
				this.Sort(new ApprovalStatusIDComparer());
				break;
		
			case ApprovalStatusFields.ApprovalStatusCode:
				this.Sort(new ApprovalStatusCodeComparer());
				break;
		
			case ApprovalStatusFields.Description:
				this.Sort(new DescriptionComparer());
				break;
			}
			if(!isAscending) this.Reverse();
		}//End SortField
		#endregion
		#region Region: IComparer///////////////////////////////////////////////////////////////////

		private sealed class ApprovalStatusIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				ApprovalStatus first = (ApprovalStatus) x;
				ApprovalStatus second = (ApprovalStatus) y;
				return first.ApprovalStatusID.CompareTo(second.ApprovalStatusID);
			}
		}	
		private sealed class ApprovalStatusCodeComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				ApprovalStatus first = (ApprovalStatus) x;
				ApprovalStatus second = (ApprovalStatus) y;
				return first.ApprovalStatusCode.CompareTo(second.ApprovalStatusCode);
			}
		}	
		private sealed class DescriptionComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				ApprovalStatus first = (ApprovalStatus) x;
				ApprovalStatus second = (ApprovalStatus) y;
				return first.Description.CompareTo(second.Description);
			}
		}	
		#endregion
		#region Region: Data Access Layer ///////////////////////////////////////////////////////////////////
		public bool DAL_Load(
						string sKeyWords
						)
        {
            try
            {
				
				using(SqlDataReader drApprovalStatus = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalStatusList",
					sKeyWords 
					))
            	{
					if (drApprovalStatus.HasRows)
                    {
						while (drApprovalStatus.Read())
						{
							ApprovalStatus oApprovalStatus =  new ApprovalStatus();		
							oApprovalStatus.ApprovalStatusID = Convert.ToInt16(drApprovalStatus["COM_APPROVAL_STATUS_ID"]);
							oApprovalStatus.ApprovalStatusCode = Convert.ToString(drApprovalStatus["COM_APPROVAL_STATUS_CODE"]);
							oApprovalStatus.Description = Convert.ToString(drApprovalStatus["DESCRIPTION"]);
							this.Add(oApprovalStatus);
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
				using(SqlDataReader drApprovalStatus = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalStatusList"))
            	{
					if (drApprovalStatus.HasRows)
                    {
						while (drApprovalStatus.Read())
						{
							ApprovalStatus oApprovalStatus =  new ApprovalStatus();		
							oApprovalStatus.ApprovalStatusID = Convert.ToInt16(drApprovalStatus["COM_APPROVAL_STATUS_ID"]);
							oApprovalStatus.ApprovalStatusCode = Convert.ToString(drApprovalStatus["COM_APPROVAL_STATUS_CODE"]);
							oApprovalStatus.Description = Convert.ToString(drApprovalStatus["DESCRIPTION"]);
							this.Add(oApprovalStatus);
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
				foreach (ApprovalStatus oApprovalStatus in m_oApprovalStatusList)
				{
					bool bIsSuccess = oApprovalStatus.DAL_Update(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oApprovalStatusList.Count)
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
				foreach (ApprovalStatus oApprovalStatus in m_oApprovalStatusList)
				{
					bool bIsSuccess = oApprovalStatus.DAL_Add(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oApprovalStatusList.Count)
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
				foreach (ApprovalStatus oApprovalStatus in m_oApprovalStatusList)
				{
					bool bIsSuccess = oApprovalStatus.DAL_Delete(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oApprovalStatusList.Count)
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
