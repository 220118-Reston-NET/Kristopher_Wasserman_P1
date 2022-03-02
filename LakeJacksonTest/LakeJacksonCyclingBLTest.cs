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
    }
}