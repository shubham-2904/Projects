using Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public TaskEnums Category { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime LastModifyDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<TaskDetail>? Details { get; set; }
    }
}
