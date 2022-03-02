using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{
    public class OrderTest
    {
        [Fact]
        public void ShouldTestProductName()
        {
             Orders oTest = new Orders();
            string validName = "Bib";
            

            //Act
            oTest.pName = validName;
            
            
            //Assert
            Assert.NotNull(oTest.pName);
            Assert.Equal(validName, oTest.pName);
             
        }
        [Fact]
        public void ShouldTestAddress()
        {
             Orders oaddress = new Orders();
            string validAddress = "123 this way ";
            

            //Act
            oaddress.pAddress = validAddress;
            
            
            //Assert
            Assert.NotNull(oaddress.pAddress);
            Assert.Equal(validAddress, oaddress.pAddress);
        }
        [Fact]
        public void ShouldTestStoreAddress()
        {
             Orders saddress = new Orders();
            string validAddress = "23 oyster blvd ";
            

            //Act
            saddress.StoreAddress = validAddress;
            
            
            //Assert
            Assert.NotNull(saddress.StoreAddress);
            Assert.Equal(validAddress, saddress.StoreAddress);
        }
        [Fact]
        public void QuantityTest()
        {
            // Given
            Orders quantityTest = new Orders();
            int validquantity = 2;
            // When
            quantityTest.Quantity = validquantity;
            // Then

            Assert.NotNull(quantityTest.Quantity);
            Assert.Equal(validquantity, quantityTest.Quantity);
        }
         
    }
}