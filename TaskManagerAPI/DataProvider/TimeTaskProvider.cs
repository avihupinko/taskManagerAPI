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
    public class TimeTaskProvider : ITimeTaskProvider
    {
        private readonly string connectionString = "Server=LAPTOP-GR4TL2UE;Database=TaskScheduler;Trusted_Connection=True;";


        public async Task AddTask(TimeTask task)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Title", task.Title);
                dp.Add("@Description", task.Description);
                dp.Add("@StartDate", task.StartDate);
                dp.Add("@EndDate", task.EndDate);
                await sqlConnection.ExecuteAsync(
                    "spAddTimeTask",
                    dp,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<IEnumerable<TimeTask>> GetTasks()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();

                return await sqlConnection.QueryAsync<TimeTask>(
                    "spGetTimeTasks",
                    null,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<TimeTask> GetTask(int taskId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@ID", taskId);

                
                return await sqlConnection.QuerySingleOrDefaultAsync<TimeTask>(
                    "spGetTimeTask",
                    dp,
                    commandType: CommandType.StoredProcedure);

            }
        }


        public async Task UpdateTask(TimeTask task)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@Id", task.Id);
                dp.Add("@Title", task.Title);
                dp.Add("@Description", task.Description);
                dp.Add("@StartDate", task.StartDate);
                dp.Add("@EndDate", task.EndDate);
                await sqlConnection.ExecuteAsync(
                    "spUpdateTimeTask",
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
                    "spDeleteTimeTask",
                    dp,
                    commandType: CommandType.StoredProcedure);

            }
        }
    }
}
    
