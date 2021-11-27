using estulo_mediatr_crud_pessoa.Models.Enumerators;
using MediatR;

namespace estulo_mediatr_crud_pessoa.Commands
{
    public class CreatePersonCommand : IRequest<Unit>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Sexo Sexo { get; set; }

        public CreatePersonCommand(string id, string name, int age, Sexo sexo)
        {
            Id = id;
            Name = name;
            Age = age;
            Sexo = sexo;
        }
    }
}
