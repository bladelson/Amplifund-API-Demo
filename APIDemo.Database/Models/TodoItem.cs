
namespace APIDemo.Database.Models
{
    public class TodoItem
    {
        public int Id { get; set; } = -1; //-1 is sentinel for entity framework
        public string Title { get; set; } = default!; //database enforces non null
        public string Description { get; set; } = default!; //database enforces non null
        public DateTimeOffset Created { get; set; } = default;
        public DateTimeOffset Modified { get; set; } = default;
        public bool Deleted { get; set; }
    }
}