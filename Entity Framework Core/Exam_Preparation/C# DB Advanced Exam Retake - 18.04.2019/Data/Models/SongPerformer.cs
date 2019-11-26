using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
   public class SongPerformer
    {
        [ForeignKey(nameof(Song))]
        [Required]
        public int SongId { get; set; }//NEED COMPOSITE KEY
        public Song Song { get; set; }

        [ForeignKey(nameof(Performer))]
        [Required]
        public int PerformerId { get; set; } //NEED COMPOSITE KEY

        public Performer Performer { get; set; }
    }
}
