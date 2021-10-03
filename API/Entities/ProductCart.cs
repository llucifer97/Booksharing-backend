namespace API.Entities
{
    public class ProductCart
     {
         public int Id { get; set; } // unique
         public int BookId { get; set; }
         public int Price { get; set; }
         public int Count { get; set; }
         public int Total { get; set; }
         public string UserId { get; set; }
         public AppUser AppUsers { get; set; }
         public string Transaction_id { get; set; }
        


    }
}