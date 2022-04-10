<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 119px;
        }
        .style2
        {
            width: 424px;
        }
        .auto-style1 {
            height: 57px;
        }
        .auto-style2 {
            width: 704px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <center>
          
      <table  style="height: 196px; font-weight: bold; font-size: x-large; width:1340px; background-image: url('img/newhead.png'); color: #000066;" >
        <tr>
            
               <td align="center">
                    <br />
                    </td>
        </tr>
    </table>
         <table style="width:1340px; height:10px; background-color: #CCCCCC;">
             <tr>
                 <td>

                 </td>
             </tr>
         </table>
      
          <br />
        <br />
          <marquee>
              <asp:Label ID="Label3" runat="server" Text="Welcome User!!!" Font-Bold="True" Font-Names="Cambria" ForeColor="#000066"></asp:Label></marquee>
      <table style="width: 1005px; height: 280px;">
        <tr>
             <td align="left" style="font-weight: bold; color: #FF3300; font-family: cambria;" 
                valign="baseline" class="auto-style2">
                 LOGIN FORM:<br />
                <asp:Image ID="Image2" runat="server" Height="291px" 
                    ImageUrl="~/img/login.jpg" Width="397px" />
            </td>
            <td class="style2">
            
          
      
             <table style="height: 156px; width: 348px; font-family: cambria; font-size: small; font-weight: bold;" align="center">
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td align="center">
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td align="center" class="auto-style1">
                    <asp:Button ID="Button1" runat="server" Text="LOGIN" Font-Bold="True" 
                        Font-Names="Cambria" onclick="Button1_Click" Width="72px" />
                </td>
                <td align="center" class="auto-style1">
                    <asp:Button ID="Button2" runat="server" Text="CANCEL" Font-Bold="True" 
                        Font-Names="Cambria" />
                </td>

            </tr>
        </table>
        
         </td>
        
        </tr>
      </table>
       </center>
    </div>
    </form>
</body>
</html>
