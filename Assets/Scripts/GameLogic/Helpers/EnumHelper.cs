using System;

namespace GameLogic.Helpers
{
    public static class EnumHelper
    {
        private static readonly Random Random = new Random();

        public static T GetRandomValue<T>() where T : Enum
        {
            var enumValues = Enum.GetValues(typeof(T));
            var randomIndex = Random.Next(enumValues.Length);
            return (T)enumValues.GetValue(randomIndex);
        }
    }
}