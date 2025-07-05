# Prueba Técnica LAFISE

Es una API REST desarrollada para la evaluaciòn de conocimentos en .NET8 como parte del proceso de selecciòn para los candidatos a una plaza laboral.

La API esta orientada a la administraciòn basica de la cuentas bancarias de un cliente y el registro de transacciones asociadas a estas.

## Construcciòn e instalaciòn

### 1. Requerimientos

 - .NET8 SDK.
 - Entity Framework Core Tool.
 - Git.

### 2. Clonar el repositorio.

Clone el repositorio y acceda al directorio del proyecto.

```bash
git clone https://github.com/JonathanGuillenL/PruebaTecnicaLAFISE.git
cd PruebaTecnicaLAFISE
```
 
### 3. Ejecutar migraciòn de base de datos SQLite.

```bash
dotnet ef database update
```

### 4. Ejecutar el proyecto

Ejecute el proyecto con el siguiente comando:

```bash
dotnet run
```

Luego acceda al la URL (http://localhost:5096/swagger)[http://localhost:5096/swagger]