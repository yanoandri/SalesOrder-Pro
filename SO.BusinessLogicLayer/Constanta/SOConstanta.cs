
namespace SO.BusinessLogicLayer.Constanta
{
    public sealed class Common
    {
        public const string const_sSelectAll = "-- ALL --";
        public const string const_sSelectOne = "-- SELECT ONE --";
        public const string const_sProcessingTitle = "Processing ...";
    }

    public sealed class SysParamKey
    {
        public const string const_sAuditPurgePath = "AUDIT_TRAIL_PURGE_PATH";
        public const string const_sSysParamCacheKey = "PFS_SYS_PARAM_CACHE_KEY";
    }

    public sealed class ServiceSetting
    {  
        public const string const_sScreeningStartTime = "SERVICE_SCREENING_START_TIME";
        public const string const_sScreeningEndTime = "SERVICE_SCREENING_END_TIME";
        public const string const_sScreeningRmwFilePath = "SERVICE_SCREENING_RMW_UPLOAD_FILE_PATH";
        public const string const_sScreeningFinacleCifMasterFilePath = "SERVICE_SCREENING_FINACLE_CIF_UPLOAD_FILE_PATH";
        public const string const_sScreeningJatisTransactionFilePath = "SERVICE_SCREENING_JATIS_TRANSACTION_UPLOAD_FILE_PATH";
        public const string const_sImportingStartTime = "SERVICE_IMPORTING_START_TIME";
        public const string const_sImportingEndTime = "SERVICE_IMPORTING_END_TIME";
        public const string const_sImportingRmwFilePath = "SERVICE_IMPORTING_RMW_UPLOAD_FILE_PATH";
        public const string const_sImportingFinacleCifMasterFilePath = "SERVICE_IMPORTING_FINACLE_CIF_UPLOAD_FILE_PATH";
        public const string const_sImportingJatisTransactionFilePath = "SERVICE_IMPORTING_JATIS_TRANSACTION_UPLOAD_FILE_PATH";
        public const string const_sImportingArchiveFilePath = "SERVICE_IMPORTING_ARCHIVE_FILE_PATH";
        public const string const_sImportingArchiveFilePassword = "SERVICE_IMPORTING_ARCHIVE_FILE_PASSWORD";
        public const string const_sImportingFailedFilePath = "SERVICE_IMPORTING_FAILED_FILE_PATH";
        public const string const_sImportingInvalidFilePath = "SERVICE_IMPORTING_INVALID_FILE_PATH";
        public const string const_sArchivingTempFilePath = "SERVICE_ARCHIVING_FILE_TEMP_PATH";
        public const string const_sReportRiskProfileExpiryPath = "REPORT_RISK_PROFILE_EXPIRY_PATH";
        public const string const_sServiceReportRiskProfileStartTime = "SERVICE_RISK_PROFILE_START_TIME";
        public const string const_sServiceReportRiskProfileEndTime = "SERVICE_RISK_PROFILE_END_TIME";
        public const string const_sServiceInProcessMessage = "INPROCESS_IMPORTING_FILE_MESSAGE";
      
    }

    public sealed class ManualUpload
    {
        public const string const_sManualUploadImportFilePath = "MANUAL_UPLOAD_IMPORT_FILE_PATH";
        public const string const_sManualUploadInvalidFilePath = "MANUAL_UPLOAD_INVALID_FILE_PATH";
        public const string const_sManualUploadArchiveFilePath = "MANUAL_UPLOAD_ARCHIVE_FILE_PATH";
        public const string const_sManualUploadArchiveFileTempPath = "MANUAL_UPLOAD_ARCHIVE_FILE_TEMP_PATH";
        public const string const_sManualUploadArchiveFilePassword = "MANUAL_UPLOAD_ARCHIVE_FILE_PASSWORD";
        public const string const_sManualUploadFailedFilePath = "MANUAL_UPLOAD_FAILED_FILE_PATH";
    }

    public sealed class GlobalSetting
    {
        public const string const_sExceptionExpiryPeriod = "EXCEPTION_EXPIRY_PERIOD";
        public const string const_sReasonToProceed = "REASON_TO_PROCEED";
        public const string const_sMaxTransactionLevel = "MAX_TRANSACTION_LEVEL";
        public const string const_sMinTransactionLevel = "MIN_TRANSACTION_LEVEL";
        public const string const_sMaxCustomerLevel = "MAX_CUSTOMER_LEVEL";
        public const string const_sMinCustomerLevel = "MIN_CUSTOMER_LEVEL";
        public const string const_sMaxAmountLevel = "MAX_AMOUNT_LEVEL";
        public const string const_sMinAmountLevel = "MIN_AMOUNT_LEVEL";
        public const string const_sCriteriaMinNotAllowed = "CRITERIA_MIN_NOT_ALLOWED";
    }

}
