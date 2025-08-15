using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Question_2 : System.Web.UI.Page
    {
        
        Dictionary<string, (string ImageUrl, string Price)> products = new Dictionary<string, (string, string)>
        {
            { "Laptop", ("~/Images/laptop.png", "$999") },
            { "Desktop", ("~/Images/desktop.png", "$799") },
            { "Tablet", ("~/Images/tablet.png", "$499") },
            { "Mobile", ("~/Images/mobile.png", "$699") }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("-- Select Product --");
                foreach (var product in products.Keys)
                {
                    DropDownList1.Items.Add(product);
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = DropDownList1.SelectedItem.Text;

            if (products.ContainsKey(selectedProduct))
            {
                Image1.ImageUrl = products[selectedProduct].ImageUrl;
                Label1.Text = "";
            }
            else
            {
                Image1.ImageUrl = "";
                Label1.Text = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selectedProduct = DropDownList1.SelectedItem.Text;

            if (products.ContainsKey(selectedProduct))
            {
                Label1.Text = "Price: " + products[selectedProduct].Price;
            }
            else
            {
                Label1.Text = "Please select a valid product.";
            }
        }
    }
}
