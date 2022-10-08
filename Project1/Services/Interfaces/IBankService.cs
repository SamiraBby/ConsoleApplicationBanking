using Project1.Models;
using System.Collections.Generic;

namespace Project1.Services.Interfaces
{
    public interface IBankService<T> where T : BaseModel
    {
        T Create(T entity);
        T Update(string name, T entity);
        void Delete(string name);
        T Get(string name);
        void GetAll();
    }
}
