using SlugGeneratorLibrary;
using System.Net.Security;
using Xunit;

namespace SlugGeneratorUnitTesting
{
    public class SlugAlgorithmUnitTest
    {
        [Fact]
        public void RemoveWhiteSpaces()
        {
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello"));
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("    Hello    "));
        }

        [Fact]
        public void ConvertToLowerCase()
        {
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("hElLo"));
        }

        [Fact]
        public void NullInput()
        {
            Assert.Throws<ArgumentNullException>(() => SlugGenerator.GenerateHyphens(null));
        }

        [Fact]
        public void EmptyInput()
        {
            Assert.Equal(string.Empty, SlugGenerator.GenerateHyphens(string.Empty));
        }

        [Fact]
        public void InputWithOnlyWhiteSpaces()
        {
            Assert.Equal(string.Empty, SlugGenerator.GenerateHyphens("     "));
        }

        [Fact]
        public void InputWithSpecialCharacters()
        {
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello World"));
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello-World"));
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello_World"));
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello____World"));
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello _ World"));
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello -  _  - World"));
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello -_World"));
        }

        [Fact]
        public void InputWithSpecialCharactersToRemove()
        {
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello!"));
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello@"));
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello#"));
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello%"));
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello^"));
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello*"));
            Assert.Equal("hello", SlugGenerator.GenerateHyphens("Hello()"));
            Assert.Equal("helloworld", SlugGenerator.GenerateHyphens("Hello()!@#%^*+/\\.|`~,world"));
            Assert.Equal("hello-world", SlugGenerator.GenerateHyphens("Hello_- ()!@#%^*+/\\.|`~,- world"));
        }

        [Fact]
        public void InputWithArabicCharacters()
        {
            Assert.Equal("مرحبا-بالعالم", SlugGenerator.GenerateHyphens("مرحبا بالعالم"));
        }

        [Fact]
        public void SlugStringExtention()
        {
            Assert.Equal("hello-world", "hello world".ToSlug());
        }

        [Fact]
        public void SlugWithUnderscores()
        {
            Assert.Equal("hello_world", SlugGenerator.GenerateUnderscores("hello world"));
        }

        [Fact]
        public void CustomGenerate()
        {
            Assert.Equal("hello.world", SlugGenerator.CustomGenerate("hello world", '.'));
            Assert.Equal("hello*world", SlugGenerator.CustomGenerate("hello world", '*'));
        }
    }
}
