using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Entities;
using System.Text;
using System.Collections;


public partial class MMSMain : System.Web.UI.Page
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
            LoadPageContents();

        }

    }

    private void LoadPageContents()
    {
        if (Session["CurrentUser"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        try
        {

            UserEntity objCurrentUser = Session["CurrentUser"] as UserEntity;

            Machine_BLL objMachineBLL = new Machine_BLL();

            MachineEntity objMachineFilter = new MachineEntity();


            objMachineFilter.Isdeleted = 0;

            List<MachineEntity> allMachines = objMachineBLL.GetAllMachines(objMachineFilter);

            #region pagging

            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = allMachines;
            pgitems.PageSize = 4;//number of items


            pgitems.AllowPaging = true;

            if (allMachines.Count > 1)
            {

                var pages = (allMachines.Count / pgitems.PageSize) + (allMachines.Count % pgitems.PageSize > 0 ? 1 : 0);
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
                    if (itemIndex <= (allMachines.Count - 1))
                    {
                        pagesData.Add(allMachines[itemIndex]);
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
                rptAvailable.DataSource = allMachines;
                rptAvailable.DataBind();

            }

            #endregion pagging

         
          
        }
        catch (Exception ex)
        {

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
        LoadPageContents();
    }

    protected void BtnPick_Click(object sender, EventArgs e)
    {
        //StringBuilder sb = new StringBuilder();
        LinkButton objLinkBtn = sender as LinkButton;
        int machineId = Convert.ToInt32(objLinkBtn.CommandArgument);
        Response.Redirect("MachineDetails.aspx?machineId=" + machineId);
    }

    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        Boolean isNotFilter = true;
        MachineEntity entity = new MachineEntity();
        List<MachineEntity> list = new List<MachineEntity>();
        Machine_BLL objMachineBLL = new Machine_BLL();

        try
        {
            if (SearchByMachineName_TB.Text != string.Empty)
            {
                entity.Name = SearchByMachineName_TB.Text;
                isNotFilter = false;
            } if (notInUserCheckBox.Checked)
            {
                entity.notInUserFlag = 1;
                isNotFilter = false;
            } if (SearchByMachineCheckBox.Checked)
            {
                entity.MachineTypeFlag = 1;
                entity.MachineType = int.Parse(SearchByMachineDropDown.SelectedItem.Value);
                isNotFilter = false;
            } if (SearchByUsers_TB.Text != string.Empty)
            {
                entity.UserName = SearchByUsers_TB.Text;
                isNotFilter = false;
            }


            if (isNotFilter)
            {
                throw new System.ArgumentNullException();
            }
            else
            {
                list = objMachineBLL.GetAllMachines(entity);
                rptAvailable.DataSource = list;
                rptAvailable.DataBind();
            }

        }
        catch (Exception ex)
        {

            LoadPageContents();
        }
    }

    protected void InsertBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("MachineDetails.aspx?machineId=" + 0);
    }

}
