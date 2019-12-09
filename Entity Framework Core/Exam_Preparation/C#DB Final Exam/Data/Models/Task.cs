using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.Data.Models
{
    public class Task
    {




        //•	OpenDate - date and time(required)
        //•	DueDate - date and time(required)
        //•	ExecutionType - enumeration of type ExecutionType, with possible values(ProductBacklog, SprintBacklog, InProgress, Finished) (required)
        //•	LabelType - enumeration of type LabelType, with possible values(Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
        //•	ProjectId - integer, foreign key(required)
        //•	Project - Project 
        //•	EmployeesTasks - collection of type EmployeeTask

            [Key]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public ExecutionType ExecutionType { get; set; }

        [Required]
        public LabelType LabelType { get; set; }

        [Required]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<EmployeeTask> EmployeesTasks { get; set; } = new HashSet<EmployeeTask>();
    }
}
