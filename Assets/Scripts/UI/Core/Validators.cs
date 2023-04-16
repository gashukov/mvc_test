namespace UI.Core
{
    public static class Validators
    {
        public static char ValidateHardPrice(string text, int index, char addedChar)
        {
            if (!char.IsDigit(addedChar)) return '\0';
            if (!int.TryParse(text + addedChar, out var parsedValue)) return '\0';
            return parsedValue >= 0 ? addedChar : '\0';
        }

        public static char ValidatePercents(string text, int index, char addedChar)
        {
            if (!char.IsDigit(addedChar)) return '\0';
            if (!int.TryParse(text + addedChar, out var parsedValue)) return '\0';
            if (parsedValue >= 0 && parsedValue <= 100)
            {
                return addedChar;
            }

            return '\0';
        }

        public static char ValidateLimitedIntCount(string text, int index, char addedChar, int min, int max)
        {
            if (!char.IsDigit(addedChar)) return '\0';
            if (!int.TryParse(text + addedChar, out var parsedValue)) return '\0';
            if (parsedValue >= min && parsedValue <= max)
            {
                return addedChar;
            }

            return '\0';
        }
    }
}