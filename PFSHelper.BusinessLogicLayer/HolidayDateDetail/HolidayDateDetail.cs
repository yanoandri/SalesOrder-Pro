using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFSHelper.BusinessLogicLayer
{
    public partial class HolidayDateDetail
    {
        #region Region: Member Variables///////////////////////////////////////////////////////////
        //protected int m_iHolidayDateDetailID = -1;
		protected int m_iHolidayID = 0;
        protected int m_iHolidayDateID = 0;
		protected DateTime m_dtHolidayDate = DateTime.Parse("01/01/1900");
		protected string m_sHolidayDesc = string.Empty;
        protected int m_iCreateByUserID = 0;
        protected DateTime m_dtCreateDate = new DateTime(1900, 1, 1);
        protected int m_iUpdateByUserID = 0;
        protected DateTime m_dtUpdateDate = new DateTime(1900, 1, 1);
		#endregion
		
		#region Region: Constructor////////////////////////////////////////////////////////////////
		public HolidayDateDetail()
		{
			//m_iHolidayDateDetailID = -1;
		}	
        //public HolidayDateDetail(int iID)
        //{
        //    m_iHolidayDateDetailID = iID;
        //}
		#endregion
		
		#region Region: Properties/////////////////////////////////////////////////////////////////

        //public int HolidayDateDetailID
        //{
        //    get { return m_iHolidayDateDetailID; }
        //    set { m_iHolidayDateDetailID = value; }
        //}
        public int HolidayID
		{
			get {return m_iHolidayID;}
			set {m_iHolidayID = value;}
		}
        public int HolidayDateID
        {
            get { return m_iHolidayDateID; }
            set { m_iHolidayDateID = value; }
        }
		public DateTime HolidayDate
		{
			get {return m_dtHolidayDate;}
			set {m_dtHolidayDate = value;}
		}
		public string HolidayDesc
		{
			get {return m_sHolidayDesc;}
			set {m_sHolidayDesc = value;}
		}
        public int CreateByUserID
        {
            get { return m_iCreateByUserID; }
            set { m_iCreateByUserID = value; }
        }
        public DateTime CreateDate
        {
            get { return m_dtCreateDate; }
            set { m_dtCreateDate = value; }
        }
        public int UpdateByUserID
        {
            get { return m_iUpdateByUserID; }
            set { m_iUpdateByUserID = value; }
        }
        public DateTime UpdateDate
        {
            get { return m_dtUpdateDate; }
            set { m_dtUpdateDate = value; }
        }
		#endregion
    }
}
