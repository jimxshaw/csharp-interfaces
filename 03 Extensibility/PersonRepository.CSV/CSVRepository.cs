using PersonRepository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace PersonRepository.CSV
{
    public class CSVRepository : IPersonRepository
    {
        string path;

        public CSVRepository()
        {
            var filename = ConfigurationManager.AppSettings["CSVFileName"];
            path = AppDomain.CurrentDomain.BaseDirectory + filename;
        }

        public IEnumerable<Person> GetPeople()
        {
            // We open a text file using a StreamReader on it to go through each 
            // line one at a time. We parse that line based on commas as separators. 
            // We turn those into person objects and then we put that into a list of 
            // person that we can return back from the method. 
            var people = new List<Person>();

            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var elems = line.Split(',');
                    var per = new Person()
                    {
                        FirstName = elems[0],
                        LastName = elems[1],
                        StartDate = DateTime.Parse(elems[2]),
                        Rating = Int32.Parse(elems[3])
                    };
                    people.Add(per);
                }
            }
            return people;
        }

        public Person GetPerson(string lastName)
        {
            Person selPerson = new Person();
            if (File.Exists(path))
            {
                var sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var elems = line.Split(',');
                    if (elems[1].ToLower() == lastName.ToLower())
                    {
                        selPerson.FirstName = elems[0];
                        selPerson.LastName = elems[1];
                        selPerson.StartDate = DateTime.Parse(elems[2]);
                        selPerson.Rating = Int32.Parse(elems[3]);
                    }
                }
            }

            return selPerson;
        }

        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            throw new NotImplementedException();
        }
    }
}
