using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace API.Entities
{
    public class Book
    {
        public int Id { get; set; } // unique
        public string Title { get; set; } // unique    -- caution cannot be unique
        public int Price { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public string URL { get; set; }
        public string SellId { get; set; }  // unique

    }
}