using System.Text.RegularExpressions;
namespace Canducci.Recurrence.Strings
{
    public static class Extensions
    {
        private static readonly Regex DigitsOnly = new Regex(@"[^\d]");
        public static string ToDigitsOnly(this string input)
        {            
            return DigitsOnly.Replace(input, "");
        }
    }
}
