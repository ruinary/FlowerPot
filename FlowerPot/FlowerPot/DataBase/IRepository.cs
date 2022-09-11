using System.Collections.Generic;

namespace FlowerPot.Repository
{
    interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Remove(int id);
        void Update(T item);
    }
}
