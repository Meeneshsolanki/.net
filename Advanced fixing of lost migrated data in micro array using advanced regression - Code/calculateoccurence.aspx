<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="calculateoccurence.aspx.cs" Inherits="calculateoccurence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
         <td>
             <asp:Image ID="Image1" runat="server" ImageUrl="~/img/calculate.png" />
      </td>
        <td>
        
      
    <table style="width: 441px; height: 230px; color: #000000; font-family: cambria; font-size: small; font-weight: bolder;">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Patient Id"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblid" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
       <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Patient Name"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
       <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Select Test Date"></asp:Label>
        </td>
        <td>
            
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="TestDate" 
                DataValueField="TestDate" Font-Bold="True" Font-Names="Cambria" 
                BackColor="#FF6600">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [TestDate] FROM [datasetdet] WHERE (([ID] = @ID) AND ([Name] = @Name))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lblid" Name="ID" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="lblname" Name="Name" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Calculate" 
                onclick="Button1_Click" Font-Bold="True" Font-Names="Cambria" ForeColor="Black" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblpercen" runat="server" Text="........." Font-Bold="True" 
                ForeColor="#CC0000" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
  </td>
 
    </tr>
</table>

</asp:Content>

