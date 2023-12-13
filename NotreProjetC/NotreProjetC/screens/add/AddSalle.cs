using NotreProjetC.screens.list;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotreProjetC.screens.add
{
    public partial class AddSalle : Form
    {
        private readonly FormSalle _parent;

        public string id,@ref,capacite;

        public AddSalle(FormSalle parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            btnSave.Text = "Update";
            label1.Text = "Update Student";
            textRef.Text = @ref;
            textCap.Text = capacite;

        }

        public void SaveInfo()
        {
            btnSave.Text = "Save";
            label1.Text = "Add Student";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textRef.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name is Empty ( > 3 ).");
                return;
            }
            if (textCap.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student Reg is Empty ( > 1 ).");
                return;
            }

            if (btnSave.Text == "Save")
            {
                SalleDeClasse std = new SalleDeClasse(textRef.Text.Trim(), textCap.Text.Trim());
                bdSalle.AddSalle(std);
                clearFill();
            }

            if (btnSave.Text == "Update")
            {
                SalleDeClasse std = new SalleDeClasse(textRef.Text.Trim(), textCap.Text.Trim());
                bdSalle.UpdateSalle(std, id);
                clearFill();
            }

            _parent.Display();
        }

        public void clearFill()
        {
            textRef.Text = textCap.Text = string.Empty;
        }

        private void AddSalle_Load(object sender, EventArgs e)
        {

        }
    }
}
