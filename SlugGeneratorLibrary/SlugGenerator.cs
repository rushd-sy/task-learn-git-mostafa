using System;
using System.Text.RegularExpressions;

namespace SlugGeneratorLibrary
{
    public static class SlugGenerator
    {
        public static string Generate(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            text = text.Trim()
                .ToLowerInvariant();
            text = Regex.Replace(text, @"[+()^*%#@!/\\.,|`~]+", string.Empty);
            text = Regex.Replace(text, @"[\s_-]+", "-");
            return text;
        }
    }
}