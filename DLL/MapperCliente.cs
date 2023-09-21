using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace DLL
{
    public class MapperCliente
    {
        private Acceso ac = new Acceso();

        public List<Cliente> Listar() 
        {
            List<Cliente> clientes = new List<Cliente>();
            ac.AbrirConn();
            DataTable tabla = ac.Leer("cliente_listar");
            ac.CerrarConn();

            foreach (DataRow registro in tabla.Rows) 
            {
                Cliente cliente = new Cliente();
                cliente.ID = int.Parse(registro["id_cliente"].ToString());
                cliente.Nombre = registro["nombre"].ToString();
                cliente.Apellido = registro["apellido"].ToString();
                cliente.Borrado = int.Parse(registro["borrado"].ToString());
                clientes.Add(cliente);
            }
            return clientes;
        }

        public int Insertar(Cliente cl) 
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(ac.CrearParametro("@nom", cl.Nombre));
            parametros.Add(ac.CrearParametro("@ape", cl.Apellido));
            ac.AbrirConn();
            int resultado = ac.Escribir("cliente_insertar", parametros);
            ac.CerrarConn();
            return resultado;
        }

        public int Modificar(Cliente cl)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(ac.CrearParametro("@id", cl.ID));
            parametros.Add(ac.CrearParametro("@b", cl.Borrado));
            parametros.Add(ac.CrearParametro("@nom", cl.Nombre));
            parametros.Add(ac.CrearParametro("@ape", cl.Apellido));
            ac.AbrirConn();
            int resultado = ac.Escribir("cliente_editar", parametros);
            ac.CerrarConn();
            return resultado;
        }

    }
}