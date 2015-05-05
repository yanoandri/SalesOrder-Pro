


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
    public partial class SysParamGroup
    {
        #region Region: Member Variables///////////////////////////////////////////////////////////
        protected int m_iSysParamGroupID = -1;
        protected string m_sParamGroupName = string.Empty;
        protected string m_sGroupDescr = string.Empty;
        protected int m_iIndexOrder = -1;
        protected bool m_bIsVisible = true;
        protected SysParamCollection m_oSysParam = new SysParamCollection();
        #endregion

        #region Region: Constructor////////////////////////////////////////////////////////////////
        public SysParamGroup()
        {
            
        }
        public SysParamGroup(int iID)
        {
            m_iSysParamGroupID = iID;
        }

        #endregion

        #region Region: Properties/////////////////////////////////////////////////////////////////

        public int SysParamGroupID
        {
            get { return m_iSysParamGroupID; }
            set { m_iSysParamGroupID = value; }
        }
        public string ParamGroupName
        {
            get { return m_sParamGroupName; }
            set { m_sParamGroupName = value; }
        }
        public string GroupDescr
        {
            get { return m_sGroupDescr; }
            set { m_sGroupDescr = value; }
        }
        public int IndexOrder
        {
            get { return m_iIndexOrder; }
            set { m_iIndexOrder = value; }
        }
        public bool IsVisible
        {
            get { return m_bIsVisible; }
            set { m_bIsVisible = value; }
        }
        public SysParamCollection SysParam
        {
            get { return m_oSysParam; }
            set { m_oSysParam = value; }
        }
        #endregion

        #region Region: Data Access Methods////////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamGet", m_iSysParamGroupID))
                {
                    if (drSysParam.Read())
                    {
                        m_iSysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                        m_sParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                        m_sGroupDescr = Convert.ToString(drSysParam["group_descr"]);
                        m_iIndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                        m_bIsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
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
        public bool DAL_Load(int iID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamGet", iID))
                {
                    if (drSysParam.Read())
                    {
                        m_iSysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                        m_sParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                        m_sGroupDescr = Convert.ToString(drSysParam["group_descr"]);
                        m_iIndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                        m_bIsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
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

        public bool DAL_LoadWithChild()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamGet", m_iSysParamGroupID))
                {
                    if (drSysParam.Read())
                    {
                        m_iSysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                        m_sParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                        m_sGroupDescr = Convert.ToString(drSysParam["group_descr"]);
                        m_iIndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                        m_bIsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
                        m_oSysParam.DAL_Load(null, true, m_iSysParamGroupID,null);
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
        public bool DAL_LoadWithChild(int iID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamGet", iID))
                {
                    if (drSysParam.Read())
                    {
                        m_iSysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                        m_sParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                        m_sGroupDescr = Convert.ToString(drSysParam["group_descr"]);
                        m_iIndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                        m_bIsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
                        m_oSysParam.DAL_Load(null, true, m_iSysParamGroupID,null);
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


        //public bool DAL_Update()
        //{
        //    SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
        //    SqlTransaction oTrans = oConn.BeginTransaction();
        //    try
        //    {
        //        bool bIsSuccess = false;
        //        bIsSuccess = DAL_Update(oTrans);
        //        if (!bIsSuccess)
        //        {
        //            oTrans.Rollback();
        //            return false;
        //        }

        //        oTrans.Commit();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        oTrans.Rollback();
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        PFSDataBaseAccess.CloseConnection(ref oConn);
        //    }
        //}
        //public bool DAL_Update(SqlTransaction p_oTrans)
        //{
        //    try
        //    {
        //        bool bIsSuccess = false;
        //        if (!m_iSysParamGroupID.Equals(string.Empty))
        //        {
        //            int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_SysParamUpdate",
        //            m_iSysParamGroupID,
        //                                m_sParamGroupName,
        //                                m_sGroupDescr,
        //                                m_iIndexOrder,
        //            ));
        //            bIsSuccess = (iError == 0);
        //        }
        //        else
        //        {
        //            //bIsSuccess = DAL_Add(p_oTrans);
        //        }
        //        return (bIsSuccess);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool DAL_Delete()
        //{
        //    SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
        //    SqlTransaction oTrans = oConn.BeginTransaction();
        //    try
        //    {
        //        bool bIsSuccess = DAL_Delete(oTrans);

        //        if (!bIsSuccess)
        //        {
        //            oTrans.Rollback();
        //            return false;
        //        }

        //        oTrans.Commit();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        oTrans.Rollback();
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        PFSDataBaseAccess.CloseConnection(ref oConn);
        //    }
        //}
        //public bool DAL_Delete(SqlTransaction p_oTrans)
        //{
        //    try
        //    {

        //        int iRowAffected = SqlHelper.ExecuteNonQuery(p_oTrans, "uspPFS_SysParamDelete", m_iSysParamGroupID);

        //        return (iRowAffected > 0);
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw (ex);
        //    }
        //}

        //public bool DAL_Add()
        //{
        //    SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
        //    SqlTransaction oTrans = oConn.BeginTransaction();
        //    try
        //    {
        //        bool bIsSuccess = DAL_Add(oTrans);

        //        if (!bIsSuccess)
        //        {
        //            oTrans.Rollback();
        //            return false;
        //        }

        //        oTrans.Commit();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        oTrans.Rollback();
        //        throw (ex);
        //    }
        //    finally
        //    {
        //        PFSDataBaseAccess.CloseConnection(ref oConn);
        //    }
        //}
        //public bool DAL_Add(SqlTransaction p_oTrans)
        //{
        //    try
        //    {
        //        m_sCode = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_SysParamAdd",

        //            m_sDescription,
        //            m_sValue,
        //            m_sDataType,
        //            m_bIsVisible,
        //            m_sGroupName
        //            ));

        //        bool bIsSuccess = (m_sCode >= 0);


        //        return bIsSuccess;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //*** This section is a temporary data access for combo, Radio Button etc. ToDo: Delete this and use the proper class definition
        #endregion
    } //** Class
} //** Name Space
