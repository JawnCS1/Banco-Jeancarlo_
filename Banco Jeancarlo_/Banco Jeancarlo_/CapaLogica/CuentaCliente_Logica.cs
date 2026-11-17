using System.Data;
using System.Data.SqlClient;

namespace Banco.Capa_Logica
{
    public class CuentaCliente_Logica
    {
        public static int Agregarcuenta(int codigo, string tipo, int codigocliente)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Insert into cuentacliente (codigo, tipo, codigocliente) values (@codigo,@tipo,@codigocliente)", Conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@codigocliente", codigocliente);
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

        public static int Modificarcuenta(int codigo, string tipo, int codigocliente)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("update cuentacliente set tipo=@tipo, codigocliente=@codigocliente where codigo=@codigo", Conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@codigocliente", codigocliente);
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

        public static int Borrarcuenta(int codigo)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Delete from cuentacliente where codigo=@codigo", Conn);
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