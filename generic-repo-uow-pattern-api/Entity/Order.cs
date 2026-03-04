namespace generic_repo_uow_pattern_api.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        //Foreign Key
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Navigation property
        public Product Product { get; set; } = null!;
    }
}