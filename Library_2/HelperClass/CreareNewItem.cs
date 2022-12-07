using InventoryExample.DataProvider;
using library_2.dataprovider;
using Library_2.DataProvider.DB;
using Library_2.Exceptions;
using Library_2.Models;
using Library_2.Services;

namespace Library_2.HelperClass
{
    public class CreareNewItem
    {
        ApplicationContext appContext = new ApplicationContext();
        public CreareNewItem()
        {
            ClassHelper.LoadAll();
        }
        public void NamberClass()
        {
            try
            {
                Console.WriteLine("Customer: 1");
                Console.WriteLine("Worker: 2");
                Console.WriteLine("Rent: 3");
                Console.WriteLine("Athor: 4");
                Console.WriteLine("Book: 5");
                var namber = int.Parse(Console.ReadLine());
                NewItems(namber);
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CustomException("You must insert Int value! 1 to 5");
            }
        }

        public void NewItems(int namder)
        {
            switch (namder)
            {
                case 1:
                    CustomerDeleteCreate();
                    break;
                case 2:
                    WorkerDeleteCreate();
                    break;
                case 3:
                    RentDeleteCreateUpdate();
                    break;
                case 4:
                    NewAuthor();
                    break;
                case 5:
                    BookDeleteCreate();
                    break;
                default:
                    break;
            }
        }

        public void CustomerDeleteCreate()
        {
            try
            {
                var customerServise = new CustomerServise(new DataBaeProvider<Customer>(appContext.Customers));
                Console.WriteLine("1.Create, 2.Delete");
                var namber = int.Parse(Console.ReadLine());
                if (namber == 1)
                {
                    Console.WriteLine("NewCustomer");
                    var id = appContext.Customers.Max(c => c.Id);
                    Console.Write("Name: ");
                    var name = Console.ReadLine().ToLower();
                    Console.Write("Address: ");
                    var address = Console.ReadLine().ToLower();
                    Console.Write("Phone: ");
                    var Phone = Console.ReadLine().ToLower();

                    var customer = new Customer()
                    {
                        Id = ++id,
                        FillName = name,
                        Address = address,
                        Phone = Phone
                    };
                    customerServise.Add(customer);
                    appContext.SaveChanges();
                }
                else if (namber == 2)
                {
                    Console.Write("Customer name to delete: ");
                    var name = Console.ReadLine().ToLower();
                    if (name == null)
                        throw new CustomException("Customer name not null here!");
                    var customer = ClassHelper.customers.FirstOrDefault(c => c.FillName.ToLower() == name);
                    customerServise.Delete(customer);
                    appContext.SaveChanges();
                }
                else
                    throw new CustomException("Namber is not > 2! Insert 1 or 2!");
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new CustomException("Craete and Delete are not nul here");
            }
        }

        public void WorkerDeleteCreate()
        {
            try
            {
                var workerServise = new WorkerService(new DataBaeProvider<Worker>(appContext.Workers));
                Console.WriteLine("1.Create, 2.Delete");
                var namber = int.Parse(Console.ReadLine());
                if (namber == 1)
                {
                    Console.WriteLine("NewWorker");
                    var id = ClassHelper.workers.Last().Id;
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Address: ");
                    var address = Console.ReadLine();
                    Console.Write("Phone: ");
                    var Phone = Console.ReadLine();
                    var worker = new Worker()
                    {
                        Id = ++id,
                        FillName = name,
                        Address = address,
                        Phone = Phone
                    };
                    workerServise.Add(worker);
                }
                else if (namber == 2)
                {
                    Console.Write("Worker name to delete: ");
                    var name = Console.ReadLine().ToLower();
                    if (name == null)
                        throw new CustomException("Worker is not null here!");
                    var worker = ClassHelper.workers.FirstOrDefault(c => c.FillName.ToLower() == name);
                    workerServise.Delete(worker);
                }
                else
                    throw new CustomException("Namber is not > 2! Insert 1 or 2!");

            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new CustomException("Craete and Delete are not nul here!");
            }
        }

