


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
	[System.Xml.Serialization.XmlRoot("Module")]
	public partial class ModuleCollection  : ICollection
	{
		#region Region: Member Variables///////////////////////////////////////////////////////////
        private ArrayList m_oModuleList = new ArrayList();
		private int m_iPageSize = 10;
		private int m_iPageNumber = 1;
		#endregion
		#region Region: Constructor///////////////////////////////////////////////////////////////////
		public ModuleCollection()
		{
			m_iPageSize = 10;
			m_iPageNumber = 1;
		}
		#endregion
		#region Region: Properties///////////////////////////////////////////////////////////////////		
		public Module this[int index]
        {
            get { return (Module)m_oModuleList[index]; }
        }
        public int Count
        {
            get { return m_oModuleList.Count; }
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
			m_oModuleList.Sort(oComparer);
		}

		public void Reverse()
		{
			m_oModuleList.Reverse();
		}

        public void CopyTo(Array a, int index)
        {
            m_oModuleList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oModuleList.GetEnumerator();
        }
        public void Add(Module oObject)
        {
            m_oModuleList.Add(oObject);
        }
		public void RemoveAt(int index)
		{
			m_oModuleList.RemoveAt(index);
		}
		#endregion
		#region Region: Field Enumeration ///////////////////////////////////////////////////////////
		public enum ModuleFields 
		{
			ModuleID,
			ModuleCode,
			ModuleName,
			ModuleDescr,
			IndexOrder
		}//End Enum
		#endregion
		#region Region: Sort Method///////////////////////////////////////////////////////////////////
		public void Sort (ModuleFields sortField, bool isAscending) 
		{
			switch (sortField) 
			{		
					
			case ModuleFields.ModuleID:
				this.Sort(new ModuleIDComparer());
				break;
		
			case ModuleFields.ModuleCode:
				this.Sort(new ModuleCodeComparer());
				break;
		
			case ModuleFields.ModuleName:
				this.Sort(new ModuleNameComparer());
				break;
		
			case ModuleFields.ModuleDescr:
				this.Sort(new ModuleDescrComparer());
				break;
		
			case ModuleFields.IndexOrder:
				this.Sort(new IndexOrderComparer());
				break;
			}
			if(!isAscending) this.Reverse();
		}//End SortField
		#endregion
		#region Region: IComparer///////////////////////////////////////////////////////////////////

		private sealed class ModuleIDComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Module first = (Module) x;
				Module second = (Module) y;
				return first.ModuleID.CompareTo(second.ModuleID);
			}
		}	
		private sealed class ModuleCodeComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Module first = (Module) x;
				Module second = (Module) y;
				return first.ModuleCode.CompareTo(second.ModuleCode);
			}
		}	
		private sealed class ModuleNameComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Module first = (Module) x;
				Module second = (Module) y;
				return first.ModuleName.CompareTo(second.ModuleName);
			}
		}	
		private sealed class ModuleDescrComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Module first = (Module) x;
				Module second = (Module) y;
				return first.ModuleDescr.CompareTo(second.ModuleDescr);
			}
		}	
		private sealed class IndexOrderComparer:IComparer
		{
			public int Compare(object x, object y) 
			{
				Module first = (Module) x;
				Module second = (Module) y;
				return first.IndexOrder.CompareTo(second.IndexOrder);
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
				
				using(SqlDataReader drModule = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleList",
					sKeyWords 
					))
            	{
					if (drModule.HasRows)
                    {
						while (drModule.Read())
						{
							Module oModule =  new Module();		
							oModule.ModuleID = Convert.ToInt32(drModule["PFS_MODULE_ID"]);
							oModule.ModuleCode = Convert.ToString(drModule["MODULE_CODE"]);
							oModule.ModuleName = Convert.ToString(drModule["MODULE_NAME"]);
							oModule.ModuleDescr = Convert.ToString(drModule["MODULE_DESCR"]);
							oModule.IndexOrder = Convert.ToInt32(drModule["INDEX_ORDER"]);
							this.Add(oModule);
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

		public bool DAL_LoadWithChild(
						string sKeyWords
						
						)
        {
            try
            {
				
				using(SqlDataReader drModule = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleList",
					sKeyWords 
					))
            	{
					if (drModule.HasRows)
                    {
						while (drModule.Read())
						{
							Module oModule =  new Module();		
							oModule.ModuleID = Convert.ToInt32(drModule["PFS_MODULE_ID"]);
							oModule.ModuleCode = Convert.ToString(drModule["MODULE_CODE"]);
							oModule.ModuleName = Convert.ToString(drModule["MODULE_NAME"]);
							oModule.ModuleDescr = Convert.ToString(drModule["MODULE_DESCR"]);
							oModule.IndexOrder = Convert.ToInt32(drModule["INDEX_ORDER"]);
							this.Add(oModule);
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
				using(SqlDataReader drModule = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleList"))
            	{
					if (drModule.HasRows)
                    {
						while (drModule.Read())
						{
							Module oModule =  new Module();		
							oModule.ModuleID = Convert.ToInt32(drModule["PFS_MODULE_ID"]);
							oModule.ModuleCode = Convert.ToString(drModule["MODULE_CODE"]);
							oModule.ModuleName = Convert.ToString(drModule["MODULE_NAME"]);
							oModule.ModuleDescr = Convert.ToString(drModule["MODULE_DESCR"]);
							oModule.IndexOrder = Convert.ToInt32(drModule["INDEX_ORDER"]);
							this.Add(oModule);
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
		
		public bool DAL_LoadWithChild()
        {
            try
            {
				using(SqlDataReader drModule = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleList"))
            	{
					if (drModule.HasRows)
                    {
						while (drModule.Read())
						{
							Module oModule =  new Module();		
							oModule.ModuleID = Convert.ToInt32(drModule["PFS_MODULE_ID"]);
							oModule.ModuleCode = Convert.ToString(drModule["MODULE_CODE"]);
							oModule.ModuleName = Convert.ToString(drModule["MODULE_NAME"]);
							oModule.ModuleDescr = Convert.ToString(drModule["MODULE_DESCR"]);
							oModule.IndexOrder = Convert.ToInt32(drModule["INDEX_ORDER"]);
							this.Add(oModule);
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
				foreach (Module oModule in m_oModuleList)
				{
					bool bIsSuccess = oModule.DAL_Update(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oModuleList.Count)
                    return false;
                else
                    return true;
			}

			catch (Exception ex)
			{
                throw ex;
			}
		}	
		
		public bool DAL_UpdateWithChild()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_UpdateWithChild(oTrans);

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
		public bool DAL_UpdateWithChild(SqlTransaction p_oTrans)
		{
			try
			{
				int iSuccessCounter = 0;
                //foreach (Module oModule in m_oModuleList)
                //{
                //    bool bIsSuccess = oModule.DAL_UpdateWithChild(p_oTrans);
                //    if (!bIsSuccess) break;
                //    iSuccessCounter++;
                //}
				if (iSuccessCounter < m_oModuleList.Count)
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
				foreach (Module oModule in m_oModuleList)
				{
					bool bIsSuccess = oModule.DAL_Add(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oModuleList.Count)
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
				foreach (Module oModule in m_oModuleList)
				{
					bool bIsSuccess = oModule.DAL_Delete(p_oTrans);
					if (!bIsSuccess) break;
                    iSuccessCounter++;
				}
				if (iSuccessCounter < m_oModuleList.Count)
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
