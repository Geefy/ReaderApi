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
        static string connectionString = "server=127.0.0.1;uid=root;pwd=root;database=ReaderDB";


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
            finally
            {
                conn.Close();
            }
        }

        public void Create(Reader reader)
        {

        }

        public IEnumerable<Reader> GetAllReaders()
        {
            string sqlQuery = "SELECT * FROM Reader;";
            List<Reader> readers = new List<Reader>();
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
                    Reader readerObj = new Reader();
                    readerObj.ReaderName = row["ReaderName"].ToString();
                    readerObj.ReaderNumber = row["ReaderNumber"].ToString();
                    readerObj.Placement = row["Placement"].ToString();
                    readerObj.Reading = row["Reading"].ToString();
                    readerObj.ReaderUnit = row["ReaderUnit"].ToString();
                    readerObj.Date = row["Date"].ToString();
                    readerObj.Location = row["Location"].ToString();

                    readers.Add(readerObj);
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
            return readers;
        }

        public IEnumerable<Reader> GetReadersByLocation(string locationName)
        {
            string sqlQuery = "SELECT * FROM Reader WHERE Location = @LocationName;";
            List<Reader> readers = new List<Reader>();
            try
            {

                conn.Open();
                cmd = new MySqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@LocationName", locationName);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Reader readerObj = new Reader();
                    readerObj.ReaderName = row["ReaderName"].ToString();
                    readerObj.ReaderNumber = row["ReaderNumber"].ToString();
                    readerObj.Placement = row["Placement"].ToString();
                    readerObj.Reading = row["Reading"].ToString();
                    readerObj.ReaderUnit = row["ReaderUnit"].ToString();
                    readerObj.Date = row["Date"].ToString();
                    readerObj.Location = row["Location"].ToString();

                    readers.Add(readerObj);
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
            return readers;
        }

        public IEnumerable<Reader> GetReaderHistoryByName(string readerNumber)
        {
            string sqlQuery = "SELECT * FROM ReaderHistory WHERE ReaderNumber = @ReaderNumber;";
            List<Reader> readers = new List<Reader>();
            try
            {
                conn.Open();
                cmd = new MySqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@ReaderNumber", readerNumber);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Reader readerObj = new Reader();
                    readerObj.ReaderName = row["ReaderName"].ToString();
                    readerObj.ReaderNumber = row["ReaderNumber"].ToString();
                    readerObj.Placement = row["Placement"].ToString();
                    readerObj.Reading = row["Reading"].ToString();
                    readerObj.ReaderUnit = row["ReaderUnit"].ToString();
                    readerObj.Date = row["Date"].ToString();
                    readerObj.Location = row["Location"].ToString();

                    readers.Add(readerObj);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return readers;
        }
    }
}

