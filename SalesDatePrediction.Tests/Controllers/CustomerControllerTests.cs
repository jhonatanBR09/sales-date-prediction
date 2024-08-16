using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.Controllers;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;
using SalesDatePrediction.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SalesDatePrediction.Tests.Controllers
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _controller;
        private readonly Mock<ICustomerService> _mockCustomerService;

        public CustomerControllerTests()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _controller = new CustomerController(_mockCustomerService.Object);
        }

        [Fact]
        public async Task GetCustomers_ReturnsOkResult_WithListOfCustomers()
        {
            
            var customers = new List<CustomerDto>
            {
                new CustomerDto { CustomerId = 1, CompanyName = "Company A", ContactName = "John Doe", ContactTitle = "Manager", Address = "123 Street", City = "City A", Country = "Country A", Phone = "123-456-7890" },
                new CustomerDto { CustomerId = 2, CompanyName = "Company B", ContactName = "Jane Smith", ContactTitle = "Director", Address = "456 Avenue", City = "City B", Country = "Country B", Phone = "987-654-3210" }
            };

            _mockCustomerService.Setup(service => service.GetCustomersAsync())
                .ReturnsAsync(customers);
            
            var result = await _controller.GetCustomers();
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnCustomers = Assert.IsType<List<CustomerDto>>(okResult.Value);
            Assert.Equal(2, returnCustomers.Count);
        }

        [Fact]
        public async Task GetCustomerById_ReturnsNotFoundResult_WhenCustomerDoesNotExist()
        {            
            int testId = 1;
            _mockCustomerService.Setup(service => service.GetCustomerByIdAsync(testId))
                .ReturnsAsync((CustomerDto)null);
         
            var result = await _controller.GetCustomerById(testId);
         
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetCustomerById_ReturnsOkResult_WithCustomer()
        {            
            int testId = 1;
            var customer = new CustomerDto
            {
                CustomerId = testId,
                CompanyName = "Company A",
                ContactName = "John Doe",
                ContactTitle = "Manager",
                Address = "123 Street",
                City = "City A",
                Country = "Country A",
                Phone = "123-456-7890"
            };

            _mockCustomerService.Setup(service => service.GetCustomerByIdAsync(testId))
                .ReturnsAsync(customer);
            
            var result = await _controller.GetCustomerById(testId);
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnCustomer = Assert.IsType<CustomerDto>(okResult.Value);
            Assert.Equal(testId, returnCustomer.CustomerId);
        }

        [Fact]
        public async Task GetCustomersWithOrderDates_ReturnsOkResult_WithListOfCustomersWithOrderDates()
        {            
            var customersWithOrderDates = new List<CustomerWithOrderDatesDto>
            {
                new CustomerWithOrderDatesDto
                {
                    customerId = 1,
                    CustomerName = "Company A",
                    LastOrderDate = DateTime.Now,
                    NextPredictedOrder = DateTime.Now.AddDays(30)
                },
                new CustomerWithOrderDatesDto
                {
                    customerId = 2,
                    CustomerName = "Company B",
                    LastOrderDate = DateTime.Now,
                    NextPredictedOrder = DateTime.Now.AddDays(60)
                }
            };

            _mockCustomerService.Setup(service => service.GetCustomersWithOrderDatesAsync())
                .ReturnsAsync(customersWithOrderDates);
            
            var result = await _controller.GetCustomersWithOrderDates();
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnCustomers = Assert.IsType<List<CustomerWithOrderDatesDto>>(okResult.Value);
            Assert.Equal(2, returnCustomers.Count);
        }
    }
}
