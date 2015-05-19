using System;

namespace SO.BusinessLogicLayer.Enumeration
{
    public class SOEnumeration
    {
        #region Module

        public enum PFSModule : int
        {
            Security = 10,
            Approval = 30,
            Sales = 70
        }

        public enum PFSModuleObject : int
        {
            User = 1001,
            Group = 1002,
            AuditTrail = 1003,

            ApprovalLog = 3000,

            SalesOrder = 7001,
            AddOrder = 7002

        }

        public enum PFSModuleObjectMember : int
        {
            SCR_USR_CREATE = 100101,
            SCR_USR_READ = 100102,
            SCR_USR_UPDATE = 100103,
            SCR_USR_DELETE = 100104,
            SCR_USR_LOGIN = 100105,
            SCR_USR_LOGOUT = 100106,
            SCR_USR_APPROVE = 100107,
            SCR_USR_REJECT = 100108,
            SCR_USR_CHANGE_PASSWORD = 100109,

            SCR_GRP_CREATE = 100201,
            SCR_GRP_READ = 100202,
            SCR_GRP_UPDATE = 100203,
            SCR_GRP_DELETE = 100204,
            SCR_GRP_ACCESS = 100205,
            SCR_GRP_APPROVE = 100206,
            SCR_GRP_REJECT = 100207,

            SCR_AUD_READ = 100301,
            SCR_AUD_PURGE = 100302,

            APP_LOG_READ = 300001,
            APP_LOG_EXPORT_EXCEL = 300002,

            SALES_SO_READ = 700101,
            SALES_SO_DELETE = 700102,
            SALES_SO_ADD = 700103,

            SALES_SOINPUT_SAVE = 700201,
            SALES_SOINPUT_ADDITEM = 700202,
            SALES_SOINPUT_DETAIL = 700203
        }
        #endregion
     
        #region Process
        public enum ApprovalStatus
        {
            APPROVE = 1,
            PENDING = 2,
            REJECT = 3,
            CANCEL = 4
        }

        #endregion

    }
}
