using CleanArchitecture.Application.Queries.Products.GetProductById;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Interfaces.Repository;
using Newtonsoft.Json;
using Telerik.JustMock;

namespace CleanArchitecture.Test.QueriesTest.Product;

[TestClass]
public class GetProductByIdTest
{
    public TestContext? TestContext { get; set; }

    [TestMethod]
    public async Task GivenGetProductByIdQueryHandler_WhenHandleCalled_ThenReturnProduct()
    {
        // Arrange
        var products = new List<Domain.Entities.Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 100
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 200
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Price = 300
            }
        };

        var mockRepository = Mock.Create<IProductRepository>();
        Mock.Arrange(() => mockRepository.GetByIdAsync(Arg.IsAny<Guid>()))
            .Returns(Task.FromResult(products[0]));

        var handler = new GetProductByIdQueryHandler(mockRepository);
        var query = new GetProductByIdQuery(products[0].Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);
        // Assert
        Assert.IsNotNull(result, "Result should not be null");
        Assert.AreEqual(products[0].Id, result.Data.Id);
        Assert.AreEqual(products[0].Name, result.Data.Name);
        Assert.AreEqual(products[0].Price, result.Data.Price);

        var resultJson = JsonConvert.SerializeObject(result);
        TestContext?.WriteLine(resultJson);
    }
}