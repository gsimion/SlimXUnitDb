namespace SampleApp.Objects
{
    public class AppPerson
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public AppPerson()
        {
        }

        public AppPerson(int id, string name)
            : this()
        {
            Name = name;
            Id = id;
        }
    }
}
