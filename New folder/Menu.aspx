<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

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
<form method="post" action="Menu.aspx">
<div class="main">

  <div class="header">
    <div class="header_resize">
     <%-- <div class="logo">
         
        <h1>
            <img src="images/tps.gif" alt="TPS - Making Transactions Happen" width="227" height="72" border="0">
        </h1>
        
      </div>--%>
            <div class="menu">
                <ul>
                   <li><a href="Login.aspx" class="logout"><span>Logout</span> </a></li>
                </ul>
              </div>

      <div class="text_header">
              <img src="images/tps.gif" alt="TPS - Making Transactions Happen" width="150" height="38" border="0"/>
               <h2>Machine Management System</h2>
      </div>


      <div class="clr"></div>
    </div>
    
    <div class="clr"></div>
  </div>

  <div class="body">
        <table cellpadding="30" style="margin-left: auto;   margin-right: auto; text-align: center">
               <tr>
                   <td >
                        <div id="ex5">
                           <a href="MMSMain.aspx"><img src="images/machines/ETPOOL6.jpg" width="100px" height="100px" /></a><br />
                           <h6>Machines</h6>
                       </div>
                    </td>
                     <td>
                         <div id="ex5">
                            <a href="Users.aspx"><img src="images/User-icon.png" width="100px" height="100px" /></a><br />
                            <h6>Users</h6>
                             </div>
                         </td>

                         <td>
                         <div id="ex5">
                            <a href="Maintenance.aspx"><img src="images/Maintenance.jpg" width="100px" height="100px" /></a><br />
                            <h6>Maintenance</h6>
                             </div>
                         </td>
                    
                  </tr>
         </table>
 </div>

<div class="clr"></div>

  <div class="footer-fixed">
    <div class="footer_resize" >
        Copyright © 2012 <a href="#">TPS Pakistan</a>
      <div class="clr"></div>
    </div>
  </div>

</div>
</form>
</body>
</html>
