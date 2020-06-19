using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AmigoWallet.OfferService.Model;

namespace AmigoWallet.OfferService.Model
{
    public interface IOfferRepository
    {
        Task<List<Offer>> GetAllOffers();
        Task AddOffer(Offer offer);
    }
}
