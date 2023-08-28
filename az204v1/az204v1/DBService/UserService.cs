using System.Data.SqlClient;
using az204v1.Models;
namespace az204v1.DBService
{
    public class UserService
    {
        public static string db_source = "az204db.database.windows.net";
        public static string db_username = "useraz204";
        public static string db_password = "P@ssw0rd7405";
        public static string database = "az204sql";

        public SqlConnection GetConnection() {
        
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_username;
            builder.Password = db_password;
            builder.InitialCatalog = database;
            return new SqlConnection(builder.ConnectionString);

            
        }

        public List<UserModel> GetUser() { 
        
            SqlConnection conn = GetConnection();
            List<UserModel> users = new List<UserModel>();
            string statement = "SELECT userid, username, env FROM USERS";
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                UserModel user = new UserModel
                {
                    userId = rd.GetInt32(0),
                    userName = rd.GetString(1),
                    env = rd.GetString(2)

                };
                users.Add(user);
            }
            return users;
        }

    }
}
