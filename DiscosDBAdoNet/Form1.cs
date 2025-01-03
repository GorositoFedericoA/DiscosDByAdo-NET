using DiscosDBAdoNet.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscosDBAdoNet
{
    public partial class Form1 : Form
    {
        private List <Disco> _discoLista;

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
            DiscoNegocio discos = new DiscoNegocio();
            _discoLista = discos.Listar();
            dgvDiscos.DataSource = _discoLista;9
            dgvDiscos.Columns["Id"].Visible = false;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            CargarImagen(_discoLista[0].UrlImagenTapa);

        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = new Disco();

            seleccionado = (Disco) dgvDiscos.CurrentRow.DataBoundItem;

            CargarImagen(seleccionado.UrlImagenTapa);

        }




        private void CargarImagen(string imagen) 
        {
            try
            {
                picBox.Load(imagen);
            }
            catch (Exception ex)
            {

                picBox.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReiKeTsm26jLOx1RQhXGkRSPWNj2tCeMKdUA&s");
            }
        }

    }
}
