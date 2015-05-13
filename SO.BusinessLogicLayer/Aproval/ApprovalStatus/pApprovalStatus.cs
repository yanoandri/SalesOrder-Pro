using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SO.BusinessLogicLayer
{
    public partial class ApprovalStatus
    {
        protected string m_sApprovalStatusName;

        public string ApprovalStatusName
        {
            get
            {
                string sStatusName;
                switch (m_sApprovalStatusCode)
                {
                    case "APPROVE":
                        sStatusName="APPROVED";
                        break;
                    case "PENDING":
                        sStatusName="PENDING";
                        break;
                    case "REJECT":
                        sStatusName="REJECTED";
                        break;
                    case "CANCEL":
                        sStatusName = "CANCELLED";
                        break;
                    default:
                        sStatusName=string.Empty;
                        break;
                }
                return sStatusName;
            }
        }
    }
}
