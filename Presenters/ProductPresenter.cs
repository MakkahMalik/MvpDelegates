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
        public ProductPresenter(IProductView view)
        {
            _view = view;
             model = new DatabaseHelper();
            _view.AddProductRequest += OnAddProductRequested;
            _view.LoadProductRequest += OnLoadPorductRequested;
            _view.RemoveProductRequest += OnRemoveProductRequested;
            _view.LoadProductForEditRequest += OnLoadProductForEditRequested;
            _view.UpdateProductRequest += OnUpdateProductRequested;
 
        }


       public void AddProduct()
        {
            var product = new Product
            {
                Name = _view.ProductName,
                Description = _view.ProductDescription
            };
             model.AddProduct(product);
            _view.DisplayMessage("Add product successfuly");
        }

       public void LoadProduct() 
        {
            List<Product> products = model.GetProduct();
            _view.ShowProduct(products);
        }

       public void DeleteProduct(int id)
        {
            model.DeleteProduct(id);
        }

        public void LoadProductForEdit(int productId)
        {
            
            Product product = model.GetProductById(productId);
            if (product != null)
            {
                _view.ProductName = product.Name;
                _view.ProductDescription = product.Description;
            
            }
            else
            {
                _view.DisplayMessage("Product not found.");
            }
        }

        public void UpdateProduct()
        {
            var updatedProduct = new Product
            {
           
                Name = _view.ProductName,
                Description = _view.ProductDescription
            };
              model.UpdateProduct(updatedProduct);

        }

       



    }
    }