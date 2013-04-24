using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Entities;
using System.Collections.Generic;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();
            Session.Clear();

        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string loginid = Request["txtloginid"].ToString().Trim();
        string password = Request["txtpassword"].ToString().Trim();

        if (loginid == string.Empty && password == string.Empty)
            return;

        User_BLL objUserBLL = new User_BLL();

        UserEntity objUser = new UserEntity();
        objUser.Loginid = loginid;
        objUser.Password = password;
        objUser.Isdeleted = 0;

        List<UserEntity> userList = objUserBLL.GetAllUsers(objUser);

        if (userList != null && userList.Count > 0)
        {
            Session.Add("CurrentUser", userList[0]);
            Response.Redirect("Menu.aspx");
        }

    }
}
