


using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using PFSHelper.DataAccessLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    [System.Xml.Serialization.XmlRoot("SysParam")]
    public partial class SysParamGroupCollection : Collection<SysParamGroup>
    {
        //public void Sort<TSource, TValue>(this List<TSource> source, Func<TSource, TValue> selector, bool IsAscending)
        //{
        //    var comparer = Comparer<TValue>.Default;
        //    if (IsAscending)
        //        source.Sort((x, y) => comparer.Compare(selector(x), selector(y)));
        //    else
        //        source.Sort((x, y) => comparer.Compare(selector(y), selector(x)));
        //}
        #region Region: Data Access Layer ///////////////////////////////////////////////////////////////////
        public bool DAL_Load(
                        string sKeyWords
                        )
        {
            try
            {

                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamList",
                    sKeyWords
                    ))
                {
                    if (drSysParam.HasRows)
                    {
                        while (drSysParam.Read())
                        {
                            SysParamGroup oSysParamGroup = new SysParamGroup();
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.ParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                            oSysParamGroup.GroupDescr = Convert.ToString(drSysParam["group_descr"]);
                            oSysParamGroup.IndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.IsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
                            this.Add(oSysParamGroup);
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
        public bool DAL_Load()
        {
            try
            {
                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamGroupList"))
                {
                    if (drSysParam.HasRows)
                    {
                        while (drSysParam.Read())
                        {
                            SysParamGroup oSysParamGroup = new SysParamGroup();
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.ParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                            oSysParamGroup.GroupDescr = Convert.ToString(drSysParam["group_descr"]);
                            oSysParamGroup.IndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.IsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
                            this.Add(oSysParamGroup);
                        }
                        return true;
                    }
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
        public bool DAL_LoadWithChild(
                        string sKeyWords
                        )
        {
            try
            {

                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamGroupList",
                    sKeyWords
                    ))
                {
                    if (drSysParam.HasRows)
                    {
                        while (drSysParam.Read())
                        {
                            SysParamGroup oSysParamGroup = new SysParamGroup();
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.ParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                            oSysParamGroup.GroupDescr = Convert.ToString(drSysParam["group_descr"]);
                            oSysParamGroup.IndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.IsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
                            oSysParamGroup.SysParam.DAL_Load(sKeyWords, true, oSysParamGroup.SysParamGroupID,null);
                            this.Add(oSysParamGroup);
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
        public bool DAL_LoadWithChild()
        {
            try
            {
                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamGroupList"))
                {
                    if (drSysParam.HasRows)
                    {
                        while (drSysParam.Read())
                        {
                            SysParamGroup oSysParamGroup = new SysParamGroup();
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.ParamGroupName = Convert.ToString(drSysParam["param_group_name"]);
                            oSysParamGroup.GroupDescr = Convert.ToString(drSysParam["group_descr"]);
                            oSysParamGroup.IndexOrder = Convert.ToInt32(drSysParam["index_order"]);
                            oSysParamGroup.SysParamGroupID = Convert.ToInt32(drSysParam["pfs_sys_param_group_id"]);
                            oSysParamGroup.IsVisible = Convert.ToBoolean(drSysParam["is_visible"]);
                            oSysParamGroup.SysParam.DAL_Load(null, true, oSysParamGroup.SysParamGroupID,null);
                            this.Add(oSysParamGroup);
                        }
                        return true;
                    }
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
        //public bool DAL_Update()
        //{
        //    SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
        //    SqlTransaction oTrans = oConn.BeginTransaction();
        //    try
        //    {
        //        bool bIsSuccess = DAL_Update(oTrans);

        //        if (!bIsSuccess)
        //        {
        //            oTrans.Rollback();
        //            return false;
        //        }

        //        oTrans.Commit();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
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
        //        int iSuccessCounter = 0;
        //        foreach (SysParamGroup oSysParamGroup in this)
        //        {
        //            bool bIsSuccess = oSysParamGroup.DAL_Update(p_oTrans);
        //            if (!bIsSuccess) break;
        //            iSuccessCounter++;
        //        }
        //        if (iSuccessCounter < this.Count)
        //            return false;
        //        else
        //            return true;
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
        //    catch (Exception ex)
        //    {
        //        throw ex;
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
        //        int iSuccessCounter = 0;
        //        foreach (SysParamGroup oSysParam in this)
        //        {
        //            bool bIsSuccess = oSysParam.DAL_Delete(p_oTrans);
        //            if (!bIsSuccess) break;
        //            iSuccessCounter++;
        //        }
        //        if (iSuccessCounter < this.Count)
        //            return false;
        //        else
        //            return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
    } //** Class
} //** Name Space
