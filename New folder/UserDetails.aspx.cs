using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entities;

public partial class UserDetails : System.Web.UI.Page
{
    int userId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            userId = int.Parse(Request.QueryString["userId"]);


            User_BLL userBlObj = new User_BLL();
            List<UserEntity> users = new List<UserEntity>();
            UserEntity userEntity = new UserEntity();
            userEntity.Id = userId;

            if (userId != 0)
            {

                users = userBlObj.GetAllUsers(userEntity);

                Name_TB.Text = users[0].Name;
                Email_TB.Text = users[0].Email;
                Loginid_TB.Text = users[0].Loginid;
                Password_TB.Text = users[0].Password;
                Designation_TB.Text = users[0].userDesignation;

                InsertBtn.Visible = false;
            }
            else
            {
                UpdateBtn.Visible = false;

            }



            UserDesignationEntity designationEntity = new UserDesignationEntity();
            Designation_BLL DesiObj = new Designation_BLL();

            DesignationsDW.DataSource = DesiObj.GetDesignation(designationEntity);
            DesignationsDW.DataTextField = "UserDesignation";
            DesignationsDW.DataValueField = "Id";
            DesignationsDW.DataBind();
        }

    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        UserEntity userEntity = new UserEntity();
        User_BLL user = new User_BLL();

        //Getting user designation..
        UserDesignationEntity userDE = new UserDesignationEntity();
        List<UserDesignationEntity> list = new List<UserDesignationEntity>();
        userDE.UserDesignation=Designation_TB.Text;
        Designation_BLL desObj = new Designation_BLL();
        list=desObj.GetDesignation(userDE);

        userEntity.Id = int.Parse(Request.QueryString["userId"]);
        userEntity.Email = Email_TB.Text;
        userEntity.Name = Name_TB.Text;
        userEntity.Password = Password_TB.Text;
        userEntity.Loginid = Loginid_TB.Text;
        userEntity.Inpoolid = 1;
        userEntity.Isdeleted = 0;
        userEntity.Isadmin = 0;
        userEntity.Isadmin = 0;

        if (list[0].Id != 0) {

            userEntity.userDesignationId =list[0].Id;
        }

        user.UpdateUser(userEntity);
    }

    protected void InsertBtn_Click(object sender, EventArgs e)
    {
        UserEntity userEntity = new UserEntity();
        User_BLL user = new User_BLL();

        //Getting user designation..
        UserDesignationEntity userDE = new UserDesignationEntity();
        List<UserDesignationEntity> list = new List<UserDesignationEntity>();
        userDE.UserDesignation=Designation_TB.Text;
        Designation_BLL desObj = new Designation_BLL();
        list=desObj.GetDesignation(userDE);

        userEntity.Email = Email_TB.Text;
        userEntity.Name = Name_TB.Text;
       userEntity.Password = Password_TB.Text;
        userEntity.Loginid = Loginid_TB.Text;
        userEntity.Inpoolid = 1;
        userEntity.Isdeleted = 0;
        userEntity.Isadmin = 0;
        userEntity.Isadmin = 0;

        if (list[0].Id != 0) {

            userEntity.userDesignationId =list[0].Id;
        }

        int id=user.InsertUser(userEntity);

       
       Response.Redirect("Users.aspx");
      
    }
    
    protected void DesignationDW_SelectedIndexChanged(object sender, EventArgs e)
    {
        Designation_TB.Text = DesignationsDW.SelectedItem.Text;
    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Users.aspx");
    }
    
}