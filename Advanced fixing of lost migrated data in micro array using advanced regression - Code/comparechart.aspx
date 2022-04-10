<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="comparechart.aspx.cs" Inherits="comparechart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 230px; height: 72px; color: #000000; font-weight: bold;">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblid" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
       <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
<table>
    <tr>
        <td align="center">
            <asp:Button ID="Button1" runat="server" Text="View Consoldated Chart" 
                Height="38px" onclick="Button1_Click" Width="213px" Font-Bold="True" 
                Font-Names="Cambria" BackColor="#CCCCCC" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
                Palette="SeaGreen" Visible="False" BackColor="255, 128, 0" BackGradientStyle="LeftRight">
                <Series>
                    <asp:Series Name="Series1" XValueMember="conchart" YValueMembers="per">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Percentage">
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [conchart], [per] FROM [consoldateddet]"></asp:SqlDataSource>
            <%--<asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                DataFile="~/App_Data/predic.mdb" 
                SelectCommand="SELECT [conchart], [per] FROM [consoldateddet]">
            </asp:AccessDataSource>--%>
        </td>
    </tr>
</table>
</asp:Content>

