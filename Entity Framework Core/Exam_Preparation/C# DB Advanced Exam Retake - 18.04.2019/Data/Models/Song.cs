using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }

        public Album Album { get; set; } //ALBUM!

        [Required]
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }
        public Writer Writer { get; set; } //Writer

        [Required]
        [Range(0d, (double)decimal.MaxValue)] //could be something simpler [Minvalue = 0]
        public decimal Price { get; set; }
        public ICollection<SongPerformer> SongPerformers { get; set; } = new HashSet<SongPerformer>(); //SongPerformers!

    }
}
