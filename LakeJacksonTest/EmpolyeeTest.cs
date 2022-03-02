using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJackson
{
    public class EmployeeTest
    {
        
        [Fact]
        public void ShouldBeName()
        {
            // Given
            Employee Name = new Employee();
            string name = "kris";
        
            // When
            Name.Name = name;
            // Then
            Assert.NotNull(Name.Name);
            Assert.Equal(name, Name.Name);
             
        }
        [Fact]
        /// <summary>
        /// This will test to see if there is a department validation in Employee Model
        /// </summary>
        public void ShouldGetDepartmentName()
        {
            // Given
            Employee department = new Employee();

            string dnametest = "Manager";
        
            // When
            department.Department = dnametest;
            // Then
            Assert.NotNull(department.Department);
            Assert.Equal(dnametest,department.Department);
        }
        /// <summary>
        /// tests the name of the employee in the Employee Model
        /// </summary>
        [Fact]
        public void ShouldTestEmployeeName()
        {
            Employee cName = new Employee();
            string validName = "Kristopher";
            

            //Act
            cName.Name = validName;
            
            
            //Assert
            Assert.NotNull(cName.Name);
            Assert.Equal(validName, cName.Name);
             
        }
    }
}