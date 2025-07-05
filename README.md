# Prueba T�cnica LAFISE

Es una API REST desarrollada para la evaluaci�n de conocimentos en .NET8 como parte del proceso de selecci�n para los candidatos a una plaza laboral.

La API esta orientada a la administraci�n basica de la cuentas bancarias de un cliente y el registro de transacciones asociadas a estas.

## Construcci�n e instalaci�n

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
 
### 3. Ejecutar migraci�n de base de datos SQLite.

```bash
dotnet ef database update
```

### 4. Ejecutar el proyecto

Ejecute el proyecto con el siguiente comando:

```bash
dotnet run
```

Luego acceda al la URL [http://localhost:5096/swagger](http://localhost:5096/swagger)