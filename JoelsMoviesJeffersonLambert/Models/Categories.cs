using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JoelsMoviesJeffersonLambert.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
// public DbSet<Categories> Categories { get; set; }
