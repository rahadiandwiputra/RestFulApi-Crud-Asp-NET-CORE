using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
namespace SamuraiApp.Test
{
    [TestClass]
    public class BussinessDataLogicTest
    {
        [TestMethod]
        public void CanAddSamuraiByName()
        {
            //Test in memory
            var builder = new DbContextOptionsBuilder<SamuraiContext>();
            builder.UseInMemoryDatabase("CanAddSamuraiByName");
            using (var context = new SamuraiContext(builder.Options))
            {
                var bs = new BusinessDataLogic(context);
                var expectred = 3;
                var nameList = new string[] { "Nobunage", "Takeda", "Iyeasu" };
                var result = bs.AddSamuraiByName(nameList);
                Assert.AreEqual(expectred, result);
            }
        }
        [TestMethod]
        public void CanInsertingSamuraiSingle()
        {
            var builder = new DbContextOptionsBuilder<SamuraiContext>();
            builder.UseInMemoryDatabase("CanInsertingSamuraiSingle");
            using (var context = new SamuraiContext(builder.Options))
            {
                var bs = new BusinessDataLogic(context);
                var expected = 1;
                var name = new Samurai { Name = "Tanjiro" };
                bs.InsertNewSamurai(name);
                Assert.AreEqual(expected, context.Samurais.Count());
            }
        }
        [TestMethod]
        public void CanInsertSamuraiWithQuote()
        {
            var expect = 2;
            var newSamurai = new Samurai
            {
                Name = "Tanjiro",
                Quotes = new List<Quote>
                {
                    new Quote { Name = "You only live once"},
                    new Quote { Name = "Sword is your best Friend"}
                }
            };
            var builder = new DbContextOptionsBuilder<SamuraiContext>();
            builder.UseInMemoryDatabase("SamuraiWithQuote");
            using (var context = new SamuraiContext(builder.Options))
            {
                var bs = new BusinessDataLogic(context);
                var Result = bs.InsertNewSamurai(newSamurai);
            }
            using (var context2 = new SamuraiContext(builder.Options))
            {
                var SamuraiWithQuotes = context2.Samurais.Include(s => s.Quotes).FirstOrDefault();
                Assert.AreEqual(expect, SamuraiWithQuotes.Quotes.Count);
            }
        }

        [TestMethod]
        public void CanGetSamuraiWithQuote()
        {
            int samuraiId;
            var expected = 3;
            var builder = new DbContextOptionsBuilder<SamuraiContext>();
            builder.UseInMemoryDatabase("GetQuotes");
            using (var context = new SamuraiContext(builder.Options))
            {
                var newSamuraiName = new Samurai
                {
                    Name = "Tanjiro",
                    Quotes = new List<Quote>
                    {
                    new Quote { Name = "You only live once"},
                    new Quote { Name = "Sword is your best Friend"},
                    new Quote { Name = "Fear is your enemy"}
                    }
                };
                context.Add(newSamuraiName);
                context.SaveChanges();
                samuraiId = newSamuraiName.Id;
            }
            using (var context2 = new SamuraiContext(builder.Options))
            {
                var bs = new BusinessDataLogic(context2);
                var SamuraiQoute = bs.GetSamuraiWithQuote(samuraiId);
                Assert.AreEqual(expected, SamuraiQoute.Quotes.Count);
            }
        }

    }
}
