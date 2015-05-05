using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class ModuleObjectMemberGroupCollection
    {
        public void Remove(ModuleObjectMemberGroup Object)
        {
            m_oModuleObjectMemberGroupList.Remove(Object);
        }

        public bool DAL_LoadByGroupID(object iGroupID)
        {
            try
            {
                using (SqlDataReader drModuleObjectMemberGroup = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberGroupList",
                    null,
                    null,
                    null,
                    null,
                    iGroupID
                    ))
                {
                    if (drModuleObjectMemberGroup.HasRows)
                    {
                        while (drModuleObjectMemberGroup.Read())
                        {
                            ModuleObjectMemberGroup oModuleObjectMemberGroup = new ModuleObjectMemberGroup();
                            oModuleObjectMemberGroup.ModuleObjectMemberGroupID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_OBJECT_MEMBER_GROUP_ID"]);
                            oModuleObjectMemberGroup.ModuleID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_ID"]);
                            oModuleObjectMemberGroup.ModuleObjectID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_OBJECT_ID"]);
                            oModuleObjectMemberGroup.ModuleObjectMemberID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oModuleObjectMemberGroup.GroupID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_GROUP_ID"]);
                            oModuleObjectMemberGroup.ModuleCode = Convert.ToString(drModuleObjectMemberGroup["MODULE_CODE"]);
                            oModuleObjectMemberGroup.ModuleName = Convert.ToString(drModuleObjectMemberGroup["MODULE_NAME"]);
                            oModuleObjectMemberGroup.ObjectCode = Convert.ToString(drModuleObjectMemberGroup["OBJECT_CODE"]);
                            oModuleObjectMemberGroup.ObjectName = Convert.ToString(drModuleObjectMemberGroup["OBJECT_NAME"]);
                            oModuleObjectMemberGroup.MemberCode = Convert.ToString(drModuleObjectMemberGroup["MEMBER_CODE"]);
                            oModuleObjectMemberGroup.MemberName = Convert.ToString(drModuleObjectMemberGroup["MEMBER_NAME"]);
                            oModuleObjectMemberGroup.GroupName = Convert.ToString(drModuleObjectMemberGroup["GROUP_NAME"]);
                            this.Add(oModuleObjectMemberGroup);
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
        public bool DAL_LoadOrderByGroupName(string p_sKeyword, int? p_iModuleID, int? p_iModuleObjectID, int? p_iModuleObjectMemberID, int? p_iGroupID)
        {
            try
            {
                using (SqlDataReader drModuleObjectMemberGroup = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberGroupListOrderByGroupName",
                    p_sKeyword,
                    p_iModuleID,
                    p_iModuleObjectID,
                    p_iModuleObjectMemberID,
                    p_iGroupID
                    ))
                {
                    if (drModuleObjectMemberGroup.HasRows)
                    {
                        while (drModuleObjectMemberGroup.Read())
                        {
                            ModuleObjectMemberGroup oModuleObjectMemberGroup = new ModuleObjectMemberGroup();
                            oModuleObjectMemberGroup.ModuleObjectMemberGroupID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_OBJECT_MEMBER_GROUP_ID"]);
                            oModuleObjectMemberGroup.ModuleID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_ID"]);
                            oModuleObjectMemberGroup.ModuleObjectID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_OBJECT_ID"]);
                            oModuleObjectMemberGroup.ModuleObjectMemberID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oModuleObjectMemberGroup.GroupID = Convert.ToInt32(drModuleObjectMemberGroup["PFS_GROUP_ID"]);
                            oModuleObjectMemberGroup.ModuleCode = Convert.ToString(drModuleObjectMemberGroup["MODULE_CODE"]);
                            oModuleObjectMemberGroup.ModuleName = Convert.ToString(drModuleObjectMemberGroup["MODULE_NAME"]);
                            oModuleObjectMemberGroup.ObjectCode = Convert.ToString(drModuleObjectMemberGroup["OBJECT_CODE"]);
                            oModuleObjectMemberGroup.ObjectName = Convert.ToString(drModuleObjectMemberGroup["OBJECT_NAME"]);
                            oModuleObjectMemberGroup.MemberCode = Convert.ToString(drModuleObjectMemberGroup["MEMBER_CODE"]);
                            oModuleObjectMemberGroup.MemberName = Convert.ToString(drModuleObjectMemberGroup["MEMBER_NAME"]);
                            oModuleObjectMemberGroup.GroupName = Convert.ToString(drModuleObjectMemberGroup["GROUP_NAME"]);
                            this.Add(oModuleObjectMemberGroup);
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
        public bool DAL_DeleteByGroupID(int iGroupID)
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                bool bIsSuccess = DAL_DeleteByGroupID(iGroupID, oTrans);

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
        public bool DAL_DeleteByGroupID(int p_iGroupID,SqlTransaction p_oTrans)
        {
            try
            {
                int iError = Convert.ToInt32(SqlHelper.ExecuteScalar(p_oTrans, "uspPFS_ModuleObjectMemberGroupDeleteByGroupID", p_iGroupID));

                return (iError == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }	
    }
}
