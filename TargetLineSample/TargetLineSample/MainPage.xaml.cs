using Syncfusion.Maui.Charts;

namespace TargetLineSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Y_Axis == null) return;
            var maxValue = Y_Axis.Maximum;
            
            if (sender is Entry entry)
            {
                if (string.IsNullOrWhiteSpace(entry.Text))
                {
                    entry.Text = string.Empty;
                }
                else
                {
                    if (double.TryParse(e.NewTextValue, out double newValue))
                    {
                        if (newValue > maxValue)
                        {
                            entry.Text = e.OldTextValue;
                        }
                    }
                    else
                    {
                        entry.Text = e.OldTextValue;
                    }
                }
            }
        }
    }

}
