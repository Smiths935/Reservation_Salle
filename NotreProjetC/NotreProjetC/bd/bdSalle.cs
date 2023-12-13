using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace NotreProjetC
{
    class bdSalle
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

        public static void AddSalle(SalleDeClasse std)
        {
            string sql = "INSERT INTO Salles VALUES(NULL,@id,@capacite,@disponible)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = std.ID;
            cmd.Parameters.Add("@capacite", MySqlDbType.VarChar).Value = std.Capacite;
            cmd.Parameters.Add("@disponible", MySqlDbType.VarChar).Value = std.Disponibilite;
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

        public static void UpdateSalle(SalleDeClasse std, string id)
        {
            string sql = "UPDATE Salles SET ID = @id,Capacite=@capacite,Disponible=@disponible WHERE num=@idsalle";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@idsalle", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = std.ID;
            cmd.Parameters.Add("@capacite", MySqlDbType.VarChar).Value = std.Capacite;
            cmd.Parameters.Add("@disponible", MySqlDbType.VarChar).Value = std.Disponibilite;
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
            string sql = "DELETE FROM Salles WHERE num =@num";
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
