namespace generic_repo_pattern_api.Model.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        //Foreign key to Product
        public int ProductId { get; set; }
        //Navigation property 
        public Product Products { get; set; } = new Product();
    }
}
