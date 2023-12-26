using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services
{
    public class ProductService
    {
        private static string db_source = "vcsqlserver101.database.windows.net";
        private static string db_username = "vcadmin";
        private static string db_password = "Magic@22Password";
        private static string db_database = "vcsqlwebappdb"; 

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_username;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Product> GetProducts ()
        {
            SqlConnection conn = GetConnection();
            List <Product> products = new List<Product>();
            string statement = "SELECT ProductID, ProductName, Quantity FROM Products";

            conn.Open ();   

            SqlCommand cmd = new SqlCommand (statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader ())
            {
                while (reader.Read ())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32 (0),
                        ProductName = reader.GetString (1),
                        Quantity = reader.GetInt32 (2)
                    };

                    products.Add(product);
                }

            }

            conn.Close ();

            return products;
        }
    }
}
