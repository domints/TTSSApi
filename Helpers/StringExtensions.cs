using System.Text;

namespace TTSSApi.Web.Helpers
{
    public static class StringExtensions
    {
        public static string RemoveDiacritics(this string input)
        {
            var sb = new StringBuilder(input);
            for(int i = 0; i < sb.Length; i++)
            {
                if(Consts.Diacritics.ContainsKey(sb[i]))
                    sb[i] = Consts.Diacritics[sb[i]];
            }

            return sb.ToString();
        }

        public static string PrepareForCompare(this string input)
        {
            return input.Trim().ToLowerInvariant().RemoveDiacritics();
        }
    }
}