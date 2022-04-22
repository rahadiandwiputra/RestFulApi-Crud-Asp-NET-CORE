using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //relasi satu ke banyak (satu samurai bisa banyak quote) makanya di beritanda List
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        //relasi many-to-many dengan table Battle 
        public List<Battle> Battles { get; set; } = new List<Battle>();
        public Horse? Horse { get; set; }
        public List<Sword> Swords { get; set; } = new List<Sword>();
    }
}
