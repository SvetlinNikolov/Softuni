namespace MusicHub
{
    using AutoMapper;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using System;
    using System.Globalization;

    public class MusicHubProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public MusicHubProfile()
        {
            this.CreateMap<ImportSongsDto, Song>()
                 .ForMember(x => x.Duration, y => y.MapFrom(
                     x => TimeSpan.ParseExact(x.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture)))
                 .ForMember(x => x.CreatedOn, y => y.MapFrom(
                     x => DateTime.ParseExact(x.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture)))
                 .ForMember(x => x.Genre, y => y.MapFrom(
                     x => Enum.Parse(typeof(Genre), x.Genre)));
        }
    }
} 
