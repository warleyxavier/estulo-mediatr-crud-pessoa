using estulo_mediatr_crud_pessoa.Models.Enumerators;

namespace estulo_mediatr_crud_pessoa.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Sexo Sexo { get; set; }

        public Person(string id, string name, int age, Sexo sexo)
        {
            Id = id;
            Name = name;
            Age = age;
            Sexo = sexo;
        }
    }
}
