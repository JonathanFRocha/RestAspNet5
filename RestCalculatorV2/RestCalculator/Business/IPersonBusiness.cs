using RestPerson.Data.VO;
using System.Collections.Generic;

namespace RestPerson.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO peson);
        void Delete(long id);
    }
}
