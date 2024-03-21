namespace EnteringProjectData.Models
{
    public class Person
    {
        public Person(string name, int age) 
        {
            Name = name;
            Age = age;
        }
        //public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}
