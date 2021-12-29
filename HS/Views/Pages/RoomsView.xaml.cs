using System;
using System.Windows.Controls;

namespace HS.Views.Pages
{
    public partial class RoomsView : UserControl
    {
        public RoomsView()
        {
            InitializeComponent();
        }

        private void MinPriceTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (MinPriceTextBox.Text == "") MinPriceTextBox.Text = "1";
            if (Convert.ToInt32(MinPriceTextBox.Text) <= 0) MinPriceTextBox.Text = "1";
        }

        private void MaxPriceTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (MaxPriceTextBox.Text == "") MaxPriceTextBox.Text = "1";
            if (Convert.ToInt32(MaxPriceTextBox.Text) <= 0) MaxPriceTextBox.Text = "1";
        }

        private void MinCapacityTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (MinCapacityTextBox.Text == "") MinCapacityTextBox.Text = "1";
            if (Convert.ToInt32(MinCapacityTextBox.Text) <= 0) MinCapacityTextBox.Text = "1";
        }

        private void MaxCapacityTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (MaxCapacityTextBox.Text == "") MaxCapacityTextBox.Text = "1";
            if (Convert.ToInt32(MaxCapacityTextBox.Text) <= 0) MaxCapacityTextBox.Text = "1";
        }

        private void PeriodsAmountTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (PeriodsAmountTextBox.Text == "") PeriodsAmountTextBox.Text = "1";
            if (Convert.ToInt32(PeriodsAmountTextBox.Text) <= 0) PeriodsAmountTextBox.Text = "1";
        }
    }
}