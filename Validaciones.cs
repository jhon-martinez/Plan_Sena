using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Rec_Sena
{
    class Validaciones
    {
        public bool Vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Console.WriteLine(" La entrada no puede ser VACIO");
                return true;
            }
            else
                return false;
        }

        public bool TipoNumero(string texto)
        {
            Regex regla = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine(" La entrada  debe ser NUMERICA");
                return false;
            }
        }

        public bool TipoTexto(string texto)
        {
            Regex regla = new Regex("^[a-zA-Z ]*$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine(" La entrada  debe ser SOLO TEXTO");
                return false;
            }

        }

    }

}