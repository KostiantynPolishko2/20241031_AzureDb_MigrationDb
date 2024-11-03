using System.ComponentModel.DataAnnotations;

namespace SpaceObject.Entities
{
    public class SpaceItem
    {
        [Key]
        public int item_id { get; set; }
        public string name { get; set; } = null!;
        public string type { get; set; } = null!;
        public float speed { get; set; }
        public bool isAvailabe  { get; set; }
    }
}
