using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotreProjetC.bd
{
    class bdEnseignant
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;username=root;password=;database=projetC";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Mysql Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void AddProf(Enseignant std)
        {
            string sql = "INSERT INTO enseignant VALUES(NULL,@mat,@nom,@tel)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@mat", MySqlDbType.VarChar).Value = std.Matricule;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = std.Nom;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = std.Tel;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateSalle(Enseignant std, string id)
        {
            string sql = "UPDATE enseignant SET Matricule = @mat,Nom=@nom, Tel=@tel WHERE id=@id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@mat", MySqlDbType.VarChar).Value = std.Matricule;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = std.Nom;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = std.Tel;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not Update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

       
        public static void DeleteSalle(string id)
        {
            string sql = "DELETE FROM enseignant WHERE id =@num";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = id;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfuly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not Delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
