using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace ABM
{
    public partial class Form1 : Form
    {
        List<Persona> lista = new List<Persona>();
        ProvedorDeDatos proveedor = new ProvedorDeDatos();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Refrescar();
        }

        public void Refrescar()
        {
            this.listBox1.Items.Clear();
            this.lista = this.proveedor.ObtenerPersonaBD();
            foreach (Persona per in lista)
            {
                listBox1.Items.Add(per);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar agregar = new Agregar();
            agregar.ShowDialog();
            if (agregar.DialogResult == DialogResult.OK)
            {
                this.Refrescar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = this.listBox1.SelectedIndex;
            Persona per = lista[id];
            bool estado = false;
            Agregar agregar = new Agregar(per, estado);
            agregar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = this.listBox1.SelectedIndex;
            Persona per = lista[id];
            bool estado = true;
            Agregar agregar = new Agregar(per, estado);
            agregar.ShowDialog();
        }


    }
}
