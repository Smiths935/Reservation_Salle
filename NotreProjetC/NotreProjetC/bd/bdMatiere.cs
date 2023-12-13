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
    class bdMatiere
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

        public static void AddMatiere(Matiere std)
        {
            string sql = "INSERT INTO matiere VALUES(NULL,@libelle,@idEns,@nbreHeure)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = std.Libelle;
            cmd.Parameters.Add("@idEns", MySqlDbType.VarChar).Value = std.MatriculeEns ;
            cmd.Parameters.Add("@nbreHeure", MySqlDbType.VarChar).Value = std.NbreHeure;
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

        public static void UpdateMatiere(Matiere std, string id)
        {
            string sql = "UPDATE matiere SET libelle = @libelle,IDEns=@idens,nbreHeure=@nbreH WHERE id=@id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@libelle", MySqlDbType.VarChar).Value = std.Libelle;
            cmd.Parameters.Add("@idens", MySqlDbType.VarChar).Value = std.MatriculeEns;
            cmd.Parameters.Add("@nbreH", MySqlDbType.VarChar).Value = std.NbreHeure;
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


        public static void DeleteMatiere(string id)
        {
            string sql = "DELETE FROM matiere WHERE id =@num";
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
