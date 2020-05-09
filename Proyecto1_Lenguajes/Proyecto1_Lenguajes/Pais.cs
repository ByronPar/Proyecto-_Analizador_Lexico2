using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Lenguajes
{
    class Pais
    {
        private String nombre;
        private long poblacion;
        private int saturacion;
        private String bandera;
        private int saturacionContinente;

        public Pais(string nombre, long poblacion, int saturacion, string bandera)
        {
            this.Nombre = nombre;
            this.Poblacion = poblacion;
            this.Saturacion = saturacion;
            this.Bandera = bandera;
        }



        public string Nombre { get => nombre; set => nombre = value; }
        public long Poblacion { get => poblacion; set => poblacion = value; }
        public int Saturacion { get => saturacion; set => saturacion = value; }
        public string Bandera { get => bandera; set => bandera = value; }
        public int SaturacionContinente { get => saturacionContinente; set => saturacionContinente = value; }

        public String GetNombre()
        {
            return nombre;
        }

        public long GetPoblacion()
        {
            return poblacion;
        }
        public int GetSaturacion()
        {
            return saturacion;
        }

        public int GetSaturacionContinente()
        {
            return saturacionContinente;
        }

        public String GetBandera()
        {
            return bandera;
        }

        public String ObtenerDot()
        {

            return this.Nombre + " [shape=record label=\"{ " + this.Nombre + " | " + this.saturacion + " }\" style=filled fillcolor=" + CalcularColor() + "];\n";
        }
        public String CalcularColor()
        {
            String color = "";
            if (saturacion >= 0 && saturacion <= 15)
            {
                color = "white";
            }
            else if (saturacion >= 16 && saturacion <= 30)
            {
                color = "blue";
            }
            else if (saturacion >= 31 && saturacion <= 45)
            {
                color = "green";
            }
            else if (saturacion >= 46 && saturacion <= 60)
            {
                color = "yellow";
            }
            else if (saturacion >= 61 && saturacion <= 75)
            {
                color = "orange";
            }
            else if (saturacion >= 76 && saturacion <= 100)
            {
                color = "red";
            }
            else {

            }
            return color;
        }
    }
}
