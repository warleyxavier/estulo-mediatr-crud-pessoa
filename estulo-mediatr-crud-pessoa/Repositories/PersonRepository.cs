using estulo_mediatr_crud_pessoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estulo_mediatr_crud_pessoa.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly List<Person> _persons = new();
        public void Delete(string id)
        {
            _persons.RemoveAll(p => p.Id == id);
        }

        public Person Get(string id)
        {
            return _persons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _persons;
        }

        public void Save(Person person)
        {
            _persons.Add(person);
        }

        public void Update(Person person)
        {
            Delete(person.Id);
            Save(person);
        }
    }
}
