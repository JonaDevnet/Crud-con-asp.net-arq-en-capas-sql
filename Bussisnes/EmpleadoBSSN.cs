using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Bussisnes
{
    public class EmpleadoBSSN
    {
        // instancia de EmpleadoData
        private readonly EmpleadoData _data;

        // Constructor que recibe EmpleadoData como dependencia
        public EmpleadoBSSN(EmpleadoData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data)); // validamos que no sea nulo
        }
        /// <summary>
        /// Metodo para listar los empleados
        /// </summary>
        /// <returns>Lista de empleados</returns>
        public async Task<List<Empleado>> Lista()
        {
            return await _data.Lista(); // Llama al método de la capa de datos
        }
        /// <summary>
        /// Metodo para crear empleados
        /// </summary>
        /// <param name="e"></param>
        /// <returns>true si se creo || False sino</returns>
        public async Task<bool> Crear(Empleado e)
        {
            return await _data.Crear(e); // Llama al método de la capa de datos
        }
        /// <summary>
        /// Metodo para editar
        /// </summary>
        /// <param name="e"></param>
        /// <returns>true si se creo || False sino</returns>
        public async Task<bool> Editar(Empleado e)
        {
            return await _data.Editar(e); // Llama al método de la capa de datos
        }
        /// <summary>
        /// Metodo para eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true si se creo || False sino</returns>
        public async Task<bool> Eliminar(int id)
        {
            return await _data.Eliminar(id); // Llama al método de la capa de datos
        }
    }
}
