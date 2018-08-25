using System;
using System.Collections.Generic;

namespace TaskManagerAPI.Models
{
    public partial class SeverityTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Severity { get; set; }

    }
}
