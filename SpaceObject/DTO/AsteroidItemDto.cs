namespace SpaceObject.DTO
{
    public class AsteroidItemDto
    {
        public string name { get; set; } = null!;
        //public string Name
        //{
        //    get
        //    {
        //        if (name == null || name == "None")
        //            return "None";
        //        return name.Replace(name[0], name.ToUpper()[0]);
        //    }
        //    set { name = value??"None"; }
        //}

        public string type { get; set; } = null!;
        //public string Type
        //{
        //    get => "class " + type;
        //    set { type = value != null ? value.ToUpper() : "None"; }
        //}
    }
}
