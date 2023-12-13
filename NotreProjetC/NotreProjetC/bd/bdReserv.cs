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
    class bdReserv
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

        public static void AddReserv(Reservation std)
        {
            string sql = "INSERT INTO Reservation VALUES(NULL,@heureD,@heureF,@idE,@idS,@dateR,@numSalle,@nomEnsei,@matiere)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@heureD", MySqlDbType.VarChar).Value = std.HeureD;
            cmd.Parameters.Add("@heureF", MySqlDbType.VarChar).Value = std.HeureF;
            cmd.Parameters.Add("@idE", MySqlDbType.VarChar).Value = std.IDE;
            cmd.Parameters.Add("@idS", MySqlDbType.VarChar).Value = std.IDS;
            cmd.Parameters.Add("@dateR", MySqlDbType.VarChar).Value = std.DateR;
            cmd.Parameters.Add("@numSalle", MySqlDbType.VarChar).Value = std.numSalle;
            cmd.Parameters.Add("@nomEnsei", MySqlDbType.VarChar).Value = std.NommEnse;
            cmd.Parameters.Add("@matiere", MySqlDbType.VarChar).Value = std.Matiere;
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

        public static void UpdateReserv(Reservation std, string id)
        {
            string sql = "UPDATE Reservation SET heurD=@heureD,heureF@heureF,IdE=@idE,idS=@idS,DateR=@dateR,numSalle=@numSalle,nomEnsei=@nomEnsei,matiere=@matiere WHERE ID=@ID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = id;
            cmd.Parameters.Add("@heureD", MySqlDbType.VarChar).Value = std.HeureD;
            cmd.Parameters.Add("@heureF", MySqlDbType.VarChar).Value = std.HeureF;
            cmd.Parameters.Add("@idE", MySqlDbType.VarChar).Value = std.IDE;
            cmd.Parameters.Add("@idS", MySqlDbType.VarChar).Value = std.IDS;
            cmd.Parameters.Add("@dateR", MySqlDbType.VarChar).Value = std.DateR;
            cmd.Parameters.Add("@numSalle", MySqlDbType.VarChar).Value = std.numSalle;
            cmd.Parameters.Add("@nomEnsei", MySqlDbType.VarChar).Value = std.NommEnse;
            cmd.Parameters.Add("@matiere", MySqlDbType.VarChar).Value = std.Matiere;
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


        public static void DeleteReserv(string id)
        {
            string sql = "DELETE FROM Reservation WHERE ID =@ID";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = id;
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
