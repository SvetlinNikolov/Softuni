using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        [Required]
        [ForeignKey(nameof(Employee))] //TODO CHECK IF NEEDS FOREIGN KEY AND USE FLUENT FOR COMPOSITE
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

            
        [Required]
        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}