using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Banco.CapaPresentacion
{
    public partial class CuentasClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM cuentacliente", con))
            {
                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo, codigocliente;
            if (int.TryParse(txtcodigo.Text, out codigo) && int.TryParse(txtcodigocliente.Text, out codigocliente) &&
                txttipo.Text.Trim() != "")
            {
                if (Capa_Logica.CuentaCliente_Logica.Agregarcuenta(codigo, txttipo.Text, codigocliente) > 0)
                    lblMensaje.Text = "Cuenta agregada correctamente.";
                else
                    lblMensaje.Text = "No se pudo agregar. Compruebe los códigos.";
                LlenarGrid();
            }
            else
                lblMensaje.Text = "Revise los datos ingresados.";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int codigo, codigocliente;
            if (int.TryParse(txtcodigo.Text, out codigo) && int.TryParse(txtcodigocliente.Text, out codigocliente) &&
                txttipo.Text.Trim() != "")
            {
                if (Capa_Logica.CuentaCliente_Logica.Modificarcuenta(codigo, txttipo.Text, codigocliente) > 0)
                    lblMensaje.Text = "Cuenta modificada correctamente.";
                else
                    lblMensaje.Text = "No se encontró la cuenta o no se pudo modificar.";
                LlenarGrid();
            }
            else
                lblMensaje.Text = "Revise los datos ingresados.";
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int codigo;
            if (int.TryParse(txtcodigo.Text, out codigo))
            {
                if (Capa_Logica.CuentaCliente_Logica.Borrarcuenta(codigo) > 0)
                    lblMensaje.Text = "Cuenta borrada correctamente.";
                else
                    lblMensaje.Text = "No se pudo borrar la cuenta.";
                LlenarGrid();
            }
            else
                lblMensaje.Text = "Ingrese un código válido.";
        }
    }
}