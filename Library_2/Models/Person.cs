using Library_2.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_2.Models
{
    public abstract class Person : EntityBase
    {
        public string FillName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, FillName: {FillName}, Address: {Address}, Phone: {Phone}";
        }
    }
}
