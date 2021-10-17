using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G4_Ejercicio2
{
    public partial class FrmMenu : Form
    {
        //Creamos una lista para almacenar los objetos de la clase ingeniería
        private List<Ingenieria> Ingenieros = new List<Ingenieria>();
        private int edit_indice = -1;
        //Creamos el Data Table en la que vamos a intrducir la lista para mostrarla posteriormente en el DGV
        DataTable ListaIngenieros = new DataTable();

        //Con este metodo vamos a limpiar todos los campos para que puedan ingresar unos nuevos
        private void limpiarCampos()
        {
            txtcarnet.Clear();
            txtcarrera.Clear();
            txtcum.Clear();
            txthcompletas.Clear();
            txthtotales.Clear();
            txtmateriasinscritas.Clear();
            txtnomproyecto.Clear();
            txtnota1.Clear();
            txtnota2.Clear();
            txtnota3.Clear();
            txtnota4.Clear();
            txtnota5.Clear();
            txtcarnet.Focus();
        }

        //Este metodo limpiar, lo usaremos ya en el buscador
        private void limpiarbusqueda()
        {
            txtbuscaruni.Clear();
            Dgvingenieria.DataSource = null;
        }
        
        //El siguiente metodo llenará el DGV con los datos de la lista
        private void LlenarGrid(List<Ingenieria> Ingenieros)
        {
            ListaIngenieros.Rows.Clear();
            foreach (Ingenieria v in Ingenieros)
            {
                ListaIngenieros.Rows.Add(v.Carnet, v.NivelEstudios, v.Universidad, v.Carrera, v.MateriasInscritas, v.Cum, v.Promedio, v.Nombreproyecto, v.Thoras, v.Nhorascompletas);
            }
            Dgvingenieria.DataSource = null;
            Dgvingenieria.DataSource = ListaIngenieros;

        }

        public FrmMenu()
        {
            InitializeComponent();

            //Agregamos columnas al data table
            ListaIngenieros.Columns.Add(new DataColumn("Carnet", typeof(string)));
            ListaIngenieros.Columns.Add(new DataColumn("Estudios", typeof(string)));
            ListaIngenieros.Columns.Add(new DataColumn("Universidad", typeof(string)));
            ListaIngenieros.Columns.Add(new DataColumn("Carrera", typeof(string)));
            ListaIngenieros.Columns.Add(new DataColumn("Materias Inscritas", typeof(int)));
            ListaIngenieros.Columns.Add(new DataColumn("CUM", typeof(double)));
            ListaIngenieros.Columns.Add(new DataColumn("Promedio", typeof(double)));
            ListaIngenieros.Columns.Add(new DataColumn("Nombre pryecto", typeof(string)));
            ListaIngenieros.Columns.Add(new DataColumn("Total horas", typeof(double)));
            ListaIngenieros.Columns.Add(new DataColumn("Horas completas", typeof(double)));
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Salir",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)== DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnañadir_Click(object sender, EventArgs e)
        {
            //Creamos el objeto de la clase Ingenieria
            Ingenieria ing = new Ingenieria();

            //Hacemos el procedimiento para sacar el promedio gracias a los datos de las notas
            double prom;
            double sum;
            double nota1 = double.Parse(txtnota1.Text);
            double nota2 = double.Parse(txtnota2.Text);
            double nota3 = double.Parse(txtnota3.Text);
            double nota4 = double.Parse(txtnota4.Text);
            double nota5 = double.Parse(txtnota5.Text);

            sum = nota1 + nota2 + nota3 + nota4 + nota5;
            prom = sum / 5;

            //Asignamos las variables a los datos que entraran en los text box
            ing.Carnet = txtcarnet.Text;
            ing.Carrera = txtcarrera.Text;
            ing.MateriasInscritas = int.Parse(txtmateriasinscritas.Text);
            ing.Cum = double.Parse(txtcum.Text);
            ing.Promedio = prom;
            ing.Nombreproyecto = txtnomproyecto.Text;
            ing.Thoras = double.Parse(txthtotales.Text);
            ing.Nhorascompletas = double.Parse(txthcompletas.Text);

            //Hacemos los casos para el ingreso de los datos de "Nivel de estudios"

            //Caso de Nivel de Estudios de "Bachillerato"
            if (cmboxlvlestudios.SelectedItem.ToString() == "Bachillerato")
            {
                ing.NivelEstudios = "Bachillerato";
            }
            //Caso de Nivel de Estudios "Tecnico"
            if (cmboxlvlestudios.SelectedItem.ToString()=="Tecnico")
            {
                ing.NivelEstudios = "Tecnico";
            }
            //Caso de Nivel de Estudios "Ingenieria"
            if (cmboxlvlestudios.SelectedItem.ToString() == "Ingeniería ")
            {
                ing.NivelEstudios = "Ingeniería ";
            }

            //Ahora hacemos los casos para el ingreso de los datos "Nombre de Universidad"

            //Caso de Universidad "Don Bosco"
            if (cmboxuniversidad.SelectedItem.ToString() == "Don Bosco")
            {
                ing.Universidad = "Don Bosco";
            }
            //Caso de Universidad "Nacional"
            if (cmboxuniversidad.SelectedItem.ToString() == "Nacional")
            {
                ing.Universidad = "Nacional";
            }
            //Caso de Universidad "Francisco Gavidia"
            if (cmboxuniversidad.SelectedItem.ToString() == "Francisco Gavidia")
            {
                ing.Universidad = "Francisco Gavidia";
            }

            //Este IF verificará si hay un índice seleccionado
            if (edit_indice > -1)
            {
                Ingenieros[edit_indice] = ing;
                edit_indice = -1;
            }
            else
            {
                Ingenieros.Add(ing); //Al arreglo Ingenieros, le añado el objeto "ing"
            }

            limpiarCampos();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //En esta variable almacenaremos la universidad que se buscará
            string unibuscar = txtbuscaruni.Text.Trim();

            //En esta lista se alamacenaran solamente aquellas universidades que busquemos
            List<Ingenieria> lista = new List<Ingenieria>();

            foreach (Ingenieria v in Ingenieros)
            {
                if (String.Concat(v.Universidad).ToUpper().Contains(unibuscar.ToUpper()))
                {
                    lista.Add(v); //Mostramos una lista con los filtrso ya aplicados
                }
            }
            LlenarGrid(lista);
            
        }



        private void Frmmenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            //Mostrará la lista con los datos registrados en ese momento
            LlenarGrid(Ingenieros);
        }
    }
}
