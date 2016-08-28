using PersonRepository.Interface;
using PersonRespository.Service.MyService;
using System.Collections.Generic;
using System.Linq;

namespace PersonRespository.Service
{
    // This ServiceRepository class simply serves as a pass-thru to the WCF service data layer.
    public class ServiceRepository : IPersonRepository
    {
        PersonServiceClient serviceProxy = new PersonServiceClient();

        public void AddPerson(Person newPerson)
        {
            serviceProxy.AddPerson(newPerson);
        }

        public IEnumerable<Person> GetPeople()
        {
            return serviceProxy.GetPeople();
        }

        public Person GetPerson(string lastName)
        {
            return serviceProxy.GetPerson(lastName);
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            // Collections of type IEnumerable<T> can be converted to List<T> by
            // calling ToList on the collection. 
            serviceProxy.UpdatePeople(updatedPeople.ToList());
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            serviceProxy.UpdatePerson(lastName, updatedPerson);
        }

        public void DeletePerson(string lastName)
        {
            serviceProxy.DeletePerson(lastName);
        }
    }
}
