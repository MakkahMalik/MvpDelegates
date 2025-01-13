using MVPdemo.Data;
using MVPdemo.Interfaces;
using MVPdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI.WebControls;

namespace MVPdemo.Presenters
{
    public class ProductPresenter
    {
        private readonly IProductView _view;
        private readonly IProductEdit _EditView;
        private readonly DatabaseHelper model;
        public ProductPresenter(IProductView view , IProductEdit EditView)
        {
            _view = view;
            _EditView = EditView;
             model = new DatabaseHelper();

            if(_view != null)
            {
                _view.AddProductRequest += OnAddProductRequested;
                _view.LoadProductRequest += OnLoadPorductRequested;
                _view.RemoveProductRequest += OnRemoveProductRequested;
            }

            if (_EditView != null) {

               _EditView.LoadProductForEditRequest += OnLoadProductForEditRequested;
               _EditView.UpdateProductRequest += OnUpdateProductRequested;
            }    
        }

        public void OnAddProductRequested(object sender, EventArgs e)
        {
            var product = new Product()
            {
                Name = _view.ProductName,
                Description = _view.ProductDescription

            };
            model.AddProduct(product);
            _view.DisplayMessage("Add product successfuly");
            OnLoadPorductRequested(sender, e);
        }
        public void OnLoadPorductRequested(object sender, EventArgs e)
        {
            List<Product> products = model.GetProduct();
            _view.ShowProduct(products);

        }
        public void OnRemoveProductRequested(object sender, int id)
        {
            model.DeleteProduct(id);
            _view.DisplayMessage("product deleted successfuly");
            OnLoadPorductRequested(sender, EventArgs.Empty);
        }
        private void OnLoadProductForEditRequested(object sender, int productId)
        {
            Product product = model.GetProductById(productId);
            if (product != null)
            {
                _EditView.LoadProductDetails(product);
            }
            else
            {
                _EditView.DisplayMessage("Product not found.");
            }
        }
        private void OnUpdateProductRequested(object sender, Product product)
        {
            model.UpdateProduct(product);
            _EditView.DisplayMessage("Product updated successfully!");
        }
    }
    }