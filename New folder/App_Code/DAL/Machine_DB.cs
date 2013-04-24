/***************************************************************************************
'*
'*      Class Name         :    MachineDB
'*      Class Description  :    Provides the Entity Level Functionality of table MachineDB
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 10:14:17 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using Entities;


namespace DAL
{
    public class Machine_DB
    {
        #region  Attributes

        private SqlConnection m_strconnection = null;

        #endregion

        #region  Constructors

        public Machine_DB()
        {

        }

        #endregion

        #region  Properties

        #endregion

        #region  Methods

        public Int32 InsertMachine(MachineEntity objMachine)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_InsertMachine", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_strname", objMachine.Name);
            dbCom.Parameters.Add("@p_strcomputer_name", objMachine.Computer_name);
            dbCom.Parameters.Add("@p_strprocessor", objMachine.Processor);
            dbCom.Parameters.Add("@p_strram", objMachine.Ram);
            dbCom.Parameters.Add("@p_strharddisk", objMachine.Harddisk);
            dbCom.Parameters.Add("@p_strsoftware", objMachine.Software);
            dbCom.Parameters.Add("@p_strdetails", objMachine.Details);
            dbCom.Parameters.Add("@p_nenabled", objMachine.Enabled);
            dbCom.Parameters.Add("@p_nisdeleted", objMachine.Isdeleted);
            dbCom.Parameters.Add("@p_ninusedbyuserid", objMachine.Inusedbyuserid);
            dbCom.Parameters.Add("@p_ninpoolid", objMachine.Inpoolid);
            dbCom.Parameters.Add("@p_nmachineType", objMachine.MachineType);
               

            /*Output Parameters*/
            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@p_nid";
            pid.SqlDbType = SqlDbType.Int;
            pid.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pid);

            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();
            objMachine.Id = Int32.Parse(pid.Value.ToString());

            return Int32.Parse(pid.Value.ToString());
        }

        public MachineEntity GetMachine(Int32 id)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_GetMachine", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_nid", id);
          

            /*Output Parameters*/
            SqlParameter pname = new SqlParameter();
            pname.ParameterName = "@p_strname";
            pname.SqlDbType = SqlDbType.NVarChar;
            pname.Size = 50;
            pname.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pname);

            SqlParameter pprocessor = new SqlParameter();
            pprocessor.ParameterName = "@p_strprocessor";
            pprocessor.SqlDbType = SqlDbType.NVarChar;
            pprocessor.Size = 50;
            pprocessor.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pprocessor);

            SqlParameter pcomputer_name = new SqlParameter();
            pcomputer_name.ParameterName = "@p_strcomputer_name";
            pcomputer_name.SqlDbType = SqlDbType.NVarChar;
            pcomputer_name.Size = 50;
            pcomputer_name.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pcomputer_name);

            SqlParameter pram = new SqlParameter();
            pram.ParameterName = "@p_strram";
            pram.SqlDbType = SqlDbType.NVarChar;
            pram.Size = 50;
            pram.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pram);

            SqlParameter pharddisk = new SqlParameter();
            pharddisk.ParameterName = "@p_strharddisk";
            pharddisk.SqlDbType = SqlDbType.NVarChar;
            pharddisk.Size = 50;
            pharddisk.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pharddisk);

            SqlParameter psoftware = new SqlParameter();
            psoftware.ParameterName = "@p_strsoftware";
            psoftware.SqlDbType = SqlDbType.NVarChar;
            psoftware.Size = 100;
            psoftware.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(psoftware);

            SqlParameter pdetails = new SqlParameter();
            pdetails.ParameterName = "@p_strdetails";
            pdetails.SqlDbType = SqlDbType.NVarChar;
            pdetails.Size = 50;
            pdetails.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pdetails);

            SqlParameter penabled = new SqlParameter();
            penabled.ParameterName = "@p_nenabled";
            penabled.SqlDbType = SqlDbType.Int;
            //penabled.Size = 32;
            penabled.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(penabled);

            SqlParameter pisdeleted = new SqlParameter();
            pisdeleted.ParameterName = "@p_nisdeleted";
            pisdeleted.SqlDbType = SqlDbType.Int;
            //pisdeleted.Size = 32;
            pisdeleted.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pisdeleted);

            SqlParameter pinusedbyuserid = new SqlParameter();
            pinusedbyuserid.ParameterName = "@p_ninusedbyuserid";
            pinusedbyuserid.SqlDbType = SqlDbType.Int;
            //pinusedbyuserid.Size = 32;
            pinusedbyuserid.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pinusedbyuserid);

            SqlParameter pinpoolid = new SqlParameter();
            pinpoolid.ParameterName = "@p_ninpoolid";
            pinpoolid.SqlDbType = SqlDbType.Int;
            //pinpoolid.Size = 32;
            pinpoolid.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(pinpoolid);

            SqlParameter username= new SqlParameter();
            username.ParameterName = "@p_username";
            username.Size = 50;
            username.SqlDbType = SqlDbType.NVarChar;
            username.Direction = ParameterDirection.Output;
            dbCom.Parameters.Add(username);

            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();

            MachineEntity objMachine = new MachineEntity();


                objMachine.Name = pname.Value.ToString();
                objMachine.Computer_name = pcomputer_name.Value.ToString();
                objMachine.Processor = pprocessor.Value.ToString();
                objMachine.Ram = pram.Value.ToString();
                objMachine.Harddisk = pharddisk.Value.ToString();
                objMachine.Software = psoftware.Value.ToString();
                objMachine.Details = pdetails.Value.ToString();
                objMachine.Enabled = Int32.Parse(penabled.Value.ToString());
                objMachine.Isdeleted = Int32.Parse(pisdeleted.Value.ToString());
                objMachine.Inusedbyuserid = Int32.Parse(pinusedbyuserid.Value.ToString());
                objMachine.Inpoolid = Int32.Parse(pinpoolid.Value.ToString());
                objMachine.UserName = username.Value.ToString();
                objMachine.Id = id;
           
            return objMachine;
        }

        public DataTable GetAllMachines(object id, object name, object computer_name, object processor, object ram, object harddisk, object software, object details, object enabled, object isdeleted, object inusedbyuserid, object inpoolid,object noinuseflag,object machineTypeFlag,object machineType,object username)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlDataAdapter dbAdapter = new SqlDataAdapter("usp_GetAllMachines", dbConn);
            dbAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (id != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nid", id);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nid", System.DBNull.Value);
            }
            if (name != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strname", name);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strname", System.DBNull.Value);
            }
            if (computer_name != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strcomputer_name", computer_name);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strcomputer_name", System.DBNull.Value);
            }
            if (processor != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strprocessor", processor);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strprocessor", System.DBNull.Value);
            }
            if (ram != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strram", ram);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strram", System.DBNull.Value);
            }
            if (harddisk != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strharddisk", harddisk);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strharddisk", System.DBNull.Value);
            }
            if (software != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strsoftware", software);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strsoftware", System.DBNull.Value);
            }
            if (details != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strdetails", details);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strdetails", System.DBNull.Value);
            }
            if (enabled != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nenabled", enabled);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nenabled", System.DBNull.Value);
            }
            if (isdeleted != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nisdeleted", isdeleted);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_nisdeleted", System.DBNull.Value);
            }
            if (inusedbyuserid != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_ninusedbyuserid", inusedbyuserid);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_ninusedbyuserid", System.DBNull.Value);
            }
            if (inpoolid != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_ninpoolid", inpoolid);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_ninpoolid", System.DBNull.Value);
            }

            if (noinuseflag != null) {

                dbAdapter.SelectCommand.Parameters.Add("@p_flag",noinuseflag);
            }
            if (machineType != null)
            {

                dbAdapter.SelectCommand.Parameters.Add("@p_machineType", machineType);
            }

            if (machineTypeFlag != null) {

                dbAdapter.SelectCommand.Parameters.Add("@p_flag1",machineTypeFlag);
             }

            if (username != null)
            {

                dbAdapter.SelectCommand.Parameters.Add("@p_username",username);
            }


            DataTable dtMachine = new DataTable("Machine");

            dbAdapter.Fill(dtMachine);

            return dtMachine;
        }

        public void DeleteMachine(Int32 id)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_Deletehine", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_nid", id);

            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();
        }

        public void UpdateMachine(MachineEntity objMachine)
        {

            SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
            SqlCommand dbCom = new SqlCommand("usp_UpdateMachine", dbConn);
            dbCom.CommandType = CommandType.StoredProcedure;


            /*Input Parameters*/
            dbCom.Parameters.Add("@p_nid", objMachine.Id);
            dbCom.Parameters.Add("@p_strname", objMachine.Name);
            dbCom.Parameters.Add("@p_strcomputer_name", objMachine.Computer_name);
            dbCom.Parameters.Add("@p_strprocessor", objMachine.Processor);
            dbCom.Parameters.Add("@p_strram", objMachine.Ram);
            dbCom.Parameters.Add("@p_strharddisk", objMachine.Harddisk);
            dbCom.Parameters.Add("@p_strsoftware", objMachine.Software);
            dbCom.Parameters.Add("@p_strdetails", objMachine.Details);
            dbCom.Parameters.Add("@p_nenabled", objMachine.Enabled);
            dbCom.Parameters.Add("@p_nisdeleted", objMachine.Isdeleted);
            dbCom.Parameters.Add("@p_ninusedbyuserid", objMachine.Inusedbyuserid);
            dbCom.Parameters.Add("@p_ninpoolid", objMachine.Inpoolid);
            dbCom.Parameters.Add("@p_machineType", objMachine.MachineType);
            dbConn.Open();
            dbCom.ExecuteNonQuery();
            dbConn.Close();
        }

        #endregion

    }
}