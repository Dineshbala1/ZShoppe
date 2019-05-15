using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Controls
{
    public partial class ProductView
    {
        public ProductView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ParentContextProperty = BindableProperty.Create(nameof(ParentContext), typeof(object), typeof(ProductView), propertyChanged:
            (bindable, value, newValue) =>
            {
                if (newValue != value)
                {
                    ((ProductView)bindable).AddToCartButton.BindingContext = newValue;
                }
            });

        public object ParentContext
        {
            get => GetValue(ParentContextProperty);
            set => SetValue(ParentContextProperty, value);
        }
    }
}