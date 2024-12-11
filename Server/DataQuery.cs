using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Server
{
    public class DataQuery
    {
        private string _connection;
        public DataQuery(string connection) 
        {
            _connection = connection;
        }
        public List<Friend> Users()
        {
            List<Friend> users = new List<Friend>();
            string query = @"SELECT telegram_id, friend_username,interested 
                            FROM friend_list 
                            WHERE EXTRACT(DAY FROM date_of_birth) = EXTRACT(DAY FROM CURRENT_DATE) 
                              AND EXTRACT(MONTH FROM date_of_birth) = EXTRACT(MONTH FROM CURRENT_DATE);";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_connection))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                while (reader.Read())
                                {
                                    users.Add(new Friend()
                                    {
                                        telegram_id = reader.GetInt64(0),
                                        friend_username = reader.GetString(1),
                                        interested = reader.GetString(2)
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }
    }
}
