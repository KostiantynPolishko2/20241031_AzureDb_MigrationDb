using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace SpaceObject.Entities
{
    public class AsteroidProperty
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }
        public int size { get; set; }
        public float weight { get; set; }
        public int speed { get; set; }
        public int idAsteroidItem { get; set; }
        public AsteroidItem? asteroidItem { get; set; }
    }
}
