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
using System.Net;
using System.Web.Http.Cors;

namespace TaskManagerAPI.Controllers
{
    [Route("api/timeTask")]
    [ApiController]
    [EnableCors("*", "*", "*")]
    public class TimeTaskController : Controller
    {
        private ITimeTaskProvider timeTaskProvider;

        public TimeTaskController (ITimeTaskProvider TDP)
        {
            this.timeTaskProvider = TDP;
        }

        [HttpGet]
        public async Task<IEnumerable<TimeTask>> Get()
        {
            return await this.timeTaskProvider.GetTasks();
        }

        

        [HttpGet("{id}")]
        public async Task<TimeTask> Get(int id)
        {
            return await this.timeTaskProvider.GetTask(id);
        }

        [HttpPut("Id={id}&Title={Title}&Description={Description}&StartDate={StartDate}&EndDate={EndDate}")]
        public async Task Put(int id, string Title, string Description, string StartDate, string EndDate)
        {
            TimeTask tb = new TimeTask();
            tb.Id = id;
            tb.Title = Title;
            tb.Description = Description;
            if (StartDate.Equals("null") && EndDate.Equals("null"))
            {
                await this.timeTaskProvider.UpdateTask(tb);
            }
            else
            {
                tb.StartDate = Convert.ToDateTime(StartDate);
                tb.EndDate = Convert.ToDateTime(EndDate);
                await this.timeTaskProvider.UpdateTask(tb);
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.timeTaskProvider.DeleteTask(id);
        }


        [HttpPost("Title={Title}&Description={Description}&startDate={StartDate}&endDate={EndDate}")]
        public async Task Post(string Title, string Description, string StartDate, string EndDate)
        {
            TimeTask tb = new TimeTask();

            tb.Title = Title;
            tb.Description = Description;
            
            if (StartDate.Equals("null") && EndDate.Equals("null"))
            {
                await this.timeTaskProvider.AddTask(tb);
            } else
            {
                //if (StartDate.Equals("null") || EndDate.Equals("null"))
                //{
                //    return "when using dates, both need to be sent";
                //}
                tb.StartDate = Convert.ToDateTime(StartDate);
                tb.EndDate = Convert.ToDateTime(EndDate);

            }

            if ( tb.StartDate > tb.EndDate)
            {
                // TODO: throw exception
                //throw new UriFormatException("start date cannot be after end date");
            }
            else
            {
                await this.timeTaskProvider.AddTask(tb);
            }
        }
    }


}