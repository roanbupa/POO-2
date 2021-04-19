using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    public class Categoria
    {
        private string codigo;
        private string nombre;
        private int precioBase;

        public string Codigo
        {
            get { return codigo.Trim().ToUpper(); }
            set
            {
                if (value.Length == 3)
                {
                    codigo = value;
                }
                else
                {
                    throw new Exception("\n* El codigo debe tener 3 digitos *");
                }
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("\n* Debe ingresar un nombre *");
                }
                else
                {
                    nombre = value;
                }
            }
        }

        public int PrecioBase
        {
            get { return precioBase; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("\n* Debe ingresar precio correctamente *");
                }
                else
                {
                    precioBase = value;
                }
            }
        }

        public Categoria(string pCodigo, string pNombre, int pPrecioBase)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            PrecioBase = pPrecioBase;
        }

        public override string ToString()
        {
            return "\nCATEGORIA" + "\nCodigo: " + Codigo + "\nNombre: " + Nombre + "\nPrecio Base: " + PrecioBase;
        }
    }
}
