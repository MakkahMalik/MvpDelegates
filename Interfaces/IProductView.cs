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
        string ProductName { get; set; }
        string ProductDescription { get; set; }
        void ShowProduct(List<Product> products);
        void DisplayMessage(string message);

       
        event EventHandler<AddProductEventArgs> AddProductRequest;
        event EventHandler<LoadProductEventArgs> LoadProductRequest;
        event EventHandler<RemoveProductEventArgs> RemoveProductRequest;
        event EventHandler<int> LoadProductForEditRequest;



    }
}
