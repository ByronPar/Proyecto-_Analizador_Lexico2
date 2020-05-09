using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Lenguajes
{
    class Continente
    {
        private String Nombre = "";
        private ArrayList listaPaises = new ArrayList();
        private int saturacionCont;

        public Continente(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public int SaturacionCont { get => saturacionCont; set => saturacionCont = value; }
        public ArrayList listaPais { get => listaPaises; set => listaPaises = value; }


        public int GetSaturacionCont()
        {
            return saturacionCont;
        }

        public void SetSaturacionCont(int a)
        {
            this.saturacionCont=a;
        }



        public void AgregarPais(Pais pais)
        {
            this.listaPaises.Add(pais);
        }

        public void Imprimir()
        {
            Console.WriteLine(">>>>>>> " + this.Nombre + " <<<<<<<<<<");
            foreach (Pais obj in listaPaises)
            {
                Console.WriteLine(obj.Nombre + ", " + obj.Poblacion + ", " + obj.Saturacion);
            }
        }

        public String ObtenerDot()
        {
            String cadenGraphviz = "";
            cadenGraphviz += this.Nombre + " [shape=record label=\"{ " + this.Nombre + " | " + CalcularSaturacion() + "} \" style=filled fillcolor=" + CalcularColor() + "];\n";
            //Se relaciona el continente con los paises 
            foreach (Pais obj in this.listaPaises)
            {
                cadenGraphviz += this.Nombre + " ->" + obj.Nombre + ";\n";
            }
            //-- Se obtiene el codigo de cada pais ----
            foreach (Pais obj in listaPaises)
            {
                cadenGraphviz += obj.ObtenerDot();
            }
            //-------------------------------------------
            return cadenGraphviz;
        }

        public int CalcularSaturacion()
        {
            int promedio;
            int cantPaises = 0;
            int suma = 0;
            foreach (Pais obj in this.listaPaises)
            {
                cantPaises++;
                //Console.WriteLine(a.Saturacion);
                suma += obj.GetSaturacion();

            }


            promedio = suma / cantPaises;
            SetSaturacionCont(promedio);
            //Se deveria de sacar el promedio de saturacion de los paises
            return promedio; //se retorna el promedio
        }
        public String CalcularColor()
        {
            int saturacion = CalcularSaturacion();
            
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
            else
            {

            }
            return color;
        }

       
    }
}
