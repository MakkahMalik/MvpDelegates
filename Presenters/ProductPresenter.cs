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
    
        private readonly DatabaseHelper model;
        public ProductPresenter(IProductView view )
        {
            _view = view;
           
             model = new DatabaseHelper();         
                _view.AddProductRequest += OnAddProductRequested;
                _view.LoadProductRequest += OnLoadPorductRequested;
                _view.RemoveProductRequest += OnRemoveProductRequested;
                _view.LoadProductForEditRequest += OnLoadProductForEditRequested;              
                _view.UpdateProductRequest += OnUpdateProductRequested;             
        }

        //addProduct
        public void OnAddProductRequested(object sender, ProductEventArgs e)
        {
            var product = new Product()
            {
                Name = e.ProductName,
                Description = e.ProductDescription

            };
            model.AddProduct(product);
            _view.DisplayMessage("Add product successfuly");
            OnLoadPorductRequested(sender, new ProductEventArgs());
        }
       
        //loadProduct
        public void OnLoadPorductRequested(object sender, ProductEventArgs e)
        {
            List<Product> products = model.GetProduct();
            _view.ShowProduct(products);

        }
        //RemoveProduct
        public void OnRemoveProductRequested(object sender, ProductEventArgs e)
        {
             model.DeleteProduct(e.ProductId);
            _view.DisplayMessage("product deleted successfuly");
        }
      //productProductForEdit
        private void OnLoadProductForEditRequested(object sender, ProductEventArgs e)
        {
            Product product = model.GetProductById(e.ProductId);
            if (product != null)
            {
                _view.LoadProductDetails(product);
            }
            else
            {
                _view.DisplayMessage("Product not found.");
            }
        }
      //UpdateProduct
        private void OnUpdateProductRequested(object sender, ProductEventArgs e)
        {
            Product product = new Product() {
                Id = e.ProductId,
                Name = e.ProductName,
                Description = e.ProductDescription                                 
            };


            model.UpdateProduct(product);
            _view.DisplayMessage("Product updated successfully!");
        }
    }
    }