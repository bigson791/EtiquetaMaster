using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtiquetaMaster
{
    public partial class ReporteVidrios : Form
    {
        public ReporteVidrios()
        {
            InitializeComponent();
        }

        private bool existeOrden(string no_orden)
        {
            MySqlConnection conexionDB = Conexion.conexion();
            try
            {
                conexionDB.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos, contacte al administrador del sistema.");
            }

            string sql = "SELECT COUNT(VID_NO_ORDEN) FROM vidrios WHERE VID_NO_ORDEN = '" + no_orden + "'";
            MySqlCommand comando = new MySqlCommand(sql, conexionDB);

            int cantidad = Convert.ToInt32(comando.ExecuteScalar());

            if (cantidad > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        private void FORM_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'vidriosDataSet.tbVidrios' Puede moverla o quitarla según sea necesario.
            //this.tbVidriosTableAdapter.Fill(this.vidriosDataSet.tbVidrios);
            //this.dataTableTableAdapter.getHojasVentana(this.DataSet1.DataTable);

            //this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void lblRuta_Click(object sender, EventArgs e)
        {

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            string numeroOrden = txtNumOrden.Text;
            bool orden = existeOrden(numeroOrden);
            if (orden)
            {
                this.tbVidriosTableAdapter.consultaPorNumeroOrden(this.vidriosDataSet.tbVidrios, numeroOrden);
                this.reportViewer1.RefreshReport();
            }
            else {
                MessageBox.Show("El número de orden no existe.");
            }
        }

        private void consultaPorNumeroOrdenToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void vID_NO_ORDENToolStripTextBox_Click(object sender, EventArgs e)
        {

        }

        private void txtNumOrden_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtNumOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string numeroOrden = txtNumOrden.Text;
                bool orden = existeOrden(numeroOrden);
                if (orden)
                {
                    this.tbVidriosTableAdapter.consultaPorNumeroOrden(this.vidriosDataSet.tbVidrios, numeroOrden);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("El número de orden no existe.");
                }
            }
        }
    }
}
