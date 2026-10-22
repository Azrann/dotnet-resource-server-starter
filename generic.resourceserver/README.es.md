**Languages:** [English](Readme.md) · [Español](README.es.md)

# generic.resourceserver

Base de servidor de recursos Web API/OWIN con autenticación JWT, un ejemplo de empresas y soporte de eventos, dependencias y estado de salud.

Documentación basada en los archivos locales revisados el 21 de octubre de 2026.

<!-- BEGIN project-context -->

## Antigüedad y evidencia

**Año de referencia de esta versión: 2015.** Se toma el archivo de código o configuración más reciente con una fecha histórica recuperable; no se ha podido confirmar la fecha exacta de creación.

- Archivo más reciente datable: **2015-07-26**, [`generic.resourceserver/src/ResourceServer.Domain/Services/ICompanyService.cs`](src/ResourceServer.Domain/Services/ICompanyService.cs); fecha del commit que modificó el archivo, recuperada del Git local.
- Primer registro del repositorio Git original que contiene este código: **2015-07-24**. Puede corresponder a una importación; no prueba cuándo se escribió por primera vez.
- Dependencia fechada más reciente entre las comprobadas: [Newtonsoft.Json 7.0.1](https://www.nuget.org/packages/Newtonsoft.Json/7.0.1), publicada el **2015-06-22** (versión declarada), en [`generic.resourceserver/src/ResourceServer.Host/packages.config`](src/ResourceServer.Host/packages.config).
- Referencia adicional: destino `v4.5.2` en [`generic.resourceserver/src/ResourceServer.Api/ResourceServer.Api.csproj`](src/ResourceServer.Api/ResourceServer.Api.csproj); su [versión estable se publicó el 2014-05-05](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). Es una pista de generación tecnológica; pudieron existir versiones preliminares anteriores.

La publicación de una dependencia sitúa la configuración conservada a partir de esa versión, si la referencia es válida. Una actualización de paquetes puede ser mucho más reciente que el inicio del proyecto. No se restauraron paquetes para comprobarlo.

Se descartaron las marcas de tiempo de la copia de octubre de 2026 y los documentos generados durante esta revisión. Las fechas recuperables no garantizan que no existan cambios posteriores sin datar.

## Por qué merece la pena mirarlo

Además de la separación API/dominio, destaca la infraestructura que describe dependencias de servicios y su estado de arranque. Es útil para explorar cómo un servidor puede hacer visibles sus requisitos y problemas de inicialización.

Puntos de entrada al código:

- [`src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs`](src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs)
- [`src/ResourceServer.SharedKernel/AppStart/ServiceHealth`](src/ResourceServer.SharedKernel/AppStart/ServiceHealth/)
- [`src/ResourceServer.Api/Controllers/CompanyController.cs`](src/ResourceServer.Api/Controllers/CompanyController.cs)

<!-- END project-context -->

## Estructura y responsabilidades

| Ruta | Responsabilidad |
| --- | --- |
| `src/ResourceServer.Api/` | Arranque, OAuthConfiguration y controladores Company/Version. |
| `src/ResourceServer.Domain/` | CompanyContext, entidad Company y CompanyService. |
| `src/ResourceServer.SharedKernel/` | Eventos de dominio, contratos, dependencias, estado de salud e integración Windsor. |
| `src/ResourceServer.Host/` | Host IIS. |

## Tecnologías y requisitos

Windows, Visual Studio/MSBuild, .NET Framework 4.5.2 y paquetes NuGet de ASP.NET Web API/OWIN y Castle Windsor. SQL y mensajería según la configuración.

Destinos leídos de los proyectos: `v4.5.2`.

## Preparación y arranque

Abrir la solución de src, restaurar NuGet y seleccionar ResourceServer.Host en IIS Express.

Soluciones presentes: `src/ResourceServer.sln`.

## Configuración e integraciones

App.config de la API y Web.config del host contienen conexión al bus y JWT.Secret. Sustituir esos valores y definir un emisor de tokens propio.

## Estado de esta copia

Comparte patrones con DaysOn, pero su integración dentro de esa aplicación no está confirmada.

La revisión fue estática: no se restauraron dependencias, no se compiló ni se ejecutaron aplicaciones o pruebas. Los comandos anteriores son instrucciones de preparación, no resultados de validación. Las versiones indicadas son las del código conservado.


## Copia pública

Las credenciales originales se han retirado o sustituido por `REPLACE_WITH_YOUR_VALUE`. Los datos locales, sesiones, certificados privados y perfiles de despliegue se omiten. Configurar servicios y credenciales propios antes de ejecutar. La compilación y el funcionamiento con servicios externos no se han validado.
