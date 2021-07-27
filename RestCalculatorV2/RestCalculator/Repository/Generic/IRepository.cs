using RestPerson.Model.Base;
using System.Collections.Generic;

namespace RestPerson.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T person);
        T FindById(long id);
        List<T> FindAll();
        T Update(T peson);
        void Delete(long id);
        bool Exists(long id);
    }
}
