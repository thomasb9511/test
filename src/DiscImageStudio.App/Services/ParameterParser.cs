using System.Globalization;

namespace DiscImageStudio.Services;

/// Input parsing with dual-culture tolerance; messages are identical to the original UI.
internal static class ParameterParser
{
    internal static double ParseDouble(string raw, string fieldName)
    {
        string value = raw.Trim();
        if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result)
            || double.TryParse(value, NumberStyles.Float, CultureInfo.CurrentCulture, out result))
        {
            return result;
        }

        throw new FormatException($"{fieldName}[EN]。");
    }

    internal static double ParsePositiveDouble(string raw, string fieldName)
    {
        double result = ParseDouble(raw, fieldName);
        return double.IsFinite(result) && result > 0
            ? result
            : throw new ArgumentOutOfRangeException(fieldName, $"{fieldName}must be greater than 0。");
    }

    internal static int ParsePositiveInt(string raw, string fieldName)
    {
        string value = raw.Trim();
        return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result) && result > 0
            ? result
            : throw new FormatException($"{fieldName}must[EN]。");
    }

    internal static long ParsePositiveLong(string raw, string fieldName)
    {
        string value = raw.Trim();
        return long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long result) && result > 0
            ? result
            : throw new FormatException($"{fieldName}must[EN]。");
    }

    internal static long ParseNonNegativeLong(string raw, string fieldName)
    {
        string value = raw.Trim();
        return long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out long result) && result >= 0
            ? result
            : throw new FormatException($"{fieldName}must[EN]。");
    }

    internal static int ParsePreviewSize(string raw)
    {
        int size = ParsePositiveInt(raw, "Preview size");
        return size is >= 64 and <= 8192
            ? size
            : throw new ArgumentOutOfRangeException(nameof(raw), "Preview sizemust[EN] 64–8192 px [EN]。");
    }

    internal static int ParsePreviewSamples(string raw, int maximum)
    {
        int samples = ParsePositiveInt(raw, "Samples per sector");
        return samples <= maximum
            ? samples
            : throw new ArgumentOutOfRangeException(nameof(raw), $"Samples per sectormust[EN] 1–{maximum} [EN]。");
    }
}
