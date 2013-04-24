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


public partial class MachineDetails : System.Web.UI.Page
{
    private static string currentUser = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        int machineId = int.Parse(Request.QueryString["machineId"]);

        if (!IsPostBack)
        {
            MachineEntity entity = new MachineEntity();
            List<MachineEntity> machineEntity = new List<MachineEntity>();
            Machine_BLL objMachineBLL = new Machine_BLL();
            MachineEntity objMachineFilter = new MachineEntity();

            User_BLL objUserBLL = new User_BLL();
            UserEntity userEntity = new UserEntity();


            if (machineId != 0)
            {

                entity.Id = machineId;

                //entity.MachineType = 1;
                //entity.MachineTypeFlag = 1;

                // entity = objMachineBLL.GetMachine(entity);
                machineEntity = objMachineBLL.GetAllMachines(entity);


                Name_TB.Text = machineEntity[0].Name;
                computerNam_TB.Text = machineEntity[0].Computer_name;
                Processor_TB.Text = machineEntity[0].Processor;
                Ram_TB.Text = machineEntity[0].Ram;
                Hd_TB.Text = machineEntity[0].Harddisk;
                Software_TB.Text = machineEntity[0].Software;
                Details_TB.Text = machineEntity[0].Details;
                Username_TB.Text = machineEntity[0].UserName;
                Image1.ImageUrl = "images/machines/" + machineEntity[0].Computer_name + ".jpg";
                Type_TB.Text = machineEntity[0].MachineTypeName;

                InsertBtn.Visible = false;

                #region GetAuditLog

                AuditLog_BLL audit_BLL = new AuditLog_BLL();
                AuditLogEntity auditLogEntity = new AuditLogEntity();
                auditLogEntity.Machine_id = machineId;

                MachineHistory.DataSource = audit_BLL.GetAllLogs(auditLogEntity);
                MachineHistory.DataBind();

                #endregion GetAuditLog
                
            }
            else
            {
                Image1.Visible = false;
                LinkButton1.Visible = false;
                DeleteBtn.Visible = false;

            }

            //Getting Users

            List<UserEntity> userList = objUserBLL.GetAllUsers(userEntity);


            UsersDW.DataSource = userList;
            UsersDW.DataTextField = "Name";
            UsersDW.DataValueField = "Id";
            UsersDW.DataBind();

            UsersDW.Items.Add("SELECT");


            Constants cons = new Constants();
            MachineTypeDW.DataSource = cons.ConsList;
            MachineTypeDW.DataTextField = "Key";
            MachineTypeDW.DataValueField = "Value";
            MachineTypeDW.DataBind();

            currentUser = Username_TB.Text;
            
        }

