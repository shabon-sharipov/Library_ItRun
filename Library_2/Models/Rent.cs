using Library_2.HelperClass;
using Newtonsoft.Json;

namespace Library_2.Models;

public class Rent : EntityBase
{
    public int BookId { get; private set; }

    private Book _book;
    [JsonIgnore]
    public Book Book
    {
        get
        {
            if (_book == null)
            {
                foreach (var book in ClassHelper.books)
                {
                    if (book.Id == BookId)
                        _book = book;
                }
            }
            return _book;
        }
        set
        {
            _book = value;
            BookId = _book?.Id ?? 0;
        }
    }

    public int WorkerId { get; private set; }

    private Worker _worker;
    [JsonIgnore]
    public Worker Worker
    {
        get
        {
            if (_worker == null)
            {
                foreach (var worker in ClassHelper.workers)
                {
                    if (worker.Id == WorkerId)
                        _worker = worker;
                }
            }
            return _worker;
        }
        set
        {
            _worker = value;
            WorkerId = _worker?.Id ?? 0;
        }
    }

    public int CustomerId { get; private set; }
    private Customer _customer;
    [JsonIgnore]
    public Customer Customer
    {
        get
        {
            if (_customer == null)
            {
                foreach (var customer in ClassHelper.customers)
                {
                    if (customer.Id == CustomerId)
                        _customer = customer;
                }
            }
            return _customer;
        }
        set
        {
            _customer = value;
            CustomerId = _customer?.Id ?? 0;
        }
    }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"Book: {Book.Name}, Worker: {Worker.FillName}, Customer: {Customer.FillName}, Quantity: {Quantity}";
    }
}
