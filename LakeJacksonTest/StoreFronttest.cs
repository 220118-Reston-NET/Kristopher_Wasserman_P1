using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{
    public class StoreFronttest
    {
        [Fact]
        public void ShouldGetStoreTest()
        {
            StoreFrontModel sf = new StoreFrontModel();
            string validName = "Bib Store";
            

            //Act
            sf.StoreName = validName;
            
            
            //Assert
            Assert.NotNull(sf.StoreName);
            Assert.Equal(validName, sf.StoreName);
        }
    }
}