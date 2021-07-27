using RestCalculator.Model;
using RestPerson.Model.Context;
using RestPerson.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestPerson.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness

    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

    }
}
