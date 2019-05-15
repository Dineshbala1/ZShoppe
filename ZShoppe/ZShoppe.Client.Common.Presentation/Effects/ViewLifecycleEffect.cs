using System;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Effects
{
    public class ViewLifecycleEffect : RoutingEffect
    {
        public event EventHandler<EventArgs> Loaded;
        public event EventHandler<EventArgs> Unloaded;

        public ViewLifecycleEffect() : base("ZShoppe.Client.Common.Presentation.Effects.ViewLifecycleEffect") { }

        public void RaiseLoaded(Element element) => Loaded?.Invoke(element, EventArgs.Empty);
        public void RaiseUnloaded(Element element) => Unloaded?.Invoke(element, EventArgs.Empty);
    }
}
