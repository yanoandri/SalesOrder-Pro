#region " Revision History "
// Copyright (c) 2005, PT. Profescipta Wahanatehnik. All Rights Reserved.
//
// This software, all associated documentation, and all copies
// are CONFIDENTIAL INFORMATION of PT. Profescipta Wahanatehnik. 
// http://www.profescipta.com
// 
// $Workfile: CustomPrincipal.cs $
// $Revision: 1 $
// $Date: 6/02/08 3:35p $
//
// DESCRIPTION
//
//
// $Log: /Project2008/metronome_v2/source/PFSHelper.BusinessLogicLayer/Security/CustomPrincipal.cs $
// 
// 1     6/02/08 3:35p Wkurniawan
// 
// 1     7/23/07 2:33p Wkurniawan
// 
// 1     7/23/07 2:26p Wkurniawan
// 
// 1     4/06/07 2:35p Mramdhan
// 
#endregion

using System;
using System.Security.Principal;

namespace PFSHelper.BusinessLogicLayer
{
	public class CustomPrincipal : IPrincipal
	{
        #region Member variables 

        private string m_sIPAddress;
        private IIdentity m_Identity;
        private User m_oUser;
        #endregion

        #region Constructor 

        public CustomPrincipal() { }

        public CustomPrincipal(IIdentity Identity, string IpAddress, User oUser)
        {
            m_Identity = Identity;
            m_sIPAddress = IpAddress;
            m_oUser = oUser;
        }
        #endregion

        #region Properties 

        public IIdentity Identity
		{
			get
			{
				return m_Identity;
			}
		}

        public User User
        {
            get
            {
                return m_oUser;
            }
            set
            {
                m_oUser = value;
            }
        }
		
		public string IpAddress
		{
			get
			{
				return m_sIPAddress;
			}
			set
			{
				m_sIPAddress = value;
			}
		}

		public bool IsInRole(string role)
		{
			string[] roleArray = role.Split(',');
			foreach(string r in roleArray) 
			{

			}
			return false;
        }
        #endregion
    }
}
