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
    public class CustomerServise : BaseService<Customer>
    {
        public CustomerServise(IDataProvider<Customer> dataProvider) : base(dataProvider)
        {
        }

        protected override bool IsEntityValid(Customer customer, out string reason)
        {
            reason = "";
            if (customer.FillName == "")
                reason += "Name is not null here\r\n";

            if (customer.Address == "")
                reason += "Address is not null here\r\n";

            if (customer.Phone == "")
                reason += "Phone is not null here\r\n";

            return reason == "";
        }
    }
}
