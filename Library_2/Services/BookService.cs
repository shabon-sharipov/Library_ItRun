using InventoryExample.DataProvider;
using Library_2.Abstractions.Services;
using Library_2.Exceptions;
using Library_2.HelperClass;
using Library_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_2.Services
{
    public class BookService : BaseService<Book>
    {
        public BookService(IDataProvider<Book> dataProvider) : base(dataProvider)
        {

        }

        protected override bool IsEntityValid(Book entity, out string reason)
        {
            reason = "";
            if (entity.Name == "")
                reason = "Name is not null here!";
            else if (entity.Author == null)
                reason = "Author is not null here!";
            else if (entity.Categoriy == null)
                reason = "Categoriy is not null here!";
            else if (entity.NamberOfPage == null && entity.Quantity == 0)
                reason = "NamberOfPage is not null here!";

            return reason == "";
        }
    }
}
