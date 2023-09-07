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

        // https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-7.0
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("book_id")]
        public int Book_Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(255, ErrorMessage = "Title can't be longer than 255 characters")]
        [Column("title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(255, ErrorMessage = "Author can't be longer than 255 characters")]
        [Column("author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column("price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity Available is required")]
        [Column("quantity_available")]
        public int Quantity_Available { get; set; }

    }
}