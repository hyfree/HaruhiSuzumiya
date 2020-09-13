namespace HaruhiSuzumiya.APP.Models
{
    public class Animal
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string CoverImageUrl { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
