<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment_1.Question_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Question 1</title>
    <style type="text/css">
        .selfstyle{
            height:476px;
            margin-left:40px;
        }
    </style>
    <script type="text/javascript">
        function ValidateField(source, args) {
            if (args.Value.trim() === "") {
                args.IsValid = false;
            } else {
                args.IsValid = args.Value.length >= 2;
            }
        }

        function ValidatePhone(source, args) {
            var value = args.Value.trim();
            if (value === "") {
                args.IsValid = false;
            } else {
                var phonePattern = /^(\d{2}-\d{7}|\d{3}-\d{7})$/;
                if (phonePattern.test(value)) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }
        }

        function ValidateEmail(source, args) {
            var value = args.Value.trim();
            if (value === "") {
                args.IsValid = false;
            } else {
                var emailPattern = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                if (emailPattern.test(value)) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }
        }
        function ValidateFamilyName(source, args) {
            var name = document.getElementById('<%= txtname.ClientID %>').value.trim();
            var familyName = args.Value.trim();
            if (familyName === "") {
                args.IsValid = false;
            } else {
                if (familyName.toLowerCase() !== name.toLowerCase()) {
                    args.IsValid = true;
                } else {
                    args.IsValid = false;
                }
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="selfstyle">
            <h3 style="color:black;font-size:20px;text-align:left">Insert your details:</h3>
            &nbsp;&nbsp;<br />
            Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; 
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" Display="Dynamic" ErrorMessage="Name cannot be Blank" ForeColor="Red" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            <br />
            <br />
            Family Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtname" Display="Dynamic" ErrorMessage="Family Name cannot be Blank" ForeColor="Red" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            &nbsp;<asp:CustomValidator ID="CustomValidatorFamilyName" runat="server"
            OnServerValidate="CustomValidatorFamilyName_ServerValidate"
            ControlToValidate="txtfname"
            ClientValidationFunction="ValidateFamilyName"
            ErrorMessage="Family Name must differ from Name"
            ForeColor="Red" ValidationGroup="Validation" Display="Dynamic"> </asp:CustomValidator>

&nbsp;
            <br />
            <br />
            Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
            
           

            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtaddress" ErrorMessage="Address cannot be Blank" ForeColor="Red" ValidationGroup="Validation" Display="Dynamic">*</asp:RequiredFieldValidator>
&nbsp;
             <asp:CustomValidator ID="CustomValidatorAddress" runat="server"
                ControlToValidate="txtaddress"
                 OnServerValidate="CustomValidatorAddress_ServerValidate"
                ClientValidationFunction="ValidateField"
                 Display="Dynamic"
                ErrorMessage="Address must be at least 2 characters"
                ForeColor="Red" ValidationGroup="Validation"></asp:CustomValidator>
            <br />
            <br />
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="txtcity" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtcity" ErrorMessage="City cannot be Blank" ForeColor="Red" ValidationGroup="Validation" Display="Dynamic">*</asp:RequiredFieldValidator>
&nbsp;
             <asp:CustomValidator ID="CustomValidatorCity" runat="server"
                ControlToValidate="txtcity"
                 OnServerValidate="CustomValidatorCity_ServerValidate"
                ClientValidationFunction="ValidateField"
                 Display="Dynamic"
                ErrorMessage="City must be at least 2 characters"
                ForeColor="Red" ValidationGroup="Validation"></asp:CustomValidator>
            <br />
            <br />
            Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="txtzipcode" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtzipcode" ErrorMessage="Zip Code cannot be Blank" ForeColor="Red" ValidationGroup="Validation" Display="Dynamic">*</asp:RequiredFieldValidator>
&nbsp;
            <asp:CustomValidator ID="CustomValidatorZip" runat="server"
                ControlToValidate="txtzipcode"
                OnServerValidate="CustomValidatorZip_ServerValidate"
                ErrorMessage="Zip Code must be exactly 5 digits"
                ForeColor="Red" ValidationGroup="Validation" Display="Dynamic">  </asp:CustomValidator>
            <br />
            <br />
            Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtname" Display="Dynamic" ErrorMessage="Phone cannot be Blank" ForeColor="Red" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            &nbsp;<asp:CustomValidator ID="CustomValidatorPhone" runat="server"
                ControlToValidate="txtphone"
                OnServerValidate="CustomValidatorPhone_ServerValidate"
                ClientValidationFunction="ValidatePhone"
                ErrorMessage="Invalid Phone format"
                ForeColor="Red" ValidationGroup="Validation" Display="Dynamic"> </asp:CustomValidator>

&nbsp;
            <br />
            <br />
            Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtemail" ErrorMessage="Email cannot be Blank" ForeColor="Red" ValidationGroup="Validation" Display="Dynamic">*</asp:RequiredFieldValidator>
&nbsp;
            <asp:CustomValidator ID="CustomValidatorEmail" runat="server"
            ControlToValidate="txtemail"
                OnServerValidate="CustomValidatorEmail_ServerValidate"
             ClientValidationFunction="ValidateEmail"
            ErrorMessage="Invalid Email format"
             ForeColor="Red" ValidationGroup="Validation" Display="Dynamic" />

            <br />
            <br />
            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" ValidationGroup="Validation" />
            <br />
            <br />
            <br />
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" />
        <asp:Label ID="lbltext" runat="server" style="color:red">Validation Summary</asp:Label><asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Validation" />
    </form>
</body>
</html>
