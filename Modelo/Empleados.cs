using System;
using System.Collections.Generic;

namespace Rec_Sena.Modelo
{
    public partial class Empleados
    {
        public uint Cedula { get; set; }
        public string Nombre { get; set; }
        public string Salario { get; set; }
        public double? Dias { get; set; }
        public double? Vacacionespagar { get; set; }
    }
}
