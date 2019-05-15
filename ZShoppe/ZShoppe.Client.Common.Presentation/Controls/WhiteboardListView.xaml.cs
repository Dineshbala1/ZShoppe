using System;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Controls
{
    public partial class WhiteboardListView
    {
        public WhiteboardListView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(WhiteboardListView), null,
                propertyChanged:
                (bindable, value, newValue) =>
                {
                    (bindable as WhiteboardListView).SfListView.ItemTemplate = (DataTemplate)newValue;
                });

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
    }
}