[TestFixture]
public class CustomerServiceTests
{
    private Mock<IGenericRepository<Customer>> _customerRepositoryMock;
    private CustomerService _customerService;

    [SetUp]
    public void Setup()
    {
        _customerRepositoryMock = new Mock<IGenericRepository<Customer>>();
        _customerService = new CustomerService(_customerRepositoryMock.Object);
    }

    [Test]
    public void GetAllCustomers_ShouldReturnCustomers()
    {
        // Arrange
        var customers = new List<Customer> { new Customer { Name = "John" } };
        _customerRepositoryMock.Setup(repo => repo.GetAll()).Returns(customers);

        // Act
        var result = _customerService.GetAllCustomers();

        // Assert
        Assert.AreEqual(1, result.Count());
    }
}
