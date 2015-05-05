using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class UserGroupCollection
    {
        public int GetTemporaryUserGroupID()
        {
            if (m_oUserGroupList.Count > 0)
            {
                this.Sort(UserGroupCollection.UserGroupFields.UserGroupID, true);
                if ((((UserGroup)m_oUserGroupList[0]).UserGroupID + -1) > 0) ((UserGroup)m_oUserGroupList[0]).UserGroupID = ((UserGroup)m_oUserGroupList[0]).UserGroupID * -1;
                return ((UserGroup)m_oUserGroupList[0]).UserGroupID + -1;
            }
            else
            {
                return -1;
            }
        }

        #region " Finder "
        private int GroupIDFinder(object p_oFinder)
        {
            for (int i = 0; i < m_oUserGroupList.Count; i++)
            {
                if (((UserGroup)m_oUserGroupList[i]).GroupID == (int)p_oFinder)
                {
                    return i;
                }
            }
            return -1;
        }
        private int UserGroupIDFinder(object p_oFinder)
        {
            for (int i = 0; i < m_oUserGroupList.Count; i++)
            {
                if (((UserGroup)m_oUserGroupList[i]).UserGroupID == (int)p_oFinder)
                {
                    return i;
                }
            }
            return -1;
        }
        private int UserIDFinder(object p_oFinder)
        {
            for (int i = 0; i < m_oUserGroupList.Count; i++)
            {
                if (((UserGroup)m_oUserGroupList[i]).UserID == (int)p_oFinder)
                {
                    return i;
                }
            }
            return -1;
        }
        private int UserNameFinder(object p_oFinder)
        {
            for (int i = 0; i < m_oUserGroupList.Count; i++)
            {
                if (((UserGroup)m_oUserGroupList[i]).UserName == (string)p_oFinder)
                {
                    return i;
                }
            }
            return -1;
        }
        private int GroupNameFinder(object p_oFinder)
        {
            for (int i = 0; i < m_oUserGroupList.Count; i++)
            {
                if (((UserGroup)m_oUserGroupList[i]).GroupName == (string)p_oFinder)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion


        public int FindIndex(UserGroupFields sortField, object p_oFinder)
        {
            switch (sortField)
            {

                case UserGroupFields.GroupID:
                    return this.GroupIDFinder(p_oFinder);

                case UserGroupFields.UserGroupID:
                    return this.UserGroupIDFinder(p_oFinder);

                case UserGroupFields.UserID:
                    return this.UserIDFinder(p_oFinder);

                case UserGroupFields.GroupName:
                    return this.GroupNameFinder(p_oFinder);

                case UserGroupFields.UserName:
                    return this.UserNameFinder(p_oFinder);

            }
            return -1;
        }

        #region Region : Partial Methods
        public bool Contains(object item)
        {
            return m_oUserGroupList.Contains(item);
        }
        public void RemoveAt(UserGroup p_oUserGroup)
        {
            m_oUserGroupList.RemoveAt(m_oUserGroupList.IndexOf(p_oUserGroup));
        }
        public bool RemoveByID(int p_oUserGroupID)
        {
            UserGroup GroupDelete = new UserGroup();
            foreach (object oUserGroupItem in m_oUserGroupList)
            {
                GroupDelete = (UserGroup)oUserGroupItem;
                if (GroupDelete.UserGroupID == p_oUserGroupID)
                {
                    m_oUserGroupList.Remove(GroupDelete);
                    return true;
                }
            }

            return false;
        }
        #endregion

        public bool DAL_LoadByUserIDReadPast(int iID)
        {
            try
            {
                return this.DAL_LoadReadPast(
                    null,
                    iID,
                    null
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadReadPast(
                        string sKeyWords,
                        object iUserID,
                        object iGroupID

                        )
        {
            try
            {
                using (System.Data.SqlClient.SqlDataReader drUserGroup = PFSHelper.DataAccessLayer.SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_UserGroupListReadPast",
                    sKeyWords,
                    iUserID,
                    iGroupID
                    ))
                {
                    if (drUserGroup.HasRows)
                    {
                        while (drUserGroup.Read())
                        {
                            UserGroup oUserGroup = new UserGroup();
                            oUserGroup.UserGroupID = Convert.ToInt32(drUserGroup["PFS_USER_GROUP_ID"]);
                            oUserGroup.UserID = Convert.ToInt32(drUserGroup["PFS_USER_ID"]);
                            oUserGroup.GroupID = Convert.ToInt32(drUserGroup["PFS_GROUP_ID"]);
                            oUserGroup.UserName = Convert.ToString(drUserGroup["USER_NAME"]);
                            oUserGroup.FullName = Convert.ToString(drUserGroup["FULL_NAME"]);
                            oUserGroup.GroupName = Convert.ToString(drUserGroup["GROUP_NAME"]);
                            this.Add(oUserGroup);
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
