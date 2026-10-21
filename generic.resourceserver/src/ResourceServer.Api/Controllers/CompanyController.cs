using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using ResourceServer.BoundedContext.Entities;
using ResourceServer.BoundedContext.Services;
using log4net;

namespace ResourceServer.Api.Controllers
{
    public class CompanyController : ApiControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [AllowAnonymous]
        [Route("company/create")]
        [HttpGet]
        public async Task<IHttpActionResult> Create()
        {
            _companyService.AddCompany(new Company(Guid.NewGuid())
                {
                    Name = "BAT",
                    Teams = new List<string>() {"Alpha","Beta"}
                });
            return Ok();
        }
    }
}
