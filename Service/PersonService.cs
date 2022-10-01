using Domain.Models;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PersonService : IService<Person>
    {
        readonly IRepository<Person> repository;

        public PersonService(IRepository<Person> repository) => this.repository = repository;

        public void Delete(int id)
        {
            Person person = repository.Get(id);
            repository.Delete(person);
        }

        public IEnumerable<Person> GetAll() => repository.GetAll();

        public Person Get(int id) => repository.Get(id);

        public void Insert(Person value)
        {
            repository.Insert(value);
            repository.SaveChanges();
        }

        public void Update(Person value)
        {
            repository.Update(value);
            repository.SaveChanges();
        }
    }
}
