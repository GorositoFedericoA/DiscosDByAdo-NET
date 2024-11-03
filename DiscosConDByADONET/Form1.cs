using DiscosConDByADONET.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiscosConDByADONET
{
    public partial class Form1 : Form
    {
        private List<Discos> listaDiscos = new List<Discos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DiscosData discosdata = new DiscosData();
            listaDiscos = discosdata.Listar();
            dgvDiscos.DataSource = listaDiscos;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            CargarImagen(listaDiscos[0].UrlImagenTapa);
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
            CargarImagen(seleccionado.UrlImagenTapa);
        }


        private void CargarImagen(string imagen)
        {
            try
            {
                picBoxDiscos.Load(imagen);
            }
            catch (Exception)
            {

                picBoxDiscos.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

    }
}
