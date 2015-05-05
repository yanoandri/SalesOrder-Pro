


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
// $Log:$
//
#endregion

namespace PFSHelper.BusinessLogicLayer
{
	//Standard class autogenerated by PFS Generator v5.0
	public partial class ModuleObjectMember
	{
		#region Region: Member Variables///////////////////////////////////////////////////////////
		protected int m_iModuleObjectMemberID = 0;
		protected int m_iModuleObjectID = 0;
		protected string m_sMemberCode = "NONE";
		protected string m_sMemberName = "NONE";
		protected string m_sMemberDescr = "NONE";
		protected short m_iIndexOrder = 0;
		protected bool m_bIsWithApprovalProccess = false;
		protected string m_sObjectCode = "NONE";
		protected string m_sObjectName = "NONE";
		#endregion
		
		#region Region: Constructor////////////////////////////////////////////////////////////////
		public ModuleObjectMember()
		{
			m_iModuleObjectMemberID = -1;			
		}	
		public ModuleObjectMember(int iID)
		{
			m_iModuleObjectMemberID = iID;
		}

		public ModuleObjectMember(
			int iModuleObjectMemberID,
			int iModuleObjectID,
			string sMemberCode,
			string sMemberName,
			string sMemberDescr,
			short iIndexOrder,
			bool bIsWithApprovalProccess
			)
		{
			m_iModuleObjectMemberID = iModuleObjectMemberID;
			m_iModuleObjectID = iModuleObjectID;
			m_sMemberCode = sMemberCode;
			m_sMemberName = sMemberName;
			m_sMemberDescr = sMemberDescr;
			m_iIndexOrder = iIndexOrder;
			m_bIsWithApprovalProccess = bIsWithApprovalProccess;
		}

		#endregion
		
		#region Region: Properties/////////////////////////////////////////////////////////////////
		public int ModuleObjectMemberID
		{
			get {return m_iModuleObjectMemberID;}
			set {m_iModuleObjectMemberID = value;}
		}

		public int ModuleObjectID
		{
			get {return m_iModuleObjectID;}
			set {m_iModuleObjectID = value;}
		}

		public string MemberCode
		{
			get {return m_sMemberCode;}
			set {m_sMemberCode = value;}
		}

		public string MemberName
		{
			get {return m_sMemberName;}
			set {m_sMemberName = value;}
		}

		public string MemberDescr
		{
			get {return m_sMemberDescr;}
			set {m_sMemberDescr = value;}
		}

		public short IndexOrder
		{
			get {return m_iIndexOrder;}
			set {m_iIndexOrder = value;}
		}

		public bool IsWithApprovalProccess
		{
			get {return m_bIsWithApprovalProccess;}
			set {m_bIsWithApprovalProccess = value;}
		}

		public string ObjectCode
		{
			get {return m_sObjectCode;}
			set {m_sObjectCode = value;}
		}

		public string ObjectName
		{
			get {return m_sObjectName;}
			set {m_sObjectName = value;}
		}
		#endregion
		
