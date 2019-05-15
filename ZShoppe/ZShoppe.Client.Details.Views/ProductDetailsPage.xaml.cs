using Xamarin.Forms;

namespace ZShoppe.Client.Details.Views
{
    public partial class ProductDetailsPage
	{
		public ProductDetailsPage ()
		{
			InitializeComponent ();
		}

	    private bool _animationInProgress;

	    private async void ProductScrollview_OnScrolled(object sender, ScrolledEventArgs e)
	    {
	        if (e.ScrollY + ProductScrollview.Height > (ProductScrollview.ContentSize.Height * 0.75))
	        {
	            if (BuyButton.IsVisible && !_animationInProgress)
	            {
	                _animationInProgress = true;
	                BuyBottomButton.IsVisible = true;
                    await BuyButton.TranslateTo(0, 300, 500, Easing.CubicOut)
	                    .ContinueWith(task =>
	                    {
	                        Device.BeginInvokeOnMainThread(() =>
	                        {
	                            BuyButton.IsVisible = false;
	                            _animationInProgress = false;
	                        });
	                    });
                }
	        }
	        else if(e.ScrollY + ProductScrollview.Height < (ProductScrollview.ContentSize.Height * 0.75))
	        {
	            if (!BuyButton.IsVisible && !_animationInProgress)
	            {
	                _animationInProgress = true;
	                BuyBottomButton.IsVisible = false;
	                BuyButton.IsVisible = true;
                    await BuyButton.TranslateTo(0, 0, 500, Easing.CubicIn).ContinueWith(task =>
	                {
	                    Device.BeginInvokeOnMainThread(() =>
	                    {
	                        _animationInProgress = false;
	                    });
	                });
                }
	        }

	    }
	}
}