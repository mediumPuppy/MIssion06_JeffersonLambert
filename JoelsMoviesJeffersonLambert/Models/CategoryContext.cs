using Microsoft.EntityFrameworkCore;

namespace JoelsMoviesJeffersonLambert.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }


    }
}
