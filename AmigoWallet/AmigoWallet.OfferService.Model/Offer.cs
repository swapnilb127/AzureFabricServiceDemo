using System;

namespace AmigoWallet.OfferService.Model
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int Cashback { get; set; }
    
    }
}
