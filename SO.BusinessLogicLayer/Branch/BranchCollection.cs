using System;
using System.Collections;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

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

namespace SO.BusinessLogicLayer
{
    //Standard class autogenerated by PFS Generator v5.1
    [System.Xml.Serialization.XmlRoot("Branchs")]
    public partial class BranchCollection : ICollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        private ArrayList m_oBranchList = new ArrayList();
        #endregion
        #region Region: Properties/////////////////////////////////////////////////////////////
        public Branch this[int index]
        {
            get { return (Branch)m_oBranchList[index]; }
        }
        public int Count
        {
            get { return m_oBranchList.Count; }
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
            m_oBranchList.Sort(oComparer);
        }
        public void Reverse()
        {
            m_oBranchList.Reverse();
        }
        public void CopyTo(Array a, int index)
        {
            m_oBranchList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oBranchList.GetEnumerator();
        }
        public void Add(Branch oObject)
        {
            m_oBranchList.Add(oObject);
        }
        public void RemoveAt(int index)
        {
            m_oBranchList.RemoveAt(index);
        }
        public void Clear()
        {
            m_oBranchList.Clear();
        }
        #endregion
        #region Region: Field Enumeration /////////////////////////////////////////////////////
        public enum BranchFields
        {
            BranchID,
            BranchCode,
            BranchName,
            Description,
            IsActive,
            IsDeleted,
            CreateDate,
            CreateByUserID,
            UpdateDate,
            UpdateByUserID
        }
        #endregion
        #region Region: Sort Method////////////////////////////////////////////////////////////
        public void Sort(BranchFields sortField, bool isAscending)
        {
            switch (sortField)
            {
                case BranchFields.BranchID:
                    this.Sort(new BranchIDComparer());
                    break;
                case BranchFields.BranchCode:
                    this.Sort(new BranchCodeComparer());
                    break;
                case BranchFields.BranchName:
                    this.Sort(new BranchNameComparer());
                    break;
                case BranchFields.Description:
                    this.Sort(new DescriptionComparer());
                    break;
                case BranchFields.IsActive:
                    this.Sort(new IsActiveComparer());
                    break;
                case BranchFields.IsDeleted:
                    this.Sort(new IsDeletedComparer());
                    break;
                case BranchFields.CreateDate:
                    this.Sort(new CreateDateComparer());
                    break;
                case BranchFields.CreateByUserID:
                    this.Sort(new CreateByUserIDComparer());
                    break;
                case BranchFields.UpdateDate:
                    this.Sort(new UpdateDateComparer());
                    break;
                case BranchFields.UpdateByUserID:
                    this.Sort(new UpdateByUserIDComparer());
                    break;
            }
            if (!isAscending) this.Reverse();
        }
        #endregion
        #region Region: IComparer//////////////////////////////////////////////////////////////
        private sealed class BranchIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.BranchID.CompareTo(second.BranchID);
            }
        }
        private sealed class BranchCodeComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.BranchCode.CompareTo(second.BranchCode);
            }
        }
        private sealed class BranchNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.BranchName.CompareTo(second.BranchName);
            }
        }
        private sealed class DescriptionComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.Description.CompareTo(second.Description);
            }
        }
        private sealed class IsActiveComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.IsActive.CompareTo(second.IsActive);
            }
        }
        private sealed class IsDeletedComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.IsDeleted.CompareTo(second.IsDeleted);
            }
        }
        private sealed class CreateDateComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.CreateDate.CompareTo(second.CreateDate);
            }
        }
        private sealed class CreateByUserIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.CreateByUserID.CompareTo(second.CreateByUserID);
            }
        }
        private sealed class UpdateDateComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.UpdateDate.CompareTo(second.UpdateDate);
            }
        }
        private sealed class UpdateByUserIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Branch first = (Branch)x;
                Branch second = (Branch)y;
                return first.UpdateByUserID.CompareTo(second.UpdateByUserID);
            }
        }
        #endregion
        #region Region: Data Access Layer /////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspCOM_BranchList"))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Branch oBranch = new Branch();
                            oBranch.BranchID = Convert.ToInt32(dr["COM_BRANCH_ID"]);
                            oBranch.BranchCode = Convert.ToString(dr["BRANCH_CODE"]);
                            oBranch.BranchName = Convert.ToString(dr["BRANCH_NAME"]);
                            oBranch.Description = Convert.ToString(dr["DESCRIPTION"]);
                            oBranch.IsActive = Convert.ToBoolean(dr["IS_ACTIVE"]);
                            oBranch.IsDeleted = Convert.ToBoolean(dr["IS_DELETED"]);
                            oBranch.CreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                            oBranch.CreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                            oBranch.UpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                            oBranch.UpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
                            this.Add(oBranch);
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
            object p_bIsActive,
            object p_bIsDeleted,
            object p_dtCreateDateFrom,
            object p_dtCreateDateTo,
            object p_iCreateByUserID,
            object p_dtUpdateDateFrom,
            object p_dtUpdateDateTo,
            object p_iUpdateByUserID


        )
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspCOM_BranchList",
                    p_sKeyWords,
                    p_bIsActive,
                    p_bIsDeleted,
                    p_dtCreateDateFrom,
                    p_dtCreateDateTo,
                    p_iCreateByUserID,
                    p_dtUpdateDateFrom,
                    p_dtUpdateDateTo,
                    p_iUpdateByUserID

                ))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Branch oBranch = new Branch();
                            oBranch.BranchID = Convert.ToInt32(dr["COM_BRANCH_ID"]);
                            oBranch.BranchCode = Convert.ToString(dr["BRANCH_CODE"]);
                            oBranch.BranchName = Convert.ToString(dr["BRANCH_NAME"]);
                            oBranch.Description = Convert.ToString(dr["DESCRIPTION"]);
                            oBranch.IsActive = Convert.ToBoolean(dr["IS_ACTIVE"]);
                            oBranch.IsDeleted = Convert.ToBoolean(dr["IS_DELETED"]);
                            oBranch.CreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                            oBranch.CreateByUserID = Convert.ToInt32(dr["CREATE_BY_USER_ID"]);
                            oBranch.UpdateDate = Convert.ToDateTime(dr["UPDATE_DATE"]);
                            oBranch.UpdateByUserID = Convert.ToInt32(dr["UPDATE_BY_USER_ID"]);
                            this.Add(oBranch);
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
                foreach (Branch oBranch in m_oBranchList)
                {
                    if (!oBranch.DAL_Add(p_oTrans)) return false;
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
                foreach (Branch oBranch in m_oBranchList)
                {
                    if (!oBranch.DAL_Update(p_oTrans)) return false;
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
                foreach (Branch oBranch in m_oBranchList)
                {
                    if (!oBranch.DAL_Delete(p_oTrans)) return false;
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