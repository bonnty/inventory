using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Models
{
    [PrimaryKey(nameof(Isbn))]
    public class Book
    {
        public int Isbn { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;

        [Range(0, 10)]
        public int? Rating { get; set; }
    }
}