namespace Inventory.Models {
    public class BoardGame
    {
	    public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; }
        public bool IsDone { get; set; }
    }
}
