using System.Text.RegularExpressions;

namespace SlugGeneratorLibrary
{
    public static class SlugGenerator
    {
        public static string CustomGenerate(string text, char separator)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            text = text.Trim()
                .ToLowerInvariant();
            text = Regex.Replace(text, @"[+()^*%#@!/\\.,|`~]+", string.Empty);
            text = Regex.Replace(text, @"[\s_-]+", separator.ToString());
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
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            // append text with a GUID-based suffix to greatly reduce collision risk
            string uniqueText = text + '-' + Guid.NewGuid().ToString("N");
            return GenerateHyphens(uniqueText);
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