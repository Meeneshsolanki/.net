<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="viewpatient.aspx.cs" Inherits="viewpatient" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style4 {
        width: 605px;
        height: 337px;
    }
    .auto-style5 {
        height: 337px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="font-weight: bold; font-size: medium; color: #CC0000; width: 265px;">
    <tr>
        <td>
        PATIENT LAB REPORT
            :</td>
    </tr>
</table>

    <table style="width: 230px; height: 72px; font-family: cambria; font-size: small; font-weight: bold; color: #000000;">
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
<table style="width: 1092px">
    <tr>
        <td class="auto-style4">
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
                Width="567px" BackColor="255, 128, 0" BackGradientStyle="TopBottom">
                <Series>
                    <asp:Series Name="Series1" XValueMember="TestDate" YValueMembers="per" 
                        YValuesPerPoint="2">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" AlignmentOrientation="All">
                        <AxisY Title="% of Occurence">
                        </AxisY>
                        <AxisX Title="Tested Date" LineColor="Maroon">
                        </AxisX>
                        <Area3DStyle WallWidth="3" />
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [TestDate], [per] FROM [occurenceper] WHERE (([ID] = @ID) AND ([Name] = @Name))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblid" Name="ID" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="lblname" Name="Name" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <%--<asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                DataFile="~/App_Data/predic.mdb" 
                SelectCommand="SELECT [TestDate], [per] FROM [occurenceper] WHERE (([ID] = ?) AND ([Name] = ?))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblid" Name="ID" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="lblname" Name="Name" PropertyName="Text" 
                        Type="String" />
                </SelectParameters>
            </asp:AccessDataSource>--%>
        </td>
        <td valign="top" class="auto-style5">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="SqlDataSource2" 
                Width="350px" Font-Bold="True" Font-Names="Cambria" Font-Size="Small" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="TestDate" HeaderText="Tested Date" 
                        SortExpression="TestDate" />
                    <asp:BoundField DataField="per" HeaderText="Percentage of Occurence" 
                        SortExpression="per" />
                        <asp:BoundField DataField="cputime" HeaderText="CPU Time" 
                        SortExpression="cputime" />
                </Columns>
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [TestDate], [per], [cputime] FROM [occurenceper] WHERE (([ID] = @ID) AND ([Name] = @Name))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblid" Name="ID" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="lblname" Name="Name" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
        </td>
    </tr>
</table>
</asp:Content>

