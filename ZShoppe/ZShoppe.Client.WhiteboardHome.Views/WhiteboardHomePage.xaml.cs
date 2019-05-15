using Prism.Events;
using Xamarin.Forms.Xaml;
using ZShoppe.Client.Common.Presentation.Pages;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace ZShoppe.Client.WhiteboardHome.Views
{
	public partial class WhiteboardHomePage : CustomMasterDetailPage
	{
		public WhiteboardHomePage(IEventAggregator eventAggregator):base(eventAggregator)
		{
			InitializeComponent ();
		}
	}
}