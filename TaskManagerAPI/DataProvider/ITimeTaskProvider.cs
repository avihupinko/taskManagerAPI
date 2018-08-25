using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.DataProvider
{
    public interface ITimeTaskProvider
    {
        Task<IEnumerable<TimeTask>> GetTasks();

        Task<TimeTask> GetTask(int taskId);

        Task AddTask(TimeTask task);

        Task UpdateTask(TimeTask task);

        Task DeleteTask(int taskId);
    }
}
