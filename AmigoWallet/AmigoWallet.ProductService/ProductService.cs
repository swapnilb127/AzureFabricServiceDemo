using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AmigoWallet.ProductService.Model;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace AmigoWallet.ProductService
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class ProductService : StatefulService
    {
        private IProductRepository _repObj;
        public ProductService(StatefulServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new ServiceReplicaListener[0];
        }

        /// <summary>
        /// This is the main entry point for your service replica.
        /// This method executes when this replica of your service becomes primary and has write status.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service replica.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            _repObj = new ProductRepository(this.StateManager);
            var offer1 = new Product
            {

                ProductId = 1,
                CategoryId = 10,
                ProductName = "Samsung K10",
                Price = 9500,
                QuantityAvailable = 10
            };
            var offer2 = new Product
            {
                ProductId = 2,
                CategoryId = 10,
                ProductName = "Xiomi Note 10",
                Price = 12500,
                QuantityAvailable = 10
            };
            var offer3 = new Product
            {
                ProductId = 3,
                CategoryId = 10,
                ProductName = "Lenovo K3 Note",
                Price = 9500,
                QuantityAvailable = 10
            };
            var offer4 = new Product
            {
                ProductId = 4,
                CategoryId = 10,
                ProductName = "Nokia N70",
                Price = 6500,
                QuantityAvailable = 10
            };


            await _repObj.AddProduct(offer1);
            await _repObj.AddProduct(offer2);
            await _repObj.AddProduct(offer3);
            await _repObj.AddProduct(offer4);
        }
    }
}
