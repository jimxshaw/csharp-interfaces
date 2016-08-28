using PersonRepository.Interface;
using System.Collections.Generic;

namespace PersonRespository.Service
{
    public class ServiceRepository : IPersonRepository
    {
        public void AddPerson(Person newPerson)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Person> GetPeople()
        {
            throw new System.NotImplementedException();
        }

        public Person GetPerson(string lastName)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new System.NotImplementedException();
        }
    }
}
