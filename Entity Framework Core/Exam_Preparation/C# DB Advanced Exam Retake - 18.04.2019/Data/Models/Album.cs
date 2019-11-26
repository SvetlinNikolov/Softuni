﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        [NotMapped]
        public decimal Price => Songs.Sum(s => s.Price);

        [ForeignKey(nameof(Producer))]
    
        public int ProducerId { get; set; }
        public Producer Producer { get; set; } //PRODUCER
        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
     


    }
}
