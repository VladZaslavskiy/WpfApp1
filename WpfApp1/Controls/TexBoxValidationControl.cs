using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Controls
{
    class TexBoxValidationControl : Control
    {
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register
            (
                "Text", 
                typeof(string), 
                typeof(TexBoxValidationControl),
                new PropertyMetadata(string.Empty,
                    new PropertyChangedCallback(OnTextChanged))
            );

        public void Clear()
        {
            Text = string.Empty;
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = (TexBoxValidationControl)d;
            c.Text = e.NewValue?.ToString();
        }
    }
}
