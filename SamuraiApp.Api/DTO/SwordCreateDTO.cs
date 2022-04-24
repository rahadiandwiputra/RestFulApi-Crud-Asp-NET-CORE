namespace SamuraiApp.Api.DTO
{
    public class SwordCreateDTO
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Weight { get; set; }
        public int SamuraiId
        {
            get; set;
        }

    }
}
