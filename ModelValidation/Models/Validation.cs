using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ModelValidation.Models
{
    public static class Validation
    {
        public static string AssertNotEmpty(
            [NotNull] this string? value,
            [CallerArgumentExpression("value")] string? argumentName = null
            ) =>
                !string.IsNullOrWhiteSpace(value)
                    ? value
                        : throw new ArgumentOutOfRangeException(argumentName);

        public static Guid AssertNotEmpty(
            [NotNull] this Guid? value,
            [CallerArgumentExpression("value")] string? argumentName = null
            ) =>
            (value != null && value.Value != Guid.Empty)
                ? value.Value
                    : throw new ArgumentOutOfRangeException(argumentName);

        public static string? AssertNullOrNotEmpty(
            this string? value,
            [CallerArgumentExpression("value")] string? argumentName = null
            ) =>
                value?.AssertNotEmpty(argumentName);

        public static string AssertMatchesRegex(
            [NotNull] this string? value,
            [NotNull] string pattern,
            [CallerArgumentExpression("value")] string? argumentName = null
            ) =>
                Regex.IsMatch(value.AssertNotEmpty(argumentName), pattern)
                    ? value
                        : throw new ArgumentOutOfRangeException(argumentName);
    }
}
