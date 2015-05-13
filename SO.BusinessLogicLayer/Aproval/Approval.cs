using System;
using System.Data.SqlClient;
using System.Web;
using PFSHelper.BusinessLogicLayer;
using PFSHelper.DataAccessLayer;
using SO.BusinessLogicLayer.Enumeration;

namespace SO.BusinessLogicLayer
{
    public sealed class Approval
    {
        #region  Approval Request
        public static bool UpdateApprovalLog(Object p_Object, ApprovalLog p_ApprovalLog, SOEnumeration.ApprovalStatus p_ApprovalStatus, ref string p_sMessage)
        {
            bool bIsSuccess = false;
            ApprovalLog oApprovalLogCheck = new ApprovalLog(p_ApprovalLog.ApprovalLogID);
            SqlConnection oConn = PFSDataBaseAccess.OpenConnection();
            SqlTransaction oTrans = oConn.BeginTransaction();

            try
            {
                if (p_ApprovalStatus != SOEnumeration.ApprovalStatus.PENDING)
                {
                    oApprovalLogCheck.DAL_LoadWithWithModuleObject();
                    if (oApprovalLogCheck.ApprovalStatusID != (int)SOEnumeration.ApprovalStatus.PENDING)
                    {
                        p_sMessage = "This approval request has been handled by another user";
                        return false;
                    }
                }

                #region Approval User
                if (p_Object is User)
                    switch (p_ApprovalStatus)
                    {
                        case SOEnumeration.ApprovalStatus.APPROVE:
                            bIsSuccess = ApproveUser(p_Object, p_ApprovalLog, oTrans);
                            break;

                        case SOEnumeration.ApprovalStatus.PENDING:
                            bIsSuccess = AddApprovalLogUser(p_Object, p_ApprovalLog, oTrans);
                            break;

                        case SOEnumeration.ApprovalStatus.REJECT:
                            bIsSuccess = RejectUser(p_Object, p_ApprovalLog, oTrans);
                            break;
                    }
                    #endregion

                #region Approval Group
                else if (p_Object is Group)

                    switch (p_ApprovalStatus)
                    {
                        case SOEnumeration.ApprovalStatus.APPROVE:
                            bIsSuccess = ApproveGroup(p_Object, p_ApprovalLog, oTrans);
                            break;
                        case SOEnumeration.ApprovalStatus.PENDING:
                            bIsSuccess = AddApprovalLogGroup(p_Object, p_ApprovalLog, oTrans);
                            break;
                        case SOEnumeration.ApprovalStatus.REJECT:
                            bIsSuccess = RejectGroup(p_Object, p_ApprovalLog, oTrans);
                            break;
                    }
                    #endregion

                else if (p_Object is Holiday)

                    #region Approval Holiday
                    switch (p_ApprovalStatus)
                    {
                        case SOEnumeration.ApprovalStatus.APPROVE:
                            bIsSuccess = ApproveHoliday(p_Object, p_ApprovalLog, oTrans);
                            break;
                        case SOEnumeration.ApprovalStatus.PENDING:
                            bIsSuccess = AddApprovalLogHoliday(p_Object, p_ApprovalLog, oTrans);
                            break;
                        case SOEnumeration.ApprovalStatus.REJECT:
                            bIsSuccess = RejectHoliday(p_Object, p_ApprovalLog, oTrans);
                            break;
                    }
                    #endregion

                if (bIsSuccess)
                    oTrans.Commit();
                else
                    oTrans.Rollback();

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                PFSDataBaseAccess.CloseConnection(ref oConn);
            }
        }
        #region Close Approval Log
        public static bool CloseApprovalLog(ApprovalLog p_ApprovalLog, ref string p_sMessage)
        {
            bool bIsSuccess = false;
            try
            {
                p_ApprovalLog.ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.CANCEL;
                p_ApprovalLog.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                p_ApprovalLog.UpdateDate = DateTime.Now;
                bIsSuccess = p_ApprovalLog.Close();

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region  Approve Process
        /// <summary>
        /// Approval process to approve module USER request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool ApproveUser(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;

            try
            {
                User oUser = (User)p_Object;
                oUser.IsNeedApproval = false;

                if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_USR_CREATE)
                    bIsSuccess = oUser.DAL_Add(p_Trans);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE)
                    bIsSuccess = oUser.DAL_UpdateWithChild(p_Trans);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_USR_DELETE)
                    bIsSuccess = oUser.DAL_Delete(p_Trans);
                else
                    bIsSuccess = false;

