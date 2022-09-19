
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferMicroservice.Models;
using OfferMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OfferMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OfferController : ControllerBase
    {
        private IOfferRepo<Offer> _repo;


        public OfferController(IOfferRepo<Offer> repo)
        {
            _repo = repo;
        }


        // GET: api/<OfferController>
        [HttpGet]
        [Route("GetOffersList")]
        public IActionResult GetOffersList()
        {
            if (_repo.GetAllOffers() != null)
                return Ok(_repo.GetAllOffers());
            return BadRequest("No Offers");
        }

        // GET: api/<OfferController>/<name>
        [HttpGet]
        [Route("GetOfferById/{id}")]
        public IActionResult GetOfferById(int id)
        {
            
            
            var offer = _repo.GetOfferDetails(id);
            if (offer != null)
            {
                return Ok(offer);
            }
            
            return NotFound("Offer Not Found");
            


            //catch
            //{
            //    return BadRequest("No offer found");
            //}
        }




        // POST api/<OfferController>
        [HttpPost]
        [Route("PostOffer")]
        public ActionResult<IEnumerable<Offer>> PostOffer(Offer newOffer)
        {
            if (newOffer.OfferId == 0 || newOffer.EmployeeId == 0 || newOffer.Category == null || newOffer.Details == null)

            {
                return BadRequest(new {message="OfferId, Employee Id, Category, details cannot be empty"});
            }
            else
            {
                var _offer = _repo.AddOffer(newOffer);
                if(_offer==null)
                {
                    return BadRequest(new { message = "Offer Id already exists" });
                }
                return Ok( new {message="offer Added Successfully"});
            }


        }

        // PUT api/<OfferController>/5
        [HttpPost]
        [Route("EditOffer")]

        public IActionResult UpdateOffer(Offer updateOff)

        {
            var _update = _repo.EditOffer(updateOff);

            //if(offer.ClosedDate>offer.EngagedDate && offer.Status!="Closed")
            //{
            //    return BadRequest("Please update status to Closed");
            //}

            //return Ok("Edited Successfully");
            return Ok(_update);

            //return offers;

        }




        [HttpGet]
        [Route("GetOfferByCategory/{category}")]
        public IActionResult GetOfferByCategory(string category)
        {
            var _category = _repo.CatOffer(category);
            if(_category==null)
            {
                return NotFound("No such Category found.");
            }

            return Ok(_category);

        }

        [HttpGet]
        [Route("GetOfferByOpenedDate/{openedDate}")]
        public ActionResult<Offer> GetOfferByOpenedDate(DateTime openedDate)
        {
            var _date = _repo.DateOffer(openedDate);
            if(_date==null)
            {
                return NotFound("No offers found in the given date.");
            }
            return Ok(_date);

        }


        [HttpGet]
        [Route("GetOfferByTopThreeLikes/{category}")]
        public ActionResult<Offer> GetOfferByTopThreeLikes(string category)
        {

            var _like = _repo.ThreeLikes(category);
            if(_like==null)
            {
                return NotFound("No offers found");
            }
            return Ok(_like);
        }

        [HttpPost]
        [Route("EngageOffer")]
        public ActionResult<IEnumerable<Offer>> EngageOffer(Offer offerDetails)
        {
            //Offer o = new Offer();
            //o.OfferId = offerDetails.OfferId;
            //o.EmployeeId = offerDetails.EmployeeId;
            var _engage = _repo.EngaOffer(offerDetails);
            if(_engage==null)
            {
                return NotFound("You are not authorized");
            }
            return Ok(_engage); ;
        }

        [HttpPost]
        [Route("LikeOffer")]
        public ActionResult<Offer> LikeOffer(Offer o)

        {
            var _like = _repo.LikeOffer(o);
            return Ok(_like);


            

        }


    }
}
