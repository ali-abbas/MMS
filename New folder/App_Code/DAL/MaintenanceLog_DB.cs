/***************************************************************************************
'*
'*      Class Name         :    MaintenanceLogDB
'*      Class Description  :    Provides the Entity Level Functionality of table MaintenanceLog
'*      Task Owned By      :    Ali Abbas
'*      Creation Date      : 31/7/2012 5:14:07 PM   31/7/2012 12:00:00 AM
'***************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using Entities;

public class MaintenanceLog_DB
{

    #region  Attributes

    private SqlConnection m_strconnection = null;

    #endregion

    #region constructor
    public MaintenanceLog_DB()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #endregion constructor


    #region Methods


    public DataTable GetAllMaintenanceLog(object id,object repairByUserId,object machineId,object category,object datetime,object issue,object resolutin,object comments,object machineName)
    {

        SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        SqlDataAdapter dbAdapter = new SqlDataAdapter("usp_GetAllMaintenanceLogs", dbConn);
        dbAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

        if (id != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nid", id);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nid", System.DBNull.Value);
        }
        if (repairByUserId != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nrepairbyuserid",repairByUserId);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nrepairbyuserid", System.DBNull.Value);
        }
        if (machineId != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nmachineid ",machineId);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nmachineid", System.DBNull.Value);
        }
        if (category!= null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_ncategory",category);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_ncategory", System.DBNull.Value);
        }
        if (datetime != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_ndatetime", datetime);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_ndatetime", System.DBNull.Value);
        }
        if (issue != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nissue",issue);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nissue", System.DBNull.Value);
        }

        if (resolutin != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nresolution", resolutin);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nresolution", System.DBNull.Value);
        }
        if (comments != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_ncomments",comments);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_ncomments", System.DBNull.Value);
        }
        if (machineName != null)
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nmachineName", machineName);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.Add("@p_nmachineName", System.DBNull.Value);
        }




        DataTable dtItLog = new DataTable("MaintenanceLog");

        dbAdapter.Fill(dtItLog);

        return dtItLog;
    }


    public Int32 InsertMaintenanceLog(MaintenanceLogEntity Entity) {


        SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        SqlCommand dbCom = new SqlCommand("usp_InsertMaintenanceLog", dbConn);
        dbCom.CommandType = CommandType.StoredProcedure;


        /*Input Parameters*/
        dbCom.Parameters.Add("@p_nrepairbyuserid ", Entity.RepairByUserId);
        dbCom.Parameters.Add("@p_nmachineid", Entity.MachineId);
        dbCom.Parameters.Add("@p_ncategory", Entity.Category);
        dbCom.Parameters.Add("@p_ndatetime", Entity.DateTime);
        dbCom.Parameters.Add("@p_nissue", Entity.Issue);
        dbCom.Parameters.Add("@p_nresolution", Entity.Resolution);
        dbCom.Parameters.Add("@p_ncomments", Entity.Comments);

        /*Output Parameters*/
        SqlParameter pid = new SqlParameter();
        pid.ParameterName = "@p_nid";
        pid.SqlDbType = SqlDbType.Int;
        pid.Direction = ParameterDirection.Output;
        dbCom.Parameters.Add(pid);

        dbConn.Open();
        dbCom.ExecuteNonQuery();
        dbConn.Close();
        Entity.Id = Int32.Parse(pid.Value.ToString());

        return Int32.Parse(pid.Value.ToString());

    }


    #endregion Methods

}