                if (bIsSuccess)
                {
                    if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_USR_CREATE)
                    {
                        UserPasswordHistory oUserPasswordHistory = new UserPasswordHistory();
                        oUserPasswordHistory.CreateDate = DateTime.Now;
                        oUserPasswordHistory.UserID = oUser.UserID;
                        oUserPasswordHistory.Password = oUser.Password;
                        bIsSuccess = oUserPasswordHistory.DAL_Add(p_Trans);
                    }
                    p_ApprovalLog.ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.APPROVE;
                    p_ApprovalLog.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.UpdateDate = DateTime.Now;
                    bIsSuccess = p_ApprovalLog.DAL_Update(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Approval process to approve module GROUP request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool ApproveGroup(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;

            try
            {
                Group oGroup = (Group)p_Object;
                oGroup.IsNeedApproval = false;

                if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE)
                    bIsSuccess = oGroup.DAL_Add(p_Trans);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE)
                    bIsSuccess = oGroup.DAL_Update(p_Trans);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_DELETE)
                    bIsSuccess = oGroup.DAL_Delete(p_Trans);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS)
                {
                    bIsSuccess = oGroup.GroupMemberCollection.DAL_DeleteByGroupID(oGroup.GroupID, p_Trans);
                    if (bIsSuccess) bIsSuccess = oGroup.GroupMemberCollection.DAL_Update(p_Trans);
                    if (bIsSuccess) bIsSuccess = oGroup.UpdateApprovalStatus(p_Trans, false);
                }
                else
                    bIsSuccess = false;

