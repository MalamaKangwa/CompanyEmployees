using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using System.Linq;

namespace Repository
{
    public class CompanyRepository: RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) 
            : base (repositoryContext) 
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToList();

        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges)
            .SingleOrDefault();


        public void CreateCompany(Company company) => Create(company);

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChnages) =>
            FindByCondition(x => ids.Contains(x.Id), trackChnages).ToList();

        public void DeleteCompany(Company company) { Delete(company); }
    }
}
