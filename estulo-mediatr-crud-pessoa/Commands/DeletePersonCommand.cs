using MediatR;

namespace estulo_mediatr_crud_pessoa.Commands
{
    public class DeletePersonCommand : IRequest<Unit>
    {
        public string Id { get; set; }

        public DeletePersonCommand(string id)
        {
            Id = id;
        }
    }
}
