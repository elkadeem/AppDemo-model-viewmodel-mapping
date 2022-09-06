using AppDemo.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.Xml;

namespace AppDemo.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomersService customersService;

        public string Name { get; set; }

        public string Email { get; set; }
        public List<CustomerDto> Customers { get; set; }

        public IndexModel(IMapper mapper)
        {            
            this.customersService = new CustomersService(new TestRepo(), mapper);
        }

        public void OnGet()
        {
            Customers = customersService.Get(Name, Email);
        }
    }

    public class TestRepo : ICustomersRepository
    {
       private static List<Customer> cusotmers = new List<Customer> {
                new Customer(Guid.NewGuid(), "Wael", "mail@mail.com"),
                new Customer(Guid.NewGuid(), "Wael2", "mail2@mail.com"),
            };
    public TestRepo()
        {

        }
        public void Add(Customer customer)
        {
            cusotmers.Add(customer);
        }

        public List<Customer> Get(string name, string email)
        {
            return cusotmers;
        }
    }
}
