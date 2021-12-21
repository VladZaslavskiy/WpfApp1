using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Controls
{
    public class TextBoxButtonControl : Control
    {
        public string FildText
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register
            (
                "FildText", 
                typeof(string), 
                typeof(TextBoxButtonControl),
                new PropertyMetadata(string.Empty,
                    new PropertyChangedCallback(OnTextChanged))
            );

        public void Clear()
        {
            FildText = string.Empty;
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = (TextBoxButtonControl)d;
            c.FildText = e.NewValue?.ToString();
        }
    }
}