                if (bIsSuccess)
                {
                    p_ApprovalLog.ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.APPROVE;
                    p_ApprovalLog.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.UpdateDate = DateTime.Now;
                    bIsSuccess = p_ApprovalLog.DAL_Update(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Approval process to approve module HOLIDAY request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool ApproveHoliday(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;

            try
            {
                Holiday oHoliday = (Holiday)p_Object;
                oHoliday.IsNeedApproval = false;

                //if (p_ApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.PRE_HOLIDAY_SETUP_ADD)
                //    bIsSuccess = oHoliday.DAL_Add(p_Trans);
                //else if (p_ApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.PRE_HOLIDAY_SETUP_UPDATE)
                //    bIsSuccess = oHoliday.DAL_Update(p_Trans);
                //else if (p_ApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.PRE_HOLIDAY_SETUP_DELETE)
                //    bIsSuccess = oHoliday.DAL_Delete(p_Trans);
                //else
                //    bIsSuccess = false;

                if (bIsSuccess)
                {
                    p_ApprovalLog.ApprovalStatusID = (int)SOEnumeration.ApprovalStatus.APPROVE;
                    p_ApprovalLog.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.UpdateDate = DateTime.Now;
                    bIsSuccess = p_ApprovalLog.DAL_Update(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region  Add Approval Log Process

        /// <summary>
        /// Approval process to pending module USER request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool AddApprovalLogUser(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;

            try
            {
                User oUser = (User)p_Object;

                if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_USR_CREATE)
                    bIsSuccess = true;
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_USR_UPDATE)
                    bIsSuccess = oUser.UpdateApprovalStatus(p_Trans, true);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_USR_DELETE)
                    bIsSuccess = oUser.UpdateApprovalStatus(p_Trans, true);
                else
                    bIsSuccess = false;

                if (bIsSuccess)
                {
                    p_ApprovalLog.CreateDate = DateTime.Now;
                    p_ApprovalLog.CreateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.AddApprovalLog(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// Approval process to pending module GROUP request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool AddApprovalLogGroup(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;

            try
            {
                Group oGroup = (Group)p_Object;
                oGroup.IsNeedApproval = true;

                if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_CREATE)
                    bIsSuccess = true;
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_UPDATE)
                    bIsSuccess = oGroup.UpdateApprovalStatus(p_Trans, true);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_DELETE)
                    bIsSuccess = oGroup.UpdateApprovalStatus(p_Trans, true);
                else if (p_ApprovalLog.ModuleObjectMemberID == (int)SOEnumeration.PFSModuleObjectMember.SCR_GRP_ACCESS)
                    bIsSuccess = oGroup.UpdateApprovalStatus(p_Trans, true);
                else
                    bIsSuccess = false;

                if (bIsSuccess)
                {
                    p_ApprovalLog.CreateDate = DateTime.Now;
                    p_ApprovalLog.CreateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.AddApprovalLog(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Approval process to pending module Holiday request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool AddApprovalLogHoliday(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;

            try
            {
                Holiday oHoliday = (Holiday)p_Object;
                oHoliday.IsNeedApproval = true;

                //if (p_ApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.PRE_HOLIDAY_SETUP_ADD)
                //    bIsSuccess = true;
                //else if (p_ApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.PRE_HOLIDAY_SETUP_UPDATE)
                //    bIsSuccess = oHoliday.UpdateApprovalStatus(p_Trans, true);
                //else if (p_ApprovalLog.ModuleObjectMemberID == (int)OTSCEnumeration.PFSModuleObjectMember.PRE_HOLIDAY_SETUP_DELETE)
                //    bIsSuccess = oHoliday.UpdateApprovalStatus(p_Trans, true);
                //else
                //    bIsSuccess = false;

                if (bIsSuccess)
                {
                    p_ApprovalLog.CreateDate = DateTime.Now;
                    p_ApprovalLog.CreateByUserID = ((CustomPrincipal)System.Web.HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.AddApprovalLog(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region  Reject Process

        /// <summary>
        /// Approval process to reject module USER request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool RejectUser(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;
            try
            {
                User oUser = (User)p_Object;

                bIsSuccess = oUser.RejectApprovalRequest(p_Trans);

                if (bIsSuccess)
                {
                    p_ApprovalLog.ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.REJECT;
                    p_ApprovalLog.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.UpdateDate = DateTime.Now;
                    bIsSuccess = p_ApprovalLog.DAL_Update(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Approval process to reject module GROUP request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool RejectGroup(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;
            try
            {
                Group oGroup = (Group)p_Object;

                bIsSuccess = oGroup.RejectApprovalRequest(p_Trans);

                if (bIsSuccess)
                {
                    p_ApprovalLog.ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.REJECT;
                    p_ApprovalLog.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.UpdateDate = DateTime.Now;
                    bIsSuccess = p_ApprovalLog.DAL_Update(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /// <summary>
        /// Approval process to reject module Holiday request
        /// </summary>
        /// <param name="p_Object">User Object Class</param>
        /// <param name="p_ApprovalLog">Approval log object</param>
        /// <param name="p_Trans">Sql transaction</param>
        /// <returns>Return True if process is succeeded and false if process is failed</returns>
        private static bool RejectHoliday(Object p_Object, ApprovalLog p_ApprovalLog, SqlTransaction p_Trans)
        {
            bool bIsSuccess = false;
            try
            {
                Holiday oHoliday = (Holiday)p_Object;

                bIsSuccess = oHoliday.RejectApprovalRequest(p_Trans);

                if (bIsSuccess)
                {
                    p_ApprovalLog.ApprovalStatusID = (int)SO.BusinessLogicLayer.Enumeration.SOEnumeration.ApprovalStatus.REJECT;
                    p_ApprovalLog.UpdateByUserID = ((CustomPrincipal)HttpContext.Current.User).User.UserID;
                    p_ApprovalLog.UpdateDate = DateTime.Now;
                    bIsSuccess = p_ApprovalLog.DAL_Update(p_Trans);
                }

                return bIsSuccess;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        public class Summary
        {
            #region  Member Variables
            private int m_iPendingNumber;
            private int m_iApprovedNumber;
            private int m_iRejectedNumber;
            private int m_iNeedApprovalNumber;
            private int m_iApprovedByUserNumber;
            private int m_iRejectedByUserNumber;
            #endregion

            #region  Properties
            public int PendingNumber
            {
                get { return m_iPendingNumber; }
                set { m_iPendingNumber = value; }
            }
            public int ApprovedNumber
            {
                get { return m_iApprovedNumber; }
                set { m_iApprovedNumber = value; }
            }
            public int RejectedNumber
            {
                get { return m_iRejectedNumber; }
                set { m_iRejectedNumber = value; }
            }
            public int NeedApprovalNumber
            {
                get { return m_iNeedApprovalNumber; }
                set { m_iNeedApprovalNumber = value; }
            }
            public int ApprovedByUserNumber
            {
                get { return m_iApprovedByUserNumber; }
                set { m_iApprovedByUserNumber = value; }
            }
            public int RejectedByUserNumber
            {
                get { return m_iRejectedByUserNumber; }
                set { m_iRejectedByUserNumber = value; }
            }
            #endregion

            public bool GetSummary()
            {
                bool bIsSuccess = false;
                try
                {
                    using (SqlDataReader drApprovalLog = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspCOM_ApprovalLogGetForLandingPage",
                        ((CustomPrincipal)HttpContext.Current.User).User.UserID))
                    {
                        if (drApprovalLog.Read())
                        {
                            m_iPendingNumber = Convert.ToInt32(drApprovalLog["PENDING_NUMBER"]);
                            m_iApprovedNumber = Convert.ToInt32(drApprovalLog["APPROVED_NUMBER"]);
                            m_iRejectedNumber = Convert.ToInt32(drApprovalLog["REJECTED_NUMBER"]);
                            m_iNeedApprovalNumber = Convert.ToInt32(drApprovalLog["NEED_APPROVAL_NUMBER"]);
                            m_iApprovedByUserNumber = Convert.ToInt32(drApprovalLog["APPROVED_BY_USER_NUMBER"]);
                            m_iRejectedByUserNumber = Convert.ToInt32(drApprovalLog["REJECTED_BY_USER_NUMBER"]);
                            bIsSuccess = true;
                        }
                    }
                    return bIsSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
        #endregion