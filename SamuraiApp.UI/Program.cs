// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

/*SamuraiContext _context = new SamuraiContext();
_context.Database.EnsureCreated();
*//*MENJALANKAN METHOD*/
//GetSamurai("Sebelum ditambahkan");
//AddSamurai("samurai 1", "samurai 2", "samurai 3","samurai 5");
//AddBattle("Battle Of Anegawa", "Battle Of Kyoto");
//GetSamurai("Setelah Ditambahkan");
//AddVariousType();
//QueryFilters();
//QueryFilters1();
//RettriveAndUpdateSamurai();
//QueryAggregates();
//RettieveAndUpdateSamuraiMultiple();
//MultipleDatabaseOprations();
//RettriveAnDeleteSamuraiMultiple();
//RettriveAnDeleteSamurai();
//QueryAndUpdateBattleDisconnect();
//InsertNewSamuraiWithQuote();
//AddQuotesToExistingSamurai();
//AddQuotesToExistingSamuraiNoTracking(2);
//SimpleAddQuotesToExistingSamuraiNoTracking(4);
//EagerLoadSamuraiWithQuotes();
//projectSample();
//ExplisitLoadQuotes();
//FilteringWithRelatedData();
//ChangeQuotes();
//ModifyRelatedDataNoTracking();
//AddNewSAmuraiToBattle();
//BattleWithSamurai();
//AddAllSamuraiAllBattle();
//RemoveSamuraiBatle();
//RemoveSamuraiFromBattleExplicit();
//AddNewSamuraiWithHorse();
//AddNewSamuraiWithHorseByFK();
//AddNewHorseNoTracking();
//GetSamuraiWithHorse();
//QueryViewBattleStat();
//QueryUsingRaw();
//QueryUsingSPRaw();
//AddNewSamurai("Rahadian");
//GetBattle();
Console.WriteLine("Press Any Key");
Console.ReadKey(true);
//QueryAndUpdateBattleDisconnectAgain();
//GetSamurai("Setelah Ditambahkan");
/*AddSamuraiByName("Nobunage", "Takeda", "Iyeasu");


void AddSamurai(params string[] names)
{
    foreach(string name in names)
    {
        //tracking dulu dan di tampung dulu di DbContext jika inputan banyak
        _context.Samurais.Add(new Samurai { Name = name });
    }
*//*    var samurai = new Samurai { Name = name};
    _context.Samurais.Add(samurai);*//*
    //lalu di save setelah di tracking
    _context.SaveChanges();
}
void AddBattle(params string[] names)
{
    foreach (string name in names)
    {
        //tracking dulu dan di tampung dulu di DbContext jika inputan banyak
        _context.Battles.Add(new Battle { Name = name });
    }
    *//*    var samurai = new Samurai { Name = name};
        _context.Samurais.Add(samurai);*//*
    //lalu di save setelah di tracking
    _context.SaveChanges();
}
//Insert Multiple Table Relations
void AddVariousType()
{
    *//*    _context.Samurais.AddRange(
            new Samurai { Name = "Kensin" },
            new Samurai { Name = "Shisio" }
            );
        _context.Battles.AddRange(
            new Battle{ Name = "Battle Of Anegawa"},
            new Battle { Name = "Battle Of Anegawa" }
            );*//*
    _context.AddRange(
        new Samurai { Name = "Shobu" },
        new Samurai { Name = "Sami" },
        new Battle { Name = "Battle Ground" },
        new Battle { Name = "Battle of Kyoto" }
        );
    _context.SaveChanges();
}
void GetSamurai(string text)
{
    //best practice 
    var samurais = _context.Samurais
        .TagWith("Get Samurai Method")
        .ToList();//ToList Disini diperuntukan untuk menampung dulu data yang sudah di ambil dari database 
    Console.WriteLine($"{text} : Jumlah Samurai adalah {samurais.Count}" );
    foreach (var samurai in samurais)
    {
        Console.WriteLine($"{samurai.Id} - {samurai.Name}");
    }
}
void QueryFilters()
{
    var samurais = _context.Samurais.Where(s => s.Name == "Rengoku").OrderBy(s=>s.Name).ToList();
}
void QueryFilters1()
{
    var samurais = _context.Samurais.Where(s => s.Name.Contains("Reng")).ToList();
    var sm = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "Re%")).ToList();
    foreach (var samurai in sm)
    {
        Console.WriteLine(samurai.Name);
    }
}
void QueryAggregates()
{
    var name = "Rengoku";
    //var samurai = _context.Samurais.FirstOrDefault(s => s.Name==name); //menggunakan LINQ Method
    var samurai = (from s in _context.Samurais
                   where s.Name == name
                   select s).FirstOrDefault();//ini menggunakan LINQ Query
    //var samurai = _context.Samurais.Find(2); //langsung terhubung ke DataSet<>
    Console.WriteLine($"ID {samurai.Id} - Nama {samurai.Name}");
}
//update data menggunakan first or default
void RettriveAndUpdateSamurai()
{
    var samurai = _context.Samurais.SingleOrDefault(s=>s.Id==2);
    samurai.Name = "Kyojiro Rengoku";
    _context.SaveChanges();
    
}
//multiple update
void RettieveAndUpdateSamuraiMultiple()
{
    //yang diupdate index 1-4 di database menambahkan San dibelakang 
    var samurai = _context.Samurais.Skip(0).Take(4).ToList();
    samurai.ForEach(s=>s.Name+=" San");
    _context.SaveChanges();
}
//Opration Update And Insert
void MultipleDatabaseOprations()
{
    var samurai = _context.Samurais.OrderBy(s=>s.Id).LastOrDefault();
    samurai.Name += " San";
    _context.Samurais.Add(new Samurai { Name = "Gyomei Himejima" });
    _context.SaveChanges();
}
//Delete
void RettriveAnDeleteSamurai()
{
    var samurai = _context.Samurais.Find(8);
    _context.Samurais.Remove(samurai);
    _context.SaveChanges();
}
//Multiple delete
void RettriveAnDeleteSamuraiMultiple()
{
    var samurai = _context.Samurais.Where(s=>s.Name.StartsWith("Samurai")).ToList();
    _context.Samurais.RemoveRange(samurai);
    _context.SaveChanges();
}
//Dalam kasus ini kita tidak bisa mentracking karena context disinya sudah disconnnect maka yang akan dilakukan adalah sistem akan mengupdate semua field
//Biasanya kasus ini terjadi ketika pelemparan data antar service
void QueryAndUpdateBattleDisconnect()
{
    List<Battle> disconnectBattle;
    using (var context1= new SamuraiContext())
    {
        disconnectBattle = context1.Battles.AsNoTracking().ToList(); // hati hati dalam menggunakan asnotracking karena tidak bisa di update insert atau delete karena itu butuh tracking
    }//sudah di sispose/ sudah di akses oleh service lain
    disconnectBattle.ForEach(b =>
    {
        b.SatrtDate = new DateTime(1570, 01,01);
        b.EndDate = new DateTime(1575, 01, 01);
    });
    using (var context2 = new SamuraiContext())
    {
        context2.UpdateRange(disconnectBattle);
        context2.SaveChanges();
    } 
}
void GetBattle()
{
    var battle = _context.Battles.ToList();
    foreach (var b in battle)
    {
        Console.WriteLine($"ID {b.BattleId} - Name {b.Name}");
    }
}
//No tracking sama dengan method QueryAndUpdateBattleDisconnect()
void QueryAndUpdateBattleDisconnectAgain()
{
    List<Battle> disconnectBattle;
    using (var context1 = new SamuraiContextNoTracking())
    {
        disconnectBattle = context1.Battles.ToList(); 
    }//sudah di sispose/ sudah di akses oleh service lain
    disconnectBattle.ForEach(b =>
    {
        b.SatrtDate = new DateTime(2015, 01, 01);
        b.EndDate = new DateTime(2015, 01, 01);
    });
    using (var context2 = new SamuraiContext())
    {
        context2.UpdateRange(disconnectBattle);
        context2.SaveChanges();
    }
}
//insert table relation
void InsertNewSamuraiWithQuote()
{
    var samurai = new Samurai
    {
        Name = "Miyamoto Musashi",
        Quotes = new List<Quote> 
        { 
            new Quote { Name = "Think lightly off yourself and deeply world"},
            new Quote { Name = "Do Nothing that is of no use"},
        }
    };
    _context.Samurais.Add(samurai);
    _context.SaveChanges();
}
void AddQuotesToExistingSamurai()
{
    var samurai = _context.Samurais.Where(s => s.Id == 1).FirstOrDefault();
    samurai.Quotes.Add(
        new Quote
        {
            Name = "Dont Fear death"
           
        });
    _context.SaveChanges();

    
}
//insert Quotes To Existing Samurai No Tracking
void AddQuotesToExistingSamuraiNoTracking(int samuraiId)
{
    var samurai = _context.Samurais.Find(samuraiId);
    samurai.Quotes.Add(new Quote
    {
        Name = "Do not fear death"
    });
    using (var context1 = new SamuraiContextNoTracking())
    {
        //context1.Samurais.Update(samurai);
        context1.Samurais.Attach(samurai);
        context1.SaveChanges(); 
    }
}
//insert Quotes To Existing Samurai No Tracking Lebih SImple
void SimpleAddQuotesToExistingSamuraiNoTracking(int samuraiId)
{
    var quote = new Quote { Name = "Never Stray from the way", SamuraiId = samuraiId };
    using (var context1 = new SamuraiContextNoTracking())
    {
        context1.Quotes.Add(quote);
        context1.SaveChanges();
    }
}
//relasi one-to-many
void EagerLoadSamuraiWithQuotes()
{
    //var samuraiWitthQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
    //var SplitQuery = _context.Samurais.AsSplitQuery().Include(s => s.Quotes).ToList();

    //Filtering dengan relasi with condition
    //var filteredEntity = _context.Samurais.Include(s => s.Quotes.Where(
    //    q => q.Name.Contains("fear"))).ToList();

    //relasi with codition
   // var filteredEntitInclude = _context.Samurais.Where(s => s.Name.Contains("San")).Include(s => s.Quotes).ToList();

    var single=_context.Samurais.Where(s => s.Id == 14).Include(q => q.Quotes.Where(l => l.Id == 1)).FirstOrDefault();
    Console.WriteLine(single);  
}
//hanya menampilkan object tertentu
void projectSample()
{
    //var result = _context.Samurais.Select(s =>new { s.Id,  s.Name }).ToList();
    //var result = _context.Samurais.Select(s => new IdAndName { s.Id, s.Name }).ToList();
    *//*var resultWithCount = _context.Samurais.Select(s =>
                           new { s.Id, s.Name, NumOfQuotes = s.Quotes.Count }).ToList();*//*
    var samuraiAndQuotes = _context.Samurais.Select(s => new
    {
        Samurai = s,
        BesQuotes = s.Quotes.Where(q => q.Name.Contains("fear"))
    }).ToList();
}
//one-to-one  menagmbil object yang sudah ada di memory
void ExplisitLoadQuotes()
{
    *//*_context.Set<Horse>().Add(new Horse { SamuraiId = 1, Name = "Yamato" });
    _context.SaveChanges();*//*
    var samurai = _context.Samurais.Find(1);
    _context.Entry(samurai).Collection(s => s.Quotes).Load();
}
void FilteringWithRelatedData()
{
    var samurai= _context.Samurais.Where(s=>s.Quotes.Any(q=>q.Name.Contains("fear"))).ToList();
}
//merubah quotes dari obejct samurai
void ChangeQuotes()
{
    var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 14);
    samurai.Quotes[0].Name = "Hello World";
    _context.Quotes.Remove(samurai.Quotes[1]);
    _context.SaveChanges();
}
//update quote yang berlesai dengan samurai dengan NoTracking / Disconnected
void ModifyRelatedDataNoTracking()
{
    var samurai = _context.Samurais.Include(s=>s.Quotes).FirstOrDefault(s=>s.Id == 14);
    var quotes = samurai.Quotes[0];
    quotes.Name = "Never Give UP";
    using (var context1 = new SamuraiContext())
    {
        //context1.Quotes.Update(quotes);//karena menggunakan metod update yang di update table samurai dan quote itu tidak efektif karena kita hanya ingin mengupdate quote aja
        context1.Entry(quotes).State = EntityState.Modified;//explisit lebih efektif karena disini yang di update hanya satu table yaitu quote aja
        context1.SaveChanges();
    }
}
//contoh many-to-many not payload
void AddNewSAmuraiToBattle()
{
    var battle = _context.Battles.FirstOrDefault();
    battle.Samurais.Add(new Samurai { Name = "Nobuya Oda" });
    _context.SaveChanges();
}
void BattleWithSamurai()
{
    //var battle = _context.Battles.Include(b=>b.Samurais).FirstOrDefault(b=>b.BattleId == 1);
    var battles = _context.Battles.Include(b => b.Samurais).ToList();
}
//daftarin semua samurai ke battles
void AddAllSamuraiAllBattle()
{
    var allbattle = _context.Battles.ToList();
    var allsamurais = _context.Samurais.ToList();
    foreach(var battle in allbattle)
    {
        battle.Samurais.AddRange(allsamurais);
    }
    _context.SaveChanges();
}
void RemoveSamuraiBatle()
{
    var battleWithSamurai = _context.Battles.Include(b=>b.Samurais.Where(s=>s.Id == 14))
        .SingleOrDefault(b=>b.BattleId == 1);
    var samurai = battleWithSamurai.Samurais[0]; 
    battleWithSamurai.Samurais.Remove(samurai);
    _context.SaveChanges();
}
void RemoveSamuraiFromBattleExplicit()
{
    var battlesamurai = _context.Set<BattleSamurai>()
        .SingleOrDefault(bs=>bs.BattleId==1 && bs.SamuraiId == 2);
    if (battlesamurai!=null)
    {
        _context.Remove(battlesamurai);
        _context.SaveChanges();
    }
    else
    {
        Console.WriteLine("Data Kosong");
    }
}
//Tanpa ForeignKey
void AddNewSamuraiWithHorse()
{
    var samurai = new Samurai { Name = "Kensin Himura" };
    samurai.Horse = new Horse { Name = "Nekochan" };
    _context.Samurais.Add(samurai);
    _context.SaveChanges();
}
//Menggunakan Foreign Key
void AddNewSamuraiWithHorseByFK()
{
    var horse = new Horse { Name = "Red Horse", SamuraiId = 10 };
    _context.Add(horse);
    _context.SaveChanges();
}
void AddNewHorseNoTracking()
{
    var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(s=>s.Id == 3);//nambah di samurai ke 3
    samurai.Horse = new Horse { Name = "Silver Thunder" };
    using (var contetxt1 = new SamuraiContext())
    {
        contetxt1.Samurais.Attach(samurai);
        contetxt1.SaveChanges();
    }
}
//get samurai with horse
void GetSamuraiWithHorse()
{
    var samurais = _context.Samurais.Include(s => s.Horse).ToList();
    var hourse = _context.Set<Horse>().Find(1);
}
void QueryViewBattleStat()
{
    *//*var result = _context.SamuraiBattleStats.ToList();
    foreach(var stat in result)
    {
        Console.WriteLine($"{stat.Name} - {stat.NumberOfBattles} - {stat.EarliestBattle}");
    }*//*
    //filter
    var firstsats = _context.SamuraiBattleStats.FirstOrDefault(s => s.Name == "Kensin");
    Console.WriteLine($"{firstsats.Name} - {firstsats.NumberOfBattles} - {firstsats.EarliestBattle}");
}
//Scalar Function
void QueryUsingRaw()
{
    *//*  var samurais = _context.Samurais.FromSqlRaw("select * from Samurais").ToList();
      foreach (var item in samurais)
      {
          Console.WriteLine($"{item.Name}");
      }*//*
    var name = "Kensin";
    var samurai = _context.Samurais.FromSqlInterpolated($"select * from Samurais Where Name = {name}").ToList();
}
//Store Procedure Function
void QueryUsingSPRaw()
{
    //var text = "fear";
    //var samurai = _context.Samurais.FromSqlRaw("exec dbo.SamuraisWhoSaidAWord {0}", text).ToList();
    //var samurai = _context.Samurais.FromSqlInterpolated($"exec dbo.SamuraisWhoSaidAWord {text}").ToList();
    var QuotesID = 6;
    // _context.Database.ExecuteSqlRaw("exec dbo.DeleteQuotesForSamurai {0}", QuotesID);
    _context.Database.ExecuteSqlInterpolated($"exec dbo.DeleteQuotesForSamurai {QuotesID}");// 
    Console.WriteLine($"Data Quotes ID = {QuotesID} berhasil di Delete");
}
void AddSamuraiByName(params string[] names){
    var bs = new BusinessDataLogic();
    var SamuraiCreate= bs.AddSamuraiByName(names);
}
void AddNewSamurai(string name)
{
    var bs = new BusinessDataLogic();
    var SamuraiNew = bs.InsertNewSamurai(new Samurai { Name = name});
}
struct IdAndName
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public IdAndName(int id,string name)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Id = id;
        Name = name;
    }
    public int Id;
    public string Name; 
}*/
