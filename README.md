# 🎉 Proyecto CRUD con Arquitectura en Capas y Web API en C# 🎉

¡Bienvenido al proyecto CRUD desarrollado con C#, una Web API y una arquitectura en capas robusta! Este proyecto incluye una base de datos construida en SQL Server y presenta una implementación clara y modular del patrón de arquitectura en capas.

## 📋 Descripción del Proyecto

Este proyecto se enfoca en construir un sistema CRUD (Crear, Leer, Actualizar, Eliminar) usando:

- **C# y .NET**: Para la lógica de negocio y la API.
- **Web API**: Para la exposición de servicios HTTP.
- **SQL Server**: Para la persistencia de datos.
- **Arquitectura en Capas**: Para una estructura de código limpia, mantenible y escalable.

## 🏗️ Estructura de la Arquitectura en Capas

El proyecto se organiza en las siguientes capas:

1. **Capa de Datos (Data Layer)**: Maneja todas las interacciones con la base de datos utilizando procedimientos almacenados, sentencias SQL, etc.
2. **Capa de Negocio (Business Layer)**: Contiene la lógica de negocio y se comunica con la capa de datos.
3. **Capa de Presentación (Presentation Layer)**: En este caso, es la Web API que expone los endpoints CRUD al usuario.

## 🌐 Endpoints de la Web API

- **GET** `/api/`: Obtiene una lista de entidades.
- **POST** `/api/`: Crea una nueva entidad.
- **PUT** `/api/{id}`: Actualiza una entidad existente.
- **DELETE** `/api/{id}`: Elimina una entidad específica.

## 🗄️ Creando la Base de Datos en SQL Server

Para configurar la base de datos, sigue las instrucciones a continuación:

### 1️⃣ Creación de la Base de Datos

```sql
create database DbCrudNet8

go
```
### 2️⃣ Creación de la Tablas

```sql
create table Departamento(
IdDepartamento int primary key identity(1,1),
Nombre varchar(50)
)

create table Empleado(
IdEmpleado int primary key identity(1,1),
NombreCompleto varchar(50),
IdDepartamento int references Departamento(IdDepartamento),
Sueldo decimal(10,2),
FechaContrato date,
)

```
### 3️⃣ Creación de Procedimientos Almacenados
📄 Procedimiento para Insertar una Nuevas Entidades

```sql
insert into Departamento (Nombre) values
('Administracion'),
('Marketing')
insert into Empleado (NombreCompleto,IdDepartamento,Sueldo,FechaContrato) 
values
('Maria Mendez',1,4500,'2024-01-12')
--- Pueden generar mas datos, en mi caso con uno me bastó
```
📄 Procedimiento para listar los empleados

```sql
create procedure sp_listaEmpleados
as
begin
	select
	e.IdEmpleado as ID,
	e.NombreCompleto as [Nombre Completo],
	e.Sueldo,
	convert(char(10),e.FechaContrato,103) as [Fecha Contrato],
	d.IdDepartamento as [ID Departamento],
	d.Nombre
	from Empleado e
	inner join Departamento d on e.IdDepartamento = d.IdDepartamento
end

```
📄 Procedimiento para crear un empleado
```sql
create procedure sp_crearEmpleado
(
	@NombreCompleto varchar(50),
	@IdDepartamento int,
	@Sueldo decimal(10,2),
	@FechaContrato varchar(10) --DD/MM/YY
)
as
begin
	set dateformat dmy --definimos el formato

	insert into Empleado(
	NombreCompleto,
	IdDepartamento,
	Sueldo,
	FechaContrato
	)
	values(
	@NombreCompleto,
	@IdDepartamento,
	@Sueldo,
	convert(date,@FechaContrato,103)
	)
end
```
📄 Procedimiento para editar los empleados

```sql
create procedure sp_editarEmpleado
(
	@IdEmpleado int,
	@NombreCompleto varchar(50),
	@IdDepartamento int,
	@Sueldo decimal(10,2),
	@FechaContrato varchar(10) --DD/MM/YY
)
as
begin
	set dateformat dmy --definimos el formato

	update Empleado
	set
	NombreCompleto = @NombreCompleto,
	IdDepartamento = @IdDepartamento,
	Sueldo = @Sueldo,
	FechaContrato = convert(date,@FechaContrato,103)
	where IdEmpleado = @IdEmpleado
end
```

📄 Procedimiento para eliminar los empleados
```sql
create procedure sp_eliminarEmpleado
(
	@IdEmpleado int
)
as
begin
	delete from Empleado where IdEmpleado = @IdEmpleado
end
```

## 🛠️ Tecnologías y Herramientas Utilizadas

- **C# / .NET Core**
- **Entity Framework Core** (opcional)
- **SQL Server**
- **Swagger** (para la documentación de la API)

## 🚀 Instrucciones de Configuración

- Clona este repositorio.
- Configura la cadena de conexión en el archivo de configuración de la API (`appsettings.json`).
- Ejecuta el script SQL para crear la base de datos y las tablas.
- Compila y ejecuta la API.

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Si deseas mejorar este proyecto, sigue estos pasos:

- Haz un fork del repositorio.
- Crea una nueva rama (`git checkout -b feature/nuevaCaracteristica`).
- Realiza tus cambios.
- Haz un commit de tus cambios (`git commit -am 'Añadir nueva característica'`).
- Empuja la rama (`git push origin feature/nuevaCaracteristica`).
- Abre un Pull Request.

## 📝 Licencia

Este proyecto está bajo la Licencia MIT - mira el archivo [LICENSE](./LICENSE) para más detalles.








