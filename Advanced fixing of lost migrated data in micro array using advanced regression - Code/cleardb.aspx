<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="cleardb.aspx.cs" Inherits="cleardb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/db.png" />
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Click Here to Clear the Database" Font-Bold="True" Font-Names="Cambria" Height="35px" 
                onclick="Button1_Click" />
        </td>
    </tr>
</table>
</asp:Content>

