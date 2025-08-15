using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Question_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Page.Validate();
            }
        }
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                lbltext.Visible = false;
                lblMessage.Text = "Validation Successful";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ValidationSummary1.Visible = false;
            }
            else
            {
                lbltext.Visible = true;
                lblMessage.Text = "Please edit details.....";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                ValidationSummary1.Visible = true;
            }
        }

        protected void CustomValidatorEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(args.Value.Trim(), @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        protected void CustomValidatorName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(args.Value);
        }

        protected void CustomValidatorFamilyName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtname.Text.Trim() == "" || txtfname.Text.Trim() == txtname.Text.Trim())
            {
                args.IsValid = false;
            }
            args.IsValid = txtfname.Text.Trim() != txtname.Text.Trim();
        }

        protected void CustomValidatorZip_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(args.Value.Trim(), @"^\d{5}$");
        }

        protected void CustomValidatorAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() == "")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = args.Value.Length >= 2;
            }
        }

        protected void CustomValidatorCity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() == "")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = args.Value.Length >= 2;
            }
        }

        protected void CustomValidatorPhone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string value = args.Value.Trim();

            if (string.IsNullOrEmpty(value))
            {
                args.IsValid = false;
            }
            else
            { 
                var phonePattern = @"^(\d{2}-\d{7}|\d{3}-\d{7})$";
                args.IsValid = System.Text.RegularExpressions.Regex.IsMatch(value, phonePattern);
            }
        }

    }
}