using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Sword Sword { get; set; }
        //SamuraiId ini sebagai foreign key untuk Samurai
        public int? SwordId
        {
            get; set;
        }
    }
}
