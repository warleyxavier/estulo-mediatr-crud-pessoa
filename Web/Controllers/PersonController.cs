using estulo_mediatr_crud_pessoa.Commands;
using estulo_mediatr_crud_pessoa.Models;
using estulo_mediatr_crud_pessoa.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.Requestes;

namespace Web.Controllers
{
    [ApiController]
    [Route("/person")]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IMediator _mediator;

        public PersonController(IRepository<Person> personRepository, IMediator mediator)
        {
            _personRepository = personRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_personRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_personRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonRequest request)
        {
            var id = Guid.NewGuid().ToString();

            var command = new CreatePersonCommand(id, request.Name, request.Age, request.Sexo);

            await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] string id,[FromBody] UpdatePersonRequest request)
        {
            var command = new UpdatePersonCommand(id, request.Name, request.Age, request.Sexo);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var obj = new DeletePersonCommand(id);

            await _mediator.Send(obj);

            return Ok();
        }

    }
}
