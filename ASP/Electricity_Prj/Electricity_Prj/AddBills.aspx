<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBills.aspx.cs" Inherits="Electricity_Prj.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PrimaryContent" runat="server">
    <div style="text-align:center;">
        <h3>Add Electricity Bills</h3>
             <label for="txtBillCount">Enter Number of Bills to be added: </label>
             <asp:TextBox ID="txtBillCount" runat="server" TextMode="Number"></asp:TextBox>&nbsp; <br /><br />
             <asp:Button ID="btnAdd" runat="server" TextMode="Add" Text="Add" Height="30px" Width="60px" OnClick="btnAdd_Click" ValidationGroup="Add"></asp:Button>
        <br />
        <br />
             <asp:PlaceHolder ID="bills" runat="server"></asp:PlaceHolder>
             <br />
        <br />
             <asp:Button ID="btnSave" runat="server" TextMode="Save" Text="Save" Height="30px" Width="60px" Visible="false" OnClick="btnSave_Click"></asp:Button><br />
        <asp:Label ID="status" runat="server" ForeColor="Green"></asp:Label><br />
        <asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
    </div>
</asp:Content>
