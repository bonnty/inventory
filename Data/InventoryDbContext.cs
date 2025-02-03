using Microsoft.EntityFrameworkCore;
using Inventory.Models;

namespace Inventory.Data
{
    public class InventoryDbContext : DbContext
    {
    	public InventoryDbContext (DbContextOptions<InventoryDbContext> options): base(options) {}
    
    	public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
