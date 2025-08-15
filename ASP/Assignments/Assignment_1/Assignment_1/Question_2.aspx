<%--Create a web application that hosts a series of products (any) as a dropdown list.
Have a image control that can display the image of the selected item in the dropdown.
have a button control that gets the price of the selected product and displays it in a Label control--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question_2.aspx.cs" Inherits="Assignment_1.Question_2" %>
 
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Question 2</title>
    <style>
        .container {
            max-width: 600px;
            margin: 50px auto;
            background-color: #ffffff;
            padding: 30px;
            border-radius: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div class="container">
<h2>Select a Product:</h2>
 
       <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" CssClass="dropdown"></asp:DropDownList>
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Width="400px" Height="400px" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Get Price" OnClick="btnGetPrice_Click"  CssClass="button"/>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"  CssClass="price-label" ForeColor="Green"></asp:Label>
        </div>
</form>
</body>
</html>
