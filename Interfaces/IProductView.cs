using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MVPdemo.Models;

namespace MVPdemo.Interfaces
{
    public interface IProductView
    {
   
        void ShowProduct(List<Product> products);
        void DisplayMessage(string message);
        void LoadProductDetails(Product product);

        event EventHandler<ProductEventArgs> AddProductRequest;
        event EventHandler<ProductEventArgs> LoadProductRequest;
        event EventHandler<ProductEventArgs> RemoveProductRequest;
        event EventHandler<ProductEventArgs> LoadProductForEditRequest;
        event EventHandler<ProductEventArgs> UpdateProductRequest;



    }
}
