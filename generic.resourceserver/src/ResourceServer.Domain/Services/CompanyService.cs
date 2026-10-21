using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using ResourceServer.BoundedContext.Entities;
using ResourceServer.SharedKernel.Repositories;

namespace ResourceServer.BoundedContext.Services
{
    [CastleComponent]
    public class CompanyService : ICompanyService
    {
        public IRepository<Company> Repository { get; set; }

        public void AddCompany(Company company)
        {
            Repository.Add(company);
            Repository.Save();
        }

        IEnumerable<Company> ICompanyService.GetAll()
        {
            return Repository.GetAll(x => true).ToList();
        }
    }
}
