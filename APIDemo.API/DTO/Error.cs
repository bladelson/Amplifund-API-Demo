namespace APIDemo.API.DTO
{
    public class Error(string Detail)
    {
        public string Detail { get; set; } = Detail;
    }
}