/***************************************************************************************
'*
'*      Class Name         :    R
'*      Class Description  :    Provides the Entity Level Functionality of table R
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 3:43:07 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;


namespace Entities
{
	public class UserEntity
	{
	    #region  Attributes 

		private Int32 m_nId = 0;

		private String m_strName = String.Empty;

		private String m_strLoginid = String.Empty;

        private String m_strPassword = String.Empty;

		private String m_strEmail = String.Empty;

		private Int32 m_nEnabled = 0;

		private Int32 m_nIsadmin = 0;

		private Int32 m_nIsdeleted = 0;

		private Int32 m_nInpoolid = 0;

        private string m_userDesignation = string.Empty;

        private Int32 m_userDesignationId = 0;

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

		public String Name
		{
			get
			{
				return m_strName;

			}
			set
			{
				m_strName = value;

			}
		}

		public String Loginid
		{
			get
			{
				return m_strLoginid;

			}
			set
			{
				m_strLoginid = value;

			}
		}

        public String Password
        {
            get
            {
                return m_strPassword;

            }
            set
            {
                m_strPassword = value;

            }
        }

		public String Email
		{
			get
			{
				return m_strEmail;

			}
			set
			{
				m_strEmail = value;

			}
		}

		public Int32 Enabled
		{
			get
			{
				return m_nEnabled;

			}
			set
			{
				m_nEnabled = value;

			}
		}

		public Int32 Isadmin
		{
			get
			{
				return m_nIsadmin;

			}
			set
			{
				m_nIsadmin = value;

			}
		}

		public Int32 Isdeleted
		{
			get
			{
				return m_nIsdeleted;

			}
			set
			{
				m_nIsdeleted = value;

			}
		}

		public Int32 Inpoolid
		{
			get
			{
				return m_nInpoolid;

			}
			set
			{
				m_nInpoolid = value;

			}
		}

        public string userDesignation {

            get {

                return m_userDesignation;
            }

            set {

                m_userDesignation = value;
            }
            
        }

        public Int32 userDesignationId {

            get {

                return m_userDesignationId;
            }

            set {

                m_userDesignationId = value;
            }

            
        }

	#endregion 

	#region  Methods 

	#endregion 

	}
}