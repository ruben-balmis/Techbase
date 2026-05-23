# TechBase Store
<img width="4000" height="4000" alt="logo" src="https://github.com/user-attachments/assets/02450e5e-0a3b-4d71-b58b-8b5d2717c80f" />

Proyecto desarrollado en ASP.NET Core MVC como tienda online de componentes gaming.

## Tecnologías utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap
- ASP.NET Identity

---

# Requisitos

Antes de ejecutar el proyecto es necesario tener instalado:

- Visual Studio 2022
- .NET 8 SDK
- SQL Server LocalDB

---

# Instalación de herramientas necesarias

## 1. Instalar Visual Studio 2022

Descargar desde:

https://visualstudio.microsoft.com/es/vs/

Durante la instalación seleccionar:

- ASP.NET and web development
- .NET desktop development

---

## 2. Instalar .NET 8 SDK

Descargar desde:

https://dotnet.microsoft.com/es-es/download/dotnet/8.0

Para comprobar que está instalado correctamente:

Abrir CMD y ejecutar:

```bash
dotnet --version
```

---

## 3. Instalar SQL Server LocalDB

Normalmente se instala automáticamente con Visual Studio.

Para comprobarlo:

Abrir CMD y ejecutar:

```bash
sqllocaldb info
```

Si no está instalado:

https://learn.microsoft.com/es-es/sql/database-engine/configure-windows/sql-server-express-localdb

---

## 4. Instalar Git

Descargar desde:

https://git-scm.com/downloads

Para comprobar instalación:

```bash
git --version
```

---

# Cómo descargar el proyecto desde GitHub

## Opción 1 — Visual Studio

1. Abrir Visual Studio
2. Seleccionar:

```plaintext
Clone a repository
```

3. Pegar la URL del repositorio GitHub
4. Elegir carpeta local
5. Pulsar:

```plaintext
Clone
```

---

## Opción 2 — Git CMD

Abrir CMD y ejecutar:

```bash
git clone URL_DEL_REPOSITORIO
```

---

# Configuración inicial del proyecto

Una vez descargado:

## 1. Abrir solución

Abrir:

```plaintext
TechBase.sln
```

---

## 2. Restaurar paquetes

Abrir:

```plaintext
Tools -> NuGet Package Manager -> Package Manager Console
```

Ejecutar:

```powershell
dotnet restore
```

---

## 3. Crear base de datos

En la consola NuGet ejecutar:

```powershell
Update-Database
```

---

## 4. Ejecutar proyecto

Pulsar:

```plaintext
F5
```

o:

```plaintext
Ctrl + F5
```

# Usuarios de prueba

## Administrador

```plaintext
Email: admin@techbase.com
Password: Admin123!
```

## Usuario normal

```plaintext
Email: usuario@techbase.com
Password: Usuario123!
```

---

# Funcionalidades implementadas

- Registro e inicio de sesión
- Roles de usuario y administrador
- Catálogo de productos
- Filtros por categoría
- Buscador de productos
- Carrito de compra
- Gestión de pedidos
- Historial de pedidos
- Panel de administración
- CRUD de productos
- Gestión de estados de pedidos
- Diseño responsive
- Home moderna con Hero Section y Carousel Bootstrap

---

# Notas importantes

- Las imágenes de productos se encuentran en:

```plaintext
wwwroot/images/productos
```

- El proyecto utiliza Entity Framework Core con migraciones.

- Los datos iniciales se cargan mediante SeedData.

- ---

# Solución de errores comunes

## Error al ejecutar `Update-Database`

### Error:

```plaintext
The ALTER TABLE statement conflicted with the FOREIGN KEY constraint
```

### Solución:

Eliminar la base de datos anterior y volver a ejecutar las migraciones.

Desde Visual Studio:

```plaintext
View -> SQL Server Object Explorer
```

Eliminar la base de datos del proyecto y ejecutar:

```powershell
Update-Database
```

---

## Error relacionado con `staticwebassets`

### Error:

```plaintext
System.IO.DirectoryNotFoundException
```

o errores relacionados con:

```plaintext
staticwebassets
identity.ui
```

### Solución:

1. Cerrar Visual Studio.
2. Eliminar las carpetas:

```plaintext
bin
obj
```

3. Abrir Visual Studio nuevamente.
4. Ejecutar:
   
```powershell
dotnet restore
```

---
