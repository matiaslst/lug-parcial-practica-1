using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DLL
{
    public class MapperCompra
    {
        private Acceso ac = new Acceso();

        public void EstablecerID(Compra com) 
        {
            ac.AbrirConn();
            com.ID = ac.LeerEscalar("SiguienteCompra"); 
            ac.CerrarConn();
        }

        public void Insertar(Compra com) 
        {
            ac.AbrirConn();
            ac.IniciarTX();
            bool error = false;
            foreach (Item i in com.Detalle) 
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(ac.CrearParametro("@id",com.ID));
                parametros.Add(ac.CrearParametro("@id_c",com.Cliente.ID));
                parametros.Add(ac.CrearParametro("@id_p",i.Producto.ID));
                parametros.Add(ac.CrearParametro("@c", i.Cantidad));

                if (ac.Escribir("InsertarCompra", parametros) == -1) 
                {
                    error = true;
                }
            }
            if (!error)
            {
                ac.ConfirmarTX();
            }
            else {
            ac.RollbackTX();
            }
            ac.CerrarConn();
        }
    }
}