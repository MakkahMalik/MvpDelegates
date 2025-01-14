using MVPdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPdemo.Interfaces
{
    public interface IProductEdit
    {      
        void LoadProductDetails(Product product);
        void DisplayMessage(string message);
        event EventHandler<LoadProductForEditEventArgs> LoadProductForEditRequest;
        event EventHandler<UpdateProductEventArgs> UpdateProductRequest;
        

    }
}
