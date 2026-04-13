using System;
using System.Security.Cryptography;
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
            // append text with current milliseconds and a random number to ensure uniqueness
            string millisecondsText = text + '-' + DateTimeOffset.UtcNow.
                ToUnixTimeMilliseconds().ToString() + '-' +
                RandomNumberGenerator.GetInt32(0, 100).ToString();
            return GenerateHyphens(millisecondsText);
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