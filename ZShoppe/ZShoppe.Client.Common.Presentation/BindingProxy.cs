using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ZShoppe.Client.Common.Presentation
{
    public class BindingProxy : BindableObject
    {
        public static readonly BindableProperty DataProperty =
            BindableProperty.Create("Data", typeof(object), typeof(BindingProxy));

        public object Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static double AppWidth = 0;
        public static double AppHeight = 0;
    }
}
