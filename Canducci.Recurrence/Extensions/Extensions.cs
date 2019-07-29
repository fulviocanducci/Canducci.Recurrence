using System.Text.RegularExpressions;
namespace Canducci.Recurrence.Extensions
{
    public static class GlobalExtensions
    {
        private static readonly Regex DigitsOnly = new Regex(@"[^\d]");
        public static string ToDigitsOnly(this string input)
        {            
            return DigitsOnly.Replace(input, "");
        }

        public static int ToMultiple(this decimal _v, int value = 100)
        {
            return (int)(_v * value);
        }

        public static decimal ToDivise(this int _v, int value = 100)
        {
            return _v / 100;
        }

        public static string ToStringDate(this System.DateTime _d, string format = "yyyy-MM-dd")
            => _d.ToString(format);
    }
}
