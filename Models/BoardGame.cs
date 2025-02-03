using System.ComponentModel.DataAnnotations;

namespace Inventory.Models {
    public class BoardGame
    {
	    public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Range(0, 10)]
        public int? Rating { get; set; }
        public bool IsDone { get; set; }
    }
}
