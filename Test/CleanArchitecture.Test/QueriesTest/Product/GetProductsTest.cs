﻿using CleanArchitecture.Application.Interfaces.Repository;
using CleanArchitecture.Application.Queries.Products.GetProducts;
using Newtonsoft.Json;
using Telerik.JustMock;

namespace CleanArchitecture.Test.QueriesTest.Product;

[TestClass]
public class GetProductsTest
{
    public TestContext? TestContext { get; set; }

    [TestMethod]
    public async Task GivenGetProductsQueryHandler_WhenHandleCalled_ThenReturnProducts()
    {
        // Arrange
        var products = new List<Domain.Entities.Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 21.1f
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 10.2f
            }
        };

        var mockRepository = Mock.Create<IProductRepository>();
        Mock.Arrange(() => mockRepository.GetsAsync())
            .Returns(Task.FromResult<IEnumerable<Domain.Entities.Product>>(products));

        var handler = new GetProductsQueryHandler(mockRepository);
        var query = new GetProductsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.IsNotNull(result, "Result should not be null");
        var expectedProductNames = new List<string> { "Product 1", "Product 2" };
        var enumerable = result.Data as Domain.Entities.Product[] ?? result.Data.ToArray();
        foreach (var product in enumerable)
            Assert.IsTrue(expectedProductNames.Contains(product.Name),
                $"Product name '{product.Name}' should be in the expected list");
        Assert.AreEqual(2, enumerable.Count());
        var resultJson = JsonConvert.SerializeObject(result);
        TestContext?.WriteLine(resultJson);
    }
}