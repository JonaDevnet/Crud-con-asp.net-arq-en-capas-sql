using Microsoft.Extensions.Options;
using System.Data;
using Models;
using System.Data.SqlClient;

namespace Data
{
    public class EmpleadoData
    {
        // instancia de la coneccion
        private readonly ConnectionStrings _conexiones;
        // constructor para proporcionar info de la cadena
        public EmpleadoData(IOptions<ConnectionStrings> options)
        {
            _conexiones = options.Value;
        }
        /// <summary>
        /// Listar empleados
        /// </summary>
        /// <returns>List Empleados</returns>
        public async Task<List<Empleado>> Lista()
        {
            List<Empleado> listaEmpleado = new List<Empleado>();

            try
            {
                using (var conexion = new SqlConnection(_conexiones.CadenaSQL))
                {
                    await conexion.OpenAsync();
                    SqlCommand cmd = new SqlCommand("sp_listaEmpleados", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No se encontraron filas.");
                        }

                        while (reader.Read())
                        {
                            listaEmpleado.Add(new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(reader["ID"]),
                                NombreCompleto = reader["Nombre Completo"].ToString(),
                                Sueldo = Convert.ToDecimal(reader["Sueldo"]),
                                FechaContrato = reader["Fecha Contrato"].ToString(),
                                Departamento = new Departamento
                                {
                                    IdDepartamento = Convert.ToInt32(reader["ID Departamento"]),
                                    Nombre = reader["Nombre"].ToString()
                                }
                            });
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return listaEmpleado;
        }
        /// <summary>
        /// Crear Empleado
        /// </summary>
        /// <param name="e"></param>
        /// <returns>True or false</returns>
        public async Task<bool> Crear(Empleado e)
        {     
            bool respuesta = true;

            if (e == null || e.NombreCompleto == null || e.Departamento.IdDepartamento == 0 || e.Sueldo == 0 || e.FechaContrato == string.Empty) 
                return false;

            using (var conexion = new SqlConnection(_conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("sp_crearEmpleado", conexion);
                cmd.Parameters.AddWithValue("@NombreCompleto", e.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", e.Departamento!.IdDepartamento); /// ! negamos la posibilidad de que sea nulo
                cmd.Parameters.AddWithValue("@Sueldo", e.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", e.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;/// Tipo de comando

                try
                {
                    await conexion.OpenAsync(); /// esperamos la coneccion
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false; /// true si se modifican las filas
                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Editar empleado
        /// </summary>
        /// <param name="e"></param>
        /// <returns>true or false</returns>
        public async Task<bool> Editar(Empleado e)
        {
            bool respuesta = true;

            if (e == null || e.NombreCompleto == null || e.Departamento.IdDepartamento == 0 || e.Sueldo == 0 || e.FechaContrato == string.Empty)
                return false;


            using (var conexion = new SqlConnection(_conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("sp_editarEmpleado", conexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", e.IdEmpleado);
                cmd.Parameters.AddWithValue("@NombreCompleto", e.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", e.Departamento!.IdDepartamento); /// ! negamos la posibilidad de que sea nulo
                cmd.Parameters.AddWithValue("@Sueldo", e.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", e.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;/// Tipo de comando

                try
                {
                    await conexion.OpenAsync(); /// esperamos la coneccion
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false; /// true si se modifica
                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Eliminar empleado
        /// </summary>
        /// <param name="idE"></param>
        /// <returns>true or false</returns>
        public async Task<bool> Eliminar(int idE)
        {
            bool respuesta = true;
            if (idE == 0) return false;

            using (var conexion = new SqlConnection(_conexiones.CadenaSQL))
            {
                SqlCommand cmd = new SqlCommand("sp_eliminarEmpleado", conexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", idE);
                cmd.CommandType = CommandType.StoredProcedure;/// Tipo de comando

                try
                {
                    await conexion.OpenAsync(); /// esperamos la coneccion
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false; /// true si se modifica
                }
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

    }
}
