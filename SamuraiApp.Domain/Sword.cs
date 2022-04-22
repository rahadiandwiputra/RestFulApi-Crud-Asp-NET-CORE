using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Sword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Weight { get; set; }
        public Samurai Samurai { get; set; }
        //SamuraiId ini sebagai foreign key untuk Samurai
        public int? SamuraiId
        {
            get; set;
        }
        public List<Element> Elements { get; set; } = new List<Element>();

    }
}
