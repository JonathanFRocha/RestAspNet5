using RestCalculator.Model;
using System.Collections.Generic;

namespace RestPerson.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person peson);
        void Delete(long id);
        bool Exists(long id);
    }
}
