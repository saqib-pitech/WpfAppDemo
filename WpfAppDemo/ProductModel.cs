using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppDemo
{
    class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> prodList = new List<ProductModel>() { new ProductModel { ProductId=1, ProductName="Watch", UnitPrice=1200},
            new ProductModel { ProductId=2, ProductName="Ipod", UnitPrice=3000},
            new ProductModel { ProductId=3, ProductName="Mobile", UnitPrice=5000}};
            return prodList;
        }
    }
}
