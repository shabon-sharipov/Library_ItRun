using Library_2.HelperClass;
using Newtonsoft.Json;
namespace Library_2.Models;

public class Book : EntityBase
{
    public string Name { get; set; }
    public int AuthorId { get; private set; }

    private Author _author;
    [JsonIgnore]
    public Author Author
    {
        get
        {
            if (_author == null)
                _author = ClassHelper.authors.SingleOrDefault(m => m.Id == AuthorId);
            return _author;
        }
        set
        {
            _author = value;
            AuthorId = _author?.Id ?? 0;
        }
    }

    public int CategoriyId { get; private set; }

    private Categoriy _categoriy;
    [JsonIgnore]
    public Categoriy Categoriy
    {
        get
        {
            if (_categoriy == null)
                _categoriy = ClassHelper.categoriys.SingleOrDefault(m => m.Id == CategoriyId);
            return _categoriy;
        }
        set
        {
            _categoriy = value;
            CategoriyId = _categoriy?.Id ?? 0;
        }
    }
    public int Quantity { get; set; }
    public int NamberOfPage { get; set; }

    public override string ToString()
    {
        return $"NameBook: {Name}, Author: {Author.Name}, Category: {Categoriy.Name}, Quantity: {Quantity}, NamberOfPage: {NamberOfPage}";
    }
}
