namespace SamuraiApp.Api.DTO
{
    public class SamuraiCreateWithSwordDTO
    {
        public string Name { get; set; }
        public List<SwordCreateDTO> Swords { get; set; } = new List<SwordCreateDTO>();
    }
}
