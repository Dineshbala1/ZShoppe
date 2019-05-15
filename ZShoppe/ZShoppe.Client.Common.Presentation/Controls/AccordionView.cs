using System.Collections;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Controls
{
    public class AccordionView : ScrollView
    {
        private readonly StackLayout _layout = new StackLayout {Spacing = 1};

        public DataTemplate Template { get; set; }
        public DataTemplate SubTemplate { get; set; }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(AccordionView));

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                propertyName: "ItemsSource",
                returnType: typeof(IList),
                declaringType: typeof(AccordionSectionView),
                defaultValue: default(IList),
                propertyChanged: PopulateList);

        public IList ItemsSource
        {
            get => (IList) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public AccordionView()
        {

        }

        void PopulateList()
        {
            _layout.Children.Clear();

            foreach (object item in ItemsSource)
            {
                var template = (View) Template.CreateContent();
                template.BindingContext = item;
                _layout.Children.Add(template);
            }
        }

        static void PopulateList(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue)
                return;
            if (bindable is AccordionView aView)
            {
                aView.SubTemplate = aView.ItemTemplate;
                aView.Template = new DataTemplate(() => new AccordionSectionView(aView.ItemTemplate, aView) as object);
                aView.Content = aView._layout;
                aView.PopulateList();
            }
        }
    }

    public class AccordionSectionView : StackLayout
    {
        private bool _isExpanded = false;
        private readonly StackLayout _content = new StackLayout { HeightRequest = 0 };
        private readonly Color _headerColor = Color.FromHex("0067B7");
        private readonly ImageSource _arrowRight = ImageSource.FromFile("ic_keyboard_arrow_right_white_24dp.png");
        private readonly ImageSource _arrowDown = ImageSource.FromFile("ic_keyboard_arrow_down_white_24dp.png");
        private readonly AbsoluteLayout _header = new AbsoluteLayout();
        private readonly Image _headerIcon = new Image { VerticalOptions = LayoutOptions.Center };
        private readonly Label _headerTitle = new Label { TextColor = Color.White, VerticalTextAlignment = TextAlignment.Center, HeightRequest = 50 };
        private readonly DataTemplate _template;

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                propertyName: "ItemsSource",
                returnType: typeof(IList),
                declaringType: typeof(AccordionSectionView),
                defaultValue: default(IList),
                propertyChanged: PopulateList);

        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
                propertyName: "Title",
                returnType: typeof(string),
                declaringType: typeof(AccordionSectionView),
                propertyChanged: ChangeTitle);

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public AccordionSectionView(DataTemplate itemTemplate, ScrollView parent)
        {
            _template = itemTemplate;
            _headerTitle.BackgroundColor = _headerColor;
            _headerIcon.Source = _arrowRight;
            _header.BackgroundColor = _headerColor;

            _header.Children.Add(_headerIcon, new Rectangle(0, 1, .1, 1), AbsoluteLayoutFlags.All);
            _header.Children.Add(_headerTitle, new Rectangle(1, 1, .9, 1), AbsoluteLayoutFlags.All);

            Spacing = 0;
            Children.Add(_header);
            Children.Add(_content);

            _header.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = new Command(async () =>
                    {
                        if (_isExpanded)
                        {
                            _headerIcon.Source = _arrowRight;
                            _content.HeightRequest = 0;
                            _content.IsVisible = false;
                            _isExpanded = false;
                        }
                        else
                        {
                            _headerIcon.Source = _arrowDown;
                            _content.HeightRequest = _content.Children.Count * 50;
                            _content.IsVisible = true;
                            _isExpanded = true;

                            // Scroll top by the current Y position of the section
                            if (parent.Parent is VisualElement)
                            {
                                await parent.ScrollToAsync(0, Y, true);
                            }
                        }
                    })
                }
            );
        }

        void ChangeTitle()
        {
            _headerTitle.Text = Title;
        }

        void PopulateList()
        {
            _content.Children.Clear();

            foreach (object item in ItemsSource)
            {
                var template = (View)_template.CreateContent();
                template.BindingContext = item;
                _content.Children.Add(template);
            }
        }

        static void ChangeTitle(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue) return;
            ((AccordionSectionView)bindable).ChangeTitle();
        }

        static void PopulateList(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue) return;
            ((AccordionSectionView)bindable).PopulateList();
        }
    }
}
