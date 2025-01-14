using MVPdemo.Data;
using MVPdemo.Interfaces;
using MVPdemo.Models;
using MVPdemo.Presenters;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MVPdemo.Views
{
    public partial class EditProduct : System.Web.UI.Page, IProductView
    {
        private readonly ProductPresenter presenter;
        public event EventHandler<ProductEventArgs> LoadProductForEditRequest;
        public event EventHandler<ProductEventArgs> UpdateProductRequest;
        public EditProduct()
        {
            presenter = new ProductPresenter(this); // Pass only IProductEdit
        }

        event EventHandler<ProductEventArgs> IProductView.AddProductRequest
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<ProductEventArgs> IProductView.LoadProductRequest
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<ProductEventArgs> IProductView.RemoveProductRequest
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<ProductEventArgs> IProductView.LoadProductForEditRequest
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event EventHandler<ProductEventArgs> IProductView.UpdateProductRequest
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the product ID from the query string
                if (Request.QueryString["Id"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["Id"]);
                    LoadProductForEditRequest?.Invoke(this, new ProductEventArgs { ProductId = productId });
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
            ProductEventArgs UpdateArg = new ProductEventArgs()
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

        void IProductView.ShowProduct(List<Product> products)
        {
            throw new NotImplementedException();
        }

        void IProductView.DisplayMessage(string message)
        {
            throw new NotImplementedException();
        }

        void IProductView.LoadProductDetails(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
