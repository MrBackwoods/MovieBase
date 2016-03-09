using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;


namespace MovieBase
{
    class DatabaseHandler
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "DB";
        private string uid = "root";
        private string password = "PW";

        private void  OpenConnection()
        {
        string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Cannot connect to server.");
                Application.Exit();
            }
        }

        public List<Movie> GetMovies()
        {
            List <Movie> movies = new List<Movie>();
            string query = "SELECT * FROM movie";
            OpenConnection();

            DataSet tableSet = new DataSet();
            MySqlDataAdapter dataAdapter;
            dataAdapter = new MySqlDataAdapter(query, connection);
            dataAdapter.Fill(tableSet, "result");
            DataTable table = tableSet.Tables["result"];
            CloseConnection(); 

            foreach (DataRow row in table.Rows)
            {
                Movie movie = new Movie();
                movie.Id = Convert.ToInt32(row[0]);
                movie.Name = row[1].ToString();
                movie.Director = row[2].ToString();
                movie.ReleaseYear = row[3].ToString();
                movie.Note = row[4].ToString();
                movie.Review = Convert.ToInt32(row[5]);
                movies.Add(movie);
            }

            CloseConnection();
            return movies;
        }


        public void UpdateMovie(Movie movie) {
            OpenConnection();
            string query = "UPDATE movie SET Name='" + movie.Name + "', Review='" + movie.Review + "', Director='" + movie.Director + "', Note='" + movie.Note + "', ReleaseYear='" + movie.ReleaseYear + "' WHERE ID='" + movie.Id + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

        public void DeleteMovie(int i)
        {
            OpenConnection();
            string query = "DELETE FROM movie WHERE id='" + i + "'";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

        public void AddMovie()
        {
            OpenConnection();
            string query = "INSERT INTO movie (Review) VALUES(0)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }

        //Close connection
        private void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException )
            {
                MessageBox.Show("Cannot disconnect from server.");
                Application.Exit();

            }
        }

    }
}
