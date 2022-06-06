using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Cloud_technologies_002.Controllers
{
    [Route("api/category/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet(Name = "GetCategory")]
        public IEnumerable<string> Get()
        {
            List<string> transactions = new List<string>();
            string connStr = new string("Server=tcp:my-server93-2.database.windows.net,1433;Initial Catalog=my-bd;Persist Security Info=False;User ID=admin93;Password=PASSworld93;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Category]", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        transactions.Add(reader.GetValue(1).ToString());
                    }
                }
                return transactions;
            };
        }

        [HttpPost(Name = "PostCategory")]
        public StatusCodeResult Post(string name)
        {
            string connStr = new string("Server=tcp:my-server93-2.database.windows.net,1433;Initial Catalog=my-bd;Persist Security Info=False;User ID=admin93;Password=PASSworld93;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"INSERT INTO [dbo].[Category]([Name])" +
                    $" VALUES (\'{name}\')", connection))
                {
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        return StatusCode(405);
                    }
                }
                return StatusCode(200);
            };
        }

        [HttpDelete(Name = "DeleteCategory")]
        public StatusCodeResult Delete(int id)
        {
            string connStr = new string("Server=tcp:my-server93-2.database.windows.net,1433;Initial Catalog=my-bd;Persist Security Info=False;User ID=admin93;Password=PASSworld93;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM [dbo].[Category] WHERE id = {id}", connection))
                {
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        return StatusCode(405);
                    }
                }
                return StatusCode(200);
            };
        }
    }
}
