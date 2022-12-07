using InventoryExample.DataProvider;
using Library_2.DataProvider.DB;
using Library_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace library_2.dataprovider
{
    public class DataBaeProvider<T> : IDataProvider<T> where T : EntityBase
    {
        readonly public DbSet<T> _dbset;

        public DataBaeProvider(DbSet<T> dbset)
        {
            _dbset = dbset;
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }


        public T GetById(int Id)
        {
            return _dbset.Find(Id);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

    }
}

