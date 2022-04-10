<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="height: 162px; width: 498px; font-family: cambria; font-weight: bold;">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Old Password" ForeColor="Black" Font-Size="Small"></asp:Label>
        </td>
        <td>
        
            <asp:TextBox ID="txtold" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="New Password" ForeColor="Black" Font-Size="Small"></asp:Label>
        </td>
        <td>
        
            <asp:TextBox ID="txtnew" runat="server" TextMode="Password"></asp:TextBox>

        </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Retype Password" ForeColor="Black" Font-Size="Small"></asp:Label>
        </td>
        <td>
        
            <asp:TextBox ID="txtretype" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtretype" 
                ControlToCompare="txtnew" runat="server" ErrorMessage="password mismatch" 
                ForeColor="#CC0000"></asp:CompareValidator>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Change Password" Font-Bold="True" 
                Font-Names="Cambria" onclick="Button1_Click" />
        </td>
        <td>
        
            <asp:Button ID="Button2" runat="server" Text="Cancel" Font-Bold="True" 
                Font-Names="Cambria" />
        </td>
        </tr>
</table>
</asp:Content>

