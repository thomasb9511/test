using DiscImageStudio.Core.Calibration;

namespace DiscImageStudio.Services;

internal static class CalibrationRadiusDisplay
{
    internal static string Format(CalibrationTarget target)
    {
        CalibrationParameters p = target.Parameters;
        return $"[EN]（[EN]）：{ParameterNumberText.ForInput(p.InnerRadiusMm)}–{ParameterNumberText.ForInput(p.OuterRadiusMm)} mm";
    }
}
