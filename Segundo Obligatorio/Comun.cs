using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    public class Comun:Aviso
    {
        private List<string> palabrasClaves = new List<string>();

        public List<string> PalabrasClaves
        {
            get { return palabrasClaves; }
            set
            {
                if (value == null)
                {
                    throw new Exception("\n* Debe de ingresar las palabra clave *");
                }
                else
                {
                    palabrasClaves = value;
                }
            }
        }

        public Comun(int pNumero, string pTelefono, DateTime pPublicacion, Categoria pCategoria, List<string> pPalabrasClaves)
            : base(pNumero, pTelefono, pPublicacion, pCategoria)
        {
            PalabrasClaves = pPalabrasClaves;
        }

        public override string ToString()
        {
            return "\nCOMUN" + "\n" + base.ToString();
        }

    }
}
