using FNVCB.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FNVCB.VIEW
{
    /// <summary>
    /// Interaction logic for Input_view.xaml
    /// </summary>
    public partial class Input_View : UserControl
    {
        public Input_View()
        {
            InitializeComponent();
        }
        private static readonly Regex _score_re = new Regex("[0-9]+"); //regex that matches disallowed text
        private static readonly Regex _invalid_text_re = new Regex("[^a-zA-Z]+"); //regex that matches disallowed text
        private void PreviewScoreInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsScoreAllowed(e.Text);
        }
        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static bool IsScoreAllowed(string text)
        {
            return _score_re.IsMatch(text);
        }
        private static bool IsTextAllowed(string text)
        {
            return !_invalid_text_re.IsMatch(text);
        }

        private void IgnoreSpaceKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox != null)
            {
                // Preserve caret position
                int caretPosition = textBox.CaretIndex;

                // Update the text to uppercase
                textBox.Text = textBox.Text.ToUpper();

                // Restore caret position
                textBox.CaretIndex = caretPosition;
            }
        }
    }
}
