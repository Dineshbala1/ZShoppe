using System.Linq;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZShoppe.Client.Common.Presentation.Effects;
using ZShoppe.Client.Droid.Effects;
using View = Android.Views.View;

[assembly: ExportEffect(typeof(AndroidViewLifecycleEffect), "AndroidViewLifecycleEffect")]
namespace ZShoppe.Client.Droid.Effects
{
    public class AndroidViewLifecycleEffect : PlatformEffect
    {
        private View _nativeView;
        private ViewLifecycleEffect _viewLifecycleEffect;

        protected override void OnAttached()
        {
            _viewLifecycleEffect = Element.Effects.OfType<ViewLifecycleEffect>().FirstOrDefault();

            _nativeView = Control ?? Container;
            _nativeView.ViewAttachedToWindow += OnViewAttachedToWindow;
            _nativeView.ViewDetachedFromWindow += OnViewDetachedFromWindow;
        }

        protected override void OnDetached()
        {
            View view = Control ?? Container;
            _viewLifecycleEffect.RaiseUnloaded(Element);
            _nativeView.ViewAttachedToWindow -= OnViewAttachedToWindow;
            _nativeView.ViewDetachedFromWindow -= OnViewDetachedFromWindow;
        }

        private void OnViewAttachedToWindow(object sender, View.ViewAttachedToWindowEventArgs e) => _viewLifecycleEffect?.RaiseLoaded(Element);
        private void OnViewDetachedFromWindow(object sender, View.ViewDetachedFromWindowEventArgs e) => _viewLifecycleEffect?.RaiseUnloaded(Element);
    }
}