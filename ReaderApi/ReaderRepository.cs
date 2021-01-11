using MySql.Data.MySqlClient;
using ReaderApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderApi
{
    public class ReaderRepository
    {
        static string connectionString = "";


        private MySqlConnection conn = new MySqlConnection(connectionString);
        private MySqlCommand cmd;
        public void Update(ReaderDTO reader)
        {
            string sqlQuery = "UPDATE Reader SET Reading = @NewReading, Date = @Date WHERE ReaderNumber = @ReaderNumber";
            try
            {
                conn.Open();
                cmd = new MySqlCommand(sqlQuery, conn);
                DateTime dt = DateTime.Now;
                string formatForMySql = dt.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@NewReading", reader.Reading);
                cmd.Parameters.AddWithValue("@ReaderNumber", reader.ReaderNumber);
                cmd.Parameters.AddWithValue("@Date", formatForMySql);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            conn.Close();
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            string sqlQuery = "SELECT * FROM Reader";
            List<Reader> readers = new List<Reader>();
            try
            {
                conn.Open();
                cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    foreach (DataRow row in rdr)
                    {
                        Reader readerObj = new Reader();
                        readerObj.ReaderName = row["ReaderName"].ToString();
                        readerObj.ReaderNumber = row["ReaderNumber"].ToString();
                        readerObj.Placement = row["Placement"].ToString();
                        readerObj.Reading = row["Reading"].ToString();
                        readerObj.ReaderUnit = row["ReaderUnit"].ToString();
                        readerObj.Date = row["Date"].ToString();

                        readers.Add(readerObj);
                    }
                }
                rdr.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            conn.Close();
            return readers;
        }
    }
}
