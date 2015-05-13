using System;

namespace SO.BusinessLogicLayer.Enumeration
{
    public class SOEnumeration
    {
        #region Module

        public enum PFSModule : int
        {
            Security = 10,
            Preference = 20,
            Approval = 30,
            Master = 40,
            Transaction = 50,
            Report = 60,
            Sales = 70
        }

        public enum PFSModuleObject : int
        {
            User = 1001,
            Group = 1002,
            AuditTrail = 1003,

            SystemParameter = 2000,

            ApprovalLog = 3000,

            Product = 4001,
            ExceptionForm = 4002,

            ManualUpload = 5001,
            ProductChecking = 5002,
            ProductOffering = 5003,

            REPORT_LEVEL_EXCEPTION = 6001,
            REPORT_HISTORY_TRANSACION = 6002,
            REPORT_RISK_MISSMATCH = 6003,
            REPORT_FNA_EXCEPTION = 6004,
            REPORT_RISK_EXPIRY = 6005,
            REPORT_RISK_CHANGES = 6006,
            REPORT_EXEPTION_LIST = 6007,

            REPORT_VIEW_ALL_BRANCH = 6008,

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

            PRE_SYS_PARAM_READ = 200001,
            PRE_SYS_PARAM_UPDATE = 200002,

            PRE_CON_MATRIX_READ = 200003,
            PRE_CON_MATRIX_UPDATE = 200004,

            APP_LOG_READ = 300001,
            APP_LOG_EXPORT_EXCEL = 300002,

            MST_PRD_READ = 400101,
            MST_PRD_CREATE = 400102,
            MST_PRD_UPDATE = 400103,
            MST_PRD_DELETE = 400104,
            MST_PRD_APPROVE = 400105,
            MST_PRD_REJECT = 400106,

            MST_EXC_READ = 400201,
            MST_EXC_CREATE = 400202,
            MST_EXC_UPDATE = 400203,
            MST_EXC_DELETE = 400204,
            MST_EXC_APPROVE = 400205,
            MST_EXC_REJECT = 400206,

            MNL_UPLOAD_READ = 500101,
            MNL_UPLOAD_CREATE = 500102,

            PROD_CHECK_ACTION = 500201,
            PROD_CHECK_PRINT = 500202,
            PROD_OFFER_ACTION = 500301,
            PROD_OFFER_PRINT = 500302,

            REPORT_LEVEL_EXCEPTION_VIEW = 600101,
            REPORT_LEVEL_EXCEPTION_EXPORT = 600102,

            REPORT_HISTORY_TRANSACION_VIEW = 600201,
            REPORT_HISTORY_TRANSACION_EXPORT = 600202,

            REPORT_RISK_MISSMATCH_VIEW = 600301,
            REPORT_RISK_MISSMATCH_EXPORT = 600302,

            REPORT_FNA_EXCEPTION_VIEW = 600401,
            REPORT_FNA_EXCEPTION_EXPORT = 600402,

            REPORT_RISK_EXPIRY_VIEW = 600501,
            REPORT_RISK_EXPIRY_EXPORT = 600502,

            REPORT_RISK_CHANGES_VIEW = 600601,
            REPORT_RISK_CHANGES_EXPORT = 600602,

            REPORT_EXEPTION_LIST_VIEW = 600701,
            REPORT_EXEPTION_LIST_EXPORT = 600702,

            REPORT_VIEW_ALL_BRANCH_VIEW = 600801,

            SALES_SO_READ = 700101,
            SALES_SO_DELETE = 700102,
            SALES_SO_ADD = 700103,


            SALES_SOINPUT_SAVE = 700201,
            SALES_SOINPUT_ADDITEM = 700202,
            SALES_SOINPUT_DETAIL = 700203
        }

        public enum ConditionMatrixSetupVulnerableCheckingCriteria : int
        {
            AGE1 = 1,
            AGE2 = 2,
            EDUCATION_BACKGROUND = 3
        }

        public enum AssetClass : int
        {
            MONEY_MARKET_FUND = 1,
            FIXED_INCOME = 2,
            BALANCE_FUND = 3,
            EQUITY_FUNDS = 4,
            INDONESIA_SOVEREIGN_BONDS_P1_P3 = 5,
            INDONESIA_SOVEREIGN_BONDS_P4_P5 = 6,
            STRUCTURED_PRODUCT = 7,
            STRUCTURED_DEPOSIT = 8
        }

        public enum ConditionMatrixSetupCustomerRiskRating : int
        {
            C1 = 1,
            C2 = 2,
            C3 = 3,
            C4 = 4,
            C5 = 5
        }

        public enum ProductRating : int
        {
            P1 = 1,
            P2 = 2,
            P3 = 3,
            P4 = 4,
            P5 = 5
        }

        public enum ImportantNotesMatrixRefCode : int
        {
            IMPORTANT_NOTES_MATRIX_PARAM_1 = 1,
            IMPORTANT_NOTES_MATRIX_PARAM_2 = 2,
            IMPORTANT_NOTES_MATRIX_PARAM_3 = 3,
            IMPORTANT_NOTES_MATRIX_PARAM_4 = 4
        }
        public enum ConditionMatrixSetupImportantNotesMatrix : int
        {
            SALES_SUPERVISOR = 1,
            RETAIL_HEAD = 2,
            CALLBACK = 3,
            REASON_TO_PROCEED = 4
        }

        public enum EducationBackground : int
        {
            UNDER_GRADUATE = 1,
            GRADUATE = 2,
            POST_GRADUATE = 3
        }
        #endregion

        #region Service

        public enum FileProcesStatus : int
        {
            NOT_PROCESS = 0,
            FIRST_STAGING_IMPORTING_FILE = 1,
            SECOND_STAGING_IMPORTING_FILE = 2,
            IMPORTING_TO_FINAL_TABLE = 3,
            FINISH = 10,
            FAILED = 11,
            ARCHIEVING = 12
        }

        public enum ReportProcessStatus : int
        {
            START_REPORT_RISK = 20,
            FINISH_REPORT_RISK = 21,
            FAILED_REPORT_RISK = 22
        }

        public enum FileType : int
        {
            RMW_CIP = 1,
            CIFMASTER = 2,
            TRANSACTION = 3
        }

        public enum JatisTransaction : int
        {
            CFX = 1,
            MFX = 2,
            PFX = 3,
            BANCA = 4,
            FI = 5,
            DCI = 6
        }

        public enum PopUpSearch
        {
            Customer
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

        public enum RefCodeImportantNotesMatrix
        {
            IMPORTANT_NOTES_MATRIX_PARAM_1,
            IMPORTANT_NOTES_MATRIX_PARAM_2,
            IMPORTANT_NOTES_MATRIX_PARAM_3,
            IMPORTANT_NOTES_MATRIX_PARAM_4
        }

        public enum ReportType
        {
            LEVEL_EXCEPTION_REPORT = 1,
            TRANSACTION_HISTORY_REPORT = 2,
            RISK_MISMATCH_REPORT = 3,
            FNA_EXCEPTION_LIST_REPORT = 4,
            CUSTOMER_RISK_PROFILE_EXPIRY_DATE = 5,
            CUSTOMER_RISK_PROFILE_FREQUENT_CHANGE_REPORT = 6,
            EXCEPTION_LIST_REPORT = 7
        }

    }
}
