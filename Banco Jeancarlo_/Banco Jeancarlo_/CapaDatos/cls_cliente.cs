using System;

namespace Banco.CapaDatos
{
    public class cls_cliente
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private int edad;
        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        private decimal saldo;
        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
    }
}