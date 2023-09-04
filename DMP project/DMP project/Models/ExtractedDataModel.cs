namespace DMP_project.Models
{
    public class ExtractedDataModel
    {
        public string? NameOfURL { get; set; }
        public int TotalItems { get; set; }
        public List<Client>? Clients { get; set; }
    }
    public class Client
    {
        public string? Name { get; set; }
        public string? Annotation { get; set; }
        public string? Content { get; set; }
        public string? Link { get; set; }
        public string? Image { get; set; }
    }
}