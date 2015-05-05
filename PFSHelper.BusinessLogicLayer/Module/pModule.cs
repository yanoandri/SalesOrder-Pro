using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PFSHelper.DataAccessLayer;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class Module
    {
        protected ModuleObjectCollection m_oModuleObjectCollection = null;

        public ModuleObjectCollection ModuleObjects
        {
            get { return m_oModuleObjectCollection; }
            set { m_oModuleObjectCollection = value; }
        }

        public bool DAL_LoadWithChild()
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drModule = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleGet", m_iModuleID))
                {
                    if (drModule.Read())
                    {
                        m_iModuleID = Convert.ToInt32(drModule["PFS_MODULE_ID"]);
                        m_sModuleCode = Convert.ToString(drModule["MODULE_CODE"]);
                        m_sModuleName = Convert.ToString(drModule["MODULE_NAME"]);
                        m_sModuleDescr = Convert.ToString(drModule["MODULE_DESCR"]);
                        m_iIndexOrder = Convert.ToInt32(drModule["INDEX_ORDER"]);
                        m_oModuleObjectCollection.DAL_LoadByModuleID(m_iModuleID);
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

        public bool DAL_LoadWithChild(int iID)
        {
            bool bIsSuccess = false;
            try
            {
                using (SqlDataReader drModule = SqlHelper.ExecuteReader(PFSHelper.DataAccessLayer.PFSDataBaseAccess.ConnectionString, "uspPFS_ModuleGet", iID))
                {
                    if (drModule.Read())
                    {
                        m_iModuleID = Convert.ToInt32(drModule["PFS_MODULE_ID"]);
                        m_sModuleCode = Convert.ToString(drModule["MODULE_CODE"]);
                        m_sModuleName = Convert.ToString(drModule["MODULE_NAME"]);
                        m_sModuleDescr = Convert.ToString(drModule["MODULE_DESCR"]);
                        m_iIndexOrder = Convert.ToInt32(drModule["INDEX_ORDER"]);
                        m_oModuleObjectCollection.DAL_LoadByModuleID(m_iModuleID);
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
