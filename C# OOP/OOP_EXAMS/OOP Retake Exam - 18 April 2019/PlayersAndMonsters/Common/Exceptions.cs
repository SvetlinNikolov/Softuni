namespace PlayersAndMonsters.Common
{
    public static class Exceptions
    {
        public const string UsernameNullOrEmpty = "Player's username cannot be null or an empty string.";
        public const string PlayerBonusLessThanZero = "Player's health bonus cannot be less than zero.";
        public const string DamagagePointsLessThanZero = "Damage points cannot be less than zero.";
        public const string CardNameNullOrEmpty = "Card's name cannot be null or an empty string.";
        public const string CardDamagePointsLessThanZero = "Card's damage points cannot be less than zero.";
        public const string CardHpLessThanZero = "Card's HP cannot be less than zero.";
        public const string PlayerIsDead = "Player is dead!";
        public const string PlayerIsNull = "Player cannot be null";
        public const string PlayerAlreadyExists = "Player {0} already exists!";
        public const string CardIsNull = "Card cannot be null!";
        public const string CardAlreadyExists = "Card {0} already exists!";


    }
}