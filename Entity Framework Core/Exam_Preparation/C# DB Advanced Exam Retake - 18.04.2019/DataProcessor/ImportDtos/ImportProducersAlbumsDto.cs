using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
   public class ImportProducersAlbumsDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Pseudonym")]
        public string Pseudonym { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Albums")]
        public ICollection<ImportAlbumDto> ProducerAlbums { get; set; } = new HashSet<ImportAlbumDto>();
    }
}
