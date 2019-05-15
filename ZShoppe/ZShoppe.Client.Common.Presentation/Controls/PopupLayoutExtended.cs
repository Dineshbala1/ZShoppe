using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Controls
{
    public class PopupLayoutExtended : PopupView
    {
        public PopupLayoutExtended()
        {
            ShowCloseButton = false;
            ShowFooter = false;
            this.PropertyChanged += PopupLayoutExtended_PropertyChanged;
        }

        private void PopupLayoutExtended_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Parent")
            {
                (Parent as SfPopupLayout)?.Show();
            }
        }
    }
}
