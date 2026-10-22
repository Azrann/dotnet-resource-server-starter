**Languages:** [English](README.md) · [Español](README.es.md)

# dotnet-resource-server-starter

Servidor de recursos de ejemplo con autenticación y acceso a datos.

<!-- BEGIN project-context -->

## Antigüedad y evidencia

**Año de referencia de esta versión: 2015.** Se toma el archivo de código o configuración más reciente con una fecha histórica recuperable; no se ha podido confirmar la fecha exacta de creación.

- Archivo más reciente datable: **2015-07-26**, [`generic.resourceserver/src/ResourceServer.Domain/Services/ICompanyService.cs`](generic.resourceserver/src/ResourceServer.Domain/Services/ICompanyService.cs); fecha del commit que modificó el archivo, recuperada del Git local.
- Primer registro del repositorio Git original que contiene este código: **2015-07-24**. Puede corresponder a una importación; no prueba cuándo se escribió por primera vez.
- Dependencia fechada más reciente entre las comprobadas: [Newtonsoft.Json 7.0.1](https://www.nuget.org/packages/Newtonsoft.Json/7.0.1), publicada el **2015-06-22** (versión declarada), en [`generic.resourceserver/src/ResourceServer.Host/packages.config`](generic.resourceserver/src/ResourceServer.Host/packages.config).
- Referencia adicional: destino `v4.5.2` en [`generic.resourceserver/src/ResourceServer.Api/ResourceServer.Api.csproj`](generic.resourceserver/src/ResourceServer.Api/ResourceServer.Api.csproj); su [versión estable se publicó el 2014-05-05](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-framework). Es una pista de generación tecnológica; pudieron existir versiones preliminares anteriores.

La publicación de una dependencia sitúa la configuración conservada a partir de esa versión, si la referencia es válida. Una actualización de paquetes puede ser mucho más reciente que el inicio del proyecto. No se restauraron paquetes para comprobarlo.

Se descartaron las marcas de tiempo de la copia de octubre de 2026 y los documentos generados durante esta revisión. Las fechas recuperables no garantizan que no existan cambios posteriores sin datar.

## Por qué merece la pena mirarlo

Además de la separación API/dominio, destaca la infraestructura que describe dependencias de servicios y su estado de arranque. Es útil para explorar cómo un servidor puede hacer visibles sus requisitos y problemas de inicialización.

Puntos de entrada al código:

- [`src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs`](generic.resourceserver/src/ResourceServer.SharedKernel/AppStart/ServiceDependency/ServiceDependencyContainer.cs)
- [`src/ResourceServer.SharedKernel/AppStart/ServiceHealth`](generic.resourceserver/src/ResourceServer.SharedKernel/AppStart/ServiceHealth/)
- [`src/ResourceServer.Api/Controllers/CompanyController.cs`](generic.resourceserver/src/ResourceServer.Api/Controllers/CompanyController.cs)

<!-- END project-context -->

## Contenido

| Directorio | Función |
| --- | --- |
| [`generic.resourceserver/`](generic.resourceserver/) | Base de servidor de recursos Web API/OWIN con autenticación JWT, un ejemplo de empresas y soporte de eventos, dependencias y estado de salud. |



## Requisitos y preparación

.NET Framework, Web API/OWIN, JWT y SQL Server.

Esta es una copia histórica. Consultar los archivos de proyecto y los README de cada componente para sus versiones y dependencias. Restaurar NuGet/npm desde la carpeta correspondiente; las bibliotecas internas pueden necesitar reconstrucción. Preparar las bases de datos y los servicios externos con cuentas propias.

Soluciones conservadas:

- `generic.resourceserver/src/ResourceServer.sln`

## Configuración y seguridad

Los secretos originales se han eliminado o sustituido por `REPLACE_WITH_YOUR_VALUE`. Buscar este marcador antes de ejecutar y aportar los valores mediante configuración local o variables de entorno. Las sesiones, claves privadas, certificados de firma, bases de datos, registros, perfiles de despliegue y paquetes binarios no se publican. El `.gitignore` protege estos archivos locales.

Se publica un historial nuevo: los commits antiguos permanecen únicamente en la copia local original. Los valores de ejemplo no permiten conectarse a los servicios originales.

## Estado de validación

Se realizó una revisión estática y un escaneo de secretos antes de publicar. No se ejecutaron aplicaciones, operaciones de trading, despliegues ni pruebas que contacten servicios externos. No se garantiza la compilación con herramientas actuales. Algunos proyectos necesitan dependencias históricas y activos que no están incluidos.

## Licencias y procedencia

Se conservan las licencias y atribuciones de terceros presentes en el código. No se añade una licencia global a los componentes que no la tenían. Esta importación conserva fuentes locales y no afirma ser una versión actual del proyecto original.