        public void RentDeleteCreateUpdate()
        {
            try
            {
                var rentService = new RentService(new DataBaeProvider<Rent>(appContext.Rents));
                Console.WriteLine("1.Create, 2.Delete, 3.Updata");
                var namber = int.Parse(Console.ReadLine());
                if (namber == 1)
                {
                    Console.WriteLine("NewRent");
                    var id = ClassHelper.rents.Last()?.Id ?? 0;
                    Console.Write("NameBook: ");
                    var nameBook = Console.ReadLine().ToLower();
                    Console.Write("NameCustomer: ");

                    var nameCustomer = Console.ReadLine().ToLower();
                    Console.Write("NameWorker: ");
                    var nameWorker = Console.ReadLine().ToLower();
                    Console.Write("Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    var rent = new Rent();

                    var book = ClassHelper.books.FirstOrDefault(b => b.Name.ToLower() == nameBook);
                    if (book == null)
                        ClearConsole("In khel Book nest!");

                    var customer = ClassHelper.customers.FirstOrDefault(c => c.FillName.ToLower() == nameCustomer);
                    if (customer == null)
                        ClearConsole("In khel Cusromer nest!");

                    var worker = ClassHelper.workers.FirstOrDefault(w => w.FillName.ToLower() == nameWorker);
                    if (worker == null)
                        ClearConsole("In khel Worker nest!");

                    rent.Id = ++id;
                    rent.Book = book;
                    rent.Worker = worker;
                    rent.Customer = customer;
                    rent.Quantity = quantity;

                    foreach (var item in ClassHelper.books)
                    {
                        if (item.Name == book.Name)
                        {
                            if (item.Quantity - quantity > 0)
                                item.Quantity -= quantity;
                            else
                                ClearConsole($"Quantity book: {item.Quantity}");
                            break;
                        }
                    }

                    // var rentFiltir = DataProvider.rents.FirstOrDefault(c => c.Customer.FillName.ToLower() == //nameCustomer && c.Book.Name.ToLower() == nameBook);
                    //if (rentFiltir != null)
                    //{
                    //    rentFiltir.Quantity += quantity;
                    //    return;
                    //}
                    rentService.Add(rent);
                }
                else if (namber == 2)
                {
                    Console.Write("Name Customer to delete: ");
                    var nameCustomer = Console.ReadLine().ToLower();
                    Console.Write("Name Book to delete: ");
                    var nameBook = Console.ReadLine().ToLower();
                    Console.Write("Quantity Book to delete: ");
                    var rent = ClassHelper.rents.FirstOrDefault(c => c.Customer.FillName.ToLower() == nameCustomer && c.Book.Name.ToLower() == nameBook);
                    rentService.DeleteBook(rent);
                }
                else if (namber == 3)
                {
                    //Console.Write("Name Customer to updata: ");
                    //var nameCustomer = Console.ReadLine().ToLower();
                    //Console.Write("Name Book to updata: ");
                    //var nameBook = Console.ReadLine().ToLower();
                    //Console.Write("Quantity: ");
                    //var quantity = int.Parse(Console.ReadLine());
                    //var rent = DataProvider.rents.FirstOrDefault(c => c.Customer.FillName.ToLower() == nameCustomer && c.Book.Name.ToLower() == nameBook);
                    //rent.Quantity = quantity;
                    //rentService.Update(rent);
                }
                else
                    throw new CustomException("Namber is not big 3! Insert 1 or 2 or 3! ");
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CustomException("Craete and Delete are not nul here!");
            }
        }

        public void BookDeleteCreate()
        {
            try
            {
                var bookService = new BookService(new JsonDataProvider<Book>(ClassHelper.books));
                Console.WriteLine("1.Create, 2.Delete");
                var namber = int.Parse(Console.ReadLine());
                if (namber == 1)
                {
                    Console.WriteLine("NewBook");
                    var id = ClassHelper.books.LastOrDefault().Id;
                    Console.Write("Name: ");
                    var name = Console.ReadLine().ToLower();
                    Console.Write("Author: ");
                    var authorName = Console.ReadLine().ToLower();
                    Console.Write("Categoriy: ");
                    var categoritName = Console.ReadLine().ToLower();
                    Console.Write("Quantity: ");
                    var quantitiy = int.Parse(Console.ReadLine());


                    Console.Write("NamberOfPage: ");
                    var namberOfPage = int.Parse(Console.ReadLine());

                    var author = ClassHelper.authors.FirstOrDefault(a => a.Name.ToLower() == authorName);
                    if (author == null)
                        throw new CustomException($"This author is not in list Authors");

                    var categoriy = ClassHelper.categoriys.FirstOrDefault(c => c.Name.ToLower() == categoritName);
                    if (author == null)
                        throw new CustomException($"This categoriy is not in list Categoriy! Ilmi and Badei");

                    var book = new Book()
                    {
                        Id = ++id,
                        Name = name,
                        Categoriy = categoriy,
                        Author = author,
                        Quantity = quantitiy,
                        NamberOfPage = namberOfPage,
                    };
                    bookService.Add(book);
                }
                else if (namber == 2)
                {
                    Console.Write("Book name to delete: ");
                    var name = Console.ReadLine().ToLower();
                    var book = ClassHelper.books.FirstOrDefault(c => c.Name.ToLower() == name);
                    bookService.Delete(book);
                }
                else
                    throw new CustomException("Namber is not big 2! Insert 1 or 2!");
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CustomException("Craete and Delete are not nul here");
            }

        }

        public void NewAuthor()
        {
            Console.WriteLine("NewAuthor");
            var id = ClassHelper.authors.LastOrDefault().Id;
            Console.Write("Name: ");
            var name = Console.ReadLine();
            var author = new Author()
            {
                Id = id,
                Name = name
            };
            ClassHelper.authors.Add(author);
        }
        public void ClearConsole(string name)
        {
            Console.WriteLine(name);
            Console.ReadLine();
            Console.Clear();
        }
    }


    public static class Test
    {
        public static int test { get; set; }
    }


}
