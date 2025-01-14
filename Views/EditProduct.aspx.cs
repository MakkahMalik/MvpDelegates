using MVPdemo.Data;
using MVPdemo.Interfaces;
using MVPdemo.Models;
using MVPdemo.Presenters;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MVPdemo.Views
{
    public partial class EditProduct : System.Web.UI.Page, IProductEdit
    {
        private readonly ProductPresenter presenter;
        public event EventHandler<LoadProductForEditEventArgs> LoadProductForEditRequest;
        public event EventHandler<UpdateProductEventArgs> UpdateProductRequest;
        public EditProduct()
        {
            presenter = new ProductPresenter(null, this); // Pass only IProductEdit
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the product ID from the query string
                if (Request.QueryString["Id"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["Id"]);
                    LoadProductForEditRequest?.Invoke(this, new LoadProductForEditEventArgs { ProductId = productId });
                }
            }
        }
        public void LoadProductDetails(Product product)
        {
            if (product != null)
            {
                hdnProductId.Value = product.Id.ToString();
                txtProductName.Text = product.Name;
                txtProductDescription.Text = product.Description;
            }
            else
            {
                lblMessage.Text = "Product not found.";
            }
        }
        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get values from form controls
            UpdateProductEventArgs UpdateArg = new UpdateProductEventArgs()
            {
                ProductId = Convert.ToInt32(hdnProductId.Value),
                ProductName = txtProductName.Text,
                ProductDescription = txtProductDescription.Text
            };

             UpdateProductRequest.Invoke(this, UpdateArg);

             Response.Redirect("ProductPage.aspx");

            // Show success message
             lblMessage.Text = "Product updated successfully!";
        }

    }
}
