using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Custom.ExtensionMethods
{
    public static class StringExtensions
    {
        /// <summary>
        /// Reverses the characters in the given string.
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string ReverseString(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// Removes special characters from the string, replaces spaces with underscores,
        /// and normalizes characters with diacritics (e.g., Vietnamese characters).
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The sanitized string.</returns>
        public static string ToFormatFileNameString(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Normalize the string to decompose diacritics (e.g., "é" becomes "e" + accent).
            string normalized = input.Normalize(NormalizationForm.FormD);

            // Remove diacritics using Unicode category filtering.
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Convert the string back to the normalized form.
            string withoutDiacritics = sb.ToString().Normalize(NormalizationForm.FormC);

            // Replace spaces and hyphens with underscores.
            withoutDiacritics = Regex.Replace(withoutDiacritics, @"[\s\-]+", "_");

            // Replace special characters like parentheses and ensure numbers inside them are preserved.
            withoutDiacritics = Regex.Replace(withoutDiacritics, @"[^\w_.]", string.Empty);

            return withoutDiacritics;
        }
    }
}
