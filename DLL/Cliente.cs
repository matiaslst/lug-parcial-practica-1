using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLL
{
    public class Cliente
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string apellido;

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}

		private int borrado;

		public int Borrado
		{
			get { return borrado; }
			set { borrado = value; }
		}

        public override string ToString()
        {
			return nombre + " " + apellido;
        }

		// BLL

		private MapperCliente mapper = new MapperCliente();

		public List<Cliente> Listar() 
		{
			return mapper.Listar();
		}

		public void Grabar(Cliente cliente) 
		{
			if (cliente.ID == 0)
			{
				mapper.Insertar(cliente);
			}
			else 
			{
				mapper.Modificar(cliente);
			}
		}

	}
}