        if (machineId != 0) {

            #region GetAuditLog

            AuditLog_BLL audit_BLL = new AuditLog_BLL();
            AuditLogEntity auditLogEntity = new AuditLogEntity();
            auditLogEntity.Machine_id = machineId;

            MachineHistory.DataSource = audit_BLL.GetAllLogs(auditLogEntity);
            MachineHistory.DataBind();

            #endregion GetAuditLog
        }

        
    }

    protected void BtnPick_Click(object sender, EventArgs e)
    {
        Response.Redirect("MMSMain.aspx");
      
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        MachineEntity Entity = new MachineEntity();
        Machine_BLL BLL = new Machine_BLL();
        Constants cons = new Constants();
        Dictionary<string,int> constants = cons.ConsList;

           //Getting values from textboxes
           Entity.Id = int.Parse(Request.QueryString["machineId"]);
           Entity.Name= Name_TB.Text;
           Entity.Computer_name = computerNam_TB.Text;
           Entity.Processor =Processor_TB.Text;
           Entity.Ram = Ram_TB.Text;
           Entity.Harddisk = Hd_TB.Text;
           Entity.Software =Software_TB.Text;
            
            
           Entity.MachineType = constants[Type_TB.Text];
            
            
           if (Username_TB.Text == "SELECT")
           {
               Entity.Inusedbyuserid = 0;
               
           }
           else {

               Entity.Inusedbyuserid = int.Parse(UsersDW.SelectedItem.Value);
           }
           
           Entity.Details = Details_TB.Text;
           Entity.Inpoolid = 1;
           BLL.UpdateMachine(Entity);

           //Inserting AuditLog
           if (currentUser != Username_TB.Text) {

               #region auditLogForInsertion

               AuditLogEntity auditEntity = new AuditLogEntity();
               AuditLog_BLL audit_BLL = new AuditLog_BLL();
               DateTime dt = DateTime.Now;
               auditEntity.Machine_id = Entity.Id;
               auditEntity.User_id = Entity.Inusedbyuserid;
               auditEntity.Datetime = dt.ToString();

               if (Entity.Inusedbyuserid == 0)
               {
                   auditEntity.Operation = 1;
               }
               else
               {
                   auditEntity.Operation = 2;
               }


               audit_BLL.insertItLog(auditEntity);

               #endregion auditLogForInsertion

           }
           

    }

    protected void InsertBtn_Click(object sender, EventArgs e)
    {

        MachineEntity Entity = new MachineEntity();
        Machine_BLL BLL = new Machine_BLL();
        Constants cons = new Constants();
        Dictionary<string, int> constants = cons.ConsList;

            //Getting values from textboxes
            Entity.Id = int.Parse(Request.QueryString["machineId"]);
            Entity.Name = Name_TB.Text;
            Entity.Computer_name = computerNam_TB.Text;
            Entity.Processor = Processor_TB.Text;
            Entity.Ram = Ram_TB.Text;
            Entity.Harddisk = Hd_TB.Text;
            Entity.Software = Software_TB.Text;

            Entity.MachineType = constants[Type_TB.Text];

            if (Username_TB.Text == "SELECT")
            {
                Entity.Inusedbyuserid = 0;

            }
            else
            {
                 Entity.Inusedbyuserid = int.Parse(UsersDW.SelectedItem.Value);
            }

            Entity.Details = Details_TB.Text;

            Entity.Enabled = 1;
            Entity.Inpoolid = 1;

            int machineId=BLL.InsertMachine(Entity);


            #region auditLogForInsertion

                AuditLogEntity auditEntity = new AuditLogEntity();
                AuditLog_BLL audit_BLL = new AuditLog_BLL();
                DateTime dt = DateTime.Now;
                auditEntity.Machine_id = Entity.Id;
                auditEntity.User_id = Entity.Inusedbyuserid;
                auditEntity.Datetime = dt.ToString();

                if (Entity.Inusedbyuserid == 0)
                {
                    auditEntity.Operation = 1;
                }
                else
                {
                    auditEntity.Operation = 2;
                }


                audit_BLL.insertItLog(auditEntity);

            #endregion auditLogForInsertion

            Response.Redirect("MMSMain.aspx");
    }

    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        MachineEntity Entity = new MachineEntity();
        Machine_BLL BLL = new Machine_BLL();
        Constants cons = new Constants();

        Dictionary<string, int> constants = cons.ConsList;

        //Getting values from textboxes
        Entity.Id = int.Parse(Request.QueryString["machineId"]);
        Entity.Name = Name_TB.Text;
        Entity.Computer_name = computerNam_TB.Text;
        Entity.Processor = Processor_TB.Text;
        Entity.Ram = Ram_TB.Text;
        Entity.Harddisk = Hd_TB.Text;
        Entity.Software = Software_TB.Text;


    
            Entity.MachineType = constants[Type_TB.Text];
        
        if (Username_TB.Text == "SELECT")
        {
            Entity.Inusedbyuserid = 0;

        }
        else
        {

    
            Entity.Inusedbyuserid = int.Parse(UsersDW.SelectedItem.Value);
        }

        Entity.Isdeleted = 1;
        Entity.Details = Details_TB.Text;
        Entity.Inpoolid = 1;
        BLL.UpdateMachine(Entity);

        Response.Redirect("MMSMain.aspx");

    }

    protected void UsersDW_SelectedIndexChanged(object sender, EventArgs e)
    {
        Username_TB.Text = UsersDW.SelectedItem.Text;
    }

    protected void MachineTypeDW_SelectedIndexChanged(object sender, EventArgs e)
    {
        Type_TB.Text = MachineTypeDW.SelectedItem.Text;
    }

    protected void MachineHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        MachineHistory.PageIndex = e.NewPageIndex;
        MachineHistory.DataBind();
    }

}