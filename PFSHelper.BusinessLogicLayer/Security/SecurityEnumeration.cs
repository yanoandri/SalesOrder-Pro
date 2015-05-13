using System;
using System.Collections;
using System.Text;

namespace PFSHelper.BusinessLogicLayer
{
    public class SecurityEnumeration
    {
        public enum SecurityModuleObjectMember
        {
            SCR_USR_CREATE = 1,
            SCR_USR_READ = 2,
            SCR_USR_UPDATE = 3,
            SCR_USR_DELETE=4,
            SCR_USR_LOGIN=36,
            SCR_USR_LOGOUT=37,
            SCR_GRP_CREATE=5,
            SCR_GRP_READ=6,
            SCR_GRP_UPDATE=7,
            SCR_GRP_DELETE=8,
            SCR_GRP_ACCESS=11,
            SCR_AUD_READ=12,
            SCR_AUD_PURGE=13,
            MAS_LOC_READ,
            MAS_LOC_UPDATE,
            MAS_LOC_DELETE,
            MAS_AUD_CREATE,
            MAS_AUD_READ,
            MAS_AUD_UPDATE,
            MAS_AUD_DELETE,
            MAS_ORG_CREATE,
            MAS_ORG_READ,
            MAS_ORG_UPDATE,
            MAS_ORG_DELETE,
            RPT_SUM_READ,
            RPT_AUD_READ,
            MST_EXC_READ,
            MST_EXC_CREATE,
            SALES_SO_READ,
            SALES_SO_DELETE,
            SALES_SO_ADD,
            SALES_SOINPUT_SAVE,
            SALES_SOINPUT_ADDITEM,
            SALES_SOINPUT_DETAIL
        }
      
        public enum ActiveStatus : int
        {
            ACTIVE = 1,
            NOT_ACTIVE = 0
        }
    }
}
