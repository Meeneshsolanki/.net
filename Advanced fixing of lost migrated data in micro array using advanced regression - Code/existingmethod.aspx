<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="existingmethod.aspx.cs" Inherits="existingmethod" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 33px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="font-weight: bold; font-size: medium; color: #CC0000; width: 265px;">
    <tr>
        <td>
            PATIENT REPORT
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
    <br />
<table>
    <tr>
        
        <td align="center">
        <asp:Label ID="Label4" runat="server" Text="PROPOSED METHOD" Font-Bold="True" 
                Font-Size="Large" ForeColor="#CC0000"></asp:Label>
        </td>
    </tr>
    <tr>
    
        <td>
            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
                Width="661px" BackColor="255, 128, 0" BackGradientStyle="TopBottom">
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
        </tr>
        <tr>
            
            <td>
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="SqlDataSource2" 
                Width="500px" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="TestDate" HeaderText="Tested Date" 
                        SortExpression="TestDate" />
                    <asp:BoundField DataField="per" HeaderText="Percentage of Occurence" 
                        SortExpression="per" />
                        <asp:BoundField DataField="cputime" HeaderText="CPU Time" 
                        SortExpression="cputime" />
                        <asp:BoundField DataField="accuracy" HeaderText="Accuracy" 
                        SortExpression="accuracy" />
                </Columns>
                 <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [TestDate], [per], [cputime], [accuracy] FROM [occurenceper] WHERE (([ID] = @ID) AND ([Name] = @Name))">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblid" Name="ID" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="lblname" Name="Name" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            
            </td>
        </tr>
</table>
<table style="color: #000000">
    <tr>
       <%-- <td>
        CPUTIME GRAPH
            <asp:AccessDataSource ID="AccessDataSource6" runat="server" 
                DataFile="~/App_Data/predic.mdb" 
                SelectCommand="SELECT [TestDate], [cputime] FROM [existingtab]">
            </asp:AccessDataSource>
        </td>
        <td>
        ACCURACY GRAPH
            <asp:AccessDataSource ID="AccessDataSource7" runat="server" 
                DataFile="~/App_Data/predic.mdb" 
                SelectCommand="SELECT [TestDate], [accuracy] FROM [existingtab]">
            </asp:AccessDataSource>
        </td>--%>
        <td class="style3">
        </td>
          <td>
          CPUTIME GRAPH<br />
&nbsp;<asp:Chart ID="Chart5" runat="server" DataSourceID="SqlDataSource3" 
                  BackColor="255, 128, 0" Palette="Berry">
                <Series>
                    <asp:Series Name="Series1" ChartType="FastLine" XValueMember="TestDate" 
                        YValueMembers="cputime">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Time">
                        </AxisY>
                        <AxisX Title="Date">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>    
              <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [TestDate], [cputime] FROM [occurenceper]"></asp:SqlDataSource>
              
        </td>
        <td>
        ACCURACY GRAPH<br />
&nbsp;<asp:Chart ID="Chart6" runat="server" DataSourceID="SqlDataSource4" 
                BackColor="Yellow" Palette="SemiTransparent">
                <Series>
                    <asp:Series Name="Series1" ChartType="FastLine" XValueMember="TestDate" 
                        YValueMembers="accuracy">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisY Title="Accuracy">
                        </AxisY>
                        <AxisX Title="Date">
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>    
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [TestDate], [accuracy] FROM [occurenceper]"></asp:SqlDataSource>
            
        </td>
    </tr>
</table>
<%--<table>
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="PERFORMANCE GRID" 
                onclick="Button1_Click" Visible="False" />
        </td>
        <td>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataSourceID="AccessDataSource5" Visible="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="tdate" HeaderText="tdate" SortExpression="tdate" />
                    <asp:BoundField DataField="cputime" HeaderText="cputime" 
                        SortExpression="cputime" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            <asp:AccessDataSource ID="AccessDataSource5" runat="server" 
                DataFile="~/App_Data/predic.mdb" SelectCommand="SELECT * FROM [performance]">
            </asp:AccessDataSource>
        </td>
    </tr>
</table>--%>
</asp:Content>

