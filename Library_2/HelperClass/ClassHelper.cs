using JsonNet.ContractResolvers;
using Library_2.Models;
using Newtonsoft.Json;
using System.Collections;
namespace Library_2.HelperClass;

public static class ClassHelper
{
    const string BookDataFilePath = @"C:\\Users\\shabon\\source\\repos\\ItiRaun\\Library_2\\Library_2\\Data\\Book.json ";
    const string CategoriyFilePath = @"C:\\Users\\shabon\\source\\repos\\ItiRaun\\Library_2\\Library_2\\Data\\Categoriy.json";
    const string CustomerDataFilePath = @"C:\\Users\\shabon\\source\\repos\\ItiRaun\\Library_2\\Library_2\\Data\\Customer.json";
    const string AuthorsDataFilePath = @"C:\\Users\\shabon\\source\\repos\\ItiRaun\\Library_2\\Library_2\\Data\\Author.json";
    const string RentDataFilePath = @"C:\\Users\\shabon\\source\\repos\\ItiRaun\\Library_2\\Library_2\\Data\\Rent.json";
    const string WorkerDataFilePath = @"C:\\Users\\shabon\\source\\repos\\ItiRaun\\Library_2\\Library_2\\Data\\Worker.json";

    static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
    {
        ContractResolver = new PrivateSetterContractResolver()
    };

    public static List<Author> authors { get; private set; }
    public static List<Book> books { get; private set; }
    public static List<Customer> customers { get; private set; }
    public static List<Rent> rents { get; private set; }
    public static List<Categoriy> categoriys { get; private set; }
    public static List<Worker> workers { get; private set; }

    public static void Save()
    {
        SaveData(books, BookDataFilePath);
        SaveData(categoriys, CategoriyFilePath);
        SaveData(customers, CustomerDataFilePath);
        SaveData(rents, RentDataFilePath);
        SaveData(authors, AuthorsDataFilePath);
        SaveData(workers, WorkerDataFilePath);
    }
    static void SaveData(IEnumerable list, string filePath)
    {
        var textData = JsonConvert.SerializeObject(list);
        File.WriteAllText(filePath, textData);
    }

    static List<T> LoadData<T>(string filePath) where T : class
    {
        if (File.Exists(filePath))
        {
            var textData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(textData, _settings);
        }
        return new List<T>();
    }

    public static void LoadAll()
    {
        books = LoadData<Book>(BookDataFilePath);
        categoriys = LoadData<Categoriy>(CategoriyFilePath);
        customers = LoadData<Customer>(CustomerDataFilePath);
        workers = LoadData<Worker>(WorkerDataFilePath);
        authors = LoadData<Author>(AuthorsDataFilePath);
        rents = LoadData<Rent>(RentDataFilePath);
    }
}