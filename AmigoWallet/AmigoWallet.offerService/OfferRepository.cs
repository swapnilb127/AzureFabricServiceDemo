using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;

namespace AmigoWallet.OfferService.Model
{
    public class OfferRepository : IOfferRepository
    {
        private readonly IReliableStateManager _reliableStateManager;
        public OfferRepository(IReliableStateManager reliableStateManager)
        {
            _reliableStateManager = reliableStateManager;
        }
        public async Task AddOffer(Offer offer)
        {
            var offerlist = await _reliableStateManager.GetOrAddAsync<IReliableDictionary<int, Offer>>("offers");

            using (var tx = _reliableStateManager.CreateTransaction())
            {
                await offerlist.AddOrUpdateAsync(tx, offer.OfferId, offer, (id, value) => offer);
                await tx.CommitAsync();
            }
        }
        public async Task<List<Offer>> GetAllOffers()
        {
            var offerlist = await _reliableStateManager.GetOrAddAsync<IReliableDictionary<int, Offer>>("offers");
            var result = new List<Offer>();
            using (var tx = _reliableStateManager.CreateTransaction())
            {
                var allOffers = await offerlist.CreateEnumerableAsync(tx, EnumerationMode.Unordered);
                using (var enumerator = allOffers.GetAsyncEnumerator())
                {
                    while (await enumerator.MoveNextAsync(CancellationToken.None))
                    {
                        KeyValuePair<int, Offer> current = enumerator.Current;
                        result.Add(current.Value);
                    }
                }
            }
            return result;
        }
    }
}
