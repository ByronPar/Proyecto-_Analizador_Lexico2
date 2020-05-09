using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1_Lenguajes
{
    public partial class Form1 : Form
    {
        int contarpestaña = 1;
        ArrayList ListaPestaña = new ArrayList();
        ArrayList ListaCaja = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void CrearPestaña()
        {
            TabPage NuevaPestaña = new TabPage("Pestaña  " + contarpestaña);
           // TextBox nuevoCaja = new TextBox();
            RichTextBox nuevoCaja = new RichTextBox();
            nuevoCaja.Multiline = true;
            nuevoCaja.Location = new Point(5, 5);
            //nuevoCaja.ScrollBars = ScrollBars.Vertical;
           // nuevoCaja.AcceptsReturn = true;
            nuevoCaja.AcceptsTab = false;
            nuevoCaja.WordWrap = true;
            nuevoCaja.Height = 440;
            nuevoCaja.Width = 380;

            NuevaPestaña.Controls.Add(nuevoCaja);


            ListaPestaña.Add(NuevaPestaña);
            ListaCaja.Add(nuevoCaja);




            tabControl1.TabPages.Add(NuevaPestaña);

            contarpestaña++;
            tabControl1.SelectedTab = NuevaPestaña;
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programa Realizado por:      Byron Josué Par Rancho" +
                "\n\n" +
                "\nCarnet: 201701078" +
                "\n\n" +
                "\nEstudiante de Ingenieria en Ciencias y Sistemas" +
                "\n\n" +
                "\nProyecto Número 1 - Lenguajes Formales y de Programación" +
                "\n\n" +
                "\nSección: A+   "+
                "\n\n" +
                "\nAuxiliar :  Elmer Orlando Real Ixcayau" +
                "\n\n" +
                "\nIngeniero : Otto Rodriguez" +
                "\n\n" +
                "\nSección: A+   ");
        }

        private void AbrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (contarpestaña == 1)
            {
                MessageBox.Show("Debe Crear una Pestaña para Empezar");
            }
            else
            {
                //CONTINUAR AQUI DESPUES DE CENAR XD
                OpenFileDialog ventana = new OpenFileDialog();
                ventana.Filter = "Archivos ORG(*.ORG)|*.ORG";
                ventana.Title = "Archivos ORG";
                ventana.FileName = "Sin titulo... ";

                if (ventana.ShowDialog() == DialogResult.OK)
                {
                    //AQUI DEBO COLOCAR LA FUNCIONALIDAD PARA OBTENER EL TEXTO
                    StreamReader leer = new StreamReader(ventana.FileName);


                    foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                    {
                        if (ctrl is RichTextBox)
                        {
                            //Si entra, es que se tiene un richtextBox (utilizo rich para la propiedad de pintar las palabras)

                            ctrl.Text = leer.ReadToEnd();
                            leer.Close();
                           
                        }
                    }

                }
            }

        }

        private void NuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearPestaña();
        }

        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contarpestaña == 1)
            {
                MessageBox.Show("Debe Crear una Pestaña para Empezar");
            }
            else
            {
                foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                {
                    if (ctrl is RichTextBox)
                    {
                        //Si entra, es que se tiene un textbox

                        SaveFileDialog guardar = new SaveFileDialog();
                        guardar.InitialDirectory = @"C:\";
                        guardar.RestoreDirectory = true;
                        guardar.FileName = "*.txt";
                        guardar.DefaultExt = "txt";
                        guardar.Filter = "txt files (*.txt)|*.txt";

                        if (guardar.ShowDialog() == DialogResult.OK)
                        {
                            Stream fileStream = guardar.OpenFile();
                            StreamWriter algo = new StreamWriter(fileStream);
                            algo.Write(ctrl.Text);
                            algo.Close();
                            fileStream.Close();

                        }

                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //AnalizadorLexico lex = new AnalizadorLexico();
            //LinkedList<Token> lTokens = lex.escanear(entrada);
            //lex.imprimirListaToken(lTokens);



            if (contarpestaña == 1)
            {
                MessageBox.Show("Debe Crear una Pestaña para Empezar");
            }
            else
            {
                RichTextBox enviar;
                String entrada = "";
                foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                {
                    if (ctrl is RichTextBox)
                    {
                        //Si entra, es que se tiene un richtextbox

                        entrada = ctrl.Text;
                    }
                }

                // String entrada= textBox2.Text;
                AnalizadorLexico lex = new AnalizadorLexico();
                LinkedList<Token> lTokens = lex.escanear(entrada);
                //lex.imprimirListaToken(lTokens);
                

                foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                {
                    if (ctrl is RichTextBox)
                    {
                        
                       
                        enviar = (RichTextBox) ctrl;
                    
                        lex.generarReporte(lTokens, entrada, enviar,textBox1,pictureBox2,pictureBox1);

                    }
                }

               




            }
        }

        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (contarpestaña == 1)
            {
                MessageBox.Show("Debe Crear una Pestaña para Empezar");
            }
            else
            {
                foreach (Control ctrl in tabControl1.SelectedTab.Controls)
                {
                    if (ctrl is RichTextBox)
                    {
                        //Si entra, es que se tiene un richtextbox
                        String vacio = "";
                        ctrl.Text = vacio;
                        pictureBox1.Image = null;
                        pictureBox2.Image = null;
                        textBox1.Text = "";
                    }
                }
            }
        }
    }
}
