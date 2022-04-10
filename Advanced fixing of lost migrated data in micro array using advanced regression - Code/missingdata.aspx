<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="missingdata.aspx.cs" Inherits="missingdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table>
    <tr>
        <td>
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" DataSourceID="SqlDataSource1" 
                Width="973px" Font-Bold="True" Font-Names="Cambria" Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                            <asp:BoundField DataField="TestDate" HeaderText="TestDate" 
                                SortExpression="TestDate" />
                            <asp:BoundField DataField="WBC" HeaderText="WBC" SortExpression="WBC" />
                            <asp:BoundField DataField="RBC" HeaderText="RBC" SortExpression="RBC" />
                            <asp:BoundField DataField="HGB" HeaderText="HGB" SortExpression="HGB" />
                            <asp:BoundField DataField="HCT" HeaderText="HCT" SortExpression="HCT" />
                            <asp:BoundField DataField="MCV" HeaderText="MCV" SortExpression="MCV" />
                            <asp:BoundField DataField="MCH" HeaderText="MCH" SortExpression="MCH" />
                            <asp:BoundField DataField="MCHC" HeaderText="MCHC" SortExpression="MCHC" />
                            <asp:BoundField DataField="PLT" HeaderText="PLT" SortExpression="PLT" />
                            <asp:BoundField DataField="RDWSD" HeaderText="RDWSD" SortExpression="RDWSD" />
                            <asp:BoundField DataField="DW" HeaderText="DW" SortExpression="DW" />
                            <asp:BoundField DataField="MPV" HeaderText="MPV" SortExpression="MPV" />
                            <asp:BoundField DataField="PLCR" HeaderText="PLCR" SortExpression="PLCR" />
                            <asp:BoundField DataField="PCT" HeaderText="PCT" SortExpression="PCT" />
                            <asp:BoundField DataField="NRBC" HeaderText="NRBC" SortExpression="NRBC" />
                            <asp:BoundField DataField="NEUT" HeaderText="NEUT" SortExpression="NEUT" />
                            <asp:BoundField DataField="LYMPH" HeaderText="LYMPH" SortExpression="LYMPH" />
                            <asp:BoundField DataField="MONO" HeaderText="MONO" SortExpression="MONO" />
                            <asp:BoundField DataField="EO" HeaderText="EO" SortExpression="EO" />
                            <asp:BoundField DataField="BASO" HeaderText="BASO" SortExpression="BASO" />
                            <asp:BoundField DataField="IG" HeaderText="IG" SortExpression="IG" />
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [datasetdet]"></asp:SqlDataSource>
                    
        </td>
    </tr>
</table>
    <table align="center">
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Find Missing Data ???" 
                Font-Bold="True" Font-Names="Cambria" Width="287px" 
                onclick="Button1_Click" Height="41px" BorderColor="#FF6600" />
                 &nbsp;
                 <asp:Button ID="Button2" runat="server" Text="Fix Missing Data !!!" 
                Font-Bold="True" Font-Names="Cambria" Width="287px" 
                Height="41px" Visible="False" onclick="Button2_Click" BorderColor="#660033" />
            &nbsp;
            <asp:Button ID="Button3" runat="server" Font-Bold="True" 
                Font-Names="Cambria" ForeColor="#CC0000" onclick="Button3_Click" 
                Text="Download As Excel" Visible="False" />
        </td>
    </tr>
</table>
 <asp:Timer ID="Timer1" runat="server" OnTick="gettickvalue" 
    Interval="5000" Enabled="False" 
       >
</asp:Timer>
<asp:UpdatePanel ID="BannerPanel" runat="server" UpdateMode="Conditional">
<Triggers >
<asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
</Triggers>
<ContentTemplate>

<asp:Image ID="imgBanner" ImageUrl="~/img/uploading.gif" runat="server" 
        Visible="False" />
<table>
    <tr>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" DataSourceID="SqlDataSource2" 
                        Visible="False" Width="973px" Font-Bold="True" Font-Names="Cambria" 
                        Font-Size="Small">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                            <asp:BoundField DataField="TestDate" HeaderText="TestDate" 
                                SortExpression="TestDate" />
                            <asp:BoundField DataField="WBC" HeaderText="WBC" SortExpression="WBC" />
                            <asp:BoundField DataField="RBC" HeaderText="RBC" SortExpression="RBC" />
                            <asp:BoundField DataField="HGB" HeaderText="HGB" SortExpression="HGB" />
                            <asp:BoundField DataField="HCT" HeaderText="HCT" SortExpression="HCT" />
                            <asp:BoundField DataField="MCV" HeaderText="MCV" SortExpression="MCV" />
                            <asp:BoundField DataField="MCH" HeaderText="MCH" SortExpression="MCH" />
                            <asp:BoundField DataField="MCHC" HeaderText="MCHC" SortExpression="MCHC" />
                            <asp:BoundField DataField="PLT" HeaderText="PLT" SortExpression="PLT" />
                            <asp:BoundField DataField="RDWSD" HeaderText="RDWSD" SortExpression="RDWSD" />
                            <asp:BoundField DataField="DW" HeaderText="DW" SortExpression="DW" />
                            <asp:BoundField DataField="MPV" HeaderText="MPV" SortExpression="MPV" />
                            <asp:BoundField DataField="PLCR" HeaderText="PLCR" SortExpression="PLCR" />
                            <asp:BoundField DataField="PCT" HeaderText="PCT" SortExpression="PCT" />
                            <asp:BoundField DataField="NRBC" HeaderText="NRBC" SortExpression="NRBC" />
                            <asp:BoundField DataField="NEUT" HeaderText="NEUT" SortExpression="NEUT" />
                            <asp:BoundField DataField="LYMPH" HeaderText="LYMPH" SortExpression="LYMPH" />
                            <asp:BoundField DataField="MONO" HeaderText="MONO" SortExpression="MONO" />
                            <asp:BoundField DataField="EO" HeaderText="EO" SortExpression="EO" />
                            <asp:BoundField DataField="BASO" HeaderText="BASO" SortExpression="BASO" />
                            <asp:BoundField DataField="IG" HeaderText="IG" SortExpression="IG" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [datasetdet]"></asp:SqlDataSource>
                    
        </td>
    </tr>
</table>
</ContentTemplate>

</asp:UpdatePanel>
</asp:Content>

