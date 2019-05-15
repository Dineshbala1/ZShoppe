using System.Linq;
using Android.Graphics.Drawables;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZShoppe.Client.Common.Presentation.Effects;
using SelectionEffect = ZShoppe.Client.Droid.Effects.SelectionEffect;
using View = Android.Views.View;

[assembly: ExportEffect(typeof(SelectionEffect), "SelectionEffect")]
namespace ZShoppe.Client.Droid.Effects
{
    public class SelectionEffect : PlatformEffect
    {
        private Xamarin.Forms.View _element;

        protected override void OnAttached()
        {
            var colors = new int[] { Android.Graphics.Color.ParseColor("#56ab2f"), Android.Graphics.Color.ParseColor("#a8e063") };
            var drawable = new GradientDrawable(GradientDrawable.Orientation.RightLeft, colors);

            if (Control == null)
            {
                if (Container != null)
                {
                    //TODO:https://uigradients.com/#Lush                    
                    Container.SetBackgroundDrawable(drawable);
                   //Container.Touch += ControlOnTouch;
                }
            }
            else
            {
                //Control.SetBackgroundDrawable(drawable);
                Control.Touch += ControlOnTouch;
            }

            _element = Element as Xamarin.Forms.View;
        }

        private void ControlOnTouch(object sender, View.TouchEventArgs touchEventArgs)
        {
            if (touchEventArgs.Event.Action == MotionEventActions.Down)
            {
                _element.ScaleTo(0.95, 50, Easing.CubicOut);
            }
            else if (touchEventArgs.Event.Action == MotionEventActions.Cancel)
            {
                _element.ScaleTo(1, 50, Easing.CubicIn);
            }
            else if (touchEventArgs.Event.Action == MotionEventActions.Up)
            {
                _element.ScaleTo(1, 50, Easing.CubicIn);
                var tapGesture = _element.GestureRecognizers.FirstOrDefault(row => row is TapGestureRecognizer);
                if (tapGesture is TapGestureRecognizer gesture)
                {
                    gesture.Command?.Execute(gesture.CommandParameter);
                }
                else if (_element is Button btn)
                {
                    if (btn.Command != null && btn.Command.CanExecute(btn.CommandParameter))
                    {
                        btn.Command.Execute(btn.CommandParameter);
                    }
                }
                else
                {
                    
                }
            }
        }

        protected override void OnDetached()
        {
            if (Control == null)
            {
                if (Container != null)
                    Container.Touch -= ControlOnTouch;
            }
            else
                Control.Touch -= ControlOnTouch;
        }
    }
}