using System;
using System.Data;

using Entities;
using DAL;
using System.Collections.Generic;

/// <summary>
/// Summary description for Designation_BLL
/// </summary>
public class Designation_BLL
{
	public Designation_BLL()
	{
	}


    public List<UserDesignationEntity> GetDesignation(UserDesignationEntity entity) {

        Designation_DB DBObj = new Designation_DB();
        DataTable dt=DBObj.GetDesignation(entity.Id, entity.UserDesignation);
        return FillEntities(dt);
    }

    private List<UserDesignationEntity> FillEntities(DataTable dt)
    {
        List<UserDesignationEntity> list = new List<UserDesignationEntity>();

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow currentRow in dt.Rows)
            {
                UserDesignationEntity entity = new UserDesignationEntity();

                entity.Id =int.Parse(currentRow["id"].ToString());
                entity.UserDesignation = currentRow["Designation"].ToString();

                list.Add(entity);
            }
        }

        return list;
    }
}