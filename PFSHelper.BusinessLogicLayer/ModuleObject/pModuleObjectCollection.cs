using System;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class ModuleObjectCollection
    {
        public bool DAL_LoadForApprovalLogBinding()
        {
            try
            {
                using (SqlDataReader drModuleObject = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectListForApprovalLogBinding"))
                {
                    if (drModuleObject.HasRows)
                    {
                        while (drModuleObject.Read())
                        {
                            ModuleObject oModuleObject = new ModuleObject();
                            oModuleObject.ModuleObjectID = Convert.ToInt32(drModuleObject["PFS_MODULE_OBJECT_ID"]);
                            oModuleObject.ModuleID = Convert.ToInt32(drModuleObject["PFS_MODULE_ID"]);
                            oModuleObject.ObjectCode = Convert.ToString(drModuleObject["OBJECT_CODE"]);
                            oModuleObject.ObjectName = Convert.ToString(drModuleObject["OBJECT_NAME"]);
                            oModuleObject.ObjectDescr = Convert.ToString(drModuleObject["OBJECT_DESCR"]);
                            oModuleObject.IndexOrder = Convert.ToInt16(drModuleObject["INDEX_ORDER"]);
                            this.Add(oModuleObject);
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
    }
}
