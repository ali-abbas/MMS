<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MMSMain.aspx.cs" Inherits="MMSMain" CodeBehind="~/MachineDetails.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">


<head>


    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TPS - Machine Management System</title>
    <meta name="keywords" content="MMS" />
    <meta name="description" content="MMS" />

    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link href="style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/cufon-yui.js"></script>
    <script type="text/javascript" src="js/arial.js"></script>
    <script type="text/javascript" src="js/cuf_run.js"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/custom.js" type="text/javascript"></script>

     <!--////// FOR PIROBOX  \\\\\\\-->
    <link href="css_pirobox/white/style.css" media="screen" title="shadow" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/piroBox.1_2.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $().piroBox({
                my_speed: 600, //animation speed
                bg_alpha: 0.5, //background opacity
                radius: 4, //caption rounded corner
                scrollImage: false, // true == image follows the page, false == image remains in the same open position
                pirobox_next: 'piro_next', // Nav buttons -> piro_next == inside piroBox , piro_next_out == outside piroBox
                pirobox_prev: 'piro_prev', // Nav buttons -> piro_prev == inside piroBox , piro_prev_out == outside piroBox
                close_all: '.piro_close', // add class .piro_overlay(with comma)if you want overlay click close piroBox
                slideShow: 'slideshow', // just delete slideshow between '' if you don't want it.
                slideSpeed: 4 //slideshow duration in seconds(3 to 6 Recommended)
            });
        });


    
    </script>

    <!--////// END  \\\\\\\-->
</head>

<body>

    <form id="Form1" runat="server">
    <div class="main">

          <div class="header">

            <div class="header_resize">
           
              <div class="menu">
                <ul>
                  <li><a href="Menu.aspx" class="active">Home</a></li>
                  <li><a href="MMSMain.aspx" >Machines</a></li>
                  <li><a href="Users.aspx" class="active">Users</a></li>
                   <li><a href="Maintenance.aspx" class="active"><span>Maintenance</span> </a></li>
                   <li><a href="Login.aspx" class="active"><span>Logout</span> </a></li>
                </ul>
              </div>

            
              <div class="text_header">
              <img src="images/tps.gif" alt="TPS - Making Transactions Happen" width="150" height="38" border="0"/>
               <h2>Machine Management System</h2>
              </div>

              <div class="clr"></div>
            </div>

            <div class="headert_text_resize_bg">
           
                   <div class="search">
                   
                     <div class="div-left block">
                        <h3>Search</h3>
                        <b>Seach by machine id : </b><asp:TextBox ID="SearchByMachineName_TB" runat="server" ></asp:TextBox>   <br />
                        <b>Seach by user name: </b>&nbsp&nbsp<asp:TextBox ID="SearchByUsers_TB" runat="server"></asp:TextBox>   <br />
                    
                        <asp:CheckBox ID="SearchByMachineCheckBox" runat="server" />
                        <b>Search By Machine Type :</b>
                        <asp:DropDownList ID="SearchByMachineDropDown" runat="server">
                             <asp:ListItem Selected="True" Value="1"> Machine </asp:ListItem>
                            <asp:ListItem Value="2"> Laptop </asp:ListItem>
                        </asp:DropDownList><br />

                        <asp:CheckBox ID="notInUserCheckBox" runat="server" /><b> Not In Use</b><br /><br />
                     
                                        <table>
                                      
                                            <tr>

                                                <td class="button"> <asp:LinkButton ID="BtnRelease" runat="server" Text="Serach" OnClick="SearchBtn_Click" ></asp:LinkButton></td>
                                                
                                            </tr>
                                        </table>
                   </div>
                    </div>

                  
                    <div class="clr"></div>
                    
            </div>
            
          </div>

       <div class="body">
         
        <div class="clr"></div>
         <h1><small><td class="button"> <asp:LinkButton ID="InsertBtn" runat="server" Text="Add New Machine" OnClick="InsertBtn_Click" ></asp:LinkButton></td></small></h1>
        <table cellspacing="22" id="table">
                                            <thead>
                                                 <th>IMG</th>
                                                <th>NAME</th>
                                                <th>COM_NAME</th>
                                                <th>PROCESSOR</th>
                                                <th>RAM</th>
                                                <th>HD</th>
                                                <th>SOFTWARE</th>
                                                <th>DETAILS</th>
                                                <th>USER_NAME</th>
                                                <th>Type</th>
                                                <th>OPERATIONS</th>
                                            
                                             </thead>
                                            
                                                

                                <asp:Repeater ID="rptAvailable" runat="server">
                                    <ItemTemplate>
                                       <tbody>
                                            <tr>
                                                            <td >
                                                                 <a href="images/machines/<%# Eval("Computer_name") %>.jpg" class="pirobox" title="<%# Eval("details") %>">
                                                                 <img src="images/machines/<%# Eval("Computer_name") %>.jpg" alt="" width=30px height=30px/></a>
                                                            </td>
                                                            <td>
                                                                <%# Eval("name") %>
                                                            </td>
                                                            <td >
                                                                <%# Eval("computer_name")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("processor")%>
                                                            </td>
                                                             <td>
                                                                <%# Eval("ram")%>
                                                            </td>
                                                            <td >
                                                                <%# Eval("harddisk")%>
                                                            </td>
                                                             <td>
                                                                <%# Eval("software")%>
                                                            </td>
                                                             <td>
                                                                <%# Eval("DetailsForGrid")%>
                                                            </td>
                                                               
                                                            <td>
                                                              <%# Eval("UserName") %>
                                                            </td>

                                                            <td>
                                                              <%# Eval("MachineTypeName") %>
                                                            </td>



                                                            <td>
                                                                <asp:LinkButton ID="BtnPick" runat="server"  CommandArgument='<%# Eval("id") %>' OnClick="BtnPick_Click">
                                                                         <asp:Image ID="img" runat="server" ImageUrl="images/operation-icon.gif" Width=20px Height=20px />
                                                                </asp:LinkButton>
                                                             
                                                            </td>
                                                        </tr>
                                        </tbody>

                                        

                                    </ItemTemplate>

                                </asp:Repeater>

                                
                    </table>
                      <div class="clr"></div>
                  <asp:Repeater ID="rptPages" Runat="server" OnItemCommand="rptPages_ItemCommand">
                      <HeaderTemplate>
                          <table cellpadding="0" cellspacing="0" border="0">
                          <tr class="text">
                             <td><b>Pages:</b>&nbsp;</td>
                             <td>
                      </HeaderTemplate>
                              <ItemTemplate>
                                 <asp:LinkButton ID="btnPage" CommandName="Page" CommandArgument="<%#Container.DataItem %>" Runat="server"><%# Container.DataItem %> </asp:LinkButton>&nbsp;
                              </ItemTemplate>
                              <FooterTemplate>
                                         </td>
                                      </tr>
                                      </table>
                              </FooterTemplate>
                    </asp:Repeater>

                                        
                                        

<div class="clr"></div>
  </div>

           <br /><br /><br /><br /><br /><br /><br />

             <div class="clr"></div>

         <div class="footer">
    <div class="footer_resize" >
        Copyright © 2012 <a href="#">TPS Pakistan</a>
      <div class="clr"></div>
    </div>
  </div>

    </div>
 </form>

</body>
</html>