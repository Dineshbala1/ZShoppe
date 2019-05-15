using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation.Controls
{
    public class TabletListView : SfListView
    {
        public TabletListView()
        {

            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.TV ||
                Device.Idiom == TargetIdiom.Desktop)
            {

                LayoutManager = new GridLayout {SpanCount = (int) BindingProxy.AppWidth / 480};

            }

        }
    }
}
