using RestCalculator.Model;
using RestPerson.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestPerson.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository

    {
        private MySQLContext _dbContext;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _dbContext = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _dbContext.Add(person);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            Person foundPerson = _dbContext.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if(foundPerson!= null)
            {
                try
                {
                    _dbContext.Persons.Remove(foundPerson);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Person> FindAll()
        {
            return _dbContext.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _dbContext.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;
            Person foundPerson = _dbContext.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if(foundPerson != null)
            {
                try
                {
                    _dbContext.Entry(foundPerson).CurrentValues.SetValues(person);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public bool Exists(long id)
        {
            return _dbContext.Persons.Any(p => p.Id == id);
        }
    }
}
