using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolphyText
{
    class Configuraciones
    {
        private String nombre;
        private bool estado;
        private int linea;

        public string Nombre { get => nombre; set => nombre = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int Linea { get => linea; set => linea = value; }

        public Configuraciones(string nombre, bool estado)
        {
            this.nombre = nombre;
            this.estado = estado;
        }

        public Configuraciones(string nombre, bool estado, int linea)
        {
            this.nombre = nombre;
            this.linea = linea;
            this.estado = estado;
        }


    }
}
