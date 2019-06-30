using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Capturar()
        {
            File.WriteAllText("fecha.text", DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void comprobar()
        {
            try
            {
                string dia = "", mes = "", año = "";
                string[] corte;

                bool error = false;

                corte = File.ReadAllText("fecha.text").Split('/');
                dia = corte[0];
                mes = corte[1];
                año = corte[2];

                File.WriteAllText("fecha1.text",DateTime.Now.ToString("dd/MM/yyyy"));

                string[] corte1 = File.ReadAllText("fecha1.text").Split('/');

                if (int.Parse(corte1[2]) >= int.Parse(año))
                {
                    if (int.Parse(corte1[1]) == int.Parse(mes))
                    {
                        if (int.Parse(corte1[0]) >= int.Parse(dia))
                        {
                            txtfecha.Text = "La hora esta correcta";
                        }
                        else
                            error = true;
                    }
                    else
                        error = true;

                    if (int.Parse(corte1[1]) > int.Parse(mes))
                    {
                        txtfecha.Text = "La hora esta correcta";
                        error = false;
                    }


                }
                else
                    error = true;

                if(error == true)
                {
                    txtfecha.Text = "Se retraso la fecha";
                }
            }
            catch
            {

            }
            finally
            {
                File.Delete("fecha1.text");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Capturar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comprobar();
        }
    }
}
