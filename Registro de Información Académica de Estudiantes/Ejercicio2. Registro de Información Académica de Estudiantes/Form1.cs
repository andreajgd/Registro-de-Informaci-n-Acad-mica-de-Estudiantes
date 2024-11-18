using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ejercicio2.Registro_de_Información_Académica_de_Estudiantes
{
    public partial class Form1 : Form
    {
        //almacena objetos tipo estudiantes 
        List<Estudiantes> est = new List<Estudiantes>() { };

        public Form1()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guardar()
        {
            string nombre = txtNombre.Text;
            string apellidoss = txtApellido.Text;
            int num = int.Parse(txtNum.Text);
            string carreras = cmbCarreras.SelectedItem.ToString();
            int materias = int.Parse(txtMaterias.Text);
            int promedio = int.Parse(txtPromedio.Text);

            est.Add(new Estudiantes(nombre, apellidoss, num, carreras, materias, promedio));
            Actualizar();
            LimpiarCampos();
            ActualizarGrafica();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNum.Clear();
            cmbCarreras.SelectedIndex = -1;
            txtMaterias.Clear();
            txtPromedio.Clear();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();

        }

        private void Actualizar()
        {
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = est;
            ActualizarGrafica() ;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Eliminar()
        {
            int i = dgvEstudiantes.CurrentCell.RowIndex;
            est.RemoveAt(i);
            Actualizar();
            ActualizarGrafica() ;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void tlsGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void tlsActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void tlsEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarGrafica()
        {
            //limpiar configuración previa
            chart1.Series.Clear();
            chart1.Titles.Clear();

            //configura título y ejes
            chart1.Titles.Add("Distribución de Estudiantes por Carrera");
            chart1.ChartAreas[0].AxisX.Title = "Carreras";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Title = "Cantidad de Estudiantes";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "0"; //forzar valores enteros en las etiquetas
            chart1.ChartAreas[0].AxisY.Interval = 1;    

            Series serie = new Series("Estudiantes")
            {
                ChartType = SeriesChartType.Column,  //se define el tipo de gráfico 
                IsValueShownAsLabel = true  //configura el valor de cada barra se muestre en la parte superior de la columna
            };

            var estudiantesPorCarrera = est
                .GroupBy(e => e.Carrera)
                .Select(g => new { Carrera = g.Key, Cantidad = g.Count() });

            foreach (var grupo in estudiantesPorCarrera)
            {
                serie.Points.AddXY(grupo.Carrera, grupo.Cantidad);
            }

            //agrega la serie al gráfico
            chart1.Series.Add(serie);
            chart1.Invalidate();  //le indica al gráfico que debe volver a dibujarse

            ActualizarStatusStrip();
        }

        private void ActualizarStatusStrip()
        {
            toolStripStatusLabel.Text = $"Número de estudiantes registrados: {est.Count}";
        }

    }
}