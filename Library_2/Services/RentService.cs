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
    public class RentService : BaseService<Rent>
    {
        public RentService(IDataProvider<Rent> dataProvider) : base(dataProvider)
        {

        }
        protected override bool IsEntityValid(Rent entity, out string reason)
        {
            reason = "";
            if (entity.Quantity == null)
                reason = "Worker is not null here";

            return reason == "";
        }

        public void DeleteBook(Rent rent)
        {
            foreach (var item in ClassHelper.books)
            {
                if (rent.Book.Name == item.Name)
                    item.Quantity += rent.Quantity;
                break;
            }
            Delete(rent);
        }
    }
}
