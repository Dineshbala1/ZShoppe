using System;
using System.Collections;
using System.Linq;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Controls
{
    public class GridBindable : Grid
    {

        private bool _isDirty;
        private readonly int _columnCount;

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(GridBindable), null, propertyChanged: ItemsSourceChanged);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(GridBindable));

        public static readonly BindableProperty ItemTemplateSelectorProperty =
            BindableProperty.Create(nameof(ItemTemplateSelector), typeof(DataTemplateSelector), typeof(GridBindable));

        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create(nameof(OrientationProperty), typeof(Orientation), typeof(GridBindable),
                Orientation.Vertical);

        public Orientation Orientation
        {
            get => (Orientation) GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public DataTemplateSelector ItemTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
            set { SetValue(ItemTemplateSelectorProperty, value); }
        }

        public GridBindable()
        {
            RowSpacing = 0;
            ColumnSpacing = 0;
            _columnCount = Device.Idiom == TargetIdiom.Phone ? 2 : 3;
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, EventArgs eventArgs)
        {
            if (Width > 0 && ItemsSource != null && !_isDirty)
            {
                Children.Clear();
                Add(ItemsSource);
            }
        }

        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is GridBindable grid))
            {
                return;
            }

            grid.Children.Clear();
            grid._isDirty = false;
            if (newValue != null)
            {
                grid.Add(newValue as IEnumerable);
            }
        }
       
        private void Add(IEnumerable items)
        {
            var itemsEnumerable = items.Cast<Object>();

            var enumerable = itemsEnumerable as object[] ?? itemsEnumerable.ToArray();
            if (Orientation == Orientation.Horizontal)
            {
                if (Width > 0)
                {
                    var columnSize = (Width / _columnCount);

                    for (int i = 0; i < _columnCount; i++)
                    {
                        ColumnDefinitions.Add(new ColumnDefinition() { Width = columnSize });
                    }

                    var rowCount = enumerable.Count() / _columnCount;

                    for (int i = 0; i < rowCount; i++)
                    {
                        RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
                    }

                    int currentcolumn = 0;
                    int currentRow = 0;
                    for (var i = 0; i < enumerable.Count(); i++)
                    {
                        var v = GetChild(enumerable.ElementAt(i));

                        if (currentcolumn > _columnCount - 1)
                        {
                            currentcolumn = 0;
                            currentRow += 1;
                        }

                        Children.Add(v, currentcolumn, currentRow);
                        currentcolumn++;
                    }

                    _isDirty = true;
                }
            }
            else
            {
                for (int i = 0; i < enumerable.Count(); i++)
                {
                    RowDefinitions.Add(new RowDefinition() {Height = GridLength.Auto});
                }

                var widht = Width;

                for (var i = 0; i < enumerable.Count(); i++)
                {
                    var v = GetChild(enumerable.ElementAt(i));

                    Children.Add(v, 0, i);
                }
            }
        }

        private View GetChild(object data)
        {
            object child = null;
            if (ItemTemplate != null || ItemTemplateSelector != null)
            {
                if (ItemTemplateSelector != null)
                {
                    child = ItemTemplateSelector.SelectTemplate(data, this).CreateContent();
                }
                else if (ItemTemplate != null)
                {
                    child = ItemTemplate.CreateContent();
                }

                View view = null;
                if (child is View contentview)
                {
                    view = contentview;
                }
                else if (child is ViewCell viewCell)
                {
                    view = viewCell.View;
                }
                if (view == null)
                {
                    throw new InvalidOperationException($"No item template for child {data}");
                }
                view.BindingContext = data;
                return view;
            }
            throw new InvalidOperationException($"No item template for child {data}");

        }
    }

    public enum Orientation
    {
        Horizontal=0,
        Vertical
    }
}
