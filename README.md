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

- **GET** `/api/entidad`: Obtiene una lista de entidades.
- **POST** `/api/entidad`: Crea una nueva entidad.
- **PUT** `/api/entidad/{id}`: Actualiza una entidad existente.
- **DELETE** `/api/entidad/{id}`: Elimina una entidad específica.

## 🗄️ Creando la Base de Datos en SQL Server

Para configurar la base de datos, sigue las instrucciones a continuación:

### 1️⃣ Creación de la Base de Datos

```sql
CREATE DATABASE MiBaseDeDatos;
GO
```
### 2️⃣ Creación de la Tabla de Ejemplo

```sql

```
3️⃣ Creación de Procedimientos Almacenados
📄 Procedimiento para Obtener Todas las Entidades

```sql

```
📄 Procedimiento para Insertar una Nueva Entidad

```sql

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








