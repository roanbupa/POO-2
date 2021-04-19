using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    public abstract class Aviso
    {
        private int numero;
        private string telefono;
        private DateTime publicacion;
        private Categoria categoria;


        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Telefono
        {
            get { return telefono.Trim(); }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("\n* Debe ingresar un telefono *");
                }
                else
                {
                    telefono = value;
                }
            }
        }

        public DateTime Publicacion
        {
            get { return publicacion; }
            set { publicacion = value; }
        }

        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public Aviso(int pNumero, string pTelefono, DateTime pPublicacion, Categoria pCategoria)
        {
            Numero = pNumero;
            Telefono = pTelefono;
            Publicacion = pPublicacion;
            Categoria = pCategoria;
        }

        public override string ToString()
        {
            return "\nID: " + Numero + "\nTelefono: " + Telefono + "\nFecha de publicacion: " + Publicacion + 
                "\n" + Categoria.ToString() + "\n";
        }
    }
}
