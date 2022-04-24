using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SwordRepo : ISword
    {
        private readonly SamuraiContext _context;

        public SwordRepo(SamuraiContext context)
        {
            _context = context;
        }

        public async Task DeleteById(int id)
        {
            var deleteSword = await GetById(id);
            _context.Swords.Remove(deleteSword);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var swords = await _context.Swords.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return swords;
        }

        public async Task<Sword> GetById(int id)
        {
            var result = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data dengan id : {id} Tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
            var result = await _context.Swords.Where(s => s.Name.Contains(name)).ToListAsync();
            if (result == null) throw new Exception($"Data dengan Nama : {name} Tidak ditemukan");
            return result;
        }

        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException edbx)
            {
                throw new Exception(edbx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        

        public async Task<Sword> Update(int id, Sword obj)
        {
            try
            {
                var sword = await GetById(id);
                sword.Name = obj.Name;
                sword.Created = DateTime.Now;
                sword.Weight = obj.Weight;
                await _context.SaveChangesAsync();
                return sword;
            }
            catch (DbUpdateConcurrencyException edbx)
            {
                throw new Exception(edbx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
