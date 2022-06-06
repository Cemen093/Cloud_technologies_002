using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Cloud_technologies_002.Controllers
{
    [ApiController]
    [Route("api/transactions/[controller]")]
    public class TransactionsController : ControllerBase
    {
        [HttpGet(Name = "GetTransactions")]
        public IEnumerable<string> Get()
        {
            List<string> transactions = new List<string>();
            string connStr = new string("Server=tcp:my-server93-2.database.windows.net,1433;Initial Catalog=my-bd;Persist Security Info=False;User ID=admin93;Password=PASSworld93;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Transactions]", connection)) {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        transactions.Add(reader.GetValue(1).ToString());
                    }
                }
                return transactions;
            };
        }

        [HttpPost(Name = "PostTransactions")]
        public StatusCodeResult Post(string name, string desctiption, string date, int amount_of_money, int categoryId, int TypeBalanceChangeId )
        {
            string connStr = new string("Server=tcp:my-server93-2.database.windows.net,1433;Initial Catalog=my-bd;Persist Security Info=False;User ID=admin93;Password=PASSworld93;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"INSERT INTO [dbo].[Transactions]([Name],[Description],[Date],[Amount of money],[CategoryId], [TypeBalanceChangeId])" +
                    $" VALUES (\'{name}\', \'{desctiption}\', \'{date}\', \'{amount_of_money}\',  \'{categoryId}\', \'{TypeBalanceChangeId}\')", connection))
                {
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        return StatusCode(405);
                    }
                }
                return StatusCode(200);
            };
        }

        [HttpDelete(Name = "DeleteTransactions")]
        public StatusCodeResult Delete(int id)
        {
            string connStr = new string("Server=tcp:my-server93-2.database.windows.net,1433;Initial Catalog=my-bd;Persist Security Info=False;User ID=admin93;Password=PASSworld93;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"DELETE FROM [dbo].[Transactions] WHERE id = {id}", connection))
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