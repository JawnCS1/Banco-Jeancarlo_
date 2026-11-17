using System;

namespace Banco.CapaDatos
{
    public class cls_cuentacliente
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private int codigocliente;
        public int CodigoCliente
        {
            get { return codigocliente; }
            set { codigocliente = value; }
        }
    }
}