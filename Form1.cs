using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblRuta.Text = openFileDialog1.FileName;
            }
            else {
                lblRuta.Text = "Selecciona un archivo";
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string ruta = lblRuta.Text;
            if (ruta == "Selecciona un archivo" || ruta == "")
            {
                MessageBox.Show("Error debes seleccionar un archivo");
            }
            else
            {
                try 
                {
                    SLDocument sl = new SLDocument(@ruta);
                    SLWorksheetStatistics propiedades = sl.GetWorksheetStatistics();

                    int ultimaFila = propiedades.EndRowIndex + 1;
                    MySqlConnection conexionDB = Conexion.conexion();
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
                    try
                    {
                        conexionDB.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al conectar con la base de datos");
                    }
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa

#pragma warning disable CS0219 // La variable está asignada pero nunca se usa su valor
                    string error = "";
#pragma warning restore CS0219 // La variable está asignada pero nunca se usa su valor
                    string vid_no_orden = sl.GetCellValueAsString("A" + 1);
                    string vid_cliente = sl.GetCellValueAsString("B" + 1);
                    string vid_no_ventana = sl.GetCellValueAsString("C" + 1);
                    string vid_tipo = sl.GetCellValueAsString("D" + 1);
                    string vid_cantidad = sl.GetCellValueAsString("E" + 1);
                    string vid_ancho = sl.GetCellValueAsString("F" + 1);
                    string vid_alto = sl.GetCellValueAsString("G" + 1);
                    string id_ventana = sl.GetCellValueAsString("H" + 1);



                    if (existeOrden(vid_no_orden))
                    {
                        MessageBox.Show("Ya existe la orden: " + vid_no_orden + "\n");
                        lblRuta.Text = "Selecciona un archivo";
                    }
                    else if (vid_no_orden == "" || vid_cliente == "" || vid_no_ventana == "" || vid_tipo == "" || vid_cantidad == "" || vid_ancho == "" || vid_alto == "")
                    {
                        MessageBox.Show("Algunas de las celdas estan vacías, verifique el formato");
                    }
                    else
                    {
                        for (int x = 1; x < ultimaFila; x++)
                        {


                            string tipoVidrio = sl.GetCellValueAsString("D" + x);
                            int cantidad = sl.GetCellValueAsInt32("E" + x);
                            string camara = tipoVidrio.Extract(13);
                            // MessageBox.Show("esto es lo que se extrajo: " + camara);
                            if (camara == "VIDRIO CAMARA")
                            {
                                cantidad = cantidad * 2;
                            }
                            else
                            {
                                cantidad = cantidad * 1;
                            }

                            for (int i = 0; i < cantidad; i++)
                            {
                                try
                                {
                                    string sql = "INSERT INTO vidrios(VID_NO_ORDEN,VID_CLIENTE, VID_NO_VENTANA,VID_TIPO, VID_CANTIDAD, VID_ANCHO,VID_ALTO" +
                            ")VALUES(@VID_NO_ORDEN,@VID_CLIENTE,@VID_NO_VENTANA, @VID_TIPO, @VID_CANTIDAD, @VID_ANCHO, @VID_ALTO)";

                                    MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                                    comando.Parameters.AddWithValue("@VID_NO_ORDEN", sl.GetCellValueAsString("A" + x));
                                    comando.Parameters.AddWithValue("@VID_CLIENTE", sl.GetCellValueAsString("B" + x));
                                    comando.Parameters.AddWithValue("@VID_NO_VENTANA", sl.GetCellValueAsString("C" + x));
                                    comando.Parameters.AddWithValue("@VID_TIPO", sl.GetCellValueAsString("D" + x));
                                    comando.Parameters.AddWithValue("@VID_CANTIDAD", sl.GetCellValueAsString("E" + x));
                                    comando.Parameters.AddWithValue("@VID_ANCHO", sl.GetCellValueAsString("F" + x));
                                    comando.Parameters.AddWithValue("@VID_ALTO", sl.GetCellValueAsString("G" + x));
                                    comando.ExecuteNonQuery();
                                }
                                catch (MySqlException ex)
                                {

                                    MessageBox.Show(ex.Message);
                                }
                            }

                        }
                        MessageBox.Show("Datos Cargados");
                        lblRuta.Text = "Selecciona un archivo";
                    }



                } catch 
                {
                    MessageBox.Show("El documento esta abierto por otro programa, cierralo y vuelve a intentarlo");
                }


                
            }
        }

        private void ejecutarReporte_Click(object sender, EventArgs e)
        {
            ReporteVidrios rv = new ReporteVidrios();
            rv.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String orden = txtEliminarOrden.Text;

            if (orden == "")
            {
                MessageBox.Show("Debes agregar el número de orden");
            }
            else 
            {
                bool bandera =  existeOrden(orden);
                if (bandera == false) 
                {
                    MessageBox.Show("Numero de orden no existe");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Se va a eliminar la orden: " + orden,"Advertencia", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        
                        MySqlConnection conexionDB = Conexion.conexion();
                        try
                        {
                            conexionDB.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al conectar con la base de datos" + ex);
                        }
                        try
                        {
                            string sql = "DELETE FROM vidrios WHERE VID_NO_ORDEN = '" + orden+ "'";
                            MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                            comando.ExecuteScalar();
                            MessageBox.Show("Orden: "+orden+" Eliminada");
                        }
                        catch
                        {
                        }

                    }
                    else 
                    {
                        //MessageBox.Show("te dare opcion a revisar");
                    }

                }
            }
        }
    }
}
public static class StringExtensions
{
    public static string Extract(this string input, int len)
    {
        if (string.IsNullOrEmpty(input) || input.Length < len)
        {
            return input;
        };

        return input.Substring(0, len);
    }
}
