using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.Security;
using PFSHelper.Lib;

namespace PFSHelper.BusinessLogicLayer
{
    public class ActiveDirectory
    {
        private string m_sUserName = "NONE";

        public string UserName
        {
            get { return m_sUserName; }
            set { m_sUserName = value; }
        }

        public ActiveDirectory()
        {
        }

        public ActiveDirectory(string p_sUserName)
        {
            m_sUserName = p_sUserName;
        }

        public static bool IsAuthenticated(string p_sUserName, string p_sPassword)
        {
            string sDomainAndUserName = PFSConfiguration.ActiveDirectory.AdDomain + @"\" + p_sUserName;
            DirectoryEntry entry = new DirectoryEntry(PFSConfiguration.ActiveDirectory.AdPath, sDomainAndUserName, p_sPassword);

            try
            {
                if (PFSConfiguration.ActiveDirectory.IsUsingAd)
                {
                    Object obj = entry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + p_sUserName + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();
                    if (null == result)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
            }
            finally
            {
                entry.Dispose();
            }
        }

        public static bool ChangePassword(string p_sUserName, string p_sOldPassword, string p_sNewPassword)
        {
            string sDomainAndUserName = PFSConfiguration.ActiveDirectory.AdDomain + @"\" + p_sUserName;
            DirectoryEntry entry = new DirectoryEntry(PFSConfiguration.ActiveDirectory.AdPath, sDomainAndUserName, p_sOldPassword, AuthenticationTypes.Secure | AuthenticationTypes.Sealing | AuthenticationTypes.ServerBind);

            try
            {
                if (PFSConfiguration.ActiveDirectory.IsUsingAd)
                {
                    Object obj = entry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + p_sUserName + ")";
                    search.SearchScope = SearchScope.Subtree;
                    search.CacheResults = false;
                    //search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();

                    if (null == result)
                    {
                        return false;
                    }
                    else
                    {
                        DirectoryEntry user = result.GetDirectoryEntry();
                        Object ret = user.Invoke("ChangePassword", new object[] { p_sOldPassword, p_sNewPassword });
                        user.CommitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                entry.Dispose();
            }
        }
    }
}
