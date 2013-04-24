using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entities;
using System.Text;
using System.Collections;

public partial class Users : System.Web.UI.Page
{

    public int PageNumber
    {

        get
        {
            if (ViewState["PageNumber"] != null)
            {
                return Convert.ToInt32(ViewState["PageNumber"]);
            }
            else { return 0; }

        }

        set
        {

            ViewState["PageNumber"] = value;

        }
    }

    public int totalPages
    {

        get
        {
            if (ViewState["totalPages"] != null)
            {
                return Convert.ToInt32(ViewState["totalPages"]);
            }
            else { return 0; }

        }

        set
        {

            ViewState["totalPages"] = value;

        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["CurrentUser"] == null)
        {

            Response.Redirect("Login.aspx");

        }
        if (!IsPostBack)
        {
            loadPageContnets();
        }
    }

    private void loadPageContnets()
    {
        if (Session["CurrentUser"] == null) {
            Response.Redirect("Login.aspx");
        }

        try
        {

            User_BLL userObj = new User_BLL();
            UserEntity entity = new UserEntity();
            List<UserEntity> usersList = new List<UserEntity>();
            usersList = userObj.GetAllUsers(entity);

            #region pagging

            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = usersList;
            pgitems.PageSize = 4;//number of items


            pgitems.AllowPaging = true;

            if (usersList.Count > 1)
            {

                var pages = (usersList.Count / pgitems.PageSize) + (usersList.Count % pgitems.PageSize > 0 ? 1 : 0);
                pgitems.CurrentPageIndex = PageNumber;

                totalPages = pages;

            }
            if (pgitems.PageCount > 1)
            {
                rptAvailable.Visible = true;

                ArrayList pagesData = new ArrayList();
                int itemIndex = (pgitems.CurrentPageIndex) * pgitems.PageSize;

                for (int i = 0; i < pgitems.PageSize; i++)
                {
                    if (itemIndex <= (usersList.Count - 1))
                    {
                        pagesData.Add(usersList[itemIndex]);
                        itemIndex++;
                    }
                }


                rptAvailable.DataSource = pagesData;
                rptAvailable.DataBind();

                //Show indexes
                showPageIndexes(pgitems);


            }
            else
            {
                rptAvailable.DataSource = usersList;
                rptAvailable.DataBind();

            }

            #endregion pagging

        }
        catch (Exception ex) {

            throw ex;
        
        }

    }
    
    private void showPageIndexes(PagedDataSource pgItems)
    {
        if (pgItems.Count >= 1)
        {

            rptAvailable.Visible = true;
            ArrayList pages = new ArrayList();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < pgItems.PageCount; i++)
            {
                int currentPage = i;

                if (currentPage == PageNumber)
                {
                    currentPage++;
                    sb.Append("<b>" + currentPage + "</b>");
                    pages.Add(sb);
                }
                else
                {
                    pages.Add((i + 1).ToString());
                }


            }
            rptPages.DataSource = pages;
            rptPages.DataBind();
        }
        else
        {
            rptPages.Visible = false;

        }
    }

    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        loadPageContnets();
    }

    protected void UsersDetails_Click(object sender, EventArgs e) {
        
        LinkButton objLinkBtn = sender as LinkButton;
        int userId =int.Parse(objLinkBtn.CommandArgument);
        Response.Redirect("UserDetails.aspx?userId="+userId);
    }

    protected void InsertBtn_Click(object sender, EventArgs e)
    {
        int userId =0;
        Response.Redirect("UserDetails.aspx?userId="+userId);
    }


    protected void DeleteUser_Click(object sender, EventArgs e)
    {

        User_BLL user = new User_BLL();
        UserEntity userEntity = new UserEntity();

        LinkButton objLinkBtn = sender as LinkButton;
        int userId=int.Parse(objLinkBtn.CommandArgument);

        userEntity.Id = userId;

        List<UserEntity> usersList = new List<UserEntity>();
        usersList = user.GetAllUsers(userEntity);


        userEntity.Id = usersList[0].Id;
        userEntity.Name = usersList[0].Name;
        userEntity.Email = usersList[0].Email;
        userEntity.Password = usersList[0].Password;
        userEntity.userDesignationId = usersList[0].userDesignationId;
        userEntity.Loginid = usersList[0].Loginid;
        userEntity.Inpoolid = usersList[0].Inpoolid;
        userEntity.Isadmin = usersList[0].Isadmin;
        userEntity.Enabled = usersList[0].Enabled;

        //additional

        userEntity.Isdeleted = 1;


        user.UpdateUser(userEntity);

        Response.Redirect("Users.aspx");

    }


    protected void BackBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MMSMain.aspx");
    }

   
}