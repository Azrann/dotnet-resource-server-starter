using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;

namespace ResourceServer.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    public class VersionController : ApiController
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        [Route("version")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAsync()
        {
            _logger.Debug("Version method called.");
            return await Task.Run(
                () =>
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                    return Ok(fileVersionInfo.FileVersion);
                });
        }
    }
}
