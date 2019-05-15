using System.ComponentModel;
using System.Linq;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZShoppe.Client.Common.Presentation.Effects;
using ZShoppe.Client.Droid.Effects;

[assembly: ResolutionGroupName("ZShoppe.Client.Common.Presentation.Effects")]
[assembly: ExportEffect(typeof(LabelMaxLinesEffect), "LabelMaxLinesEffect")]
namespace ZShoppe.Client.Droid.Effects
{
    class LabelMaxLinesEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!(Control is TextView))
            {
                int[] colors =
                    {Android.Graphics.Color.ParseColor("#9d50bb"), Android.Graphics.Color.ParseColor("#6e48aa")};

                var dd = new GradientDrawable(GradientDrawable.Orientation.LeftRight, colors);
                if (Control == null)
                {
                    Container.SetBackground(dd);
                }
                else
                {
                    Control.SetBackground(dd);
                }
            }
            else
            {
                UpdateMaxLines();
            }
            
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == MaxLinesEffect.MaxLinesProperty.PropertyName)
            {
                UpdateMaxLines();
            }
        }

        void UpdateMaxLines()
        {
            var maxLines = MaxLinesEffect.GetMaxLines(Element);
            if (Control is TextView textView)
            {
                textView.SetMaxLines(maxLines);
                textView.Ellipsize = TextUtils.TruncateAt.End;
            }

        }
    }
}