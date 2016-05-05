using System;
using System.Data.SqlClient;
using System.Data;
using SimpleProject.Use;

namespace SimpleProject.Data
{
    /**
    <summary> 
    Выполняет операции над данными пользователя.
    </summary>
    */
    class DataSet
    {
        private static string path =Environment.CurrentDirectory +
                                    @"\Database\Database.mdf;";
        private static string pathDebug =
                                    @"C:\Users\vladlen\Documents\Visual Studio 2015\Projects\C Sharp\SimpleProject-Game\SimpleProject Server\Database\Database.mdf;";
        private static string conn =@"Data Source=(LocalDB)\MSSQLLocalDB;" +
                                    @"AttachDbFilename=" +
                                    path +
                                    @"Integrated Security=True";
        
        public bool SignUp(string email, string password, string nick)
        {
            string sql = string.Format("INSERT INTO [Accounts] ([Email], [Password], [Nick]) VALUES (@email, @pass, @nick)");
            try
            {
                using (SqlConnection data = new SqlConnection(conn))
                {
                    data.Open();
                    var cmd = new SqlCommand(sql, data);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@nick", nick);
                    cmd.ExecuteNonQuery();
                } 
                Console.WriteLine("Yeah!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void Clear()
        {
            string sqlClear = string.Format("DELETE FROM [Accounts]");
            string sqlReset = string.Format("DBCC CHECKIDENT([Accounts], RESEED, 0)");
            try
            {
                using (SqlConnection data = new SqlConnection(conn))
                {
                    data.Open();
                    var cmd = new SqlCommand(sqlClear, data);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(sqlReset, data);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Yeah!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool Delete(int id)
        {
            string sql = string.Format("DELETE FROM Accounts WHERE [Id] = '{0}'", id);
            try
            {
                using (SqlConnection data = new SqlConnection(conn))
                {
                    data.Open();
                    var cmd = new SqlCommand(sql, data);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Yeah!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public void UpdatePassword(string nick, string newPass)
        {
            string sql = string.Format("UPDATE Accounts SET [Password] = '{0}' WHERE [Nick] = '{1}'",
            newPass, nick);
            try
            {
                using (SqlConnection data = new SqlConnection(conn))
                {
                    data.Open();
                    var cmd = new SqlCommand(sql, data);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Yeah!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public IUserProfile SignIn(string email, string password)
        {
            IUserProfile profile = null;
            string sql =
            "SELECT [Email], [Password], [Nick] FROM [Accounts]"
                + "WHERE [Email] = @email ";
                //+ "ORDER BY [Id] DESC;";
            //DataTable inv = new DataTable();
            try
            {
                using (SqlConnection data = new SqlConnection(conn))
                {
                    data.Open();
                    var cmd = new SqlCommand(sql, data);
                    cmd.Parameters.AddWithValue("@email", email);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string ema = reader.GetString(0);
                        string pas = reader.GetString(1);
                        string nick = reader.GetString(2);
                        if (pas == password)
                        {
                            profile = new UserProfile();
                            profile.Nick = nick;
                        }
                    }
                    Console.WriteLine("Yeah!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return profile;
            }
            return profile;
        }
    }
}
