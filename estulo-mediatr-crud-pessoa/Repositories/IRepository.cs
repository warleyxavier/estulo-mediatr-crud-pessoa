using System.Collections.Generic;

namespace estulo_mediatr_crud_pessoa.Repositories
{
    public interface IRepository<Person>
    {
        IEnumerable<Person> GetAll();
        Person Get(string id);
        void Save(Person person);
        void Update(Person person);
        void Delete(string id);
    }
}
