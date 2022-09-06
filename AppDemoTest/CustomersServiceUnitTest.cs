using AppDemo.Domain;

namespace AppDemoTest
{
    public class CustomersServiceUnitTest
    {
        [Fact]
        public void Add_Customer_Will_Throw_Exception_When_Customer_Is_Null ()
        {
            CustomersService customersService = new CustomersService(new CustomersFakeRepo());
            Assert.Throws<ArgumentNullException>(() => customersService.Add(null));

        }

        [Fact]
        public void Add_Customer_With_Valid_Data()
        {
            //AAA
            //Arrange
            CustomersService customersService = new CustomersService(new CustomersFakeRepo());
            CustomerDto customerDto = new CustomerDto {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "ee@dd.com"
            };
            //Act
            var result = customersService.Add(customerDto);
            //Assert
            Assert.True(result);
        }
    }

    public class CustomersFakeRepo : ICustomersRepository
    {
        public void Add(Customer customer)
        {
            
        }

        public List<Customer> Get(string name, string email)
        {
            throw new NotImplementedException();
        }
    }
}