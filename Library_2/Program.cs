using InventoryExample.DataProvider;
using Library_2.Abstractions.Services;
using library_2.dataprovider;
using Library_2.DataProvider.DB;
using Library_2.HelperClass;
using Library_2.Models;
using Library_2.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Library_2;

internal class Program
{
    static void Main(string[] args)
    {
        #region MyRegion
        //ClassHelper.LoadAll();
        //var creareNewItem = new CreareNewItem();
        //while (true)
        //{
        //    Console.Clear();
        //    try
        //    {
        //        creareNewItem.NamberClass();
        //        ClassHelper.Save();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        Console.ReadLine();
        //    }
        //}
        #endregion


        ApplicationContext db = new ApplicationContext();

        var d = db.Books.Include(c=>c.Author).FirstOrDefault();

        
    }

    #region MyRegion

    public static void GroupBy()
    {
        #region GroupByCustomer
        Console.WriteLine("GroupByCustomer");
        var groupCustomer = ClassHelper.customers.GroupBy(g => g.Address);

        foreach (var group in groupCustomer)
        {
            Console.WriteLine();
            Console.WriteLine($"    Group: {group.Key}");
            foreach (var item in group)
            {
                Console.WriteLine(item.FillName);
            }
        }
        Console.WriteLine();
        Console.WriteLine();
        #endregion

        //??
        #region GroupByBook
        Console.WriteLine("GroupByBook");
        var groupBook = ClassHelper.books.GroupBy(g => g.Categoriy);

        foreach (var item in groupBook)
        {
            Console.WriteLine();
            Console.WriteLine($"\t Category: {item.Key.Name}");
            foreach (var book in item)
            {
                Console.WriteLine(book);
            }
        }
        Console.WriteLine();
        Console.WriteLine();
        #endregion

        #region GroupByRent
        Console.WriteLine("GroupByRent");
        var groupRent = ClassHelper.rents.GroupBy(g => g.Book.Categoriy.Name);

        foreach (var group in groupRent)
        {
            Console.WriteLine();
            Console.WriteLine($"\t Category: {group.Key}");
            foreach (var item in group)
            {
                Console.WriteLine(item);
            }
        }
        #endregion
    }

    public static void Select()
    {
        #region Select Customer
        var selectCustomer = ClassHelper.customers.Select(c => c.FillName);
        foreach (var item in selectCustomer)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        #endregion

        #region Select Book
        var selectBook = ClassHelper.books.Where(b => b.Quantity > 20).GroupBy(b => b.Categoriy);

        foreach (var book in selectBook)
        {
            Console.WriteLine($"Category: {book.Key.Name}");
            foreach (var item in book)
            {
                Console.WriteLine(item);
            }

        }
        Console.WriteLine();
        #endregion

        #region SelectRent
        Console.WriteLine();
        Console.WriteLine("SelectRent");
        var rets = ClassHelper.rents.Where(c => c.Worker.FillName == "Shabon Sharipov");
        foreach (var item in rets)
        {
            Console.WriteLine(item);
        }
        #endregion
    }

    public static void OrderBy()
    {
        Console.WriteLine("\t OrderBy");
        #region OrderByCustomer
        Console.WriteLine();
        Console.WriteLine("OrderByCustomer");
        var filtirCustomer = ClassHelper.customers.OrderBy(c => c.FillName);
        foreach (var item in filtirCustomer)
        {
            Console.WriteLine(item);
        }
        #endregion
        //??//
        #region Reut
        Console.WriteLine();
        var rents = ClassHelper.rents;
        var filterWorkerRentBookCount = rents.Where(c => c.Customer.FillName == "Shabon Sharipov" && c.Quantity == 1);
        foreach (var item in filterWorkerRentBookCount)
        {
            Console.WriteLine(item);
        }
        #endregion
    }
    //??
    public static void Take()
    {
        #region CustomerTake
        Console.WriteLine("\t CustomerTake");
        var customers = ClassHelper.customers;
        Console.WriteLine("Take");
        var custonTake = customers.Take(3);
        foreach (var item in custonTake)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        Console.WriteLine("TakeLast");
        var custonTakeLas = customers.TakeLast(3);
        foreach (var item in custonTake)
        {
            Console.WriteLine(item);
        }
        #endregion
    }
    #endregion

}