﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(0.01, (double)decimal.MaxValue)]
        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Customer))]
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 

        [ForeignKey(nameof(Projection))]
        [Required]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
    }
}
