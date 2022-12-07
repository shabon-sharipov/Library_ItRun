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
    public class WorkerService : BaseService<Worker>
    {
        public WorkerService(IDataProvider<Worker> dataProvider) : base(dataProvider)
        {

        }

        protected override bool IsEntityValid(Worker entity, out string reason)
        {
            reason = "";
            if (entity.FillName == "")
                reason = "Name is not null here";
            else if (entity.Address == "")
                reason = "Address is not null here";
            else if (entity.Phone == "")
                reason = "Phone is not null here";

            return reason == "";
        }
    }
}
