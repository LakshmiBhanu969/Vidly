using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            
        }
        // Get api/customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers.Include(c=>c.MembershipType);
            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customersDtos = customersQuery.ToList().Select(Mapper.Map<Customer,CustomerDto>);

            return Ok(customersDtos);
        }

        
        // Get api/customers/1
        public CustomerDto GetCustomer(int id)
        {
             
            var customerDtos = _context.Customers.SingleOrDefault(c=>c.Id == id);

            if (customerDtos == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return Mapper.Map<Customer,CustomerDto>(customerDtos);
        }

        // Post api/customers
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return customerDto;
        }

        // PUT api/Customers/1
        [System.Web.Mvc.HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto,customerInDb);

            _context.SaveChanges();
        }

        [System.Web.Mvc.HttpDelete]
        public void DeleteCustomer(int id)
        {
            
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
