using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotreProjetC.screens
{
    public partial class AddProf : Form
    {

        public string id, name, tel, mat;

        public AddProf()
        {
            InitializeComponent();
        }

        public void UpdateInfo()
        {
            btnSave.Text = "Update";
            label1.Text = "Update Prof";
            textName.Text = name;
            textMat.Text = mat;
            textTel.Text = tel;

        }

        public void SaveInfo()
        {
            btnSave.Text = "Save";
            label1.Text = "Add Prof";
        }

        public void clearFill()
        {
            textName.Text = textMat.Text = textTel.Text = string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name is Empty ( > 3 ).");
                return;
            }
            if (textMat.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student Reg is Empty ( > 1 ).");
                return;
            }
            if (textTel.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student Class is Empty ( > 1 ).");
                return;
            }

            if (btnSave.Text == "Save")
            {
                Enseignant std = new Enseignant(textMat.Text.Trim(), textName.Text.Trim(), textTel.Text.Trim());
                bdEnseignant.AddStudent(std);
                clearFill();
            }

            if (btnSave.Text == "Update")
            {
                Student std = new Student(textName.Text.Trim(), textName.Text.Trim(), textClass.Text.Trim(), textSect.Text.Trim());
                dbStudent.UpdateStudent(std, id);
                clearFill();
            }
        }
    }
}
