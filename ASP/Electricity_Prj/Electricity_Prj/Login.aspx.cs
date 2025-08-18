using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Electricity_Prj
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtusername.Text, txtpassword.Text))
            {
                Session["User"] = txtusername.Text;
                FormsAuthentication.RedirectFromLoginPage(txtusername.Text, false);
            }
            else
            {
                labelmsg.Text = "Invalid User Name or Password";
                labelmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}