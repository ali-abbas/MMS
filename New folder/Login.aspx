<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>TPS - Machine Management System</title>
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<link href="style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/cufon-yui.js"></script>
<script type="text/javascript" src="js/arial.js"></script>
<script type="text/javascript" src="js/cuf_run.js"></script>
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/custom.js" type="text/javascript"></script>
</head>

<body>

<div class="main">

  <div class="header">
    <div class="header_resize">
      <div class="logo">
         
        <h1>
          <img src="images/tps.gif" alt="TPS - Making Transactions Happen" width="227" height="72" border="0"/>
        </h1>
        
      </div>
      <div class="menu">
       
      </div>

      <div class="text_header">
       <h2>Machine Management System</h2>
      </div>

      <div class="clr"></div>
    </div>
         <div class="headert_text_resize_bg">
      <div class="headert_text_resize">
        <div class="login">
            <div class="login-right block">
            <h3>Login</h3>
                <form id="Form1" runat="server">
                      <div style="width: 100%; text-align: center;">
                                    <table style="margin-left: auto; margin-right: auto; text-align: left">
                                        <tr>
                                            <td>
                                                Login Id
                                            </td>
                                            <td>
                                                <input type="text" class="inputField" maxlength="20" id="txtloginid" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Password
                                            </td>
                                            <td>
                                                <input type="password" class="inputField" maxlength="20" id="txtpassword" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center;">

                                                <asp:Button ID="BtnSubmit" CssClass="buttonField" Text="Submit" runat="server" OnClick="BtnSubmit_Click"  />
                                            </td>
                                        </tr>
                                    </table>
                           </div>
               </form>

        </div>

        
        </div>
      </div>
    </div>
    <div class="clr"></div>
  </div>

  <div class="body">

    <div class="body_resize">
     
      <div class="right_resize">
        
  
      </div>

      <div class="clr"></div>
    </div>
  </div>

  <div class="clr"></div>

  <div class="footer-fixed">
    <div class="footer_resize" >
        Copyright © 2012 <a href="#">TPS Pakistan</a>
      <div class="clr"></div>
    </div>
  </div>

</div>

</body>
</html>
