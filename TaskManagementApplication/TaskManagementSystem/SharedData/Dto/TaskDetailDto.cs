using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Dto
{
    public class TaskDetailDto
    {
        public long Id { get; set; }
        public long TaskId { get; set; }
        public string? Detail { get; set; }
        public bool IsCompleted { get; set; }        
    }
}
