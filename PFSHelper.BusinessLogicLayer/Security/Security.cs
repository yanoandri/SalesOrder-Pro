using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using PFSHelper.DataAccessLayer;
using PFSHelper.Lib;
using System.Security.Cryptography;
using System.Text;

namespace PFSHelper.BusinessLogicLayer
{
    public class Security : PFSDataBaseAccess
    {
        #region Constructor

        public Security()
        {
        }
        #endregion

        #region DAL PFS Module

        public static SqlDataReader DAL_LoadModuleByID()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "LOOKUP_spPFS_UserGroupGroupList");
                return dr;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static SqlDataReader DAL_LoadModuleByName()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "LOOKUP_spPFS_UserGroupGroupList");
                return dr;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static SqlDataReader DAL_LoadModuleObjectByID()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "LOOKUP_spPFS_UserGroupGroupList");
                return dr;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static SqlDataReader DAL_LoadModuleObjectByName()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "LOOKUP_spPFS_UserGroupGroupList");
                return dr;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static SqlDataReader DAL_LoadModuleObjectMemberByID()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "LOOKUP_spPFS_UserGroupGroupList");
                return dr;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static SqlDataReader DAL_LoadModuleObjectMemberByName()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "LOOKUP_spPFS_UserGroupGroupList");
                return dr;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Method

        public static bool CheckSecurity(string p_sMemberCode)
        {
            return PFSCommon.CheckAccessRight(p_sMemberCode, ((CustomPrincipal)HttpContext.Current.User).User.UserID);
        }

        public static string Encrypt(string p_sContent)
        {
            UnicodeEncoding oUnicodeEncoding = new UnicodeEncoding();
            byte[] bytClearString = oUnicodeEncoding.GetBytes(p_sContent);
            SHA256Managed oSHA256Managed = new SHA256Managed();
            byte[] hash = oSHA256Managed.ComputeHash(bytClearString);           
            return Convert.ToBase64String(hash);
        }

        public static bool WriteUserLog(
            string sReferenceNumber,
            string sIPAddress,
            string sDescription,
            object oDetailData,
            short iStatus,
            int oModuleObjectMemberID,
            int iUserID,
            DateTime dtLogDate,
            string p_sPreviousDetail = "<xml />")
        {
            bool bIsSuccess = false;

            User oUser = new User();
            oUser.DAL_Load(iUserID);

            if (oDetailData == null)
            {
                UserLog oUserLog = new UserLog(
                    oUser.UserName,
                    sReferenceNumber,
                    sIPAddress,
                    dtLogDate,
                    sDescription,
                    "<xml />",
                    iStatus,
                    oModuleObjectMemberID,
                    p_sPreviousDetail);

                bIsSuccess = oUserLog.DAL_AddByUserID();
            }
            else
            {
                string sData = PFSXMLTools.SerializeObject(oDetailData);

                UserLog oUserLog = new UserLog(
                    oUser.UserName,
                    sReferenceNumber,
                    sIPAddress,
                    DateTime.Now,
                    sDescription,
                    sData,
                    iStatus,
                    oModuleObjectMemberID,
                    p_sPreviousDetail);

                bIsSuccess = oUserLog.DAL_AddByUserID();
            }

            oUser = null;

            return bIsSuccess;
        }

        public static bool WriteUserLog(
            string p_sReferenceNumber,
            string p_sDescription,
            object p_oDetailData,
            short p_iStatus,
            int p_oModuleObjectMemberID,
            string p_sPreviousDetail = "<xml />")
        {
            bool bIsSuccess = false;
            User oUser = new User();

            try
            {
                #region Log To Db

                int iUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                string sIPAddress = ((CustomPrincipal)HttpContext.Current.User).IpAddress;

                oUser.DAL_Load(iUserID);

                if (p_oDetailData == null)
                {
                    UserLog oUserLog = new UserLog(
                        oUser.UserName,
                        p_sReferenceNumber,
                        sIPAddress,
                        DateTime.Now,
                        p_sDescription,
                        "<xml />",
                        p_iStatus,
                        p_oModuleObjectMemberID,
                        p_sPreviousDetail);

                    bIsSuccess = oUserLog.DAL_AddByUserID();
                    oUserLog = null;
                }
                else
                {
                    string sData = PFSXMLTools.SerializeObject(p_oDetailData);
                    sData = Regex.Replace(sData, @"[^\u0000-\u007F]", string.Empty);

                    UserLog oUserLog = new UserLog(
                        oUser.UserName,
                        p_sReferenceNumber,
                        sIPAddress,
                        DateTime.Now,
                        p_sDescription,
                        sData,
                        p_iStatus,
                        p_oModuleObjectMemberID,
                        p_sPreviousDetail);

                    bIsSuccess = oUserLog.DAL_AddByUserID();
                    oUserLog = null;
                }

                #endregion
            }
            catch
            {
                #region Log To File

                try
                {
                    string sData = PFSXMLTools.SerializeObject(p_oDetailData);
                    sData = Regex.Replace(sData, @"[^\u0000-\u007F]", string.Empty);

                    ModuleObjectMember oModuleObjectMember = new ModuleObjectMember(p_oModuleObjectMemberID);
                    oModuleObjectMember.DAL_Load();

                    PFSCommon.WriteToFile(
                       ConfigurationManager.AppSettings.Get("AuditLogFile"),
                       string.Format("{0} ({1}) - {2} - {3} - {4:yyyy-MM-dd HH:mm:ss} - {5} - {6} - {7} ({8}) {9}{10}",
                            ((CustomPrincipal)HttpContext.Current.User).User.UserName,
                            ((CustomPrincipal)HttpContext.Current.User).User.UserID,
                            p_sReferenceNumber,
                            ((CustomPrincipal)HttpContext.Current.User).IpAddress,
                            DateTime.Now,
                            p_sDescription,
                            p_iStatus == 1 ? "True" : "False",
                            oModuleObjectMember.MemberCode,
                            oModuleObjectMember.ModuleObjectMemberID,
                            System.Environment.NewLine,
                            sData
                            ),
                       true);

                    oModuleObjectMember = null;
                    bIsSuccess = true;
                }
                catch
                {
                }

                #endregion
            }

            oUser = null;

            return bIsSuccess;
        }

        public static bool LogLoginActivity(
            string p_sUserName,
            string p_sIpAddress,
            string p_sReferenceNumber,
            string p_sDescription,
            object p_oDetailData,
            short p_iStatus,
            int p_oModuleObjectMemberID,
            string p_sPreviousDetail = "<xml />")
        {
            bool bIsSuccess = false;

            try
            {
                #region Log To Db

                if (p_oDetailData == null)
                {
                    UserLog oUserLog = new UserLog(
                        p_sUserName,
                        p_sReferenceNumber,
                        p_sIpAddress,
                        DateTime.Now,
                        p_sDescription,
                        "<xml />",
                        p_iStatus,
                        p_oModuleObjectMemberID,
                        p_sPreviousDetail);

                    bIsSuccess = oUserLog.DAL_AddByUserID();
                    oUserLog = null;
                }
                else
                {
                    string sData = PFSXMLTools.SerializeObject(p_oDetailData);
                    sData = Regex.Replace(sData, @"[^\u0000-\u007F]", string.Empty);

                    UserLog oUserLog = new UserLog(
                        p_sUserName,
                        p_sReferenceNumber,
                        p_sIpAddress,
                        DateTime.Now,
                        p_sDescription,
                        sData,
                        p_iStatus,
                        p_oModuleObjectMemberID,
                        p_sPreviousDetail);

                    bIsSuccess = oUserLog.DAL_AddByUserID();
                    oUserLog = null;
                }

                #endregion
            }
            catch
            {
                #region Log To File

                try
                {
                    string sData = PFSXMLTools.SerializeObject(p_oDetailData);
                    sData = Regex.Replace(sData, @"[^\u0000-\u007F]", string.Empty);

                    ModuleObjectMember oModuleObjectMember = new ModuleObjectMember(p_oModuleObjectMemberID);
                    oModuleObjectMember.DAL_Load();

                    PFSCommon.WriteToFile(
                       ConfigurationManager.AppSettings.Get("AuditLogFile"),
                       string.Format("{0} - {1} - {2} - {4:yyyy-MM-dd HH:mm:ss} - {5} - {6} - {7} {8} {9}",
                            p_sUserName,
                            p_sReferenceNumber,
                            p_sIpAddress,
                            DateTime.Now,
                            p_sDescription,
                            p_iStatus == 1 ? "True" : "False",
                            oModuleObjectMember.MemberCode,
                            oModuleObjectMember.ModuleObjectMemberID,
                            System.Environment.NewLine,
                            sData
                            ),
                       true);

                    oModuleObjectMember = null;
                    bIsSuccess = true;
                }
                catch
                {
                }

                #endregion
            }

            return bIsSuccess;
        }

       #endregion
    }
}
