using Prism.Events;
using Prism.Navigation;
using Xamarin.Forms;
using ZShoppe.Client.Common.Contracts.PubSubEvents;

namespace ZShoppe.Client.Common.Presentation.Pages
{
    public class CustomMasterDetailPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public CustomMasterDetailPage(IEventAggregator eventAggregator)
        {
            IsPresentedChanged += CustomMasterDetailPage_IsPresentedChanged;
            eventAggregator.GetEvent<ShowHideMenuEvent>().Subscribe(ChangeIsPresented);
        }

        private void ChangeIsPresented()
        {
            IsPresented = !IsPresented;
        }

        private void CustomMasterDetailPage_IsPresentedChanged(object sender, System.EventArgs e)
        {
            
        }

        public bool IsPresentedAfterNavigation => false;
    }
}
