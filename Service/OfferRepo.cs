using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OfferMicroservice.Service
{
    public class OfferRepo : IOfferRepo<Offer>
    {
        
        public static List<Offer> offers = new List<Offer>
            {
                 new Offer { EmployeeId=101,OfferId = 1, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate =new DateTime(2022,02,01), Details="Resale of Mobile",ClosedDate=new DateTime(),EngagedDate=new DateTime()},

                 new Offer { EmployeeId=102,OfferId = 2, Status = "Engaged", Likes = 55, Category = "Electronics", OpenedDate = new DateTime(2022,02,04),ClosedDate=new DateTime() , Details="Resale of washing machine",EngagedDate=new DateTime(2022,02,05)},

                 new Offer { EmployeeId=103,OfferId = 3, Status = "Engaged", Likes = 20, Category = "Vehicle", OpenedDate = new DateTime(2022,02,04),ClosedDate=new DateTime() , Details="Resale of Two wheeler ",EngagedDate=new DateTime(2022,02,09)},

                 new Offer { EmployeeId=103,OfferId = 4, Status = "Available", Likes = 25, Category = "Electronics", OpenedDate = new DateTime(2022,02,09),ClosedDate=new DateTime() , Details="Resale of Laptop",EngagedDate=new DateTime()},

                 new Offer { EmployeeId=103,OfferId = 5, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate = new DateTime(2022,02,09),ClosedDate=new DateTime() , Details="Resale of Laptop",EngagedDate=new DateTime()},

                 new Offer { EmployeeId=103,OfferId = 6 ,Status = "Closed", Likes = 24, Category = "Books", OpenedDate = new DateTime(2022,02,09),EngagedDate=new  DateTime(2022,02,09), ClosedDate=new DateTime(2022,02,10),Details="Wings Of Fire"},

                 new Offer {EmployeeId=104,OfferId = 7, Status = "Available", Likes = 25, Category = "Vehicle", OpenedDate =new DateTime(2022,02,18), Details="Resale of car",ClosedDate=new DateTime(),EngagedDate=new DateTime()},

                 new Offer { EmployeeId=105,OfferId = 8, Status = "Engaged", Likes = 22, Category = "Electronics", OpenedDate = new DateTime(2022,01,04),ClosedDate=new DateTime() , Details="Resale of Mobile",EngagedDate=new DateTime(2022,01,06)},


                 new Offer { EmployeeId=105,OfferId = 9, Status = "Closed", Likes = 18, Category = "Books", OpenedDate = new DateTime(2022,02,01),EngagedDate=new  DateTime(2022,02,03), ClosedDate=new DateTime(2022,02,05),Details="Harry Potter Books"},

            };

        public List<Offer> GetAllOffers()
        {
            return offers;
        }

        public  Offer GetOfferDetails(int OfferId)
        {
            var offer = offers.FirstOrDefault(c => c.OfferId == OfferId);
            if(offer!=null)
            {
                return offer;
            }
            else
            {
                return null;
            }

            


        }

        public Offer AddOffer(Offer newOffer)
        {
           
            
            foreach(var l in offers)
            {
                if(l.OfferId==newOffer.OfferId)
                {
                    return null;
                }
            }
            offers.Add(newOffer);
            return newOffer;
            //if (idCheck!=null)
            //{
            //    offers.Add(newOffer);
            //    return newOffer;
            //}
            //return null;
            
            

        }

        public Offer EditOffer(Offer updateOff)
        {
            var upd = offers.Find(c => c.OfferId == updateOff.OfferId && c.EmployeeId == updateOff.EmployeeId);

            if (upd != null)
            {
                upd.ClosedDate = updateOff.ClosedDate;

                upd.Status = updateOff.Status;

                upd.Details = updateOff.Details;

                upd.Category = updateOff.Category;



                //return offers;
            }
            return upd;

        }

        public Offer EngaOffer(Offer offerDetails)
        {
            //Offer o = new Offer();
            //o.OfferId = offerDetails.OfferId;
            //o.EmployeeId = offerDetails.EmployeeId;

            var eng = offers.FirstOrDefault(c => c.OfferId == offerDetails.OfferId && c.EmployeeId == offerDetails.EmployeeId);
            //if (eng == null)
            //{
                
            //    return null;
            //}
            //else if(eng.Status == "Engaged" || eng.Status == "Closed")
            //{

            //    return;

            //}
            if (eng != null)
            {
                if (eng.Status != "Engaged" || eng.Status != "Closed")
                {
                    eng.Status = "Engaged";
                    eng.EngagedDate = DateTime.Now;
                   
                }
                return eng;
            }
            else
            {

                return null;
            }


        }

        public List<Offer> CatOffer(string category)
        {
            List<Offer> cat = new List<Offer>();
            var list = offers.Where(c => c.Category == category);
            
            foreach (var l in list)
                cat.Add(l);
            if (cat.Count()== 0)
            {
                return null;
            }

            return cat;

        }

        public List<Offer> DateOffer(DateTime openedDate)
        {
            List<Offer> date = new List<Offer>();
            var list = offers.Where(c => c.OpenedDate == openedDate);
            foreach (var l in list)
                date.Add(l);
            if(date.Count()==0)
            {
                return null;
            }

            return date;


        }
        public List<Offer> ThreeLikes(string category)
        {
            List<Offer> likes = new List<Offer>();
            var like = (from c in offers where c.Category == category orderby c.Likes descending select c).Take(3);
            foreach (var m in like)
                likes.Add(m);

            if(likes.Count()==0)
            {
                return null;
            }
            return likes;
        }

        public Offer LikeOffer(Offer o)
        {
            Offer offer = offers.FirstOrDefault(c => c.OfferId == o.OfferId);
            offer.Likes = offer.Likes + 1;
            return offer;

        }
    }
}
