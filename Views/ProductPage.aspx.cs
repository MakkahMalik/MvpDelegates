using MVPdemo.Data;
using MVPdemo.Interfaces;
using MVPdemo.Models;
using MVPdemo.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVPdemo.Views
{
    public partial class ProductPage : System.Web.UI.Page, IProductView
    {
       private readonly ProductPresenter presenter;

        //event
        public event EventHandler<AddProductEventArgs> AddProductRequest;
        public event EventHandler<LoadProductEventArgs> LoadProductRequest;
        public event EventHandler<RemoveProductEventArgs> RemoveProductRequest;
        public event EventHandler<int> LoadProductForEditRequest;
        public ProductPage()
        {
            presenter = new ProductPresenter(this , null);

        }

        //page load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductRequest?.Invoke(this, new LoadProductEventArgs());


            }
        
        }
        public string ProductName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }
        public string ProductDescription
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }

        //disply masg
        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
        }

        //btnsave
        protected void btnSave_Click(object sender, EventArgs e)
        {

            //AddProductRequest?.Invoke(this, new AddProductEventArgs
            //{
            //    ProductName = txtName.Text,
            //    ProductDescription = txtDescription.Text

            //});
            AddProductEventArgs args = new AddProductEventArgs()
            {
                ProductName = txtName.Text,
                ProductDescription = txtDescription.Text
            };

            AddProductRequest.Invoke(this, args);
            txtName.Text =string.Empty;
            txtDescription.Text = string.Empty;
        }
      
        //showproduct
        public void ShowProduct(List<Product> products)
        {
            gvProduct.DataSource = products;
            gvProduct.DataBind();
        }

        //argument for delete and edit
        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "DeleteProduct")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var eventArgs = new RemoveProductEventArgs
                {
                    ProductId = id
                };

                RemoveProductRequest.Invoke(this, eventArgs);
                LoadProductRequest?.Invoke(this, new LoadProductEventArgs());
                //presenter.LoadProduct();

                lblMessage.Text = "Data Delete successfuly";
            }
            if (e.CommandName == "EditProduct")
                {
                    int productId = Convert.ToInt32(e.CommandArgument);
                    
                    // Redirect to the EditProduct page and pass the ProductId as a query string
                    Response.Redirect($"EditProduct.aspx?Id={productId}");

                }
            

        }




    }
}