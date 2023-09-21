using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DLL
{
    internal class Acceso
    {
        private SqlConnection conn;
        private SqlTransaction tx;

        public void AbrirConn() 
        {
            conn = new SqlConnection(@"Integrated Security = SSPI; Initial Catalog = PARCIAL; Data Source = DESKTOP-7UJG3GT\SQLEXPRESS");
            conn.Open();
        }

        public void CerrarConn() 
        {
            conn.Close();
            conn = null;
            GC.Collect();
        }

        public void IniciarTX() 
        {
            tx = conn.BeginTransaction();
        }

        public void ConfirmarTX() 
        {
            tx.Commit();
            tx = null;
        }

        public void RollbackTX() 
        {
            tx.Rollback();
            tx = null;
        }

        private SqlCommand CrearComando(string sp, List<SqlParameter> parametros = null) 
        {
            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parametros != null) 
            {
                cmd.Parameters.AddRange(parametros.ToArray());
            }
            if (tx != null) 
            {
                cmd.Transaction = tx;
            }
            return cmd;
        }

        public DataTable Leer(string sp, List<SqlParameter> parametros = null) 
        {
            DataTable tabla = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter()) 
            {
                da.SelectCommand = CrearComando(sp, parametros);
                da.Fill(tabla);
                da.Dispose();
            } 
            return tabla;
        }

        public int LeerEscalar(string sp, List<SqlParameter> parametros = null) 
        {
            int resultado;
            SqlCommand cmd = CrearComando(sp, parametros);
            try 
            {
                resultado = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex) 
            {
                resultado=-1;
            }
            return resultado;
        }

        public int Escribir(string sp, List<SqlParameter> parametros = null) 
        {
            int resultado;
            SqlCommand cmd = CrearComando(sp, parametros);
            try 
            {
                resultado = cmd.ExecuteNonQuery();
            } catch (Exception ex) 
            {
                resultado=-1;
            }
            return resultado;
        
        }
        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, valor);
            parametro.DbType = DbType.String;
            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter(nombre,valor);
            parametro.DbType = DbType.Int32;
            return parametro;
        }
        public SqlParameter CrearParametro(string nombre, float valor)
        {
            SqlParameter parametro = new SqlParameter(nombre,valor);
            parametro.DbType = DbType.Single;
            return parametro;
        }


    }
}