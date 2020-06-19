using AmigoWallet.ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace AmigoWallet.ProductService
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task AddProduct(Product offer);
    }
}
