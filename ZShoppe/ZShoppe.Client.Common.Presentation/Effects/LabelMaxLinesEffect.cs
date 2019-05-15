using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ZShoppe.Client.Common.Presentation.Effects
{
    /// <summary>
    /// This effect sets the Text wrapping to true and sets the number of maximum lines of text in the label.<para/>
    /// Use it as an attached property in XAML: effects:MaxLinesEffect.MaxLines="2"
    /// </summary>
    [Preserve(AllMembers = true)]
    public static class MaxLinesEffect
    {
        public static readonly BindableProperty MaxLinesProperty = BindableProperty.CreateAttached("MaxLines",
            typeof(int), typeof(LabelMaxLinesEffect), default(int), propertyChanged: OnMaxLinesChanged);

        private static void OnMaxLinesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            int maxLines = (int)newValue;
            if (maxLines > 0)
            {
                view.Effects.Add(new LabelMaxLinesEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is LabelMaxLinesEffect);
                if (toRemove != null)
                {
                    view.Effects.Remove(toRemove);
                }
            }
        }

        public static int GetMaxLines(BindableObject view)
        {
            return (int)view.GetValue(MaxLinesProperty);
        }

        public static void SetMaxLines(BindableObject view, int value)
        {
            view.SetValue(MaxLinesProperty, value);
        }
    }

    class LabelMaxLinesEffect : RoutingEffect
    {
        public LabelMaxLinesEffect() : base("ZShoppe.Client.Common.Presentation.Effects.LabelMaxLinesEffect")
        {
        }
    }
}
