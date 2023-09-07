using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdswerveMVCDemoAdriaanCroucamp.Models
{
    public class Book
    {
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Quantity_Available { get; set; }

    }
}