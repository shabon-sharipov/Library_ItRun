using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_2.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        //private Guid _guid;
        //public Guid Guid
        //{
        //    get
        //    {
        //        if (_guid == Guid.Empty)
        //            _guid = Guid.NewGuid();
        //        return _guid;
        //    }
        //    set { _guid = value; }

        //}
    }
}