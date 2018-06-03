//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Text;

//namespace APImaps
//{
//    class DataFromSql
//    {
//        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//        public DataFromSql()
//        {
//            builder.DataSource = "latlong.database.windows.net";
//            builder.UserID = "thelittlewozniak";
//            builder.Password = "Ruedesdames14";
//            builder.InitialCatalog = "ProgLatLong";
//        }
//        public List<string> DataPseudo()
//        {
//            List<string> pseudo = new List<string>();
//            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//            {
//                try
//                {
//                    connection.Open();
//                }
//                catch (SqlException e)
//                {
//                    ErreurAffiche NewErreurAffiche = new ErreurAffiche();
//                    NewErreurAffiche.Title = "Internet connection";
//                    NewErreurAffiche.labelData.Content = "Error! No network! Please retry!";
//                    NewErreurAffiche.Show();
//                    System.Threading.Thread.Sleep(10000);
//                }
//                StringBuilder sqlstring = new StringBuilder();
//                sqlstring.Append("SELECT nickname ");
//                sqlstring.Append("FROM player ;");
//                string sql = sqlstring.ToString();

//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            pseudo.Add(reader.GetString(0));
//                        }
//                    }
//                }
//                connection.Close();
//            }
//            pseudo.Add("Add a player");
//            return pseudo;
//        }
//        public User InfoUser(string nickname)
//        {
//            User NewUser = new User();
//            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//            {
//                connection.Open();
//                StringBuilder sqlstring = new StringBuilder();
//                sqlstring.Append("SELECT idplayer,nickname,rapidity.rapidityName,trust.trustName ");
//                sqlstring.Append("FROM player INNER JOIN rapidity ON rapidity.idrapidity=player.idrapidity INNER JOIN trust ON trust.idtrust=player.idtrust ");
//                sqlstring.Append("WHERE nickname='");
//                sqlstring.Append(nickname);
//                sqlstring.Append("';");
//                string sql = sqlstring.ToString();

//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            NewUser.idUser = reader.GetInt32(0);
//                            NewUser.nickname = reader.GetString(1);
//                            NewUser.rapidity = reader.GetString(2);
//                            NewUser.trust = reader.GetString(3);
//                        }
//                    }
//                }
//                connection.Close();
//            }
//            return NewUser;
//        }

//        public void AddUser(User NewUser)
//        {
//            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//            {
//                connection.Open();
//                StringBuilder sqlstring = new StringBuilder();
//                sqlstring.Append("INSERT INTO player VALUES ('");
//                sqlstring.Append(NewUser.nickname);
//                sqlstring.Append("','");
//                sqlstring.Append(NewUser.rapidity);
//                sqlstring.Append("','");
//                sqlstring.Append(NewUser.trust);
//                sqlstring.Append("');");
//                string sql = sqlstring.ToString();
//                SqlCommand command = new SqlCommand(sql, connection);
//                command.ExecuteNonQuery();
//                connection.Close();
//            }
//        }
//        public void AddRoute(Route NewRoute, int idUser)
//        {
//            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//            {
//                connection.Open();
//                StringBuilder SqlString = new StringBuilder();
//                SqlString.Append("INSERT INTO route VALUES ('");
//                SqlString.Append(NewRoute.WazeLink);
//                SqlString.Append("','");
//                SqlString.Append(NewRoute.MapsLink);
//                SqlString.Append("','");
//                SqlString.Append(idUser);
//                SqlString.Append("','");
//                SqlString.Append(Convert.ToInt32(NewRoute.Status));
//                SqlString.Append("','");
//                SqlString.Append(NewRoute.DistanceKm.ToString());
//                SqlString.Append("','");
//                SqlString.Append(NewRoute.TimeMin.ToString());
//                SqlString.Append("');");
//                string sql = SqlString.ToString();
//                SqlCommand command = new SqlCommand(sql, connection);
//                command.ExecuteNonQuery();
//                connection.Close();

//            }
//        }
//        public List<Route> DataRoute(int IdUser)
//        {
//            List<Route> ListRoute = new List<Route>();
//            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//            {
//                connection.Open();
//                StringBuilder sqlstring = new StringBuilder();
//                sqlstring.Append("SELECT route.distance,route.time,route.wazelink,route.mapslink,status.statusName,route.idroute ");
//                sqlstring.Append("FROM route INNER JOIN status ON status.idstatus=route.idstatus ");
//                sqlstring.Append("WHERE idplayer='");
//                sqlstring.Append(IdUser);
//                sqlstring.Append("';");

//                string sql = sqlstring.ToString();
//                using (SqlCommand command = new SqlCommand(sql, connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            ListRoute.Add(new Route() { DistanceKm = Convert.ToDouble(reader.GetString(0)), TimeMin = Convert.ToDouble(reader.GetString(1)), WazeLink = reader.GetString(2), MapsLink = reader.GetString(3), Status = reader.GetString(4), IdRoute = reader.GetInt32(5) });
//                        }
//                    }
//                }
//                connection.Close();
//            }
//            return ListRoute;
//        }
//    }
//}