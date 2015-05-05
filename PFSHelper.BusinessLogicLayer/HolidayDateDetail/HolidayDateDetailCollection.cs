using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;

namespace PFSHelper.BusinessLogicLayer
{
    [SerializableAttribute]
    [System.Xml.Serialization.XmlRoot("HolidayDateDetail")]
    public partial class HolidayDateDetailCollection : Collection<HolidayDateDetail>
    {
        private List<HolidayDateDetail> m_oHolidayDetail = new List<HolidayDateDetail>();
        public void Sort(bool Asc)
        {
            m_oHolidayDetail.Sort();
            if (!Asc)
            {
                m_oHolidayDetail.Reverse();
            }
        }
    }
}
