using Library_2.HelperClass;
using Library_2.Models;

namespace InventoryExample.DataProvider
{
    public class JsonDataProvider<T> : IDataProvider<T> where T : EntityBase
    {
        private readonly List<T> _data;

        public JsonDataProvider(List<T> data)
        {
            _data = data;
        }

        public void Add(T entity)
        {
            _data.Add(entity);
        }

        public void Delete(T entity)
        {
            _data.Remove(entity);
        }

        public T GetById(int Id)
        {
            return _data.FirstOrDefault(d => d.Id == Id);
        }

        public void Update(T customer)
        {
            throw new System.NotImplementedException();
        }
    }
}