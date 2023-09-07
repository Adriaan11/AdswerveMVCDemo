using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdswerveMVCDemoAdriaanCroucamp.Models
{
    public class Book
    {
        [Key]
        [Column("book_id")]
        public int Book_Id { get; set; }
        [Column("title")]

        public string Title { get; set; }
        [Column("author")]

        public string Author { get; set; }
        [Column("price")]

        public decimal Price { get; set; }
        [Column("quantity_available")]

        public int Quantity_Available { get; set; }

    }
}