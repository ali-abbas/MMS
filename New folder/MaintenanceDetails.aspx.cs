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

public partial class MaintenanceDetails : System.Web.UI.Page
{
   static MaintenanceLogEntity globalEntity = new MaintenanceLogEntity();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentUser"] == null)
        {
            
        }

        if (!IsPostBack) {

            LoadPageContent();
        }

    }

    private void LoadPageContent()
    {

        #region Getting Users

            User_BLL objUserBLL = new User_BLL();
            UserEntity userEntity = new UserEntity();

            List<UserEntity> userList = objUserBLL.GetAllUsers(userEntity);


            UsersDW.DataSource = userList; 
            UsersDW.DataTextField = "Name";
            UsersDW.DataValueField = "Id";
            UsersDW.DataBind();


        #endregion Getting Users

        #region Getting Machine

            Machine_BLL machineBLL = new Machine_BLL();
            MachineEntity machineEntity=new MachineEntity();
            List<MachineEntity> machines=machineBLL.GetAllMachines(machineEntity);

            MachinesDW.DataSource = machines;
            MachinesDW.DataTextField = "Name";
            MachinesDW.DataValueField = "Id";
            MachinesDW.DataBind();
            
        #endregion Getting Machine

        #region Getting MachineType


            Constants cons = new Constants();
            MachineTypeDW.DataSource = cons.ConsList;
            MachineTypeDW.DataTextField = "Key";
            MachineTypeDW.DataValueField = "Value";
            MachineTypeDW.DataBind();

            

        #endregion Getting MachineType




    }

    protected void UsersDW_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        RepairByUserName_TB.Text = UsersDW.SelectedItem.Text;
        globalEntity.RepairByUserId =int.Parse(UsersDW.SelectedItem.Value);
    }

    protected void MachinesDW_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        MachineName_TB.Text = MachinesDW.SelectedItem.Text;
        globalEntity.MachineId = int.Parse(MachinesDW.SelectedItem.Value);
       

    }

    protected void MachinesTypeDW_SelectedIndexChanged(object sender, EventArgs e)
    {
        Category_TB.Text = MachineTypeDW.SelectedItem.Text;
        globalEntity.Category = int.Parse(MachineTypeDW.SelectedItem.Value);
     
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        Category_TB.Text = MachineTypeDW.SelectedItem.Value;

    }

    protected void InsertBtn_Click(object sender, EventArgs e)
    {

        MaintenanceLog_BLL Bll = new MaintenanceLog_BLL();
        MaintenanceLogEntity entity = new MaintenanceLogEntity();

        try {

            
            entity.Comments = Comments_TB.Text;
            entity.DateTime = Date_TB.Text + " " + Time_TB.Text;
            entity.Issue = Issue_TB.Text;
            entity.MachineId = globalEntity.MachineId ;
            entity.Category = globalEntity.Category;
            entity.RepairByUserId =globalEntity.RepairByUserId;
            entity.Resolution = Resolution_TB.Text;

            int id = Bll.InsertMaintenanceLog(entity);

        }
        catch (Exception ex) {
            throw ex;
        }

    }

    protected void BackBtn_Click(object sender, EventArgs e)
    {

        Response.Redirect("Maintenance.aspx");
    }


}