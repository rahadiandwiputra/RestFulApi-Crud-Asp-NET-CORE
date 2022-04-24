using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface IGeneralFunction
    {
        Task<Samurai> GetSamuraiWithSword(int id);
        Task<Samurai> GetSamuraiSwordElement(int id);
        Task<Samurai> InsertSamuraiWithSword(Samurai obj);
        Task<Sword> InsertSwordWithElement(Sword obj);

    }
}
