**Languages:** [English](Readme.md) · [Español](README.es.md)

# generic.resourceserver

Web API/OWIN resource server starter with JWT authentication, a company example, and support for events, dependencies, and health status.

Documentation based on local files reviewed on 21 October 2026.

<!-- BEGIN project-context -->

## Historical dates and evidence

**Reference year for this version: 2015.** This uses the most recent source or configuration file with a recoverable historical date; the exact creation date could not be confirmed.

- Most recent datable file: **2015-07-26**, [`generic.resourceserver/src/ResourceServer.Domain/Services/ICompanyService.cs`](src/ResourceServer.Domain/Services/ICompanyService.cs); date of the commit modifying the file, recovered from local Git history.
- First record in the original Git repository containing this code: **2015-07-24**. This may be an import and does not establish when the code was first written.
- Most recently published dependency among those checked: [Newtonsoft.Json 7.0.1](https://www.nuget.org/packages/Newtonsoft.Json/7.0.1), published on **2015-06-22** (declared version), in [`generic.resourceserver/src/ResourceServer.Host/packages.config`](src/ResourceServer.Host/packages.config).
- Additional reference: target `v4.5.2` in [`generic.resourceserver/src/ResourceServer.Api/ResourceServer.Api.csproj`](src/ResourceServer.Api/ResourceServer.Api.csproj); its [stable release was published on 2014-05-05](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). This indicates the technology generation; earlier preview releases may have existed.

A dependency's publication places the preserved configuration at or after that version, if the reference is valid. Package updates may be much newer than the project's beginnings. Packages were not restored to verify this.

October 2026 copy timestamps and documents generated during this review were excluded. Recoverable dates do not guarantee that there are no later, undated changes.

## Why this is worth exploring

Beyond the API/domain separation, the infrastructure describing service dependencies and startup status stands out. It is useful for exploring how a server can expose its requirements and initialization problems.

Code entry points:

- [`src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs`](src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs)
- [`src/ResourceServer.SharedKernel/AppStart/ServiceHealth`](src/ResourceServer.SharedKernel/AppStart/ServiceHealth/)
- [`src/ResourceServer.Api/Controllers/CompanyController.cs`](src/ResourceServer.Api/Controllers/CompanyController.cs)

<!-- END project-context -->

## Structure and responsibilities

| Path | Responsibility |
| --- | --- |
| `src/ResourceServer.Api/` | Startup, OAuthConfiguration, and Company/Version controllers. |
| `src/ResourceServer.Domain/` | CompanyContext, Company entity, and CompanyService. |
| `src/ResourceServer.SharedKernel/` | Domain events, contracts, dependencies, health status, and Windsor integration. |
| `src/ResourceServer.Host/` | IIS host. |

## Technologies and requirements

Windows, Visual Studio/MSBuild, .NET Framework 4.5.2, and NuGet packages for ASP.NET Web API/OWIN and Castle Windsor. SQL and messaging requirements depend on configuration.

Targets read from project files: `v4.5.2`.

## Setup and startup

Open the solution in src, restore NuGet packages, and select ResourceServer.Host in IIS Express.

Solutions present: `src/ResourceServer.sln`.

## Configuration and integrations

The API's App.config and host's Web.config contain a bus connection and JWT.Secret. Replace those values and configure your own token issuer.

## Status of this copy

Shares patterns with DaysOn, but integration into that application has not been confirmed.

The review was static: dependencies were not restored, and applications and tests were neither built nor run. The commands above are setup instructions, not validation results. Listed versions describe the preserved code.


## Public copy

Original credentials have been removed or replaced with `REPLACE_WITH_YOUR_VALUE`. Local data, sessions, private certificates, and deployment profiles are omitted. Configure your own services and credentials before running. Building and operation with external services have not been validated.
