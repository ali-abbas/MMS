/***************************************************************************************
'*
'*      Class Name         :    L
'*      Class Description  :    Provides the Entity Level Functionality of table L
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 5:18:34 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;

namespace Entities
{
	public class PoolEntity
	{
	#region  Attributes 

		private Int32 m_nId = 0;

		private String m_strName = String.Empty;

		private Int32 m_nEnabled = 0;

		private Int32 m_nIsdeleted = 0;

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

	#endregion 

	#region  Methods 

	#endregion 

	}
}