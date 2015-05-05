using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class SysParamCollection
    {
        public bool DAL_LoadOrderByIndex(
                        string sKeyWords,
                        object bIsVisible,
                        object iSysParamGroupID,
                        object bIsEncrypted

                        )
        {
            try
            {

                using (SqlDataReader drSysParam = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_SysParamListOrderByIndex",
                    sKeyWords,
                    bIsVisible,
                    iSysParamGroupID,
                    bIsEncrypted
                    ))
                {
                    if (drSysParam.HasRows)
                    {
                        while (drSysParam.Read())
                        {
                            SysParam oSysParam = new SysParam();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
