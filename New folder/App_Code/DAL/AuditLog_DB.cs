/***************************************************************************************
'*
'*      Class Name         :    ItLogDB
'*      Class Description  :    Provides the Entity Level Functionality of table ItLogDB
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 5:14:07 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class AuditLog_DB
    {
        #region  Attributes

        private SqlConnection m_strconnection = null;

        #endregion

        #region  Constructors

        public AuditLog_DB()
        {

        }

        #endregion

        #region  Properties

        #endregion

        #region  Methods

        public Int32 InsertItLog(AuditLogEntity objitLog)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_InsertAuditLog", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_nuser_id", objitLog.User_id);
            dbCom.Parameters.Add("@p_nmachine_id", objitLog.Machine_id);
            dbCom.Parameters.Add("@p_strdatetime", objitLog.Datetime);
            dbCom.Parameters.Add("@p_strdetails", objitLog.Details);
            dbCom.Parameters.Add("@p_noperation", objitLog.Operation);

            /*Output Parameters*/
            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@p_nid";
            pid.SqlDbType = SqlDbType.Int;
            pid.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pid);

            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();
            objitLog.Id = Int32.Parse(pid.Value.ToString());

            return Int32.Parse(pid.Value.ToString());
        }

        public AuditLogEntity GetItLog(Int32 id)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_GetitLog", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_nid", id);

            /*Output Parameters*/
            SqlParameter puser_id = new SqlParameter();
            puser_id.ParameterName = "@p_nuser_id";
            puser_id.SqlDbType = SqlDbType.Int;
            puser_id.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(puser_id);

            SqlParameter pmachine_id = new SqlParameter();
            pmachine_id.ParameterName = "@p_nmachine_id";
            pmachine_id.SqlDbType = SqlDbType.Int;
            pmachine_id.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pmachine_id);

            SqlParameter pdatetime = new SqlParameter();
            pdatetime.ParameterName = "@p_strdatetime";
            pdatetime.SqlDbType = SqlDbType.NVarChar;
            pdatetime.Size = 20;
            pdatetime.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pdatetime);

            SqlParameter pdetails = new SqlParameter();
            pdetails.ParameterName = "@p_strdetails";
            pdetails.SqlDbType = SqlDbType.NVarChar;
            pdetails.Size = 100;
            pdetails.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pdetails);

            SqlParameter poperation = new SqlParameter();
            poperation.ParameterName = "@p_noperation";
            poperation.SqlDbType = SqlDbType.Int;
            poperation.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(poperation);

            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();

            AuditLogEntity objItLog = new AuditLogEntity();

            objItLog.User_id = Int32.Parse(puser_id.Value.ToString());
            objItLog.Machine_id = Int32.Parse(pmachine_id.Value.ToString());
            objItLog.Datetime = pdatetime.Value.ToString();
            objItLog.Details = pdetails.Value.ToString();
            objItLog.Operation = Int32.Parse(poperation.Value.ToString());
            objItLog.Id = id;

            return objItLog;
        }

        public DataTable GetAllItLog(object id, object user_id, object machine_id, object datetime, object details, object operation,object machineName,object userName)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlDataAdapter dbAdapter = new SqlDataAdapter("usp_GetAllAuditLogs", dbConn);
            dbAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (id != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nid", id);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nid", System.DBNull.Value);
            }
            if (user_id != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nuser_id", user_id);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nuser_id", System.DBNull.Value);
            }
            if (machine_id != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nmachine_id", machine_id);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nmachine_id", System.DBNull.Value);
            }
            if (datetime != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strdatetime", datetime);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strdatetime", System.DBNull.Value);
            }
            if (details != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strdetails", details);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strdetails", System.DBNull.Value);
            }
            if (operation != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_noperation", operation);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_noperation", System.DBNull.Value);
            }

            if (machineName != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nmachinename", machineName);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nmachinename", System.DBNull.Value);
            }
            if (userName != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nusername", userName);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nusername", System.DBNull.Value);
            }




            DataTable dtItLog = new DataTable("AuditLog");

            dbAdapter.Fill(dtItLog);

            return dtItLog;
        }

        public void DeleteItLog(Int32 id)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_DeleteitLog", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_nid", id);

            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void UpdateItLog(AuditLogEntity objitLog)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_UpdateitLog", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_nid", objitLog.Id);
            dbCom.Parameters.Add("@p_nuser_id", objitLog.User_id);
            dbCom.Parameters.Add("@p_nmachine_id", objitLog.Machine_id);
            dbCom.Parameters.Add("@p_strdatetime", objitLog.Datetime);
            dbCom.Parameters.Add("@p_strdetails", objitLog.Details);
            dbCom.Parameters.Add("@p_noperation", objitLog.Operation);

            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();
        }

        #endregion

    }
}