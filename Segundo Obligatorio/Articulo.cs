using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    public class Articulo
    {
        private string codigo;
        private int precio;
        private string descripcion;

        public string Codigo
        {
            get { return codigo.Trim().ToUpper(); }
            set
            {
                if (value.Length == 6)
                {
                    codigo = value;
                }
                else
                {
                    throw new Exception("\n* Codigo no valido, debe tener 6 caracteres *");
                }
            }
        }

        public int Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("\n* Ingrese el precio correctamente *");
                }
                else
                {
                    precio = value;
                }
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set 
            {
                if (value == string.Empty)
                {
                    throw new Exception("\n* Debe ingresar una descripcion *");
                }
                else
                {
                    descripcion = value;
                }
            }
        }

        public Articulo(string pCodigo, int pPrecio, string pDescripcion)
        {
            Codigo = pCodigo;
            Precio = pPrecio;
            Descripcion = pDescripcion;
        }

        public override string ToString()
        {
            return "\t\nARTICULO" + "\nCodigo: " + Codigo + "\nPrecio: " + Precio + "\nDescripcion: " + Descripcion;
        }

    }
}
