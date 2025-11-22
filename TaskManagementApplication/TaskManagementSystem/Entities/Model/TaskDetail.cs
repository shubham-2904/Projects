using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    public class TaskDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey(nameof(Task.Id))]
        public long TaskId { get; set; }
        public string? Detail {  get; set; }
        public bool IsCompleted { get; set; }
        public DateTime LastModifyDate { get; set; }
        public bool IsDeleted { get; set; }

        public Task? Task { get; set; }
    }
}
