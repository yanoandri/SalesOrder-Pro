using System;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class UserCollection
    {
        public bool DAL_Load(
            string p_sKeyWords,
            string p_sGroupID,
            object p_bIsActive)
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserListWithGroupID",
                    p_sKeyWords,
                    p_sGroupID,
                    p_bIsActive,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    1))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            User oUser = new User();

                            oUser.UserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                            oUser.UserName = Convert.ToString(dr["USER_NAME"].ToString());
                            oUser.Password = Convert.ToString(dr["PASSWORD"].ToString());
                            oUser.FullName = Convert.ToString(dr["FULL_NAME"].ToString());
                            oUser.Title = Convert.ToString(dr["TITLE"]);
                            oUser.Email = Convert.ToString(dr["EMAIL"]);
                            oUser.IsActive = Convert.ToBoolean(dr["IS_ACTIVE"]);
                            oUser.IsNeedApproval = Convert.ToBoolean(dr["IS_NEED_APPROVAL"]);
                            oUser.LastAccess = Convert.ToDateTime(dr["LAST_ACCESS"]);
                            oUser.CreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                            oUser.CreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                            oUser.UpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                            oUser.UpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
                            oUser.IsBlocked = Convert.ToBoolean(dr["IS_BLOCKED"]);
                            oUser.CreatedByName = Convert.ToString(dr["CreatedByName"]);

                            oUser.UserGroupList.DAL_Load(null, oUser.UserID, null);
                            int Index = 0;
                            oUser.UserGroupItem = string.Empty;
                            foreach (UserGroup oUserGroupItem in oUser.UserGroupList)
                            {
                                oUser.UserGroupItem += oUserGroupItem.GroupName;
                                Index++;
                                if (Index < oUser.UserGroupList.Count) oUser.UserGroupItem += string.Format(", ");
                            }

                            this.Add(oUser);
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
