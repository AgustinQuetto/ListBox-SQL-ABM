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
    public partial class Agregar : Form
    {
        ProvedorDeDatos proveedor = new ProvedorDeDatos();
        Persona persona;
        bool estado;
        int id;

        public Agregar()
        {
            InitializeComponent();
        }

        public Agregar(Persona per, bool estado)
            : this()
        {
            persona = new Persona(per.id, per.nombre, per.apellido, per.edad);
            txtNombre.Text = per.nombre;
            txtApellido.Text = per.apellido;
            txtEdad.Text = per.edad.ToString();
            this.id = per.id;
            this.estado = estado;
        }

        private void Agregar_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (persona == null)
            {
                persona = new Persona(txtNombre.Text, txtApellido.Text, int.Parse(txtEdad.Text));
                proveedor.AgregarPersonaBD(persona);
            }
            else
            {
                switch (this.estado)
                {
                    case false:
                        proveedor.EliminarPersonaBD(this.persona.id);
                        break;
                    case true:
                        persona.nombre = txtNombre.Text;
                        persona.apellido = txtApellido.Text;
                        persona.edad = int.Parse(txtEdad.Text);
                        proveedor.ModificarPersonaBD(this.persona);
                        break;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
