using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class GroupCollection
    {
        public bool DAL_LoadWithTotalUser(
                        string sKeyWords,
                        object bIsActive,
                        object bIsNeedApproval,
                        object dtCreateDateFrom,
                        object dtCreateDateTo,
                        object iCreateByUserID,
                        object dtUpdateDateFrom,
                        object dtUpdateDateTo,
                        object iUpdateByUserID

                        )
        {
            try
            {

                using (SqlDataReader drGroup = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_GroupListWithTotalUser",
                    sKeyWords,
                    bIsActive,
                    bIsNeedApproval,
                    dtCreateDateFrom,
                    dtCreateDateTo,
                    iCreateByUserID,
                    dtUpdateDateFrom,
                    dtUpdateDateTo,
                    iUpdateByUserID
                    ))
                {
                    if (drGroup.HasRows)
                    {
                        while (drGroup.Read())
                        {
                            Group oGroup = new Group();
                            oGroup.GroupID = Convert.ToInt32(drGroup["PFS_GROUP_ID"]);
                            oGroup.GroupName = Convert.ToString(drGroup["GROUP_NAME"]);
                            oGroup.GroupDescr = Convert.ToString(drGroup["GROUP_DESCR"]);
                            oGroup.IsActive = Convert.ToBoolean(drGroup["IS_ACTIVE"]);
                            oGroup.IsNeedApproval = Convert.ToBoolean(drGroup["IS_NEED_APPROVAL"]);
                            oGroup.CreateDate = Convert.ToDateTime(drGroup["CREATE_DATE"]);
                            oGroup.CreateByUserID = Convert.ToInt32(drGroup["CREATE_BY_USER_ID"]);
                            oGroup.CreateByUsername = Convert.ToString(drGroup["CREATE_BY_USERNAME"]);
                            oGroup.UpdateDate = Convert.ToDateTime(drGroup["UPDATE_DATE"]);
                            oGroup.UpdateByUserID = Convert.ToInt32(drGroup["UPDATE_BY_USER_ID"]);
                            oGroup.UpdateByUsername = Convert.ToString(drGroup["UPDATE_BY_USERNAME"]);
                            oGroup.TotalUser = Convert.ToInt32(drGroup["TOTAL_USER"]);
                            this.Add(oGroup);
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
