using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfferMicroservice.Models;

namespace OfferMicroservice.Service
{
    public interface IOfferRepo<T>
    {
        List<T> GetAllOffers();
        T GetOfferDetails(int OfferId);

        T AddOffer(Offer newOffer);

        T EditOffer(Offer updateOff);

        T EngaOffer(Offer offerDetails);
        List<T> CatOffer(string category);

        List<T> DateOffer(DateTime openedDate);
        List<T> ThreeLikes(string category);

        T LikeOffer(Offer o);


    }
}
