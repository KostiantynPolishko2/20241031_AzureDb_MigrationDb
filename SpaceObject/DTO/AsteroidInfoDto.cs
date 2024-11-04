using SpaceObject.Entities;

namespace SpaceObject.DTO
{
    public class AsteroidInfoDto
    {
        public string name = null!;
        public string Name
        {
            get
            {
                if (name == null || name == "None")
                    return "None";
                return name.Replace(name[0], name.ToUpper()[0]);
            }
            set { name = value ?? "None"; }
        }

        public string category = null!;
        public string Category
        {
            get => "class " + category.ToUpper();
            set { category = value != null ? value.ToUpper() : "None"; }
        }

        public int size { get; set; }
        public float weight { get; set; }
        public float speed { get; set; }

        public AsteroidInfoDto() { }

        public AsteroidInfoDto(AsteroidProperty? asteroidProperty)
        {
            this.size = asteroidProperty!.size;
            this.weight = asteroidProperty.weight;
            this.speed = asteroidProperty.speed;
        }
    }
}
