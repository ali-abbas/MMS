<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

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
         <div class="clr"></div>
        <!------BODY CONTENT-------->

                                                    <div class="div-MD1">

                                                        <table>
                                                            <tr><td><b> Name : </b></td> <td><asp:TextBox ID="Name_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                                            <tr><td><b> EMAIL : </b></td> <td><asp:TextBox ID="Email_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                                            <tr><td><b> LOGIN ID : </b></td> <td><asp:TextBox ID="Loginid_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>
                                                            <tr><td><b> PASSWORD :</b></td> <td><asp:TextBox ID="Password_TB" runat="server"  Width="350px"></asp:TextBox><br /></td></tr>
                                                            <tr><td><b> DESIGNATION :</b></td> <td><asp:TextBox ID="Designation_TB" runat="server"  Width="350px"></asp:TextBox></td></tr>

                                                        </table>

                                                    </div>
                                                

        <div class="clr"></div>
                                                <div class="div-MD1">
                                                        <h3>Select Details to change</h3>
                                                                 <b>Designation :</b><asp:DropDownList ID="DesignationsDW" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DesignationDW_SelectedIndexChanged"> </asp:DropDownList><br /><br />

                                                                <div class="button">
                                                                   <asp:LinkButton ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" ></asp:LinkButton>
                                                                   <asp:LinkButton ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click" ></asp:LinkButton>
                                                                    <asp:LinkButton ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" ></asp:LinkButton>
                                                                    
                                                                </div>
                                                        </div>
    <div class="clr"></div>

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