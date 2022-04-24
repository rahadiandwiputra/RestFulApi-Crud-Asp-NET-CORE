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
    public class GeneralRepo : IGeneralFunction
    {
        private readonly SamuraiContext _context;

        public GeneralRepo(SamuraiContext context)
        {
            _context = context;
        }

        public async Task<Samurai> GetSamuraiSwordElement(int id)
        {
            var result = await _context.Samurais.Where(s => s.Id == id)
                .Include(j => j.Swords)
                .ThenInclude(i => i.Elements)
                .FirstOrDefaultAsync();
            if (result == null) throw new Exception($"Data {id} Tidak Ditemukan");
            return result;
        }

        public async Task<Samurai> GetSamuraiWithSword(int id)
        {
            var result = await _context.Samurais.Include(a => a.Swords)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data {id} Tidak Ditemukan");
            return result;
        }
        public async Task<Samurai> InsertSamuraiWithSword(Samurai obj)
        {
            try
            {
                foreach (var sword in obj.Swords)
                {
                    sword.SamuraiId = obj.Id;
                }
                _context.Samurais.Add(obj);
                _context.Swords.AddRange(obj.Swords);
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




        public async Task<Sword> InsertSwordWithElement(Sword obj)
        {
            try
            {/*
                foreach (var elements in obj.Elements)
                {
                    var data = _context.Elements.Where(e => e.Name == elements.Name).First();
                    if (elements.Name == null)
                    {
                        _context.Elements.Add(elements);
                        _context.SwordElements.Add(new SwordElement { SwordId = obj.Id, ElementId = elements.Id });
                    }
                    else
                    { 
                        _context.SwordElements.Add(new SwordElement { SwordId = obj.Id, ElementId = elements.Id });
                    }
                }*/
                _context.Elements.AddRange(obj.Elements);   
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
    }
}
