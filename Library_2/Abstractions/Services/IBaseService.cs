using Library_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_2.Abstractions.Services
{
    public interface IBaseService<T> where T : EntityBase
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int Id);
        void Update(T entity);
    }
}
