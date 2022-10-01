using Domain.Models;
using Repository.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class CompanyService : IService<Company>
    {
        readonly IRepository<Company> _repository;
        public CompanyService(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            Company person = _repository.Get(id);
            _repository.Delete(person);
        }

        public Company Get(int id) => _repository.Get(id);

        public IEnumerable<Company> GetAll() => _repository.GetAll();

        public void Insert(Company value)
        {
            _repository.Insert(value);
            _repository.SaveChanges();
        }

        public void Update(Company value)
        {
            _repository.Update(value);
            _repository.SaveChanges();
        }
    }
}
