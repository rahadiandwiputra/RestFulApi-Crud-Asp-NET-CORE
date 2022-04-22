using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    [TestClass]
    public class InMemoryTest
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabaseInMemory()
        {
            /*var builder = new DbContextOptionsBuilder<SamuraiContext>();
            builder.UseInMemoryDatabase("CanInsertSamurai");
            using (var context = new SamuraiContext())
            {
                var samurai = new Samurai();
                //Assert.AreNotEqual(0,samuraiId)
                context.Samurais.Add(samurai);
                Assert.AreEqual(EntityState.Added,
                    context.Entry(samurai).State);
            }*/
        }
    }
}
