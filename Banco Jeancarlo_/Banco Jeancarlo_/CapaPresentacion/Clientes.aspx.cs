using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Banco.CapaPresentacion
{
    public partial class Clientes : System.Web.UI.Page
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
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM cliente", con))
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
            int codigo, edad;
            decimal saldo;
            if (int.TryParse(txtcodigo.Text, out codigo) && int.TryParse(txtedad.Text, out edad) &&
                decimal.TryParse(txtsaldo.Text, out saldo) && txtnombre.Text.Trim() != "")
            {
                if (Capa_Logica.Cliente_Logica.Agregarclientes(codigo, txtnombre.Text, edad, saldo) > 0)
                    lblMensaje.Text = "Cliente agregado correctamente.";
                else
                    lblMensaje.Text = "No se pudo agregar el cliente.";
                LlenarGrid();
            }
            else
                lblMensaje.Text = "Revise los datos ingresados.";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int codigo, edad;
            decimal saldo;
            if (int.TryParse(txtcodigo.Text, out codigo) && int.TryParse(txtedad.Text, out edad) &&
                decimal.TryParse(txtsaldo.Text, out saldo) && txtnombre.Text.Trim() != "")
            {
                if (Capa_Logica.Cliente_Logica.Modificarclientes(codigo, txtnombre.Text, edad, saldo) > 0)
                    lblMensaje.Text = "Cliente modificado correctamente.";
                else
                    lblMensaje.Text = "No se encontró el cliente o no se pudo modificar.";
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
                if (Capa_Logica.Cliente_Logica.Borrarclientes(codigo) > 0)
                    lblMensaje.Text = "Cliente borrado correctamente.";
                else
                    lblMensaje.Text = "No se pudo borrar. Compruebe si tiene cuentas asociadas.";
                LlenarGrid();
            }
            else
                lblMensaje.Text = "Ingrese un código válido.";
        }
    }
}