public class CustomerService
{
    private readonly IGenericRepository<Customer> _customerRepository;

    public CustomerService(IGenericRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }

    public Customer GetCustomerById(int id)
    {
        return _customerRepository.GetById(id);
    }

    public void AddCustomer(Customer customer)
    {
        _customerRepository.Insert(customer);
        _customerRepository.Save();
    }

    public void UpdateCustomer(Customer customer)
    {
        _customerRepository.Update(customer);
        _customerRepository.Save();
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(id);
        _customerRepository.Save();
    }
}
