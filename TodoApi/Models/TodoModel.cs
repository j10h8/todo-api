namespace TodoApi.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Completed { get; set; }
    }
}
