using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.DataProvider
{
    public class SeverityTaskProvider : ISeverityTaskProvider
    {
        //private readonly string connectionString = "Server=LAPTOP-GR4TL2UE;Database=TaskScheduler;Trusted_Connection=True;";
        private readonly string connectionString = "Server=tcp:avihupinko.database.windows.net,1433;Initial Catalog=TaskScheduler;Persist Security Info=False;User ID=avihupinko;Password=@avi1990pin;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task AddTask(SeverityTask task)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Title", task.Title);
                dp.Add("@Description", task.Description);
                dp.Add("@Severity", task.Severity);
                
                await sqlConnection.ExecuteAsync(
                    "spAddSeverityTask",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<IEnumerable<SeverityTask>> GetTasks()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                return await sqlConnection.QueryAsync<SeverityTask>(
                    "spGetSeverityTasks",
                    null,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<SeverityTask> GetTask(int taskId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@ID", taskId);

                
                return await sqlConnection.QuerySingleOrDefaultAsync<SeverityTask>(
                    "spGetSeverityTask",
                    dp,
                    commandType: CommandType.StoredProcedure);

            }
        }


        public async Task UpdateTask(SeverityTask task)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Id", task.Id);
                dp.Add("@Title", task.Title);
                dp.Add("@Description", task.Description);
                dp.Add("@Severity", task.Severity);
                
                await sqlConnection.ExecuteAsync(
                    "spUpdateSeverityTask",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteTask(int taskId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Id", taskId);

                await sqlConnection.ExecuteAsync(
                    "spDeleteSeverityTask",
                    dp,
                    commandType: CommandType.StoredProcedure);

            }
        }

    }
}
    
