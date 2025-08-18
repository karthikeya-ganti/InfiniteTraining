using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Electricity_Prj
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            int n = 0;
            int.TryParse(txtnvalue.Text, out n);
            if (n <= 0)
            {
                error.Visible = true;
                error.Text = "N cannot be less than or equal to zero";
                return;
            }
            ElectricityBoard eb = new ElectricityBoard();
            var bills = eb.Generate_N_BillDetails(n);
            GridView1.DataSource = bills;
            GridView1.DataBind(); 
            txt.Visible = true;
            nbills.Visible = true;
            for (int i = 0; i < n; i++)
            {
                nbills.Text += $"<p>EB Bill for {bills[i].ConsumerName} is {bills[i].BillAmount}</p>";
            }
        }
    }
}