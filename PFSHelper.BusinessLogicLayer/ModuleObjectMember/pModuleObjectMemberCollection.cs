using System;
using PFSHelper.DataAccessLayer;
using System.Data.SqlClient;
using System.Web;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class ModuleObjectMemberCollection
    {
        public bool DAL_LoadForApprovalLogBinding(int p_iModuleObjectID)
        {
            try
            {
                using (SqlDataReader drModuleObject = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleObjectMemberListForApprovalLogBinding", p_iModuleObjectID))
                {
                    if (drModuleObject.HasRows)
                    {
                        while (drModuleObject.Read())
                        {
                            ModuleObjectMember oModuleObjectMember = new ModuleObjectMember();
                            oModuleObjectMember.ModuleObjectMemberID = Convert.ToInt32(drModuleObject["PFS_MODULE_OBJECT_MEMBER_ID"]);
                            oModuleObjectMember.MemberCode = Convert.ToString(drModuleObject["MEMBER_CODE"]);
                            oModuleObjectMember.MemberName = Convert.ToString(drModuleObject["MEMBER_NAME"]);
                            oModuleObjectMember.MemberDescr = Convert.ToString(drModuleObject["MEMBER_DESCR"]);
                            this.Add(oModuleObjectMember);
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

        public bool Checksecurity()
        {
            using (SqlDataReader drModuleObjectMember = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserAccess",
                      Convert.ToInt32(((CustomPrincipal)HttpContext.Current.User).User.UserID),
                      null))
            {
                if (drModuleObjectMember.HasRows)
                {
                    while (drModuleObjectMember.Read())
                    {
                        ModuleObjectMember oModuleObjectMember = new ModuleObjectMember();
                        oModuleObjectMember.MemberCode = Convert.ToString(drModuleObjectMember["MEMBER_CODE"]);
                        this.Add(oModuleObjectMember);
                    }
                    return true;
                } //*** if (dr.HasRows)
                else
                {
                    return false;
                }

            }
        }
    }
}
