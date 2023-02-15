using Microsoft.AspNetCore.Mvc;
using CustomerService;
using System.Linq; 
using System.Collections.Generic;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
   private static List<Customer> _customers = new List<Customer>() {
    new Customer() {
        Id = 1,
        Name = "International Bicycles A/S",
        Address1 = "Nydamsvej 8",
        Address2 = null,
        PostalCode = 8362,
        City = "Hørning",
        TaxNumber = "DK-75627732",
        ContactName = "Dennis Jørgensen"
},

 new Customer() {
        Id = 2,
        Name = "ABC Corporation A/S",
        Address1 = "Nydamsvej 10",
        Address2 = null,
        PostalCode = 8362,
        City = "Hørning",
        TaxNumber = "DK-75627732",
        ContactName = "Caroline Jensen"
},
new Customer() {
        Id = 3,
        Name = "XYZ Industries A/S",
        Address1 = "Nydamsvej 30",
        Address2 = null,
        PostalCode = 8362,
        City = "Hørning",
        TaxNumber = "DK-75627732",
        ContactName = "Mads Sørensen"
}

 };
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

   [HttpGet("GetCustomerById")]
public Customer Get(int customerId)
{
    return _customers.Where(c => c.Id == customerId).First();
}

[HttpGet("GetAllCustomers")]
public List<Customer> GetAll()
{
    return _customers;
}

[HttpPost("AddCustomer")]
public IActionResult AddCustomer([FromBody] Customer customer)
{
    if (customer == null)
    {
        return BadRequest();
    }

    _customers.Add(customer);
    return Ok();
}


}


