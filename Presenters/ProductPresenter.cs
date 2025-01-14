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

        //addProduct
        public void OnAddProductRequested(object sender, AddProductEventArgs e)
        {
            var product = new Product()
            {
                Name = e.ProductName,
                Description = e.ProductDescription

            };
            model.AddProduct(product);
            _view.DisplayMessage("Add product successfuly");
            OnLoadPorductRequested(sender, new LoadProductEventArgs());
        }
       
        //loadProduct
        public void OnLoadPorductRequested(object sender, LoadProductEventArgs e)
        {
            List<Product> products = model.GetProduct();
            _view.ShowProduct(products);

        }
        //RemoveProduct
        public void OnRemoveProductRequested(object sender, RemoveProductEventArgs e)
        {
             model.DeleteProduct(e.ProductId);
            _view.DisplayMessage("product deleted successfuly");
        }
      //productProductForEdit
        private void OnLoadProductForEditRequested(object sender, LoadProductForEditEventArgs e)
        {
            Product product = model.GetProductById(e.ProductId);
            if (product != null)
            {
                _EditView.LoadProductDetails(product);
            }
            else
            {
                _EditView.DisplayMessage("Product not found.");
            }
        }
      //UpdateProduct
        private void OnUpdateProductRequested(object sender, UpdateProductEventArgs e)
        {
            Product product = new Product() {
                Id = e.ProductId,
                Name = e.ProductName,
                Description = e.ProductDescription                                 
            };


            model.UpdateProduct(product);
            _EditView.DisplayMessage("Product updated successfully!");
        }
    }
    }