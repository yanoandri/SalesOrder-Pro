


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
	[System.Xml.Serialization.XmlRoot("SysParam")]
	public partial class SysParamCollection  : ICollection
	{
		#region Region: Member Variables///////////////////////////////////////////////////////////
        private ArrayList m_oSysParamList = new ArrayList();
		private int m_iPageSize = 10;
		private int m_iPageNumber = 1;
		#endregion
		#region Region: Constructor///////////////////////////////////////////////////////////////////
		public SysParamCollection()
		{
			m_iPageSize = 10;
			m_iPageNumber = 1;
		}
		#endregion
		#region Region: Properties///////////////////////////////////////////////////////////////////		
		public SysParam this[int index]
        {
            get { return (SysParam)m_oSysParamList[index]; }
        }
        public int Count
        {
            get { return m_oSysParamList.Count; }
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
			m_oSysParamList.Sort(oComparer);
		}

		public void Reverse()
		{
			m_oSysParamList.Reverse();
		}

        public void CopyTo(Array a, int index)
        {
            m_oSysParamList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oSysParamList.GetEnumerator();
        }
        public void Add(SysParam oObject)
        {
            m_oSysParamList.Add(oObject);
        }
		public void RemoveAt(int index)
		{
			m_oSysParamList.RemoveAt(index);
		}
		#endregion
		#region Region: Field Enumeration ///////////////////////////////////////////////////////////
		public enum SysParamFields 
		{
			Code,
			Description,
			Value,
			DataType,
			IsVisible,
			SysParamGroupID,
			SysParamName,
			IndexOrder,
			IsEncrypted,
			ParamGroupName
		}//End Enum
		#endregion
		#region Region: Sort Method///////////////////////////////////////////////////////////////////
		public void Sort (SysParamFields sortField, bool isAscending) 
		{
			switch (sortField) 
			{		
					
			case SysParamFields.Code:
				this.Sort(new CodeComparer());
				break;
		
			case SysParamFields.Description:
				this.Sort(new DescriptionComparer());
				break;
		
			case SysParamFields.Value:
				this.Sort(new ValueComparer());
				break;
		
			case SysParamFields.DataType:
				this.Sort(new DataTypeComparer());
				break;
		
			case SysParamFields.IsVisible:
				this.Sort(new IsVisibleComparer());
				break;
		
			case SysParamFields.SysParamGroupID:
				this.Sort(new SysParamGroupIDComparer());
				break;
		
			case SysParamFields.SysParamName:
				this.Sort(new SysParamNameComparer());
				break;
		
			case SysParamFields.IndexOrder:
				this.Sort(new IndexOrderComparer());
				break;
		
			case SysParamFields.IsEncrypted:
				this.Sort(new IsEncryptedComparer());
				break;
		
			case SysParamFields.ParamGroupName:
				this.Sort(new ParamGroupNameComparer());
				break;
			}
			if(!isAscending) this.Reverse();
		}//End SortField
		#endregion
		#region Region: IComparer///////////////////////////////////////////////////////////////////

		private sealed class CodeComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.Code.CompareTo(second.Code);
			}
		}	
		private sealed class DescriptionComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.Description.CompareTo(second.Description);
			}
		}	
		private sealed class ValueComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.Value.CompareTo(second.Value);
			}
		}	
		private sealed class DataTypeComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.DataType.CompareTo(second.DataType);
			}
		}	
		private sealed class IsVisibleComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.IsVisible.CompareTo(second.IsVisible);
			}
		}	
		private sealed class SysParamGroupIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.SysParamGroupID.CompareTo(second.SysParamGroupID);
			}
		}	
		private sealed class SysParamNameComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.SysParamName.CompareTo(second.SysParamName);
			}
		}	
		private sealed class IndexOrderComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.IndexOrder.CompareTo(second.IndexOrder);
			}
		}	
		private sealed class IsEncryptedComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.IsEncrypted.CompareTo(second.IsEncrypted);
			}
		}	
		private sealed class ParamGroupNameComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				SysParam first = (SysParam) x;
				SysParam second = (SysParam) y;
				return first.ParamGroupName.CompareTo(second.ParamGroupName);
			}
		}	
		#endregion
		#region Region: Data Access Layer ///////////////////////////////////////////////////////////////////
		public bool DAL_Load(
						string sKeyWords,
						object bIsVisible,
						object iSysParamGroupID,
						object bIsEncrypted
						
						)
        {
            try
            {
				
				using(SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamList",
					sKeyWords ,
					bIsVisible,
					iSysParamGroupID,
					bIsEncrypted
					))
            	{
					if (drSysParam.HasRows)
                    {
						while (drSysParam.Read())
						{
							SysParam oSysParam =  new SysParam();		
							oSysParam.Code = Convert.ToString(drSysParam["CODE"]);
							oSysParam.Description = Convert.ToString(drSysParam["DESCRIPTION"]);
							oSysParam.Value = Convert.ToString(drSysParam["VALUE"]);
							oSysParam.DataType = Convert.ToString(drSysParam["DATA_TYPE"]);
							oSysParam.IsVisible = Convert.ToBoolean(drSysParam["IS_VISIBLE"]);
							oSysParam.SysParamGroupID = Convert.ToInt32(drSysParam["PFS_SYS_PARAM_GROUP_ID"]);
							oSysParam.SysParamName = Convert.ToString(drSysParam["SYS_PARAM_NAME"]);
							oSysParam.IndexOrder = Convert.ToInt32(drSysParam["INDEX_ORDER"]);
							oSysParam.IsEncrypted = Convert.ToBoolean(drSysParam["IS_ENCRYPTED"]);
							oSysParam.ParamGroupName = Convert.ToString(drSysParam["PARAM_GROUP_NAME"]);
							this.Add(oSysParam);
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
				using(SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamList"))
            	{
					if (drSysParam.HasRows)
                    {
						while (drSysParam.Read())
						{
							SysParam oSysParam =  new SysParam();		
							oSysParam.Code = Convert.ToString(drSysParam["CODE"]);
							oSysParam.Description = Convert.ToString(drSysParam["DESCRIPTION"]);
							oSysParam.Value = Convert.ToString(drSysParam["VALUE"]);
							oSysParam.DataType = Convert.ToString(drSysParam["DATA_TYPE"]);
							oSysParam.IsVisible = Convert.ToBoolean(drSysParam["IS_VISIBLE"]);
							oSysParam.SysParamGroupID = Convert.ToInt32(drSysParam["PFS_SYS_PARAM_GROUP_ID"]);
							oSysParam.SysParamName = Convert.ToString(drSysParam["SYS_PARAM_NAME"]);
							oSysParam.IndexOrder = Convert.ToInt32(drSysParam["INDEX_ORDER"]);
							oSysParam.IsEncrypted = Convert.ToBoolean(drSysParam["IS_ENCRYPTED"]);
							oSysParam.ParamGroupName = Convert.ToString(drSysParam["PARAM_GROUP_NAME"]);
							this.Add(oSysParam);
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
		

		public bool DAL_LoadBySysParamGroupID(Int64 iID)
        {
            try
            {
				return this.DAL_Load(
					null,
					null,
					iID,
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
				foreach (SysParam oSysParam in m_oSysParamList)
				{
					bool bIsSuccess = oSysParam.DAL_Update(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oSysParamList.Count)
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
				foreach (SysParam oSysParam in m_oSysParamList)
				{
					bool bIsSuccess = oSysParam.DAL_Add(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oSysParamList.Count)
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
				foreach (SysParam oSysParam in m_oSysParamList)
				{
					bool bIsSuccess = oSysParam.DAL_Delete(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oSysParamList.Count)
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
