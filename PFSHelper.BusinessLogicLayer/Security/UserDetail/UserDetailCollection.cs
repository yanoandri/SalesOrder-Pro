using System;
using System.Collections;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;
using System.Data.SqlTypes;

#region Region: Revision History///////////////////////////////////////////////////////////////
// Copyright (c) 2015, PT. Profescipta Wahanatehnik. All Rights Reserved.
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
    //Standard class autogenerated by PFS Generator v5.1
    [System.Xml.Serialization.XmlRoot("UserDetails")]
    public partial class UserDetailCollection : ICollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        private ArrayList m_oUserDetailList = new ArrayList();
        #endregion
        #region Region: Properties/////////////////////////////////////////////////////////////
        public UserDetail this[int index]
        {
            get { return (UserDetail)m_oUserDetailList[index]; }
        }
        public int Count
        {
            get { return m_oUserDetailList.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        #endregion
        #region Region: List Method////////////////////////////////////////////////////////////
        public void Sort(IComparer oComparer)
        {
            m_oUserDetailList.Sort(oComparer);
        }
        public void Reverse()
        {
            m_oUserDetailList.Reverse();
        }
        public void CopyTo(Array a, int index)
        {
            m_oUserDetailList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oUserDetailList.GetEnumerator();
        }
        public void Add(UserDetail oObject)
        {
            m_oUserDetailList.Add(oObject);
        }
        public void RemoveAt(int index)
        {
            m_oUserDetailList.RemoveAt(index);
        }
        public void Clear()
        {
            m_oUserDetailList.Clear();
        }
        #endregion
        #region Region: Field Enumeration /////////////////////////////////////////////////////
        public enum UserDetailFields
        {
            UserDetailID,
            UserID,
            UserCode,
            BranchCode,
            DepartmentName,
            Position,
            Dob,
            HomeNumber,
            WorkNumber,
            MobileNumber,
            Picture,
            UserName,
            FullName
        }
        #endregion
        #region Region: Sort Method////////////////////////////////////////////////////////////
        public void Sort(UserDetailFields sortField, bool isAscending)
        {
            switch (sortField)
            {
                case UserDetailFields.UserDetailID:
                    this.Sort(new UserDetailIDComparer());
                    break;
                case UserDetailFields.UserID:
                    this.Sort(new UserIDComparer());
                    break;
                case UserDetailFields.UserCode:
                    this.Sort(new UserCodeComparer());
                    break;
                case UserDetailFields.BranchCode:
                    this.Sort(new BranchCodeComparer());
                    break;
                case UserDetailFields.DepartmentName:
                    this.Sort(new DepartmentNameComparer());
                    break;
                case UserDetailFields.Position:
                    this.Sort(new PositionComparer());
                    break;
                case UserDetailFields.Dob:
                    this.Sort(new DobComparer());
                    break;
                case UserDetailFields.HomeNumber:
                    this.Sort(new HomeNumberComparer());
                    break;
                case UserDetailFields.WorkNumber:
                    this.Sort(new WorkNumberComparer());
                    break;
                case UserDetailFields.MobileNumber:
                    this.Sort(new MobileNumberComparer());
                    break;
                case UserDetailFields.Picture:
                    this.Sort(new PictureComparer());
                    break;
                case UserDetailFields.UserName:
                    this.Sort(new UserNameComparer());
                    break;
                case UserDetailFields.FullName:
                    this.Sort(new FullNameComparer());
                    break;
            }
            if (!isAscending) this.Reverse();
        }
        #endregion
        #region Region: IComparer//////////////////////////////////////////////////////////////
        private sealed class UserDetailIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.UserDetailID.CompareTo(second.UserDetailID);
            }
        }
        private sealed class UserIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.UserID.CompareTo(second.UserID);
            }
        }
        private sealed class UserCodeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.UserCode.CompareTo(second.UserCode);
            }
        }
        private sealed class BranchCodeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.BranchCode.CompareTo(second.BranchCode);
            }
        }
        private sealed class DepartmentNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.DepartmentName.CompareTo(second.DepartmentName);
            }
        }
        private sealed class PositionComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.Position.CompareTo(second.Position);
            }
        }
        private sealed class DobComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.Dob.CompareTo(second.Dob);
            }
        }
        private sealed class HomeNumberComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.HomeNumber.CompareTo(second.HomeNumber);
            }
        }
        private sealed class WorkNumberComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.WorkNumber.CompareTo(second.WorkNumber);
            }
        }
        private sealed class MobileNumberComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.MobileNumber.CompareTo(second.MobileNumber);
            }
        }
        private sealed class PictureComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.Picture.CompareTo(second.Picture);
            }
        }
        private sealed class UserNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.UserName.CompareTo(second.UserName);
            }
        }
        private sealed class FullNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserDetail first = (UserDetail)x;
                UserDetail second = (UserDetail)y;
                return first.FullName.CompareTo(second.FullName);
            }
        }
        #endregion
        #region Region: Data Access Layer /////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserDetailList"))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserDetail oUserDetail = new UserDetail();
                            oUserDetail.UserDetailID = Convert.ToInt32(dr["PFS_USER_DETAIL_ID"]);
                            oUserDetail.UserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                            oUserDetail.UserCode = Convert.ToString(dr["USER_CODE"]);
                            oUserDetail.BranchCode = Convert.ToString(dr["BRANCH_CODE"]);
                            oUserDetail.DepartmentName = Convert.ToString(dr["DEPARTMENT_NAME"]);
                            oUserDetail.Position = Convert.ToString(dr["POSITION"]);
                            oUserDetail.Dob = Convert.ToDateTime(dr["DOB"]);
                            oUserDetail.HomeNumber = Convert.ToString(dr["HOME_NUMBER"]);
                            oUserDetail.WorkNumber = Convert.ToString(dr["WORK_NUMBER"]);
                            oUserDetail.MobileNumber = Convert.ToString(dr["MOBILE_NUMBER"]);
                            oUserDetail.Picture = (SqlBinary)(dr["PICTURE"]);
                            oUserDetail.UserName = Convert.ToString(dr["USER_NAME"]);
                            oUserDetail.FullName = Convert.ToString(dr["FULL_NAME"]);
                            this.Add(oUserDetail);
                        }
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_Load(
            string p_sKeyWords,
            object p_iUserID,
            object p_dtDobFrom,
            object p_dtDobTo


        )
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserDetailList",
                    p_sKeyWords,
                    p_iUserID,
                    p_dtDobFrom,
                    p_dtDobTo

                ))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserDetail oUserDetail = new UserDetail();
                            oUserDetail.UserDetailID = Convert.ToInt32(dr["PFS_USER_DETAIL_ID"]);
                            oUserDetail.UserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                            oUserDetail.UserCode = Convert.ToString(dr["USER_CODE"]);
                            oUserDetail.BranchCode = Convert.ToString(dr["BRANCH_CODE"]);
                            oUserDetail.DepartmentName = Convert.ToString(dr["DEPARTMENT_NAME"]);
                            oUserDetail.Position = Convert.ToString(dr["POSITION"]);
                            oUserDetail.Dob = Convert.ToDateTime(dr["DOB"]);
                            oUserDetail.HomeNumber = Convert.ToString(dr["HOME_NUMBER"]);
                            oUserDetail.WorkNumber = Convert.ToString(dr["WORK_NUMBER"]);
                            oUserDetail.MobileNumber = Convert.ToString(dr["MOBILE_NUMBER"]);
                           // oUserDetail.Picture = (SqlBinary)(dr["PICTURE"]);
                            oUserDetail.UserName = Convert.ToString(dr["USER_NAME"]);
                            oUserDetail.FullName = Convert.ToString(dr["FULL_NAME"]);
                            this.Add(oUserDetail);
                        }
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAL_LoadByUserID(int p_iID)
        {
            try
            {
                return DAL_Load(
                    null,
                    p_iID,
                    null,
                    null


                );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DAL_Add()
        {
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();
            try
            {
                if (DAL_Add(oTrans))
                {
                    oTrans.Commit();
                    return true;
                }
                else
                {
                    oTrans.Rollback();
                    return false;
                }
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
        public bool DAL_Add(SqlTransaction p_oTrans)
        {
            try
            {
                foreach (UserDetail oUserDetail in m_oUserDetailList)
                {
                    if (!oUserDetail.DAL_Add(p_oTrans)) return false;
                }
                return true;
            }
            catch (Exception ex)
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
                if (DAL_Update(oTrans))
                {
                    oTrans.Commit();
                    return true;
                }
                else
                {
                    oTrans.Rollback();
                    return false;
                }
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
        public bool DAL_Update(SqlTransaction p_oTrans)
        {
            try
            {
                foreach (UserDetail oUserDetail in m_oUserDetailList)
                {
                    if (!oUserDetail.DAL_Update(p_oTrans)) return false;
                }
                return true;
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
                if (DAL_Delete(oTrans))
                {
                    oTrans.Commit();
                    return true;
                }
                else
                {
                    oTrans.Rollback();
                    return false;
                }
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
        public bool DAL_Delete(SqlTransaction p_oTrans)
        {
            try
            {
                foreach (UserDetail oUserDetail in m_oUserDetailList)
                {
                    if (!oUserDetail.DAL_Delete(p_oTrans)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}