using NotreProjetC.screens.add;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotreProjetC.screens.list
{
    public partial class FormSalle : Form
    {
        AddSalle form;
        public FormSalle()
        {
            InitializeComponent();
            form = new AddSalle(this);
        }
        public void Display()
        {
            bdSalle.DisplayAndSearch("SELECT num,ID,Capacite,disponible FROM Salles", dataGridView1);

        }

        private void FormSalle_Load(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.clearFill();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            bdSalle.DisplayAndSearch("SELECT num,ID,Capacite,disponible FROM Salles WHERE ID LIKE '%" + textSearch.Text + "%'", dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                form.clearFill();
                form.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.@ref = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.capacite = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                textSearch.Text = "";

                return;
            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are you want to delete student record ?", " Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    bdSalle.DeleteSalle(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    textSearch.Text = "";
                    Display();
                }
                return;
            }
        }
    }
}
