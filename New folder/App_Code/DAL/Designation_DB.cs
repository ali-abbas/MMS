using System;
using System.Data;
using System.Data.SqlClient;
using Entities;


/// <summary>
/// Summary description for Designation_DB
/// </summary>
public class Designation_DB
{
	public Designation_DB()
	{
	}

    public DataTable GetDesignation(object id, object Designation) {

        SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        SqlDataAdapter dbAdapter = new SqlDataAdapter("usp_GetDesignation", dbConn);
        dbAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

        if (id != null)
        {   
            dbAdapter.SelectCommand.Parameters.AddWithValue("@p_nid", id);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.AddWithValue("@p_nid", System.DBNull.Value);
        }


        if (Designation != null)
        {
            dbAdapter.SelectCommand.Parameters.AddWithValue("@p_nDesignation",Designation);
        }
        else
        {
            dbAdapter.SelectCommand.Parameters.AddWithValue("@p_nDesignation",System.DBNull.Value);
        
        }

            DataTable dtMachine = new DataTable("UserDesignation");

            dbAdapter.Fill(dtMachine);

            return dtMachine;
    
    }

}