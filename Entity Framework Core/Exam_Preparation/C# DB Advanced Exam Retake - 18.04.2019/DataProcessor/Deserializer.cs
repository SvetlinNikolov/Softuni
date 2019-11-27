namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Linq;
    using Data;
    using MusicHub.Data.Models;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.IO;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using AutoMapper;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {

            var writers = JsonConvert.DeserializeObject<Writer[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            var validWriters = new List<Writer>();

            foreach (var writer in writers)
            {


                bool isValidWriter = IsValid(writer);

                if (isValidWriter)
                {
                    validWriters.Add(writer);
                    sb.AppendLine($"Imported {writer.Name}");
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }

            }
            context.Writers.AddRange(validWriters);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersAndAlbums = JsonConvert.DeserializeObject<ImportProducersAlbumsDto[]>(jsonString);
            var sb = new StringBuilder();

            var producers = new List<Producer>();

            foreach (var prodAlbum in producersAndAlbums)
            {
                var producer = new Producer
                {
                    Name = prodAlbum.Name,
                    Pseudonym = prodAlbum.Pseudonym,
                    PhoneNumber = prodAlbum.PhoneNumber
                };
                if (!IsValid(producer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var alb in prodAlbum.ProducerAlbums)
                {
                    var album = new Album
                    {
                        Name = alb.Name,
                        ReleaseDate = DateTime.ParseExact(alb.ReleaseDate, "dd/MM/yyyy",CultureInfo.InvariantCulture)

                    };

                    if (!IsValid(album))
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    producer.Albums.Add(album);
                }

                producers.Add(producer);

                if (producer.PhoneNumber != null)
                {
                    sb.AppendLine( $"Imported {producer.Name} with phone: {producer.PhoneNumber} produces {producer.Albums.Count()} albums");
                }
                else
                {
                    sb.AppendLine( $"Imported {producer.Name} with no phone number produces {producer.Albums.Count()} albums");
                }
               
            }
            return sb.ToString().TrimEnd();

        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDto[]),
              new XmlRootAttribute("Songs"));

            var songsDto = (ImportSongsDto[])(xmlSerializer
                .Deserialize(new StringReader(xmlString)));

            var songs = new List<Song>();
            

            foreach (var songDto in songsDto)
            {
                bool isValidAlbum = context.Albums.Any(a => a.Id == songDto.AlbumId);
                bool isValidWriter = context.Writers.Any(w => w.Id == songDto.WriterId);

                if (isValidAlbum==false || isValidWriter == false)
                {
                    continue;
                }
                Song song = null;

                try
                {
                    song = Mapper.Map<Song>(songDto);
                }
                catch (Exception)
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }
                

                if (IsValid(song))
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
                    songs.Add(song);
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
                
            }
            return sb.ToString().TrimEnd();
            

        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}