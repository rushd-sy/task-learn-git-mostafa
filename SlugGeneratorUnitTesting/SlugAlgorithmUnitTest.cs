using SlugGeneratorLibrary;
using Xunit;

namespace SlugGeneratorUnitTesting
{
    public class SlugAlgorithmUnitTest
    {
        [Fact]
        public void RemoveWhiteSpaces()
        {
            Assert.Equal("hello", SlugGenerator.Generate("Hello"));
            Assert.Equal("hello", SlugGenerator.Generate("    Hello    "));
        }

        [Fact]
        public void ConvertToLowerCase()
        {
            Assert.Equal("hello", SlugGenerator.Generate("hElLo"));
        }

        [Fact]
        public void NullInput()
        {
            Assert.Throws<ArgumentNullException>(() => SlugGenerator.Generate(null));
        }

        [Fact]
        public void EmptyInput()
        {
            Assert.Equal(string.Empty, SlugGenerator.Generate(string.Empty));
        }

        [Fact]
        public void InputWithOnlyWhiteSpaces()
        {
            Assert.Equal(string.Empty, SlugGenerator.Generate("     "));
        }

        [Fact]
        public void InputWithSpecialCharacters()
        {
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello World"));
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello-World"));
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello_World"));
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello____World"));
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello _ World"));
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello -  _  - World"));
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello -_World"));
        }

        [Fact]
        public void InputWithSpecialCharactersToRemove()
        {
            Assert.Equal("hello", SlugGenerator.Generate("Hello!"));
            Assert.Equal("hello", SlugGenerator.Generate("Hello@"));
            Assert.Equal("hello", SlugGenerator.Generate("Hello#"));
            Assert.Equal("hello", SlugGenerator.Generate("Hello%"));
            Assert.Equal("hello", SlugGenerator.Generate("Hello^"));
            Assert.Equal("hello", SlugGenerator.Generate("Hello*"));
            Assert.Equal("hello", SlugGenerator.Generate("Hello()"));
            Assert.Equal("helloworld", SlugGenerator.Generate("Hello()!@#%^*+/\\.|`~,world"));
            Assert.Equal("hello-world", SlugGenerator.Generate("Hello_- ()!@#%^*+/\\.|`~,- world"));
        }

        [Fact]
        public void InputWithArabicCharacters()
        {
            Assert.Equal("مرحبا-بالعالم", SlugGenerator.Generate("مرحبا بالعالم"));
        }
    }
}
