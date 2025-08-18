<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewBills.aspx.cs" Inherits="Electricity_Prj.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PrimaryContent" runat="server">
    <div style="text-align:center;">
        <h2>View Last N Bills</h2>
        <label>Enter N Value to view bills: </label>
    <asp:TextBox ID="txtnvalue" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <br />
    <asp:Button ID="btnview" runat="server" Text="View" OnClick="btnview_Click" />
        <br />

    <asp:Label ID="error" runat="server" Visible="false" ForeColor="Red"></asp:Label>
    </div>
        
        <br />
        
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="ConsumerNumber" HeaderText="Consumer Number" />
                <asp:BoundField DataField="ConsumerName" HeaderText="Consumer Name" />
                <asp:BoundField DataField="UnitsConsumed" HeaderText="Units Consumed" />
                <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" />
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
    <br />
    <div style="text-align:center;">
        <br />
        <asp:Label ID ="txt" runat="server" Visible="False" Font-Size="Large" Font-Bold="True" ForeColor="#003366">Details of last 'N' bills:</asp:Label>
        <br />
        <asp:Label ID="nbills" runat="server" Visible="false" ForeColor ="Black"></asp:Label>
    </div>
    
</asp:Content>
