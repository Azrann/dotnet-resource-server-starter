**Languages:** [English](README.md) · [Español](README.es.md)

# dotnet-resource-server-starter

Example resource server with authentication and data access.

<!-- BEGIN project-context -->

## Historical dates and evidence

**Reference year for this version: 2015.** This uses the most recent source or configuration file with a recoverable historical date; the exact creation date could not be confirmed.

- Most recent datable file: **2015-07-26**, [`generic.resourceserver/src/ResourceServer.Domain/Services/ICompanyService.cs`](generic.resourceserver/src/ResourceServer.Domain/Services/ICompanyService.cs); date of the commit modifying the file, recovered from local Git history.
- First record in the original Git repository containing this code: **2015-07-24**. This may be an import and does not establish when the code was first written.
- Most recently published dependency among those checked: [Newtonsoft.Json 7.0.1](https://www.nuget.org/packages/Newtonsoft.Json/7.0.1), published on **2015-06-22** (declared version), in [`generic.resourceserver/src/ResourceServer.Host/packages.config`](generic.resourceserver/src/ResourceServer.Host/packages.config).
- Additional reference: target `v4.5.2` in [`generic.resourceserver/src/ResourceServer.Api/ResourceServer.Api.csproj`](generic.resourceserver/src/ResourceServer.Api/ResourceServer.Api.csproj); its [stable release was published on 2014-05-05](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). This indicates the technology generation; earlier preview releases may have existed.

A dependency's publication places the preserved configuration at or after that version, if the reference is valid. Package updates may be much newer than the project's beginnings. Packages were not restored to verify this.

October 2026 copy timestamps and documents generated during this review were excluded. Recoverable dates do not guarantee that there are no later, undated changes.

## Why this is worth exploring

Beyond the API/domain separation, the infrastructure describing service dependencies and startup status stands out. It is useful for exploring how a server can expose its requirements and initialization problems.

Code entry points:

- [`src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs`](generic.resourceserver/src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs)
- [`src/ResourceServer.SharedKernel/AppStart/ServiceHealth`](generic.resourceserver/src/ResourceServer.SharedKernel/AppStart/ServiceHealth/)
- [`src/ResourceServer.Api/Controllers/CompanyController.cs`](generic.resourceserver/src/ResourceServer.Api/Controllers/CompanyController.cs)

<!-- END project-context -->

## Contents

| Directory | Function |
| --- | --- |
| [`generic.resourceserver/`](generic.resourceserver/) | Web API/OWIN resource server starter with JWT authentication, a company example, and support for events, dependencies, and health status. |



## Requirements and setup

.NET Framework, Web API/OWIN, JWT, and SQL Server.

This is a historical copy. Consult each component's project files and README for versions and dependencies. Restore NuGet/npm from the appropriate folder; internal libraries may need rebuilding. Prepare databases and external services using your own accounts.

Preserved solutions:

- `generic.resourceserver/src/ResourceServer.sln`

## Configuration and security

Original secrets have been removed or replaced with `REPLACE_WITH_YOUR_VALUE`. Search for this marker before running and provide values through local configuration or environment variables. Sessions, private keys, signing certificates, databases, logs, deployment profiles, and binary packages are not published. The `.gitignore` protects these local files.

A fresh history is published: old commits remain only in the original local copy. Example values cannot connect to the original services.

## Validation status

A static review and secret scan were performed before publication. Applications, trading operations, deployments, and tests contacting external services were not run. Building with current tools is not guaranteed. Some projects need historical dependencies and assets that are not included.

## Licenses and provenance

Third-party licenses and attributions present in the code are retained. No blanket license is added to components that lacked one. This import preserves local sources and does not claim to be a current version of the original project.
