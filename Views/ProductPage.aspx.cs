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

      public event EventHandler AddProductRequest;
      public event EventHandler LoadProductRequest;
      public event EventHandler<int> RemoveProductRequest;
      public event EventHandler<int> LoadProductForEditRequest;
        public ProductPage()
        {
            presenter = new ProductPresenter(this , null);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductRequest?.Invoke(this, EventArgs.Empty);


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
        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            AddProductRequest?.Invoke(this, EventArgs.Empty);
            txtName.Text =string.Empty;
            txtDescription.Text = string.Empty;
        }

        public void ShowProduct(List<Product> products)
        {
            gvProduct.DataSource = products;
            gvProduct.DataBind();
        }

        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "DeleteProduct")
            {
                int id = Convert.ToInt32(e.CommandArgument);    
                RemoveProductRequest.Invoke(this,id);
                    
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