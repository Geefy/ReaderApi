using MySql.Data.MySqlClient;
using ReaderApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderApi.Repositories
{
    public class LocationRepository
    {
        static string connectionString = "server=127.0.0.1;uid=root;pwd=root;database=ReaderDB";
        private MySqlConnection conn = new MySqlConnection(connectionString);
        private MySqlCommand cmd;

        public IEnumerable<Location> GetAllLocations()
        {
            string sqlQuery = "SELECT * FROM Location;";
            List<Location> locations = new List<Location>();
            try
            {

                conn.Open();
                cmd = new MySqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Location locationObj = new Location();
                    locationObj.LocationName = row["LocationName"].ToString();

                    locations.Add(locationObj);
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return locations;
        }
    }
}
