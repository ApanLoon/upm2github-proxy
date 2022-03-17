using System.Globalization;
using System.Text.RegularExpressions;

namespace UnitTests.Serialization
{
    public static class Helpers
    {
        public static string UnEscapeUnicode(string input)
        {
            const string literalBackslashPlaceholder = "\uf00b";
            const string unicodeEscapeRegexString = @"(?:\\u([0-9a-fA-F]{4}))|(?:\\U([0-9a-fA-F]{8}))";
            // Replace escaped backslashes with something else so we don't
            // accidentally expand escaped unicode escapes.
            string workingString = input.Replace("\\\\", literalBackslashPlaceholder);

            // Replace unicode escapes with actual unicode characters.
            workingString = new Regex(unicodeEscapeRegexString).Replace(workingString,
                match => ((char)int.Parse(match.Value.Substring(2), NumberStyles.HexNumber))
                    .ToString(CultureInfo.InvariantCulture));

            // Replace the escaped backslash placeholders with non-escaped literal backslashes.
            workingString = workingString.Replace(literalBackslashPlaceholder, "\\");
            return workingString;
        }
    }
}
