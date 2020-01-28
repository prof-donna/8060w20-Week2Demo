using Microsoft.EntityFrameworkCore; // DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Week2Demo.Models
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options)
        {
            Database.EnsureCreated();  // will check and create if not found
        }
    }
}
