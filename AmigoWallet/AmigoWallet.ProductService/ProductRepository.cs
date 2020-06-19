using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AmigoWallet.ProductService.Model;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;

namespace AmigoWallet.ProductService
{
    public class ProductRepository : IProductRepository
    {
        private readonly IReliableStateManager _reliableStateManager;
        public ProductRepository(IReliableStateManager reliableStateManager)
        {
            _reliableStateManager = reliableStateManager;
        }

        public async Task AddProduct(Product product)
        {
            var offerlist = await _reliableStateManager.GetOrAddAsync<IReliableDictionary<int, Product>>("offers");

            using (var tx = _reliableStateManager.CreateTransaction())
            {
                await offerlist.AddOrUpdateAsync(tx, product.ProductId, product, (id, value) => product);
                await tx.CommitAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var offerlist = await _reliableStateManager.GetOrAddAsync<IReliableDictionary<int, Product>>("offers");
            var result = new List<Product>();
            using (var tx = _reliableStateManager.CreateTransaction())
            {
                var allOffers = await offerlist.CreateEnumerableAsync(tx, EnumerationMode.Unordered);
                using (var enumerator = allOffers.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        KeyValuePair<int, Product> current = enumerator.Current;
                        result.Add(current.Value);
                    }
                }
            }
            return result;
        }
    }
}
