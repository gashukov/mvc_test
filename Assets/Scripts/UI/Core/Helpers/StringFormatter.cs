namespace UI.Core.Helpers
{
    public static class StringFormatter
    {
        public static string ToHardPrice(this float price)
        {
            return $"${price:F2}";
        }
        
        public static string ToHardSale(this uint sale)
        {
            return $"-{sale}%";
        }
    }
}