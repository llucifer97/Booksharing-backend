using System.Collections.Generic;

namespace API.DTOs
{
    public class OrderDTO
    {
        public string Transaction_id { get; set; }
        // public string BookTitle { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public int Price { get; set; }    
        public string UserId { get; set; }       
        public string bookserialno { get; set; }    

    }
}