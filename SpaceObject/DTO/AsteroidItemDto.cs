namespace SpaceObject.DTO
{
    public class AsteroidItemDto
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
            //set { name = value ?? "None"; }
        }

        public string type = null!;
        public string Type
        {
            get => "class " + type.ToUpper();
            //set { type = value != null ? value.ToLower() : "None"; }
        }
    }
}
