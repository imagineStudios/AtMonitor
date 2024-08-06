using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace AtMonitor.Views;

public class PressureGraph : SKCanvasView
{
    public static readonly BindableProperty PressureProperty = BindableProperty.Create(
        nameof(Pressure),
        typeof(double),
        typeof(PressureGraph),
        null,
        propertyChanged: dings);

    private static void dings(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as PressureGraph)?.InvalidateSurface();
    }

    public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(
        nameof(MaxValue),
        typeof(double),
        typeof(PressureGraph),
        null,
        propertyChanged: dings);

    public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
        nameof(ForegroundColor),
        typeof(Color),
        typeof(PressureGraph),
        Colors.Blue,
        propertyChanged: dings);

    public Color ForegroundColor
    {
        get => (Color)GetValue(ForegroundColorProperty);
        set => SetValue(ForegroundColorProperty, value);
    }

    public double Pressure
    {
        get => (double)GetValue(PressureProperty);
        set => SetValue(PressureProperty, value);
    }

    public double MaxValue
    {
        get => (double)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);
        Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
    }

    private void Draw(SKCanvas canvas, int width, int height)
    {
        var area = new SKRect(0, 0, width, height);

        // Clear just the drawing area to avoid messing up rest of the canvas in case it's shared
        //using (var paint = new SKPaint
        //{
        //    Style = SKPaintStyle.Fill,
        //    Color = BackgroundColor.ToSKColor(),
        //})
        //{
        //    canvas.DrawRect(area, paint);
        //}

        using (var paint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = ForegroundColor.ToSKColor(),
        })
        {
            var path = new SKPath();
            path.AddArc(new SKRect(0, 0, width, width), 180, 180);
            path.LineTo(width, height - width / 2);
            path.ArcTo(new SKRect(0, height - width, width, height), 0, 180, false);
            path.Close();

            canvas.DrawPath(path, paint);
        }

        using (var paint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White,
        })
        {
            var path = new SKPath();
            path.AddArc(new SKRect(0, height - width, width, height), 0, 90);
            //path.LineTo(width / 2, height - width / 2);
            path.Close();
        }
           
        using (var paint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black,
        })
        {
            var path = new SKPath();
            path.AddArc(new SKRect(0, height - width, width, height), 90, 90);
            path.LineTo(width / 2, height - width / 2);
            path.Close();

            canvas.DrawPath(path, paint);
        }           

        using (var paint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black,
        })
        {
            canvas.DrawRect(new SKRect(0, 0, width, (int)Math.Round(Pressure / MaxValue * height)), paint);
        }
    }
}
