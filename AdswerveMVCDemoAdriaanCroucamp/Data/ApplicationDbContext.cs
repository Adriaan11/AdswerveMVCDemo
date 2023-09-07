using AdswerveMVCDemoAdriaanCroucamp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdswerveMVCDemoAdriaanCroucamp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

    }
}