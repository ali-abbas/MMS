/***************************************************************************************
'*
'*      Class Name         :    UserDB
'*      Class Description  :    Provides the Entity Level Functionality of table UserDB
'*      Task Owned By      :    MUHAMMADAUserIF-HP
'*      Creation Date      : 1/7/2012 5:01:26 PM   1/7/2012 12:00:00 AM
'***************************************************************************************/
using System;
using System.Data;
using Entities;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class User_BLL
    {
        #region  Attributes

  
        #endregion

        #region  Constructors

        public User_BLL()
        {

        }

        #endregion

        #region  Properties

        #endregion

        #region  Methods

        //public Int32 InsertUser(UserEntity objUser)
        //{

        //    SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        //    SqlCommand dbCom = new SqlCommand("usp_InsertUser", dbConn);
        //    dbCom.CommandType = CommandType.StoredProcedure;


        //    /*Input Parameters*/
        //    dbCom.Parameters.Add("@p_strname", objUser.Name);
        //    dbCom.Parameters.Add("@p_strloginid", objUser.Loginid);
        //    dbCom.Parameters.Add("@p_stremail", objUser.Email);
        //    dbCom.Parameters.Add("@p_nenabled", objUser.Enabled);
        //    dbCom.Parameters.Add("@p_nisadmin", objUser.Isadmin);
        //    dbCom.Parameters.Add("@p_nisdeleted", objUser.Isdeleted);
        //    dbCom.Parameters.Add("@p_ninpoolid", objUser.Inpoolid);

        //    /*Output Parameters*/
        //    SqlParameter pid = new SqlParameter();
        //    pid.ParameterName = "@p_nid";
        //    pid.SqlDbType = SqlDbType.Int;
        //    pid.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(pid);

        //    dbConn.Open();
        //    dbCom.ExecuteNonQuery();
        //    dbConn.Close();
        //    objUser.Id = Int32.Parse(pid.Value.ToString());

        //    return Int32.Parse(pid.Value.ToString());
        //}

        //public UserEntity GetUser(Int32 id)
        //{

        //    SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        //    SqlCommand dbCom = new SqlCommand("usp_GetUser", dbConn);
        //    dbCom.CommandType = CommandType.StoredProcedure;


        //    /*Input Parameters*/
        //    dbCom.Parameters.Add("@p_nid", id);

        //    /*Output Parameters*/
        //    SqlParameter pname = new SqlParameter();
        //    pname.ParameterName = "@p_strname";
        //    pname.SqlDbType = SqlDbType.NVarChar;
        //    pname.Size = 50;
        //    pname.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(pname);

        //    SqlParameter ploginid = new SqlParameter();
        //    ploginid.ParameterName = "@p_strloginid";
        //    ploginid.SqlDbType = SqlDbType.NVarChar;
        //    ploginid.Size = 50;
        //    ploginid.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(ploginid);

        //    SqlParameter pemail = new SqlParameter();
        //    pemail.ParameterName = "@p_stremail";
        //    pemail.SqlDbType = SqlDbType.NVarChar;
        //    pemail.Size = 50;
        //    pemail.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(pemail);

        //    SqlParameter penabled = new SqlParameter();
        //    penabled.ParameterName = "@p_nenabled";
        //    penabled.SqlDbType = SqlDbType.Int;
        //    penabled.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(penabled);

        //    SqlParameter pisadmin = new SqlParameter();
        //    pisadmin.ParameterName = "@p_nisadmin";
        //    pisadmin.SqlDbType = SqlDbType.Int;
        //    pisadmin.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(pisadmin);

        //    SqlParameter pisdeleted = new SqlParameter();
        //    pisdeleted.ParameterName = "@p_nisdeleted";
        //    pisdeleted.SqlDbType = SqlDbType.Int;
        //    pisdeleted.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(pisdeleted);

        //    SqlParameter pinpoolid = new SqlParameter();
        //    pinpoolid.ParameterName = "@p_ninpoolid";
        //    pinpoolid.SqlDbType = SqlDbType.Int;
        //    pinpoolid.Direction = ParameterDirection.Output;
        //    dbCom.Parameters.Add(pinpoolid);

        //    dbConn.Open();
        //    dbCom.ExecuteNonQuery();
        //    dbConn.Close();

        //    UserEntity objUser = new UserEntity();

        //    objUser.Name = pname.Value.ToString();
        //    objUser.Loginid = ploginid.Value.ToString();
        //    objUser.Email = pemail.Value.ToString();
        //    objUser.Enabled = Int32.Parse(penabled.Value.ToString());
        //    objUser.Isadmin = Int32.Parse(pisadmin.Value.ToString());
        //    objUser.Isdeleted = Int32.Parse(pisdeleted.Value.ToString());
        //    objUser.Inpoolid = Int32.Parse(pinpoolid.Value.ToString());
        //    objUser.Id = id;

        //    return objUser;
        //}

        public List<UserEntity> GetAllUsers(UserEntity objUser)
        {
            User_DB objUserDb = new User_DB();
            DataTable dt = objUserDb.GetAllUsers(objUser.Id, objUser.Name, objUser.Loginid, objUser.Password, objUser.Email, objUser.Enabled, objUser.Isadmin, objUser.Isdeleted, objUser.Inpoolid);

            return FillEntities(dt);
        }

        //public void DeleteUser(Int32 id)
        //{

        //    SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        //    SqlCommand dbCom = new SqlCommand("usp_DeleteUser", dbConn);
        //    dbCom.CommandType = CommandType.StoredProcedure;


        //    /*Input Parameters*/
        //    dbCom.Parameters.Add("@p_nid", id);

        //    dbConn.Open();
        //    dbCom.ExecuteNonQuery();
        //    dbConn.Close();
        //}

        //public void UpdateUser(UserEntity objUser)
        //{

        //    SqlConnection dbConn = new SqlConnection(Helper.GetDBConnectionString());
        //    SqlCommand dbCom = new SqlCommand("usp_UpdateUser", dbConn);
        //    dbCom.CommandType = CommandType.StoredProcedure;


        //    /*Input Parameters*/
        //    dbCom.Parameters.Add("@p_nid", objUser.Id);
        //    dbCom.Parameters.Add("@p_strname", objUser.Name);
        //    dbCom.Parameters.Add("@p_strloginid", objUser.Loginid);
        //    dbCom.Parameters.Add("@p_stremail", objUser.Email);
        //    dbCom.Parameters.Add("@p_nenabled", objUser.Enabled);
        //    dbCom.Parameters.Add("@p_nisadmin", objUser.Isadmin);
        //    dbCom.Parameters.Add("@p_nisdeleted", objUser.Isdeleted);
        //    dbCom.Parameters.Add("@p_ninpoolid", objUser.Inpoolid);

        //    dbConn.Open();
        //    dbCom.ExecuteNonQuery();
        //    dbConn.Close();
        //}

        private List<UserEntity> FillEntities(DataTable dt)
        {
            List<UserEntity> objUserList = new List<UserEntity>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow currentRow in dt.Rows)
                {
                    UserEntity currentUser = new UserEntity();
                    currentUser.Email = currentRow["email"].ToString();
                    currentUser.Enabled = Convert.ToInt32( currentRow["enabled"].ToString());
                    currentUser.Id = Convert.ToInt32( currentRow["id"].ToString());
                    currentUser.Inpoolid = currentRow["inpoolid"] == DBNull.Value ? -1 : Convert.ToInt32( currentRow["inpoolid"].ToString());
                    currentUser.Isadmin = Convert.ToInt32( currentRow["isadmin"].ToString());
                    currentUser.Isdeleted = Convert.ToInt32(currentRow["isdeleted"].ToString());
                    currentUser.Loginid = currentRow["loginid"].ToString();
                    currentUser.Name = currentRow["name"].ToString();
                    currentUser.Password = currentRow["password"].ToString();
                    currentUser.userDesignation = currentRow["userDesignation"].ToString();
                    currentUser.userDesignationId = int.Parse(currentRow["designation"].ToString()) ;

                    objUserList.Add(currentUser);
                }

            }

            return objUserList;
        }


        public void UpdateUser(UserEntity objUser) {

            User_DB objUserDb = new User_DB();
            objUserDb.UpdateUser(objUser);
        
        }

        public int InsertUser(UserEntity objUser) {

            User_DB objUserDb = new User_DB();
            int id=objUserDb.InsertUser(objUser);
            return id;
        }

        #endregion

    }
}