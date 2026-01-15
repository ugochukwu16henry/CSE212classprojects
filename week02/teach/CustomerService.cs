/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{

    public static void Run()
    {

        // Test 1: Invalid max size defaults to 10
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        Console.WriteLine("=================");

        // Test 2: Queue overflow check
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(2);
        cs2.AddNewCustomer("Henry", "A01", "Login issue");
        cs2.AddNewCustomer("Sarah", "A02", "Payment issue");
        cs2.AddNewCustomer("John", "A03", "Network issue"); // should fail
        Console.WriteLine(cs2);
        Console.WriteLine("=================");

        // Test 3: Serve customers FIFO
        Console.WriteLine("Test 3");
        cs2.ServeCustomer(); // Henry
        cs2.ServeCustomer(); // Sarah
        cs2.ServeCustomer(); // error
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId}) : {Problem}";
        }
    }

    /// <summary>
    /// Enqueue a new customer
    /// </summary>
    private void AddNewCustomer(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue and serve next customer
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " +
               string.Join(", ", _queue) + "]";
    }
}
