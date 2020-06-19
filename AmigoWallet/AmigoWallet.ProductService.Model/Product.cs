using System;

namespace AmigoWallet.ProductService.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int QuantityAvailable { get; set; }
        
    }
}
