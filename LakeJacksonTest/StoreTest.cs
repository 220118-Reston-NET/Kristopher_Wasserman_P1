using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{
    public class StoreTest
    {
        [Fact]
        public void ShouldTestStoreName()
        {
            StoreModel sm = new StoreModel();
            string validName = "Bib Store";
            

            //Act
            sm.StoreName = validName;
            
            
            //Assert
            Assert.NotNull(sm.StoreName);
            Assert.Equal(validName, sm.StoreName);
        }
        [Fact]
        public void ShouldTestStoreAddress()
        {
            StoreModel sm = new StoreModel();
            string validName = "123 bib st";
        
            // When
            sm.StoreAddress = validName;
            // Then
            Assert.NotNull(sm.StoreAddress);
            Assert.Equal(validName,sm.StoreAddress);
        }
        
        
        [Fact]
        public void ShouldTestProductName()
        {
           StoreModel sm = new StoreModel();
            string validName = "Bib shorts";
            

            //Act
            sm.StoreName = validName;
            
            
            //Assert
            Assert.NotNull(sm.StoreName);
            Assert.Equal(validName, sm.StoreName);
        }
    }
}