using MVPdemo.Data;
using MVPdemo.Models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MVPdemo.Views
{
    public partial class EditProduct : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the product ID from the query string
                if (Request.QueryString["Id"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["Id"]);
                    LoadProductDetails(productId);
                }
            }
        }      
        // Load product details based on the product ID
        private void LoadProductDetails(int productId)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            Product product = dbHelper.GetProductById(productId);

            if (product != null)
            {
                // Populate the fields with product details
                hdnProductId.Value = product.Id.ToString();
                txtProductName.Text = product.Name;
                txtProductDescription.Text = product.Description;
            }
        }

        // On Update Button Click
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get values from form controls
            int productId = Convert.ToInt32(hdnProductId.Value);
            string productName = txtProductName.Text;
            string productDescription = txtProductDescription.Text;

            // Create Product object
            Product updatedProduct = new Product
            {
                Id = productId,
                Name = productName,
                Description = productDescription
            };

            // Call DatabaseHelper to update the product in the database
            DatabaseHelper dbHelper = new DatabaseHelper();
            dbHelper.UpdateProduct(updatedProduct);
            Response.Redirect("ProductPage.aspx");

            // Show success message
            lblMessage.Text = "Product updated successfully!";
        }

    }
}
