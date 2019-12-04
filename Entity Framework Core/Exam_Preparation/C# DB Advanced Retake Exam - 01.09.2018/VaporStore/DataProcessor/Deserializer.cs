namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ImportDtos;

    public static class Deserializer
    {
        private const string ImportedPurchase = "Imported {0} for {1}";
        private const string ErrorMessage = "Invalid Data";
        private const string ImportedGame = "Added {0} ({1}) with {2} tags";
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var allGamesDto = JsonConvert.DeserializeObject<ImportGamesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validGames = new List<Game>();

            var existingTags = new List<Tag>();

            var genresToAdd = new List<Genre>();
            var developersToAdd = new List<Developer>();

            foreach (var gameDto in allGamesDto)
            {
                var tagsToAdd = new List<Tag>();

                var isValidGame = IsValid(gameDto);

                if (!isValidGame)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Developer developer = developersToAdd.FirstOrDefault(x => x.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer { Name = gameDto.Developer };
                    developersToAdd.Add(developer);
                }

                Genre genre = genresToAdd.FirstOrDefault(x => x.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre { Name = gameDto.Genre };
                    genresToAdd.Add(genre);
                }

                foreach (var tag in gameDto.Tags)
                {
                    Tag tagToSearch = existingTags.FirstOrDefault(x => x.Name == tag);

                    if (tagToSearch == null)
                    {
                        tagToSearch = new Tag
                        {
                            Name = tag
                        };

                        existingTags.Add(tagToSearch);
                    }

                    tagsToAdd.Add(tagToSearch);
                }

                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = tagsToAdd.Select(gt => new GameTag { Tag = gt }).ToList()
                };

                sb.AppendLine(string.Format(ImportedGame,
                      game.Name,
                      game.Genre.Name,
                      game.GameTags.Count()));

                validGames.Add(game);
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var cardsDto = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var users = new List<User>();

            foreach (var cardDto in cardsDto)
            {
                bool isValidCard = IsValid(cardDto);

                if (!isValidCard)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User
                {
                    FullName = cardDto.FullName,
                    Username = cardDto.Username,
                    Email = cardDto.Username,
                    Age = cardDto.Age,


                };

                user.Cards = new HashSet<Card>();

                bool cardsHaveValidType = cardDto.Cards.All(x => Enum.IsDefined(typeof(CardType), x.Type));
                bool cardsAreValid = cardDto.Cards.All(x => IsValid(x));

                if (cardsHaveValidType && cardsAreValid)
                {

                    foreach (var card in cardDto.Cards)
                    {
                        user.Cards.Add(new Card
                        {
                            Number = card.Number,
                            Cvc = card.Cvc,
                            Type = card.Type
                        });
                    }
                    users.Add(user);
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                sb.AppendLine($"Imported {user.Email} with {user.Cards.Count()} cards");
                //bool isValidCardType = Enum.IsDefined(typeof(CardType), cardDto.Cards);

            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchasesDto[]), new XmlRootAttribute("Purchases"));
            var purchasesDto = (ImportPurchasesDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Purchase> purchases = new List<Purchase>();

            StringBuilder sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                bool isValidDto = IsValid(purchaseDto);
                bool isValidType = Enum.IsDefined(typeof(PurchaseType), purchaseDto.Type);
                var targetGame = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                var targtCard = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (isValidDto == false ||
                    isValidType == false ||
                    targetGame == null ||
                    targtCard == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Card = targtCard,
                    Game = targetGame,
                    Date = DateTime.ParseExact(
                        purchaseDto.Date, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    ProductKey = purchaseDto.Key,
                    Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type)
                };

                purchases.Add(purchase);

                sb.AppendLine(string.Format(ImportedPurchase,
                    purchase.Game.Name,
                    purchase.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();
            

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);

        }
    }
}