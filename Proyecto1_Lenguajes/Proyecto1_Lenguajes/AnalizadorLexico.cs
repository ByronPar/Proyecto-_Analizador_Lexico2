using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Lenguajes
{
    class AnalizadorLexico
    {
        private LinkedList<Token> Salida;
        private int estado;
        private String auxlex;
        private int columna;
        private int fila;
        private int vError;
        //PROYECTO 1 BYRON PAR


        public LinkedList<Token> escanear(String entrada)
        {

            //entrada = entrada + "#";
            Salida = new LinkedList<Token>();
            estado = 0;
            auxlex = "";
            Char c;
            fila = 1;
            columna = 0;
            vError = 0;


            for (int i = 0; i <= entrada.Length - 1; i++)
            {
                c = entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (c.CompareTo('P') == 0)
                        {
                            estado = 1;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('N') == 0)
                        {
                            estado = 2;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('S') == 0)
                        {
                            estado = 3;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('B') == 0)
                        {
                            estado = 4;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('G') == 0)
                        {
                            estado = 5;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('C') == 0)
                        {
                            estado = 6;
                            auxlex += c;
                            columna++;
                        }
                        else if (Char.IsDigit(c))
                        {
                            estado = 7;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('"') == 0)
                        {
                            estado = 8;
                            //auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('{') == 0)
                        {


                            auxlex += c;
                            agregarToken(Token.Tipo.LLave_de_entrada, 4);
                            columna++;
                        }
                        else if (c.CompareTo('}') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.LLave_de_Cierre, 4);
                            columna++;
                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.Dos_Puntos, 4);
                            columna++;
                        }
                        else if (c.CompareTo(';') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.Punto_Coma, 4);
                            columna++;
                        }
                        else if (c.CompareTo('%') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.Signo_Porcentaje, 4);
                            columna++;
                        }
                        else if (c.CompareTo('\r') == 0)
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\t') == 0)
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\f') == 0)
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\b') == 0)
                        {
                            estado = 0;
                        }
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\n') == 0)
                        {
                            fila++;
                            columna = 1;
                            estado = 0;
                        }
                        else
                        {
                            auxlex += c;
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            vError = 1;
                        }

                        break;
                    case 1:
                        if (c.CompareTo('a') == 0) //CONTINUAR AQUI EN EL CASO 1
                        {
                            estado = 9;
                            auxlex += c;
                            columna++;

                        }
                        else if (c.CompareTo('o') == 0)
                        {
                            estado = 10;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 2:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 11;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 3:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 12;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 4:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 13;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 5:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 14;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 6:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 15;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 7:
                        if (Char.IsDigit(c))
                        {
                            estado = 7;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Número, 3);
                            columna++;
                            i -= 1;
                        }
                        break;
                    case 8:
                        if (c.CompareTo('"') == 0)
                        {
                            agregarToken(Token.Tipo.Cadena, 2);
                            columna++;

                        }
                        else
                        {
                            estado = 8;
                            auxlex += c;
                            columna++;
                        }
                        break;
                    case 9:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 17;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 10:
                        if (c.CompareTo('b') == 0)
                        {
                            estado = 18;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 11:
                        if (c.CompareTo('m') == 0)
                        {
                            estado = 19;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 12:
                        if (c.CompareTo('t') == 0)
                        {
                            estado = 20;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 13:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 21;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 14:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 22;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 15:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 23;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 17:
                        if (c.CompareTo('s') == 0)
                        {
                            estado = 24;

                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            vError = 1;
                            i -= 1;
                        }
                        break;
                    case 18:
                        if (c.CompareTo('l') == 0)
                        {
                            estado = 25;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 19:
                        if (c.CompareTo('b') == 0)
                        {
                            estado = 26;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 20:
                        if (c.CompareTo('u') == 0)
                        {
                            estado = 27;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 21:
                        if (c.CompareTo('d') == 0)
                        {
                            estado = 28;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 22:
                        if (c.CompareTo('f') == 0)
                        {
                            estado = 29;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 23:
                        if (c.CompareTo('t') == 0)
                        {
                            estado = 30;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 24:
                        agregarToken(Token.Tipo.Reservado_Pais, 1);
                        i -= 1;
                        columna++;

                        break;
                    case 25:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 31;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 26:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 32;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 27:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 33;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 28:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 34;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 29:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 35;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 30:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 36;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 31:
                        if (c.CompareTo('c') == 0)
                        {
                            estado = 37;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 32:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 38;

                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 33:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 39;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 34:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 40;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 35:
                        if (c.CompareTo('c') == 0)
                        {
                            estado = 41;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 36:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 42;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 37:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 43;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 38:
                        agregarToken(Token.Tipo.Reservado_Nombre, 1);
                        columna++;
                        i -= 1;
                        break;
                    case 39:
                        if (c.CompareTo('c') == 0)
                        {
                            estado = 44;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 40:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 45;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 41:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 46;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 42:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 47;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 43:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 48;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 44:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 49;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 45:
                        agregarToken(Token.Tipo.Reservado_Bandera, 1);
                        columna++;
                        i -= 1;
                        break;
                    case 46:
                        agregarToken(Token.Tipo.Reservado_Grafica, 1);
                        columna++;
                        i -= 1;
                        break;
                    case 47:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 50;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 48:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 51;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 49:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 52;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 50:
                        if (c.CompareTo('t') == 0)
                        {
                            estado = 53;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 51:
                        agregarToken(Token.Tipo.Reservado_Poblacion, 1);
                        columna++;
                        i -= 1;
                        break;
                    case 52:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 54;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 53:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 55;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 54:
                        agregarToken(Token.Tipo.Reservado_Saturacion, 1);
                        columna++;
                        i -= 1;
                        break;
                    case 55:
                        agregarToken(Token.Tipo.Reservado_Continente, 1);
                        columna++;
                        i -= 1;
                        break;


                    default:

                        break;




                }
                Console.WriteLine(i);
            }

            return Salida;
        }

        public void agregarToken(Token.Tipo tipo, int idToken)
        {
            Salida.AddLast(new Token(columna, fila, idToken, auxlex, tipo));
            auxlex = "";
            estado = 0;
        }

        public void agregarTokenError(Token.Tipo tipo)
        {
            Salida.AddLast(new Token(columna, fila, auxlex, tipo));
            auxlex = "";
            estado = 0;

        }

        public void imprimirListaToken(LinkedList<Token> lista)
        {
            int a = 0;
            foreach (Token item in lista)
            {
                Console.WriteLine(a + "  <--->   " + item.GetVal() + "   <--->   " + item.GetTipo() + "  <-->  " + item.GetidToken() + "  <-->  " + item.Getfila() + "  <-->  " + item.Getcolumna());
                a++;
            }

        }

        public void imprimirListaVector(Token[] lista)
        {


            for (int i = 0; i < lista.Length; i++)
            {
                Console.WriteLine(i + 1 + "  <--->   " + lista[i].GetVal() + "   <--->   " + lista[i].GetTipo() + "  <-->  " + lista[i].GetidToken() + "  <-->  " + lista[i].Getfila() + "  <-->  " + lista[i].Getcolumna());
            }

        }

        public void generarReporte(LinkedList<Token> lista, String entrada, RichTextBox recibido, TextBox datosImg, PictureBox bandera, PictureBox grafo)
        {
            int contadorToken = 0;
            if (vError == 1)
            {//SE GENERARA UN REPORTE DE ERRORES  Y  se abrira nada más
                System.IO.StreamWriter html1 = new System.IO.StreamWriter("C:\\Users\\HP ENVY\\Desktop\\TablaDeErrores.html");//CONTINUAR AQUI
                html1.WriteLine("<html><h1><center>Tabla De  Errores</center></h1>"
                    + "<br>"
                    + "<center>No ------------------------------- VALOR ------------------------------- TIPO ------------------------------------- FILA ------------------------------- COLUMNA</center>");
                html1.WriteLine("<center><table border = '1'>");
                foreach (Token item in lista)
                {
                    if (item.GetTipo().Equals("DESCONOCIDO", StringComparison.InvariantCultureIgnoreCase))
                    {




                        contadorToken++;
                        html1.WriteLine(" <tr>"
                            + " <td WIDTH=160 bgcolor=orange>" + contadorToken + "</td><td WIDTH=200 bgcolor=orange>" + item.GetVal() + "</td>"
                            + " <td WIDTH=280 bgcolor=orange>" + item.GetTipo() + "</td>"
                            + " <td WIDTH=230 bgcolor=orange>" + item.Getfila() + "</td><td WIDTH=150 bgcolor=orange>" + item.Getcolumna() + "</td>"
                            + "   </tr>");
                    }

                }
                html1.WriteLine(" </table></center>"
                             + "</body>"
                             + "</html>");
                html1.Close();

                MessageBox.Show("Se han Encontrado Errores Lexicos en el editor de Texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                Process.Start("C:\\Users\\HP ENVY\\Desktop\\TablaDeErrores.html");

                recibido.Text = entrada;

            }
            else
            {//SE GENEREARA UN REPORTE DE TOKENS , Y SE EJECUTARA UN NUEVO ANALIZADOR PARA PINTAR

                System.IO.StreamWriter html2 = new System.IO.StreamWriter("C:\\Users\\HP ENVY\\Desktop\\TablaDeTokens.html");//CONTINUAR AQUI
                html2.WriteLine("<html><h1><center>Tabla De  Tokens</center></h1>"
                    + "<br>"
                    + "<center>No ------------------------------- LEXEMA------------------------------- TIPO ------------------------------------- FILA ------------------------------- COLUMNA</center>");
                html2.WriteLine("<center><table border = '1'>");
                foreach (Token item in lista)
                {
                    if (item.GetTipo().Equals("DESCONOCIDO", StringComparison.InvariantCultureIgnoreCase))
                    {

                    }
                    else
                    {

                        contadorToken++;
                        html2.WriteLine(" <tr>"
                            + " <td WIDTH=160 bgcolor=orange>" + contadorToken + "</td><td WIDTH=200 bgcolor=orange>" + item.GetVal() + "</td>"
                            + " <td WIDTH=280 bgcolor=orange>" + item.GetTipo() + "</td>"
                            + " <td WIDTH=230 bgcolor=orange>" + item.Getfila() + "</td><td WIDTH=150 bgcolor=orange>" + item.Getcolumna() + "</td>"
                            + "   </tr>");
                    }

                }
                html2.WriteLine(" </table></center>"
                             + "</body>"
                             + "</html>");
                html2.Close();
                Process.Start("C:\\Users\\HP ENVY\\Desktop\\TablaDeTokens.html");
                generarImagen(datosImg, lista, bandera,grafo);

               

                pintar(entrada, recibido);
            }
        }


        public void generarImagen(TextBox datosImg, LinkedList<Token> lista, PictureBox imgBandera, PictureBox grafo)
        {//GENERARE MI GRAFO

            String nombrePais = "";
            long poblacion = 0;
            int saturacion = 0;
            String bandera = "";
            ArrayList listaContinentes = new ArrayList();
            int cantPais = 0;
            int a = 0;
            int s = 0;
            foreach (Token item in lista) // para crear un mi vector de mis tokens
            {
                a++;

            }

            Token[] arregloTokens = new Token[a];


            foreach (Token item in lista) // lleno mi vector de todos mis tokens
            {
                arregloTokens[s] = item;
                s++;

            }



            for (int i = 0; i < arregloTokens.Length; i++)
            {
                if (arregloTokens[i].GetTipo().Equals("Reservado Continente"))
                {
                    i = i + 5;
                    Continente continenteNuevo = new Continente(arregloTokens[i].GetVal().Trim());
                    i = i + 2;
                    while (arregloTokens[i].GetTipo().Equals("Reservado Pais", StringComparison.InvariantCultureIgnoreCase))
                    {
                        nombrePais = "";
                        poblacion = 0;
                        saturacion = 0;
                        bandera = "";
                        i = i + 5;

                        nombrePais = arregloTokens[i].GetVal().Trim();

                        i = i + 4;
                        poblacion = long.Parse(arregloTokens[i].GetVal());


                        i = i + 4;
                        saturacion = int.Parse(arregloTokens[i].GetVal());

                        i = i + 5;
                        bandera = arregloTokens[i].GetVal().Trim();

                        continenteNuevo.AgregarPais(new Pais(nombrePais, poblacion, saturacion, bandera));
                        cantPais++;
                        i = i + 3;
                        continenteNuevo.SaturacionCont += saturacion;


                    }
                    
                    listaContinentes.Add(continenteNuevo);



                }
            }

            Pais[] listaPais = new Pais[cantPais];
            int v = 0;
            foreach (Continente obj in listaContinentes)
            {
                foreach (Pais pa in obj.listaPais)
                {
                    listaPais[v] = pa;
                    listaPais[v].SaturacionContinente = obj.SaturacionCont;
                    v++;
                }
            }

            //imprimirListaVector(arregloTokens);

            String nombreGrafica = "";

            for (int i = 0; i < arregloTokens.Length; i++)
            {
                if (arregloTokens[i].GetTipo().Equals("Cadena", StringComparison.InvariantCultureIgnoreCase))
                {
                    nombreGrafica = arregloTokens[i].GetVal().Trim();
                    break;
                }
            }

            String cadenGraphviz = "";
            cadenGraphviz += " digraph G {\n";
            cadenGraphviz += "  start [shape=Mdiamond label=\"" + nombreGrafica + "\"];\n";
            //Se relaciona la raiz con los continentes 
            foreach (Continente obj in listaContinentes)
            {
                cadenGraphviz += "  start ->" + obj.Nombre1 + ";\n";
            }
            //----------------------------------------------
            //-- Se obtiene el codigo de cada continente ----
            foreach (Continente obj in listaContinentes)
            {
                cadenGraphviz += obj.ObtenerDot();
            }
            //-------------------------------------------

            cadenGraphviz += "}";
            //richTextBox1.Text = cadenGraphviz;
            System.IO.File.WriteAllText(@"C:\\Users\\HP ENVY\\Desktop\\imagenGra.txt", cadenGraphviz);
            ProcessStartInfo startInfo = new ProcessStartInfo("dot.exe");
            startInfo.Arguments = "-Tpng \"C:\\Users\\HP ENVY\\Desktop\\imagenGra.txt\" -o \"C:\\Users\\HP ENVY\\Desktop\\imagen.jpg\"";
            
            Process.Start(startInfo);
            







            for (int i = 0; i < listaPais.Length - 1; i++)
            {
                for (int j = 0; j < listaPais.Length - i - 1; j++)
                {
                    if (listaPais[j + 1].GetSaturacion() < listaPais[j].GetSaturacion())
                    {
                        Pais aux = listaPais[j + 1];
                        listaPais[j + 1] = listaPais[j];
                        listaPais[j] = aux;
                    }
                }
            }


            if (listaPais[0].GetSaturacion() == listaPais[1].GetSaturacion())
            {
                
                        if (listaPais[1].GetSaturacionContinente() < listaPais[0].GetSaturacionContinente())
                        {
                            Pais auxiliar = listaPais[1];
                            listaPais[1] = listaPais[0];
                            listaPais[0] = auxiliar;
                        }                 

            }

            try
            {
                imgBandera.Image = null;
                datosImg.Text = "";
                //creo dos string uno donde estara mi ruta de imagen y la otra esta mi descripción


                datosImg.Text = "Pais Seleccionado:   " + listaPais[0].GetNombre() +
                    "\n " +
                    "\n Población =  " +  listaPais[0].GetPoblacion();
                imgBandera.Image = Image.FromFile(listaPais[0].GetBandera());
                imgBandera.SizeMode = PictureBoxSizeMode.StretchImage;

                //MessageBox.Show(e.Node.Text);
                // MessageBox.Show(e.Node.Tag.ToString());

            }
            catch (Exception al)
            {
                //nada
            }



            try
            {
                grafo.Image = null;
                // textBox1.Text = "";

                String ruta = "C:\\Users\\HP ENVY\\Desktop\\imagen.jpg";

                grafo.Image = Image.FromFile(ruta);
                grafo.SizeMode = PictureBoxSizeMode.StretchImage;



            }
            catch (Exception al)
            {
                //nada
            }



        }

        public void pintar(String entrada, RichTextBox recibido)
        {

            Salida = new LinkedList<Token>();
            estado = 0;
            auxlex = "";
            Char c;
            fila = 1;
            columna = 0;
            vError = 0;
            int index = recibido.SelectionStart;
            int contadorNumero = 0;
            int contadorCadena = 0;


            for (int i = 0; i <= entrada.Length - 1; i++)
            {
                c = entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (c.CompareTo('P') == 0)
                        {
                            estado = 1;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('N') == 0)
                        {
                            estado = 2;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('S') == 0)
                        {
                            estado = 3;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('B') == 0)
                        {
                            estado = 4;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('G') == 0)
                        {
                            estado = 5;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('C') == 0)
                        {
                            estado = 6;
                            auxlex += c;
                            columna++;
                        }
                        else if (Char.IsDigit(c))
                        {
                            contadorNumero++;
                            estado = 7;
                            auxlex += c;
                            columna++;
                        }
                        else if (c.CompareTo('"') == 0)
                        {
                            estado = 8;
                            //auxlex += c;
                            columna++;
                            contadorCadena++;
                        }
                        else if (c.CompareTo('{') == 0)
                        {


                            auxlex += c;
                            agregarToken(Token.Tipo.LLave_de_entrada, 4);
                            columna++;
                            {
                                recibido.Select(i, 1);
                                recibido.SelectionColor = Color.Red;
                                recibido.SelectionStart = index;
                            }
                        }
                        else if (c.CompareTo('}') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.LLave_de_Cierre, 4);
                            columna++;
                            {
                                recibido.Select(i, 1);
                                recibido.SelectionColor = Color.Red;
                                recibido.SelectionStart = index;
                            }
                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.Dos_Puntos, 4);
                            columna++;

                        }
                        else if (c.CompareTo(';') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.Punto_Coma, 4);
                            columna++;
                            {
                                recibido.Select(i, 1);
                                recibido.SelectionColor = Color.Orange;
                                recibido.SelectionStart = index;
                            }
                        }
                        else if (c.CompareTo('%') == 0)
                        {
                            auxlex += c;
                            agregarToken(Token.Tipo.Signo_Porcentaje, 4);
                            columna++;
                        }
                        else if (c.CompareTo('\r') == 0)
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\t') == 0)
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\f') == 0)
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\b') == 0)
                        {
                            estado = 0;
                        }
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        else if (c.CompareTo('\n') == 0)
                        {
                            fila++;
                            columna = 1;
                            estado = 0;
                        }
                        else
                        {
                            auxlex += c;
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            vError = 1;
                        }

                        break;
                    case 1:
                        if (c.CompareTo('a') == 0) //CONTINUAR AQUI EN EL CASO 1
                        {
                            estado = 9;
                            auxlex += c;
                            columna++;

                        }
                        else if (c.CompareTo('o') == 0)
                        {
                            estado = 10;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 2:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 11;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 3:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 12;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 4:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 13;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 5:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 14;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 6:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 15;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 7:
                        if (Char.IsDigit(c))
                        {
                            contadorNumero++;
                            estado = 7;
                            auxlex += c;
                            columna++;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.Número, 3);
                            columna++;
                            i -= 1;
                            {
                                recibido.Select(i - (contadorNumero - 1), (contadorNumero));
                                recibido.SelectionColor = Color.Green;
                                recibido.SelectionStart = index;
                            }
                            contadorNumero = 0;
                        }
                        break;
                    case 8:
                        if (c.CompareTo('"') == 0)
                        {
                            agregarToken(Token.Tipo.Cadena, 2);

                            columna++;
                            {
                                recibido.Select(i - (contadorCadena), (contadorCadena + 1));
                                recibido.SelectionColor = Color.Yellow;
                                recibido.SelectionStart = index;
                            }
                            contadorCadena = 0;

                        }
                        else
                        {
                            estado = 8;
                            auxlex += c;
                            columna++;
                            contadorCadena++;
                        }
                        break;
                    case 9:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 17;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 10:
                        if (c.CompareTo('b') == 0)
                        {
                            estado = 18;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 11:
                        if (c.CompareTo('m') == 0)
                        {
                            estado = 19;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 12:
                        if (c.CompareTo('t') == 0)
                        {
                            estado = 20;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 13:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 21;
                            columna++;
                            auxlex += c;


                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 14:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 22;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 15:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 23;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 17:
                        if (c.CompareTo('s') == 0)
                        {
                            estado = 24;

                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            vError = 1;
                            i -= 1;
                        }
                        break;
                    case 18:
                        if (c.CompareTo('l') == 0)
                        {
                            estado = 25;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 19:
                        if (c.CompareTo('b') == 0)
                        {
                            estado = 26;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 20:
                        if (c.CompareTo('u') == 0)
                        {
                            estado = 27;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 21:
                        if (c.CompareTo('d') == 0)
                        {
                            estado = 28;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 22:
                        if (c.CompareTo('f') == 0)
                        {
                            estado = 29;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 23:
                        if (c.CompareTo('t') == 0)
                        {
                            estado = 30;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 24:
                        agregarToken(Token.Tipo.Reservado_Pais, 1);
                        //PINTAR AQUI

                        i -= 1;
                        {
                            recibido.Select(i - 3, 5);
                            recibido.SelectionColor = Color.Blue;
                            recibido.SelectionStart = index;
                        }
                        columna++;

                        break;
                    case 25:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 31;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 26:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 32;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 27:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 33;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 28:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 34;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 29:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 35;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 30:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 36;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 31:
                        if (c.CompareTo('c') == 0)
                        {
                            estado = 37;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 32:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 38;

                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 33:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 39;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 34:
                        if (c.CompareTo('r') == 0)
                        {
                            estado = 40;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 35:
                        if (c.CompareTo('c') == 0)
                        {
                            estado = 41;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 36:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 42;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 37:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 43;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 38:
                        agregarToken(Token.Tipo.Reservado_Nombre, 1);
                        columna++;
                        i -= 1;
                        {
                            recibido.Select(i - 5, 7);
                            recibido.SelectionColor = Color.Blue;
                            recibido.SelectionStart = index;
                        }
                        break;
                    case 39:
                        if (c.CompareTo('c') == 0)
                        {
                            estado = 44;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 40:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 45;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 41:
                        if (c.CompareTo('a') == 0)
                        {
                            estado = 46;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 42:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 47;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 43:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 48;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 44:
                        if (c.CompareTo('i') == 0)
                        {
                            estado = 49;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 45:
                        agregarToken(Token.Tipo.Reservado_Bandera, 1);
                        columna++;
                        i -= 1;
                        {
                            recibido.Select(i - 6, 8);
                            recibido.SelectionColor = Color.Blue;
                            recibido.SelectionStart = index;
                        }
                        break;
                    case 46:
                        agregarToken(Token.Tipo.Reservado_Grafica, 1);
                        columna++;
                        i -= 1;
                        {
                            recibido.Select(i - 6, 8);
                            recibido.SelectionColor = Color.Blue;
                            recibido.SelectionStart = index;
                        }
                        break;
                    case 47:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 50;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 48:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 51;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 49:
                        if (c.CompareTo('o') == 0)
                        {
                            estado = 52;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 50:
                        if (c.CompareTo('t') == 0)
                        {
                            estado = 53;
                            columna++;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 51:
                        agregarToken(Token.Tipo.Reservado_Poblacion, 1);
                        columna++;
                        i -= 1;


                        {
                            recibido.Select(i - 8, 10);
                            recibido.SelectionColor = Color.Blue;
                            recibido.SelectionStart = index;
                        }

                        break;
                    case 52:
                        if (c.CompareTo('n') == 0)
                        {
                            estado = 54;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 53:
                        if (c.CompareTo('e') == 0)
                        {
                            estado = 55;
                            auxlex += c;
                        }
                        else
                        {
                            agregarTokenError(Token.Tipo.Desconocido);
                            columna++;
                            i -= 1;
                            vError = 1;
                        }
                        break;
                    case 54:
                        agregarToken(Token.Tipo.Reservado_Saturacion, 1);
                        columna++;
                        i -= 1;
                        {
                            recibido.Select(i - 9, 11);
                            recibido.SelectionColor = Color.Blue;
                            recibido.SelectionStart = index;
                        }
                        break;
                    case 55:
                        agregarToken(Token.Tipo.Reservado_Continente, 1);
                        columna++;
                        i -= 1;
                        {
                            recibido.Select(i - 9, 10);
                            recibido.SelectionColor = Color.Blue;
                            recibido.SelectionStart = index;
                        }
                        break;


                    default:

                        break;




                }
            }

            recibido.SelectionColor = Color.Black;


        }
    }
}