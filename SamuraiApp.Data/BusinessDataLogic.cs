﻿using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class BusinessDataLogic
    {
        private SamuraiContext _context;
        public BusinessDataLogic(SamuraiContext context)
        {
            _context = context;
        }
        /*public BusinessDataLogic()
        {
            _context = new SamuraiContext();
        }*/
        public int AddSamuraiByName(params string[] names)
        {
            foreach(string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }
            var dbResult = _context.SaveChanges();
            return dbResult;
        }
        public int InsertNewSamurai(Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            var dbResult = _context.SaveChanges();
            return dbResult;
        }
        public Samurai GetSamuraiWithQuote(int samuraiId)
        {
            var samurai = _context.Samurais.Where(s=>s.Id == samuraiId).Include(s=>s.Quotes).FirstOrDefault();
            return samurai;
        }
    }
}
