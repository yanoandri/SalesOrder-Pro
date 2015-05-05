﻿using System;
using System.Collections;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

#region Region: Revision History///////////////////////////////////////////////////////////////
// Copyright (c) 2013, PT. Profescipta Wahanatehnik. All Rights Reserved.
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
    [System.Xml.Serialization.XmlRoot("UserPasswordHistorys")]
    public partial class UserPasswordHistoryCollection : ICollection
    {
        #region Region: Member Variables///////////////////////////////////////////////////////
        private ArrayList m_oUserPasswordHistoryList = new ArrayList();
        #endregion
        #region Region: Properties/////////////////////////////////////////////////////////////
        public UserPasswordHistory this[int index]
        {
            get { return (UserPasswordHistory)m_oUserPasswordHistoryList[index]; }
        }
        public int Count
        {
            get { return m_oUserPasswordHistoryList.Count; }
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
            m_oUserPasswordHistoryList.Sort(oComparer);
        }
        public void Reverse()
        {
            m_oUserPasswordHistoryList.Reverse();
        }
        public void CopyTo(Array a, int index)
        {
            m_oUserPasswordHistoryList.CopyTo(a, index);
        }
        public IEnumerator GetEnumerator()
        {
            return m_oUserPasswordHistoryList.GetEnumerator();
        }
        public void Add(UserPasswordHistory oObject)
        {
            m_oUserPasswordHistoryList.Add(oObject);
        }
        public void RemoveAt(int index)
        {
            m_oUserPasswordHistoryList.RemoveAt(index);
        }
        public void Clear()
        {
            m_oUserPasswordHistoryList.Clear();
        }
        #endregion
        #region Region: Field Enumeration /////////////////////////////////////////////////////
        public enum UserPasswordHistoryFields
        {
            UserPasswordHistoryID,
            UserID,
            Password,
            CreateDate,
            UserName,
            FullName
        }
        #endregion
        #region Region: Sort Method////////////////////////////////////////////////////////////
        public void Sort(UserPasswordHistoryFields sortField, bool isAscending)
        {
            switch (sortField)
            {
                case UserPasswordHistoryFields.UserPasswordHistoryID:
                    this.Sort(new UserPasswordHistoryIDComparer());
                    break;
                case UserPasswordHistoryFields.UserID:
                    this.Sort(new UserIDComparer());
                    break;
                case UserPasswordHistoryFields.Password:
                    this.Sort(new PasswordComparer());
                    break;
                case UserPasswordHistoryFields.CreateDate:
                    this.Sort(new CreateDateComparer());
                    break;
                case UserPasswordHistoryFields.UserName:
                    this.Sort(new UserNameComparer());
                    break;
                case UserPasswordHistoryFields.FullName:
                    this.Sort(new FullNameComparer());
                    break;
            }
            if (!isAscending) this.Reverse();
        }
        #endregion
        #region Region: IComparer//////////////////////////////////////////////////////////////
        private sealed class UserPasswordHistoryIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserPasswordHistory first = (UserPasswordHistory)x;
                UserPasswordHistory second = (UserPasswordHistory)y;
                return first.UserPasswordHistoryID.CompareTo(second.UserPasswordHistoryID);
            }
        }
        private sealed class UserIDComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserPasswordHistory first = (UserPasswordHistory)x;
                UserPasswordHistory second = (UserPasswordHistory)y;
                return first.UserID.CompareTo(second.UserID);
            }
        }
        private sealed class PasswordComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserPasswordHistory first = (UserPasswordHistory)x;
                UserPasswordHistory second = (UserPasswordHistory)y;
                return first.Password.CompareTo(second.Password);
            }
        }
        private sealed class CreateDateComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserPasswordHistory first = (UserPasswordHistory)x;
                UserPasswordHistory second = (UserPasswordHistory)y;
                return first.CreateDate.CompareTo(second.CreateDate);
            }
        }
        private sealed class UserNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserPasswordHistory first = (UserPasswordHistory)x;
                UserPasswordHistory second = (UserPasswordHistory)y;
                return first.UserName.CompareTo(second.UserName);
            }
        }
        private sealed class FullNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UserPasswordHistory first = (UserPasswordHistory)x;
                UserPasswordHistory second = (UserPasswordHistory)y;
                return first.FullName.CompareTo(second.FullName);
            }
        }
        #endregion
        #region Region: Data Access Layer /////////////////////////////////////////////////////
        public bool DAL_Load()
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserPasswordHistoryList"))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserPasswordHistory oUserPasswordHistory = new UserPasswordHistory();
                            oUserPasswordHistory.UserPasswordHistoryID = Convert.ToInt64(dr["PFS_USER_PASSWORD_HISTORY_ID"]);
                            oUserPasswordHistory.UserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                            oUserPasswordHistory.Password = Convert.ToString(dr["PASSWORD"]);
                            oUserPasswordHistory.CreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                            oUserPasswordHistory.UserName = Convert.ToString(dr["USER_NAME"]);
                            oUserPasswordHistory.FullName = Convert.ToString(dr["FULL_NAME"]);
                            this.Add(oUserPasswordHistory);
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
            object p_dtCreateDateFrom,
            object p_dtCreateDateTo


        )
        {
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(PFSDataBaseAccess.ConnectionString, "uspPFS_UserPasswordHistoryList",
                    p_sKeyWords,
                    p_iUserID,
                    p_dtCreateDateFrom,
                    p_dtCreateDateTo

                ))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserPasswordHistory oUserPasswordHistory = new UserPasswordHistory();
                            oUserPasswordHistory.UserPasswordHistoryID = Convert.ToInt64(dr["PFS_USER_PASSWORD_HISTORY_ID"]);
                            oUserPasswordHistory.UserID = Convert.ToInt32(dr["PFS_USER_ID"]);
                            oUserPasswordHistory.Password = Convert.ToString(dr["PASSWORD"]);
                            oUserPasswordHistory.CreateDate = Convert.ToDateTime(dr["CREATE_DATE"]);
                            oUserPasswordHistory.UserName = Convert.ToString(dr["USER_NAME"]);
                            oUserPasswordHistory.FullName = Convert.ToString(dr["FULL_NAME"]);
                            this.Add(oUserPasswordHistory);
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
                foreach (UserPasswordHistory oUserPasswordHistory in m_oUserPasswordHistoryList)
                {
                    if (!oUserPasswordHistory.DAL_Add(p_oTrans)) return false;
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
                foreach (UserPasswordHistory oUserPasswordHistory in m_oUserPasswordHistoryList)
                {
                    if (!oUserPasswordHistory.DAL_Update(p_oTrans)) return false;
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
                foreach (UserPasswordHistory oUserPasswordHistory in m_oUserPasswordHistoryList)
                {
                    if (!oUserPasswordHistory.DAL_Delete(p_oTrans)) return false;
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