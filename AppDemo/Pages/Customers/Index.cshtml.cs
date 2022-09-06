using AppDemo.Domain;
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

        public IndexModel()
        {            
            this.customersService = new CustomersService(new TestRepo());
        }

        public void OnGet()
        {
            Customers = customersService.Get(Name, Email);
        }
    }

    public class TestRepo : ICustomersRepository
    {
        public void Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get(string name, string email)
        {
            return new List<Customer> {
                new Customer(Guid.NewGuid(), "Wael", "mail@mail.com"),
                new Customer(Guid.NewGuid(), "Wael2", "mail2@mail.com"),
            };
        }
    }
}
