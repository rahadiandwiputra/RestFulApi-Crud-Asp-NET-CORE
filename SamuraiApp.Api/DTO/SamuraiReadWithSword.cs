namespace SamuraiApp.Api.DTO
{
    public class SamuraiReadWithSword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SwordDTO> Swords { get; set; }= new List<SwordDTO>();
    }
}
