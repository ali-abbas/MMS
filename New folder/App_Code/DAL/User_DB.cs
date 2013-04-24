/***************************************************************************************
'*
'*      Class Name         :    UserDB
'*      Class Description  :    Provides the Entity Level Functionality of table UserDB
'*      Task Owned By      :    MUHAMMADAUserIF-HP
'*      Creation Date      : 1/7/2012 5:01:26 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
	public class User_DB
	{
	#region  Attributes 

		private SqlConnection m_strconnection = null;

	#endregion 

	#region  Constructors 

		public User_DB()
		{

		}

	#endregion 

	#region  Properties 

	#endregion 

	#region  Methods 

		public Int32 InsertUser(UserEntity objUser)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlCommand dbCom=new SqlCommand("usp_InsertUser", dbConn);
			dbCom.CommandType=CommandType.StoredProcedure;


 /*Input Parameters*/
			dbCom.Parameters.Add("@p_strname",objUser.Name);
			dbCom.Parameters.Add("@p_strloginid",objUser.Loginid);
			dbCom.Parameters.Add("@p_stremail",objUser.Email);
			dbCom.Parameters.Add("@p_nenabled",objUser.Enabled);
			dbCom.Parameters.Add("@p_nisadmin",objUser.Isadmin);
			dbCom.Parameters.Add("@p_nisdeleted",objUser.Isdeleted);
			dbCom.Parameters.Add("@p_ninpoolid",objUser.Inpoolid);
            dbCom.Parameters.Add("@p_npassword", objUser.Password);
            dbCom.Parameters.Add("@p_ndesignation", objUser.userDesignationId);
                

 /*Output Parameters*/
			SqlParameter pid=new SqlParameter();
			pid.ParameterName="@p_nid";
			pid.SqlDbType = SqlDbType.Int;
			pid.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pid);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();
			objUser.Id = Int32.Parse(pid.Value.ToString());

			return Int32.Parse(pid.Value.ToString());
		}

		public UserEntity GetUser(Int32 id)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlCommand dbCom=new SqlCommand("usp_GetUser", dbConn);
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

			SqlParameter ploginid=new SqlParameter();
			ploginid.ParameterName="@p_strloginid";
			ploginid.SqlDbType = SqlDbType.NVarChar;
			ploginid.Size = 50;
			ploginid.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(ploginid);

			SqlParameter pemail=new SqlParameter();
			pemail.ParameterName="@p_stremail";
			pemail.SqlDbType = SqlDbType.NVarChar;
			pemail.Size = 50;
			pemail.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pemail);

			SqlParameter penabled=new SqlParameter();
			penabled.ParameterName="@p_nenabled";
			penabled.SqlDbType = SqlDbType.Int;
			penabled.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(penabled);

			SqlParameter pisadmin=new SqlParameter();
			pisadmin.ParameterName="@p_nisadmin";
			pisadmin.SqlDbType = SqlDbType.Int;
			pisadmin.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pisadmin);

			SqlParameter pisdeleted=new SqlParameter();
			pisdeleted.ParameterName="@p_nisdeleted";
			pisdeleted.SqlDbType = SqlDbType.Int;
			pisdeleted.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pisdeleted);

			SqlParameter pinpoolid=new SqlParameter();
			pinpoolid.ParameterName="@p_ninpoolid";
			pinpoolid.SqlDbType = SqlDbType.Int;
			pinpoolid.Direction=ParameterDirection.Output;
			dbCom.Parameters.Add(pinpoolid);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();

                UserEntity objUser = new UserEntity();

			objUser.Name = pname.Value.ToString();
			objUser.Loginid = ploginid.Value.ToString();
			objUser.Email = pemail.Value.ToString();
			objUser.Enabled = Int32.Parse(penabled.Value.ToString());
			objUser.Isadmin = Int32.Parse(pisadmin.Value.ToString());
			objUser.Isdeleted = Int32.Parse(pisdeleted.Value.ToString());
			objUser.Inpoolid = Int32.Parse(pinpoolid.Value.ToString());
			objUser.Id = id;

			return objUser;
		}

		public DataTable GetAllUsers(object id, object name, object loginid, object password, object email, object enabled, object isadmin, object isdeleted, object inpoolid)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlDataAdapter dbAdapter=new SqlDataAdapter("usp_GetAllUsers", dbConn);
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
			if(loginid!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_strloginid",loginid);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_strloginid",System.DBNull.Value);
			}
            if (password != null)
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strpassword", password);
            }
            else
            {
                dbAdapter.SelectCommand.Parameters.Add("@p_strpassword", System.DBNull.Value);
            }
			if(email!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_stremail",email);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_stremail",System.DBNull.Value);
			}
			if(enabled!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nenabled",enabled);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nenabled",System.DBNull.Value);
			}
			if(isadmin!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nisadmin",isadmin);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nisadmin",System.DBNull.Value);
			}
			if(isdeleted!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nisdeleted",isdeleted);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_nisdeleted",System.DBNull.Value);
			}
			if(inpoolid!=null)
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_ninpoolid",inpoolid);
			}
			else
			{
				dbAdapter.SelectCommand.Parameters.Add("@p_ninpoolid",System.DBNull.Value);
			}

			DataTable dtUser=new DataTable("User");

			dbAdapter.Fill(dtUser);

			return dtUser;
		}

		public void DeleteUser(Int32 id)
		{

			SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			SqlCommand dbCom=new SqlCommand("usp_DeleteUser", dbConn);
			dbCom.CommandType=CommandType.StoredProcedure;


 /*Input Parameters*/
			dbCom.Parameters.Add("@p_nid",id);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();
		}

		public void UpdateUser(UserEntity objUser)
		{

			    SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
			    SqlCommand dbCom=new SqlCommand("usp_UpdateUser", dbConn);
			    dbCom.CommandType=CommandType.StoredProcedure;


                 /*Input Parameters*/
			    dbCom.Parameters.Add("@p_nid",objUser.Id);
			    dbCom.Parameters.Add("@p_strname",objUser.Name);
			    dbCom.Parameters.Add("@p_strloginid",objUser.Loginid);
			    dbCom.Parameters.Add("@p_stremail",objUser.Email);
			    dbCom.Parameters.Add("@p_nenabled",objUser.Enabled);
			    dbCom.Parameters.Add("@p_nisadmin",objUser.Isadmin);
			    dbCom.Parameters.Add("@p_nisdeleted",objUser.Isdeleted);
			    dbCom.Parameters.Add("@p_ninpoolid",objUser.Inpoolid);
                dbCom.Parameters.Add("@p_npassword", objUser.Password);
                dbCom.Parameters.Add("@p_ndesignation", objUser.userDesignationId);

				dbConn.Open();
				dbCom.ExecuteNonQuery();
				dbConn.Close();
		}

	#endregion 

	}
}