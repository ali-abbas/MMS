using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data;

using DAL;
using Entities;
/// <summary>
/// Summary description for AuditLog_BLL
/// </summary>
public class AuditLog_BLL
{
	public AuditLog_BLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public Int32 insertItLog(AuditLogEntity Entity) {

        AuditLog_DB DB = new AuditLog_DB();
        int id=DB.InsertItLog(Entity);
        return id;
    }

    public List<AuditLogEntity> GetAllLogs(AuditLogEntity Entity) {

        AuditLog_DB DB=new AuditLog_DB();
        DataTable dt = DB.GetAllItLog(Entity.Id, Entity.User_id, Entity.Machine_id, Entity.Datetime, Entity.Details, Entity.Operation,Entity.MachineName,Entity.UserName);
        List<AuditLogEntity> list_logs = FillEntities(dt);
        return list_logs;
    }

    private List<AuditLogEntity> FillEntities(DataTable dt)
    {
        List<AuditLogEntity> listLogs=new List<AuditLogEntity>();

        if (dt != null && dt.Rows.Count > 0) {

            foreach (DataRow currentrow in dt.Rows )
            {
                AuditLogEntity entity = new AuditLogEntity();

                entity.Id = int.Parse(currentrow["id"].ToString());
                entity.Machine_id = int.Parse(currentrow["machine_id"].ToString());
                entity.User_id = int.Parse(currentrow["user_id"].ToString());
                entity.Operation = int.Parse(currentrow["operation"].ToString());
                entity.Datetime = currentrow["datetime"].ToString();
                entity.Details = currentrow["details"].ToString();
                entity.MachineName = currentrow["name1"].ToString();
                entity.UserName = currentrow["name"].ToString();
              
                listLogs.Add(entity);
            }

            
        }
        return listLogs;

    }


}