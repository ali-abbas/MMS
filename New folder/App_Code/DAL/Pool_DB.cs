/***************************************************************************************
'*
'*      Class Name         :    LDB
'*      Class Description  :    Provides the Entity Level Functionality of table LDB
'*      Task Owned By      :    MUHAMMADARIF-HP
'*      Creation Date      : 1/7/2012 5:18:13 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
	public class Pool_DB
	{
	#region  Attributes 

		private SqlConnection m_strconnection = null;

	#endregion 

	#region  Constructors 

		public Pool_DB()
		{

		}

	#endregion 

	#region  Properties 

	#endregion 

	#region  Methods 

		public Int32 InsertL(PoolEntity objL)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlCommand dbCom=new SqlCommand("usp_Insertl", dbConn);
			dbCom.CommandType=CommandType.StoredProcedure;


 /*Input Parameters*/
			dbCom.Parameters.Add("@p_strname",objL.Name);
			dbCom.Parameters.Add("@p_nenabled",objL.Enabled);
			dbCom.Parameters.Add("@p_nisdeleted",objL.Isdeleted);

 /*Output Parameters*/
			SqlParameter pid=new SqlParameter();
			pid.ParameterName="@p_nid";
			pid.SqlDbType = SqlDbType.Int;
			pid.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pid);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();
			objL.Id = Int32.Parse(pid.Value.ToString());

			return Int32.Parse(pid.Value.ToString());
		}

		public PoolEntity GetL(Int32 id)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlCommand dbCom=new SqlCommand("usp_Getl", dbConn);
			dbCom.CommandType=CommandType.StoredProcedure;


 /*Input Parameters*/
			dbCom.Parameters.Add("@p_nid",id);

 /*Output Parameters*/
			SqlParameter pname=new SqlParameter();
			pname.ParameterName="@p_strname";
			pname.SqlDbType = SqlDbType.NVarChar;
			pname.Size = 50;
			pname.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pname);

			SqlParameter penabled=new SqlParameter();
			penabled.ParameterName="@p_nenabled";
			penabled.SqlDbType = SqlDbType.Int;
			penabled.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(penabled);

			SqlParameter pisdeleted=new SqlParameter();
			pisdeleted.ParameterName="@p_nisdeleted";
			pisdeleted.SqlDbType = SqlDbType.Int;
			pisdeleted.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pisdeleted);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();

			PoolEntity objL = new PoolEntity();

			objL.Name = pname.Value.ToString();
			objL.Enabled = Int32.Parse(penabled.Value.ToString());
			objL.Isdeleted = Int32.Parse(pisdeleted.Value.ToString());
			objL.Id = id;

			return objL;
		}

		public DataTable GetAllL(object id, object name, object enabled, object isdeleted)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlDataAdapter dbAdapter=new SqlDataAdapter("usp_GetAlll", dbConn);
			dbAdapter.SelectCommand.CommandType=CommandType.StoredProcedure;

			if(id!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nid",id);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nid",System.DBNull.Value);
			}
			if(name!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_strname",name);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_strname",System.DBNull.Value);
			}
			if(enabled!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nenabled",enabled);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nenabled",System.DBNull.Value);
			}
			if(isdeleted!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nisdeleted",isdeleted);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nisdeleted",System.DBNull.Value);
			}

			DataTable dtL=new DataTable("L");

			dbAdapter.Fill(dtL);

			return dtL;
		}

		public void DeleteL(Int32 id)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlCommand dbCom=new SqlCommand("usp_Deletel", dbConn);
			dbCom.CommandType=CommandType.StoredProcedure;


 /*Input Parameters*/
			dbCom.Parameters.Add("@p_nid",id);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();
		}

		public void UpdateL(PoolEntity objL)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlCommand dbCom=new SqlCommand("usp_Updatel", dbConn);
			dbCom.CommandType=CommandType.StoredProcedure;


 /*Input Parameters*/
			dbCom.Parameters.Add("@p_nid",objL.Id);
			dbCom.Parameters.Add("@p_strname",objL.Name);
			dbCom.Parameters.Add("@p_nenabled",objL.Enabled);
			dbCom.Parameters.Add("@p_nisdeleted",objL.Isdeleted);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();
		}

	#endregion 

	}
}