using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MaintenanceLogEntity
/// </summary>
public class MaintenanceLogEntity
{
    #region constructor
    public MaintenanceLogEntity()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #endregion constructor


    #region Attributes

    private Int32 m_nid = 0;

    private Int32 m_nrepaireByUserId = 0;

    private Int32 m_nmachineId = 0;

    private Int32 m_ncategory = 0;

    private String m_ndatetime=String.Empty;

    private String issue = String.Empty;

    private String resolution = String.Empty;

    private String comments = String.Empty;

    private String repairByUserName = String.Empty;

    private string machineName = String.Empty;

    private string machineType = String.Empty;


    #endregion Attributes

    #region properties

    public Int32 Id {

        get { 
            return m_nid;
        }

        set {

            m_nid = value;
        }
    }
    
    public Int32 RepairByUserId {

        get {

            return m_nrepaireByUserId;
        }

        set {

            m_nrepaireByUserId = value;
        }
    
    }

    public Int32 MachineId {

        get {

            return m_nmachineId;
        }

        set {

            m_nmachineId = value;
        }
    
    }

    public Int32 Category {

        get {

            return m_ncategory;
        }

        set {

            m_ncategory = value;
        }
    }

    public String DateTime {

        get {

            return m_ndatetime;
        }

        set {

            m_ndatetime = value;
        }
        
    }

    public String Issue {

        get {

           return issue;
        }

        set {

            issue = value;
        }
    
    }

    public String Resolution {

        get {

            return resolution;
        }
        set {

            resolution = value;
        }

    }

    public String Comments {

        get {

            return comments;
        }

        set {

            comments = value;
        }
    }

    public String RepairByUserName {

        get {

            return repairByUserName;
        }

        set {

            repairByUserName = value;
        }


    }

    public String MachineName {

        get {

          return  machineName;
        }

        set {

            machineName = value;
        }
            
    }

    public String MachineType {

        get {

            return machineType;
        }

        set {

            machineType = value;

        }
    
    }


    #endregion properties


    #region  Methods

    #endregion Methods


}