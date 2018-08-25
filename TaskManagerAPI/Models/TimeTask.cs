using System;
using System.Collections.Generic;

namespace TaskManagerAPI.Models
{
    public partial class TimeTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
