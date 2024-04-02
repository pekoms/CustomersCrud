namespace CustomersCrud.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string? email { get;set; }
        public string? first { get;set; }
        public string? last { get;set; }
        public string? company { get;set; }
        public string? created_at { get;set; }
        public string? country { get; set; }

    }
}
