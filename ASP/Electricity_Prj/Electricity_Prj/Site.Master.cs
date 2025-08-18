using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Electricity_Prj
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    login.Visible = false;
                    adefault.Visible = true;
                    add.Visible = true;
                    view.Visible = true;
                    btnLogout.Visible = true;
                }
                else
                {
                    login.Visible = true;
                    adefault.Visible = false;
                    add.Visible = false;
                    view.Visible = false;
                    btnLogout.Visible = false;
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}