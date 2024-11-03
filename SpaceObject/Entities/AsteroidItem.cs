using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace SpaceObject.Entities
{
    public class AsteroidItem
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string type { get; set; } = null!;

        [SwaggerIgnore]
        public AsteroidProperty? asteroidProperty { get; set; }
    }
}
    