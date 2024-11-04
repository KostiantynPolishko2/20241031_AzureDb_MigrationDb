using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace SpaceObject.Entities
{
    public class AsteroidItem
    {
        [Key]
        [SwaggerIgnore]
        public int id { get; set; }

        public string name = null!;
        public string Name
        {
            get => name;
            set => name = value.ToLower();
        }

        public string type = null!;
        public string Type
        {
            get => type;
            set => type = value.ToLower()[0].ToString();
        }

        [SwaggerIgnore]
        public AsteroidProperty? asteroidProperty { get; set; }
    }
}
    