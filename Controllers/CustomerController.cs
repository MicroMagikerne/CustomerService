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
     _logger.LogInformation("Metode GetCustomerByID called at {DT}",
        DateTime.UtcNow.ToLongTimeString());

    return _customers.Where(c => c.Id == customerId).First();
}

[HttpGet("GetAllCustomers")]
public List<Customer> GetAll()
{
     _logger.LogInformation("Metode GetAllCustomers called at {DT}",
    DateTime.UtcNow.ToLongTimeString());

    return _customers;
}
[HttpPost("AddCustomer")]
public IActionResult AddCustomer(Customer customer)
{
    
    // Log, at metoden er blevet kaldt
    _logger.LogInformation("Metode AddCustomer called at {DT}", DateTime.UtcNow.ToLongTimeString());

    // Tjek, om der allerede eksisterer en kunde i listen med samme ID som den kunde, der forsøges at blive tilføjet
    if (_customers.Any(c => c.Id == customer.Id))
    {
        // Log, at kunden er blevet tilføjet
        _logger.LogInformation("Customer with ID {ID} added to the list of customers", customer.Id);

        // Hvis en kunde med samme ID allerede eksisterer, returner en HTTP-statuskode 409 Conflict med en fejlbesked
        return StatusCode(409, $"Customer with ID {customer.Id} already exists.");
    }
    else
    {
        // Hvis kunden ikke eksisterer i listen, tilføj kunden til listen
        _customers.Add(customer);

        // Log, at kunden er blevet tilføjet
        _logger.LogInformation("Customer with ID {ID} added to the list of customers", customer.Id);

        // Returner en HTTP-statuskode 200 OK for at indikere, at kunden er blevet tilføjet
        return Ok();
    }
}
}



