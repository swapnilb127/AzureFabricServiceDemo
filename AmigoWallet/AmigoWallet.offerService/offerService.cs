using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using AmigoWallet.OfferService.Model;

namespace AmigoWallet.offerService
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class offerService : StatefulService
    {
        private IOfferRepository _repObj;
        public offerService(StatefulServiceContext context)
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
            _repObj = new OfferRepository(this.StateManager);
            var offer1 = new Offer
            {
                OfferId = 1,
                MinAmount = 20000,
                MaxAmount = 50000,
                Cashback = 50
            };
            var offer2 = new Offer
            {
                OfferId = 2,
                MinAmount = 50001,
                MaxAmount = 100000,
                Cashback = 100
            };
            var offer3 = new Offer
            {
                OfferId = 3,
                MinAmount = 100001,
                MaxAmount = 150000,
                Cashback = 200
            };
            var offer4 = new Offer
            {
                OfferId = 4,
                MinAmount = 150001,
                MaxAmount = 200000,
                Cashback = 300
            };


            await _repObj.AddOffer(offer1);
            await _repObj.AddOffer(offer2);
            await _repObj.AddOffer(offer3);
            await _repObj.AddOffer(offer4);
        }
    }
}
