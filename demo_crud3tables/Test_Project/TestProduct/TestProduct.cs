using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project.TestProduct
{
    internal class TestProduct
    {
        private Mock<IRepository> mockRepository;
        private YourClass testProductInstance;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IRepository>();
            testProductInstance = new YourClass(mockRepository.Object);
        }

        [Test]
        public async Task Insert_ValidProductAndFile_SuccessResult()
        {
            // Arrange
            var product = new Product
            {
                CategoryID = 1,  // Assuming a valid CategoryID
                SupplierID = 1, // Assuming a valid SupplierID
                // Other product properties...
            };

            var fileMock = new Mock<IFormFile>();

            // Assume FindAsync always returns a valid category and supplier for simplicity in this test
            mockRepository.Setup(r => r.Categories.FindAsync(It.IsAny<int>())).ReturnsAsync(new Category());
            mockRepository.Setup(r => r.Suppliers.FindAsync(It.IsAny<int>())).ReturnsAsync(new Supplier());

            // Act
            var result = await testProductInstance.Insert(product, fileMock.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("Success", result.Message);
            Assert.IsNotNull(result.Data);
            // Add more assertions if needed based on your specific requirements
        }

        [Test]
        public async Task Insert_InvalidCategoryID_BadRequestResult()
        {
            // Arrange
            var product = new Product
            {
                CategoryID = 999,  // Assuming an invalid CategoryID for this test
                // Other product properties...
            };

            var fileMock = new Mock<IFormFile>();

            // Assume FindAsync always returns null for the category to simulate an invalid CategoryID
            mockRepository.Setup(r => r.Categories.FindAsync(It.IsAny<int>())).ReturnsAsync(null);

            // Act
            var result = await testProductInstance.Insert(product, fileMock.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("CategoryID does not exist", result.Message);
            Assert.IsNull(result.Data);
        }
    }
}
