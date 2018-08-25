using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Models;
using TaskManagerAPI.DataProvider;
using System.IO;
using System.Net.Http;

namespace TaskManagerAPI.Controllers
{
    [Route("api/severityTask")]
    [ApiController]
    public class SeverityTaskController : Controller
    {
        private ISeverityTaskProvider severityTaskProvider;

        public SeverityTaskController(ISeverityTaskProvider TDP)
        {
            this.severityTaskProvider = TDP;
        }

        [HttpGet]
        public async Task<IEnumerable<SeverityTask>> Get()
        {
            return await this.severityTaskProvider.GetTasks();
        }

        [HttpGet("{id}")]
        public async Task<SeverityTask> Get(int id)
        {
            return await this.severityTaskProvider.GetTask(id);
        }

        [HttpPut("Id={id}&Title={Title}&Description={Description}&Severity={Severity}")]
        public async Task Put(int id, string Title, string Description, int Severity)
        {
            SeverityTask st = new SeverityTask();
            st.Id = id;
            st.Title = Title;
            st.Description = Description;
            st.Severity = Severity;

            await this.severityTaskProvider.UpdateTask(st);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.severityTaskProvider.DeleteTask(id);
        }


        [HttpPost("Title={Title}&Description={Description}&Severity={Severity}")]
        public async Task Post(string Title, string Description, int Severity)
        {
            SeverityTask st = new SeverityTask(); 
            
            st.Title = Title;
            st.Description = Description;
            st.Severity = Severity;

            await this.severityTaskProvider.AddTask(st);
        }
    }


}