using AppDemo.Domain;
using AutoMapper;
using Moq;

namespace AppDemoTest
{
    public class CustomersServiceUnitTest
    {
        [Fact]
        public void Add_Customer_Will_Throw_Exception_When_Customer_Is_Null ()
        {
            var repoSub = new Mock<ICustomersRepository>();
            var mapperSub = new Mock<IMapper>();
            CustomersService customersService = new CustomersService(repoSub.Object, mapperSub.Object);
            Assert.Throws<ArgumentNullException>(() => customersService.Add(null));

        }

        [Fact]
        public void Add_Customer_With_Valid_Data()
        {
            //AAA
            //Arrange
            var repoSub = new Mock<ICustomersRepository>();
            var mapperSub = new Mock<IMapper>();
            CustomersService customersService = new CustomersService(repoSub.Object, mapperSub.Object);
            CustomerDto customerDto = new CustomerDto {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "ee@dd.com"
            };
            //Act
            var result = customersService.Add(customerDto);
            //Assert
            Assert.True(result);
            repoSub.Verify(c => c.Add(It.IsAny<Customer>()), Times.Once);
        }
    }

    
}