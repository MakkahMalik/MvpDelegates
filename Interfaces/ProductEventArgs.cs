using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPdemo.Interfaces
{

    public class AddProductEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

    }

    public class UpdateProductEventArgs : EventArgs
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }

    public class RemoveProductEventArgs : EventArgs
   {
        public int ProductId { get; set; }
    }

    public class LoadProductEventArgs : EventArgs
    {
    }





}
