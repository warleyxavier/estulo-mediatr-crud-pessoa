using estulo_mediatr_crud_pessoa.Commands;
using estulo_mediatr_crud_pessoa.Models;
using estulo_mediatr_crud_pessoa.Notifications;
using estulo_mediatr_crud_pessoa.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace estulo_mediatr_crud_pessoa.CommandHandlers
{
    public class PersonCommandHandler :
        IRequestHandler<CreatePersonCommand, Unit>,
        IRequestHandler<UpdatePersonCommand, Unit>,
        IRequestHandler<DeletePersonCommand, Unit>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Person> _personRepository;

        public PersonCommandHandler(IRepository<Person> personRepository, IMediator mediator)
        {
            _personRepository = personRepository;
            _mediator = mediator;
        }

        public Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.Id, request.Name, request.Age, request.Sexo);

            _personRepository.Save(person);

            _mediator.Publish(new PersonCreatedNotification(person.Id));

            return Unit.Task;
        }

        public Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.Id, request.Name, request.Age, request.Sexo);

            _personRepository.Update(person);

            _mediator.Publish(new PersonUpdatedNotification(person.Id));

            return Unit.Task;
        }

        public Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _personRepository.Delete(request.Id);

            _mediator.Publish(new PersonDeletedNotification(request.Id));

            return Unit.Task;
        }
    }
}
