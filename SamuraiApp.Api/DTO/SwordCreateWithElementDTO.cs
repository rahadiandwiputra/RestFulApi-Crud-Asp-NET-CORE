using SamuraiApp.Domain;

namespace SamuraiApp.Api.DTO
{
    public class SwordCreateWithElementDTO
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SamuraiId { get; set; }
        public List<ElementDTO> Elements { get; set; } = new List<ElementDTO>();
    }
}
