
using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.DirectoryServices;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.Lib;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
	#region Revision History 
// Copyright (c) 2007, PT. Profescipta Wahanatehnik. All Rights Reserved.
//
// This software, all associated documentation, and all copies
// are CONFIDENTIAL INFORMATION of PT. Profescipta Wahanatehnik. 
// http://www.profescipta.com
//
// $Workfile: ActiveDirectoryCollection.cs $
// $Revision: 2 $
// $Date: 6/26/08 2:16p $
//
// DESCRIPTION

#endregion

	[System.Xml.Serialization.XmlRoot("ActiveDirectoryuration")]
    public class ActiveDirectoryCollection : PFSDataBaseAccess, ICollection
	{
		#region Member Variables 

        private ArrayList m_oActiveDirectoryList = new ArrayList();

		#endregion

		#region Constructor 

        public ActiveDirectoryCollection()
		{
		}

		#endregion

		#region Properties 
		
		public void Sort(IComparer oComparer)
		{
			m_oActiveDirectoryList.Sort(oComparer);
		}

		public void Reverse()
		{
			m_oActiveDirectoryList.Reverse();
		}
        
		public ActiveDirectory this[int index]
        {
            get { return (ActiveDirectory)m_oActiveDirectoryList[index]; }
        }

        public void CopyTo(Array a, int index)
        {
            m_oActiveDirectoryList.CopyTo(a, index);
        }

        public int Count
        {
            get { return m_oActiveDirectoryList.Count; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public IEnumerator GetEnumerator()
        {
            return m_oActiveDirectoryList.GetEnumerator();
        }

        public void Add(ActiveDirectory oObject)
        {
            m_oActiveDirectoryList.Add(oObject);
        }

		public void RemoveAt(int index)
		{
			m_oActiveDirectoryList.RemoveAt(index);
		}

		#endregion

		#region Field Enumeration 

		public enum ActiveDirectoryFields 
		{
            UserName
		}//End Enum

		#endregion

		#region Sort 

		public void Sort (ActiveDirectoryFields sortField, bool isAscending) 
		{
			switch (sortField) 
			{
                case ActiveDirectoryFields.UserName:
                    this.Sort(new UserNameComparer());
                    break;
            }
			if(!isAscending) this.Reverse();

		}//End SortField

		#endregion

		#region IComparer 
        private sealed class UserNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                ActiveDirectory first = (ActiveDirectory)x;
                ActiveDirectory second = (ActiveDirectory)y;
                return first.UserName.CompareTo(second.UserName);
            }
        }
		#endregion

		#region Data Access Layer 

        public static ArrayList GetAllADDomainUsers()
        {
            try
            {
                ArrayList allUsers = new ArrayList();

                DirectoryEntry searchRoot = new DirectoryEntry(PFSConfiguration.ActiveDirectory.AdPath);
                DirectorySearcher search = new DirectorySearcher(searchRoot);
                search.Filter = "(&(objectClass=user)(objectCategory=person))";
                search.PropertiesToLoad.Add("SAMAccountName");

                SearchResult result;
                SearchResultCollection resultCol = search.FindAll();
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        result = resultCol[counter];
                        if (result.Properties.Contains("SAMAccountName"))
                        {
                            ActiveDirectory temp = new ActiveDirectory(result.Properties["SAMAccountName"][0].ToString());
                            allUsers.Add(temp);
                        }
                    }
                }

                allUsers.Sort(new UserNameComparer());
                return allUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

	
		#endregion
	} //** Class
} //** Name Space
