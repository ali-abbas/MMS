<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MachineDetails.aspx.cs" Inherits="MachineDetails" %>

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
            <%--  <div class="logo">
                             
                 <img src="images/tps.gif" alt="TPS - Making Transactions Happen" width="227" height="72" border="0"/>
        
              </div>--%>

              <div class="menu">
                <ul>
                  <li><a href="Menu.aspx" class="active">Home</a></li>
                  <li><a href="MMSMain.aspx" class="active">Machines</a></li>
                  <li><a href="Users.aspx" >Users</a></li>
                   <li><a href="Login.aspx" class="active"><span>Logout</span> </a></li>
                </ul>
              </div>

            
              <div class="text_header">
                  <img src="images/tps.gif" alt="TPS - Making Transactions Happen" width="150" height="38" border="0"/>
                   <h2>Machine Management System</h2>
              </div>

              <div class="clr"></div>
            </div>
            
          </div>

       <div class="body">
         
        <!------BODY CONTENT-------->
            <div class="clr"></div>
                 <div class="div-MD1">
                            <table>
                                <tr><asp:Image ID="Image1" runat="server"  width="100px" height="100px" CssClass="pirobox" /></tr>
                                <tr><td><b>Name :</b></td><td><asp:TextBox ID="Name_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                <tr><td><b> Computer Name : </b></td><td><asp:TextBox ID="computerNam_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                <tr><td><b>Processor</b></td> <td><asp:TextBox ID="Processor_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                <tr><td><b >Ram : </b></td> <td><asp:TextBox ID="Ram_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                <tr><td><b>Hard Disk :</b></td> <td><asp:TextBox ID="Hd_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                <tr><td><b> Software :</b></td> <td><asp:TextBox ID="Software_TB" runat="server" Width="350px"></asp:TextBox> <br /></td></tr>
                                <tr><td> <b>Details : </b></td> <td><asp:TextBox ID="Details_TB" runat="server" Width="350px"></asp:TextBox></td></tr>
                                <tr><td><b>Current User : </b></td> <td> <asp:TextBox ID="Username_TB" runat="server" Width="350px"></asp:TextBox></td></tr>
                                <tr><td><b>Type : </b></td> <td><asp:TextBox ID="Type_TB" runat="server" Width="350px"></asp:TextBox> </td></tr>
                            </table>
                  </div>
           <div class="clr"></div>
                 <div class="div-MD1">
                                                        
                                                        <table>
                                                            <tr><h3>Select Details to change</h3></tr>
                                                            <tr><td><b>New User :</b></td> <td><asp:DropDownList ID="UsersDW" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UsersDW_SelectedIndexChanged"> </asp:DropDownList></td></tr>
                                                            <tr><td> <b>New Machine Type :</b> </td> <td> <asp:DropDownList ID="MachineTypeDW" runat="server" AutoPostBack="true" OnSelectedIndexChanged="MachineTypeDW_SelectedIndexChanged"> </asp:DropDownList></td></tr>
                                                            <tr><td><br /></td></tr>
                                                            <tr class="button">
                                                                                   <td><asp:LinkButton ID="BtnRelease" runat="server" Text="Back" OnClick="BtnPick_Click" ></asp:LinkButton></td> 
                                                                                   <td><asp:LinkButton ID="LinkButton1" runat="server" Text="Update" OnClick="UpdateBtn_Click"></asp:LinkButton></td> 
                                                                                   <td><asp:LinkButton ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"></asp:LinkButton></td> 
                                                                                    <td><asp:LinkButton ID="DeleteBtn" runat="server" Text="Delete" OnClick="DeleteBtn_Click"></asp:LinkButton></td> 
                                                             </tr>
                                                        </table>
                                                           
                 </div>
           <div class="clr"></div>  
            <h3>MACHINE HISTORY</h3>
                 <div style="width: 97%; text-align:center; height: 290px;">
                                                            

                                                            <asp:GridView ID="MachineHistory" runat="server" AutoGenerateColumns="False"  
                                                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                                                EnableTheming="True" ForeColor="Black" GridLines="Vertical"  Height="164px" 
                                                                HorizontalAlign="Justify" PageSize="5" UseAccessibleHeader="False" 
                                                                Width="814px" BackColor="White" AllowPaging="true" OnPageIndexChanging="MachineHistory_PageIndexChanging">

                                                                 <PagerSettings  Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous" NextPageText="Next" LastPageText="Last" />
                                                                   <AlternatingRowStyle BackColor="#CCCCCC" />
                                                                   <Columns>
                                                                        <asp:TemplateField HeaderText="Machine Name">
                                                                            <ItemTemplate><%# Eval("MachineName") %></ItemTemplate>
                                                                        </asp:TemplateField> 

                                                                        <asp:TemplateField HeaderText="IN USED">
                                                                            <ItemTemplate><%# Eval("UserName") %></ItemTemplate>
                                                                        </asp:TemplateField> 

                                                                        <asp:TemplateField HeaderText="Date Time">
                                                                            <ItemTemplate><%# Eval("Datetime") %></ItemTemplate>
                                                                        </asp:TemplateField> 

                                                                   </Columns>
                                                                   <FooterStyle BackColor="#CCCCCC" />
                                                                   <RowStyle Height="30px" />
                                                                   <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Height="50px" />
                                                                   <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                                   <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                   <SortedAscendingHeaderStyle BackColor="#808080" />
                                                                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                   <SortedDescendingHeaderStyle BackColor="#383838" />
                                                            </asp:GridView>

                                                </div> 

        </div>

           <br /><br /><br />

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