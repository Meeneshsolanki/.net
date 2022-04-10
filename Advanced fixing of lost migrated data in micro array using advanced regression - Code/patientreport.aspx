<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="patientreport.aspx.cs" Inherits="patientreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <table style="width: 491px; height: 116px; font-family: cambria; font-size: small; font-weight: bold;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Upload Patient Report" 
                    ForeColor="Black"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Font-Bold="True" 
                    Font-Names="Cambria" Width="320px" ForeColor="Black" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" 
                    Width="102px" Font-Bold="True" Font-Names="Cambria" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Cancel" Width="101px" 
                    Font-Bold="True" Font-Names="Cambria" />
              
            &nbsp;&nbsp;
               
              
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
         <asp:Label ID="lblack" runat="server" ForeColor="#CC0000" 
                    Text="Uploaded Successfully !!!" Visible="False" 
        Font-Bold="True"></asp:Label>
</ContentTemplate>

</asp:UpdatePanel>
</asp:Content>

