using System.Collections.Generic;
using ResourceServer.BoundedContext.Entities;

namespace ResourceServer.BoundedContext.Services
{
    public interface ICompanyService
    {
        void AddCompany(Company company);
        IEnumerable<Company> GetAll();
    }
}
