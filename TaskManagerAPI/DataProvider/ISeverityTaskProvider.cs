using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.DataProvider
{
    public interface ISeverityTaskProvider
    {
        Task<IEnumerable<SeverityTask>> GetTasks();

        Task<SeverityTask> GetTask(int taskId);

        Task AddTask(SeverityTask task);

        Task UpdateTask(SeverityTask task);

        Task DeleteTask(int taskId);
    }
}
