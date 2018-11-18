using System.ComponentModel;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using VkXamarinApp.Droid.Renderer;
using VkXamarinApp.CustomControls;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineLabelRender))]
namespace VkXamarinApp.Droid.Renderer
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class UnderlineLabelRender : ViewRenderer<UnderlineLabel, TextView>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<UnderlineLabel> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                // создаем и настраиваем элемент
                TextView textView = new TextView(Context);
                textView.SetTextSize(ComplexUnitType.Dip, (float)Element.FontSize);

                textView.PaintFlags = PaintFlags.UnderlineText;
                // устанавливаем элемент для класса из Portable-проекта
                SetNativeControl(textView);
                // установка свойств
                if (e.NewElement != null)
                {
                    SetText();
                    SetTextColor();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextColorProperty.PropertyName)
            {
                SetTextColor();
            }
            else if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                SetText();
            }
        }

        private void SetText()
        {
            Control.Text = Element.Text;

        }
        private void SetTextColor()
        {
            Android.Graphics.Color andrColor = Android.Graphics.Color.Gray;

            if (Element.TextColor != Xamarin.Forms.Color.Default)
            {
                Xamarin.Forms.Color color = Element.TextColor;
                andrColor = Android.Graphics.Color.Argb(
                    (byte)(color.A * 255),
                    (byte)(color.R * 255),
                    (byte)(color.G * 255),
                    (byte)(color.B * 255));
            }
            Control.SetTextColor(andrColor);
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}
