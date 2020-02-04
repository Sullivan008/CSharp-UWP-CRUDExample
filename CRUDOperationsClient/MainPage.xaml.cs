using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace CRUDOperationsClient
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        #region EVENTS

        private void NumericTextBox_OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            sender.Text = new string(sender.Text.Where(char.IsDigit).ToArray());
            sender.Select(sender.Text.Length, 0);
        }

        #endregion
    }
}
