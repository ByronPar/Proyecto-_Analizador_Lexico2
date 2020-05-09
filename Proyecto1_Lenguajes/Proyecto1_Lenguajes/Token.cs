using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_Lenguajes
{
    class Token { 


        public enum Tipo
    {

        Reservado_Poblacion,
        Reservado_Saturacion,
        Reservado_Bandera,
        Reservado_Grafica,
        Reservado_Nombre,
        Reservado_Continente,
        Cadena,
        Dos_Puntos,
        Número,
        LLave_de_Cierre,
        LLave_de_entrada,
        Desconocido,
        Reservado_Pais,
        Signo_Porcentaje,
        Espacio,
         Punto_Coma


    }

        private int columna;
        private int fila;
        private int idToken;
        private String valor;
        private Tipo tipoToken;


        public Token(int columna, int fila, int idToken, string valor, Tipo tipoToken)//CONSTRUCTOR DE MIS TOKENS
        {
            this.columna = columna;
            this.fila = fila;
            this.idToken = idToken;
            this.valor = valor;
            this.tipoToken = tipoToken;
        }

        public Token(int columna, int fila,  string valor, Tipo tipoToken)//CONSTRUCTOS DE MIS ERRORES QUE ALMACENARE
        {
            this.columna = columna;
            this.fila = fila;
            this.idToken = 0;
            this.valor = valor;
            this.tipoToken = tipoToken;
        }

        public String GetVal() {
            return valor;
        }

        public int GetidToken() {
            return idToken;
        }

        public int Getfila() {
            return fila;
        }

        public int Getcolumna() {
            return columna;
        }

        public String GetTipo() {
            switch (tipoToken) {
                case Tipo.Cadena:
                    return "Cadena";
                case Tipo.Dos_Puntos:
                    return "Dos Puntos";
                case Tipo.Espacio:
                    return "Espacio";
                case Tipo.LLave_de_Cierre:
                    return "Llave de Cierre";
                case Tipo.LLave_de_entrada:
                    return "Llave de entrada";
                case Tipo.Número:
                    return "Número";
                case Tipo.Reservado_Bandera:
                    return "Reservado Bandera";
                case Tipo.Reservado_Continente:
                    return "Reservado Continente";
                case Tipo.Reservado_Grafica:
                    return "Reservado Grafica";
                case Tipo.Reservado_Nombre:
                    return "Reservado Nombre";
                case Tipo.Reservado_Pais:
                    return "Reservado Pais";
                case Tipo.Reservado_Poblacion:
                    return "Reservado Poblacion";
                case Tipo.Reservado_Saturacion:
                    return "Reservado Saturación";
                case Tipo.Signo_Porcentaje:
                    return "Signo Porcentaje";
                case Tipo.Punto_Coma:
                    return "Punto y Coma";

                default:
                    return "DESCONOCIDO";
            }
        }




    }
}
