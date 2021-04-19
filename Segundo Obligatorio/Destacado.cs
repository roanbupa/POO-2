using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    public class Destacado:Aviso
    {
        private Articulo articulo;

        public Articulo Articulo
        {
            get { return articulo; }
            set { articulo = value; }
        }

        public Destacado(int pNumero, string pTelefono, DateTime pPublicacion, Categoria pCategoria, Articulo pArticulo)
            : base(pNumero, pTelefono, pPublicacion, pCategoria)
        {
            Articulo = pArticulo;
        }

        public override string ToString()
        {
            return "\nDESTACADO" + "\n" + base.ToString() + "\t" + Articulo.ToString();
        }
    }
}