		#region Region: Data Access Methods////////////////////////////////////////////////////////
		public bool DAL_Load()
        {
			bool bIsSuccess = false;
            try
            {
				using(SqlDataReader drModuleObjectMember = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberGet", m_iModuleObjectMemberID))
            	{
					if(drModuleObjectMember.Read())
            		{      
						m_iModuleObjectMemberID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_MEMBER_ID"]);
						m_iModuleObjectID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_ID"]);
						m_sMemberCode = Convert.ToString(drModuleObjectMember["MEMBER_CODE"]);
						m_sMemberName = Convert.ToString(drModuleObjectMember["MEMBER_NAME"]);
						m_sMemberDescr = Convert.ToString(drModuleObjectMember["MEMBER_DESCR"]);
						m_iIndexOrder = Convert.ToInt16(drModuleObjectMember["INDEX_ORDER"]);
						m_bIsWithApprovalProccess = Convert.ToBoolean(drModuleObjectMember["IS_WITH_APPROVAL_PROCCESS"]);
						m_sObjectCode = Convert.ToString(drModuleObjectMember["OBJECT_CODE"]);
						m_sObjectName = Convert.ToString(drModuleObjectMember["OBJECT_NAME"]);
						
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
		public bool DAL_LoadWithChild()
        {
			bool bIsSuccess = false;
            try
            {
				using(SqlDataReader drModuleObjectMember = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberGet", m_iModuleObjectMemberID))
            	{
					if(drModuleObjectMember.Read())
            		{      
						m_iModuleObjectMemberID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_MEMBER_ID"]);
						m_iModuleObjectID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_ID"]);
						m_sMemberCode = Convert.ToString(drModuleObjectMember["MEMBER_CODE"]);
						m_sMemberName = Convert.ToString(drModuleObjectMember["MEMBER_NAME"]);
						m_sMemberDescr = Convert.ToString(drModuleObjectMember["MEMBER_DESCR"]);
						m_iIndexOrder = Convert.ToInt16(drModuleObjectMember["INDEX_ORDER"]);
						m_bIsWithApprovalProccess = Convert.ToBoolean(drModuleObjectMember["IS_WITH_APPROVAL_PROCCESS"]);
						m_sObjectCode = Convert.ToString(drModuleObjectMember["OBJECT_CODE"]);
						m_sObjectName = Convert.ToString(drModuleObjectMember["OBJECT_NAME"]);
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
				using(SqlDataReader drModuleObjectMember = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberGet",iID))
            	{
					if(drModuleObjectMember.Read())
            		{      
						m_iModuleObjectMemberID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_MEMBER_ID"]);
						m_iModuleObjectID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_ID"]);
						m_sMemberCode = Convert.ToString(drModuleObjectMember["MEMBER_CODE"]);
						m_sMemberName = Convert.ToString(drModuleObjectMember["MEMBER_NAME"]);
						m_sMemberDescr = Convert.ToString(drModuleObjectMember["MEMBER_DESCR"]);
						m_iIndexOrder = Convert.ToInt16(drModuleObjectMember["INDEX_ORDER"]);
						m_bIsWithApprovalProccess = Convert.ToBoolean(drModuleObjectMember["IS_WITH_APPROVAL_PROCCESS"]);
						m_sObjectCode = Convert.ToString(drModuleObjectMember["OBJECT_CODE"]);
						m_sObjectName = Convert.ToString(drModuleObjectMember["OBJECT_NAME"]);
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
		public bool DAL_LoadWithChild(int iID)
        {
			bool bIsSuccess = false;
            try
            {
				using(SqlDataReader drModuleObjectMember = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberGet",iID))
            	{
					if(drModuleObjectMember.Read())
            		{      
						m_iModuleObjectMemberID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_MEMBER_ID"]);
						m_iModuleObjectID = Convert.ToInt32(drModuleObjectMember["PFS_MODULE_OBJECT_ID"]);
						m_sMemberCode = Convert.ToString(drModuleObjectMember["MEMBER_CODE"]);
						m_sMemberName = Convert.ToString(drModuleObjectMember["MEMBER_NAME"]);
						m_sMemberDescr = Convert.ToString(drModuleObjectMember["MEMBER_DESCR"]);
						m_iIndexOrder = Convert.ToInt16(drModuleObjectMember["INDEX_ORDER"]);
						m_bIsWithApprovalProccess = Convert.ToBoolean(drModuleObjectMember["IS_WITH_APPROVAL_PROCCESS"]);
						m_sObjectCode = Convert.ToString(drModuleObjectMember["OBJECT_CODE"]);
						m_sObjectName = Convert.ToString(drModuleObjectMember["OBJECT_NAME"]);
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
				if (m_iModuleObjectMemberID > 0)
				{
					int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_ModuleObjectMemberUpdate",
					m_iModuleObjectMemberID,
										m_iModuleObjectID,
										m_sMemberCode,
										m_sMemberName,
										m_sMemberDescr,
										m_iIndexOrder,
										m_bIsWithApprovalProccess
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
		
		public bool DAL_UpdateWithChild() 
		{
			SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
			try
			{
				bool bIsSuccess = false;
				bIsSuccess = DAL_UpdateWithChild(oTrans);
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
		public bool DAL_UpdateWithChild(SqlTransaction p_oTrans) 
		{
			try
			{
				bool bIsSuccess = false;
				if (m_iModuleObjectMemberID > 0)
				{
					int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_ModuleObjectMemberUpdate",
					m_iModuleObjectMemberID,
										m_iModuleObjectID,
										m_sMemberCode,
										m_sMemberName,
										m_sMemberDescr,
										m_iIndexOrder,
										m_bIsWithApprovalProccess
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
                int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_ModuleObjectMemberDelete", m_iModuleObjectMemberID);

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
                m_iModuleObjectMemberID = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_ModuleObjectMemberAdd", 

					m_iModuleObjectID,
					m_sMemberCode,
					m_sMemberName,
					m_sMemberDescr,
					m_iIndexOrder,
					m_bIsWithApprovalProccess
					));
					
				bool bIsSuccess = (m_iModuleObjectMemberID >=0);
				
				return bIsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
		//*** This section is a temporary data access for combo, Radio Button etc. ToDo: Delete this and use the proper class definition
		public static SqlDataReader DAL_ModuleObjectMemberModuleObjectList()
		{
			try
			{
				SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "LOOKUP_uspPFS_ModuleObjectMemberModuleObjectList"); 
				return dr;
			}
			catch(Exception ex)
			{
				throw(ex);
			}			
		}		
		#endregion
	} //** Class
} //** Name Space
