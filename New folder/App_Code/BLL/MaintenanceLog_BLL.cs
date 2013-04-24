/***************************************************************************************
'*
'*      Class Name         :    MaintenanceLogDB
'*      Class Description  :    Provides the Entity Level Functionality of table MaintenanceLog
'*      Task Owned By      :    Ali Abbas
'*      Creation Date      : 31/7/2012 5:14:07 PM   31/7/2012 12:00:00 AM
'***************************************************************************************/

using System;
using System.Data;

using Entities;
using DAL;
using System.Collections.Generic;
public class MaintenanceLog_BLL
{
    public MaintenanceLog_BLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<MaintenanceLogEntity> GetAllMaintenanceLogs(MaintenanceLogEntity Entity)
    {

        MaintenanceLog_DB DB = new MaintenanceLog_DB();
        DataTable dt = DB.GetAllMaintenanceLog(Entity.Id, Entity.RepairByUserId, Entity.MachineId, Entity.Category, Entity.DateTime, Entity.Issue, Entity.Resolution, Entity.Comments,Entity.MachineName);

        List<MaintenanceLogEntity> Logs = FillEntities(dt);

        return Logs;
    }

    public Int32 InsertMaintenanceLog(MaintenanceLogEntity Entity) {

        MaintenanceLog_DB DB = new MaintenanceLog_DB();
        Int32 id=DB.InsertMaintenanceLog(Entity);
        return id;
    }

    private List<MaintenanceLogEntity> FillEntities(DataTable dt)
    {
        List<MaintenanceLogEntity> Logs = new List<MaintenanceLogEntity>();

        if (dt != null && dt.Rows.Count > 0)
        {

            foreach (DataRow currentRow in dt.Rows)
            {

                MaintenanceLogEntity Entity = new MaintenanceLogEntity();

                Entity.Id = Convert.ToInt32(currentRow["id"].ToString());
                Entity.RepairByUserId = Convert.ToInt32(currentRow["repairbyuserid"].ToString());
                Entity.MachineId = Convert.ToInt32(currentRow["machineid"].ToString());
                Entity.Category = Convert.ToInt32(currentRow["category"].ToString());
                Entity.DateTime = currentRow["datetime"].ToString();
                Entity.Issue = currentRow["issue"].ToString();
                Entity.Resolution = currentRow["resolution"].ToString();
                Entity.Comments = currentRow["comments"].ToString();
                Entity.RepairByUserName = currentRow["repairByUserName"].ToString();
                Entity.MachineName = currentRow["machineName"].ToString();
                Entity.MachineType = currentRow["machineType"].ToString();

                Logs.Add(Entity);
            }

        }

        return Logs;

    }
}