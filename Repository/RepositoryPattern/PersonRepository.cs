using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryPattern
{
    public class PersonRepository : IRepository<Person>
    {
        #region property  
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Person> persons;
        #endregion

        #region Constructor  
        public PersonRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            persons = _applicationDbContext.Persons;
        }
        #endregion

        public Person Get(int Id)
        {
            Person? Person = persons.FirstOrDefault(c => c.Id == Id);
            return Person == null ? new Person() : Person;
        }

        public IEnumerable<Person> GetAll() => persons;

        public void Insert(Person entity) => persons.Add(entity);

        public void Remove(Person entity) => persons.Remove(entity);

        public void Update(Person entity) => persons.Update(entity);

        public void Delete(Person entity)
        {
            persons.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges() => _applicationDbContext.SaveChanges();
    }
}
