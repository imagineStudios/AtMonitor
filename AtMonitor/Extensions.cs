using AtMonitor.Views;
using SkiaSharp;
using System.Globalization;

namespace AtMonitor;

public static class Extensions
{
    public static void DrawCaptionLabels(this SKCanvas canvas, string label, SKColor labelColor, string value, SKColor valueColor, float textSize, SKPoint point, SKTextAlign horizontalAlignment, SKTypeface typeface, out SKRect totalBounds)
    {
        var hasLabel = !string.IsNullOrEmpty(label);
        var hasValueLabel = !string.IsNullOrEmpty(value);

        totalBounds = new SKRect();

        if (hasLabel || hasValueLabel)
        {
            var hasOffset = hasLabel && hasValueLabel;
            var captionMargin = textSize * 0.60f;
            var space = hasOffset ? captionMargin : 0;

            if (hasLabel)
            {
                using (var paint = new SKPaint
                {
                    TextSize = textSize,
                    IsAntialias = true,
                    Color = labelColor,
                    IsStroke = false,
                    TextAlign = horizontalAlignment,
                    Typeface = typeface
                })
                {
                    var bounds = new SKRect();
                    var text = label;
                    paint.MeasureText(text, ref bounds);

                    var y = point.Y - ((bounds.Top + bounds.Bottom) / 2) - space;

                    canvas.DrawText(text, point.X, y, paint);

                    var labelBounds = GetAbsolutePositionRect(point.X, y, bounds, horizontalAlignment);
                    totalBounds = labelBounds.Standardized;
                }
            }

            if (hasValueLabel)
            {
                using (var paint = new SKPaint()
                {
                    TextSize = textSize,
                    IsAntialias = true,
                    FakeBoldText = true,
                    Color = valueColor,
                    IsStroke = false,
                    TextAlign = horizontalAlignment,
                    Typeface = typeface
                })
                {
                    var bounds = new SKRect();
                    var text = value;
                    paint.MeasureText(text, ref bounds);

                    var y = point.Y - ((bounds.Top + bounds.Bottom) / 2) + space;

                    canvas.DrawText(text, point.X, y, paint);

                    var valueBounds = GetAbsolutePositionRect(point.X, y, bounds, horizontalAlignment);

                    if (totalBounds.IsEmpty)
                    {
                        totalBounds = valueBounds.Standardized;
                    }
                    else
                    {
                        totalBounds.Union(valueBounds.Standardized);
                    }
                }
            }
        }
    }
    private static SKRect GetAbsolutePositionRect(float x, float y, SKRect bounds, SKTextAlign horizontalAlignment)
    {
        var captionBounds = new SKRect
        {
            Left = x + bounds.Left,
            Top = y + bounds.Top
        };

        switch (horizontalAlignment)
        {
            case SKTextAlign.Left:
                captionBounds.Right = captionBounds.Left + bounds.Width;
                break;
            case SKTextAlign.Center:
                captionBounds.Right = captionBounds.Left + bounds.Width / 2;
                break;
            case SKTextAlign.Right:
                captionBounds.Right = captionBounds.Left - bounds.Width;
                break;
        }

        captionBounds.Bottom = captionBounds.Top + bounds.Height;

        return captionBounds;
    }

    public static void DrawTextCenteredVertically(this SKCanvas canvas, string text, SKPaint paint, SKPoint point)
    {
        canvas.DrawTextCenteredVertically(text, paint, point.X, point.Y);
    }

    public static void DrawTextCenteredVertically(this SKCanvas canvas, string text, SKPaint paint, float x, float y)
    {
        var textY = y + (((-paint.FontMetrics.Ascent + paint.FontMetrics.Descent) / 2) - paint.FontMetrics.Descent);
        canvas.DrawText(text, x, textY, paint);
    }

    public static void Remove<T>(this ICollection<T> e, Func<T, bool> predicate)
    {
        var toDelete = e.Where(predicate).ToArray();
        toDelete.ForEach(i => e.Remove(i));
    }

    public static void ForEach<T>(this IEnumerable<T> e, Action<T> action)
    {
        foreach (var item in e)
        {
            action?.Invoke(item);
        }
    }

    public static T? GetAttributeOfType<T>(this Enum enumVal)
        where T : Attribute
    {
        var memInfo = enumVal.GetType().GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }

    public static string? Description(this Enum enumVal)
       => (string?)new EnumToDescriptionConverter().Convert(
           enumVal,
           typeof(string),
           null,
           CultureInfo.InvariantCulture);

    public static int RoundTo(this int value, int Precission)
        => Precission * (int)Math.Round((double)value / Precission);
}
