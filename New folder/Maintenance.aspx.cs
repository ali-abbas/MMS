using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using System.Collections;
public partial class Maintenance : System.Web.UI.Page
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
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {

            LoadPageContents();
        }


    }



    private void LoadPageContents()
    {
        MaintenanceLog_BLL Bll = new MaintenanceLog_BLL();
        MaintenanceLogEntity Entity = new MaintenanceLogEntity();

        try
        {
            List<MaintenanceLogEntity> logs = Bll.GetAllMaintenanceLogs(Entity);


            #region pagging

            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = logs;
            pgitems.PageSize = 4;//number of items


            pgitems.AllowPaging = true;

            if (logs.Count > 1)
            {

                var pages = (logs.Count / pgitems.PageSize) + (logs.Count % pgitems.PageSize > 0 ? 1 : 0);
                pgitems.CurrentPageIndex = PageNumber;

                totalPages = pages;

            }
            if (pgitems.PageCount > 1)
            {
                rptAvailable.Visible = true;

                ArrayList pagesData = new ArrayList();
                int itemIndex = (pgitems.CurrentPageIndex) * pgitems.PageSize;

                for (int i = 0; i <pgitems.PageSize; i++)
                {
                    if (itemIndex <=(logs.Count - 1))
                    { 
                        pagesData.Add(logs[itemIndex]);
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
                rptAvailable.DataSource = logs;
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
                int currentPage =i;
              
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


    protected void btnClick(object sender, EventArgs e)
    {

        Response.Redirect("MaintenanceDetails.aspx");

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        MaintenanceLogEntity mLogEntity = new MaintenanceLogEntity();
        List<MaintenanceLogEntity> logList = new List<MaintenanceLogEntity>();
        MaintenanceLog_BLL Bll = new MaintenanceLog_BLL();

        try
        {

            mLogEntity.MachineName = SearchByMachineName_TB.Text;

            if (SearchByMachineId_TB.Text != "")
            {
                mLogEntity.MachineId = int.Parse(SearchByMachineId_TB.Text);
            }

            logList = Bll.GetAllMaintenanceLogs(mLogEntity);

            if (logList != null && logList.Count > 0)
            {

                rptAvailable.DataSource = logList;
                rptAvailable.DataBind();

            }

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void UsersDW_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void MachinesDW_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
}
