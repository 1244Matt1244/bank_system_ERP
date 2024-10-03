---

# Bank System ERP

The **Bank System ERP** is a C# (.NET Framework) project that integrates a banking system with functionalities for managing customers and transactions, exporting data to Excel, and utilizing Excel VBA for enhanced user interaction. This project uses the **Entity Framework** for data access and incorporates the **Repository Pattern** for modularity and ease of maintenance.

## Features

- **Customer and Transaction Management**: Add, update, delete, and retrieve customer and transaction data.
- **Data Access Layer**: Uses **Entity Framework** for handling database operations.
- **Repository Pattern**: Separates data access logic from business logic.
- **Excel Integration**: Export customer data to Excel using **EPPlus**.
- **Excel VBA**: Macro-enabled workbook for user interaction.
- **Dependency Injection**: Implements **Unit of Work** for managing repositories.
- **Configurable via App.config**: Database connection strings and other settings are configurable through `App.config`.

## Project Structure

```plaintext
├── App.config
├── BankSystemContext.cs (Data Access Layer)
├── GenericRepository.cs (Generic Repository)
├── CustomerRepository.cs (Customer-Specific Repository)
├── TransactionRepository.cs (Transaction-Specific Repository)
├── UnitOfWork.cs (Unit of Work)
├── Customer.cs (Customer Entity Model)
├── Transaction.cs (Transaction Entity Model)
├── ExcelService.cs (Excel Integration using EPPlus)
├── Main Program.cs (Main Program for Customer & Transaction Management)
├── Excel VBA - Macro-Enabled Workbook.xlsm (Excel VBA for User Interface)
└── README.md (This File)
```

## Getting Started

### Prerequisites

To run this project, you will need:

- **Visual Studio 2019** or later
- **.NET Framework 4.7.2** or later
- **SQL Server** (local or remote)
- **EPPlus Library** for Excel integration
- **Entity Framework** for database interaction

### Setting Up the Project

1. **Clone the Repository**

   Clone the repository to your local machine:
   ```bash
   git clone https://github.com/1244Matt1244/bank_system_ERP.git
   ```

2. **Database Setup**

   Ensure you have a SQL Server database set up. Update the `App.config` file to reflect your database connection string:
   ```xml
   <connectionStrings>
     <add name="BankSystemContext"
          connectionString="Data Source=.;Initial Catalog=BankSystemDB;Integrated Security=True"
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

3. **Install Dependencies**

   Use NuGet Package Manager in Visual Studio to install the following packages:
   - **EntityFramework** (for ORM)
   - **EPPlus** (for Excel export)

4. **Update Database**

   Run the following commands in the **Package Manager Console** to apply migrations and update the database:
   ```bash
   Update-Database
   ```

### Running the Application

1. **Open the Solution in Visual Studio**.
   
2. **Build the Solution** by selecting `Build -> Build Solution`.

3. **Run the Program**:
   - In `Main Program.cs`, the system will:
     - Add customers and transactions to the database.
     - Fetch and display customer data.
     - Export customer data to an Excel file.
   
4. **Excel VBA Integration**:
   - Open the **Excel VBA - Macro-Enabled Workbook.xlsm** file.
   - The user can interact with the system through Excel, running macros like `ExportCustomers` to fetch data from the system.

### Example Usage

In the **Main Program**, you can see an example where the system adds a new customer and fetches all customers:

```csharp
using (var context = new BankSystemContext())
{
    using (var unitOfWork = new UnitOfWork(context))
    {
        var newCustomer = new Customer { Name = "John Doe", Email = "john.doe@example.com" };
        unitOfWork.CustomerRepository.Insert(newCustomer);
        unitOfWork.Save();

        var customers = unitOfWork.CustomerRepository.GetAll();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Id}: {customer.Name} ({customer.Email})");
        }
    }
}
```

### Excel Integration

The **ExcelService.cs** script allows you to export customer data to an Excel file. For example:

```csharp
var excelService = new ExcelService();
excelService.ExportCustomersToExcel(customers, "Customers.xlsx");
```

### Excel VBA

The **Excel VBA - Macro-Enabled Workbook** provides user interaction through buttons and macros. For example, the `ExportCustomers` macro fetches customer data and exports it to the workbook.

### Entity Framework

This project uses **Entity Framework** to manage the data access layer, connecting the `Customer` and `Transaction` models to the database. The `UnitOfWork` pattern ensures that changes across multiple repositories are saved in a single transaction.

## Logging

You can add logging functionality (e.g., using **NLog** or **Log4Net**) to track operations and errors. This is not included by default but can be added easily to extend the project.

## Testing

You can implement unit tests using **MSTest**, **NUnit**, or **xUnit**. This ensures that your business logic and repository operations work as expected.

### Example Unit Test

```csharp
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
        var customers = new List<Customer> { new Customer { Name = "John" } };
        _customerRepositoryMock.Setup(repo => repo.GetAll()).Returns(customers);

        var result = _customerService.GetAllCustomers();

        Assert.AreEqual(1, result.Count());
    }
}
```

## Contributing

Feel free to contribute to the project by submitting pull requests or reporting issues. Contributions are always welcome!

## License

This project is licensed under the MIT License.

---
