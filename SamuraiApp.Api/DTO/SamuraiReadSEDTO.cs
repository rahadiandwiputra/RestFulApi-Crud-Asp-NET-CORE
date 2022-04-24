namespace SamuraiApp.Api.DTO
{
    public class SamuraiReadSEDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SwordElementDTO> Swords { get; set; } = new List<SwordElementDTO>();
    }
}
