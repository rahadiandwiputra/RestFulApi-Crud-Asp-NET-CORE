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
    public class SamuraiRepo : ISamurai
    {
        private readonly SamuraiContext _context;

        public SamuraiRepo(SamuraiContext context)
        {
            _context = context;
        }
        //Tracking
        public async Task DeleteById(int id)
        {
            var deleteSamurai = await GetById(id);
            _context.Samurais.Remove(deleteSamurai);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var result = await _context.Samurais.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Samurai> GetById(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data dengan id : {id} Tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetByName(string names)
        {
            var result = await _context.Samurais.Where(s => s.Name.Contains(names)).ToListAsync();
            if (result == null) throw new Exception($"Data dengan Nama : {names} Tidak ditemukan");
            return result;
        }


        public async Task<Samurai> Insert(Samurai obj)
        {

            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                /*if (obj.Swords.Count>0)
                {
                    _context.Swords.AddRange(obj.Swords);
                    await _context.SaveChangesAsync();
                }*/
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

        

        //Tracking
        public async Task<Samurai> Update(int id, Samurai obj)
        {
            try
            {
                var samurais = await GetById(id);
                samurais.Name = obj.Name;
                await _context.SaveChangesAsync();
                return samurais;
            }
            catch (DbUpdateConcurrencyException edbx)
            {
                throw new Exception(edbx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //throw new NotImplementedException();
        }
    }
}
