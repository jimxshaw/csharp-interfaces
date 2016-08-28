using System.Collections.Generic;

namespace PersonRepository.Interface
{
    public interface IPersonRepository
    {
        // CREATE
        void AddPerson(Person newPerson);

        // READ
        IEnumerable<Person> GetPeople();
        Person GetPerson(string lastName);

        // UPDATE
        void UpdatePeople(IEnumerable<Person> updatedPeople);
        void UpdatePerson(string lastName, Person updatedPerson);

        // DELETE
        void DeletePerson(string lastName);
    }
}
