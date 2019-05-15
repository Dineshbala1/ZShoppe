using System;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Controls
{
    public class AnimatedLabel : Label
    {
        private bool _animated;

        public AnimatedLabel()
        {
            TranslationY = -100;
        }

        private async void LoadedEffect_Loaded(object sender, EventArgs e)
        {
            if (!_animated)
            {
                await this.TranslateTo(0, 0);
                _animated = true;
            }
        }
    }
}
