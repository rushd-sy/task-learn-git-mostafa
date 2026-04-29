using System.Text.RegularExpressions;

namespace SlugGeneratorLibrary
{
    public static class SlugGenerator
    {
        public static string CustomGenerate(string text, char separator)
        {
            ArgumentNullException.ThrowIfNull(text);
            text = Regex.Replace(text.Trim()
                .ToLowerInvariant(), 
                @"[+()^*%#@!/\\.,|`~]+", string.Empty);
            text = Regex.Replace(text.Trim(), @"[\s_-]+", separator.ToString());
            return text;
        }

        public static string GenerateHyphens(string text)
        {
            return CustomGenerate(text, '-');
        }

        public static string GenerateUnderscores(string text)
        {
            return CustomGenerate(text, '_');
        }

        public static string GenerateUnique(string text)
        {
            ArgumentNullException.ThrowIfNull(text);
            // append text with a GUID-based suffix to greatly reduce collision risk
            string uniqueText = text;
            string slugifiedText = GenerateHyphens(uniqueText);
            slugifiedText += '-' + Guid.NewGuid().ToString("N");
            return slugifiedText;
        }
    }

    public static class StringExtensions
    {
        /// <summary>Convert string to slug separated by hyphens.</summary>
        public static string ToSlug(this string text)
        {
            return SlugGenerator.GenerateHyphens(text);
        }
    }
}