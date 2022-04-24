namespace SamuraiApp.Api.DTO
{
    public class SwordDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int Weight { get; set; }
        public int SamuraiId
        {
            get; set;
        }
    }
}
