<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Maintenance.aspx.cs" Inherits="Maintenance" %>
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
                  <li><a href="MMSMain.aspx" class="active" >Machines</a></li>
                  <li><a href="Users.aspx" class="active">Users</a></li>
                  <li><a href="Maintenance.aspx"><span>Maintenance</span> </a></li>
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
                                      <table>
                                        <tr><td>By machine Name : </td> <td><asp:TextBox ID="SearchByMachineName_TB" runat="server"></asp:TextBox></td></tr>
                                        <tr><td>By machine id :</td> <td><asp:TextBox ID="SearchByMachineId_TB" runat="server"></asp:TextBox> </td></tr>
                                        <tr><td class="button"><asp:LinkButton ID="BtnSearch" runat="server" Text="Serach" OnClick="BtnSearch_Click" ></asp:LinkButton></td></tr>
                                      </table>
                               
                                 </div>

                    </div>

                    <div class="clr"></div>
                     
            </div>
            
          </div>

       <div class="body">
         
        <div class="clr"></div>

            <h1><small><td class="button"> <asp:LinkButton ID="InsertBtn" runat="server" Text="Add New Maintence Log" OnClick="btnClick" ></asp:LinkButton></td></small></h1>

                
                 <table cellspacing="30" id="table">
                                            <thead>
                                                 <th>Repair By</th>
                                                <th>Machine Name</th>
                                                <th>MachineType</th>
                                                <th>Date Time</th>
                                                <th>Issue</th>
                                                <th>Resolution</th>
                                                <th>Comments</th>
                                            
                                             </thead>
                                            
                                                

                                <asp:Repeater ID="rptAvailable" runat="server" >
                                    <ItemTemplate>
                                       <tbody>
                                            <tr>
                                                            <td>
                                                              <%# Eval("RepairByUserName") %>
                                                            </td>
                                                            <td >
                                                                <%# Eval("MachineName")%>
                                                            </td>
                                                            <td>
                                                                <%# Eval("MachineType")%>
                                                            </td>
                                                             <td>
                                                                <%# Eval("DateTime")%>
                                                            </td>
                                                            <td >
                                                                <%# Eval("Issue")%>
                                                            </td>
                                                             <td>
                                                                <%# Eval("Resolution")%>
                                                            </td>
                                                             <td>
                                                                <%# Eval("Comments")%>
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