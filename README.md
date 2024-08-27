# BankSystemIntegration

## Overview

This project integrates a bank system with Excel, allowing users to export transaction and customer data from the bank's database to Excel files. The project is implemented using C# for the backend data access and Excel file generation, and VBA for the Excel user interface.

## Technologies Used

- **C#**: For data access and Excel file generation.
- **Entity Framework**: For database interactions.
- **EPPlus**: For creating Excel files.
- **VBA**: For the Excel user interface.

## Project Structure

```
/BankSystemIntegration
    /src
        /CSharp
            BankIntegration.sln
            BankIntegration/
                BankIntegration.csproj
                Program.cs
                DataAccessLayer/
                    BankDbContext.cs
                    TransactionRepository.cs
                    CustomerRepository.cs
                ExcelIntegration/
                    ExcelService.cs
        /VBA
            BankIntegration.xlsm
            Module1.bas
        /docs
            README.md
            installation.md
            usage.md
        /data
            sample_data.xlsx
        /tests
            BankIntegration.Tests.csproj
            TransactionTests.cs
            CustomerTests.cs
        /bin
            BankIntegration.exe
```

## Prerequisites

- **Visual Studio**: For developing and running the C# application.
- **Excel**: For running the VBA scripts and using the Excel workbook.
- **SQL Server**: For the bank's database.

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/BankSystemIntegration.git
   ```

2. Open the `BankIntegration.sln` file in Visual Studio.

3. Configure the database connection string in the `App.config` file:
   ```xml
   <connectionStrings>
     <add name="BankDbConnection" connectionString="Data Source=YourERPServer;Initial Catalog=YourERPDatabase;Integrated Security=True" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

4. Build the solution to ensure all dependencies are restored.

## Usage

1. Run the C# application by executing the `BankIntegration.exe` file. This will generate `Transactions.xlsx` and `Customers.xlsx` files in the output directory.

2. Open the `BankIntegration.xlsm` file in Excel.

3. Run the `LoadBankData` macro to load the transaction and customer data into the Excel workbook.

## Testing

To run the unit tests, open the `BankIntegration.Tests.csproj` in Visual Studio and run the tests using the Test Explorer.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

This `README.md` file provides a comprehensive overview of the project, including setup instructions, usage guidelines, and information about testing and contributing.
