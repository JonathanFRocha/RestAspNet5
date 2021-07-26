using RestCalculator.Model;
using System.Collections.Generic;

namespace RestPerson.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person peson);
        void Delete(long id);
    }
}
