﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Controllers.Models;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();

        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(m =>newRentalDto.MovieIds.Contains(m.Id)).ToList();

            

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Today
                };
                _context.Rental.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateRentalsReturned(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();



            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Today
                };
                _context.Rental.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}