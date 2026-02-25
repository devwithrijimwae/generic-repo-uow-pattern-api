namespace generic_repo_pattern_api.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        //Navigation property 
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
