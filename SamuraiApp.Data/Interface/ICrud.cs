using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface  ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetByName(string name);
        Task<T> Insert(T obj);
        Task<T> Update(int id, T obj);
        Task DeleteById(int id);

        Task<T> GetSamuraiWithSword(int id);
        Task<T> GetSamuraiSwordElement(int id);
        Task<T> InsertSamuraiWithSword(T obj);


    }
}
