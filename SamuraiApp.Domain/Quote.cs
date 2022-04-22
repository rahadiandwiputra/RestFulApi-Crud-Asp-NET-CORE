using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Quote
    {
        public int Id { get; set; } 
        public string Name { get; set; }   

        // relasi untuk menandakan bahwa beberapa Quote hanya butuh satu samurai (banyak ke satu)
        public Samurai Samurai { get; set; }
        //SamuraiId ini sebagai foreign key untuk Samurai
        public int SamuraiId { get; set; }  
    }
}
