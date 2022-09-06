namespace AppDemo.Domain
{
    public class CustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public bool Add(CustomerDto customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var newCustomer = customer.ToCustomer();
            //Validation

            _customersRepository.Add(newCustomer);
            return true;

        }

        public List<CustomerDto> Get(string name, string email)
        {
            List<Customer> customers = _customersRepository.Get(name, email);
            return customers.Select(c => c.ToCustomerDto()).ToList();
        }
    }

    public interface ICustomersRepository
    {
        void Add(Customer customer);
        List<Customer> Get(string name, string email);
    }

    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
    }


    public static class CustomerExtension
    {
        public static Customer ToCustomer(this CustomerDto customerDto)
        {
            if (customerDto == null)
                return null;

            return new Customer(customerDto.Id, customerDto.Name, customerDto.Email)
            {
                Phone = customerDto.Phone,
                Address = customerDto.Address,
            };
        }

        public static CustomerDto ToCustomerDto(this Customer customer)
        {
            if (customer == null)
                return null;

            return new CustomerDto
            {
                Id = customer.Id,
                Address = customer.Address,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone,
            };
        }
    }
}
