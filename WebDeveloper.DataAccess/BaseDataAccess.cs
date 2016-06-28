using System.Collections.Generic;

namespace WebDeveloper.DataAccess
{
    public class BaseDataAccess<T> : IDataAccess<T> where T: class
    {
        public int Add(T entity)
        {
            return 0;
        }

        public int Delete(T entity)
        {
            return 0;
        }

        public List<T> GetList()
        {
            return new List<T>();
        }

        public int Update(T entity)
        {
            return 0;
        }
    }
}
