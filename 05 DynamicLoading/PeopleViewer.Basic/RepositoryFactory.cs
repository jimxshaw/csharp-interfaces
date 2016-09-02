using PersonRepository.Interface;
using System;
using System.Configuration;

namespace PeopleViewer
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository()
        {
            // RepositoryType is the specific value we're looking for in our App.config file.
            // That contains the information we need to dynamically load the assembly.
            string typeName = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(typeName);
            // Activator gives back an instantiated service repository based on our current 
            // configuration. Cast that into an IPersonRepository.
            object repoInstance = Activator.CreateInstance(repoType);
            IPersonRepository repo = repoInstance as IPersonRepository;

            return repo;
        }
    }
}
