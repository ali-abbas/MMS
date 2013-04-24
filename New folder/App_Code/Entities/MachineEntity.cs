/***************************************************************************************
'*
'*      Class Name         :    Hine
'*      Class Description  :    Provides the Entity Level Functionality of table Hine
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 10:13:43 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;


namespace Entities
{
    public class MachineEntity
    {
        #region  Attributes

        private Int32 m_nId = 0;

        private String m_strName = String.Empty;

        private String m_strComputer_name = String.Empty;

        private String m_strProcessor = String.Empty;

        private String m_strRam = String.Empty;

        private String m_strHarddisk = String.Empty;

        private String m_strSoftware = String.Empty;

        private String m_strDetails = String.Empty;

        private Int32 m_nEnabled = 0;

        private Int32 m_nIsdeleted = 0;

        private Int32 m_nInusedbyuserid = 0;

        private Int32 m_nInpoolid = 0;

        private UserEntity userEntity;

        private string userName = String.Empty;

        private int notInUseFlag = 0;

        private int machineType = 0;

        private int machineTypeFlag = 0;

        private string machineTypeName = string.Empty;

        
        #endregion

        #region  Constructors

        public MachineEntity()
        {
            userEntity = new UserEntity();
        }

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

        public String Computer_name
        {
            get
            {
                return m_strComputer_name;

            }
            set
            {
                m_strComputer_name = value;

            }
        }

        public String Processor
        {
            get
            {
                return m_strProcessor;

            }
            set
            {
                m_strProcessor = value;

            }
        }

        public String Ram
        {
            get
            {
                return m_strRam;

            }
            set
            {
                m_strRam = value;

            }
        }

        public String Harddisk
        {
            get
            {
                return m_strHarddisk;

            }
            set
            {
                m_strHarddisk = value;

            }
        }

        public String Software
        {
            get
            {
                return m_strSoftware;

            }
            set
            {
                m_strSoftware = value;

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

        public String DetailsForGrid
        {
            get
            {
                if (m_strDetails.Length > 25)
                    return m_strDetails.Substring(0, 25) + "..";
                else
                    return m_strDetails;

            }
            set
            {
                m_strDetails = value;

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

        public Int32 Inusedbyuserid
        {
            get
            {
                return m_nInusedbyuserid;

            }
            set
            {
                m_nInusedbyuserid = value;

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



        public UserEntity MachineUser
        {
            get
            {
                return userEntity;

            }
            set
            {
                userEntity = value;

            }
        }

        public string UserName
        {

            get
            {

                return userName;

            }

            set
            {
                userName = value;
            }
        }

        public int notInUserFlag {

            get { return notInUseFlag; }

            set {

                notInUseFlag = value;
            }
            
        }


        public int MachineType {

            get { return machineType; }

            set { machineType = value; }
            
        }

        public int MachineTypeFlag{

            get { return machineTypeFlag; }
            set { machineTypeFlag = value; }
            
        }

        public string MachineTypeName {

            get { return machineTypeName; }

            set { machineTypeName = value; }
        
        }

   
        
        #endregion

        #region  Methods

        #endregion

    }
}