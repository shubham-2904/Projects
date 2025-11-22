using Entities.Enum;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Dto
{
    public class TaskDto
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public TaskEnums Category { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public IEnumerable<TaskDetailDto>? Details { get; set; }
    }
}
