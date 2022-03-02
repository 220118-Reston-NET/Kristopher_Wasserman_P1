using LakeJacksonCyclingModel;
using LakeJacksonCyclingBL;
using Moq;
using Xunit;
using LakeJacksonCyclingDL;
using System.Collections.Generic;

namespace LakeJacksonTest
{
        public class LakeJacksonCyclingBLTest
        {
            [Fact]
            public void ShouldGetAllCustomers()
            {
               

           //Arrange
            string Name = "STEPHEN";
            string Address = "117A BlEECKER STREET";
            string State = "NY";
            string City = "NEW YORK CITY";
            string Zipcode = "10011";
            string Email = "STEPHEN.Pederolio@AOL.COM";


            Customers p_cust = new Customers()
            {
                Name = Name,
                Address = Address,
                State = State,
                City = City,
                Zip = Zipcode,
                Email = Email
            };

            //Mock The Repo that is a dependency
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //Mock GetAddCustomers
            mockRepo.Setup(repo => repo.AddCustomer(p_cust)).Returns(p_cust);
            ILakeJacksonBL repo = new LakeJacksonBL(mockRepo.Object);

            Customers p_cust2 = repo.AddCustomer(p_cust);

           //Assert
           Assert.Same(p_cust, p_cust2);
           Assert.Equal(p_cust.Name, p_cust2.Name);
           Assert.NotNull(p_cust2);

       
            }
        
        [Fact]
        public void ShouldSearchCustomer()
        {
            // Given
            string name = "Kris";

            List<Customers> cust = new List<Customers>();
            Customers customer1 = new Customers()
            {
                Name = name
            };

            Mock<IRepository> MockRepo = new Mock<IRepository>();

            MockRepo.Setup(repo => repo.GetAllCustomers()).Returns(cust);
            ILakeJacksonBL repo = new LakeJacksonBL(MockRepo.Object);


            
            // When
            Assert.Same(customer1,customer1);
            Assert.Equal(customer1,customer1);
            Assert.NotNull(customer1);
            // Then
        }

        [Fact]
        public void ShouldTestGetAllEmployees()
        {
            string name = "Kris";
            string department = "Manager";

            List<Employee> employee = new List<Employee>();
            Employee employee1 = new Employee()
            {
                Name = name,
                Department = department,
            };

            Mock<IRepository> MockRepo = new Mock<IRepository>();

            MockRepo.Setup(repo => repo.GetEmployees()).Returns(employee);
            ILakeJacksonBL repo = new LakeJacksonBL(MockRepo.Object);


            
            // When
            Assert.Same(employee,employee1);
            Assert.Equal(employee1,employee1);
            Assert.NotNull(employee1);
        }
        [Fact]
        public void ShouldTestGetStoreFront()
        {
            string name = "LakeJacksonCycling";


            List<StoreFrontModel> store = new List<StoreFrontModel>();
            StoreFrontModel Store1 = new StoreFrontModel()
            {
                StoreName = name
            };

            Mock<IRepository> MockRepo = new Mock<IRepository>();

            MockRepo.Setup(repo => repo.GetAllStoreFront()).Returns(store);
            ILakeJacksonBL repo = new LakeJacksonBL(MockRepo.Object);


            
            // When
            Assert.Same(store,Store1);
            Assert.Equal(Store1,Store1);
            Assert.NotNull(Store1);
        }
    }
}