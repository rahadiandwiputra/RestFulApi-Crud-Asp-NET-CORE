using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface ICrudSword<T>
    {
        Task<IEnumerable<T>> GetAllSword();
        Task<T> InsertSword(T obj);
        Task<T> InsertSwordWithElement(T obj);
        Task<T> GetById(int id);
        Task<T> Update(int id, T obj);
        Task DeleteById(int id);

    }
}
