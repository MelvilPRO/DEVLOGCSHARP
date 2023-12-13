using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Debut_WPF
{
    public class Database
    {
        static string databaseFilename = "Users.json";

        public List<User> Users { get; set; }

        public Database()
        {
            Users = new List<User>();
        }
        public Database(List<User> users)
        {
            Users = users;
        }

        public void Deserialize()
        {
            string databaseFilepath = AppDomain.CurrentDomain.BaseDirectory + databaseFilename;
            string jsonParsed = "";
            try
            {
                StreamReader streamReader = new StreamReader(databaseFilepath);
                jsonParsed = streamReader.ReadLine();
                streamReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            try
            {
                Users = JsonSerializer.Deserialize<List<User>>(jsonParsed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public void Serialize()
        {
            string databaseFilepath = AppDomain.CurrentDomain.BaseDirectory + databaseFilename;
            string jsonSerialized = JsonSerializer.Serialize(Users);
            try
            {
                StreamWriter streamWriter = new StreamWriter(databaseFilepath);
                streamWriter.WriteLine(jsonSerialized);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public List<User> FilterScores()
        {
            List<User> listQuery = Users.OrderBy(user => user.Score).ToList();
            return listQuery;
        }
    }
}
