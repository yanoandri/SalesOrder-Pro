
using System;
using System.Configuration;
using PFSHelper.DataAccessLayer;
using PFSHelper.Lib;

#region Revision History

// Copyright (c) 2011, PT. Profescipta Wahanatehnik. All Rights Reserved.
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
// $Log:$
//
#endregion

namespace PFSHelper.BusinessLogicLayer
{
    public partial class ExceptionLog
    {
        #region Method

        public static void LogError(
            string p_sRefNo,
            string p_sClassName,
            string p_sMethodName,
            Exception p_LogException)
        {
            string sSource = string.Format("{0}.{1}", p_sClassName, p_sMethodName);

            try
            {
                SqlHelper.ExecuteScalar(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ExceptionLogAdd",
                    p_sRefNo,
                    DateTime.Now,
                    string.Format("{0}.{1}",
                        p_sClassName,
                        p_sMethodName),
                    p_LogException.ToString());
            }
            catch (Exception Ex)
            {
                try
                {
                    // Log File
                    PFSCommon.WriteToFile(
                        ConfigurationManager.AppSettings.Get("ErrorLogFile"),
                        string.Format("{0} - {1} \t: {2}{3} \t\t: {4}{5}{6}{7}{8}{9}{10}{11}{12}",
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            p_sRefNo,
                            System.Environment.NewLine,
                            sSource,
                            System.Environment.NewLine,
                            p_LogException.ToString(),
                            System.Environment.NewLine,
                            "--------------------------------------- Failed Log To Db Detail -----------------------------------------",
                            System.Environment.NewLine,
                            Ex.ToString(),
                            System.Environment.NewLine,
                            "----------------------------------------------------------------------------------------------------------",
                            System.Environment.NewLine),
                        true);
                }
                catch
                {
                    try
                    {
                        // Event Log
                        PFSCommon.WriteToEventLog(
                            "PFSHelper.BusinessLogicLayer.ExceptionLog.LogError",
                            string.Format("{0} - {1} \t: {2}{3} \t\t: {4}{5}{6}",
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                p_sRefNo,
                                System.Environment.NewLine,
                                sSource,
                                System.Environment.NewLine,
                                p_LogException.ToString(),
                                System.Environment.NewLine));

                    }
                    catch
                    {
                        // May God help us
                    }
                }
            }
        }

        #endregion
    }
}
