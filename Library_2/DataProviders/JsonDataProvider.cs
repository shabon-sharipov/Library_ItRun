using Library_2.HelperClass;
using Library_2.Models;
namespace InventoryExample.DataProvider
{
    public class JsonDataProvider<T> : IDataProvider<T> where T : EntityBase
    {
        public void Add(T entity)
        {
            if (entity is Customer)
            {
               
            }
            
            if (entity is Worker)
            {
            }
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T customer)
        {
            throw new System.NotImplementedException();
        }
    }
}