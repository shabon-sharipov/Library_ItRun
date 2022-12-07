using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_2.interfaces
{
    public interface ITypePerson
    {
        //Guid Id { get; set; }
        int Id { get; set; }
        string FillName { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
    }
}
