namespace APIDemo.API.DTO
{
    public class NewTodoItem
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsValid() => !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Description) && Title.Length <= 512;
    }
}