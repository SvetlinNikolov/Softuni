namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context
                .Genres.Where(g => genreNames.Contains(g.Name))
                .OrderByDescending(g => g.Games.
                Where(x => x.Purchases.Count() > 0)
                .Sum(s => s.Purchases.Count))
                .ThenBy(g => g.Id)
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,

                    Games = g.Games
                     .Where(game => game.Purchases.Count >= 1)
                        .Select(ga => new
                        {
                            Id = ga.Id,
                            Title = ga.Name,
                            Developer = ga.Developer.Name,
                            Tags = string.Join(", ", ga.GameTags.Select(x => x.Tag.Name)),
                            Players = ga.Purchases.Count()
                        })
                    .OrderByDescending(x => x.Players)
                    .ThenBy(x => x.Id)
                    .ToList(),

                    TotalPlayers = g.Games.Where(x => x.Purchases.Count() > 0).Sum(e => e.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();


            var json = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return json;

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            throw new NotImplementedException();
        }
    }
}