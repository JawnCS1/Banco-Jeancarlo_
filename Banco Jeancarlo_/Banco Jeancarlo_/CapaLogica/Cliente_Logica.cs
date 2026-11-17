using System.Data;
using System.Data.SqlClient;

namespace Banco.Capa_Logica
{
    public class Cliente_Logica
    {
        public static int Agregarclientes(int codigo, string nombre, int edad, decimal saldo)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Insert into cliente (codigo, nombre, edad, saldo) values (@codigo,@nombre,@edad,@saldo)", Conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@edad", edad);
                    cmd.Parameters.AddWithValue("@saldo", saldo);
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }
            return retorno;
        }

        public static int Modificarclientes(int codigo, string nombre, int edad, decimal saldo)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("update cliente set nombre=@nombre, edad=@edad, saldo=@saldo where codigo=@codigo", Conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@edad", edad);
                    cmd.Parameters.AddWithValue("@saldo", saldo);
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }
            return retorno;
        }

        public static int Borrarclientes(int codigo)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Delete from cliente where codigo=@codigo", Conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }
            return retorno;
        }
    }
}