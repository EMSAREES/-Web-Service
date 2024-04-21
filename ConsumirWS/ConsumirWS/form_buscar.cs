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
    public partial class form_buscar : Form
    {
        public int index = 0;
        public string isbn = "";

        public form_buscar()
        {
            InitializeComponent();
        }

        private void btm_buscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            wbLibros x = new wbLibros();
            DataSet ds = new DataSet();
            ds = x.buscar(txt_filtro.Text);

            dt.Columns.Add("id");
            dt.Columns.Add("ISBN");
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Autor");
            dt.Columns.Add("Genero");

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                DataRow dr = dt.NewRow();
                dr[0] = r["id"].ToString();
                dr[1] = r["ISBN"].ToString();
                dr[2] = r["Titulo"].ToString();
                dr[3] = r["Autor"].ToString();
                dr[4] = r["Genero"].ToString();
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;  
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    index = dataGridView1.CurrentRow.Index;
               
            //}
            //catch (Exception ex) 
            //{

            //}
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
            }
            catch
            {

            }
            try
            {
                isbn = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                
            }
            
        }
    }
}
