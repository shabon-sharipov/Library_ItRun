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
    public abstract class BaseService<T> : IBaseService<T> where T : EntityBase
    {
        private readonly IDataProvider<T> _dataProvider;

        public BaseService(IDataProvider<T> dataProvider)
        {
            this._dataProvider = dataProvider;
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new CustomException("Entity cannot be null");

            ValidateEntity(entity);
            _dataProvider.Add(entity);
        }

        public void Delete(T entity)
        {
            _dataProvider.Delete(entity);
        }

        public void Update(T entity)
        {
            ValidateEntity(entity);
        }

        private void ValidateEntity(T entity)
        {
            if (!IsEntityValid(entity, out string reason))
                throw new CustomException(reason);
        }

        protected abstract bool IsEntityValid(T entity, out string reason);

        public T GetById(int id)
        {
            return _dataProvider.GetById(id);
        }

    }
}
