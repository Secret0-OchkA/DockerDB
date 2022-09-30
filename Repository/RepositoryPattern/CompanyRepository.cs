using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepositoryPattern
{
    public class CompanyRepository : IRepository<Company>
    {
        #region property  
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<Company> companies;
        #endregion

        #region Constructor  
        public CompanyRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            companies = _applicationDbContext.Companies;
        }
        #endregion

        public Company Get(int Id)
        {
            Company? company = companies.FirstOrDefault(c => c.Id == Id);
            return company == null ? new Company() : company;
        }

        public IEnumerable<Company> GetAll() => companies;

        public void Insert(Company entity) => companies.Add(entity);

        public void Remove(Company entity) => companies.Remove(entity);

        public void Update(Company entity) => companies.Update(entity);

        public void Delete(Company entity)
        {
            companies.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges() => _applicationDbContext.SaveChanges();
    }
}
