<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="empty.aspx.cs" Inherits="empty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
    {
        width: 318px;
    }
    .auto-style4 {
        width: 463px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <marquee style="height: 43px">
<table>
    <tr>
        <td style="font-size: medium; font-weight: bold; font-family: cambria; color: #CC0000;">
      WELCOME USER !!!
        </td>
    </tr>
</table></marquee>
<table style="height: 226px; width: 1326px" align="center">
    <tr>
        <td class="auto-style4" valign="top">
        
      
<table style="height: 118px; width: 230px; font-family: cambria; font-size: small; font-weight: bold;" align="center">
    <tr>
        <td>
            
            <asp:Label ID="Label1" runat="server" Text="Current Date" ForeColor="Black"></asp:Label>
            </td>
            <td>
            <asp:Label ID="lbldate" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label>
        </td>
    </tr>
     <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Current Time" ForeColor="Black"></asp:Label>
            </td>
            <td>
            <asp:Label ID="lbltime" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label>
        </td>
    </tr>
</table>
  </td>
  <td>
  
      <asp:Image ID="Image1" runat="server" ImageUrl="~/img/admin.png" Height="241px" Width="214px" />
      </td>
    </tr>
</table>

</asp:Content>

