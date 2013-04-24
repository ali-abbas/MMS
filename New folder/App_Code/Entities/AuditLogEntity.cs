/***************************************************************************************
'*
'*      Class Name         :    ItLog
'*      Class Description  :    Provides the Entity Level Functionality of table ItLog
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 5:13:24 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;

namespace Entities
{
	public class AuditLogEntity
	{
	#region  Attributes 

		private Int32 m_nId = 0;

		private Int32 m_nUser_id = 0;

		private Int32 m_nMachine_id = 0;

		private String m_strDatetime = String.Empty;

		private String m_strDetails = String.Empty;

		private Int32 m_nOperation = 0;

        private string m_username = string.Empty;

        private string m_machinename = string.Empty;

	#endregion 

	#region  Constructors 

	#endregion 

	#region  Properties 

		public Int32 Id
		{
			get
			{
				return m_nId;

			}
			set
			{
				m_nId = value;

			}
		}

		public Int32 User_id
		{
			get
			{
				return m_nUser_id;

			}
			set
			{
				m_nUser_id = value;

			}
		}

		public Int32 Machine_id
		{
			get
			{
				return m_nMachine_id;

			}
			set
			{
				m_nMachine_id = value;

			}
		}

		public String Datetime
		{
			get
			{
				return m_strDatetime;

			}
			set
			{
				m_strDatetime = value;

			}
		}

		public String Details
		{
			get
			{
				return m_strDetails;

			}
			set
			{
				m_strDetails = value;

			}
		}

		public Int32 Operation
		{
			get
			{
				return m_nOperation;

			}
			set
			{
				m_nOperation = value;

			}
		}

        public string UserName {

            get {
                return m_username;
            }

            set {

                if (value == "" || value == null)
                {
                    m_username = "Not In Use";
                }
                else
                {
                    m_username = value;
                }

               
            }
        
        }


        public string MachineName {

            get {

                return m_machinename;
            }

            set {

                m_machinename = value;
            
            }
            
        }

	#endregion 

	#region  Methods 

	#endregion 

	}
}