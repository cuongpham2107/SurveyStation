using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace Common {
    public class Database {
        public static void Connect(DbConfig config) {
            var host = config.Host;
            var userName = config.Username;
            var password = config.Password;
            var database = config.Database;

            string connection = MySqlConnectionProvider.GetConnectionString(host, userName, password, database);
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connection, AutoCreateOption.None);
        }
    }

    public class DbConfig {
        public string Host { get; set; } = "localhost";
        public string Username { get; set; } = "root";
        public string Password { get; set; } = "aion43";
        public string Database { get; set; } = "nongnghiep";
    }
}