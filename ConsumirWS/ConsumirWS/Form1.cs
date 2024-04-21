using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ConsumirWS.red_local;

namespace ConsumirWS
{
    public partial class FRMLibros : Form
    {
        wbLibros x = new wbLibros();

        public FRMLibros()
        {
            InitializeComponent();
        }

        private void FRMLibros_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            Txt_isbm.Clear();
            Txt_titulo.Clear();
            Txt_autor.Clear();
            Txt_genero.Clear();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //ds = x.obtener(int.Parse(Txt_id.Text));
            
            //foreach(DataRow r in ds.Tables[0].Rows)
            //{
            //    Txt_isbm.Text = r[1].ToString();
            //    Txt_titulo.Text = r[2].ToString();
            //    Txt_autor.Text = r[3].ToString();
            //    Txt_genero.Text = r[4].ToString();
            //}


            form_buscar r = new form_buscar();
            r.ShowDialog();

            if(r.DialogResult == DialogResult.OK)
            {
                Txt_id.Text = r.dataGridView1.Rows[r.index].Cells[0].Value.ToString();
                Txt_isbm.Text = r.isbn;
                Txt_titulo.Text = r.dataGridView1.Rows[r.index].Cells[2].Value.ToString();
                Txt_autor.Text = r.dataGridView1.Rows[r.index].Cells[3].Value.ToString();
                Txt_genero.Text = r.dataGridView1.Rows[r.index].Cells[4].Value.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Txt_id.Text);
            int isbm = int.Parse(Txt_isbm.Text);
            MessageBox.Show(x.guardar(id, isbm, Txt_titulo.Text, Txt_autor.Text, Txt_genero.Text));

            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(x.eliminar(int.Parse(Txt_id.Text)));

            Limpiar();
        }

    }
}
