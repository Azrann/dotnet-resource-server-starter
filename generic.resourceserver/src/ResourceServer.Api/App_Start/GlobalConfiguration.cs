using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

namespace ResourceServer.Api.App_Start
{
    [ExcludeFromCodeCoverage]
    public static class GlobalConfiguration
    {
        public static HttpConfiguration Configuration { get; set; }
    }
}
