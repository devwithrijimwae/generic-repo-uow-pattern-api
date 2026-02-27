namespace generic_repo_uow_pattern_api.Entity
{
    public class Order
    {
        public  int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        //Foreign key to Product
        public  int ProductId { get; set; }
        //Navigation property 
        public  Product Products {get; set;}
    }
}
