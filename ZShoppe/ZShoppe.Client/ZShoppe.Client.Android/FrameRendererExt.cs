using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZShoppe.Client.Droid;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;

[assembly: ExportRenderer(typeof(Frame), typeof(FrameRendererExt))]
namespace ZShoppe.Client.Droid
{
    class FrameRendererExt : FrameRenderer
    {
        public FrameRendererExt(Context context) : base(context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                
            }
        }
    }
}