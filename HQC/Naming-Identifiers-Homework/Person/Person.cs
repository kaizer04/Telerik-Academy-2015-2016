namespace Person
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, int age, Gender gender)
            : this()
        {
            this.Gender = gender;
            this.Name = name;
            this.Age = age;
        }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Person CreatePerson(int age)
        {
            var person = new Person();

            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Gender = Gender.Female;
            }

            return person;
        }
    }
}
