using Finway.extantion;
using Finway.Models;
using Finway.Models.DTO;

namespace Finway.Interfaces
{
    public interface IPerson
    {
        GenericResponse<List<Person>> Getpeople();
        GenericResponse<Person> GetPersonById(int id);
        GenericResponse<Person> UpdatePerson(PersonDto person, int id);
        GenericResponse<Person> InsertPerson(PersonDto person);

    }
}
