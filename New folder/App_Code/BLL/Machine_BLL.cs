/***************************************************************************************
'*
'*      Class Name         :    MachineDB
'*      Class Description  :    Provides the Entity Level Functionality of table MachineDB
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 10:14:17 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;
using System.Data;

using Entities;
using DAL;
using System.Collections.Generic;


namespace BLL
{
    public class Machine_BLL
    {
        #region  Attributes



        #endregion

        #region  Constructors

        public Machine_BLL()
        {

        }

        #endregion

        #region  Properties

        #endregion

        #region  Methods

        //       public Int32 InsertMachine(MachineEntity objMachine)
        //       {

        //           SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        //           SqlCommand dbCom=new SqlCommand("usp_Inserthine", dbConn);
        //           dbCom.CommandType=CommandType.StoredProcedure;


        ///*Input Parameters*/
        //           dbCom.Parameters.Add("@p_strname",objMachine.Name);
        //           dbCom.Parameters.Add("@p_strcomputer_name",objMachine.Computer_name);
        //           dbCom.Parameters.Add("@p_strprocessor",objMachine.Processor);
        //           dbCom.Parameters.Add("@p_strram",objMachine.Ram);
        //           dbCom.Parameters.Add("@p_strharddisk",objMachine.Harddisk);
        //           dbCom.Parameters.Add("@p_strsoftware",objMachine.Software);
        //           dbCom.Parameters.Add("@p_strdetails",objMachine.Details);
        //           dbCom.Parameters.Add("@p_nenabled",objMachine.Enabled);
        //           dbCom.Parameters.Add("@p_nisdeleted",objMachine.Isdeleted);
        //           dbCom.Parameters.Add("@p_ninusedbyuserid",objMachine.Inusedbyuserid);
        //           dbCom.Parameters.Add("@p_ninpoolid",objMachine.Inpoolid);

        ///*Output Parameters*/
        //           SqlParameter pid=new SqlParameter();
        //           pid.ParameterName="@p_nid";
        //           pid.SqlDbType = SqlDbType.Int;
        //           pid.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pid);

        //               dbConn.Open();
        //               dbCom.ExecuteNonQuery();
        //               dbConn.Close();
        //           objMachine.Id = Int32.Parse(pid.Value.ToString());

        //           return Int32.Parse(pid.Value.ToString());
        //       }

        //       public MachineEntity GetMachine(Int32 id)
        //       {

        //           SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        //           SqlCommand dbCom=new SqlCommand("usp_Gethine", dbConn);
        //           dbCom.CommandType=CommandType.StoredProcedure;


        ///*Input Parameters*/
        //           dbCom.Parameters.Add("@p_nid",id);

        ///*Output Parameters*/
        //           SqlParameter pname=new SqlParameter();
        //           pname.ParameterName="@p_strname";
        //           pname.SqlDbType = SqlDbType.NVarChar;
        //           pname.Size = 50;
        //           pname.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pname);

        //           SqlParameter pcomputer_name=new SqlParameter();
        //           pcomputer_name.ParameterName="@p_strcomputer_name";
        //           pcomputer_name.SqlDbType = SqlDbType.NVarChar;
        //           pcomputer_name.Size = 50;
        //           pcomputer_name.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pcomputer_name);

        //           SqlParameter pprocessor=new SqlParameter();
        //           pprocessor.ParameterName="@p_strprocessor";
        //           pprocessor.SqlDbType = SqlDbType.NVarChar;
        //           pprocessor.Size = 50;
        //           pprocessor.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pprocessor);

        //           SqlParameter pram=new SqlParameter();
        //           pram.ParameterName="@p_strram";
        //           pram.SqlDbType = SqlDbType.NVarChar;
        //           pram.Size = 50;
        //           pram.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pram);

        //           SqlParameter pharddisk=new SqlParameter();
        //           pharddisk.ParameterName="@p_strharddisk";
        //           pharddisk.SqlDbType = SqlDbType.NVarChar;
        //           pharddisk.Size = 50;
        //           pharddisk.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pharddisk);

        //           SqlParameter psoftware=new SqlParameter();
        //           psoftware.ParameterName="@p_strsoftware";
        //           psoftware.SqlDbType = SqlDbType.NVarChar;
        //           psoftware.Size = 100;
        //           psoftware.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(psoftware);

        //           SqlParameter pdetails=new SqlParameter();
        //           pdetails.ParameterName="@p_strdetails";
        //           pdetails.SqlDbType = SqlDbType.NVarChar;
        //           pdetails.Size = 50;
        //           pdetails.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pdetails);

        //           SqlParameter penabled=new SqlParameter();
        //           penabled.ParameterName="@p_nenabled";
        //           penabled.SqlDbType = SqlDbType.Int;
        //           penabled.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(penabled);

        //           SqlParameter pisdeleted=new SqlParameter();
        //           pisdeleted.ParameterName="@p_nisdeleted";
        //           pisdeleted.SqlDbType = SqlDbType.Int;
        //           pisdeleted.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pisdeleted);

        //           SqlParameter pinusedbyuserid=new SqlParameter();
        //           pinusedbyuserid.ParameterName="@p_ninusedbyuserid";
        //           pinusedbyuserid.SqlDbType = SqlDbType.Int;
        //           pinusedbyuserid.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pinusedbyuserid);

        //           SqlParameter pinpoolid=new SqlParameter();
        //           pinpoolid.ParameterName="@p_ninpoolid";
        //           pinpoolid.SqlDbType = SqlDbType.Int;
        //           pinpoolid.Direction=ParameterDirection.Output;
        //           dbCom.Parameters.Add(pinpoolid);

        //               dbConn.Open();
        //               dbCom.ExecuteNonQuery();
        //               dbConn.Close();

        //           MachineEntity objMachine = new MachineEntity();

        //           objMachine.Name = pname.Value.ToString();
        //           objMachine.Computer_name = pcomputer_name.Value.ToString();
        //           objMachine.Processor = pprocessor.Value.ToString();
        //           objMachine.Ram = pram.Value.ToString();
        //           objMachine.Harddisk = pharddisk.Value.ToString();
        //           objMachine.Software = psoftware.Value.ToString();
        //           objMachine.Details = pdetails.Value.ToString();
        //           objMachine.Enabled = Int32.Parse(penabled.Value.ToString());
        //           objMachine.Isdeleted = Int32.Parse(pisdeleted.Value.ToString());
        //           objMachine.Inusedbyuserid = Int32.Parse(pinusedbyuserid.Value.ToString());
        //           objMachine.Inpoolid = Int32.Parse(pinpoolid.Value.ToString());
        //           objMachine.Id = id;

        //           return objMachine;
        //       }

        public List<MachineEntity> GetAllMachines(MachineEntity objMachine)
        {
            Machine_DB objMachineDb = new Machine_DB();
            
            DataTable dt = objMachineDb.GetAllMachines(objMachine.Id, objMachine.Name, objMachine.Computer_name, objMachine.Processor, objMachine.Ram, objMachine.Harddisk, objMachine.Software, objMachine.Details, objMachine.Enabled, objMachine.Isdeleted, objMachine.Inusedbyuserid, objMachine.Inpoolid,objMachine.notInUserFlag,objMachine.MachineTypeFlag,objMachine.MachineType,objMachine.UserName);

            return FillEntities(dt);
        }

        public MachineEntity GetMachine(MachineEntity objMachine) {

            Machine_DB objMachineDb = new Machine_DB();
           MachineEntity objMac=objMachineDb.GetMachine(objMachine.Id);
           return objMac;
        }
        
        //       public void DeleteMachine(Int32 id)
        //       {

        //           SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        //           SqlCommand dbCom=new SqlCommand("usp_Deletehine", dbConn);
        //           dbCom.CommandType=CommandType.StoredProcedure;


        ///*Input Parameters*/
        //           dbCom.Parameters.Add("@p_nid",id);

        //               dbConn.Open();
        //               dbCom.ExecuteNonQuery();
        //               dbConn.Close();
        //       }

        public void UpdateMachine(MachineEntity objMachine)
        {
            Machine_DB objMachineDb = new Machine_DB();
            objMachineDb.UpdateMachine(objMachine);
        }

        public Int32 InsertMachine(MachineEntity objMachine)
        {
            Machine_DB objMachineDb = new Machine_DB();
            Int32 Id=objMachineDb.InsertMachine(objMachine);
            return Id;
        }

        private List<MachineEntity> FillEntities(DataTable dt)
        {
            List<MachineEntity> objUserList = new List<MachineEntity>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow currentRow in dt.Rows)
                {
                    MachineEntity currentMachine = new MachineEntity();
                    currentMachine.Computer_name = currentRow["computer_name"].ToString();
                    currentMachine.Details = currentRow["details"].ToString();
                    currentMachine.Enabled = Convert.ToInt32(currentRow["enabled"].ToString());
                    currentMachine.Harddisk = currentRow["harddisk"].ToString();
                    currentMachine.Id = Convert.ToInt32(currentRow["id"].ToString());
                    currentMachine.Inpoolid = currentRow["inpoolid"] == DBNull.Value ? -1 : Convert.ToInt32(currentRow["inpoolid"].ToString());
                    currentMachine.Inusedbyuserid = currentRow["inusedbyuserid"] == DBNull.Value ? -1 : Convert.ToInt32(currentRow["inusedbyuserid"].ToString()); 
                    currentMachine.Isdeleted = Convert.ToInt32(currentRow["isdeleted"].ToString());
                    currentMachine.Name = currentRow["name"].ToString();
                    currentMachine.Processor = currentRow["processor"].ToString();
                    currentMachine.Ram = currentRow["ram"].ToString();
                    currentMachine.Software = currentRow["software"].ToString();
                    currentMachine.MachineUser.Name = currentRow["username"].ToString();
                    currentMachine.UserName = currentRow["username"].ToString();
                    currentMachine.MachineTypeName= currentRow["Type"].ToString();

                    objUserList.Add(currentMachine);
                }

            }

            return objUserList;
        }

        #endregion

    }
}